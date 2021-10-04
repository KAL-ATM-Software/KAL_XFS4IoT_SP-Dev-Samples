/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using XFS4IoT;
using System.Linq;
using System.Threading;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.CardReader.Commands;
using XFS4IoT.CardReader.Completions;
using XFS4IoT.CashDispenser.Commands;
using XFS4IoT.CashDispenser.Completions;
using XFS4IoTClient;
using System.Text.RegularExpressions;

namespace TestClient
{
    class TestClient
    {
        static async Task Main(string[] args) => await new TestClient().Run(args);
        private async Task Run(string[] args)
        {
            try
            {
                Logger.LogLine("Running test XFS4IoT application.");

                bool ShowJSON = false;
                int ParallelCount = 1;
                bool waitForUnsolic = false; 
                foreach (var (name, value) in from p in args
                                              let m = paramRegex.Match(p)
                                              select (m.Groups["name"].Value, m.Groups["value"].Value))
                {
                    switch (name.ToLower())
                    {
                        case "parallelcount" or "count"  : 
                            if( !int.TryParse(value, out ParallelCount ) ) 
                                throw new Exception($"Invalid parallel count {value}");
                            break;
                        case "address"  : Address = value; break;
                        case "showjson" :
                            if (string.IsNullOrEmpty(value))
                                ShowJSON = true;
                            else if (bool.TryParse(value, out bool bValue))
                                ShowJSON = bValue;
                            else 
                                throw new Exception($"Invalid value {value}");
                            break;
                        case "waitforunsolic": waitForUnsolic = true; break;

                        default: throw new Exception($"unknown parameter{name}");
                    }
                }

                Logger.WriteJSON = ShowJSON; 

                Logger.LogLine("Doing service discovery.");
                await DoServiceDiscovery();
                if( cardReader == null )
                {
                    Logger.LogError("No card reader found");
                    return;
                }

                // The test sequence - may be run multiple times. 
                async Task DoCardReader()
                {
                    Logger.LogLine("Doing card reader sequence");
                    await GetStatus(cardReader);

                    await DoAcceptCard(cardReader);
                    await DoChipIO(cardReader);
                    await DoChipPower(cardReader);
                    await DoReset(cardReader);
                    await DoRetainCard(cardReader);
                    await DoResetCount(cardReader);
                    await DoSetKey(cardReader);
                    await DoWriteData(cardReader);
                    await DoQueryIFMIdentifier(cardReader);
                    await DoParkCard(cardReader);
                    await DoEjectCard(cardReader);
                }

                async Task DoCashDispenser()
                {
                    Logger.LogLine("Doing cash dispenser sequence");

                    await DoClearCommandNonce();

                    string nonce = await DoGetCommandNonce();
                    Logger.LogLine($"Nonce : {nonce}");
                    nonce = await DoGetCommandNonce();
                    Logger.LogLine($"Nonce : {nonce}");

                    Logger.LogLine("Dispense (valid token)");
                    string token = MakeToken(nonce, true);
                    Logger.LogLine($"Token: {token}");
                    await DoDispenseCash(100, "EUR", token);

                    await DoPresentCash();

                    Logger.LogLine("Dispense (Stale token)");
                    token = MakeToken(nonce, true);
                    Logger.LogLine($"Token: {token}");
                    await DoDispenseCash(100, "EUR", token);

                    Logger.LogLine("Dispense (Invalid HMAC)");
                    token = MakeToken(nonce, false);
                    Logger.LogLine($"Invalid HMAC: {token}");
                    await DoDispenseCash(100, "EUR", token);

                    Logger.LogLine("Dispense (Invalid nonce)");
                    token = MakeToken("FFFF", true);
                    Logger.LogLine($"Invalid nonce: {token}");
                    await DoDispenseCash(100, "EUR", token);
                }

                async Task DoAll()
                {
                    await DoCardReader();
                    await DoCashDispenser(); 
                }

                await Task.WhenAll(from i in Enumerable.Range(1, ParallelCount)
                                   select DoAll() );

                Logger.LogLine($"Done");

                if (waitForUnsolic)
                {
                    Logger.LogLine("Listening for unsolicited messages."); 
                    while (true)
                    {
                        Logger.LogMessage(await cardReader.ReceiveMessageAsync());
                    }
                }
            }
            catch (WebSocketException e)
            {
                Logger.LogError($"Connection error {e.Message}");
                System.Diagnostics.Debugger.Break();
            }
            catch (Exception e)
            {
                Logger.LogError($"Unhandled exception: {e.Message}");
                System.Diagnostics.Debugger.Break();
            }
        }

        private static string MakeToken(string nonce, bool valid)
        {
            // 'valid' or invalid HMAC. 
            var HMAC = valid ? "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2"
                             : "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F3";

            var tokenBuilder = new System.Text.StringBuilder($"NONCE={nonce},TOKENFORMAT=1,TOKENLENGTH=$$$$,ANOTHERKEY=12345,HMACSHA256={HMAC}");

            // The token length field is fix at four digits to make it easy to calculate. 
            // Inject this into the string. 
            var len = $"{tokenBuilder.Length:X4}";
            tokenBuilder = tokenBuilder.Replace("$$$$", len);

            string token = tokenBuilder.ToString();
            return token;
        }

        private static readonly Regex paramRegex = new("^[/-](?<name>.*?)(?:[=:](?<value>.*))?$");

        private readonly ConsoleLogger Logger = new();
        private string Address { get; set; } = "localhost";

        private async Task DoServiceDiscovery()
        {
            // Do service discovery on all of the ports, in parallel.
            // (Flatten this to an array, or we'll re-run the DoServiceDiscovery() every time we enumerate
            var tasks = from port in XFSConstants.PortRanges select DoServiceDiscovery(port); 
            await Task.WhenAll(tasks);
        }
        // Do service discovery on a single port. 
        private async Task DoServiceDiscovery(int port)
        {
            var publisher = new ClientConnection(
                    EndPoint: new Uri($"ws://{Address}:{port}/xfs4iot/v1.0")
                    );

            try
            {
                await publisher.ConnectAsync();
            }
            catch(WebSocketException e) when (e.HResult == -0x7FFFBFFB)
            {
                Logger.LogLine($"No responce on port {port}");
                return;
            }
            catch (Exception e)
            {
                Logger.LogLine($"Caught exception : {e}");
                throw;
            }

            Logger.LogLine($"Publisher responce on port {port}");

            var command = new GetServicesCommand(RequestId.NewID(),
                                                    new GetServicesCommand.PayloadData(60000));
            Logger.LogMessage(command);
            await publisher.SendCommandAsync(command);
            var response = await GetCompletionAsync<GetServicesCompletion>(publisher);
            await FindServices(response.Payload);
        }

        private async Task FindServices(GetServicesCompletion.PayloadData endpointDetails)
        {
            Logger.LogLine($"Services:\n{string.Join("\n", from ep in endpointDetails.Services select ep.ServiceURI)}");

            async Task<(CapabilitiesCompletion capabilities, ClientConnection connection, Uri Uri)> GetServiceDetails( Uri ServiceURI )
            {
                ClientConnection service = await OpenService(ServiceURI);
                CapabilitiesCompletion caps = await GetCapabilities(service);
                return (caps, service, ServiceURI); 
            }

            // We want to do the query for the capabilities in parallel for each service to speed things up. 
            // So we create all the async 'GetServiceDetails' tasks as a group and then wait for them all to finish.  
            var services = (from ep in endpointDetails.Services.Skip(1)
                            let uri = new Uri(ep.ServiceURI)
                            select (Uri: uri, task: GetServiceDetails(uri))
                          ).ToArray();

            await Task.WhenAll(from t in services select t.task );

            // Once we've queried all the capabilities we can find which ones are actually each service class. 
            var( cardService, cardUri ) = (
                              from details in services
                              let caps = details.task.Result.capabilities.Payload
                              where caps.CardReader != null && caps.CardReader.Type == XFS4IoT.CardReader.CapabilitiesClass.TypeEnum.Motor
                              select (details.task.Result.connection, details.task.Result.Uri )
                              )
                              .FirstOrDefault();
            cardReader = cardService ?? throw new Exception($"Failed to find a card reader");
            Logger.LogLine($"Found a card reader: {cardUri }");

            var (dispService, dispenserUri) = (
                              from details in services
                              let caps = details.task.Result.capabilities.Payload
                              where caps.CashDispenser != null && caps.CashDispenser.Type == XFS4IoT.CashDispenser.CapabilitiesClass.TypeEnum.SelfServiceBill
                              select (details.task.Result.connection, details.task.Result.Uri)
                              )
                              .FirstOrDefault();
            cashDispenser = dispService ?? throw new Exception($"Failed to find a cash dispenser");
            Logger.LogLine($"Found a cash dispenser: {dispenserUri}");
        }

        private ClientConnection cardReader;
        private ClientConnection cashDispenser; 

        private static async Task<ClientConnection> OpenService(Uri service)
        {
            // Create the connection object. This doesn't start anything...  
            ClientConnection connection
                = new ClientConnection(
                    EndPoint: service
                    );

            // Open the actual network connection, with a timeout. 
            var cancel = new CancellationTokenSource();
            cancel.CancelAfter(10_000);
            await connection.ConnectAsync(cancel.Token);

            return connection; 
        }

        private async Task<StatusCompletion> GetStatus(ClientConnection service)
        {

            // Create a new command and send it to the device
            var command = new StatusCommand(RequestId.NewID(), new StatusCommand.PayloadData(Timeout: 1_000));
            Logger.LogMessage(command);
            await service.SendCommandAsync(command);

            return await GetCompletionAsync<StatusCompletion>(service);
        }

        private async Task<CapabilitiesCompletion> GetCapabilities(ClientConnection service)
        {

            // Create a new command and send it to the device
            var command = new CapabilitiesCommand(RequestId.NewID(), new CapabilitiesCommand.PayloadData(Timeout: 1_000));
            Logger.LogMessage(command);
            await service.SendCommandAsync(command);

            return await GetCompletionAsync<CapabilitiesCompletion>(service);
        }


        private async Task DoAcceptCard(ClientConnection cardReader)
        {

            // Create a new command and send it to the device
            var command = new ReadRawDataCommand(RequestId.NewID(),
                                                 new ReadRawDataCommand.PayloadData(
                                                        60_000,
                                                        Track1: true,
                                                        Track2: true,
                                                        Track3: true,
                                                        Chip: true,
                                                        Security: false,
                                                        FluxInactive: false,
                                                        Watermark: false,
                                                        MemoryChip: false,
                                                        Track1Front: false,
                                                        FrontImage: false,
                                                        BackImage: false,
                                                        Track1JIS: false,
                                                        Track3JIS: false,
                                                        Ddi: false));
            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ReadRawDataCompletion>(cardReader);
        }

        private async Task DoChipIO(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ChipIOCommand(RequestId.NewID(),
                new ChipIOCommand.PayloadData(10_0000, "chipT0", Convert.ToBase64String(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7 })));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ChipIOCompletion>(cardReader);
        }

        private async Task DoChipPower(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ChipPowerCommand(RequestId.NewID(),
                new ChipPowerCommand.PayloadData(10_000, ChipPowerCommand.PayloadData.ChipPowerEnum.Warm));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ChipPowerCompletion>(cardReader);
        }

        private async Task DoReset(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new XFS4IoT.CardReader.Commands.ResetCommand
                            (
                            RequestId: RequestId.NewID(),
                            Payload:    new 
                                        (
                                        Timeout: 10_000, 
                                        ResetIn: XFS4IoT.CardReader.Commands.ResetCommand.PayloadData.ResetInEnum.Eject
                                        )
                            );

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<XFS4IoT.CardReader.Completions.ResetCompletion>(cardReader);
        }

        private async Task DoRetainCard(ClientConnection cardReader)
        {
            Logger.LogLine("Doing AcceptCard before RetainCard.");
            await DoAcceptCard(cardReader);

            // Create a new command and send it to the device
            var command = new RetainCardCommand(RequestId.NewID(),
                new RetainCardCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<RetainCardCompletion>(cardReader);
        }

        private async Task DoResetCount(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ResetCountCommand(RequestId.NewID(),
                new ResetCountCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ResetCountCompletion>(cardReader);
        }

        private async Task DoSetKey(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new SetKeyCommand(RequestId.NewID(),
                new SetKeyCommand.PayloadData(10_000, Convert.ToBase64String(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7 })));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<SetKeyCompletion>(cardReader);
        }

        private async Task DoWriteData(ClientConnection cardReader)
        {
            Logger.LogLine("Doing AcceptCard before WriteData.");
            await DoAcceptCard(cardReader);

            // Create a new command and send it to the device
            var command = new WriteRawDataCommand(RequestId.NewID(),
                new WriteRawDataCommand.PayloadData(10_000, new()
                {
                    new(WriteRawDataCommand.PayloadData.DataClass.DestinationEnum.Track1, "12345678", WriteRawDataCommand.PayloadData.DataClass.WriteMethodEnum.Auto),
                    new(WriteRawDataCommand.PayloadData.DataClass.DestinationEnum.Track1, "12345678", WriteRawDataCommand.PayloadData.DataClass.WriteMethodEnum.Auto),
                }));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<WriteRawDataCompletion>(cardReader);

            Logger.LogLine("Ejecting card after WriteData.");
            await DoEjectCard(cardReader);
        }

        private async Task DoQueryIFMIdentifier(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new QueryIFMIdentifierCommand(RequestId.NewID(),
                new QueryIFMIdentifierCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<QueryIFMIdentifierCompletion>(cardReader);
        }

        private async Task DoParkCard(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ParkCardCommand(RequestId.NewID(),
                new ParkCardCommand.PayloadData(10_000, ParkCardCommand.PayloadData.DirectionEnum.In, 0));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ParkCardCompletion>(cardReader);
        }
        private async Task DoEjectCard(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new EjectCardCommand(RequestId.NewID(), 
                                                new(10_000)
                                                );
            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<EjectCardCompletion>(cardReader);
        }


        private async Task<string> DoGetCommandNonce()
        {
            // Create a new command and send it to the device
            var command = new GetCommandNonceCommand(RequestId.NewID(),
                                                     Payload: new(10_000)
                                                     );
            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var responce = await GetCompletionAsync<GetCommandNonceCompletion>(cashDispenser);
            if (responce.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                throw new Exception($"GetCommandNonce failed: {responce.Payload.CompletionCode}");

            return responce.Payload.CommandNonce;
        }

        private async Task DoClearCommandNonce()
        {
            var command = new ClearCommandNonceCommand(RequestId.NewID(), Payload: new(10_000));

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var responce = await GetCompletionAsync<ClearCommandNonceCompletion>(cashDispenser);
            if (responce.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                throw new Exception($"ClearCommandNonce failed: {responce.Payload.CompletionCode}");
        }

        private async Task DoDispenseCash(int Amount, string CurrencyID, string Token)
        {
            var command = new DispenseCommand(RequestId.NewID(),
                                Payload: new(Timeout: 10_000,
                                             Denomination: new(Currencies: new() { { CurrencyID, Amount } } ), 
                                             MixNumber:1,
                                             Token: Token
                                             )
                                );

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var responce = await GetCompletionAsync<DispenseCompletion>(cashDispenser);
            if (responce.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                Logger.LogWarning($"Dispense failed: {responce.Payload.CompletionCode}");

        }

        private async Task DoPresentCash()
        {
            var command = new PresentCommand(RequestId.NewID(), Payload: new(Timeout: 10_000) );

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var responce = await GetCompletionAsync<PresentCompletion>(cashDispenser);
            if (responce.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                Logger.LogWarning($"Present failed: {responce.Payload.CompletionCode}");

        }

        private async Task<CompletionType> GetCompletionAsync<CompletionType>(ClientConnection cardReader)
        {
            while (true)
            {
                var Message = await cardReader.ReceiveMessageAsync();
                Logger.LogMessage(Message);
                if (Message is CompletionType result ) return result;
            }
        }

        /// <summary>
        /// Log to the console, including timing details. 
        /// </summary>
        private class ConsoleLogger
        {
            public ConsoleLogger()
            {
                defaultColour = Console.ForegroundColor;
            }
            public void Log(string v, ConsoleColor? colour = null)
            {
                lock (this)
                {
                    Console.ForegroundColor = colour ?? defaultColour;
                    Console.Write($"{DateTime.Now:hh:mm:ss.ffff} ({DateTime.Now - Start}): {v}");
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void Write(string v, ConsoleColor? colour = null)
            {
                lock (this)
                {
                    Console.ForegroundColor = colour ?? defaultColour;
                    Console.Write(v);
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void LogLine(string v, ConsoleColor? colour = null)
            {
                lock (this)
                {
                    Console.ForegroundColor = colour ?? defaultColour;
                    Console.WriteLine($"{DateTime.Now:hh:mm:ss.ffff} ({DateTime.Now - Start}): {v}");
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void WriteLine(string v, ConsoleColor? colour = null)
            {
                lock (this)
                {
                    Console.ForegroundColor = colour ?? defaultColour;
                    Console.WriteLine(v);
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void LogError(string v)
            {
                lock (this)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{DateTime.Now:hh:mm:ss.ffff} ({DateTime.Now - Start}): {v}");
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void LogWarning(string v)
            {
                lock (this)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{DateTime.Now:hh:mm:ss.ffff} ({DateTime.Now - Start}): {v}");
                    Console.ForegroundColor = defaultColour;
                }
            }
            public void LogMessage(object Message)
            {
                if (Message is not MessageBase msgBase)
                {
                    LogError($"Invalid type of response {Message.GetType()}");
                    return;
                }

                ConsoleColor msgColour = msgBase.Header.Type switch
                {
                    MessageHeader.TypeEnum.Command => ConsoleColor.Blue,
                    MessageHeader.TypeEnum.Acknowledgement => ConsoleColor.DarkGray,
                    MessageHeader.TypeEnum.Event => ConsoleColor.Yellow,
                    MessageHeader.TypeEnum.Completion => ConsoleColor.Green,
                    MessageHeader.TypeEnum.Unsolicited => ConsoleColor.DarkYellow,
                    _ => throw new NotImplementedException($"Unknown message type {msgBase.Header.Type}"),
                };

                var reqID = msgBase.Header?.RequestId ?? 0;

                LogMessage(reqID, Message.GetType().Name, msgColour, msgBase.Serialise());
            }

            private void LogMessage( int reqId, string name, ConsoleColor colour, string JSON )
            {
                lock(this)
                {
                    Log($"{reqId,3:d}:{name}", colour);
                    if (WriteJSON)
                        WriteLine($" : {JSON}");
                    else
                        WriteLine("");
                }
            }

            public bool WriteJSON { private get; set; } = false;

            public void Restart() => Start = DateTime.Now;

            private DateTime Start = DateTime.Now;
            private readonly ConsoleColor defaultColour;
        }
    }
}
