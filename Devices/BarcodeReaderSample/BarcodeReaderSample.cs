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
using System.Diagnostics;
using System.Text;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.BarcodeReader;
using XFS4IoTFramework.Common;
using XFS4IoTServer;
using XFS4IoT.Completions;

namespace KAL.XFS4IoTSP.BarcodeReader.Sample
{
    /// <summary>
    /// Sample indipendent BarcodeReaderSample device class to implement
    /// </summary>
    public class BarcodeReaderSample : IBarcodeReaderDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public BarcodeReaderSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(BarcodeReaderSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            BarcodeReaderStatus.ScannerStatus = BarcodeReaderStatusClass.ScannerStatusEnum.Off;
        }

        #region BarcodeReader Interface

        /// <summary>
        /// This command enables the barcode reader.
        /// The barcode reader will scan for barcodes and when it successfully manages to read one or more barcodes the command will complete.
        /// The completion event for this command contains thescanned barcode data.
        /// The device waits for the period of time specified by the property in the ReadRequest.
        /// </summary>
        public async Task<ReadResult> Read(ReadRequest request, CancellationToken cancellation)
        {
            BarcodeReaderStatus.ScannerStatus = BarcodeReaderStatusClass.ScannerStatusEnum.On;

            await Task.Delay(3000, cancellation);

            List<ReadResult.ReadBarcodeData> readData = new();
            string data = @"https://www.kal.com/en/kal-atm-news/the-xfs4iot-spec-is-ready-a-huge-moment-for-the-global-atm-industry";
            
            readData.Add(new ReadResult.ReadBarcodeData(ReadResult.SymbologyEnum.QRCode, Encoding.ASCII.GetBytes(data).ToList()));

            BarcodeReaderStatus.ScannerStatus = BarcodeReaderStatusClass.ScannerStatusEnum.Off;

            return new ReadResult(MessagePayload.CompletionCodeEnum.Success,
                                  readData);
        }

        /// <summary>
        /// Perform device reset command.
        /// </summary>
        public async Task<DeviceResult> ResetDevice(CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            BarcodeReaderStatus.ScannerStatus = BarcodeReaderStatusClass.ScannerStatusEnum.Off;

            return new DeviceResult(MessagePayload.CompletionCodeEnum.Success);
        }


        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        public Task RunAsync(CancellationToken cancel)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Stores barcode reader capabilites
        /// </summary>
        public BarcodeReaderCapabilitiesClass BarcodeReaderCapabilities { get; set; } = new BarcodeReaderCapabilitiesClass(false, BarcodeReaderCapabilitiesClass.SymbologiesEnum.CODE39 | 
                                                                                                                                      BarcodeReaderCapabilitiesClass.SymbologiesEnum.CODE128 | 
                                                                                                                                      BarcodeReaderCapabilitiesClass.SymbologiesEnum.QRCode);

        /// <summary>
        /// BarcodeReader Status
        /// </summary>
        public BarcodeReaderStatusClass BarcodeReaderStatus { get; set; } = new BarcodeReaderStatusClass();

        #endregion

        #region Common Interface
        /// <summary>
        /// Stores Commons status
        /// </summary>
        public CommonStatusClass CommonStatus { get; set; } = new CommonStatusClass(Device: CommonStatusClass.DeviceEnum.Online,
                                                                                    DevicePosition: CommonStatusClass.PositionStatusEnum.InPosition,
                                                                                    PowerSaveRecoveryTime: 0,
                                                                                    AntiFraudModule: CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                                                    Exchange: CommonStatusClass.ExchangeEnum.NotSupported,
                                                                                    CommonStatusClass.EndToEndSecurityEnum.NotSupported);

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
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.StatusChangedEvent,
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.ErrorEvent
                    ]
                ),
                BarcodeReaderInterface: new CommonCapabilitiesClass.BarcodeReaderInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.BarcodeReaderInterfaceClass.CommandEnum.Read,
                        CommonCapabilitiesClass.BarcodeReaderInterfaceClass.CommandEnum.Reset,
                    ]
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

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private ILogger Logger { get; }
    }
}