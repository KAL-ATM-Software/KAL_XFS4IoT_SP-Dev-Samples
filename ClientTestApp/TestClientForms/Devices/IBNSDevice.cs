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
using XFS4IoT.BanknoteNeutralization.Commands;
using XFS4IoT.BanknoteNeutralization.Completions;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;
using XFS4IoTServer;
using XFS4IoT.Storage.Events;
using static XFS4IoT.BanknoteNeutralization.Commands.TriggerNeutralizationCommand.PayloadData;

namespace TestClientForms.Devices
{
    internal class IBNSDevice : CommonDevice
    {
        public IBNSDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.BanknoteNeutralization, InterfaceClass.NameEnum.Common]);

        public async Task SetProtection(XFS4IoT.BanknoteNeutralization.Commands.SetProtectionCommand.PayloadData.NewStateEnum newState)
        {
            var device = await GetConnection();

            var cmd = new SetProtectionCommand(
                RequestId.NewID(),
                new SetProtectionCommand.PayloadData(newState), CommandTimeout);

            await device.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case SetProtectionCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task TriggerNeutralization(XFS4IoT.BanknoteNeutralization.Commands.TriggerNeutralizationCommand.PayloadData.NeutralizationActionEnum trigger)
        {
            var device = await GetConnection();

            var cmd = new TriggerNeutralizationCommand(
                RequestId.NewID(),
                new TriggerNeutralizationCommand.PayloadData(trigger), CommandTimeout);

            await device.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case TriggerNeutralizationCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task GetUnitInfo()
        {
            var device = await GetConnection();

            var cmd = new GetStorageCommand(RequestId.NewID(), CommandTimeout);
            await device.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await device.ReceiveMessageAsync())
                {
                    case GetStorageCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }
    }
}
