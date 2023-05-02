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
using XFS4IoT;
using XFS4IoT.Common;

namespace TestClientForms.Devices
{
    public class EncryptorDevice : CommonDevice
    {
        public EncryptorDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Crypto, InterfaceClass.NameEnum.KeyManagement, InterfaceClass.NameEnum.Common });

        public async Task Initialization()
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new InitializationCommand(RequestId.NewID(), new InitializationCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await encryptor.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await encryptor.ReceiveMessageAsync();
                if (cmdResponse is InitializationCompletion response)
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

        public async Task<GetKeyDetailCompletion> GetKeyNames()
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return null;
            }

            var cmd = new GetKeyDetailCommand(RequestId.NewID(), new GetKeyDetailCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is GetKeyDetailCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }

            return (GetKeyDetailCompletion)cmdResponse;
        }

        public async Task Reset()
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ResetCommand(RequestId.NewID(), new ResetCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await encryptor.SendCommandAsync(cmd);

            
            
       
            bool completed = false;
            do
            {
                object cmdResponse = await encryptor.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
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

        public async Task LoadKey(string keyName, string keyUsage, string modeOfUse, List<byte> data)
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ImportKeyCommand(RequestId.NewID(), new ImportKeyCommand.PayloadData(CommandTimeout, 
                                                                                               keyName, 
                                                                                               new ImportKeyCommand.PayloadData.KeyAttributesClass(keyUsage, "T", modeOfUse),
                                                                                               Value:data,
                                                                                               DecryptKey: "MASTERKEY",
                                                                                               DecryptMethod: ImportKeyCommand.PayloadData.DecryptMethodEnum.Ecb));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is ImportKeyCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }

        public async Task GenerateMAC(string keyName, List<byte> data)
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GenerateAuthenticationCommand(RequestId.NewID(), new GenerateAuthenticationCommand.PayloadData(CommandTimeout, 
                                                                                                                         keyName,
                                                                                                                         data));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is GenerateAuthenticationCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }

        public async Task GenerateRandom()
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GenerateRandomCommand(RequestId.NewID(), new GenerateRandomCommand.PayloadData(CommandTimeout));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is GenerateRandomCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }

        public async Task Encrypt(string keyName, List<byte> Data)
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new CryptoDataCommand(RequestId.NewID(), new CryptoDataCommand.PayloadData(CommandTimeout,
                                                                                                 Key: keyName,
                                                                                                 Data: Data,
                                                                                                 CryptoMethod: CryptoDataCommand.PayloadData.CryptoMethodEnum.Ecb));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is CryptoDataCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }

        public async Task DeleteKey(string keyName)
        {
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new DeleteKeyCommand(RequestId.NewID(), new DeleteKeyCommand.PayloadData(CommandTimeout, Key: keyName));

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            
            

            object cmdResponse = await SendAndWaitForCompletionAsync(encryptor, cmd);
            if (cmdResponse is DeleteKeyCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }            
        }
    }
}
