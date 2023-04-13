/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.ServicePublisher.Commands;
using XFS4IoT.ServicePublisher.Completions;

namespace TestClientForms.Devices
{
    public delegate void XFS4IoTMessagesDelegate(object sender, string msg);

    public class CommonDevice
    {
        static readonly int[] PortRanges = new int[]
            {
                80,  // Only for HTTP
                443, // Only for HTTPS
                5846,
                5847,
                5848,
                5849,
                5850,
                5851,
                5852,
                5853,
                5854,
                5855,
                5856
            };

        /// <summary>
        /// Get a reference to the required text boxes for the device.
        /// Use separate text box per device to enable using more than one device at a time.
        /// </summary>
        public CommonDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox, bool useSingleConnection = false)
        {
            ServiceName = serviceName;         
            UriBox = uriBox;
            PortBox = portBox;
            ServiceUriBox = serviceUriBox;
            UseSingleConnection = useSingleConnection;
        }

        protected string ServiceName { get; init; }

        /// <summary>
        /// the event is raised when XFS4IoT message is sent or received
        /// </summary>
        public event XFS4IoTMessagesDelegate XFS4IoTMessages;

        protected virtual void OnXFS4IoTMessages(object sender, string msg)
        {
            XFS4IoTMessages?.Invoke(this, msg);
        }

        
        protected TextBox UriBox { get; init; }
        protected TextBox PortBox { get; init; }
        protected TextBox ServiceUriBox { get; init; }
        protected bool UseSingleConnection { get; init; }
        protected XFS4IoTClient.ClientConnection SingleConnection {get; private set;}

        private int? ServicePort { get; set; }

        public static readonly int CommandTimeout = 60000;

        /// <summary>
        /// Keep capabilities and make it available from an individual derived class if it's needed
        /// </summary>
        protected CapabilitiesCompletion Capabilities { get; private set; } = null;

        private async Task ServiceDiscoveryForPort(string uri, int port, InterfaceClass.NameEnum[] serviceClasses)
        {
            try
            {
                WebSocketState state;
                using (var socket = new ClientWebSocket())
                {
                    var cancels = new CancellationTokenSource();
                    cancels.CancelAfter(40_000);
                    await socket.ConnectAsync(new Uri($"{uri}:{port}/xfs4iot/v1.0"), cancels.Token);
                    state = socket.State;
                }

                if (state != WebSocketState.Open)
                    return;

                var Discovery = new XFS4IoTClient.ClientConnection(new Uri($"{uri}:{port}/xfs4iot/v1.0"));

                try
                {
                    await Discovery.ConnectAsync();
                }
                catch (Exception)
                {
                    return;
                }

                var getServiceCommand = new GetServicesCommand(RequestId.NewID(), new GetServicesCommand.PayloadData(CommandTimeout));
                string commandString = getServiceCommand.Serialise();
                XFS4IoTMessages?.Invoke(this, commandString);
                string responseString = string.Empty;

                object cmdResponse = await SendAndWaitForCompletionAsync(Discovery, getServiceCommand);

                if (cmdResponse is GetServicesCompletion response)
                {
                    responseString = response.Serialise();
                    XFS4IoTMessages?.Invoke(this, responseString);

                    var serviceURI = string.Empty;

                    foreach (var service in response.Payload.Services)
                    {
                        var capabilities = await GetCapabilities(service.ServiceURI).IsNotNull();
                        //Ensure service supports all required Interfaces
                        if (serviceClasses.Except(capabilities.Payload.Interfaces
                            .Where(c => c.Name.HasValue).Select(c => c.Name.Value)).Any())
                        {
                            continue;
                        }

                        //Use this service
                        serviceURI = service.ServiceURI;
                        break;
                    }

                    if (!string.IsNullOrEmpty(serviceURI))
                    {
                        ServicePort = port;
                        PortBox.Text = ServicePort.ToString();
                        ServiceUriBox.Text = serviceURI;
                    }
                }
            }
            catch (WebSocketException)
            { }
            catch (System.Net.HttpListenerException)
            { }
            catch (TaskCanceledException)
            { }
        }


        public async Task DoServiceDiscovery(XFS4IoT.Common.InterfaceClass.NameEnum[] serviceClasses)
        {
            ServiceUriBox.Text = string.Empty;
            ServicePort = null;

            await Task.WhenAll(from port in XFSConstants.PortRanges select ServiceDiscoveryForPort(UriBox.Text, port, serviceClasses));
            SingleConnection = null;

            if (ServicePort is null || string.IsNullOrWhiteSpace(ServiceUriBox.Text))
            {
                PortBox.Text = "";
                ServiceUriBox.Text = "";
                MessageBox.Show("Failed on finding services.");
            }
            else if (UseSingleConnection)
            {
                SingleConnection = new(new Uri($"{ServiceUriBox.Text}"));
                try
                {
                    await SingleConnection.ConnectAsync();
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed when setting up single connection.");
                    SingleConnection = null;
                }
            }
        }

        public async Task<XFS4IoTClient.ClientConnection> GetConnection()
        {
            if (UseSingleConnection && SingleConnection != null && SingleConnection.IsConnected)
                return SingleConnection;

            var device = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await device.ConnectAsync();
                return device;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<StatusCompletion> GetStatus()
        {
            var device = await GetConnection();

            var statusCmd = new StatusCommand(RequestId.NewID(), new StatusCommand.PayloadData(CommandTimeout));
            XFS4IoTMessages?.Invoke(this, statusCmd.Serialise());

            object cmdResponse = await SendAndWaitForCompletionAsync(device, statusCmd);
            if (cmdResponse is StatusCompletion response)
            {
                XFS4IoTMessages?.Invoke(this, response.Serialise());
                return response;
            }
            return null;
        }

        public async Task<CapabilitiesCompletion> GetCapabilities(string uri = null)
        {
            var device = new XFS4IoTClient.ClientConnection(new Uri($"{uri ?? ServiceUriBox.Text}"));

            try
            {
                await device.ConnectAsync();
            }
            catch (Exception)
            {
                return null;
            }

            var capabilitiesCmd = new CapabilitiesCommand(RequestId.NewID(), new CapabilitiesCommand.PayloadData(CommandTimeout));
            XFS4IoTMessages?.Invoke(this, capabilitiesCmd.Serialise());
                      

            object cmdResponse = await SendAndWaitForCompletionAsync(device, capabilitiesCmd);
            if (cmdResponse is CapabilitiesCompletion response)
            {
                Capabilities = response;
                XFS4IoTMessages?.Invoke(this, response.Serialise());
                return response;
            }
            return null;
        }

        public async Task<object> SendAndWaitForCompletionAsync(XFS4IoTClient.ClientConnection device, object command)
        {
            await device.SendCommandAsync(command);

            object cmdResponse = await device.ReceiveMessageAsync();
            if (cmdResponse is Acknowledge)
                cmdResponse = await device.ReceiveMessageAsync();
            return cmdResponse;
        }
    }

    internal class RequestId
    {
        internal static int NewID() => Interlocked.Increment(ref id);

        private static int id = 1;
    }
}
