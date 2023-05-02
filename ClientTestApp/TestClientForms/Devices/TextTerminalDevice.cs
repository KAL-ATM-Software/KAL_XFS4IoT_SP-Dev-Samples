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
using XFS4IoT.Common;
using XFS4IoT.TextTerminal.Commands;
using XFS4IoT.TextTerminal.Completions;

namespace TestClientForms.Devices
{
    public class TextTerminalDevice : CommonDevice
    {
        public TextTerminalDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.TextTerminal, InterfaceClass.NameEnum.Common });

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

            base.OnXFS4IoTMessages(this, clearScreenCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, clearScreenCmd);
            if (cmdResponse is ClearScreenCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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

            base.OnXFS4IoTMessages(this, writeCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, writeCmd);
            if (cmdResponse is WriteCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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
                                                                                          new() { { "enter", new(true) }, { "cancel", new(true) }, { "clear", new() }, { "fdk01", new() }, { "fdk02", new() }, { "fdk03", new() }, { "fdk04", new() }, { "fdk05", new() }, { "fdk06", new() }, { "fdk07", new() }, { "fdk08", new() }, }));

            base.OnXFS4IoTMessages(this, writeCmd.Serialise());

            await textTerminal.SendCommandAsync(writeCmd);

            
            

            object cmdResponse = await textTerminal.ReceiveMessageAsync();

            while(cmdResponse is not ReadCompletion)
            {
                if(cmdResponse is XFS4IoT.TextTerminal.Events.KeyEvent evt)
                {
                    base.OnXFS4IoTMessages(this, evt.Serialise());
                }
                cmdResponse = await textTerminal.ReceiveMessageAsync();
            }
            if (cmdResponse is ReadCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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

            base.OnXFS4IoTMessages(this, keyDetailCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, keyDetailCmd);
            if (cmdResponse is GetKeyDetailCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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

            var beepCmd = new BeepCommand(RequestId.NewID(), new BeepCommand.PayloadData(CommandTimeout, new(null, BeepCommand.PayloadData.BeepClass.BeepTypeEnum.Exclamation)));

            base.OnXFS4IoTMessages(this, beepCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, beepCmd);
            if (cmdResponse is BeepCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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

            base.OnXFS4IoTMessages(this, resetCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, resetCmd);
            if (cmdResponse is ResetCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
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

            base.OnXFS4IoTMessages(this, setResolutionCmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(textTerminal, setResolutionCmd);
            if (cmdResponse is SetResolutionCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }
    }
}
