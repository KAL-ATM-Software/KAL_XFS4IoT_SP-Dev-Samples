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
using XFS4IoT.Storage.Events;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestClientForms.Devices
{
    public class PrinterDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox) : 
        CommonDevice(serviceName, uriBox, portBox, serviceUriBox)
    {
        public Task DoServiceDiscovery()
            => DoServiceDiscovery([ InterfaceClass.NameEnum.Printer, InterfaceClass.NameEnum.Common ]);

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

            var cmd = new GetQueryFormCommand(
                RequestId.NewID(), 
                new GetQueryFormCommand.PayloadData(formName), 
                CommandTimeout);

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

            var cmd = new GetQueryMediaCommand(
                RequestId.NewID(),
                new GetQueryMediaCommand.PayloadData(mediaName),
                CommandTimeout);

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

            var cmd = new ControlMediaCommand(
                RequestId.NewID(),
                new ControlMediaCommand.PayloadData(
                    MediaControl: new (Move: MediaControlClass.MoveEnum.Eject, Cut:true, Flush:true)),
                CommandTimeout);

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

        public async Task PrintForm(string formName, string mediaName, Dictionary<string, List<string>> fields)
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

            var cmd = new PrintFormCommand(
                RequestId.NewID(),
                new PrintFormCommand.PayloadData(
                    FormName: formName, 
                    MediaName: mediaName, 
                    Fields: fields,
                    Alignment: PrintFormCommand.PayloadData.AlignmentEnum.FormDefinition), 
                CommandTimeout);
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

            var cmd = new PrintRawCommand(
                RequestId.NewID(),
                new PrintRawCommand.PayloadData(
                    PrintRawCommand.PayloadData.InputDataEnum.No,
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

            var cmd = new ResetCommand(
                RequestId.NewID(), 
                new ResetCommand.PayloadData("eject"), 
                CommandTimeout);
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
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is StorageErrorEvent storageErrorEv)
                {
                    base.OnXFS4IoTMessages(this, storageErrorEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
            } while (!completed);
        }
        internal class Base64Converter : JsonConverter<List<byte>>
        {
            public override List<byte> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return [.. reader.GetBytesFromBase64()];
            }

            public override void Write(Utf8JsonWriter writer, List<byte> value, JsonSerializerOptions options)
            {
                writer.WriteBase64StringValue(value.ToArray());
            }
        }

        public async Task DoSetFormOrMedia(string contents, bool Form)
        {
            var printer = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            JsonSerializerOptions jsonOptions = new()
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase), new Base64Converter() },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            try
            {
                await printer.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            if (Form)
            {
                var payload = JsonSerializer.Deserialize<SetFormCommand.PayloadData>(contents, jsonOptions);

                var cmd = new SetFormCommand(
                    RequestId.NewID(),
                    payload,
                    CommandTimeout);

                base.OnXFS4IoTMessages(this, cmd.Serialise());
                await printer.SendCommandAsync(cmd);
            }
            else
            {
                var payload = JsonSerializer.Deserialize<SetMediaCommand.PayloadData>(contents, jsonOptions);

                var cmd = new SetMediaCommand(
                    RequestId.NewID(),
                    payload,
                    CommandTimeout);

                base.OnXFS4IoTMessages(this, cmd.Serialise());
                await printer.SendCommandAsync(cmd);
            }

            bool completed = false;
            do
            {
                object cmdResponse = await printer.ReceiveMessageAsync();
                if (cmdResponse is SetMediaCompletion mediaComp)
                {
                    base.OnXFS4IoTMessages(this, mediaComp.Serialise());
                    completed = true;
                }
                else if (cmdResponse is SetFormCompletion formComp)
                {
                    base.OnXFS4IoTMessages(this, formComp.Serialise());
                    completed = true;
                }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            } while (!completed);
        }
    }
}
