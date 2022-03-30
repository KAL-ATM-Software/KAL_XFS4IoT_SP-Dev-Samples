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
        public BarcodeReaderDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.BarcodeReader, InterfaceClass.NameEnum.Common });

        public async Task Read()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(),
                                      new ReadCommand.PayloadData(CommandTimeout, new XFS4IoT.BarcodeReader.SymbologiesPropertiesClass(QrCode: true)));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ReadCompletion response:
                        RspBox.Text = response.Serialise();
                        return;

                    case Acknowledge ack:
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }

        public async Task Reset()
        {
            var device = await GetConnection();

            var cmd = new ResetCommand(RequestId.NewID(),
                                       new ResetCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        RspBox.Text = response.Serialise();
                        return;

                    case Acknowledge ack:
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }
    }
}
