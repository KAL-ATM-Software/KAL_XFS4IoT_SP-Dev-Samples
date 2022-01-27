using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.Common;
using XFS4IoT.VendorApplication.Commands;
using XFS4IoT.VendorApplication.Completions;
using XFS4IoT.VendorApplication.Events;

namespace TestClientForms.Devices
{
    internal class VendorAppDevice : CommonDevice
    {
        public VendorAppDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.VendorApplication, InterfaceClass.NameEnum.Common });

        public async Task StartLocalApplication(string appName)
        {
            var device = await GetConnection();

            var cmd = new StartLocalApplicationCommand(RequestId.NewID(),
                                                       new StartLocalApplicationCommand.PayloadData(CommandTimeout, appName));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is StartLocalApplicationCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;

                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                        return;
                }
            } while (!completed);

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case VendorAppExitedEvent response:
                        EvtBox.Text = response.Serialise();
                        return;

                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }

        public async Task<GetActiveInterfaceCompletion> GetActiveInterface()
        {
            var device = await GetConnection();

            var cmd = new GetActiveInterfaceCommand(RequestId.NewID(),
                                                    new GetActiveInterfaceCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            GetActiveInterfaceCompletion resp = null;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetActiveInterfaceCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                    resp = (GetActiveInterfaceCompletion)cmdResponse;
                }
            } while (!completed);

            return resp;
        }
    }
}
