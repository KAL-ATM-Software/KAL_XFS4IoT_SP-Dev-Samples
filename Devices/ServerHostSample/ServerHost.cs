/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using XFS4IoT;
using XFS4IoTServer;

namespace Server
{
    class Server
    {
        static async Task Main(/*string[] args*/)
        {
            ConsoleLogger Logger = new();
            try
            {
                Logger.Log($"Running ServiceProvider Server");

                var Publisher = new ServicePublisher(Logger);
                var EndpointDetails = Publisher.EndpointDetails;

                /// CardReader Service Provider
                var simCardReaderDevice = new KAL.XFS4IoTSP.CardReader.Sample.CardReaderSample(Logger);
                var cardReaderService = new CardReaderServiceProvider(EndpointDetails,
                                                                      ServiceName: "SimCardReader",
                                                                      simCardReaderDevice,
                                                                      Logger,
                                                                      new FilePersistentData(Logger));

                simCardReaderDevice.SetServiceProvider = cardReaderService;
                Publisher.Add(cardReaderService);

                /// CashDispenser Service Provider
                var simCashDispenserrDevice = new KAL.XFS4IoTSP.CashDispenser.Sample.CashDispenserSample(Logger);
                var cashDispenserService = new CashDispenserServiceProvider(EndpointDetails,
                                                                            ServiceName: "SimCashDispenser",
                                                                            simCashDispenserrDevice,
                                                                            Logger,
                                                                            new FilePersistentData(Logger));
                simCashDispenserrDevice.SetServiceProvider = cashDispenserService;
                Publisher.Add(cashDispenserService);

                /// Text Terminal Unit Service Provider
                var simTextTerminalDevice = new TextTerminalSample.TextTerminalSample(Logger);
                var textTerminalService = new TextTerminalProvider.TextTerminalServiceProvider(EndpointDetails,
                                                                                               ServiceName: "SimTextTerminal",
                                                                                               simTextTerminalDevice,
                                                                                               Logger);
                simTextTerminalDevice.SetServiceProvider = textTerminalService;
                Publisher.Add(textTerminalService);

                /// Encryptor Service Provider
                var simEncryptorDevice = new KAL.XFS4IoTSP.Encryptor.Sample.EncryptorSample(Logger);
                var encryptorService = new CryptoServiceProvider(EndpointDetails,
                                                                 ServiceName: "SimEncryptor",
                                                                 simEncryptorDevice,
                                                                 Logger,
                                                                 new FilePersistentData(Logger));

                simEncryptorDevice.SetServiceProvider = encryptorService;
                Publisher.Add(encryptorService);
  
                /// PinPad Service Provider
                var simPinPadDevice = new KAL.XFS4IoTSP.PinPad.Sample.PinPadSample(Logger);
                var pinPadService = new PinPadServiceProvider(EndpointDetails,
                                                              ServiceName: "SimPinPad",
                                                              simPinPadDevice,
                                                              Logger,
                                                              new FilePersistentData(Logger));

                simPinPadDevice.SetServiceProvider = pinPadService;
                Publisher.Add(pinPadService);

                /// Printer Service Provider
                var simPrinterDevice = new KAL.XFS4IoTSP.Printer.Sample.PrinterSample(Logger);
                var printerService = new PrinterServiceProvider(EndpointDetails,
                                                                ServiceName: "SimPrinter",
                                                                simPrinterDevice,
                                                                Logger,
                                                                new FilePersistentData(Logger));

                simPrinterDevice.SetServiceProvider = printerService;
                Publisher.Add(printerService);
                
                /// Lights Service Provider
                var simLightsDevice = new KAL.XFS4IoTSP.Lights.Sample.LightsSample(Logger);
                var lightsService = new LightsServiceProvider(EndpointDetails,
                                                              ServiceName: "SimLights",
                                                              simLightsDevice,
                                                              Logger);

                simLightsDevice.SetServiceProvider = lightsService;
                Publisher.Add(lightsService);
                
                /// Auxiliaries Service Provider
                var simAuxDevice = new KAL.XFS4IoTSP.Auxiliaries.Sample.AuxiliariesSample(Logger);
                var auxService = new AuxiliariesServiceProvider(EndpointDetails,
                                                                ServiceName: "SimAuxiliaries",
                                                                simAuxDevice,
                                                                Logger);

                simAuxDevice.SetServiceProvider = auxService;
                Publisher.Add(auxService);
                
                /// VendorApplication Service Provider
                var simVendorAppDevice = new KAL.XFS4IoTSP.VendorApplication.Sample.VendorApplicationSample(Logger);
                var vendorAppService = new VendorApplicationServiceProvider(EndpointDetails,
                                                                            ServiceName: "SimVendorApplication",
                                                                            simVendorAppDevice,
                                                                            Logger);

                simVendorAppDevice.SetServiceProvider = vendorAppService;
                Publisher.Add(vendorAppService);

                /// VendorMode Service Provider
                var simVendorModeDevice = new KAL.XFS4IoTSP.VendorMode.Sample.VendorModeSample(Logger);
                var vendorModeService = new VendorModeServiceProvider(EndpointDetails,
                                                                      ServiceName: "SimVendorMode",
                                                                      simVendorModeDevice,
                                                                      Logger);

                simVendorModeDevice.SetServiceProvider = vendorModeService;
                Publisher.Add(vendorModeService);

                /// BarcodeReader Service Provider
                var simBarcodeReaderDevice = new KAL.XFS4IoTSP.BarcodeReader.Sample.BarcodeReaderSample(Logger);
                var barcodeReaderService = new BarcodeReaderServiceProvider(EndpointDetails,
                                                                            ServiceName: "SimBarcodeReader",
                                                                            simBarcodeReaderDevice,
                                                                            Logger);

                simBarcodeReaderDevice.SetServiceProvider = barcodeReaderService;
                Publisher.Add(barcodeReaderService);

                /// Biometric Service Provider
                var simBiometricDevice = new KAL.XFS4IoTSP.Biometric.Sample.BiometricSample(Logger);
                var biometricService = new BiometricServiceProvider(EndpointDetails,
                                                                    ServiceName: "SimBiometric",
                                                                    simBiometricDevice,
                                                                    Logger, 
                                                                    new FilePersistentData(Logger));

                simBiometricDevice.SetServiceProvider = biometricService;
                Publisher.Add(biometricService);

                // CashAcceptor Service Provider
                var simCashAcceptorDevice = new KAL.XFS4IoTSP.CashAcceptor.Sample.CashAcceptorSample(Logger);
                var cashAcceptorService = new CashAcceptorServiceProvider(EndpointDetails,
                                                                          ServiceName: "SimCashAcceptor",
                                                                          simCashAcceptorDevice,
                                                                          Logger,
                                                                          new FilePersistentData(Logger));

                simCashAcceptorDevice.SetServiceProvider = cashAcceptorService;
                Publisher.Add(cashAcceptorService);

                /// CasRecycler Service Provider
                /*
                var simCashRecyclerDevice = new KAL.XFS4IoTSP.CashRecycler.Sample.CashRecyclerSample(Logger);
                var cashRecyclerService = new CashRecyclerServiceProvider(EndpointDetails,
                                                                          ServiceName: "SimCashRecycler",
                                                                          simCashRecyclerDevice,
                                                                          Logger,
                                                                          new FilePersistentData(Logger));

                simCashRecyclerDevice.SetServiceProvider = cashRecyclerService;
                Publisher.Add(cashRecyclerService);
                */
                // TODO: adding other services

                await Publisher.RunAsync();
            }
            catch (Exception e) when (e.InnerException != null)
            {
                Logger.Warning($"Unhandled exception {e.InnerException.Message}");
            }
            catch (Exception e)
            {
                Logger.Warning($"Unhandled exception {e.Message}");
            }

        }

        /// <summary>
        /// Sample logger. This should be replaced with a more robust implementation. 
        /// </summary>
        private class ConsoleLogger : ILogger
        {
            public void Warning(string Message) => Warning("SvrHost", Message);
            public void Log(string Message) => Log("SvrHost", Message);

            public void Trace(string SubSystem, string Operation, string Message) => Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} ({(DateTime.Now - Start).TotalSeconds:000.000}): {Message}");

            public void Warning(string SubSystem, string Message) => Trace(SubSystem, "WARNING", Message);

            public void Log(string SubSystem, string Message) => Trace(SubSystem, "INFO", Message);

            public void TraceSensitive(string SubSystem, string Operation, string Message) => Trace(SubSystem, Operation, Message);

            public void WarningSensitive(string SubSystem, string Message) => Trace(SubSystem, "WARNING", Message);

            public void LogSensitive(string SubSystem, string Message) => Trace(SubSystem, "INFO", Message);

            private readonly DateTime Start = DateTime.Now;
        }

        private class FilePersistentData : IPersistentData
        {
            public FilePersistentData(ILogger Logger)
            {
                this.Logger = Logger;
            }

            public bool Store<TValue>(string name, TValue obj) where TValue : class
            {
                string data;

                try
                {
                    data = JsonSerializer.Serialize<TValue>(obj);
                    if (string.IsNullOrEmpty(data))
                        return false;
                }
                catch (Exception ex)
                {
                    Logger.Warning(nameof(FilePersistentData), $"Exception caught on serializing persistent data. {ex.Message}");
                    return false;
                }

                // The data is serialized and stored it on the file system
                try
                {
                    File.WriteAllText(name, data);
                }
                catch (Exception ex)
                {
                    Logger.Warning(nameof(FilePersistentData), $"Exception caught on writing data. {name}, {ex.Message}");
                    return false;
                }

                return true;
            }

            public TValue Load<TValue>(string name) where TValue : class
            {
                // Load serialized data from the file system
                string data;
                try
                {
                    data = File.ReadAllText(name);
                }
                catch (Exception ex)
                {
                    Logger.Warning(nameof(FilePersistentData), $"Exception caught on reading persistent data. {name}, {ex.Message}");
                    return null;
                }

                TValue value;
                // Unserialize read data
                try
                {
                    value = JsonSerializer.Deserialize<TValue>(data);
                }
                catch (Exception ex)
                {
                    Logger.Warning(nameof(FilePersistentData), $"Exception caught on unserializing persistent data. {ex.Message}");
                    return null;
                }

                return value;
            }

            /// <summary>
            /// Logging interface
            /// </summary>
            public ILogger Logger { get; init; }
        }
    }
}
