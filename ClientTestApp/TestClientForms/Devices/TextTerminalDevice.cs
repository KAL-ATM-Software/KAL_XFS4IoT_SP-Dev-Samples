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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, clearScreenCmd);
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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, writeCmd);
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
                                                                                          new() { "enter", "cancel", "clear", "fdk01", "fdk02", "fdk03", "fdk04", "fdk05", "fdk06", "fdk07", "fdk08", },
                                                                                          new() { "enter", "cancel" }));

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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, keyDetailCmd);
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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, beepCmd);
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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, setLEDCmd);
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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, setLEDCmd);
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

            var setDispLightCmd = new DispLightCommand(RequestId.NewID(), new DispLightCommand.PayloadData(CommandTimeout, on));

            CmdBox.Text = setDispLightCmd.Serialise();

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, setDispLightCmd);
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

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, resetCmd);
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

            var setResolutionCmd = new SetResolutionCommand(RequestId.NewID(), new SetResolutionCommand.PayloadData(CommandTimeout, new(16, 16)));

            CmdBox.Text = setResolutionCmd.Serialise();

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, setResolutionCmd);
            if (cmdResponse is SetResolutionCompletion response)
            {
                RspBox.Text = response.Serialise();
            }            
        }
    }
}
