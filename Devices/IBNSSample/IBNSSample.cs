/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2025
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
using XFS4IoTFramework.BanknoteNeutralization;
using XFS4IoTFramework.Common;
using XFS4IoTServer;
using XFS4IoT.Completions;
using XFS4IoTFramework.Storage;

namespace KAL.XFS4IoTSP.IBNS.Sample
{
    /// <summary>
    /// Sample indipendent IBNS device class to implement
    /// </summary>
    public class IBNSSample : IBanknoteNeutralizationDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public IBNSSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(IBNSSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus.Device = CommonStatusClass.DeviceEnum.Online;

            IBNSStatus = new(
                State: State,
                WarningState: WarningState,
                ErrorState: ErrorState,
                SafeDoorState: XFS4IoTFramework.Common.IBNSStatusClass.SafeDoorStateEnum.DoorClosed,
                SafeBoltState: XFS4IoTFramework.Common.IBNSStatusClass.SafeBoltStateEnum.BoltLocked,
                LightState: XFS4IoTFramework.Common.IBNSStatusClass.LightStateEnum.NotDetected,
                TiltState: XFS4IoTFramework.Common.IBNSStatusClass.TiltStateEnum.NotTilted,
                GasState: XFS4IoTFramework.Common.IBNSStatusClass.GasStateEnum.Initializing,
                TemperatureState: XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Healthy,
                SeismicState: XFS4IoTFramework.Common.IBNSStatusClass.SeismicStateEnum.NotSupported);

            foreach (var unit in CashUnitInfo)
            {
                unit.Value.GenericStorageStatus = UnitStorageBase.StatusEnum.Good;
            }
        }

        #region IBNS Interface

        /// <summary>
        /// This operation requests to activate (arming) or deactivates (disarming) the banknote protection. 
        /// The process of arming and disarming the banknote neutralization may be protected by end-to-end security.
        /// This means that the hardware will generate a nonce through GetCommandNonce common interface and
        /// the service application should create a security token that authorizes to set protection.
        /// </summary>
        public async Task<SetProtectionResult> SetProtectionAsync(SetProtectionRequest request, CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            if (request.Protection == SetProtectionRequest.ProtectionEnum.Arm)
            {
                State.Mode = XFS4IoTFramework.Common.IBNSStatusClass.StateClass.ModeEnum.Armed;
            }
            else if (request.Protection == SetProtectionRequest.ProtectionEnum.Disarm)
            {
                State.Mode = XFS4IoTFramework.Common.IBNSStatusClass.StateClass.ModeEnum.Disarmed;
            }
            else
            {
                IBNSStatus.SafeDoorState = XFS4IoTFramework.Common.IBNSStatusClass.SafeDoorStateEnum.Disabled;
                IBNSStatus.SafeBoltState = XFS4IoTFramework.Common.IBNSStatusClass.SafeBoltStateEnum.Disabled;
                IBNSStatus.LightState = XFS4IoTFramework.Common.IBNSStatusClass.LightStateEnum.Disabled;
                IBNSStatus.TiltState = XFS4IoTFramework.Common.IBNSStatusClass.TiltStateEnum.Disabled;
                IBNSStatus.GasState = XFS4IoTFramework.Common.IBNSStatusClass.GasStateEnum.Disabled;
                IBNSStatus.TemperatureState = XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Disabled;
            }

            return new SetProtectionResult(MessageHeader.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This operation requests to activate the neutralization of the banknotes. 
        /// The process of triggering the banknote neutralization may be protected by end-to-end security. 
        /// This means that the hardware will generate a command nonce returned by GetCommandNonce common interface
        /// and the server application should  create a security token that authorizes trigering a neutralization.
        /// </summary>
        public async Task<TriggerNeutralizationResult> TriggerNeutralizationAsync(TriggerNeutralizationRequest request, CancellationToken cancellation)
        {
            await Task.Delay(10);
            return new TriggerNeutralizationResult(MessageHeader.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        public async Task RunAsync(CancellationToken cancel)
        {
            IBNSServiceProvider ibnsProvider = SetServiceProvider as IBNSServiceProvider;
            foreach (var unit in CashUnitInfo)
            {
                ibnsProvider.UpdateStorageStatus(unit.Key, unit.Value.GenericStorageStatus);
            }

            /// Initial status of GAS sensor is initializing and emulate 10 sec to complete initialization.
            await Task.Delay(5000, cancel);
            IBNSStatus.GasState = XFS4IoTFramework.Common.IBNSStatusClass.GasStateEnum.NotDetected;

            for (; ; )
            {
                await sensorSignal.WaitAsync(cancel);
                if (IBNSStatus.TemperatureState != XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Fault &&
                    IBNSStatus.TemperatureState != XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.NotSupported &&
                    IBNSStatus.TemperatureState != XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Disabled)
                {
                    IBNSStatus.TemperatureState = XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.TooHot;
                    CashUnitInfo["unit1"].StorageInfo.StorageStatus.TemperatureState = XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.TooHot;
                    CashUnitInfo["unit1"].StorageInfo.StorageStatus.PowerInfo.PowerInStatus = PowerInfoClass.PoweringStatusEnum.NotPower;
                }
            }
        }

        /// <summary>
        /// IBNS Status
        /// </summary>
        public XFS4IoTFramework.Common.IBNSStatusClass IBNSStatus { get; set; } = null;

        /// <summary>
        /// Internal status objects
        /// </summary>
        private readonly XFS4IoTFramework.Common.IBNSStatusClass.StateClass State = new(
            Mode: XFS4IoTFramework.Common.IBNSStatusClass.StateClass.ModeEnum.Disarmed,
            SubMode: XFS4IoTFramework.Common.IBNSStatusClass.StateClass.SubModeEnum.NotSupported);

        private readonly XFS4IoTFramework.Common.IBNSStatusClass.WarningStateClass WarningState = new();

        private readonly XFS4IoTFramework.Common.IBNSStatusClass.ErrorStateClass ErrorState = new();

        /// <summary>
        /// IBNS Capabilities
        /// </summary>
        public XFS4IoTFramework.Common.IBNSCapabilitiesClass IBNSCapabilities { get; set; } = new XFS4IoTFramework.Common.IBNSCapabilitiesClass(
            Mode: XFS4IoTFramework.Common.IBNSCapabilitiesClass.ModeEnum.Autonomous | XFS4IoTFramework.Common.IBNSCapabilitiesClass.ModeEnum.ClientControlled,
            GasSensor: true,
            LightSensor: true,
            SafeIntrusionDetection: true,
            PhysicalStorageUnitsAccessControl: true);

        #endregion

        #region Storage Interface
        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns></returns>
        public bool GetCardStorageConfiguration(out Dictionary<string, CardUnitStorageConfiguration> newCardUnits) => throw new NotSupportedException($"No card related operation supported in this device.");

        /// <summary>
        /// This method is call after card is moved to the storage. Move or Reset command.
        /// </summary>
        /// <returns>Return true if the device maintains hardware counters for the card units</returns>
        public bool GetCardUnitCounts(out Dictionary<string, CardUnitCount> unitCounts) => throw new NotSupportedException($"No card related operation supported in this device.");

        /// <summary>
        /// Update card unit hardware status by device class. the maintaining status by the framework will be overwritten.
        /// The framework can't handle threshold event if the device class maintains hardware storage status on threshold value is not zero.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card unit status</returns>
        public bool GetCardUnitStatus(out Dictionary<string, CardStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"No card related operation supported in this device.");
        /// <summary>
        /// Update card unit hardware storage status by device class.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card storage status</returns>
        public bool GetCardStorageStatus(out Dictionary<string, CardUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"No card related operation supported in this device.");
        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCardStorageResult> SetCardStorageAsync(SetCardStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"No card related operation supported in this device.");

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
        /// Return cheeck storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCheckStorageConfiguration(out Dictionary<string, CheckUnitStorageConfiguration> newCheckUnits) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCheckUnitCounts(out Dictionary<string, StorageCheckCountClass> unitCounts) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit initial counts maintained by the device class and only this method is called on the start of day
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCheckUnitInitialCounts(out Dictionary<string, StorageCheckCountClass> initialCounts) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");

        /// <summary>
        /// Return check storage status.
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckStorageStatus(out Dictionary<string, CheckUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");

        /// <summary>
        /// Return check unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckUnitStatus(out Dictionary<string, CheckStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");

        /// <summary>
        /// Set new configuration and counters for check units
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCheckStorageResult> SetCheckStorageAsync(SetCheckStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The CardReader service provider doesn't support check related operations.");

        /// <summary>
        /// Return printer storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetPrinterStorageConfiguration(out Dictionary<string, PrinterUnitStorageConfiguration> newPrinterUnits) => throw new NotSupportedException($"The CardReader service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer storage counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetPrinterUnitCounts(out Dictionary<string, PrinterUnitCount> unitCounts) => throw new NotSupportedException($"The CardReader service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer storage status (retract bin, passbook storage).
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterStorageStatus(out Dictionary<string, PrinterUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The CardReader service provider doesn't support printer related operations.");

        /// <summary>
        /// Return printer unit status (retract bin, passbook storage) maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetPrinterUnitStatus(out Dictionary<string, XFS4IoTFramework.Storage.PrinterStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The CardReader service provider doesn't support printer related operations.");

        /// <summary>
        /// Set new configuration and counters for printer storage.
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetPrinterStorageResult> SetPrinterStorageAsync(SetPrinterStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The CardReader service provider doesn't support printer related operations.");

        /// <summary>
        /// Return deposit storage (box or bag) information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetDepositStorageConfiguration(out Dictionary<string, DepositUnitStorageConfiguration> newDepositUnits) => throw new NotSupportedException($"The IBNS service provider doesn't support deposit related operations.");

        /// <summary>
        /// Return deposit storage counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetDepositUnitInfo(out Dictionary<string, DepositUnitInfo> unitCounts) => throw new NotSupportedException($"The IBNS service provider doesn't support deposit related operations.");

        /// <summary>
        /// Set new configuration and counters for deposit storage.
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetPrinterStorageResult> SetDepositStorageAsync(SetDepositStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The IBNS service provider doesn't support deposit related operations.");


        /// <summary>
        /// Return IBNS storage (retract bin, passbook storage) information for current configuration and capabilities on the startup.
        /// Status object is a reference to report status changes.
        /// </summary>
        /// <returns>Return true if the storage configuration or capabilities are changed, otherwise false</returns>
        public bool GetIBNSStorageInfo(out Dictionary<string, IBNSStorageInfo> newIBNSUnits)
        {
            newIBNSUnits = [];
            foreach (var unit in CashUnitInfo)
            {
                newIBNSUnits.Add(unit.Key, unit.Value.StorageInfo);
            }
            return true;
        }

        private sealed class CashUnitInfoClass(
            IBNSStorageInfo storageInfo, 
            UnitStorageBase.StatusEnum storageStatus = UnitStorageBase.StatusEnum.NotConfigured)
        {
            public UnitStorageBase.StatusEnum GenericStorageStatus { get; set; } = storageStatus;

            public IBNSStorageInfo StorageInfo { get; init; } = storageInfo;
        }


        private Dictionary<string, CashUnitInfoClass> CashUnitInfo { get; } = new()
        {
            { 
                "unit1", 
                new(
                    storageInfo: new(
                        StorageConfiguration: new(
                            PositionName: "top",
                            Capacity: 2500,
                            SerialNumber: "1234567890-1"),
                        StorageStatus: new(
                            Identifier: "ibns1",
                            StorageUnitIdentifier: null,
                            Protection: XFS4IoTFramework.Storage.IBNSStatusClass.ProtectionEnum.Armed,
                            Warning: XFS4IoTFramework.Storage.IBNSStatusClass.WarningEnum.CassetteRunsAutonomously,
                            PowerInfo: new(
                                PowerInStatus: PowerInfoClass.PoweringStatusEnum.Powering,
                                PowerOutStatus: PowerInfoClass.PoweringStatusEnum.NotPower,
                                BatteryStatus: PowerInfoClass.BatteryStatusEnum.Operational,
                                BatteryChargingStatus: PowerInfoClass.BatteryChargingStatusEnum.NotCharging),
                            TemperatureState: XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Healthy)
                        ),
                    storageStatus: UnitStorageBase.StatusEnum.Good
                    )
            },
            {
                "unit2", 
                new(
                    storageInfo: new(
                        StorageConfiguration: new(
                            PositionName: "second top",
                            Capacity: 2500,
                            SerialNumber: "1234567890-2"),
                        StorageStatus: new(
                            "ibns2",
                            StorageUnitIdentifier: null,
                            Protection: XFS4IoTFramework.Storage.IBNSStatusClass.ProtectionEnum.Armed,
                            Warning: XFS4IoTFramework.Storage.IBNSStatusClass.WarningEnum.CassetteRunsAutonomously,
                            PowerInfo: new(
                                PowerInStatus: PowerInfoClass.PoweringStatusEnum.Powering,
                                PowerOutStatus: PowerInfoClass.PoweringStatusEnum.NotPower,
                                BatteryStatus: PowerInfoClass.BatteryStatusEnum.Operational,
                                BatteryChargingStatus: PowerInfoClass.BatteryChargingStatusEnum.NotCharging),
                            TemperatureState: XFS4IoTFramework.Common.IBNSStatusClass.TemperatureStateEnum.Healthy)
                        ),
                    storageStatus: UnitStorageBase.StatusEnum.Good
                    )
            }
        };
        
        #endregion

        #region Common Interface
        /// <summary>
        /// Stores Commons status
        /// </summary>
        public CommonStatusClass CommonStatus { get; set; } = 
            new CommonStatusClass(
                Device: CommonStatusClass.DeviceEnum.Offline,
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
                BanknoteNeutralizationInterface: new CommonCapabilitiesClass.BanknoteNeutralizationInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.BanknoteNeutralizationInterfaceClass.CommandEnum.SetProtection,
                        CommonCapabilitiesClass.BanknoteNeutralizationInterfaceClass.CommandEnum.TriggerNeutralization,
                    ],
                    Events:
                    [ ]
                ),
                StorageInterface: new CommonCapabilitiesClass.StorageInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.GetStorage,
                    ],
                    Events:
                    [
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
                AntiFraudModule: false);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();

        #endregion 

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private ILogger Logger { get; }

        private readonly SemaphoreSlim sensorSignal = new(0, 1);
    }
}