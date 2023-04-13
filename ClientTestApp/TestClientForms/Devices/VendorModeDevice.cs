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
        public VendorModeDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.VendorMode, InterfaceClass.NameEnum.Common });

        public async Task EnterModeRequest()
        {
            var device = await GetConnection();

            var cmd = new EnterModeRequestCommand(RequestId.NewID(),
                                                  new EnterModeRequestCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            bool enteredEventReceived = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is EnterModeRequestCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeEnteredEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                    enteredEventReceived = true;
                }
            } while (!completed);


            while (!enteredEventReceived)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ModeEnteredEvent response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        enteredEventReceived = true;
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task ExitModeRequest()
        {
            var device = await GetConnection();

            var cmd = new ExitModeRequestCommand(RequestId.NewID(),
                                                 new ExitModeRequestCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            bool exitEventReceived = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ExitModeRequestCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeExitedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                    exitEventReceived = true;
                }
            } while (!completed);

            while (!exitEventReceived)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ModeExitedEvent response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        exitEventReceived = true;
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }
    }
}
