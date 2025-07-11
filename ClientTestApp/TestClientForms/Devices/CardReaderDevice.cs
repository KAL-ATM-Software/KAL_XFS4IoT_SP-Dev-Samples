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
using XFS4IoT.Completions;
using XFS4IoT.CardReader.Commands;
using XFS4IoT.CardReader.Completions;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;
using XFS4IoT.Storage.Events;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;
using XFS4IoT.CardReader.Events;

namespace TestClientForms.Devices
{
    public class CardReaderDevice : CommonDevice
    {
        public CardReaderDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([ InterfaceClass.NameEnum.CardReader, InterfaceClass.NameEnum.Common ]);

        public async Task AcceptCard()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var readRawDataCmd = new ReadRawDataCommand(
                RequestId.NewID(),
                new ReadRawDataCommand.PayloadData(
                    Track1: true,
                    Track2: true,
                    Track3: true,
                    Chip: false,
                    Security: false,
                    FluxInactive: false,
                    Watermark: false,
                    MemoryChip: false,
                    Track1Front: false,
                    FrontImage: false,
                    BackImage: false,
                    Track1JIS: false,
                    Track3JIS: false,
                    Ddi: false), 
                CommandTimeout);

            base.OnXFS4IoTMessages(this, readRawDataCmd.Serialise());

            await cardReader.SendCommandAsync(readRawDataCmd);

            for (; ; )
            {
                object cmdResponse = await cardReader.ReceiveMessageAsync();
                if (cmdResponse is ReadRawDataCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    break;
                }
                else if (cmdResponse is XFS4IoT.CardReader.Events.MediaInsertedEvent cardInsertedEv)
                {
                    base.OnXFS4IoTMessages(this, cardInsertedEv.Serialise());
                }
                else if (cmdResponse is XFS4IoT.CardReader.Events.InsertCardEvent insertCardEv)
                {
                    base.OnXFS4IoTMessages(this, insertCardEv.Serialise());
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
            }
        }

        public async Task EjectCard()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var ejectCmd = new MoveCommand(
                RequestId.NewID(), new MoveCommand.PayloadData(
                    From: "transport",
                    To: "exit"),
                CommandTimeout);

            base.OnXFS4IoTMessages(this, ejectCmd.Serialise());

            await cardReader.SendCommandAsync(ejectCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case MoveCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                            return;
                        break;

                    case XFS4IoT.CardReader.Events.MediaRemovedEvent removedEv:
                        base.OnXFS4IoTMessages(this, removedEv.Serialise());
                        return;

                    case XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv:
                        base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.StorageChangedEvent storageChangedEv:
                        base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.CountsChangedEvent countChangedEv:
                        base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task CaptureCard()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var captureCmd = new MoveCommand(
                RequestId.NewID(), new MoveCommand.PayloadData(
                    From: "transport",
                    To: "unitBIN1"),
                CommandTimeout);

            base.OnXFS4IoTMessages(this, captureCmd.Serialise());

            await cardReader.SendCommandAsync(captureCmd);


            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case MoveCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case XFS4IoT.Storage.Events.StorageChangedEvent storageChangedEv:
                        base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.StorageThresholdEvent storageThresholdEv:
                        base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                        break;

                    case XFS4IoT.Common.Events.StatusChangedEvent statusChangedEv:
                        base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.CountsChangedEvent countChangedEv:
                        base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                        break;

                    case Acknowledge ack:
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task Reset()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var ejectCmd = new ResetCommand(
                RequestId.NewID(), new(To: ResetCommand.PayloadData.ToEnum.Auto), CommandTimeout);

            base.OnXFS4IoTMessages(this, ejectCmd.Serialise());

            await cardReader.SendCommandAsync(ejectCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;

                    case XFS4IoT.CardReader.Events.MediaRemovedEvent removedEv:
                        base.OnXFS4IoTMessages(this, removedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.StorageChangedEvent storageChangedEv:
                        base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.CountsChangedEvent countChangedEv:
                        base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task GetStorage()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var ejectCmd = new GetStorageCommand(
                RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, ejectCmd.Serialise());

            await cardReader.SendCommandAsync(ejectCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case GetStorageCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                            return;
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task ResetBinCount()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            Dictionary<string, XFS4IoT.Storage.SetStorageUnitClass> setStorage = new()
            {
                {
                    "unitBIN1",
                    new XFS4IoT.Storage.SetStorageUnitClass(null,
                                                            new XFS4IoT.CardReader.StorageSetClass(new XFS4IoT.CardReader.StorageConfigurationClass("BIN1", 45),
                                                                                                   new XFS4IoT.CardReader.StorageStatusSetClass(0)))
                }
            };

            var ejectCmd = new SetStorageCommand(
                RequestId.NewID(), new SetStorageCommand.PayloadData(
                    Storage: setStorage),
                    Timeout: CommandTimeout);

            base.OnXFS4IoTMessages(this, ejectCmd.Serialise());

            await cardReader.SendCommandAsync(ejectCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case SetStorageCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;

                    case StorageChangedEvent storageChangedEv:
                        base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                        break;

                    case StorageThresholdEvent storageThresholdEv:
                        base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                        break;

                    case XFS4IoT.Storage.Events.CountsChangedEvent countChangedEv:
                        base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task EMVClessQueryApplications()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var emvQueryAppCmd = new EMVClessQueryApplicationsCommand(
                RequestId.NewID(),
                Timeout: CommandTimeout);

            base.OnXFS4IoTMessages(this, emvQueryAppCmd.Serialise());

            await cardReader.SendCommandAsync(emvQueryAppCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case EMVClessQueryApplicationsCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChanged:
                        base.OnXFS4IoTMessages(this, statusChanged.Serialise());
                        break;
                    case Acknowledge ack:
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task EMVClessPerformTransaction()
        {
            var cardReader = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await cardReader.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var emvPerformTxnCmd = new EMVClessPerformTransactionCommand(
                RequestId.NewID(), 
                new EMVClessPerformTransactionCommand.PayloadData(
                    Data: 
                    [
                        0x5F, 0x36, 0x01, 0x03,
                        0x5F, 0x2A, 0x02, 0x09, 0x78,
                        0x9F, 0x1A, 0x02, 0x03, 0x80,
                        0x9F, 0x02, 0x06, 00, 00, 00, 00, 00, 00, 
                        0x9C, 0x01, 0x01
                    ]),
                Timeout: CommandTimeout);

            base.OnXFS4IoTMessages(this, emvPerformTxnCmd.Serialise());

            await cardReader.SendCommandAsync(emvPerformTxnCmd);

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case EMVClessPerformTransactionCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case MediaRemovedEvent mediaRemoved:
                        base.OnXFS4IoTMessages(this, mediaRemoved.Serialise());
                        break;
                    case StatusChangedEvent statusChanged:
                        base.OnXFS4IoTMessages(this, statusChanged.Serialise());
                        break;
                    case Acknowledge ack:
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }
    }
}
