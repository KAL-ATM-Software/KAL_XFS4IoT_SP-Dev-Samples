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
using XFS4IoT.KeyManagement.Commands;
using XFS4IoT.KeyManagement.Completions;
using XFS4IoT.KeyManagement.Events;
using XFS4IoT.Crypto.Commands;
using XFS4IoT.Crypto.Completions;
using XFS4IoT.Keyboard.Commands;
using XFS4IoT.Keyboard.Completions;
using XFS4IoT.Keyboard.Events;
using XFS4IoT.Keyboard;
using XFS4IoT.PinPad.Commands;
using XFS4IoT.PinPad.Completions;
using XFS4IoT;
using XFS4IoT.Common;

namespace TestClientForms.Devices
{
    public class PinPadDevice : EncryptorDevice
    {
        public PinPadDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public new Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Crypto, InterfaceClass.NameEnum.KeyManagement, InterfaceClass.NameEnum.Keyboard, InterfaceClass.NameEnum.PinPad, InterfaceClass.NameEnum.Common });

        public async Task GetData()
        {
            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new DataEntryCommand(RequestId.NewID(), 
                                           new DataEntryCommand.PayloadData(CommandTimeout,
                                                                            0,
                                                                            true,
                                                                            new()
                                                                            {
                                                                                { "zero", new KeyClass(false) },
                                                                                { "one", new KeyClass(false) },
                                                                                { "two", new KeyClass(false) },
                                                                                { "three", new KeyClass(false) },
                                                                                { "four", new KeyClass(false) },
                                                                                { "five", new KeyClass(false) },
                                                                                { "six", new KeyClass(false) },
                                                                                { "seven", new KeyClass(false) },
                                                                                { "eight", new KeyClass(false) },
                                                                                { "nine", new KeyClass(false) },
                                                                                { "enter", new KeyClass(true) },
                                                                                { "cancel", new KeyClass(true) },
                                                                                { "clear", new KeyClass(false) }
                                                                            }));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is DataEntryCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is KeyEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task GetLayout()
        {
            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetLayoutCommand(RequestId.NewID(), new GetLayoutCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is GetLayoutCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is InitializedEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        private bool SecureKeyEntryPart1Done = false;
        private bool SecureKeyEntryPart2Done = false;

        public async Task SecureKeyEntryPart1()
        {
            await SecureKeyEntry();
            SecureKeyEntryPart1Done = true;
        }
        public async Task SecureKeyEntryPart2()
        {
            await SecureKeyEntry();
            SecureKeyEntryPart2Done = true;
        }

        public async Task ImportAssmblyKey()
        {
            if (!SecureKeyEntryPart1Done ||
                !SecureKeyEntryPart2Done)
            {
                MessageBox.Show("2 parts of key components need to be stored first.");
            }

            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ImportKeyCommand(RequestId.NewID(), 
                                           new ImportKeyCommand.PayloadData(CommandTimeout,
                                                                            Key: "MASTERKEY",
                                                                            KeyAttributes: new ImportKeyCommand.PayloadData.KeyAttributesClass("K0", "T", "B"),
                                                                            VerifyAttributes: new ImportKeyCommand.PayloadData.VerifyAttributesClass(ImportKeyCommand.PayloadData.VerifyAttributesClass.CryptoMethodEnum.KcvZero)));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is ImportKeyCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is InitializedEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);

            SecureKeyEntryPart1Done = false;
            SecureKeyEntryPart2Done = false;
        }

        private async Task SecureKeyEntry()
        {
            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new SecureKeyEntryCommand(RequestId.NewID(), 
                                                new SecureKeyEntryCommand.PayloadData(CommandTimeout,
                                                                                      SecureKeyEntryCommand.PayloadData.KeyLenEnum.Number32,
                                                                                      true,
                                                                                      new()
                                                                                      {
                                                                                        { "one", new KeyClass(false) },
                                                                                        { "two", new KeyClass(false) },
                                                                                        { "three", new KeyClass(false) },
                                                                                        { "four", new KeyClass(false) },
                                                                                        { "five", new KeyClass(false) },
                                                                                        { "six", new KeyClass(false) },
                                                                                        { "seven", new KeyClass(false) },
                                                                                        { "eight", new KeyClass(false) },
                                                                                        { "nine", new KeyClass(false) },
                                                                                        { "enter", new KeyClass(true) },
                                                                                        { "cancel", new KeyClass(true) },
                                                                                        { "shift", new KeyClass(false) },
                                                                                        { "a", new KeyClass(false) },
                                                                                        { "b", new KeyClass(false) },
                                                                                        { "c", new KeyClass(false) },
                                                                                        { "d", new KeyClass(false) },
                                                                                        { "e", new KeyClass(false) },
                                                                                        { "f", new KeyClass(false) },
                                                                                      },
                                                                                      SecureKeyEntryCommand.PayloadData.VerificationTypeEnum.Zero,
                                                                                      SecureKeyEntryCommand.PayloadData.CryptoMethodEnum.TripleDes));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is SecureKeyEntryCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is KeyEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);

            var importKeyCmd = new ImportKeyCommand(RequestId.NewID(), 
                                                    new ImportKeyCommand.PayloadData(CommandTimeout,
                                                                                     Key: "MASTERKEY",
                                                                                     KeyAttributes: new ImportKeyCommand.PayloadData.KeyAttributesClass("K0", "T", "B"),
                                                                                     Constructing: true));

            base.OnXFS4IoTMessages(this, importKeyCmd.Serialise());

            await pinpad.SendCommandAsync(importKeyCmd);

            
            

            completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is ImportKeyCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is InitializedEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        private bool PinBuffered = false;

        public async Task PinEntry()
        {
            PinBuffered = false;

            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new PinEntryCommand(RequestId.NewID(), 
                                          new PinEntryCommand.PayloadData(CommandTimeout,
                                                                          4,
                                                                          4,
                                                                          true,
                                                                          "*",
                                                                          new()
                                                                          {
                                                                              { "one", new KeyClass(false) },
                                                                              { "two", new KeyClass(false) },
                                                                              { "three", new KeyClass(false) },
                                                                              { "four", new KeyClass(false) },
                                                                              { "five", new KeyClass(false) },
                                                                              { "six", new KeyClass(false) },
                                                                              { "seven", new KeyClass(false) },
                                                                              { "eight", new KeyClass(false) },
                                                                              { "nine", new KeyClass(false) },
                                                                              { "enter", new KeyClass(true) },
                                                                              { "cancel", new KeyClass(true) },
                                                                              { "clear", new KeyClass(false) }
                                                                          }));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is PinEntryCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is KeyEvent eventResp)
                { 
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);

            PinBuffered = true;
        }

        public async Task FormatPin()
        {
            if (!PinBuffered)
            {
                MessageBox.Show("PIN must be buffered first.");
                return;
            }

            var pinpad = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await pinpad.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetPinBlockCommand(RequestId.NewID(), 
                                             new GetPinBlockCommand.PayloadData(CommandTimeout,
                                                                                CustomerData: "1234567890123456",
                                                                                Padding: 0xf,
                                                                                Format: GetPinBlockCommand.PayloadData.FormatEnum.Ansi,
                                                                                Key: "PinKey",
                                                                                CryptoMethod: GetPinBlockCommand.PayloadData.CryptoMethodEnum.Ecb));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await pinpad.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await pinpad.ReceiveMessageAsync();
                if (cmdResponse is GetPinBlockCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }

            } while (!completed);

            PinBuffered = false;
        }
    }
}
