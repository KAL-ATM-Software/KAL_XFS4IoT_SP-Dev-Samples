﻿
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.IO;
using XFS4IoT;
using XFS4IoTFramework.Check;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Storage;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.Check;
using XFS4IoT.Check.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace CheckScanner.CheckScannerTemplate
{
    public class CheckScannerTemplate : ICheckDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        public Task RunAsync(CancellationToken cancel)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Constructor of the example class for the scanner
        /// </summary>
        /// <param name="Logger"></param>
        public CheckScannerTemplate(XFS4IoT.ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CheckScannerTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(
                Device: CommonStatusClass.DeviceEnum.Online,
                DevicePosition: CommonStatusClass.PositionStatusEnum.InPosition,
                PowerSaveRecoveryTime: 0,
                AntiFraudModule: CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                Exchange: CommonStatusClass.ExchangeEnum.Inactive,
                EndToEndSecurity: CommonStatusClass.EndToEndSecurityEnum.NotEnforced);

            CheckScannerStatus = new CheckScannerStatusClass(
                Acceptor: CheckScannerStatusClass.AcceptorEnum.Ok,
                Media: CheckScannerStatusClass.MediaEnum.NotPresent,
                Toner: CheckScannerStatusClass.TonerEnum.Full,
                Ink: CheckScannerStatusClass.InkEnum.Full,
                FrontImageScanner: CheckScannerStatusClass.ImageScannerEnum.Ok,
                BackImageScanner: CheckScannerStatusClass.ImageScannerEnum.Ok,
                MICRReader: CheckScannerStatusClass.ImageScannerEnum.Ok,
                Stacker: CheckScannerStatusClass.StackerEnum.Empty,
                ReBuncher: CheckScannerStatusClass.ReBuncherEnum.NotSupported,
                MediaFeeder: CheckScannerStatusClass.MediaFeederEnum.Empty,
                Positions: new()
                {
                    { CheckScannerCapabilitiesClass.PositionEnum.Input, positionStatus },
                    { CheckScannerCapabilitiesClass.PositionEnum.Output, positionStatus },
                    { CheckScannerCapabilitiesClass.PositionEnum.Refused, positionStatus },
                });
        }

        #region Check Interface

        /// <summary>
        /// This method accepts media into the device from the input position
        /// and could be called multiple times.
        /// A media-in transaction is initiated by the first method and remains active until the
        /// transaction is either confirmed through the MediaInEnd, or cancelled by the
        /// MediaInRollBack, the RetractMedia or Reset. Multiple calls to the
        /// this methodcan be made while a transaction is active to obtain additional items 
        /// from the customer. If a media-in transaction is active.
        /// When the command is executed, if there is no media in the input slot
        /// then the device is enabled for media entry and the
        /// Check.NoMediaEvent event is generated when the device is ready to
        /// accept media. When the customer inserts the media a Check.MediaInsertedEvent
        /// event is generated and media processing begins.
        /// If media is already present at the input slot then a Check.MediaInsertedEvent
        /// event is generated and media processing begins immediately.
        /// The Check.MediaDataEvent  event delivers the code line and all requested image data 
        /// during execution of this command.One event is generated for each media item scanned 
        /// by this command. The Check.MediaDataEvent event is not generated for refused media items.
        /// A failure during processing a single media item does not mean that the operation
        /// has failed even if some or all of the media are refused by the media reader.
        /// In this case the operation will return Success and one or more Check.MediaRefusedEvent
        /// events will be sent to report the why the items have been refused.
        /// Refused items are not presented back to the customer with this command.
        /// The Check.MediaRefusedEvent  event indicates whether or not media
        /// must be returned to the customer before further media movement operations can be executed.
        /// If the [Check.MediaRefusedEvent](#check.mediarefusedevent) event indicates
        /// that the media must be returned then the application must use the Check.PresentMedia 
        /// command to return the refused items. If the event does not indicate that the application
        /// must return the media items then the application can still elect to return the media items
        /// using the Check.PresentMedia command or instead allow the refused items to be returned 
        /// during the Check.MediaInEnd or Check.MediaInRollBack operations.
        /// 
        /// If there is no stacker on the device or ApplicationRefuse property is true
        /// then just one of the media items inserted are processed by this operation,
        /// and therefore the command completes as soon as the last image for the
        /// first item is produced or when the first item is automatically refused.
        /// If there is a stacker on the device then the command completes when the
        /// last image for the last item is produced or when the last item is refused.
        /// </summary>
        public Task<MediaInResult> MediaInAsync(
            MediaInCommandEvents events,
            MediaInRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method ends a media-in transaction. 
        /// If media items are on the stacker as a result of a Check.MediaIn operation,
        /// they are moved to the destination specified by SetMediaParameters method. 
        /// Any additional actions specified for the items by SetMediaParameters such as printing, 
        /// stamping and rescanning are also executed.
        /// If the destination has not been set for a media item then the Service will decide which storage unit to put the item into. 
        /// If no items are in the device, the operation will complete with the NoMediaPresent error and
        /// The way in which media is returned to the customer as a result of this command is defined by
        /// PresentControl capability. If false, the application must call Check.PresentMedia
        /// to present the media items to be returned as a result of this operation.
        /// If true the Service presents any returned items implicitly and the application does not 
        /// need to call Check.PresentMedia.
        /// If items have been refused and the Check.MediaRefusedEvent event
        /// has indicated that the items must be returned then these items must be returned using the
        /// Check.PresentMedia command before the MediaInEnd method is issued, otherwise a RefusedItems
        /// error will be returned. If items have been refused and the Check.MediaRefusedEvent event 
        /// has indicated that the items do not need to be returned then the MediaInEnd
        /// operation causes any refused items which have not yet been returned to the customer 
        /// (via the PresentMedia operation) to be returned along with any items that the application 
        /// has selected to return to the customer(via the SetMediaParameters method). 
        /// Even if all items are being deposited, previously refused items will be returned to the
        /// customer by this command.The Check.MediaPresentedEvent event(s)
        /// inform the application of the position where the media has been presented to.
        /// This operation completes when all the media items have been put into their
        /// specified storage units and in the case where media is returned to the customer
        /// as a result of this command, after the last bunch of media items to be
        /// returned to the customer has been presented, but before the last bunch is taken.
        /// 
        /// The media-in transaction is ended even if this command does not complete successfully.
        /// </summary>
        public Task<MediaInEndResult> MediaInEndAsync(
            MediaInEndCommandEvents events,
            MediaInEndRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method ends a media-in transaction. All media that
        /// is in the device as a result of MediaIn operation is 
        /// returned to the customer. Nothing is printed on the media.If no items
        /// are in the device the command will complete with the NoMediaPresent error.
        /// The way in which media is returned to the customer as a result of this command is defined by
        /// PresentControl capability. If false, the application must perform PresentMedia operation
        /// to present the media items to be returned as a result of this operation.
        /// If true the Service presents any returned items implicitly and the application does not need
        /// to perform PresentMedia operation.
        /// If items have been refused and the Check.MediaRefusedEvent event has indicated that the 
        /// items must be returned then these items must be returned using the PresentMedia operation
        /// before the MediaInRollBack operation is performed, otherwise a RefusedItems error will be 
        /// returned.If items have been refused and the Check.MediaRefusedEvent has indicated that
        /// the items do not need to be returned then the MediaInRollBack operation causes any refused
        /// items which have not yet been returned to the customer (via the PresentMedia operation)
        /// to be returned along with any items that are returned as a result of the rollback.
        /// The Check.MediaPresentedEvent event(s) inform the application of the
        /// position where the media has been presented to.
        /// 
        /// In the case where media is returned to the customer as a result of this operation,
        /// this method completes when the last bunch of media items to be returned to the customer 
        /// has been presented, but before the last bunch is taken.
        /// 
        /// The media-in transaction is ended even if this command does not complete successfully.
        /// </summary>
        public Task<MediaInRollbackResult> MediaInRollbackAsync(
            MediaInRollbackCommandEvents events,
            MediaInRollbackRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// On devices where items can be physically rescanned or
        /// all the supported image formats can be generated during this method
        /// (regardless of the images requested during the Check.MediaIn command), 
        /// i.e. where rescan capability is true, then this method is
        /// used to obtain additional images and/or reread the code line for media
        /// already in the device.
        /// If rescan capability is false, this method is used to
        /// retrieve an image or code line that was initially obtained when the
        /// media was initially processed (e.g.during the Check.MediaIn or Check.GetNextItem command).
        /// In this case, all images required must have been previously been requested during the
        /// Check.MediaIn command.
        /// </summary>
        public Task<ReadImageResult> ReadImageAsync(
            ReadImageRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used to present media items to the customer.
        /// Applications can use this command to return refused items without
        /// terminating the media-in transaction. This allows customers to correct
        /// the problem with the media item and reinsert during execution of a
        /// subsequent Check.MediaIn command.
        /// This method is also used to return items after media-in transaction ended with
        /// Check.MediaInEnd or Check.MediaInRollBack command
        /// A Check.MediaPresentedEvent event is generated when media is
        /// presented and a Check.MediaTakenEvent event is generated when the
        /// This method completes when the last bunch of media items to be returned to the customer has been presented, 
        /// but before the last bunch is taken.
        /// </summary>
        public Task<PresentMediaResult> PresentMediaAsync(
            PresentMediaCommandEvents events,
            PresentMediaRequest request,
            CancellationToken cancellation)
        {
            // This demo supports implicit present control
            throw new NotImplementedException();
        }

        /// <summary>
        /// The media is removed from its present position (media present in device, media entering, 
        /// unknown position) and stored in the area specified in the input parameters.
        /// if a high or full condition is reached as a result of this method.
        /// If the storage unit is already full and the operation cannot be executed, 
        /// an error is returned and the media remains in its present position.
        /// If media items are to be endorsed/stamped during this operation, then
        /// SetMediaParameters is called from application prior to the this method. Where endorsing is specified, the
        /// same text will be printed on all media items that are detected.
        ///  This method ends the current media-in transaction.
        ///If no items are in the device the command will complete with the NoMediaPresent error.
        /// </summary>
        public Task<RetractMediaResult> RetractMediaAsync(
            RetractMediaCommandEvents events,
            RetractMediaRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used by the application to perform a hardware reset which will attempt to return 
        /// the device to a known good state.
        /// This method does not override a lock obtained on another application or service handle.
        /// The device will attempt to retract or eject any items found anywhere within the device.
        /// This may not always be possible because of hardware problems.
        /// One or more Check.MediaDetectedEvent command event will inform the application 
        /// where items were actually moved to.
        /// </summary>
        public Task<ResetDeviceResult> ResetAsync(
            ResetCommandEvents events,
            ResetDeviceRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used to get the next item from the
        /// multi-item feed unit and capture the item data. The data and the format
        /// of the data that is generated by this method are defined by the input
        /// parameters of this method. The media data is
        /// reported via the Check.MediaDataEvent event.
        /// 
        /// This method must be supported by all Services where the
        /// hardware does not have a stacker or where the Service supports
        /// the application making the accept/refuse decision. On single item feed
        /// devices this method simply returns the error code NoMediaPresent. This allows a single application flow to
        /// be used on all devices without a stacker.
        /// </summary>
        public Task<GetNextItemResult> GetNextItemAsync(
            GetNextItemCommandEvents events,
            GetNextItemRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to cause the predefined actions (move item to destination, 
        /// stamping, endorsing, re-imaging) to be executed on the current media item. 
        /// This method only applies to devices without stackers.
        /// </summary>
        public Task<ActionItemResult> ActionItemAsync(
            ActionItemCommandEvents events,
            ActionItemRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The media that has been presented to the customer will be expelled out of the device.
        /// This method completes after the bunch has been expelled from the device.
        /// This method does not end the current media-in transaction.
        /// </summary>
        public Task<ExpelMediaResult> ExpelMediaAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used by applications to indicate if the current media item should 
        /// be accepted or refused. Applications only usethis command when the Check.MediaIn command 
        /// is used in the mode where the application can decide if each physically acceptablemedia 
        /// item should be accepted or refused, capability ApplicationRefuse is true.
        /// </summary>
        public Task<AcceptItemResult> AcceptItemAsync(
            AcceptItemRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// After the supplies have been replenished, this method is used to indicate that one or 
        /// more supplies have been replenished and are expected to be in a healthy state.
        /// Hardware that cannot detect the level of a supply and reports on the supply's status using metrics 
        /// (or some other means), must assume the supply has been fully replenished after this method is issued.
        /// </summary>
        public Task<DeviceResult> SupplyReplenishAsync(
            SupplyReplenishRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used to predefine parameters for the specified media item or all items. 
        /// The method can be called multiple times to specify individual parameters for each required media item.
        /// Any parameter specified replaces any parameters specified for the same media item (or items) on previous commands.
        /// The parameters which can be specified include:
        /// - Destination
        /// - Endorsements, i.e., text to be printed on the media or whether the media is to be stamped
        /// - Images of the media after it has been printed on or stamped
        /// 
        /// The media is not moved immediately by this command.The requested actions are performed during subsequent methods which
        /// move the media:
        /// On devices with stackers, MediaInEnd method
        /// On devices without stackers, ActionItem method
        /// 
        /// If the bunch is returned with MediaInRollback, none of the requested actions will be performed.
        /// If the media is to be returned to the customer using MediaInEnd or ActionItem, the media can still be
        /// endorsed if the device is capable of that.
        /// The Service will determine which storage unit to use for any items that have not had a destination set by the
        /// application.
        /// </summary>
        public Task<SetMediaParametersResult> SetMediaParametersAsync(
            SetMediaParametersRequest request,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check Scanner Status
        /// </summary>
        public CheckScannerStatusClass CheckScannerStatus { get; set; }

        /// <summary>
        /// Check Scanner Capabilities
        /// </summary>
        public CheckScannerCapabilitiesClass CheckScannerCapabilities { get; set; } = new(
                Type: CheckScannerCapabilitiesClass.TypeEnum.Bunch,
                MaxMediaOnStacker: 10,
                PrintSize: new(5, 10),
                Stamp: true,
                Rescan: false,
                PresentControl: true,
                ApplicationRefuse: false,
                RetractLocations: CheckScannerCapabilitiesClass.RetractLocationEnum.Storage | 
                                  CheckScannerCapabilitiesClass.RetractLocationEnum.Stacker,
                ResetControls: CheckScannerCapabilitiesClass.ResetControlEnum.Storage |
                               CheckScannerCapabilitiesClass.ResetControlEnum.Eject,
                ImageTypes: CheckScannerCapabilitiesClass.ImageTypeEnum.BMP,
                FrontImage: new(
                    ColorFormats: CheckScannerCapabilitiesClass.ImageCapabilities.ColorFormatEnum.Binary,
                    ScanColor: CheckScannerCapabilitiesClass.ImageCapabilities.ScanColorFlagEnum.Red,
                    DefaultScanColor: CheckScannerCapabilitiesClass.ImageCapabilities.ScanColorEnum.Red),
                BackImage: null,
                CodelineFormats: CheckScannerCapabilitiesClass.CodelineFormatEnum.CMC7,
                DataSources: CheckScannerCapabilitiesClass.DataSourceEnum.Front |
                             CheckScannerCapabilitiesClass.DataSourceEnum.Codeline,
                InsertOrientations: CheckScannerCapabilitiesClass.InsertOrientationEnum.CodelineRight,
                Positions: new()
                {
                    { 
                        CheckScannerCapabilitiesClass.PositionEnum.Input, 
                        new(
                            ItemsTakenSensor: true, 
                            ItemsInsertedSensor: true, 
                            RetractAreas: CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.RetractBin | 
                            CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.Stacker) 
                    },
                    {
                        CheckScannerCapabilitiesClass.PositionEnum.Output,
                        new(
                            ItemsTakenSensor: true,
                            ItemsInsertedSensor: true,
                            RetractAreas: CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.RetractBin |
                            CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.Stacker)
                    },
                    {
                        CheckScannerCapabilitiesClass.PositionEnum.Refused,
                        new(
                            ItemsTakenSensor: true,
                            ItemsInsertedSensor: true,
                            RetractAreas: CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.RetractBin |
                            CheckScannerCapabilitiesClass.PositonCapabilities.RetractAreasEnum.Stacker)
                    },
                },
                ImageAfterEndorse: false,
                ReturnedItemsProcessing: CheckScannerCapabilitiesClass.ReturnedItemsProcessingEnum.Endorse,
                PrintSizeFront: new(5, 10));

        #endregion

        #region Storage Interface

        /// <summary>
        /// Return cheeck storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCheckStorageConfiguration(out Dictionary<string, CheckUnitStorageConfiguration> newCheckUnits)
        {
            /* Example of check unit info
            if (CheckUnitInfo.Count == 0)
            {
                CheckStorageInfo bin1 = new(
                    CheckUnitStorageConfig: new(
                        PositionName: "BIN1",
                        Capacity: 100,
                        SerialNumber: "sn1001",
                        Capabilities: new CheckCapabilitiesClass(
                            Types: CheckCapabilitiesClass.TypesEnum.MediaIn,
                            Sensors: CheckCapabilitiesClass.SensorEnum.High |
                                     CheckCapabilitiesClass.SensorEnum.Empty),
                        Configuration: new(
                            Types: CheckCapabilitiesClass.TypesEnum.MediaIn,
                            Id: "MediaBin1",
                            HighThreshold: 90,
                            RetractHighThreshold: -1))
                    );

                CheckUnitInfo.Add("unit1", bin1);

                CheckStorageInfo retract = new(
                    CheckUnitStorageConfig: new(
                        PositionName: "BIN1",
                        Capacity: 100,
                        SerialNumber: "sn1001",
                        Capabilities: new CheckCapabilitiesClass(
                            Types: CheckCapabilitiesClass.TypesEnum.Retract,
                            Sensors: CheckCapabilitiesClass.SensorEnum.High |
                                     CheckCapabilitiesClass.SensorEnum.Empty),
                        Configuration: new(
                            Types: CheckCapabilitiesClass.TypesEnum.MediaIn,
                            Id: "MediaBin1",
                            HighThreshold: 90,
                            RetractHighThreshold: -1))
                    );

                CheckUnitInfo.Add("unitRetract", retract);

            }

            newCheckUnits = [];
            foreach (var unit in CheckUnitInfo)
            {
                newCheckUnits.Add(unit.Key, unit.Value.CheckUnitStorageConfig);
            }
            */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return check unit counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCheckUnitCounts(out Dictionary<string, StorageCheckCountClass> unitCounts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return check unit initial counts maintained by the device class and only this method is called on the start of day
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCheckUnitInitialCounts(out Dictionary<string, StorageCheckCountClass> initialCounts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return check storage status.
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckStorageStatus(out Dictionary<string, CheckUnitStorage.StatusEnum> storageStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return check unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckUnitStatus(out Dictionary<string, CheckStatusClass.ReplenishmentStatusEnum> unitStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set new configuration and counters for check units
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCheckStorageResult> SetCheckStorageAsync(SetCheckStorageRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start cash unit exchange operation
        /// </summary>
        public Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Complete cash unit exchange operation
        /// </summary>
        public Task<EndExchangeResult> EndExchangeAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns></returns>
        public bool GetCardStorageConfiguration(out Dictionary<string, CardUnitStorageConfiguration> newCardUnits) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// This method is call after card is moved to the storage. Move or Reset command.
        /// </summary>
        /// <returns>Return true if the device maintains hardware counters for the card units</returns>
        public bool GetCardUnitCounts(out Dictionary<string, CardUnitCount> unitCounts) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware status by device class. the maintaining status by the framework will be overwritten.
        /// The framework can't handle threshold event if the device class maintains hardware storage status on threshold value is not zero.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card unit status</returns>
        public bool GetCardUnitStatus(out Dictionary<string, CardStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware storage status by device class.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card storage status</returns>
        public bool GetCardStorageStatus(out Dictionary<string, CardUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCardStorageResult> SetCardStorageAsync(SetCardStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCashStorageConfiguration(out Dictionary<string, CashUnitStorageConfiguration> newCashUnits) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash unit counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitCounts(out Dictionary<string, CashUnitCountClass> unitCounts) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return cash unit initial counts maintained by the device class and only this method is called on the start of day/
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCashUnitInitialCounts(out Dictionary<string, StorageCashCountClass> initialCounts) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash storage status
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashStorageStatus(out Dictionary<string, CashUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashUnitStatus(out Dictionary<string, CashStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return accuracy of counts. This method is called if the device class supports feature for count accuray
        /// </summary>
        public void GetCashUnitAccuray(string storageId, out CashStatusClass.AccuracyEnum unitAccuracy) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Check service provider doesn't support card related operations.");

        /// <summary>
        /// Return printer storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetPrinterStorageConfiguration(out Dictionary<string, PrinterUnitStorageConfiguration> newPrinterUnits) => throw new NotSupportedException($"The Check service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer storage counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetPrinterUnitCounts(out Dictionary<string, PrinterUnitCount> unitCounts) => throw new NotSupportedException($"The Check service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer storage status (retract bin, passbook storage).
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterStorageStatus(out Dictionary<string, PrinterUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Check service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer unit status (retract bin, passbook storage) maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterUnitStatus(out Dictionary<string, XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Check service provider doesn't support printer related operations.");

        /// <summary>
        /// Set new configuration and counters for printer storage.
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetPrinterStorageResult> SetPrinterStorageAsync(SetPrinterStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Check service provider doesn't support printer related operations.");

        /// <summary>
        /// Return IBNS storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// Status object is a reference to report status changes.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetIBNSStorageInfo(out Dictionary<string, IBNSStorageInfo> newIBNSUnits) => throw new NotSupportedException($"The Check service provider doesn't support IBNS related operations.");

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
                    Commands:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.StatusChangedEvent,
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.ErrorEvent,
                    ]
                ),
                CheckScannerInterface: new CommonCapabilitiesClass.CheckScannerInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.ActionItem,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.AcceptItem,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.GetNextItem,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.GetTransactionStatus,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.MediaIn,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.MediaInEnd,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.MediaInRollback,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.ReadImage,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.RetractMedia,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.PresentMedia,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.CommandEnum.SupplyReplenish,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaPresentedEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaDataEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaRefusedEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaInsertedEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaPresentedEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaTakenEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.NoMediaEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaDetectedEvent,
                        CommonCapabilitiesClass.CheckScannerInterfaceClass.EventEnum.MediaRejectedEvent,
                    ]
                ),
                StorageInterface: new CommonCapabilitiesClass.StorageInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.StartExchange,
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.EndExchange,
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.GetStorage,
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.SetStorage,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageThresholdEvent,
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageChangedEvent,
                        CommonCapabilitiesClass.StorageInterfaceClass.EventEnum.StorageErrorEvent,
                    ]
                ),
                DeviceInformation:
                [
                    new CommonCapabilitiesClass.DeviceInformationClass(
                            ModelName: "Simulator",
                            SerialNumber: "123456-78900001",
                            RevisionNumber: "1.0",
                            ModelDescription: "KAL simualtor",
                            Firmware:
                            [
                                new CommonCapabilitiesClass.FirmwareClass(
                                        FirmwareName: "XFS4 SP",
                                        FirmwareVersion: "1.0",
                                        HardwareRevision: "1.0")
                            ],
                            Software:
                            [
                                new CommonCapabilitiesClass.SoftwareClass(
                                        SoftwareName: "XFS4 SP",
                                        SoftwareVersion: "1.0")
                            ])
                ],
                PowerSaveControl: false,
                AntiFraudModule: false,
                EndToEndSecurity: new CommonCapabilitiesClass.EndToEndSecurityClass
                (
                    Required: CommonCapabilitiesClass.EndToEndSecurityClass.RequiredEnum.Always,
                    HardwareSecurityElement: false, // Sample is software. Real hardware should use an HSE. 
                    ResponseSecurityEnabled: CommonCapabilitiesClass.EndToEndSecurityClass.ResponseSecurityEnabledEnum.NotSupported
                ));

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();
        #endregion

        /// <summary>
        /// This position can be used accordingly with the device to be implemented.
        /// </summary>
        private readonly CheckScannerStatusClass.PositionStatusClass positionStatus = new(
            Shutter: CheckScannerStatusClass.ShutterEnum.Closed,
            PositionStatus: CheckScannerStatusClass.PositionStatusEnum.Empty,
            Transport: CheckScannerStatusClass.TransportEnum.Ok,
            TransportMediaStatus: CheckScannerStatusClass.TransportMediaStatusEnum.Empty,
            JammedShutterPosition: CheckScannerStatusClass.JammedShutterPositionEnum.NotJammed);
         
        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private XFS4IoT.ILogger Logger { get; }
    }
}