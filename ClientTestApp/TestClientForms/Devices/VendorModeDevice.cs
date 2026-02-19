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
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;
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
            => DoServiceDiscovery([InterfaceClass.NameEnum.VendorMode, InterfaceClass.NameEnum.Common]);

        public async Task EnterModeRequest()
        {
            var device = await GetConnection();

            object cmdResponse;
            if (!Registered)
            {
                var registerCmd = new RegisterCommand(RequestId.NewID(), new("VDA-TEST"), 3000);
                base.OnXFS4IoTMessages(this, registerCmd.Serialise());

                await device.SendCommandAsync(registerCmd);

                for (; ; )
                {
                    cmdResponse = await device.ReceiveMessageAsync();
                    if (cmdResponse is RegisterCompletion response)
                    {
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        break;
                    }
                    else if (cmdResponse is StatusChangedEvent statusChangedEv)
                    {
                        base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                    }
                    else if (cmdResponse is Acknowledge)
                    {
                    }
                    else
                    {
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                    }
                }

                Registered = true;
            }

            var cmd = new EnterModeRequestCommand(RequestId.NewID(), 10000);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool enteredEventReceived = false;

            do
            {
                cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is EnterModeRequestCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeEnteredEvent modeEnteredEv)
                {
                    base.OnXFS4IoTMessages(this, modeEnteredEv.Serialise());
                    enteredEventReceived = true;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is EnterModeRequestEvent enterModeReqEv)
                {
                    // request event received, send acknowledge for the command
                    base.OnXFS4IoTMessages(this, enterModeReqEv.Serialise());

                    var ackEnterCmd = new EnterModeAcknowledgeCommand(RequestId.NewID(), 3000);
                    base.OnXFS4IoTMessages(this, ackEnterCmd.Serialise());

                    await device.SendCommandAsync(ackEnterCmd);
                    for (; ; )
                    {
                        cmdResponse = await device.ReceiveMessageAsync();
                        if (cmdResponse is EnterModeAcknowledgeCompletion ackEnterResponse)
                        {
                            base.OnXFS4IoTMessages(this, ackEnterResponse.Serialise());
                            break;
                        }
                        else if (cmdResponse is StatusChangedEvent statusChangedEv1)
                        {
                            base.OnXFS4IoTMessages(this, statusChangedEv1.Serialise());
                        }
                        else if (cmdResponse is ModeEnteredEvent modeEnteredEv1)
                        {
                            base.OnXFS4IoTMessages(this, modeEnteredEv1.Serialise());
                            enteredEventReceived = true;
                        }
                        else if (cmdResponse is Acknowledge)
                        {
                        }
                        else
                        {
                            base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        }
                    }
                }
                else if (cmdResponse is Acknowledge)
                { }

            } while (!enteredEventReceived);
        }

        public async Task ExitModeRequest()
        {
            var device = await GetConnection();

            var cmd = new ExitModeRequestCommand(RequestId.NewID(),
                                                 CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);


            bool exitEventReceived = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ExitModeRequestCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is ModeExitedEvent modeExitedEv)
                {
                    base.OnXFS4IoTMessages(this, modeExitedEv.Serialise());
                    exitEventReceived = true;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is ExitModeRequestEvent exitModeReqEv)
                {
                    // request event received, send acknowledge for the command
                    base.OnXFS4IoTMessages(this, exitModeReqEv.Serialise());

                    var ackExitCmd = new ExitModeAcknowledgeCommand(RequestId.NewID(), 3000);
                    base.OnXFS4IoTMessages(this, ackExitCmd.Serialise());

                    await device.SendCommandAsync(ackExitCmd);
                    for (; ; )
                    {
                        cmdResponse = await device.ReceiveMessageAsync();
                        if (cmdResponse is ExitModeAcknowledgeCompletion ackExitResponse)
                        {
                            base.OnXFS4IoTMessages(this, ackExitResponse.Serialise());
                            break;
                        }
                        else if (cmdResponse is StatusChangedEvent statusChangedEv1)
                        {
                            base.OnXFS4IoTMessages(this, statusChangedEv1.Serialise());
                        }
                        else if (cmdResponse is ModeExitedEvent modeExitedEv1)
                        {
                            base.OnXFS4IoTMessages(this, modeExitedEv1.Serialise());
                            exitEventReceived = true;
                        }
                        else if (cmdResponse is Acknowledge)
                        {
                        }
                        else
                        {
                            base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        }
                    }
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!exitEventReceived);
        }

        bool Registered { get; set; } = false;
    }
}
