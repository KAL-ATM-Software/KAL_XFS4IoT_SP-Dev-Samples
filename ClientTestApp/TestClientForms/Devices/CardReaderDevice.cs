/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
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

namespace TestClientForms.Devices
{
    public class CardReaderDevice : CommonDevice
    {
        public CardReaderDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.CardReader, InterfaceClass.NameEnum.Common, InterfaceClass.NameEnum.Storage });

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
                    Timeout: CommandTimeout,
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
                    Ddi: false));

            CmdBox.Text = readRawDataCmd.Serialise();

            await cardReader.SendCommandAsync(readRawDataCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await cardReader.ReceiveMessageAsync();
                if (cmdResponse is ReadRawDataCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is XFS4IoT.CardReader.Events.MediaInsertedEvent cardInsertedEv)
                {
                    EvtBox.Text = cardInsertedEv.Serialise();
                }
                else if (cmdResponse is XFS4IoT.CardReader.Events.InsertCardEvent insertCardEv)
                {
                    EvtBox.Text = insertCardEv.Serialise();
                }
                else if (cmdResponse is Acknowledge)
                {
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
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
                    Timeout: CommandTimeout,
                    From: "transport",
                    To: "exit"));

            CmdBox.Text = ejectCmd.Serialise();

            await cardReader.SendCommandAsync(ejectCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case MoveCompletion response:
                        RspBox.Text = response.Serialise();
                        if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                            return;
                        break;

                    case XFS4IoT.CardReader.Events.MediaRemovedEvent removedEv:
                        EvtBox.Text += removedEv.Serialise();
                        return;

                    case Acknowledge ack:
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
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
                    Timeout: CommandTimeout,
                    From: "transport",
                    To: "BIN1"));

            CmdBox.Text = captureCmd.Serialise();

            await cardReader.SendCommandAsync(captureCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case MoveCompletion response:
                        RspBox.Text = response.Serialise();
                        return;
                    case XFS4IoT.Storage.Events.StorageChangedEvent storageChangedEv:
                        EvtBox.Text += storageChangedEv.Serialise();
                        break;

                    case XFS4IoT.Storage.Events.StorageThresholdEvent storageThresholdEv:
                        EvtBox.Text += storageThresholdEv.Serialise();
                        break;
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
                RequestId.NewID(), new ResetCommand.PayloadData(
                    Timeout: CommandTimeout));

            CmdBox.Text = ejectCmd.Serialise();

            await cardReader.SendCommandAsync(ejectCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        RspBox.Text = response.Serialise();
                        return;

                    case XFS4IoT.CardReader.Events.MediaRemovedEvent removedEv:
                        EvtBox.Text += removedEv.Serialise();
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
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
                RequestId.NewID(), new GetStorageCommand.PayloadData(
                    Timeout: CommandTimeout));

            CmdBox.Text = ejectCmd.Serialise();

            await cardReader.SendCommandAsync(ejectCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case GetStorageCompletion response:
                        RspBox.Text = response.Serialise();
                        if (response.Payload.CompletionCode != MessagePayload.CompletionCodeEnum.Success)
                            return;
                        break;

                    case Acknowledge ack:
                        break;

                    default:
                        EvtBox.Text += "<Unknown Event>";
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
                    "BIN1",
                    new XFS4IoT.Storage.SetStorageUnitClass(null,
                                                            new XFS4IoT.CardReader.StorageSetClass(new XFS4IoT.CardReader.StorageConfigurationClass("BIN1", 45),
                                                                                                   new XFS4IoT.CardReader.StorageStatusSetClass(0)))
                }
            };

            var ejectCmd = new SetStorageCommand(
                RequestId.NewID(), new SetStorageCommand.PayloadData(
                    Timeout: CommandTimeout,
                    Storage: setStorage));

            CmdBox.Text = ejectCmd.Serialise();

            await cardReader.SendCommandAsync(ejectCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case SetStorageCompletion response:
                        RspBox.Text = response.Serialise();
                        return;

                    case StorageChangedEvent storageChangedEv:
                        EvtBox.Text += storageChangedEv.Serialise();
                        break;

                    case StorageThresholdEvent storageThresholdEv:
                        EvtBox.Text += storageThresholdEv.Serialise();
                        break;

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
