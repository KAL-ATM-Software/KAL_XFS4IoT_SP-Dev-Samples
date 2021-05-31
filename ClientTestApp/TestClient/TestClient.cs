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
using XFS4IoT.CardReader.Events;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
                foreach (var (name, value) in from p in args
                                              let m = paramRegex.Match(p)
                                              select (m.Groups["name"].Value, m.Groups["value"].Value))
                {
                    switch (name.ToLower())
                    {
                        case "parallelcount" or "count"  : 
                            if( !int.TryParse(value, out ParallelCount ) ) 
                                throw new Exception($"Invalid parallel count {value}"); ; 
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
                        default: throw new Exception($"unknown parameter{name}");
                    }
                }

                Logger.WriteJSON = ShowJSON; 

                Logger.LogLine("Doing service discovery.");
                var CardReaderUri = await DoServiceDiscovery();
                if( CardReaderUri == null )
                {
                    Logger.LogError("No card reader found");
                    return;
                }

                // The test sequence - may be run multiple times. 
                async Task DoCardReader()
                {
                    Logger.LogLine("Connecting to the card reader");
                    XFS4IoTClient.ClientConnection cardReader = await OpenService(CardReaderUri);

                    Logger.LogLine("Get card reader status");
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

                    //await cardReader.DisconnectAsync();
                }

                await Task.WhenAll(from i in Enumerable.Range(0, ParallelCount)
                                   select DoCardReader());

                Logger.LogLine($"Done");

                // Start listening for unsolicited messages. 
                XFS4IoTClient.ClientConnection cardReader = await OpenService(CardReaderUri);
                while (true)
                {
                    Logger.LogMessage(await cardReader.ReceiveMessageAsync());
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

        private static readonly Regex paramRegex = new("^[/-](?<name>.*?)(?:[=:](?<value>.*))?$");

        /// <summary>
        /// Messages that we expect to receive so that we can decode them. 
        /// </summary>
        private readonly MessageDecoder ResponseDecoder = new(MessageDecoder.AutoPopulateType.Response);

        private readonly ConsoleLogger Logger = new();
        private string Address { get; set; } = "localhost";

        private int RequestId { get; set; } = 0;

        private async Task<Uri> DoServiceDiscovery()
        {
            // Do service discovery on a single port. 
            async Task<Uri> DoServiceDiscovery(int port)
            {
                var Discovery = new XFS4IoTClient.ClientConnection(
                        EndPoint: new Uri($"ws://{Address}:{port}/xfs4iot/v1.0")
                        );

                try
                {
                    await Discovery.ConnectAsync();
                }
                catch( System.Net.WebSockets.WebSocketException e ) when (e.HResult == -0x7FFFBFFB)
                {
                    Logger.LogLine($"No responce on port {port}");
                    return null;
                }
                catch (Exception e)
                {
                    Logger.LogLine($"Caught exception : {e}");
                    throw;
                }

                Logger.LogLine($"Publisher responce on port {port}");
                Logger.LogLine($"{nameof(GetServicesCommand)}", ConsoleColor.Blue);

                await Discovery.SendCommandAsync(new GetServicesCommand(RequestId++, new GetServicesCommand.PayloadData(60000)));
                var response = await GetCompletionAsync<GetServicesCompletion>(Discovery);
                Logger.LogMessage(response);
                return await FindCardReader(response.Payload);
            }

            // Do service discovery on all of the ports, in parallel
            var tasks = from port in XFSConstants.PortRanges select DoServiceDiscovery(port);
            await Task.WhenAll(tasks);

            // Take the first card reader that was found, or null.
            return (from task in tasks where task.Result != null select task.Result).FirstOrDefault();
        }

        private async Task<Uri> FindCardReader(GetServicesCompletion.PayloadData endpointDetails)
        {
            Logger.LogLine($"Got endpoint details {endpointDetails}");
            Logger.LogLine($"Services:\n{string.Join("\n", from ep in endpointDetails.Services select ep.ServiceURI)}");

            async Task<bool> IsACardReader( Uri ServiceURI )
            {
                var service = await OpenService(ServiceURI);
                var caps = await GetCapabilities(service);
                return caps.Payload.CardReader != null 
                        && caps.Payload.CardReader.Type == XFS4IoT.CardReader.CapabilitiesClass.TypeEnum.Motor;
            }
            
            // We want to do the query for the capabilities in parallel for each service to speed things up. 
            // So we create all the async 'IsACardReader' tasks as a group and then wait for them all to finish.  
            var services = from ep in endpointDetails.Services.Skip(1)
                           let uri = new Uri(ep.ServiceURI)
                           select (Uri:uri, task:IsACardReader(uri) );

            await Task.WhenAll(from t in services select t.task );

            // Once we've queried all the capabilities we can find which ones are actually card readers. 
            var cardReaders = from x in services
                              where x.task.Result == true
                              select x.Uri;

            // and return the card reader, or throw an error if we didn't find any. 
            return cardReaders.FirstOrDefault() ?? throw new Exception($"Failed to find a card reader endpoint");
        }


        private static async Task<XFS4IoTClient.ClientConnection> OpenService(Uri service)
        {
            // Create the connection object. This doesn't start anything...  
            XFS4IoTClient.ClientConnection connection
                = new XFS4IoTClient.ClientConnection(
                    EndPoint: service
                    );

            // Open the actual network connection, with a timeout. 
            var cancel = new CancellationTokenSource();
            cancel.CancelAfter(10_000);
            await connection.ConnectAsync(cancel.Token);

            return connection; 
        }

        private async Task<StatusCompletion> GetStatus(XFS4IoTClient.ClientConnection service)
        {
            Logger.LogLine($"{nameof(StatusCommand)}", ConsoleColor.Blue);

            // Create a new command and send it to the device
            var command = new StatusCommand(RequestId++, new StatusCommand.PayloadData(Timeout: 1_000));
            await service.SendCommandAsync(command);

            return await GetCompletionAsync<StatusCompletion>(service);
        }

        private async Task<CapabilitiesCompletion> GetCapabilities(XFS4IoTClient.ClientConnection service)
        {
            Logger.LogLine($"{nameof(CapabilitiesCommand)}", ConsoleColor.Blue);

            // Create a new command and send it to the device
            var command = new CapabilitiesCommand(RequestId++, new CapabilitiesCommand.PayloadData(Timeout: 1_000));
            await service.SendCommandAsync(command);

            return await GetCompletionAsync<CapabilitiesCompletion>(service);
        }


        private async Task DoAcceptCard(XFS4IoTClient.ClientConnection cardReader)
        {
            Logger.LogLine($"{nameof(ReadRawDataCommand)}", ConsoleColor.Blue);

            // Create a new command and send it to the device
            var command = new ReadRawDataCommand(RequestId++,
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
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ReadRawDataCompletion>(cardReader);
        }

        private async Task DoChipIO(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ChipIOCommand(RequestId++,
                new ChipIOCommand.PayloadData(10_0000, "chipT0", Convert.ToBase64String(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7 })));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ChipIOCompletion>(cardReader);
        }

        private async Task DoChipPower(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ChipPowerCommand(RequestId++,
                new ChipPowerCommand.PayloadData(10_000, ChipPowerCommand.PayloadData.ChipPowerEnum.Warm));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ChipPowerCompletion>(cardReader);
        }

        private async Task DoReset(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ResetCommand(RequestId++,
                new ResetCommand.PayloadData(10_000, ResetCommand.PayloadData.ResetInEnum.Eject));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ResetCompletion>(cardReader);
        }

        private async Task DoRetainCard(XFS4IoTClient.ClientConnection cardReader)
        {
            Logger.LogLine("Doing AcceptCard before RetainCard.");
            await DoAcceptCard(cardReader);

            // Create a new command and send it to the device
            var command = new RetainCardCommand(RequestId++,
                new RetainCardCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<RetainCardCompletion>(cardReader);
        }

        private async Task DoResetCount(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ResetCountCommand(RequestId++,
                new ResetCountCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ResetCountCompletion>(cardReader);
        }

        private async Task DoSetKey(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new SetKeyCommand(RequestId++,
                new SetKeyCommand.PayloadData(10_000, Convert.ToBase64String(new byte[] { 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7 })));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<SetKeyCompletion>(cardReader);
        }

        private async Task DoWriteData(XFS4IoTClient.ClientConnection cardReader)
        {
            Logger.LogLine("Doing AcceptCard before WriteData.");
            await DoAcceptCard(cardReader);

            // Create a new command and send it to the device
            var command = new WriteRawDataCommand(RequestId++,
                new WriteRawDataCommand.PayloadData(10_000, new()
                {
                    new(WriteRawDataCommand.PayloadData.DataClass.DestinationEnum.Track1, "12345678", WriteRawDataCommand.PayloadData.DataClass.WriteMethodEnum.Auto),
                    new(WriteRawDataCommand.PayloadData.DataClass.DestinationEnum.Track1, "12345678", WriteRawDataCommand.PayloadData.DataClass.WriteMethodEnum.Auto),
                }));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<WriteRawDataCompletion>(cardReader);

            Logger.LogLine("Ejecting card after WriteData.");
            await DoEjectCard(cardReader);
        }

        private async Task DoQueryIFMIdentifier(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new QueryIFMIdentifierCommand(RequestId++,
                new QueryIFMIdentifierCommand.PayloadData(10_000));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<QueryIFMIdentifierCompletion>(cardReader);
        }

        private async Task DoParkCard(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new ParkCardCommand(RequestId++,
                new ParkCardCommand.PayloadData(10_000, ParkCardCommand.PayloadData.DirectionEnum.In, 0));

            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<ParkCardCompletion>(cardReader);
        }
        private async Task DoEjectCard(XFS4IoTClient.ClientConnection cardReader)
        {
            // Create a new command and send it to the device
            var command = new EjectCardCommand(RequestId++, 
                                                new(10_000)
                                                );
            Logger.LogMessage(command);
            await cardReader.SendCommandAsync(command);

            // Wait for a response from the device. 
            Logger.LogLine("Waiting for response... ");

            await GetCompletionAsync<EjectCardCompletion>(cardReader);
        }

        private async Task<CompletionType> GetCompletionAsync<CompletionType>(XFS4IoTClient.ClientConnection cardReader)
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

                ConsoleColor msgColour = msgBase.Headers.Type switch
                {
                    MessageHeader.TypeEnum.Command => ConsoleColor.Blue,
                    MessageHeader.TypeEnum.Acknowledgement => ConsoleColor.DarkGray,
                    MessageHeader.TypeEnum.Event => ConsoleColor.Yellow,
                    MessageHeader.TypeEnum.Completion => ConsoleColor.Green,
                    MessageHeader.TypeEnum.Unsolicited => ConsoleColor.DarkYellow,
                    _ => throw new NotImplementedException($"Unknown message type {msgBase.Headers.Type}"),
                };

                LogMessage(Message.GetType().Name, msgColour, msgBase.Serialise());
            }

            private void LogMessage(string name, ConsoleColor colour, string JSON )
            {
                lock(this)
                {
                    Log($"{name}", colour);
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
