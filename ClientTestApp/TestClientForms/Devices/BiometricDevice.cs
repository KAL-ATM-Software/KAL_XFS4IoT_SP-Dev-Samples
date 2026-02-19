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
        public BiometricDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.Biometric, InterfaceClass.NameEnum.Common]);


        public async Task Clear()
        {
            var device = await GetConnection();

            var cmd = new ClearCommand(RequestId.NewID(), null, CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ClearCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
        }

        public async Task Reset()
        {
            var device = await GetConnection();

            var cmd = new ResetCommand(RequestId.NewID(), null, CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
        }

        public async Task<string> Read()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(), new ReadCommand.PayloadData(new List<XFS4IoT.Biometric.DataTypeClass>()
            {
                new XFS4IoT.Biometric.DataTypeClass(XFS4IoT.Biometric.DataTypeClass.FormatEnum.ReservedTemplate1, null, null)
            }, 1, ReadCommand.PayloadData.ModeEnum.Scan), 
            CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            string retVal = "";
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ReadCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                    if (response?.Payload?.DataRead is not null && response.Payload.DataRead.Count > 0 && response.Payload.DataRead[0].Data != null)
                        retVal = Convert.ToBase64String(response.Payload.DataRead[0].Data.ToArray());
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
            return retVal;
        }

        public async Task ReadMatch()
        {
            var device = await GetConnection();

            var cmd = new ReadCommand(RequestId.NewID(), new ReadCommand.PayloadData(null, 1, ReadCommand.PayloadData.ModeEnum.Match), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ReadCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
        }

        public async Task Import(string base64TemplateData)
        {
            var device = await GetConnection();

            var cmd = new ImportCommand(RequestId.NewID(), new ImportCommand.PayloadData(new()
            {
                new XFS4IoT.Biometric.BioDataClass(new XFS4IoT.Biometric.DataTypeClass(XFS4IoT.Biometric.DataTypeClass.FormatEnum.ReservedTemplate1, null, null), Convert.FromBase64String(base64TemplateData).ToList())
            }), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ImportCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
        }

        public async Task Match(string identifier)
        {
            var device = await GetConnection();

            var cmd = new MatchCommand(RequestId.NewID(), new MatchCommand.PayloadData(MatchCommand.PayloadData.CompareModeEnum.Verify, identifier, null, 50), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is MatchCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
        }

        public async Task<List<string>> GetStorageInfo()
        {
            var device = await GetConnection();

            var cmd = new GetStorageInfoCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            bool completed = false;
            List<string> identifiers = new();
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetStorageInfoCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;

                    if (response?.Payload?.Templates is { Count: > 0 })
                        identifiers = response.Payload.Templates.Keys.ToList();
                }
                else if (cmdResponse is XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv)
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
            } while (!completed);
            return identifiers;
        }
    }
}
