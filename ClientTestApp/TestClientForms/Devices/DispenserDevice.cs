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
using XFS4IoT.CashManagement.Commands;
using XFS4IoT.CashManagement.Completions;
using XFS4IoT.CashManagement.Events;
using XFS4IoT.Dispenser.Commands;
using XFS4IoT.Dispenser.Completions;
using XFS4IoT.Dispenser.Events;

namespace TestClientForms.Devices
{
    public class DispenserDevice : CommonDevice
    {
        public DispenserDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox) 
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox)
        {
        }

        public async Task GetCashUnitInfo()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var getCashUnitInfoCmd = new GetCashUnitInfoCommand(RequestId.NewID(), new(CommandTimeout));

            CmdBox.Text = getCashUnitInfoCmd.Serialise();

            await dispenser.SendCommandAsync(getCashUnitInfoCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await dispenser.ReceiveMessageAsync();
            if (cmdResponse is GetCashUnitInfoCompletion response)
            {
                RspBox.Text = response.Serialise();
            }
        }

        public async Task GetMixTypes()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var getMixTypesCmd = new GetMixTypesCommand(RequestId.NewID(), new(CommandTimeout));

            CmdBox.Text = getMixTypesCmd.Serialise();

            await dispenser.SendCommandAsync(getMixTypesCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await dispenser.ReceiveMessageAsync();
            if (cmdResponse is GetMixTypesCompletion response)
            {
                RspBox.Text = response.Serialise();
            }
        }

        public async Task GetPresentStatus()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var getPresentStatusCmd = new GetPresentStatusCommand(RequestId.NewID(), new(CommandTimeout, GetPresentStatusCommand.PayloadData.PositionEnum.Default));

            CmdBox.Text = getPresentStatusCmd.Serialise();

            await dispenser.SendCommandAsync(getPresentStatusCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await dispenser.ReceiveMessageAsync();
            if (cmdResponse is GetPresentStatusCompletion response)
            {
                RspBox.Text = response.Serialise();
            }
        }

        public async Task Denominate()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var denominateCmd = new DenominateCommand(RequestId.NewID(), new(CommandTimeout, null, 1,
                new DenominateCommand.PayloadData.DenominationClass(new Dictionary<string, double>() {
                    { "EUR", 50 }
                })));

            CmdBox.Text = denominateCmd.Serialise();

            await dispenser.SendCommandAsync(denominateCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is DenominateCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }
        public async Task Dispense()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var getPresentStatusCmd = new DispenseCommand(RequestId.NewID(), 
                new(CommandTimeout, null, 1, DispenseCommand.PayloadData.PositionEnum.Default, 
                new DispenseCommand.PayloadData.DenominationClass(new Dictionary<string, double>() {
                    { "EUR", 50 }
                }), 
                "NONCE=254611E63B2531576314E86527338D61,TOKENFORMAT=1,TOKENLENGTH=0164,DISPENSE1=50.00EUR,HMACSHA256=CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2"));

            CmdBox.Text = getPresentStatusCmd.Serialise();

            await dispenser.SendCommandAsync(getPresentStatusCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await dispenser.ReceiveMessageAsync();
            if (cmdResponse is DispenseCompletion response)
            {
                RspBox.Text = response.Serialise();
            }
        }

        public async Task StartExchange()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var startExchangeCmd = new StartExchangeCommand(RequestId.NewID(), 
                                        new(CommandTimeout, StartExchangeCommand.PayloadData.ExchangeTypeEnum.ByHand, null, new() { "1", "2", "3"}));

            CmdBox.Text = startExchangeCmd.Serialise();

            await dispenser.SendCommandAsync(startExchangeCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is StartExchangeCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else if (cmdResponse is NoteErrorEvent noteErrorEv)
                {
                    EvtBox.Text = noteErrorEv.Serialise();
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task EndExchange()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var endExchangeCmd = new EndExchangeCommand(RequestId.NewID(), new(CommandTimeout));

            CmdBox.Text = endExchangeCmd.Serialise();

            await dispenser.SendCommandAsync(endExchangeCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is EndExchangeCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else if (cmdResponse is NoteErrorEvent noteErrorEv)
                {
                    EvtBox.Text = noteErrorEv.Serialise();
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task Present()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var presentCmd = new PresentCommand(RequestId.NewID(), new(CommandTimeout));

            CmdBox.Text = presentCmd.Serialise();

            await dispenser.SendCommandAsync(presentCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is PresentCompletion response)
                {
                    RspBox.Text = response.Serialise();

                    if (response.Payload.CompletionCode != XFS4IoT.Completions.MessagePayload.CompletionCodeEnum.Success ||
                        response.Payload.ErrorCode == PresentCompletion.PayloadData.ErrorCodeEnum.NoItems)
                        break;
                }
                else if (cmdResponse is ItemsTakenEvent itemTakenEv)
                {
                    EvtBox.Text = itemTakenEv.Serialise();
                    break;
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }
        public async Task Reset()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var resetCmd = new ResetCommand(RequestId.NewID(), new(CommandTimeout, null, null, ResetCommand.PayloadData.OutputPositionEnum.Default));

            CmdBox.Text = resetCmd.Serialise();

            await dispenser.SendCommandAsync(resetCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else if (cmdResponse is IncompleteRetractEvent incompleteRetractEv)
                {
                    EvtBox.Text = incompleteRetractEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task OpenShutter()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new OpenShutterCommand(RequestId.NewID(), new(CommandTimeout, OpenShutterCommand.PayloadData.PositionEnum.Default));

            CmdBox.Text = cmd.Serialise();

            await dispenser.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is OpenShutterCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task CloseShutter()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new CloseShutterCommand(RequestId.NewID(), new(CommandTimeout, CloseShutterCommand.PayloadData.PositionEnum.Default));

            CmdBox.Text = cmd.Serialise();

            await dispenser.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is CloseShutterCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task Reject()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new RejectCommand(RequestId.NewID(), new(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await dispenser.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is RejectCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }

        public async Task Retract()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new RetractCommand(RequestId.NewID(), new(CommandTimeout, null, RetractCommand.PayloadData.RetractAreaEnum.Retract, 1));

            CmdBox.Text = cmd.Serialise();

            await dispenser.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is RetractCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    break;
                }
                else if (cmdResponse is CashUnitErrorEvent cashUnitErrorEv)
                {
                    EvtBox.Text = cashUnitErrorEv.Serialise();
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    EvtBox.Text = infoAvailableEv.Serialise();
                }
                else if (cmdResponse is IncompleteRetractEvent incompleteRetractEv)
                {
                    EvtBox.Text = incompleteRetractEv.Serialise();
                }
                else
                {
                    EvtBox.Text += "<Unknown Event>";
                }
            }
        }
    }
}
