/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2024
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.Check;
using XFS4IoT.Check.Commands;
using XFS4IoT.Check.Completions;
using XFS4IoT.Check.Events;
using XFS4IoT.Storage;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;
using XFS4IoT.Storage.Events;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;
using System.Runtime.CompilerServices;

namespace TestClientForms.Devices
{
    public class CheckScannerDevice(
        string serviceName, 
        TextBox uriBox, 
        TextBox portBox, 
        TextBox serviceUriBox) : 
        CommonDevice(
            serviceName, 
            uriBox, 
            portBox, 
            serviceUriBox)
    {
        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.Check, InterfaceClass.NameEnum.Storage, InterfaceClass.NameEnum.Common]);

        public async Task GetCheckUnitInfo()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetStorageCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());
           
            object cmdResponse = await SendAndWaitForCompletionAsync(client, cmd);
            if (cmdResponse is GetStorageCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }
        }

        public async Task SetCheckUnitInfo()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            /// Reset counts to zero
            Dictionary<string, XFS4IoT.Storage.SetStorageUnitClass> storage = new()
            {
                {
                    "unit1",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                        Check: new(
                            Status: new(
                                Initial: new(
                                    MediaInCount: 0,
                                    Count: 0,
                                    RetractOperations: 0)
                                )
                            )
                        )
                },
                {
                    "unitRetract",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                        Check: new(
                            Status: new(
                                Initial: new(
                                    MediaInCount: 0, 
                                    Count: 0, 
                                    RetractOperations: 0)
                                )
                            )
                        )
                }
            };
            var cmd = new SetStorageCommand(RequestId.NewID(), new(storage), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is SetStorageCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task GetTransactionStatus()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetTransactionStatusCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            object cmdResponse = await SendAndWaitForCompletionAsync(client, cmd);
            if (cmdResponse is GetTransactionStatusCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());

                GetTransactionStatusPayload = response.Payload;
            }
        }

        private GetTransactionStatusCompletion.PayloadData GetTransactionStatusPayload = null;

        public async Task StartExchange()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new StartExchangeCommand(RequestId.NewID(), 
                                        CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);


            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is StartExchangeCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task EndExchange()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new EndExchangeCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is EndExchangeCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task Reset()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new ResetCommand(RequestId.NewID(), new(MediaControl: "unitRetract"), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is MediaDetectedEvent mediaDetectedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaDetectedEv.Serialise());
                }
                else if (cmdResponse is MediaPresentedEvent mediaPresentedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaPresentedEv.Serialise());
                }
                else if (cmdResponse is StorageErrorEvent storageErrorEv)
                {
                    base.OnXFS4IoTMessages(this, storageErrorEv.Serialise());
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task MediaIn()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new MediaInCommand(
                RequestId.NewID(), 
                new(
                    CodelineFormat: CodelineFormatEnum.Cmc7,
                    Image: [
                        new(
                            Source: ImageSourceEnum.Front, 
                            Type: ImageTypeEnum.Bmp, 
                            ColorFormat: ImageColorFormatEnum.Binary, 
                            ScanColor: ImageScanColorEnum.Red
                            )
                        ],
                    ApplicationRefuse: false), 
                CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is MediaInCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is MediaInsertedEvent mediaInsertedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaInsertedEv.Serialise());
                }
                else if (cmdResponse is NoMediaEvent noMediaEv)
                {
                    base.OnXFS4IoTMessages(this, noMediaEv.Serialise());
                }
                else if (cmdResponse is MediaRefusedEvent mediaRefusedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaRefusedEv.Serialise());
                }
                else if (cmdResponse is MediaDetectedEvent mediaDetectedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaDetectedEv.Serialise());
                }
                else if (cmdResponse is MediaDataEvent mediaDataEv)
                {
                    base.OnXFS4IoTMessages(this, mediaDataEv.Serialise());
                }
                else if (cmdResponse is MediaRejectedEvent mediaRejectedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaRejectedEv.Serialise());
                }
                else if (cmdResponse is StorageErrorEvent storageErrorEv)
                {
                    base.OnXFS4IoTMessages(this, storageErrorEv.Serialise());
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is ShutterStatusChangedEvent shutterEv)
                {
                    base.OnXFS4IoTMessages(this, shutterEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task MediaInEnd()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new MediaInEndCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is MediaInEndCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is MediaDataEvent mediaDataEv)
                {
                    base.OnXFS4IoTMessages(this, mediaDataEv.Serialise());
                }
                else if (cmdResponse is MediaPresentedEvent mediaPresentedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaPresentedEv.Serialise());
                }
                else if (cmdResponse is StorageErrorEvent storageErrorEv)
                {
                    base.OnXFS4IoTMessages(this, storageErrorEv.Serialise());
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is ShutterStatusChangedEvent shutterEv)
                {
                    base.OnXFS4IoTMessages(this, shutterEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task MediaInRollback()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new MediaInRollbackCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is MediaInRollbackCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                        break;
                }
                else if (cmdResponse is MediaPresentedEvent mediaPresentedEv)
                {
                    base.OnXFS4IoTMessages(this, mediaPresentedEv.Serialise());
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is ShutterStatusChangedEvent shutterEv)
                {
                    base.OnXFS4IoTMessages(this, shutterEv.Serialise());
                    if (shutterEv.Payload.Shutter == ShutterStateEnum.Closed)
                        break;
                }
                else if (cmdResponse is MediaTakenEvent mediaTakenEv)
                {
                    base.OnXFS4IoTMessages(this, mediaTakenEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task Retract()
        {
            var client = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await client.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new RetractMediaCommand(
                RequestId.NewID(), 
                Payload: new(RetractLocation: "unitRetract"), 
                CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is RetractMediaCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is StorageChangedEvent storageChangedEv)
                {
                    base.OnXFS4IoTMessages(this, storageChangedEv.Serialise());
                }
                else if (cmdResponse is StorageThresholdEvent storageThresholdEv)
                {
                    base.OnXFS4IoTMessages(this, storageThresholdEv.Serialise());
                }
                else if (cmdResponse is StorageErrorEvent storageErrorEv)
                {
                    base.OnXFS4IoTMessages(this, storageErrorEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task ShowTransactionStatus()
        {
            await GetTransactionStatus();

            if (GetTransactionStatusPayload is null)
            {
                return;
            }

            if (CheckScannerTransactionStatus.IsDisposed)
            {
                CheckScannerTransactionStatus = new();
            }

            CheckScannerTransactionStatus.PrepareDisplay(GetTransactionStatusPayload);
            CheckScannerTransactionStatus.Show();
            CheckScannerTransactionStatus.BringToFront();
        }
        private CheckScannerTxnStatus CheckScannerTransactionStatus = new();
    }
}
