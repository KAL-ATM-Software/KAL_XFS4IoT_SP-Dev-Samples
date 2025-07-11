﻿/***********************************************************************************************\
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
using XFS4IoT.CashDispenser;
using XFS4IoT.CashDispenser.Commands;
using XFS4IoT.CashDispenser.Completions;
using XFS4IoT.CashDispenser.Events;
using XFS4IoT.Storage.Commands;
using XFS4IoT.Storage.Completions;
using XFS4IoT.Storage.Events;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Events;
using XFS4IoT.CashAcceptor.Completions;

namespace TestClientForms.Devices
{
    public class CashDispenserDevice : CommonDevice
    {
        public CashDispenserDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox/*, TextBox getPresentStatusNonce*/) 
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
//            GetPresentStatusNonce = getPresentStatusNonce;
        }
//        private TextBox GetPresentStatusNonce;

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.CashDispenser, InterfaceClass.NameEnum.CashManagement, InterfaceClass.NameEnum.Storage, InterfaceClass.NameEnum.Common]);

        public async Task GetCashUnitInfo()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetStorageCommand(RequestId.NewID(), CommandTimeout);
            await dispenser.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await dispenser.ReceiveMessageAsync())
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

        public async Task GetMixTypes()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new GetMixTypesCommand(RequestId.NewID(), CommandTimeout);
            await dispenser.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await dispenser.ReceiveMessageAsync())
                {
                    case GetMixTypesCompletion response:
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

        public async Task GetPresentStatus( string Nonce )
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var nonce = string.IsNullOrWhiteSpace(Nonce)? null : Nonce;

            var cmd = new GetPresentStatusCommand(RequestId.NewID(), new(OutputPositionEnum.OutDefault, Nonce: nonce), CommandTimeout);
            await dispenser.SendCommandAsync(cmd);
            base.OnXFS4IoTMessages(this, cmd.Serialise());

            while (true)
            {
                switch (await dispenser.ReceiveMessageAsync())
                {
                    case XFS4IoT.CashDispenser.Completions.GetPresentStatusCompletion response:
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

        public async Task Denominate()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var denominateCmd = new DenominateCommand(RequestId.NewID(), new(
                new
                (
                    Denomination:
                    new(App: null, 
                        Service: 
                        new(Currencies: new Dictionary<string, double>() { { "EUR", 50 } },
                            Partial: null,
                            Mix: "mix1",
                            CashBox: null)
                        ),
                    TellerID: null
                )), CommandTimeout);

            base.OnXFS4IoTMessages(this,  denominateCmd.Serialise());

            await dispenser.SendCommandAsync(denominateCmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is DenominateCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    break;
                }
                else if (cmdResponse is Acknowledge)
                {
                }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }
        public async Task Dispense( string token )
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var dispenseCommand = new DispenseCommand(RequestId.NewID(),
                                                      new(
                                                          Denomination: new(Denomination: new(App: null,
                                                               Service:
                                                                 new(Currencies: new Dictionary<string, double>() { { "EUR", 50 } },
                                                                     Partial: null,
                                                                     Mix: "mix1",
                                                                     CashBox: null)
                                                            )
                                                         ),
                                                         Position: OutputPositionEnum.OutDefault,
                                                         Token: token), 
                                                      CommandTimeout)
                                                      {

            };
            base.OnXFS4IoTMessages(this,  dispenseCommand.Serialise());

            
            

            await dispenser.SendCommandAsync(dispenseCommand);

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is DispenseCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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

        private static string MakeToken(string nonce, bool valid)
        {
            // 'valid' or invalid HMAC. 
            var HMAC = valid ? "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2"
                             : "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F3";

            var tokenBuilder = new StringBuilder($"NONCE={nonce},TOKENFORMAT=1,TOKENLENGTH=$$$$,DISPENSE1=100.00EUR,ANOTHERKEY=12345,HMACSHA256={HMAC}");

            // The token length field is fix at four digits to make it easy to calculate. 
            // Inject this into the string. 
            var len = $"{tokenBuilder.Length:X4}";
            tokenBuilder = tokenBuilder.Replace("$$$$", len);

            string token = tokenBuilder.ToString();
            return token;
        }

        internal async Task ClearCommandNonce()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            XFS4IoT.Common.Commands.ClearCommandNonceCommand clearNonceCommand = new(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this,  clearNonceCommand.Serialise());

            await dispenser.SendCommandAsync(clearNonceCommand);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is XFS4IoT.Common.Completions.ClearCommandNonceCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());

                    if (response.Header.CompletionCode == MessageHeader.CompletionCodeEnum.Success)
                        break;
                }
                else if (cmdResponse is Acknowledge)
                {
                }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        internal async Task<string> GetCommandNonce()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return "";
            }

            XFS4IoT.Common.Commands.GetCommandNonceCommand getNonceCommand = new(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this,  getNonceCommand.Serialise());

            await dispenser.SendCommandAsync(getNonceCommand);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is XFS4IoT.Common.Completions.GetCommandNonceCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());

                    if (response.Header.CompletionCode == MessageHeader.CompletionCodeEnum.Success)
                        return MakeToken(response.Payload?.CommandNonce, true);
                }
                else if (cmdResponse is Acknowledge)
                { }
                else
                {
                    base.OnXFS4IoTMessages(this, "<Unknown Event>");
                }
            }
        }

        public async Task StartExchange()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var startExchangeCmd = new StartExchangeCommand(RequestId.NewID(), 
                                        CommandTimeout);

            base.OnXFS4IoTMessages(this,  startExchangeCmd.Serialise());

            await dispenser.SendCommandAsync(startExchangeCmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is StartExchangeCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var endExchangeCmd = new EndExchangeCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this,  endExchangeCmd.Serialise());

            await dispenser.SendCommandAsync(endExchangeCmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is EndExchangeCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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

        public async Task Present()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var presentCmd = new PresentCommand(RequestId.NewID(), new(OutputPositionEnum.OutDefault), CommandTimeout);

            base.OnXFS4IoTMessages(this,  presentCmd.Serialise());

            await dispenser.SendCommandAsync(presentCmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is PresentCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());

                    if (response.Header.CompletionCode != MessageHeader.CompletionCodeEnum.Success ||
                        response.Payload.ErrorCode == PresentCompletion.PayloadData.ErrorCodeEnum.NoItems)
                        break;
                }
                else if (cmdResponse is ItemsTakenEvent itemTakenEv)
                {
                    base.OnXFS4IoTMessages(this, itemTakenEv.Serialise());
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
        public async Task Reset()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var resetCmd = new ResetCommand(RequestId.NewID(), new(new(ItemTargetEnumEnum.OutDefault)), CommandTimeout);

            base.OnXFS4IoTMessages(this,  resetCmd.Serialise());

            await dispenser.SendCommandAsync(resetCmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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

        public async Task OpenShutter()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new OpenShutterCommand(RequestId.NewID(), new(PositionEnum.OutDefault), CommandTimeout);

            base.OnXFS4IoTMessages(this,  cmd.Serialise());

            await dispenser.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is OpenShutterCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    break;
                }
                if (cmdResponse is ShutterStatusChangedEvent shutterEv)
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

        public async Task CloseShutter()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new CloseShutterCommand(RequestId.NewID(), new(PositionEnum.OutDefault), CommandTimeout);

            base.OnXFS4IoTMessages(this,  cmd.Serialise());

            await dispenser.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is CloseShutterCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    break;
                }
                if (cmdResponse is ShutterStatusChangedEvent shutterEv)
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

        public async Task Reject()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new RejectCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this,  cmd.Serialise());

            await dispenser.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is RejectCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var cmd = new RetractCommand(RequestId.NewID(), new(Location: new(OutputPosition: null, 
                                                                              RetractArea: RetractAreaEnum.Retract, 
                                                                              Index: 1)), CommandTimeout);

            base.OnXFS4IoTMessages(this,  cmd.Serialise());

            await dispenser.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is RetractCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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

        public async Task SetCashUnitInfo()
        {
            var dispenser = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await dispenser.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            StorageCashCountsClass unit3 = new (0);
            Dictionary<string, StorageCashCountClass> unit3Counts = new() { { "typeEUR5", new StorageCashCountClass(Fit: 1000) } };
            unit3.ExtendedProperties = unit3Counts;
            StorageCashCountsClass unit4 = new(0);
            Dictionary<string, StorageCashCountClass> unit4Counts = new() { { "typeEUR10", new StorageCashCountClass(Fit: 1000) } };
            unit4.ExtendedProperties = unit4Counts;
            StorageCashCountsClass unit5 = new(0);
            Dictionary<string, StorageCashCountClass> unit5Counts = new() { { "typeEUR20", new StorageCashCountClass(Fit: 1000) } };
            unit5.ExtendedProperties = unit5Counts;

            Dictionary<string, XFS4IoT.Storage.SetStorageUnitClass> storage = new()
            {
                { "unit3", new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null, 
                                            new StorageSetCashStatusClass(unit3)),
                    null) },
                { "unit4", new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null,
                                            new StorageSetCashStatusClass(unit4)),
                    null) },
                { "unit5", new XFS4IoT.Storage.SetStorageUnitClass(
                    new StorageSetCashClass(null,
                                            new StorageSetCashStatusClass(unit5)),
                    null) },
            };
            var cmd = new SetStorageCommand(RequestId.NewID(), new(storage), CommandTimeout);

            base.OnXFS4IoTMessages(this,  cmd.Serialise());

            await dispenser.SendCommandAsync(cmd);

            
            

            for (; ; )
            {
                object cmdResponse = await dispenser.ReceiveMessageAsync();
                if (cmdResponse is SetStorageCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
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
