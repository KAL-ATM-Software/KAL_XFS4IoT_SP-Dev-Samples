/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
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

namespace TestClientForms.Devices
{
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
        public CommonDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
        {
            ServiceName = serviceName;
            CmdBox = cmdBox;
            RspBox = rspBox;
            EvtBox = evtBox;
            UriBox = uriBox;
            PortBox = portBox;
            ServiceUriBox = serviceUriBox;
        }

        protected string ServiceName { get; init; }

        protected TextBox CmdBox { get; init; }
        protected TextBox RspBox { get; init; }
        protected TextBox EvtBox { get; init; }
        protected TextBox UriBox { get; init; }
        protected TextBox PortBox { get; init; }
        protected TextBox ServiceUriBox { get; init; }

        private int? ServicePort { get; set; }

        public static readonly int CommandTimeout = 60000;


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
                string responseString = string.Empty;

                object cmdResponse = await SendAndWaitForCompletionAsync(Discovery, getServiceCommand);

                if (cmdResponse is GetServicesCompletion response)
                {
                    responseString = response.Serialise();

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
                        CmdBox.Text = commandString;
                        RspBox.Text = responseString;
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
            CmdBox.Text = string.Empty;
            RspBox.Text = string.Empty;
            ServiceUriBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            ServicePort = null;

            await Task.WhenAll(from port in XFSConstants.PortRanges select ServiceDiscoveryForPort(UriBox.Text, port, serviceClasses));

            if (ServicePort is null || string.IsNullOrWhiteSpace(ServiceUriBox.Text))
            {
                PortBox.Text = "";
                ServiceUriBox.Text = "";
                MessageBox.Show("Failed on finding services.");
            }
        }

        public async Task<StatusCompletion> GetStatus()
        {
            var device = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await device.ConnectAsync();
            }
            catch (Exception)
            {
                return null;
            }

            var statusCmd = new StatusCommand(RequestId.NewID(), new StatusCommand.PayloadData(CommandTimeout));
            CmdBox.Text = statusCmd.Serialise();

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(device, statusCmd);
            if (cmdResponse is StatusCompletion response)
            {
                RspBox.Text = response.Serialise();
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
            CmdBox.Text = capabilitiesCmd.Serialise();

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(device, capabilitiesCmd);
            if (cmdResponse is CapabilitiesCompletion response)
            {
                RspBox.Text = response.Serialise();
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
