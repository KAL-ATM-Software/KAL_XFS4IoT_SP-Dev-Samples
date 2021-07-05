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


        public async Task DoServiceDiscovery()
        {
            string commandString = string.Empty;
            string responseString = string.Empty;
            string deviceServiceURI = string.Empty;

            CmdBox.Text = commandString;
            RspBox.Text = responseString;
            ServiceUriBox.Text = deviceServiceURI;
            EvtBox.Text = string.Empty;

            ServicePort = null;


            foreach (int port in PortRanges)
            {
                try
                {
                    WebSocketState state;
                    using (var socket = new ClientWebSocket())
                    {
                        var cancels = new CancellationTokenSource();
                        cancels.CancelAfter(40_000);
                        await socket.ConnectAsync(new Uri($"{UriBox.Text}:{port}/xfs4iot/v1.0"), cancels.Token);
                        state = socket.State;
                    }

                    if (state == WebSocketState.Open)
                    {
                        ServicePort = port;
                        var Discovery = new XFS4IoTClient.ClientConnection(new Uri($"{UriBox.Text}:{ServicePort}/xfs4iot/v1.0"));

                        try
                        {
                            await Discovery.ConnectAsync();
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        var getServiceCommand = new GetServicesCommand(RequestId.NewID(), new GetServicesCommand.PayloadData(CommandTimeout));
                        commandString = getServiceCommand.Serialise();
                        await Discovery.SendCommandAsync(getServiceCommand);

                        object cmdResponse = await Discovery.ReceiveMessageAsync();
                        if (cmdResponse is GetServicesCompletion response)
                        {
                            responseString = response.Serialise();
                            var service =
                                (from ep in response.Payload.Services
                                 where ep.ServiceURI.Contains(ServiceName) //ToDo: Correctly identify services.
                                 select ep
                                ).FirstOrDefault()
                                ?.ServiceURI;

                            if (!string.IsNullOrEmpty(service))
                                deviceServiceURI = service;
                        }
                        break;
                    }
                }
                catch (WebSocketException)
                { }
                catch (System.Net.HttpListenerException)
                { }
                catch (TaskCanceledException)
                { }
            }

            if (ServicePort is null)
            {
                PortBox.Text = "";
                MessageBox.Show("Failed on finding services.");
            }
            else
                PortBox.Text = ServicePort.ToString();

            CmdBox.Text = commandString;
            RspBox.Text = responseString;
            ServiceUriBox.Text = deviceServiceURI;
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

            await device.SendCommandAsync(statusCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await device.ReceiveMessageAsync();
            if (cmdResponse is StatusCompletion response)
            {
                RspBox.Text = response.Serialise();
                return response;
            }
            return null;
        }

        public async Task<CapabilitiesCompletion> GetCapabilities()
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

            var capabilitiesCmd = new CapabilitiesCommand(RequestId.NewID(), new CapabilitiesCommand.PayloadData(CommandTimeout));
            CmdBox.Text = capabilitiesCmd.Serialise();

            await device.SendCommandAsync(capabilitiesCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await device.ReceiveMessageAsync();
            if (cmdResponse is CapabilitiesCompletion response)
            {
                RspBox.Text = response.Serialise();
                return response;
            }
            return null;
        }
    }

    internal class RequestId
    {
        internal static int NewID() => Interlocked.Increment(ref id);

        private static int id = 1;
    }
}
