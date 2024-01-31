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
using XFS4IoT.BarcodeReader.Commands;
using XFS4IoT.BarcodeReader.Completions;

namespace TestClientForms.Devices
{
    internal class BarcodeReaderDevice : CommonDevice
    {
        public BarcodeReaderDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.BarcodeReader, InterfaceClass.NameEnum.Common });

        public async Task Read()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(),
                                      new ReadCommand.PayloadData(new ReadCommand.PayloadData.SymbologiesClass(QrCode: true)), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ReadCompletion response:
                        base.OnXFS4IoTMessages(this,response.Serialise());
                        return;

                    case Acknowledge ack:
                        break;

                    case XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv:
                        base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task Reset()
        {
            var device = await GetConnection();

            var cmd = new ResetCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        base.OnXFS4IoTMessages(this,response.Serialise());
                        return;

                    case Acknowledge ack:
                        break;
                    
                    case XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv:
                        base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }
    }
}
