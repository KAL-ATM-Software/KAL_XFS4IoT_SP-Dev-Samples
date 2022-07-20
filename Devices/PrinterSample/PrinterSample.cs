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
using System.Text;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.Printer;
using XFS4IoTFramework.Common;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.Printer.Events;
using XFS4IoT.Printer;
using XFS4IoT.Printer.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.Printer.Sample
{
    /// <summary>
    /// Sample Printer device class to implement
    /// </summary>
    public class PrinterSample : IPrinterDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public PrinterSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(PrinterSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(Device: CommonStatusClass.DeviceEnum.Online,
                                                 DevicePosition: CommonStatusClass.PositionStatusEnum.InPosition,
                                                 PowerSaveRecoveryTime: 0,
                                                 AntiFraudModule: CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 Exchange: CommonStatusClass.ExchangeEnum.NotSupported,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            PrinterStatus = new PrinterStatusClass(Media: PrinterStatusClass.MediaEnum.NotPresent,
                                                   Paper: new Dictionary<PrinterStatusClass.PaperSourceEnum, PrinterStatusClass.SupplyStatusClass>()
                                                   { 
                                                       { PrinterStatusClass.PaperSourceEnum.Upper, PaperSupplyStatus } 
                                                   },
                                                   Toner:  PrinterStatusClass.TonerEnum.NotSupported,
                                                   Ink:  PrinterStatusClass.InkEnum.NotSupported,
                                                   Lamp:  PrinterStatusClass.LampEnum.NotSupported,
                                                   RetractBins: null,
                                                   MediaOnStacker:  0,
                                                   BlackMarkMode: BlackMarkModeStatus);
        }

        #region Printer Interface

        /// <summary>
        /// This method is used to control media.
        /// If an eject operation is specified, it completes when the media is moved to the exit slot.An unsolicited event is
        /// generated when the media has been taken by the device capability is true.
        /// </summary>
        public async Task<ControlMediaResult> ControlMediaAsync(ControlMediaEvent controlMediaEvent,
                                                                ControlMediaRequest request,
                                                                CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            if (request.Controls.HasFlag(PrinterCapabilitiesClass.ControlEnum.Eject))
            {
                if (PrinterStatus.Media != PrinterStatusClass.MediaEnum.Present)
                {
                    return new ControlMediaResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                  $"No media to eject.",
                                                  ControlMediaResult.ErrorCodeEnum.NoMediaPresent);
                }
                PrinterStatus.Media = PrinterStatusClass.MediaEnum.Entering;

                await controlMediaEvent.MediaPresentedEvent(new MediaPresentedEvent.PayloadData());
                new Thread(PaperTakenThread).IsNotNull().Start();
            }

            return new ControlMediaResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method is used by the application to perform a hardware reset which will attempt to return the device to a
        /// known good state.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(ResetDeviceRequest request,
                                                              CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);
            PaperSupplyStatus.PaperSupply = PrinterStatusClass.PaperSupplyEnum.Full;
            CommonStatus.Device = CommonStatusClass.DeviceEnum.Online;
            return new ResetDeviceResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method switches the black mark detection mode and associated functionality on or off. The black mark
        /// detection mode is persistent. If the selected mode is already active this command will complete with success.
        /// </summary>
        public async Task<DeviceResult> SetBlackMarkModeAsync(BlackMarkModeEnum mode,
                                                              CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);
            if (mode == BlackMarkModeEnum.Off)
                BlackMarkModeStatus = PrinterStatusClass.BlackMarkModeEnum.Off;
            else
                BlackMarkModeStatus = PrinterStatusClass.BlackMarkModeEnum.On;
            return new DeviceResult(MessagePayload.CompletionCodeEnum.Success);
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
        public async Task<DeviceResult> SupplyReplenishedAsync(SupplyReplenishedRequest request,
                                                               CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);
            PaperSupplyStatus.PaperSupply = PrinterStatusClass.PaperSupplyEnum.Full;
            return new DeviceResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method is the main method for printing forms.
        /// It is passed a KXPrintJob containing one or more atomic PrintTask to print.
        /// The passed tasks are printed and flushed to the printer.
        /// Measurements in all tasks are in printer dots.
        /// This method must be implemented if your device is capable or printing.
        /// </summary>
        public async Task<PrintTaskResult> ExecutePrintTasksAsync(PrintTaskRequest request,
                                                                  CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);
            return new PrintTaskResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method is used to send raw data (a byte string of device dependent data) to the physical device.
        /// </summary>
        public async Task<RawPrintResult> RawPrintAsync(MediaPresentedCommandEvent events,
                                                        RawPrintRequest request,
                                                        CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);
            return new RawPrintResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// Returns width and height of passed task in printer dots.
        /// i.e. width and height of rectangle needed to contain the task when executed.
        /// Normally expected to return true since no hardware action is requested.
        /// </summary>
        public bool GetTaskDimensions(PrintTask task, out int width, out int height)
        {
            width = 0;
            height = 0;
            
            // Text printing only supported
            switch (task.Type)
            {
                case FieldTypeEnum.TEXT:
                    {
                        TextTask textTask = (TextTask)task;
                        // Width = length of print task * size of one column
                        width = textTask.Text.Length * DotsPerColumnTop / DotsPerColumnBottom;
                        // Double width if style is DOUBLE
                        if (textTask.Style.HasFlag(FieldStyleEnum.DOUBLE))
                        {
                            width *= 2;
                        }
                        // Height = size of one row
                        height = DotsPerRowTop / DotsPerRowBottom;
                    }
                    break;
                default:
                    Contracts.Assert(false, $"Request to get dimensions of unsupported task. {task.Type}");
                    break;
            }
            return true;
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
            PageSize = lengthInDots;
            return true;
        }

        /// <summary>
        /// Return binary data for mapping codeline format
        /// </summary>
        public List<byte> GetCodelineMapping(CodelineFormatEnum codelineFormat)
        {
            if (codelineFormat == CodelineFormatEnum.CMC7)
            {
                return new List<byte>() { 0x61, 0x62, 0x63, 0x64, 0x65, 0x00 };
            }
            return new List<byte>() { 0x61, 0x62, 0x63, 0x64, 0x00 };
        }

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling MediaRemovedEvent after card is ejected successfully.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync(CancellationToken cancel)
        {
            PrinterServiceProvider printerServiceProvider = SetServiceProvider as PrinterServiceProvider;

            for (;;)
            {
                await paperTakenSignal?.WaitAsync();
                if (PrinterStatus.Media != PrinterStatusClass.MediaEnum.NotPresent)
                {
                    PrinterStatus.Media = PrinterStatusClass.MediaEnum.NotPresent;
                    await printerServiceProvider.IsNotNull().MediaTakenEvent();
                }
            }
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
        public Task<DispensePaperResult> DispensePaperAsync(MediaPresentedCommandEvent events, DispensePaperRequest request, CancellationToken cancellation) => throw new NotSupportedException();

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
        public PrinterStatusClass PrinterStatus { get; set; }

        /// <summary>
        /// Printer Capabilities
        /// </summary>
        public PrinterCapabilitiesClass PrinterCapabilities { get; set; } = new PrinterCapabilitiesClass
                                            (
                                                Types: PrinterCapabilitiesClass.TypeEnum.Receipt,
                                                Resolutions: PrinterCapabilitiesClass.ResolutionEnum.Medium,
                                                ReadForms: PrinterCapabilitiesClass.ReadFormEnum.NotSupported,
                                                WriteForms: PrinterCapabilitiesClass.WriteFormEnum.NotSupported,
                                                Extents: PrinterCapabilitiesClass.ExtentEnum.NotSupported,
                                                Controls: PrinterCapabilitiesClass.ControlEnum.Flush | PrinterCapabilitiesClass.ControlEnum.Eject | PrinterCapabilitiesClass.ControlEnum.Cut | PrinterCapabilitiesClass.ControlEnum.ClearBuffer,
                                                MaxMediaOnStacker: 0,
                                                AcceptMedia: false,
                                                MultiPage: false,
                                                PaperSources: PrinterCapabilitiesClass.PaperSourceEnum.Upper,
                                                MediaTaken: true,
                                                RetractBins: 0,
                                                MaxRetract: null,
                                                ImageTypes: PrinterCapabilitiesClass.ImageTypeEnum.NotSupported,
                                                FrontImageColorFormats: PrinterCapabilitiesClass.FrontImageColorFormatEnum.NotSupported,
                                                BackImageColorFormats: PrinterCapabilitiesClass.BackImageColorFormatEnum.NotSupported,
                                                CodelineFormats: PrinterCapabilitiesClass.CodelineFormatEnum.NotSupported,
                                                ImageSourceTypes: PrinterCapabilitiesClass.ImageSourceTypeEnum.NotSupported,
                                                DispensePaper: false,
                                                OSPrinter: null,
                                                MediaPresented: false,
                                                AutoRetractPeriod: 0,
                                                RetractToTransport: false,
                                                CoercivityTypes: PrinterCapabilitiesClass.CoercivityTypeEnum.NotSupported,
                                                ControlPassbook: PrinterCapabilitiesClass.ControlPassbookEnum.NotSupported,
                                                PrintSides: PrinterCapabilitiesClass.PrintSidesEnum.NotSupported
                                            );

        /// <summary>
        /// This property must added MediaSpec structures to reflect the media supported by the specific device.
        /// At least one element must be added. If the printer has more than one paper supply, more than one structure may be returned.
        /// </summary>
        public List<MediaSpec> MediaSpecs { get; set; } = new()
        {
            new MediaSpec(800, 0)
        };

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
        /// For sample printer: 8 dots per mm
        /// </summary>

        // 1 inch = 2.54cm = 25.4mm = 203.2dots = 2032 / 10
        public int DotsPerInchTopX { get; set; } = 2032;
        public int DotsPerInchBottomX { get; set; } = 10;
        public int DotsPerInchTopY { get; set; } = 2032;
        public int DotsPerInchBottomY { get; set; } = 10;
        public int DotsPerMMTopX { get; set; } = 8;
        public int DotsPerMMBottomX { get; set; } = 1;
        public int DotsPerMMTopY { get; set; } = 8;
        public int DotsPerMMBottomY { get; set; } = 1;
        // Default char is 3mm high by 2mm wide: 24 x 16 dots.
        public int DotsPerRowTop { get; set; } = 24;
        public int DotsPerRowBottom { get; set; } = 1;
        public int DotsPerColumnTop { get; set; } = 16;
        public int DotsPerColumnBottom { get; set; } = 1;
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
                PrinterInterface: new CommonCapabilitiesClass.PrinterInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.ControlMedia,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetCodelineMapping,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetFormList,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetMediaList,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryField,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryForm,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.GetQueryMedia,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.LoadDefinition,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.PrintForm,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.PrintRaw,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SetBlackMarkMode,
                        CommonCapabilitiesClass.PrinterInterfaceClass.CommandEnum.SupplyReplenish,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.DefinitionLoadedEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.FieldErrorEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.FieldWarningEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.MediaTakenEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.NoMediaEvent,
                        CommonCapabilitiesClass.PrinterInterfaceClass.EventEnum.PaperThresholdEvent,
                    }
                ),
                DeviceInformation: new List<CommonCapabilitiesClass.DeviceInformationClass>()
                {
                    new CommonCapabilitiesClass.DeviceInformationClass(
                            ModelName: "Simulator",
                            SerialNumber: "123456-78900001",
                            RevisionNumber: "1.0",
                            ModelDescription: "KAL simualtor",
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

        /// <summary>
        /// Thread for simulate paper taken event to be fired
        /// </summary>
        private void PaperTakenThread()
        {
            Thread.Sleep(5000);

            paperTakenSignal.Release();
        }

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private ILogger Logger { get; }

        private PrinterStatusClass.SupplyStatusClass PaperSupplyStatus { get; set; } = new(PrinterStatusClass.PaperSupplyEnum.Full, PrinterStatusClass.PaperTypeEnum.Single);
        private PrinterStatusClass.BlackMarkModeEnum BlackMarkModeStatus { get; set; } = PrinterStatusClass.BlackMarkModeEnum.Off;
        
        private readonly SemaphoreSlim paperTakenSignal = new(0, 1);
        // Default page size is 10cm = 8 * 10 * 10 dots.
        private int PageSize { get; set; } = 800;
    }
}