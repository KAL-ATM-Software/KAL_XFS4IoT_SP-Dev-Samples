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
using XFS4IoT.Common.Events;
using XFS4IoT.Storage.Completions;
using XFS4IoT.Storage.Events;

namespace TestClientForms.Devices
{
    public class EncryptorDevice : CommonDevice
    {
        public EncryptorDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.Crypto, InterfaceClass.NameEnum.KeyManagement, InterfaceClass.NameEnum.Common]);

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

            var cmd = new InitializationCommand(RequestId.NewID(), null, CommandTimeout);
            base.OnXFS4IoTMessages(this, cmd.Serialise());
            await encryptor.SendCommandAsync(cmd);

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case InitializationCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case InitializedEvent initializedEvent:
                        base.OnXFS4IoTMessages(this, initializedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
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

            var cmd = new GetKeyDetailCommand(RequestId.NewID(), new GetKeyDetailCommand.PayloadData(), CommandTimeout);
            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case GetKeyDetailCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return response;
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
            var encryptor = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await encryptor.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ResetCommand(RequestId.NewID(), CommandTimeout);
            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case ResetCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case InitializedEvent initializedEvent:
                        base.OnXFS4IoTMessages(this, initializedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
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

            var cmd = new ImportKeyCommand(
                RequestId.NewID(), 
                new ImportKeyCommand.PayloadData( 
                    keyName, 
                    new ImportKeyCommand.PayloadData.KeyAttributesClass(keyUsage, "T", modeOfUse),
                    Value:data,
                    DecryptKey: "MASTERKEY",
                    DecryptMethod: ImportKeyCommand.PayloadData.DecryptMethodEnum.Ecb),
                CommandTimeout);

            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case ImportKeyCompletion response:
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

            var cmd = new GenerateAuthenticationCommand(
                RequestId.NewID(), 
                new GenerateAuthenticationCommand.PayloadData(keyName, data), 
                CommandTimeout);
            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case GenerateAuthenticationCompletion response:
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

            var cmd = new GenerateRandomCommand(RequestId.NewID(), CommandTimeout);
            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case GenerateRandomCompletion response:
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

            var cmd = new CryptoDataCommand(
                RequestId.NewID(), 
                new CryptoDataCommand.PayloadData(
                    Key: keyName,
                    Data: Data,
                    CryptoMethod: CryptoDataCommand.PayloadData.CryptoMethodEnum.Ecb),
                CommandTimeout);

            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case CryptoDataCompletion response:
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

            var cmd = new DeleteKeyCommand(
                RequestId.NewID(), 
                new DeleteKeyCommand.PayloadData(Key: keyName), 
                CommandTimeout);
            await encryptor.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await encryptor.ReceiveMessageAsync())
                {
                    case DeleteKeyCompletion response:
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
