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
using XFS4IoT.Printer;
using XFS4IoT.Printer.Commands;
using XFS4IoT.Printer.Completions;
using XFS4IoT.Printer.Events;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;

namespace TestClientForms.Devices
{
    public class PrinterDevice : CommonDevice
    {
        public PrinterDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Printer, InterfaceClass.NameEnum.Common });

        public async Task<GetMediaListCompletion> GetMediaList()
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return null;
            }

            var cmd = new GetMediaListCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            GetMediaListCompletion cmdCompletion = null;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetMediaListCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                    cmdCompletion = response;
                }

            } while (!completed);

            return cmdCompletion;
        }

        public async Task<GetFormListCompletion> GetFormList()
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return null;
            }

            var cmd = new GetFormListCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            GetFormListCompletion cmdCompletion = null;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetFormListCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                    cmdCompletion = response;
                }

            } while (!completed);

            return cmdCompletion;
        }

        public async Task GetQueryForm(string formName)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetQueryFormCommand(RequestId.NewID(), 
                                              new GetQueryFormCommand.PayloadData(formName), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetQueryFormCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
            } while (!completed);
        }

        public async Task GetQueryMedia(string mediaName)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetQueryMediaCommand(RequestId.NewID(),
                                               new GetQueryMediaCommand.PayloadData(mediaName), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetQueryMediaCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
            } while (!completed);
        }

        public async Task Eject()
        {
            bool waitUntilTaken = false;

            var status = await GetStatus();
            if (status?.Payload?.Printer?.Media == StatusClass.MediaEnum.Present)
            {
                waitUntilTaken = Capabilities?.Payload?.Printer?.MediaTaken is not null && (bool)Capabilities?.Payload?.Printer?.MediaTaken;
            }

            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ControlMediaCommand(RequestId.NewID(), 
                                              new ControlMediaCommand.PayloadData(new ControlMediaCommand.PayloadData.MediaControlClass(Eject: true, Cut:true, Flush:true)), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is ControlMediaCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    if (!waitUntilTaken)
                    {
                        completed = true;
                    }
                }
                else if (cmdResponse is MediaPresentedEvent presentedEv)
                {
                    base.OnXFS4IoTMessages(this, presentedEv.Serialise());
                }
                else if (cmdResponse is MediaTakenEvent mediaTakenEv)
                {
                    base.OnXFS4IoTMessages(this, mediaTakenEv.Serialise());
                    if (waitUntilTaken)
                    {
                        completed = true;
                    }
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!completed);
        }

        public async Task PrintForm(string formName, string mediaName, Dictionary<string, string> fields)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new PrintFormCommand(RequestId.NewID(),
                                              new PrintFormCommand.PayloadData(FormName: formName, 
                                                                               MediaName: mediaName, 
                                                                               Fields: fields,
                                                                               Alignment: PrintFormCommand.PayloadData.AlignmentEnum.FormDefinition), CommandTimeout);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is PrintFormCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
            } while (!completed);
        }

        public async Task PrintRaw(byte[] rawdata)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new PrintRawCommand(RequestId.NewID(),
                                              new PrintRawCommand.PayloadData(PrintRawCommand.PayloadData.InputDataEnum.No,
                                                                              rawdata.ToList()),
                                              CommandTimeout);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is PrintRawCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!completed);
        }

        public async Task Reset()
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ResetCommand(RequestId.NewID(), new ResetCommand.PayloadData("eject"), CommandTimeout);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!completed);
        }

        public async Task DoLoadDefinition(string contents)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new LoadDefinitionCommand(RequestId.NewID(),
                                              new LoadDefinitionCommand.PayloadData(contents, true),
                                              CommandTimeout);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await printer.SendCommandAsync(cmd);


            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is LoadDefinitionCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
                else if(cmdResponse is DefinitionLoadedEvent dle)
                {
                    base.OnXFS4IoTMessages(this, dle.Serialise());
                }
            } while (!completed);
        }
    }
}
