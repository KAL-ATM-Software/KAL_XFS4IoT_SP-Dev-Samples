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
using XFS4IoT.Biometric.Commands;
using XFS4IoT.Biometric.Completions;
using XFS4IoT.Common;

namespace TestClientForms.Devices
{
    public class BiometricDevice : CommonDevice
    {
        public BiometricDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Biometric, InterfaceClass.NameEnum.Common });


        public async Task Clear()
        {
            var device = await GetConnection();

            var cmd = new ClearCommand(RequestId.NewID(), new ClearCommand.PayloadData(CommandTimeout, null));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ClearCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
            } while (!completed);
        }

        public async Task Reset()
        {
            var device = await GetConnection();

            var cmd = new ResetCommand(RequestId.NewID(), new ResetCommand.PayloadData(CommandTimeout, null));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
            } while (!completed);
        }

        public async Task<string> Read()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(), new ReadCommand.PayloadData(CommandTimeout, new List<XFS4IoT.Biometric.DataTypeClass>()
            {
                new XFS4IoT.Biometric.DataTypeClass(XFS4IoT.Biometric.DataTypeClass.FormatEnum.ReservedTemplate1, null, null)
            }, 1, ReadCommand.PayloadData.ModeEnum.Scan));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            string retVal = "";
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ReadCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                    if (response?.Payload?.DataRead is not null && response.Payload.DataRead.Count > 0 && response.Payload.DataRead[0].Data != null)
                        retVal = Convert.ToBase64String(response.Payload.DataRead[0].Data.ToArray());
                }
                else
                {
                    EvtBox.Text = (cmdResponse as MessageBase).Serialise();
                }
            } while (!completed);
            return retVal;
        }

        public async Task ReadMatch()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(), new ReadCommand.PayloadData(CommandTimeout, null, 1, ReadCommand.PayloadData.ModeEnum.Match));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ReadCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else
                {
                    EvtBox.Text = (cmdResponse as MessageBase).Serialise();
                }
            } while (!completed);
        }

        public async Task Import(string base64TemplateData)
        {
            var device = await GetConnection();

            var cmd = new ImportCommand(RequestId.NewID(), new ImportCommand.PayloadData(CommandTimeout, new()
            {
                new XFS4IoT.Biometric.BioDataClass(new XFS4IoT.Biometric.DataTypeClass(XFS4IoT.Biometric.DataTypeClass.FormatEnum.ReservedTemplate1, null, null), Convert.FromBase64String(base64TemplateData).ToList())
            }));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ImportCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else
                {
                    EvtBox.Text = (cmdResponse as MessageBase).Serialise();
                }
            } while (!completed);
        }

        public async Task Match(string identifier)
        {
            var device = await GetConnection();

            var cmd = new MatchCommand(RequestId.NewID(), new MatchCommand.PayloadData(CommandTimeout, MatchCommand.PayloadData.CompareModeEnum.Verify, identifier, null, 50));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is MatchCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else
                {
                    EvtBox.Text = (cmdResponse as MessageBase).Serialise();
                }
            } while (!completed);
        }

        public async Task<List<string>> GetStorageInfo()
        {
            var device = await GetConnection();

            var cmd = new GetStorageInfoCommand(RequestId.NewID(), new GetStorageInfoCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            List<string> identifiers = new();
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetStorageInfoCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;

                    if (response?.Payload?.Templates is { Count: > 0 })
                        identifiers = response.Payload.Templates.Keys.ToList();
                }
                else
                {
                    EvtBox.Text = (cmdResponse as MessageBase).Serialise();
                }
            } while (!completed);
            return identifiers;
        }
    }
}
