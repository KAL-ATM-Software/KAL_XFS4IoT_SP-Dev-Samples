/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2024
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Configuration;
using System.Reflection;
using XFS4IoT;
using XFS4IoTServer;
using Json.Schema;

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

                var Publisher = new ServicePublisher(Logger, 
                                                     new ServiceConfiguration(Logger));
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
                var textTerminalService = new TextTerminalServiceProvider(EndpointDetails,
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

                /// Camera Service Provider
                var simCameraDevice = new KAL.XFS4IoTSP.Camera.Sample.CameraSample(Logger);
                var cameraervice = new CameraServiceProvider(EndpointDetails,
                                                             ServiceName: "SimCamera",
                                                             simCameraDevice,
                                                             Logger,
                                                             new FilePersistentData(Logger));

                simCameraDevice.SetServiceProvider = cameraervice;
                Publisher.Add(cameraervice);

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
                
                /// CheckScanner Service Provider
                var simCheckDevice = new KAL.XFS4IoTSP.CheckScanner.Sample.CheckScannerSample(Logger);
                var checkService = new CheckScannerServiceProvider(EndpointDetails,
                                                                   ServiceName: "SimCheckScanner",
                                                                   simCheckDevice,
                                                                   Logger,
                                                                   new FilePersistentData(Logger));

                simCheckDevice.SetServiceProvider = checkService;
                Publisher.Add(checkService);

                // TODO: adding other services

                // CancellationSource object allows to restart service when it's signalled.
                CancellationSource cancelToken = new CancellationSource(Logger);
                await Publisher.RunAsync(cancelToken);
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
            public FilePersistentData(ConsoleLogger Logger)
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
            public ConsoleLogger Logger { get; init; }
        }

        private class ServiceConfiguration : IServiceConfiguration
        {
            public ServiceConfiguration(ConsoleLogger Logger)
            {
                this.Logger = Logger;
                try
                {
                    Settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)?.AppSettings?.Settings;
                }
                catch (ConfigurationErrorsException ex)
                {
                    Logger.Warning(nameof(ServiceConfiguration), $"Exception caught in the constructor {nameof(ServiceConfiguration)}. {ex}");
                }
            }

            /// <summary>
            /// Get configuration value associated with the key specified.
            /// Returns null if specified value doesn't exist in the configuration. 
            /// </summary>
            /// <param name="name">Name of the configuration value</param>
            /// <returns>Configuration value</returns>
            public string Get(string name)
            {
                var configValue = Settings[name]?.Value;
                Logger.Log($"Configuration Get({name}={configValue} in {nameof(ServiceConfiguration)}");
                return configValue;
            }

            /// <summary>
            /// Logging interface
            /// </summary>
            private ConsoleLogger Logger { get; init; }


            /// <summary>
            /// The collection of configuration value
            /// </summary>
            private KeyValueConfigurationCollection Settings { get; init; }
        }

        /// <summary>
        /// Example of adding JSON validator.
        /// https://json-everything.net/
        /// MIT License
        /// </summary>
        private class JSONSchemaValidator : IJsonSchemaValidator
        {
            public JSONSchemaValidator(ILogger Logger)
            {
                this.Logger = Logger;
            }
            /// <summary>
            /// SP framework call once the ServicePublisher object gets created to load 
            /// any of JSON schema library to validate XFS4 command message
            /// </summary>
            public async Task LoadSchemaAsync()
            {
                await Task.Run(() => 
                {
                    try
                    {
                        // Load JsonSchema for current version 
                        const string resourceSchemaName = "JsonSchema-2021-1.json";

                        string[] resources = Assembly.GetExecutingAssembly().IsNotNull().GetManifestResourceNames();

                        string resourceName = string.Empty;
                        foreach (string s in resources)
                        {
                            if (s.EndsWith(resourceSchemaName))
                            {
                                resourceName = s;
                                break;
                            }
                        }

                        if (!string.IsNullOrEmpty(resourceName))
                        {
                            using Stream stream = Assembly.GetExecutingAssembly().IsNotNull().GetManifestResourceStream(resourceName);
                            if (stream is not null)
                            {
                                using StreamReader reader = new(stream);
                                string schema = reader.ReadToEnd();
                                JsonSchemaLib = Json.Schema.JsonSchema.FromText(schema);
                                Logger.Log(nameof(JSONSchemaValidator), $"Json Schema is successfully loaded {nameof(JSONSchemaValidator)}. string length: {schema.Length}");
                                SchemaLoaded = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Warning(nameof(JSONSchemaValidator), $"Exception caught in the constructor {nameof(JSONSchemaValidator)}. {ex}");
                    }
                });
            }

            /// <summary>
            /// This method will be called when the SP framework receives in-comming command messages.
            /// </summary>
            /// <param name="Command"></param>
            /// <param name="FailedReason"></param>
            /// <returns></returns>
            public bool Validate(string Command, out string FailedReason)
            {
                FailedReason = string.Empty;
                try
                {
                    JsonDocument json = JsonDocument.Parse(Command);

                    var result = JsonSchemaLib.IsNotNull().Evaluate(json.RootElement);

                    bool valid = result.IsValid;

                    Logger.Log(nameof(JSONSchemaValidator), $"Json Schema validation result. Valid: {valid}");

                    return valid;
                }
                catch (Exception ex)
                {
                    FailedReason = ex.ToString();
                    Logger.Warning(nameof(JSONSchemaValidator), $"Exception caught in the Validate {nameof(JSONSchemaValidator)}. {ex}");
                    return false;
                }
            }

            /// <summary>
            /// This property must set if the XFS4 JSON schema is loaded successfully.
            /// If this property is set to false, Validate method won't be called from the SP framework.
            /// </summary>
            public bool SchemaLoaded { get; set; } = false;

            private Json.Schema.JsonSchema JsonSchemaLib;
            private readonly ILogger Logger;
        }

        /// <summary>
        /// Example of adding JSON validator.
        /// https://github.com/RicoSuter/NJsonSchema
        /// MIT License
        /// </summary>
        private class NJSONSchemaValidator : IJsonSchemaValidator
        {
            public NJSONSchemaValidator(ILogger Logger)
            {
                this.Logger = Logger;
            }
            /// <summary>
            /// SP framework call once the ServicePublisher object gets created to load 
            /// any of JSON schema library to validate XFS4 command message
            /// </summary>
            public async Task LoadSchemaAsync()
            {
                try
                {
                    // Load JsonSchema for current version 
                    const string resourceSchemaName = "JsonSchema-2021-1.json";

                    string[] resources = Assembly.GetExecutingAssembly().IsNotNull().GetManifestResourceNames();

                    string resourceName = string.Empty;
                    foreach (string s in resources)
                    {
                        if (s.EndsWith(resourceSchemaName))
                        {
                            resourceName = s;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(resourceName))
                    {
                        using Stream stream = Assembly.GetExecutingAssembly().IsNotNull().GetManifestResourceStream(resourceName);
                        if (stream is not null)
                        {
                            using StreamReader reader = new(stream);
                            string schema = reader.ReadToEnd();
                            JsonSchemaLib = await NJsonSchema.JsonSchema.FromJsonAsync(schema);
                            Logger.Log(nameof(JSONSchemaValidator), $"Json Schema is successfully loaded {nameof(JSONSchemaValidator)}. string length: {schema.Length}");
                            SchemaLoaded = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warning(nameof(JSONSchemaValidator), $"Exception caught in the constructor {nameof(JSONSchemaValidator)}. {ex}");
                }
            }

            /// <summary>
            /// This method will be called when the SP framework receives in-comming command messages.
            /// </summary>
            /// <param name="Command"></param>
            /// <param name="FailedReason"></param>
            /// <returns></returns>
            public bool Validate(string Command, out string FailedReason)
            {
                FailedReason = string.Empty;
                try
                {
                    var result = JsonSchemaLib.IsNotNull().Validate(Command);

                    bool valid = true;
                    foreach (var error in result)
                    {
                        FailedReason += (error.Path + ": " + error.Kind) + "\n";
                        valid = false;
                    }

                    Logger.Log(nameof(JSONSchemaValidator), $"Json Schema validation result. valid: {valid}");

                    return valid;
                }
                catch (Exception ex)
                {
                    FailedReason = ex.ToString();
                    Logger.Warning(nameof(JSONSchemaValidator), $"Exception caught in the Validate {nameof(JSONSchemaValidator)}. {ex}");
                    return false;
                }
            }

            /// <summary>
            /// This property must set if the XFS4 JSON schema is loaded successfully.
            /// If this property is set to false, Validate method won't be called from the SP framework.
            /// </summary>
            public bool SchemaLoaded { get; set; } = false;

            private NJsonSchema.JsonSchema JsonSchemaLib;
            private readonly ILogger Logger;
        }
    }
}
