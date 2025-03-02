﻿/***********************************************************************************************\
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
using XFS4IoT.VendorApplication.Commands;
using XFS4IoT.VendorApplication.Completions;
using XFS4IoT.VendorApplication.Events;

namespace TestClientForms.Devices
{
    internal class VendorAppDevice : CommonDevice
    {
        public VendorAppDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.VendorApplication, InterfaceClass.NameEnum.Common]);

        public async Task StartLocalApplication(string appName)
        {
            var device = await GetConnection();

            var cmd = new StartLocalApplicationCommand(RequestId.NewID(),
                                                       new StartLocalApplicationCommand.PayloadData(appName), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is StartLocalApplicationCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;

                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                        return;
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!completed);

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case VendorAppExitedEvent response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task<GetActiveInterfaceCompletion> GetActiveInterface()
        {
            var device = await GetConnection();

            var cmd = new GetActiveInterfaceCommand(RequestId.NewID(),
                                                    CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            GetActiveInterfaceCompletion resp = null;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetActiveInterfaceCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                    resp = (GetActiveInterfaceCompletion)cmdResponse;
                }
                else if(cmdResponse is StatusChangedEvent statusChangedEvent)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                }
            } while (!completed);

            return resp;
        }
    }
}
