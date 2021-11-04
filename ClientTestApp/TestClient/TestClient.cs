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
using System.Collections.Generic;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;

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
                            ShowJSON = string.IsNullOrEmpty(value)
                                        || (bool.TryParse(value, out bool bValue) ? bValue 
                                        : throw new Exception($"Invalid value {value}"));
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
                    var connection = ParallelCount==1 ? 
                                        cardReader : 
                                        new ClientConnection(
                                            EndPoint: cardReaderURI
                                            );
                    if (!connection.IsConnected) await connection.ConnectAsync(); 

                    Logger.LogLine("Doing card reader sequence");
                    await GetStatus(connection);

                    await DoAcceptCard(connection);
                    await DoChipIO(connection);
                    await DoChipPower(connection);
                    await DoReset(connection);
                    await DoRetainCard(connection);
                    await DoSetKey(connection);
                    await DoWriteData(connection);
                    await DoQueryIFMIdentifier(connection);
                    await DoEjectCard(connection);
                }

                async Task DoCashDispenser()
                {
                    var connection = ParallelCount == 1 ?
                                        cashDispenser :
                                        new ClientConnection(
                                            EndPoint: cashDispenserURI
                                            );
                    if (!connection.IsConnected) await connection.ConnectAsync();

                    Logger.LogLine("Doing cash dispenser sequence");

                    await DoClearCommandNonce(connection);

                    await DoSetCashUnitInfo(connection);

                    string nonce = await DoGetCommandNonce(connection);
                    Logger.LogLine($"Nonce : {nonce}");
                    nonce = await DoGetCommandNonce(connection);
                    Logger.LogLine($"Nonce : {nonce}");

                    Logger.LogLine("Dispense 100EUR");
                    string token = MakeToken(nonce, "100.00EUR");
                    Logger.LogLine($"Token: {token}");
                    await DoDispenseCash(connection, 100, "EUR", token);
                    await DoPresentCash(connection);

                    Logger.LogLine("Dispense : Stale token");
                    token = MakeToken(nonce, "100.00EUR");
                    Logger.LogLine($"Token: {token}");
                    await DoDispenseCash(connection, 100, "EUR", token);

                    Logger.LogLine("Dispense : Invalid HMAC");
                    token = MakeToken(nonce, "100.00EUR", false);
                    Logger.LogLine($"Invalid HMAC: {token}");
                    await DoDispenseCash(connection, 100, "EUR", token);

                    Logger.LogLine("Dispense : Invalid nonce");
                    token = MakeToken("FFFF", "100.00EUR");
                    Logger.LogLine($"Invalid nonce: {token}");
                    await DoDispenseCash(connection, 100, "EUR", token);

                    Logger.LogLine("Dispense : Value doesn't match token");
                    token = MakeToken(await DoGetCommandNonce(connection), "100.00EUR");
                    await DoDispenseCash(connection, 200, "EUR", token);
                    await DoClearCommandNonce(connection);

                    Logger.LogLine("Dispense : Currency doesn't match token");
                    token = MakeToken(await DoGetCommandNonce(connection), "200.00EUR");
                    await DoDispenseCash(connection, 200, "GBP", token);

                    Logger.LogLine("Dispense : Dispense/Present in multiple parts");
                    token = MakeToken(await DoGetCommandNonce(connection), "300.00EUR");
                    await DoDispenseCash(connection, 100, "EUR", token);
                    await DoPresentCash(connection);
                    await DoDispenseCash(connection, 100, "EUR", token);
                    await DoPresentCash(connection);
                    await DoDispenseCash(connection, 100, "EUR", token);
                    await DoPresentCash(connection);
                    await DoDispenseCash(connection, 100, "EUR", token); // Invalid Token
                }

                async Task DoAll()
                {
                    //await DoCardReader();
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

        private static string MakeToken(string nonce, string Value, bool valid=true)
        {
            // 'valid' or invalid HMAC. 
            var HMAC = valid ? "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2"
                             : "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F3";

            var tokenBuilder = new System.Text.StringBuilder($"NONCE={nonce},TOKENFORMAT=1,TOKENLENGTH=$$$$,DISPENSE1={Value},ANOTHERKEY=12345,HMACSHA256={HMAC}");

            // The token length field is fix at four digits to make it easy to calculate. 
            // Inject this into the string. 
            var len = $"{tokenBuilder.Length:X4}";
            tokenBuilder = tokenBuilder.Replace("$$$$", len);

            return tokenBuilder.ToString();
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
                Logger.LogLine($"No response on port {port}");
                return;
            }
            catch (Exception e)
            {
                Logger.LogLine($"Caught exception : {e}");
                throw;
            }

            Logger.LogLine($"Publisher response on port {port}");

            var command = new GetServicesCommand(RequestId.NewID(),
                                                 Payload: new(Timeout: 60000));
            Logger.LogMessage(command);
            await publisher.SendCommandAsync(command);
            var response = await GetCompletionAsync<GetServicesCompletion>(publisher);

            var endpointDetails = response.Payload;
            var services = response?.Payload.Services;

            Logger.LogLine($"Services:\n{string.Join("\n", from ep in services select ep.ServiceURI)}");

            async Task<(CapabilitiesCompletion capabilities, ClientConnection connection, Uri Uri)> GetServiceDetails( Uri ServiceURI )
            {
                ClientConnection service = await OpenService(ServiceURI);
                CapabilitiesCompletion caps = await GetCapabilities(service);
                return (caps, service, ServiceURI); 
            }

            // We want to do the query for the capabilities in parallel for each service to speed things up. 
            // So we create all the async 'GetServiceDetails' tasks as a group and then wait for them all to finish.  
            var servicesDetails = (from ep in services
                                   let uri = new Uri(ep.ServiceURI)
                                   select (Uri: uri, task: GetServiceDetails(uri))
                                  ).ToArray();

            await Task.WhenAll(from t in servicesDetails select t.task );

            // Once we've queried all the capabilities we can find which ones are actually each service class. 
            var( cardService, cardUri ) = (
                              from details in servicesDetails
                              let caps = details.task.Result.capabilities.Payload
                              where caps.CardReader != null && caps.CardReader.Type == XFS4IoT.CardReader.CapabilitiesClass.TypeEnum.Motor
                              select (details.task.Result.connection, details.task.Result.Uri )
                              )
                              .FirstOrDefault();
            cardReader = cardService ?? throw new Exception($"Failed to find a card reader");
            cardReaderURI = cardUri;
            Logger.LogLine($"Found a card reader: {cardUri }");

            var (dispService, dispenserUri) = (
                              from details in servicesDetails
                              let caps = details.task.Result.capabilities.Payload
                              where caps.CashDispenser != null && caps.CashDispenser.Type == XFS4IoT.CashDispenser.CapabilitiesClass.TypeEnum.SelfServiceBill
                              select (details.task.Result.connection, details.task.Result.Uri)
                              )
                              .FirstOrDefault();
            cashDispenser = dispService ?? throw new Exception($"Failed to find a cash dispenser");
            cashDispenserURI = dispenserUri;
            Logger.LogLine($"Found a cash dispenser: {dispenserUri}");
        }

        private ClientConnection cardReader;
        private Uri cardReaderURI;
        private ClientConnection cashDispenser;
        private Uri cashDispenserURI;

        private static async Task<ClientConnection> OpenService(Uri service)
        {
            // Create the connection object. This doesn't start anything...  
            var connection
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
            var command = new ResetCommand
                            (
                            RequestId: RequestId.NewID(),
                            Payload:    new 
                                        (
                                        Timeout: 10_000, 
                                        To: ResetCommand.PayloadData.ToEnum.Transport
                                        )
                            );

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<ResetCompletion>(cardReader);
        }

        private async Task DoRetainCard(ClientConnection cardReader)
        {
            Logger.LogLine("Doing AcceptCard before RetainCard.");
            await DoAcceptCard(cardReader);

            // Create a new command and send it to the device
            var command = new MoveCommand(RequestId.NewID(),
                new MoveCommand.PayloadData(10_000,
                                            From: "transport$",
                                            To: "exit"));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<MoveCompletion>(cardReader);
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

        private async Task DoEjectCard(ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new MoveCommand(RequestId.NewID(), 
                                                new(10_000,
                                                From: "transport$",
                                                To: "exit")
                                                );
            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            await GetCompletionAsync<MoveCompletion>(cardReader);
        }


        private async Task<string> DoGetCommandNonce(ClientConnection cashDispenser)
        {
            // Create a new command and send it to the device
            var command = new GetCommandNonceCommand(RequestId.NewID(),
                                                     Payload: new(Timeout: 10_000)
                                                     );
            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var response = await GetCompletionAsync<GetCommandNonceCompletion>(cashDispenser);
            if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                throw new Exception($"GetCommandNonce failed: {response.Payload.CompletionCode}");

            return response.Payload.CommandNonce;
        }

        private async Task DoClearCommandNonce(ClientConnection cashDispenser)
        {
            var command = new ClearCommandNonceCommand(RequestId.NewID(), Payload: new(10_000));

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var response = await GetCompletionAsync<ClearCommandNonceCompletion>(cashDispenser);
            if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                throw new Exception($"ClearCommandNonce failed: {response.Payload.CompletionCode}");
        }

        private async Task DoDispenseCash(ClientConnection cashDispenser, int Amount, string CurrencyID, string Token)
        {
            var command = new DispenseCommand(RequestId.NewID(),
                                Payload: new(Timeout: 10_000,
                                             Denomination: new(Denomination: new(new() { { CurrencyID, Amount } }), "mix1"),
                                             Position: null,
                                             Token: Token
                                             )
                                );

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var response = await GetCompletionAsync<DispenseCompletion>(cashDispenser);
            if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                Logger.LogWarning($"Dispense failed: {response.Payload.CompletionCode}");

        }

        private async Task DoPresentCash(ClientConnection cashDispenser)
        {
            var command = new PresentCommand(RequestId.NewID(), Payload: new(Timeout: 10_000) );

            Logger.LogMessage(command);
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var response = await GetCompletionAsync<PresentCompletion>(cashDispenser);
            if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                Logger.LogWarning($"Present failed: {response.Payload.CompletionCode}");

        }

        public async Task DoSetCashUnitInfo(ClientConnection cashDispenser)
        {

            Dictionary<string, XFS4IoT.Storage.SetStorageUnitClass> storage = new()
            {
                {
                    "PHP3",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new XFS4IoT.CashManagement.StorageSetCashClass(null,
                                            new XFS4IoT.CashManagement.StorageSetCashStatusClass(new XFS4IoT.CashManagement.StorageCashCountsClass(0, new() { { "EUR5", new XFS4IoT.CashManagement.StorageCashCountClass(Fit: 1000) } }))),
                    null)
                },
                {
                    "PHP4",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new XFS4IoT.CashManagement.StorageSetCashClass(null,
                                            new XFS4IoT.CashManagement.StorageSetCashStatusClass(new XFS4IoT.CashManagement.StorageCashCountsClass(0, new() { { "EUR10", new XFS4IoT.CashManagement.StorageCashCountClass(Fit: 1000) } }))),
                    null)
                },
                {
                    "PHP5",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new XFS4IoT.CashManagement.StorageSetCashClass(null,
                                            new XFS4IoT.CashManagement.StorageSetCashStatusClass(new XFS4IoT.CashManagement.StorageCashCountsClass(0, new() { { "EUR20", new XFS4IoT.CashManagement.StorageCashCountClass(Fit: 1000) } }))),
                    null)
                },
            };
            var command = new SetStorageCommand(RequestId.NewID(), new(10_000, storage));
            await cashDispenser.SendCommandAsync(command);

            // Wait for a response from the device. 
            var response = await GetCompletionAsync<SetStorageCompletion>(cashDispenser);
            if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                Logger.LogWarning($"SetStorage failed: {response.Payload.CompletionCode}");
        }

        private async Task<CompletionType> GetCompletionAsync<CompletionType>(ClientConnection connection)
        {
            while (true)
            {
                var Message = await connection.ReceiveMessageAsync();
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
                    MessageHeader.TypeEnum.Acknowledge => ConsoleColor.DarkGray,
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
