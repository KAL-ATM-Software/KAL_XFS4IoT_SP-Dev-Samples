/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
 * 
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoTFramework.Printer;
using XFS4IoTFramework.Common;
using XFS4IoTServer;
using XFS4IoTFramework.Storage;

namespace Printer.PrinterTemplate
{
    /// <summary>
    /// Sample Printer device class to implement
    /// </summary>
    public class PrinterTemplate : IPrinterDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public PrinterTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(PrinterTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(
                Device: CommonStatusClass.DeviceEnum.Online,
                DevicePosition: CommonStatusClass.PositionStatusEnum.InPosition,
                PowerSaveRecoveryTime: 0,
                AntiFraudModule: CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                Exchange: CommonStatusClass.ExchangeEnum.NotSupported,
                CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            PrinterStatus = new XFS4IoTFramework.Common.PrinterStatusClass(
                Media: XFS4IoTFramework.Common.PrinterStatusClass.MediaEnum.NotPresent,
                Paper: new Dictionary<XFS4IoTFramework.Common.PrinterStatusClass.PaperSourceEnum, XFS4IoTFramework.Common.PrinterStatusClass.SupplyStatusClass>()
                {
                    { XFS4IoTFramework.Common.PrinterStatusClass.PaperSourceEnum.Upper, PaperSupplyStatus }
                },
                Toner: XFS4IoTFramework.Common.PrinterStatusClass.TonerEnum.NotSupported,
                Ink: XFS4IoTFramework.Common.PrinterStatusClass.InkEnum.NotSupported,
                Lamp: XFS4IoTFramework.Common.PrinterStatusClass.LampEnum.NotSupported,
                MediaOnStacker: 0,
                BlackMarkMode: BlackMarkModeStatus);
        }

        #region Printer Interface

        /// <summary>
        /// This method is used to control media.
        /// If an eject operation is specified, it completes when the media is moved to the exit slot.An unsolicited event is
        /// generated when the media has been taken by the device capability is true.
        /// </summary>
        public Task<ControlMediaResult> ControlMediaAsync(ControlMediaEvent controlMediaEvent,
                                                          ControlMediaRequest request,
                                                          CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used by the application to perform a hardware reset which will attempt to return the device to a
        /// known good state.
        /// </summary>
        public Task<ResetDeviceResult> ResetDeviceAsync(ResetDeviceRequest request,
                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method switches the black mark detection mode and associated functionality on or off. The black mark
        /// detection mode is persistent. If the selected mode is already active this command will complete with success.
        /// </summary>
        public Task<DeviceResult> SetBlackMarkModeAsync(BlackMarkModeEnum mode,
                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// After the supplies have been replenished, this method is used to indicate that one or more supplies have been
        /// replenished and are expected to be in a healthy state.
        /// Hardware that cannot detect the level of a supply and reports on the supply's status using metrics (or some other
        /// means), must assume the supply has been fully replenished after this command is issued.The appropriate threshold
        /// event must be broadcast.
        /// Hardware that can detect the level of a supply must update its status based on its sensors, generate a threshold
        /// event if appropriate, and succeed the command even if the supply has not been replenished. If it has already
        /// detected the level and reported the threshold before this command was issued, the command must succeed and no
        /// threshold event is required.
        /// </summary>
        public Task<DeviceResult> SupplyReplenishedAsync(SupplyReplenishedRequest request,
                                                         CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is the main method for printing forms.
        /// It is passed a KXPrintJob containing one or more atomic PrintTask to print.
        /// The passed tasks are printed and flushed to the printer.
        /// Measurements in all tasks are in printer dots.
        /// This method must be implemented if your device is capable or printing.
        /// </summary>
        public Task<PrintTaskResult> ExecutePrintTasksAsync(PrintTaskRequest request,
                                                            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used to send raw data (a byte string of device dependent data) to the physical device.
        /// </summary>
        public Task<RawPrintResult> RawPrintAsync(RawPrintCommandEvents events,
                                                  RawPrintRequest request,
                                                  CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns width and height of passed task in printer dots.
        /// i.e. width and height of rectangle needed to contain the task when executed.
        /// Normally expected to return true since no hardware action is requested.
        /// </summary>
        public bool GetTaskDimensions(PrintTask task, out int width, out int height)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method sets the page size in dots.  The requested size
        /// may be given as zero - since that's a valid media length.
        /// In XFS the value zero means an infinite roll which is never cut
        /// so if page size is set to zero and a cut instruction sent
        /// the SP can decide what to do: either cut at current postion
        /// or go into black mark mode for instance.
        /// </summary>
        public bool SetPageSize(int lengthInDots)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return binary data for mapping codeline format
        /// </summary>
        public List<byte> GetCodelineMapping(CodelineFormatEnum codelineFormat)
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
        /// This method is to print a loaded form and media in the firmware where all fields prefixed positions are recognized.
        /// </summary>
        public Task<PrintFormResult> DirectFormPrintAsync(DirectFormPrintRequest request, CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This method can turn the pages of a passbook inserted in the printer by a specified number of pages in a
        /// specified direction and it can close the passbook.
        /// </summary>
        public Task<ControlPassbookResult> ControlPassbookAsync(ControlPassbookRequest request, CancellationToken cancellation) => throw new NotSupportedException();

        /// <summary>
        /// This method is used to move paper (which can also be a new passbook) from a paper source into the print position.
        /// </summary>
        public Task<DispensePaperResult> DispensePaperAsync(DispensePaperCommandEvents events, DispensePaperRequest request, CancellationToken cancellation) => throw new NotSupportedException();

        /// <summary>
        /// This method returns image data from the current media. If no media is present, the device waits for the timeout
        /// specified, for media to be inserted.
        /// If the returned image data is in Windows bitmap format (BMP) and a file path for storing the image is not
        /// supplied, then the first byte of data will be the start of the Bitmap Info Header (this bitmap format is known as
        /// DIB, Device Independent Bitmap). The Bitmap File Info Header, which is only present in file versions of bitmaps,
        /// will NOT be returned.If the returned image data is in bitmap format(BMP) and a file path for storing the image
        /// is supplied, then the first byte of data in the stored file will be the Bitmap File Info Header.
        /// </summary>
        public Task<AcceptAndReadImageResult> AcceptAndReadImageAsync(ReadImageCommandEvents events, AcceptAndReadImageRequest request, CancellationToken cancellation) => throw new NotSupportedException();

        /// <summary>
        /// This method resets the present value for number of media items retracted to zero. The function is possible only
        /// for printers with retract capability.
        /// if the binNumber is -1, all retract bin counter to be reset
        /// </summary>
        public Task<DeviceResult> ResetBinCounterAsync(int binNumber, CancellationToken cancellation) => throw new NotSupportedException();

        /// <summary>
        /// The media is removed from its present position (media inserted into device, media entering, unknown position) and
        /// stored in one of the retract bins.An event is sent if the storage capacity of the specified retract bin is
        /// reached. If the bin is already full and the command cannot be executed, an error is returned and the media remains
        /// in its present position.
        /// </summary>
        public Task<RetractResult> RetractAsync(int binNumber, CancellationToken cancellation) => throw new NotSupportedException();

        /// <summary>
        /// Printer Status
        /// </summary>
        public XFS4IoTFramework.Common.PrinterStatusClass PrinterStatus { get; set; }

        /// <summary>
        /// Printer Capabilities
        /// </summary>
        public XFS4IoTFramework.Common.PrinterCapabilitiesClass PrinterCapabilities { get; set; } = 
            new XFS4IoTFramework.Common.PrinterCapabilitiesClass(
                Types: XFS4IoTFramework.Common.PrinterCapabilitiesClass.TypeEnum.Receipt,
                Resolutions: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ResolutionEnum.Medium,
                ReadForms: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ReadFormEnum.NotSupported,
                WriteForms: XFS4IoTFramework.Common.PrinterCapabilitiesClass.WriteFormEnum.NotSupported,
                Extents: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ExtentEnum.NotSupported,
                Controls: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ControlEnum.Flush |
                          XFS4IoTFramework.Common.PrinterCapabilitiesClass.ControlEnum.Eject |
                          XFS4IoTFramework.Common.PrinterCapabilitiesClass.ControlEnum.Cut |
                          XFS4IoTFramework.Common.PrinterCapabilitiesClass.ControlEnum.ClearBuffer,
                MaxMediaOnStacker: 0,
                AcceptMedia: false,
                MultiPage: false,
                PaperSources: XFS4IoTFramework.Common.PrinterCapabilitiesClass.PaperSourceEnum.Upper,
                MediaTaken: true,
                ImageTypes: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ImageTypeEnum.NotSupported,
                FrontImageColorFormats: XFS4IoTFramework.Common.PrinterCapabilitiesClass.FrontImageColorFormatEnum.NotSupported,
                BackImageColorFormats: XFS4IoTFramework.Common.PrinterCapabilitiesClass.BackImageColorFormatEnum.NotSupported,
                ImageSourceTypes: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ImageSourceTypeEnum.NotSupported,
                DispensePaper: false,
                OSPrinter: null,
                MediaPresented: false,
                AutoRetractPeriod: 0,
                RetractToTransport: false,
                CoercivityTypes: XFS4IoTFramework.Common.PrinterCapabilitiesClass.CoercivityTypeEnum.NotSupported,
                ControlPassbook: XFS4IoTFramework.Common.PrinterCapabilitiesClass.ControlPassbookEnum.NotSupported,
                PrintSides: XFS4IoTFramework.Common.PrinterCapabilitiesClass.PrintSidesEnum.NotSupported
            );

        /// <summary>
        /// This property must added MediaSpec structures to reflect the media supported by the specific device.
        /// At least one element must be added. If the printer has more than one paper supply, more than one structure may be returned.
        /// </summary>
        public List<MediaSpec> MediaSpecs { get; set; } =
        [
            new MediaSpec(0, 0)
        ];

        /// <summary>
        /// This property must return a FormRules structure which reflects
        /// the print capabilities of the specific device being supported.
        /// </summary>
        public FormRules FormRules { get; set; } = new
        (
            RowColumnOnly: false,
            ValidOrientation: FormOrientationEnum.PORTRAIT | FormOrientationEnum.LANDSCAPE,
            MinSkew: 0,
            MaxSkew: 90,
            ValidSide: FieldSideEnum.FRONT,
            ValidType: FieldTypeEnum.TEXT,
            ValidScaling: FieldScalingEnum.BESTFIT |
                          FieldScalingEnum.MAINTAINASPECT |
                          FieldScalingEnum.ASIS,
            ValidAccess: FieldAccessEnum.WRITE | FieldAccessEnum.READWRITE,
            // All styles valid as a default
            ValidStyle: FieldStyleEnum.BOLD |
                        FieldStyleEnum.CONDENSED |
                        FieldStyleEnum.ITALIC |
                        FieldStyleEnum.NORMAL,
            ValidBarcode: 0,
            ValidColor: FieldColorEnum.BLACK,
            ValidFonts: "ALL",
            MinPointSize: 1,
            MaxPointSize: 1000,
            MinCPI: 1,
            MaxCPI: 100,
            MinLPI: 1,
            MaxLPI: 100
        );

        /// <summary>
        /// Values for unit conversions
        /// All print tasks supplied to the printer are in printer dots.
        /// The printer must therefore export information about these
        /// units to the printer framework ie. how many dots-per-mm, dots-per-inch 
        /// and dots-per-row/column.  Conversion factors are given as a fraction -
        /// So there are DotsPerInchTop/DotsPerInchBottom dots-per-inch
        /// and similarly for mm and row/column.  Interpretation of Row/Column
        /// should be average size of a character in the default font.
        /// 

        public int DotsPerInchTopX { get; set; } = 0;
        public int DotsPerInchBottomX { get; set; } = 0;
        public int DotsPerInchTopY { get; set; } = 0;
        public int DotsPerInchBottomY { get; set; } = 0;
        public int DotsPerMMTopX { get; set; } = 0;
        public int DotsPerMMBottomX { get; set; } = 0;
        public int DotsPerMMTopY { get; set; } = 0;
        public int DotsPerMMBottomY { get; set; } = 0;
        // Default char is 3mm high by 2mm wide: 24 x 16 dots.
        public int DotsPerRowTop { get; set; } = 0;
        public int DotsPerRowBottom { get; set; } = 0;
        public int DotsPerColumnTop { get; set; } = 0;
        public int DotsPerColumnBottom { get; set; } = 0;
        #endregion

        #region Storage Interface


        /// <summary>
        /// Return cheeck storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCheckStorageConfiguration(out Dictionary<string, CheckUnitStorageConfiguration> newCheckUnits) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");

        /// <summary>
        /// Return check unit counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCheckUnitCounts(out Dictionary<string, StorageCheckCountClass> unitCounts) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit initial counts maintained by the device class and only this method is called on the start of day
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCheckUnitInitialCounts(out Dictionary<string, StorageCheckCountClass> initialCounts) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");

        /// <summary>
        /// Return check storage status.
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckStorageStatus(out Dictionary<string, CheckUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckUnitStatus(out Dictionary<string, CheckStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");
        /// <summary>
        /// Set new configuration and counters for check units
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCheckStorageResult> SetCheckStorageAsync(SetCheckStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Printer service provider doesn't support check related operations.");
        /// <summary>
        /// Start cash unit exchange operation
        /// </summary>
        public async Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Prepare for the cash unit exchange operation
            CommonStatus.Exchange = CommonStatusClass.ExchangeEnum.Active;

            return new StartExchangeResult(MessageHeader.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// Complete cash unit exchange operation
        /// </summary>
        public async Task<EndExchangeResult> EndExchangeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Complete for the cash unit exchange operation
            CommonStatus.Exchange = CommonStatusClass.ExchangeEnum.Inactive;

            return new EndExchangeResult(MessageHeader.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns></returns>
        public bool GetCardStorageConfiguration(out Dictionary<string, CardUnitStorageConfiguration> newCardUnits) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// This method is call after card is moved to the storage. Move or Reset command.
        /// </summary>
        /// <returns>Return true if the device maintains hardware counters for the card units</returns>
        public bool GetCardUnitCounts(out Dictionary<string, CardUnitCount> unitCounts) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware status by device class. the maintaining status by the framework will be overwritten.
        /// The framework can't handle threshold event if the device class maintains hardware storage status on threshold value is not zero.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card unit status</returns>
        public bool GetCardUnitStatus(out Dictionary<string, CardStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware storage status by device class.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card storage status</returns>
        public bool GetCardStorageStatus(out Dictionary<string, CardUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCardStorageResult> SetCardStorageAsync(SetCardStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCashStorageConfiguration(out Dictionary<string, CashUnitStorageConfiguration> newCashUnits) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash unit counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitCounts(out Dictionary<string, CashUnitCountClass> unitCounts) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return cash unit initial counts maintained by the device class and only this method is called on the start of day/
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCashUnitInitialCounts(out Dictionary<string, StorageCashCountClass> initialCounts) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash storage status
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashStorageStatus(out Dictionary<string, CashUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return return cash unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashUnitStatus(out Dictionary<string, CashStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return accuracy of counts. This method is called if the device class supports feature for count accuray
        /// </summary>
        public void GetCashUnitAccuray(string storageId, out CashStatusClass.AccuracyEnum unitAccuracy) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Printer service provider doesn't support card related operations.");

        /// <summary>
        /// Return printer storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetPrinterStorageConfiguration(out Dictionary<string, PrinterUnitStorageConfiguration> newPrinterUnits)
        {
            newPrinterUnits = [];
            newPrinterUnits.Add(printerUnitInfo.PrinterBin.PositionName, printerUnitInfo.PrinterBin);
            return true;
        }

        /// <summary>
        /// Return printer storage counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetPrinterUnitCounts(out Dictionary<string, PrinterUnitCount> unitCounts)
        {
            unitCounts = [];
            unitCounts.Add(printerUnitInfo.PrinterBin.PositionName, new(printerUnitInfo.InitialCount,
                                                                        printerUnitInfo.CurrentCount));
            return true;
        }

        /// <summary>
        /// Return printer storage status (retract bin, passbook storage).
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterStorageStatus(out Dictionary<string, PrinterUnitStorage.StatusEnum> storageStatus)
        {
            storageStatus = [];
            storageStatus.Add(printerUnitInfo.PrinterBin.PositionName, printerUnitInfo.StorageStatus);
            return true;
        }

        /// <summary>
        /// Return printer unit status (retract bin, passbook storage) maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterUnitStatus(out Dictionary<string, XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum> unitStatus)
        {
            unitStatus = [];
            unitStatus.Add(printerUnitInfo.PrinterBin.PositionName, printerUnitInfo.UnitStatus);
            return true;
        }

        /// <summary>
        /// Set new configuration and counters for printer storage.
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public async Task<SetPrinterStorageResult> SetPrinterStorageAsync(SetPrinterStorageRequest request, CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            foreach (var unit in request.PrinterStorageToSet)
            {
                if (unit.Key == printerUnitInfo.PrinterBin.PositionName)
                {

                    if (unit.Value.InitialCount is not null)
                    {
                        printerUnitInfo.InitialCount = (int)unit.Value.InitialCount;
                        printerUnitInfo.CurrentCount = printerUnitInfo.InitialCount;
                        printerUnitInfo.UnitStatus = XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum.Healthy;
                        if (printerUnitInfo.CurrentCount >= printerUnitInfo.PrinterBin.Capabilities.MaxRetracts)
                        {
                            printerUnitInfo.UnitStatus = XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum.Full;
                        }
                    }
                }
            }

            Dictionary<string, SetPrinterUnitStorage> newStorage = [];
            newStorage.Add(
                printerUnitInfo.PrinterBin.PositionName,
                new SetPrinterUnitStorage(
                    new(),
                    printerUnitInfo.InitialCount));

            return new SetPrinterStorageResult(MessageHeader.CompletionCodeEnum.Success, newStorage);
        }

        /// <summary>
        /// Return IBNS storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// Status object is a reference to report status changes.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetIBNSStorageInfo(out Dictionary<string, IBNSStorageInfo> newIBNSUnits) => throw new NotSupportedException($"The Printer service provider doesn't support IBNS related operations.");

        /// <summary>
        /// Return deposit storage (box or bag) information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetDepositStorageConfiguration(out Dictionary<string, DepositUnitStorageConfiguration> newDepositUnits) => throw new NotSupportedException($"The Printer service provider doesn't support deposit related operations.");

        /// <summary>
        /// Return deposit storage counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetDepositUnitInfo(out Dictionary<string, DepositUnitInfo> unitCounts) => throw new NotSupportedException($"The Printer service provider doesn't support deposit related operations.");

        /// <summary>
        /// Set new configuration and counters for deposit storage.
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetPrinterStorageResult> SetDepositStorageAsync(SetDepositStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The Printer service provider doesn't support deposit related operations.");

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
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    ]
                ),
                PrinterInterface: new CommonCapabilitiesClass.PrinterInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.ControlMedia,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetCodelineMapping,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetFormList,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetMediaList,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryField,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryForm,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryMedia,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.PrintForm,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.PrintRaw,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SetBlackMarkMode,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SupplyReplenish,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SetForm,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SetMedia,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.DefinitionLoadedEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.FieldErrorEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.FieldWarningEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.MediaTakenEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.NoMediaEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.PaperThresholdEvent,
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
                AntiFraudModule: false);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();

        #endregion 

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private ILogger Logger { get; }

        private XFS4IoTFramework.Common.PrinterStatusClass.SupplyStatusClass PaperSupplyStatus { get; set; } = 
            new(
                XFS4IoTFramework.Common.PrinterStatusClass.PaperSupplyEnum.Full,
                XFS4IoTFramework.Common.PrinterStatusClass.PaperTypeEnum.Single);
        private XFS4IoTFramework.Common.PrinterStatusClass.BlackMarkModeEnum BlackMarkModeStatus { get; set; } = XFS4IoTFramework.Common.PrinterStatusClass.BlackMarkModeEnum.Off;
        
        // Default page size is 10cm = 8 * 10 * 10 dots.
        private int PageSize { get; set; } = 800;

        private sealed class PrinterUnitInfo
        {
            public PrinterUnitInfo()
            {
                CurrentCount = 0;
                InitialCount = 0;
                StorageStatus = CardUnitStorage.StatusEnum.Good;
                UnitStatus = XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum.Healthy;
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
            public XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum UnitStatus { get; set; }

            public PrinterUnitStorageConfiguration PrinterBin = new(
                "unitBIN1",
                50,
                "SN104827639",
                new XFS4IoTFramework.Storage.PrinterCapabilitiesClass(100),
                new());
        }

        private readonly PrinterUnitInfo printerUnitInfo = new();
    }
}