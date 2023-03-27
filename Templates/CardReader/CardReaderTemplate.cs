using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.CardReader;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Storage;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.CardReader.Events;
using XFS4IoT.CardReader;
using XFS4IoT.CardReader.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace CardReader.CardReaderTemplate
{

    public class CardReaderTemplate : ICardReaderDevice, ICommonDevice, IStorageDevice
    {
        
        public CardReaderTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CardReaderTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.NotSupported,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            CardReaderStatus = new CardReaderStatusClass(CardReaderStatusClass.MediaEnum.NotPresent,
                                                         CardReaderStatusClass.SecurityEnum.NotSupported,
                                                         CardReaderStatusClass.ChipPowerEnum.NoCard,
                                                         CardReaderStatusClass.ChipModuleEnum.Ok,
                                                         CardReaderStatusClass.MagWriteModuleEnum.Ok,
                                                         CardReaderStatusClass.FrontImageModuleEnum.NotSupported,
                                                         CardReaderStatusClass.BackImageModuleEnum.NotSupported);
        }

        #region CardReader Interface

        /// <summary>
        /// For motor driven card readers, the card unit checks whether a card has been inserted. 
        /// All specified tracks are read immediately if the device can read with the low level accept command and store read data in the device specific class and set data on the ReadCardData method call.
        /// If reading the chip is requested, the chip will be contacted and reset and the ATR (AnswerTo Reset) data will be read. 
        /// When this command completes the chip will be in contacted position. This command can also be used for an explicit cold reset of a previously contacted chip.
        /// This command should only be used for user cards and should not be used for permanently connected chips.
        /// If no card has been inserted, and for all other categories of card readers, the card unit waits for the period of time specified in the call for a card to be either inserted or pulled through.
        /// The InsertCardEvent will be generated when there is no card in the cardreader and the device is ready to accept a card.
        /// </summary>
        public async Task<AcceptCardResult> AcceptCardAsync(CommonCardCommandEvents events,
                                                            AcceptCardRequest acceptCardInfo,
                                                            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read alltracks specified.
        /// All specified tracks are read immediately or 
        /// A security check via a security module(i.e. MM, CIM86) can be requested. If the security check fails however this should not stop valid data beingreturned.
        /// The response securityFail will be returned if the command specifies only security data to be read andthe security check could not be executed, in all other cases ok will be returned with the data field of theoutput parameter set to the relevant value including *hardwareError*.
        /// For non-motorized Card Readers which read track data on card exit, the invalidData error code is returned whena call to is made to read both track data and chip data.
        /// If the card unit is a latched dip unit then the device will latch the card when the chip card will be read, 
        /// The card will remain latched until a call to EjectCard is made.
        /// For contactless chip card readers a collision of two or more card signals may happen. 
        /// In this case, if the deviceis not able to pick the strongest signal, errorCardCollision will be returned.
        /// </summary>
        public async Task<ReadCardResult> ReadCardAsync(ReadCardCommandEvents events,
                                                        ReadCardRequest dataToRead,
                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The device is ready to accept a card.
        /// The application must pass the magnetic stripe data in ASCII without any sentinels. 
        /// If the data passed in is too long. The invalidError error code will be returned.
        /// This procedure is followed by data verification.
        /// If power fails during a write the outcome of the operation will be vendor specific, there is no guarantee that thewrite will have succeeded.
        /// </summary>
        public async Task<WriteCardResult> WriteCardAsync(CommonCardCommandEvents events,
                                                          WriteCardRequest dataToWrite,
                                                          CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to communicate with the chip.
        /// Transparent data is sent from the application to the chip andthe response of the chip is returned transparently to the application.
        /// The identification information e.g. ATR of the chip must be obtained before issuing this command. 
        /// The identification information for a user card or the Memory Card Identification (when available) must initially be obtained using CardReader.ReadRawData.
        /// The identification information for subsequentresets of a user card can be obtained using either CardReader.ReadRawDat or CardReader.ChipPower. 
        /// The ATR for permanent connected chips is always obtained through CardReader.ChipPower.
        /// For contactless chip card readers, applications need to specify which chip to contact with, as part of chipData, if more than one chip has been detected and multiple identification data has been returned by the CardReader.ReadRawData command.
        /// For contactless chip card readers a collision of two or more card signals may happen. 
        /// In this case, if the deviceis not able to pick the strongest signal, the cardCollision error code will be returned.
        /// </summary>
        public async Task<ChipIOResult> ChipIOAsync(ChipIORequest dataToSend,
                                                    CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used by the application to perform a hardware reset which will attempt to return the card readerdevice to a known good state.
        /// This command does not over-ride a lock obtained by another application or service handle.
        /// If the device is a user ID card unit, the device will attempt to either retain, eject or will perform no action onany user cards found in the device as specified in the input parameter. 
        /// It may not always be possible to retain oreject the items as specified because of hardware problems. 
        /// If a user card is found inside the device the CardReader.MediaInsertedEvent will inform the application where card wasactually moved to.
        /// If no action is specified the user card will not be moved even if this means that the devicecannot be recovered.
        /// If the device is a permanent chip card unit, this command will power-off the chip.For devices with parking station capability there will be one MediaInsertedEvent for each card found.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(ResetCommandEvents events,
                                                              ResetDeviceRequest cardAction,
                                                              CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command handles the power actions that can be done on the chip.For user chips, this command is only used after the chip has been contacted for the first time using the[CardReader.ReadRawData](#cardreader.readrawdata) command. For contactless user chips, this command may be used todeactivate the contactless card communication.For permanently connected chip cards, this command is the only way to control the chip power.
        /// </summary>
        public async Task<ChipPowerResult> ChipPowerAsync(ChipPowerRequest action,
                                                          CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to configure an intelligent contactless card reader before performing a contactlesstransaction.
        /// This command sets terminal related data elements, the list of terminal acceptable applications with associated application specific data and any encryption key data required for offline data authentication.
        /// This command should be used prior to CardReader.EMVClessPerformTransaction command. 
        /// It may be calledonce on application start up or when any of the configuration parameters require to be changed. 
        /// The configurationset by this command is persistent.This command should be called with a complete list of acceptable payment system applications as any previous configurations will be replaced.
        /// </summary>
        public async Task<EMVContactlessConfigureResult> EMVContactlessConfigureAsync(EMVContactlessConfigureRequest terminalConfig, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to enable an intelligent contactless card reader.
        /// The transaction will start as soon as thecard tap is detected.
        /// Based on the configuration of the contactless chip card and the reader device, this command could return dataformatted either as magnetic stripe information or as a set of BER-TLV encoded EMV tags.
        /// This command supports magnetic stripe emulation cards and EMV-like contactless cards but cannot be used on storagecontactless cards. 
        /// The latter must be managed using the CardReader.ReadRawData and CardReader.ChipIO commands.
        /// For specific payment system's card profiles an intelligent card reader could return a set of EMV tags along withmagnetic stripe formatted data. 
        /// In this case, two contactless card data structures will be returned, onecontaining the magnetic stripe like data and one containing BER-TLV encoded tags.
        /// If no card has been tapped, the contactless chip card reader waits for the period of time specified in the commandcall for a card to be tapped.
        /// For intelligent contactless card readers, any in-built audio/visual feedback such as Beep/LEDs, need to becontrolled directly by the reader. 
        /// These indications should be implemented based on the EMVCo and payment system'sspecifications.
        /// </summary>
        public async Task<EMVContactlessPerformTransactionResult> EMVContactlessPerformTransactionAsync(EMVClessCommandEvents events,
                                                                                                        EMVContactlessPerformTransactionRequest transactionData,
                                                                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command performs the post authorization processing on payment systems contactless cards.
        /// Before an online authorized transaction is considered complete, further chip processing may be requested by theissuer. 
        /// This is only required when the authorization response includes issuer update data either issuer scriptsor issuer authentication data.
        /// The command enables the contactless card reader and waits for the customer to re-tap their card.
        /// The contactless chip card reader waits for the period of time specified in the command all for a card to be tapped.
        /// </summary>
        public async Task<EMVContactlessIssuerUpdateResult> EMVContactlessIssuerUpdateAsync(EMVClessCommandEvents events,
                                                                                            EMVContactlessIssuerUpdateRequest transactionData,
                                                                                            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used for setting the DES key that is necessary for operating a CIM86 module.
        /// The command must beexecuted before the first read command is issued to the card reader.
        /// </summary>
        public async Task<SetCIM86KeyResult> SetCIM86KeyAsync(SetCIM86KeyRequest keyInfo,
                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling MediaRemovedEvent after card is ejected successfully.
        /// </summary>
        /// <returns></returns>
        public Task RunAsync(CancellationToken Token)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// This command is used to retrieve the complete list of registration authority Interface Module (IFM) identifiers.
        /// The primary registration authority is EMVCo but other organizations are also supported for historical or localcountry requirements.
        /// New registration authorities may be added in the future so applications should be able to handle the return of new(as yet undefined) IFM identifiers.
        /// </summary>
        public QueryIFMIdentifierResult QueryIFMIdentifier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to retrieve the supported payment system applications available within an intelligentcontactless card unit. 
        /// The payment system application can either be identified by an AID or by the AID incombination with a Kernel Identifier. 
        /// The Kernel Identifier has been introduced by the EMVCo specifications; seeReference [3].
        /// </summary>
        public QueryEMVApplicationResult EMVContactlessQueryApplications()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  This command is only applicable to motorized and latched dip card readers.
        ///  If after a successful completion event the card is at the exit position, the card will be accessible to the user.
        /// A CardReader.MediaRemovedEvent is generated to inform the application when the card is taken.
        /// 
        /// * Motorized card readers
        /// Motorized card readers can physically move cards from or to the transport or exit positions or a storage.
        /// The default operation is to move a card in the transport position to the exit position.
        /// If the card is being moved from the exit position to the exit position, these are valid behaviors:
        /// The card does not move as the card reader can detect the card is already in the correct position.
        /// The card is moved back into the card reader then moved back to the exit to ensure the card is in the correct position.
        /// 
        /// * Latched dip card readers
        /// Latched dips card readers can logically move cards from the transport position to the exit position by
        /// unlatching the card reader.That is, the card will not physically move but will be accessible to the user.
        /// </summary>
        public async Task<MoveCardResult> MoveCardAsync(MoveCardRequest moveCardInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Storage Interface
        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns></returns>
        public bool GetCardStorageConfiguration(out Dictionary<string, CardUnitStorageConfiguration> newCardUnits)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is call after card is moved to the storage. Move or Reset command.
        /// </summary>
        /// <returns>Return true if the device maintains hardware counters for the card units</returns>
        public bool GetCardUnitCounts(out Dictionary<string, CardUnitCount> unitCounts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update card unit hardware status by device class. the maintaining status by the framework will be overwritten.
        /// The framework can't handle threshold event if the device class maintains hardware storage status on threshold value is not zero.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card unit status</returns>
        public bool GetCardUnitStatus(out Dictionary<string, CardStatusClass.ReplenishmentStatusEnum> unitStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update card unit hardware storage status by device class.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card storage status</returns>
        public bool GetCardStorageStatus(out Dictionary<string, CardUnitStorage.StatusEnum> storageStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public async Task<SetCardStorageResult> SetCardStorageAsync(SetCardStorageRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCashStorageConfiguration(out Dictionary<string, CashUnitStorageConfiguration> newCardUnits) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Return return cash unit counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitCounts(out Dictionary<string, CashUnitCountClass> unitCounts) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Return return cash storage status
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashStorageStatus(out Dictionary<string, CashUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Return return cash unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashUnitStatus(out Dictionary<string, CashStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Return accuracy of counts. This method is called if the device class supports feature for count accuray
        /// </summary>
        public void GetCashUnitAccuray(string storageId, out CashStatusClass.AccuracyEnum unitAccuracy) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Return return cash unit initial counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitInitialCounts(out Dictionary<string, StorageCashCountClass> initialCounts) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"No cash related operation supported in this device.");

        /// <summary>
        /// Initiate exchange operation
        /// </summary>
        public Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation) => throw new NotSupportedException($"No exchange operation supported in this device.");

        /// <summary>
        /// End exchange operation
        /// </summary>
        public Task<EndExchangeResult> EndExchangeAsync(CancellationToken cancellation) => throw new NotSupportedException($"No exchange operation supported in this device.");

        /// <summary>
        /// CardReader Status
        /// </summary>
        public CardReaderStatusClass CardReaderStatus { get; set; }

        /// <summary>
        /// CardReader Capabilities
        /// </summary>
        public CardReaderCapabilitiesClass CardReaderCapabilities { get; set; } = new(CardReaderCapabilitiesClass.DeviceTypeEnum.Motor,
                                                                                      CardReaderCapabilitiesClass.ReadableDataTypesEnum.Track1 | CardReaderCapabilitiesClass.ReadableDataTypesEnum.Track2 | CardReaderCapabilitiesClass.ReadableDataTypesEnum.Track3,
                                                                                      CardReaderCapabilitiesClass.WritableDataTypesEnum.Track1 | CardReaderCapabilitiesClass.WritableDataTypesEnum.Track2 | CardReaderCapabilitiesClass.WritableDataTypesEnum.Track3,
                                                                                      CardReaderCapabilitiesClass.ChipProtocolsEnum.T0 | CardReaderCapabilitiesClass.ChipProtocolsEnum.T1,
                                                                                      CardReaderCapabilitiesClass.SecurityTypeEnum.NotSupported,
                                                                                      CardReaderCapabilitiesClass.PowerOptionEnum.Transport,
                                                                                      CardReaderCapabilitiesClass.PowerOptionEnum.Transport,
                                                                                      FluxSensorProgrammable: false,
                                                                                      ReadWriteAccessFollowingExit: false,
                                                                                      CardReaderCapabilitiesClass.WriteMethodsEnum.Loco,
                                                                                      CardReaderCapabilitiesClass.ChipPowerOptionsEnum.Cold | CardReaderCapabilitiesClass.ChipPowerOptionsEnum.Warm,
                                                                                      CardReaderCapabilitiesClass.MemoryChipProtocolsEnum.NotSupported,
                                                                                      CardReaderCapabilitiesClass.PositionsEnum.Exit | CardReaderCapabilitiesClass.PositionsEnum.Transport,
                                                                                      true);

        #endregion

        #region Common Interface
        /// <summary>
        /// Stores Commons status
        /// </summary>
        public CommonStatusClass CommonStatus { get; set; }

        /// <summary>
        /// Stores Common Capabilities
        /// </summary>
        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new CommonCapabilitiesClass(
                CommonInterface: new CommonCapabilitiesClass.CommonInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    }
                ),
                CardReaderInterface: new CommonCapabilitiesClass.CardReaderInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.ReadRawData,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.WriteRawData,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.ChipIO,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.ChipPower,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.EMVClessConfigure,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.EMVClessIssuerUpdate,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.EMVClessPerformTransaction,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.EMVClessQueryApplications,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.QueryIFMIdentifier,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.SetKey,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.CommandEnum.Move,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.InsertCardEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.MediaDetectedEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.MediaInsertedEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.MediaRemovedEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.InvalidMediaEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.EMVClessReadStatusEvent,
                        CommonCapabilitiesClass.CardReaderInterfaceClass.EventEnum.CardActionEvent,
                    }
                ),
                StorageInterface: new CommonCapabilitiesClass.StorageInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.GetStorage,
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.SetStorage,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageThresholdEvent,
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageChangedEvent,
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageErrorEvent,
                    }
                ),
                DeviceInformation: new List<CommonCapabilitiesClass.DeviceInformationClass>()
                {
                    new CommonCapabilitiesClass.DeviceInformationClass(
                            ModelName: "CardReaderTemplate",
                            SerialNumber: "123456-78900001",
                            RevisionNumber: "1.0",
                            ModelDescription: "CardReaderTemplate device",
                            Firmware: new List<CommonCapabilitiesClass.FirmwareClass>()
                            {
                                new CommonCapabilitiesClass.FirmwareClass(
                                        FirmwareName: "XFS4 SP",
                                        FirmwareVersion: "1.0",
                                        HardwareRevision: "1.0")
                            },
                            Software: new List<CommonCapabilitiesClass.SoftwareClass>()
                            {
                                new CommonCapabilitiesClass.SoftwareClass(
                                        SoftwareName: "XFS4 SP",
                                        SoftwareVersion: "1.0")
                            })
                },
                PowerSaveControl: false,
                AntiFraudModule: false);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();

        #endregion 

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        /// Internal variables
        /// 
        private sealed class CardUnitInfo
        {
            public CardUnitInfo()
            {
                CurrentCount = 0;
                InitialCount = 0;
                StorageStatus = CardUnitStorage.StatusEnum.Good;
                UnitStatus = CardStatusClass.ReplenishmentStatusEnum.Healthy;
            }

            /// <summary>
            /// Initial count of this unit
            /// </summary>
            public int InitialCount { get; set; }

            /// <summary>
            /// Current count of this unit
            /// </summary>
            public int CurrentCount { get; set; }

            /// <summary>
            /// Current storage status
            /// </summary>
            public CardUnitStorage.StatusEnum StorageStatus { get; set; }

            /// <summary>
            /// Current status of this unit
            /// </summary>
            public CardStatusClass.ReplenishmentStatusEnum UnitStatus { get; set; }

            public CardUnitStorageConfiguration CardBin = new("BIN1",
                                                              50,
                                                              "SN104827639",
                                                              new CardCapabilitiesClass(CardCapabilitiesClass.TypeEnum.Retain,
                                                                                        false),
                                                              new CardConfigurationClass(40));
        }

        private CardUnitInfo cardUnitInfo = new ();

        private ILogger Logger { get; }
    }
}