/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT;
using XFS4IoT.BanknoteNeutralization.Completions;
using XFS4IoT.Common;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common.Events;
using XFS4IoT.ServicePublisher.Commands;
using XFS4IoT.ServicePublisher.Completions;
using XFS4IoT.Storage.Events;
using XFS4IoTServer;

namespace TestClientForms.Devices
{
    public delegate void XFS4IoTMessagesDelegate(object sender, string msg);

    /// <summary>
    /// Get a reference to the required text boxes for the device.
    /// Use separate text box per device to enable using more than one device at a time.
    /// </summary>
    public class CommonDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox, bool useSingleConnection = false)
    {
        static readonly int[] PortRanges =
            [
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
            ];

        protected string ServiceName { get; init; } = serviceName;

        /// <summary>
        /// the event is raised when XFS4IoT message is sent or received
        /// </summary>
        public event XFS4IoTMessagesDelegate XFS4IoTMessages;

        protected virtual void OnXFS4IoTMessages(object sender, string msg)
        {
            XFS4IoTMessages?.Invoke(this, msg);
        }


        protected TextBox UriBox { get; init; } = uriBox;
        protected TextBox PortBox { get; init; } = portBox;
        protected TextBox ServiceUriBox { get; init; } = serviceUriBox;
        protected bool UseSingleConnection { get; init; } = useSingleConnection;
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

                var getServiceCommand = new GetServicesCommand(RequestId.NewID(), CommandTimeout);
                await Discovery.SendCommandAsync(getServiceCommand);
                XFS4IoTMessages?.Invoke(this, getServiceCommand.Serialise());

                object cmdResponse = null;
                while (cmdResponse is not GetServicesCompletion)
                {
                    cmdResponse = await Discovery.ReceiveMessageAsync();
                    if (cmdResponse is null)
                    {
                        break;
                    }
                }

                string responseString = string.Empty;
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

            var statusCmd = new StatusCommand(RequestId.NewID(), CommandTimeout);
            await device.SendCommandAsync(statusCmd);
            XFS4IoTMessages?.Invoke(this, statusCmd.Serialise());

            for (; ;)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case StatusCompletion response:
                        XFS4IoTMessages?.Invoke(this, response.Serialise());
                        return response;
                    case StatusChangedEvent statusChangedEvent:
                        XFS4IoTMessages?.Invoke(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        XFS4IoTMessages?.Invoke(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        XFS4IoTMessages?.Invoke(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task<CapabilitiesCompletion> GetCapabilities(string uri = null)
        {
            XFS4IoTClient.ClientConnection device;
            if (!string.IsNullOrEmpty(uri))
            {
                device = new XFS4IoTClient.ClientConnection(new Uri($"{uri}"));
                try
                {
                    await device.ConnectAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                device = await GetConnection();
            }

            var capabilitiesCmd = new CapabilitiesCommand(RequestId.NewID(), CommandTimeout);
            await device.SendCommandAsync(capabilitiesCmd);
            XFS4IoTMessages?.Invoke(this, capabilitiesCmd.Serialise());      

            for (; ; )
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case CapabilitiesCompletion response:
                        XFS4IoTMessages?.Invoke(this, response.Serialise());
                        if (!string.IsNullOrEmpty(uri))
                        {
                            await device.DisconnectAsync();
                        }
                        return response;
                    case StatusChangedEvent statusChangedEvent:
                        XFS4IoTMessages?.Invoke(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        XFS4IoTMessages?.Invoke(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        XFS4IoTMessages?.Invoke(this, "<Unknown Event>");
                        break;
                }
            }
        }
    }

    internal class RequestId
    {
        internal static int NewID() => Interlocked.Increment(ref id);

        private static int id = 1;
    }
}
