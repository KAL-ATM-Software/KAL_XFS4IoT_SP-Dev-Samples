/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.Common;
using XFS4IoT.VendorMode.Commands;
using XFS4IoT.VendorMode.Completions;
using XFS4IoT.VendorMode.Events;

namespace TestClientForms.Devices
{
    internal class VendorModeDevice : CommonDevice
    {
        public VendorModeDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.VendorMode, InterfaceClass.NameEnum.Common });

        public async Task EnterModeRequest()
        {
            var device = await GetConnection();

            var cmd = new EnterModeRequestCommand(RequestId.NewID(),
                                                  new EnterModeRequestCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            bool enteredEventReceived = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is EnterModeRequestCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeEnteredEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                    enteredEventReceived = true;
                }
            } while (!completed);


            while (!enteredEventReceived)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ModeEnteredEvent response:
                        EvtBox.Text = response.Serialise();
                        enteredEventReceived = true;
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }

        public async Task ExitModeRequest()
        {
            var device = await GetConnection();

            var cmd = new ExitModeRequestCommand(RequestId.NewID(),
                                                 new ExitModeRequestCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            bool exitEventReceived = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ExitModeRequestCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeExitedEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                    exitEventReceived = true;
                }
            } while (!completed);

            while (!exitEventReceived)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ModeExitedEvent response:
                        EvtBox.Text = response.Serialise();
                        exitEventReceived = true;
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }
    }
}
