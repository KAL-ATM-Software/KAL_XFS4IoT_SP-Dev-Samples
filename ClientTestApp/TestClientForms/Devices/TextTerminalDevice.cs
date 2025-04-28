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
using XFS4IoT.Lights.Completions;
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
            => DoServiceDiscovery([InterfaceClass.NameEnum.TextTerminal, InterfaceClass.NameEnum.Common]);

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

            var cmd = new ClearScreenCommand(RequestId.NewID(), new ClearScreenCommand.PayloadData(), CommandTimeout);
            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case ClearScreenCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new WriteCommand(
                RequestId.NewID(), 
                new WriteCommand.PayloadData(
                    XFS4IoT.TextTerminal.ModesEnum.Absolute,
                    0,
                    0,
                    new(),
                    "This is some sample text.\nWhich is output on\r\nmultiple lines\n\rthrough newline characters.\rAny text which overflows the current device width will be output on the next available line."),
                CommandTimeout);

            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case WriteCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new ReadCommand(
                RequestId.NewID(), 
                new ReadCommand.PayloadData(
                    5,
                    XFS4IoT.TextTerminal.ModesEnum.Absolute,
                    0,
                    0,
                    ReadCommand.PayloadData.EchoModeEnum.Text,
                    new ReadCommand.PayloadData.EchoAttrClass(false, false, false),
                    false,
                    false,
                    true,
                    ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero"],
                    new() { { "enter", new(true) }, { "cancel", new(true) }, { "clear", new(false) }, { "fdk01", new(false) }, { "fdk02", new(false) }, { "fdk03", new(false) }, { "fdk04", new(false) }, { "fdk05", new(false) }, { "fdk06", new(false) }, { "fdk07", new(false) }, { "fdk08", new(false) }, }),
                CommandTimeout);

            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case ReadCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case XFS4IoT.TextTerminal.Events.KeyEvent keyEvent:
                        base.OnXFS4IoTMessages(this, keyEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new GetKeyDetailCommand(RequestId.NewID(), CommandTimeout);
            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case GetKeyDetailCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new BeepCommand(RequestId.NewID(), new BeepCommand.PayloadData(new(null, BeepCommand.PayloadData.BeepClass.BeepTypeEnum.Exclamation)), CommandTimeout);
            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case BeepCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new ResetCommand(RequestId.NewID(), CommandTimeout);
            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
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

            var cmd = new SetResolutionCommand(RequestId.NewID(), new SetResolutionCommand.PayloadData(new(16, 16)), CommandTimeout);
            await textTerminal.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await textTerminal.ReceiveMessageAsync())
                {
                    case SetResolutionCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
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
