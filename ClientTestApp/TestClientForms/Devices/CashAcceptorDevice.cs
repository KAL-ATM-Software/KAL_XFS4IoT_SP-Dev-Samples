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
using XFS4IoT.CashManagement;
using XFS4IoT.CashManagement.Commands;
using XFS4IoT.CashManagement.Completions;
using XFS4IoT.CashManagement.Events;
using XFS4IoT.CashAcceptor;
using XFS4IoT.CashAcceptor.Commands;
using XFS4IoT.CashAcceptor.Completions;
using XFS4IoT.CashAcceptor.Events;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;
using XFS4IoT.Storage.Events;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;
using XFS4IoT.BanknoteNeutralization.Completions;
using XFS4IoTServer;

namespace TestClientForms.Devices
{
    public class CashAcceptorDevice : CommonDevice
    {
        public CashAcceptorDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox) 
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }
		
        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.CashAcceptor, InterfaceClass.NameEnum.CashManagement, InterfaceClass.NameEnum.Storage, InterfaceClass.NameEnum.Common]);

        public async Task GetCashUnitInfo()
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
            await client.SendCommandAsync(cmd);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await client.ReceiveMessageAsync())
                {
                    case GetStorageCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

        public async Task SetCashUnitInfo()
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

            StorageCashCountsClass unit1 = new(0);
            Dictionary<string, StorageCashCountClass> unit1Counts = new()
            { 
                { "typeEUR5", new StorageCashCountClass() },
                { "typeEUR10", new StorageCashCountClass() },
                { "typeEUR20", new StorageCashCountClass() },
                { "typeEUR50", new StorageCashCountClass() },
                { "typeEUR100", new StorageCashCountClass() },
                { "typeEUR200", new StorageCashCountClass() },
                { "typeEUR500", new StorageCashCountClass() },
            };
            unit1.ExtendedProperties = unit1Counts;
            StorageCashCountsClass unit2 = new(0);
            Dictionary<string, StorageCashCountClass> unit2Counts = new() { { "typeEUR5", new StorageCashCountClass() } };
            unit2.ExtendedProperties = unit2Counts;
            StorageCashCountsClass unit3 = new(0);
            Dictionary<string, StorageCashCountClass> unit3Counts = new() 
            {
                { "typeEUR5", new StorageCashCountClass() },
                { "typeEUR10", new StorageCashCountClass() },
                { "typeEUR20", new StorageCashCountClass() },
                { "typeEUR50", new StorageCashCountClass() },
                { "typeEUR100", new StorageCashCountClass() },
                { "typeEUR200", new StorageCashCountClass() },
                { "typeEUR500", new StorageCashCountClass() },
            };
            unit3.ExtendedProperties = unit3Counts;

            Dictionary<string, XFS4IoT.Storage.SetStorageUnitClass> storage = new()
            {
                {
                    "unit1",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null,
                                            new StorageSetCashStatusClass(unit1)),
                    null)
                },
                {
                    "unit2",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null,
                                            new StorageSetCashStatusClass(unit2)),
                    null)
                },
                {
                    "unit3",
                    new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null,
                                            new StorageSetCashStatusClass(unit3)),
                    null)
                },
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
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
                }
                else if (cmdResponse is IncompleteRetractEvent incompleteRetractEv)
                {
                    base.OnXFS4IoTMessages(this, incompleteRetractEv.Serialise());
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

        public async Task GetCashInStatus()
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

            var cmd = new GetCashInStatusCommand(RequestId.NewID(), CommandTimeout);
            await client.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await client.ReceiveMessageAsync())
                {
                    case GetCashInStatusCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }
        public async Task ConfigureBanknoteTypes()
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

            var cmd = new ConfigureNoteTypesCommand(RequestId.NewID(),
                                                    new(
                                                    new List<ConfigureNoteTypesCommand.PayloadData.ItemsClass>() 
                                                    {
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR5", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR10", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR20", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR50", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR100", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR200", true),
                                                        new ConfigureNoteTypesCommand.PayloadData.ItemsClass("typeEUR500", true),
                                                    }), CommandTimeout);

            await client.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await client.ReceiveMessageAsync())
                {
                    case ConfigureNoteTypesCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
                }
            }
        }

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
                else if (cmdResponse is NoteErrorEvent noteErrorEv)
                {
                    base.OnXFS4IoTMessages(this, noteErrorEv.Serialise());
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
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
                else if (cmdResponse is NoteErrorEvent noteErrorEv)
                {
                    base.OnXFS4IoTMessages(this, noteErrorEv.Serialise());
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task CashInStart()
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

            var cmd = new CashInStartCommand(
                RequestId.NewID(), 
                new(
                    UseRecycleUnits: false,
                    OutputPosition: OutputPositionEnum.OutDefault, 
                    InputPosition: InputPositionEnum.InDefault, 
                    TotalItemsLimit: 200),
                    CommandTimeout);

            await client.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await client.ReceiveMessageAsync())
                {
                    case CashInStartCompletion response:
                        base.OnXFS4IoTMessages(this, response.Serialise());
                        return;
                    case StatusChangedEvent statusChangedEvent:
                        base.OnXFS4IoTMessages(this, statusChangedEvent.Serialise());
                        break;
                    case StorageChangedEvent storageChangedEvent:
                        base.OnXFS4IoTMessages(this, storageChangedEvent.Serialise());
                        break;
                    default:
                        base.OnXFS4IoTMessages(this, "<Unknown Event>");
                        break;
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

            var cmd = new ResetCommand(RequestId.NewID(), new(Position: new(Target: ItemTargetEnumEnum.OutDefault, 
                                                                            Unit: null, 
                                                                            Index: null)), CommandTimeout);

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
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
                }
                else if (cmdResponse is IncompleteRetractEvent incompleteRetractEv)
                {
                    base.OnXFS4IoTMessages(this, incompleteRetractEv.Serialise());
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
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task CashIn()
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

            var cmd = new CashInCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is CashInCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    break;
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
                }
                else if (cmdResponse is ItemsInsertedEvent itemsInsertedEv)
                {
                    base.OnXFS4IoTMessages(this, itemsInsertedEv.Serialise());
                }
                else if (cmdResponse is InsertItemsEvent insertItemEv)
                {
                    base.OnXFS4IoTMessages(this, insertItemEv.Serialise());
                }
                else if (cmdResponse is InputRefuseEvent inputRefusedEv)
                {
                    base.OnXFS4IoTMessages(this, inputRefusedEv.Serialise());
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
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task CashInEnd()
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

            var cmd = new CashInEndCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is CashInEndCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
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
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task CashInRollback()
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

            var cmd = new CashInRollbackCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is CashInRollbackCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success)
                        break;
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
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
                    if (shutterEv.Payload.Shutter == ShutterEnum.Closed)
                        break;
                }
                else if (cmdResponse is ItemsTakenEvent itemsTakenEv)
                {
                    base.OnXFS4IoTMessages(this, itemsTakenEv.Serialise());
                }
                else if (cmdResponse is StatusChangedEvent statusChangedEv)
                {
                    base.OnXFS4IoTMessages(this, statusChangedEv.Serialise());
                }
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
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

            var cmd = new RetractCommand(RequestId.NewID(), new(Location: new(OutputPosition: null, 
                                                                              RetractArea: RetractAreaEnum.Retract, 
                                                                              Index: 1)), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await client.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await client.ReceiveMessageAsync();
                if (cmdResponse is RetractCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    break;
                }
                else if (cmdResponse is InfoAvailableEvent infoAvailableEv)
                {
                    base.OnXFS4IoTMessages(this, infoAvailableEv.Serialise());
                }
                else if (cmdResponse is IncompleteRetractEvent incompleteRetractEv)
                {
                    base.OnXFS4IoTMessages(this, incompleteRetractEv.Serialise());
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
                else if (cmdResponse is CountsChangedEvent countChangedEv)
                {
                    base.OnXFS4IoTMessages(this, countChangedEv.Serialise());
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }
    }
}
