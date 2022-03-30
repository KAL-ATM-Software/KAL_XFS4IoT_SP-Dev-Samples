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

namespace TestClientForms.Devices
{
    public class PrinterDevice : CommonDevice
    {
        public PrinterDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox)
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

            var cmd = new GetMediaListCommand(RequestId.NewID(), new GetMediaListCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            GetMediaListCompletion cmdCompletion = null;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetMediaListCompletion response)
                {
                    RspBox.Text = response.Serialise();
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

            var cmd = new GetFormListCommand(RequestId.NewID(), new GetFormListCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            GetFormListCompletion cmdCompletion = null;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetFormListCompletion response)
                {
                    RspBox.Text = response.Serialise();
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
                                              new GetQueryFormCommand.PayloadData(CommandTimeout, formName));

            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetQueryFormCompletion response)
                {
                    RspBox.Text = response.Serialise();
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
                                               new GetQueryMediaCommand.PayloadData(CommandTimeout, mediaName));

            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is GetQueryMediaCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
            } while (!completed);
        }

        public async Task Eject()
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

            var cmd = new ControlMediaCommand(RequestId.NewID(), 
                                              new ControlMediaCommand.PayloadData(CommandTimeout, 
                                                    new ControlMediaCommand.PayloadData.MediaControlClass(Eject: true, Cut:true, Flush:true)));

            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is ControlMediaCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is MediaPresentedEvent presentedEv)
                {
                    EvtBox.Text = presentedEv.Serialise();
                }
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
                                              new PrintFormCommand.PayloadData(CommandTimeout, 
                                                                               FormName: formName, 
                                                                               MediaName: mediaName, 
                                                                               Fields: fields,
                                                                               Alignment: PrintFormCommand.PayloadData.AlignmentEnum.FormDefinition));
            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is PrintFormCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
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
                                              new PrintRawCommand.PayloadData(CommandTimeout,
                                                                              PrintRawCommand.PayloadData.InputDataEnum.No,
                                                                              rawdata.ToList()));
            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is PrintRawCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
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

            var cmd = new ResetCommand(RequestId.NewID(),
                                       new ResetCommand.PayloadData(CommandTimeout));
            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
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
                                              new LoadDefinitionCommand.PayloadData(CommandTimeout, contents, true));
            CmdBox.Text = cmd.Serialise();

            await printer.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is LoadDefinitionCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if(cmdResponse is DefinitionLoadedEvent dle)
                {
                    EvtBox.Text = dle.Serialise();
                }
            } while (!completed);
        }
    }
}
