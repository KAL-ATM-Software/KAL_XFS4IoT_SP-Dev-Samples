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
using XFS4IoT.CardReader.Commands;
using XFS4IoT.CardReader.Completions;

namespace TestClientForms.Devices
{
    public class CardReaderDevice : CommonDevice
    {
        public CardReaderDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox)
        {
        }

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

            var ejectCmd = new EjectCardCommand(
                RequestId.NewID(), new EjectCardCommand.PayloadData(
                    Timeout: CommandTimeout,
                    EjectPosition: EjectCardCommand.PayloadData.EjectPositionEnum.ExitPosition));

            CmdBox.Text = ejectCmd.Serialise();

            await cardReader.SendCommandAsync(ejectCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case EjectCardCompletion response:
                        RspBox.Text = response.Serialise();
                        if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success)
                            return;
                        break;

                    case XFS4IoT.CardReader.Events.MediaRemovedEvent removedEv:
                        EvtBox.Text += removedEv.Serialise();
                        return;

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

            var captureCmd = new RetainCardCommand(
                RequestId.NewID(), new RetainCardCommand.PayloadData(
                    Timeout: CommandTimeout));

            CmdBox.Text = captureCmd.Serialise();

            await cardReader.SendCommandAsync(captureCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            while (true)
            {
                switch (await cardReader.ReceiveMessageAsync())
                {
                    case RetainCardCompletion response:
                        RspBox.Text = response.Serialise();
                        return;
                    case XFS4IoT.CardReader.Events.MediaRetainedEvent retainedEv:
                        EvtBox.Text += retainedEv.Serialise();
                        break;
                    default:
                        EvtBox.Text += "<Unknown Event>";
                        break;
                }
            }
        }
    }
}
