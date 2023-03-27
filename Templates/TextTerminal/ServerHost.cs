using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using XFS4IoT;
using XFS4IoTServer;

namespace TextTerminal.TextTerminalTemplate
{
    class Server
    {
        static async Task Main(/*string[] args*/)
        {
            ConsoleLogger Logger = new();
            try
            {
                Logger.Log($"Running ServiceProvider Server");

                var Publisher = new ServicePublisher(Logger, new ServiceConfiguration(Logger));
                var EndpointDetails = Publisher.EndpointDetails;

                /// TextTerminal Service Provider
                var textTerminalDevice = new TextTerminalTemplate(Logger);
                var textTerminalService = new TextTerminalServiceProvider(EndpointDetails,
                                                                          ServiceName: "TextTerminalTemplate",
                                                                          textTerminalDevice,
                                                                          Logger);

                textTerminalDevice.SetServiceProvider = textTerminalService;
                Publisher.Add(textTerminalService);

                await Publisher.RunAsync(new CancellationSource(Logger));
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
                    Logger.Warning(nameof(ServiceConfiguration), $"Exception caught in the constructor {nameof(ServiceConfiguration)}. {ex.Message}");
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
    }
}
