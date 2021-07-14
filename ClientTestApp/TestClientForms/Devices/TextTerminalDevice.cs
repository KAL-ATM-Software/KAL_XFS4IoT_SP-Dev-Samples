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
using XFS4IoT.TextTerminal.Commands;
using XFS4IoT.TextTerminal.Completions;

namespace TestClientForms.Devices
{
    public class TextTerminalDevice : CommonDevice
    {
        public TextTerminalDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox)
        {
        }

        public async Task ClearScreen()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var clearScreenCmd = new ClearScreenCommand(RequestId.NewID(), new ClearScreenCommand.PayloadData(CommandTimeout));

            CmdBox.Text = clearScreenCmd.Serialise();

            await textTerminal.SendCommandAsync(clearScreenCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is ClearScreenCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task Write()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var writeCmd = new WriteCommand(RequestId.NewID(), new WriteCommand.PayloadData(CommandTimeout,
                                                                                            XFS4IoT.TextTerminal.ModesEnum.Absolute,
                                                                                            0,
                                                                                            0,
                                                                                            new(),
                                                                                            "This is some sample text.\nWhich is output on\r\nmultiple lines\n\rthrough newline characters.\rAny text which overflows the current device width will be output on the next available line."));

            CmdBox.Text = writeCmd.Serialise();

            await textTerminal.SendCommandAsync(writeCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is WriteCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }
        public async Task Read()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var writeCmd = new ReadCommand(RequestId.NewID(), new ReadCommand.PayloadData(CommandTimeout,
                                                                                          5,
                                                                                          XFS4IoT.TextTerminal.ModesEnum.Absolute,
                                                                                          0,
                                                                                          0,
                                                                                          ReadCommand.PayloadData.EchoModeEnum.Text,
                                                                                          new ReadCommand.PayloadData.EchoAttrClass(false, false, false),
                                                                                          false,
                                                                                          false,
                                                                                          true,
                                                                                          "1234567890",
                                                                                          new() { "ckEnter", "ckCancel", "ckClear", "ckFDK01", "ckFDK02", "ckFDK03", "ckFDK04", "ckFDK05", "ckFDK06", "ckFDK07", "ckFDK08", },
                                                                                          new() { "ckEnter", "ckCancel" }));

            CmdBox.Text = writeCmd.Serialise();

            await textTerminal.SendCommandAsync(writeCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();

            while(cmdResponse is not ReadCompletion)
            {
                if(cmdResponse is XFS4IoT.TextTerminal.Events.KeyEvent evt)
                {
                    EvtBox.Text = evt.Serialise();
                }
                cmdResponse = await textTerminal.ReceiveMessageAsync();
            }
            if (cmdResponse is ReadCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task GetKeyDetail()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var keyDetailCmd = new GetKeyDetailCommand(RequestId.NewID(), new GetKeyDetailCommand.PayloadData(CommandTimeout));

            CmdBox.Text = keyDetailCmd.Serialise();

            await textTerminal.SendCommandAsync(keyDetailCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is GetKeyDetailCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task Beep()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var beepCmd = new BeepCommand(RequestId.NewID(), new BeepCommand.PayloadData(CommandTimeout, new(null, true)));

            CmdBox.Text = beepCmd.Serialise();

            await textTerminal.SendCommandAsync(beepCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is BeepCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task TurnOnLED()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var setLEDCmd
                = new SetLedCommand(RequestId.NewID(), new SetLedCommand.PayloadData(CommandTimeout, 1, new(SlowFlash: true, Yellow: true)));

            CmdBox.Text = setLEDCmd.Serialise();

            await textTerminal.SendCommandAsync(setLEDCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is SetLedCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task TurnOffLED()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var setLEDCmd = new SetLedCommand(RequestId.NewID(), new SetLedCommand.PayloadData(CommandTimeout, 1, new(Off: true)));

            CmdBox.Text = setLEDCmd.Serialise();

            await textTerminal.SendCommandAsync(setLEDCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is SetLedCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task SetDispLight(bool on)
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var setDispLight = new DispLightCommand(RequestId.NewID(), new DispLightCommand.PayloadData(CommandTimeout, on));

            CmdBox.Text = setDispLight.Serialise();

            await textTerminal.SendCommandAsync(setDispLight);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is DispLightCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task Reset()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var resetCmd = new ResetCommand(RequestId.NewID(), new ResetCommand.PayloadData(CommandTimeout));

            CmdBox.Text = resetCmd.Serialise();

            await textTerminal.SendCommandAsync(resetCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is ResetCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }

        public async Task SetResolution()
        {
            var textTerminal = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await textTerminal.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var resetCmd = new SetResolutionCommand(RequestId.NewID(), new SetResolutionCommand.PayloadData(CommandTimeout, new(16, 16)));

            CmdBox.Text = resetCmd.Serialise();

            await textTerminal.SendCommandAsync(resetCmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await textTerminal.ReceiveMessageAsync();
            if (cmdResponse is SetResolutionCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }
    }
}
