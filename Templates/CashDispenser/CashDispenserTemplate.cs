/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.CashDispenser;
using XFS4IoTFramework.CashManagement;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Storage;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.CashDispenser;
using XFS4IoT.CashDispenser.Completions;
using XFS4IoT.CashManagement.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace CashDispenser.CashDispenserTemplate
{
    /// <summary>
    /// Sample CashDispenser device class to implement
    /// </summary>
    public class CashDispenserTemplate : ICashManagementDevice, ICashDispenserDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling ItemsTakenEvent after cash is presented and taken by customer.
        /// </summary>
        /// <returns></returns>
        public Task RunAsync(CancellationToken Token)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public CashDispenserTemplate(XFS4IoT.ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CashDispenserTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.Inactive,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            CashDispenserStatus = new CashDispenserStatusClass(CashDispenserStatusClass.IntermediateStackerEnum.Empty,
                                                               new()
                                                               {
                                                                   { CashManagementCapabilitiesClass.OutputPositionEnum.Center, positionStatus },
                                                                   { CashManagementCapabilitiesClass.OutputPositionEnum.Default, positionStatus },
                                                               });

            CashManagementStatus = new CashManagementStatusClass(CashManagementStatusClass.DispenserEnum.Ok,
                                                                 CashManagementStatusClass.AcceptorEnum.NotSupported);

        }

        #region CashDispenser Interface
        public Task<DispenseResult> DispenseAsync(DispenseCommandEvents events, DispenseRequest dispenseInfo, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }

        public Task<PresentCashResult> PresentCashAsync(PresentCashCommandEvents events, PresentCashRequest presentInfo, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }

        public Task<RejectResult> RejectAsync(RejectCommandEvents events, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is used to test cash units following replenishment.
        /// All physical cash units which are testable (i.e. that have a status of ok or low and no application lock in the the physical cash unit) are tested.
        /// If the hardware is able to do so tests are continued even if an error occurs while testing one of the cash units. 
        /// The method completes with success if the device successfully manages to test all of the testable cash units regardless of the outcome of the test. 
        /// This is the case if all testable cash units could be tested and a dispense was possible from at least one of the cash units.
        /// </summary>
        public Task<TestCashUnitsResult> TestCashUnitsAsync(TestCashUnitsCommandEvents events, TestCashUnitsRequest testCashUnitsInfo, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }

        /// <summary>
        /// CountAsync
        /// Perform count operation to empty the specified physical cash unit(s). 
        /// All items dispensed from the cash unit are counted and moved to the specified output location.
        /// </summary>
        public Task<CountResult> CountAsync(CountCommandEvents events, CountRequest countInfo, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }

        /// <summary>
        /// PrepareDispenseAsync
        /// On some hardware it can take a significant amount of time for the dispenser to get ready to dispense media. 
        /// On this type of hardware the this method can be used to improve transaction performance.
        /// </summary>
        public Task<PrepareDispenseResult> PrepareDispenseAsync(PrepareDispenseRequest prepareDispenseInfo, CancellationToken cancellation)
		{
            throw new NotImplementedException();
        }


        /// <summary>
        /// GetPresentStatus
        /// This method returns the status of the most recent attempt to dispense and/or present items to the customer from a specified output position.
        /// Throw NotImplementedException if the device specific class doesn't support to manage present status.
        /// </summary>
        public CashDispenserPresentStatus GetPresentStatus(CashManagementCapabilitiesClass.OutputPositionEnum position)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CashDispenser Status
        /// </summary>
        public CashDispenserStatusClass CashDispenserStatus { get; set; }

        /// <summary>
        /// CashDispenser Capabilities
        /// </summary>
        public CashDispenserCapabilitiesClass CashDispenserCapabilities { get; set; } = new(
                Type: CashManagementCapabilitiesClass.TypeEnum.SelfServiceBill,
                MaxDispenseItems: 200,
                ShutterControl: false,
                RetractAreas: CashManagementCapabilitiesClass.RetractAreaEnum.Retract,
                RetractTransportActions: CashManagementCapabilitiesClass.RetractTransportActionEnum.Retract,
                RetractStackerActions: CashManagementCapabilitiesClass.RetractStackerActionEnum.Retract,
                IntermediateStacker: false,
                ItemsTakenSensor: false,
                OutputPositions: CashManagementCapabilitiesClass.OutputPositionEnum.Center | CashManagementCapabilitiesClass.OutputPositionEnum.Default,
                MoveItems: CashDispenserCapabilitiesClass.MoveItemEnum.ToCashUnit | CashDispenserCapabilitiesClass.MoveItemEnum.ToTransport | CashDispenserCapabilitiesClass.MoveItemEnum.ToStacker);

        #endregion 

        #region CashManagement Interface
        /// <summary>
        /// This method will retract items which may have been in customer access from an output position or from internal areas within the CashDispenser. 
        /// Retracted items will be moved to either a retract cash unit, a reject cash unit, item cash units, the transport or the intermediate stacker. 
        /// After the items are retracted the shutter is closed automatically, even if the ShutterControl capability is set to false.
        /// </summary>
        public Task<RetractResult> RetractAsync(RetractCommandEvents events, RetractRequest retractInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// OpenCloseShutterAsync
        /// Perform shutter operation to open or close.
        /// </summary>
        public Task<OpenCloseShutterResult> OpenCloseShutterAsync(OpenCloseShutterRequest shutterInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// ResetDeviceAsync
        /// Perform a hardware reset which will attempt to return the CashDispenser device to a known good state.
        /// </summary>
        public Task<ResetDeviceResult> ResetDeviceAsync(ResetCommandEvents events, ResetDeviceRequest resetDeviceInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method will cause a vendor dependent sequence of hardware events which will calibrate one or more physical cash units associated with a logical cash unit.
        /// </summary>
        public Task<CalibrateCashUnitResult> CalibrateCashUnitAsync(CalibrateCashUnitCommandEvents events,
                                                                    CalibrateCashUnitRequest calibrationInfo,
                                                                    CancellationToken cancellation) => throw new NotSupportedException($"Calibration commans is not supported.");

        /// <summary>
        /// This command only applies to Teller devices. It allows the application to obtain counts for each currency assigned to the teller.
        /// These counts represent the total amount of currency dispensed by the teller in all transactions.
        /// This command also enables the application to obtain the position assigned to each teller. The teller information is persistent.
        /// </summary>
        /// <returns></returns>
        public Task<GetTellerInfoResult> GetTellerInfoAsync(GetTellerInfoRequest request,
                                                            CancellationToken cancellation) => throw new NotSupportedException($"Teller operation is not supported.");

        /// <summary>
        /// This command allows the application to initialize counts for each currency assigned to the teller.The values set by this command
        /// are persistent.This command only applies to Teller ATMs.
        /// </summary>
        /// <returns></returns>
        public Task<SetTellerInfoResult> SetTellerInfoAsync(SetTellerInfoRequest request,
                                                            CancellationToken cancellation) => throw new NotSupportedException($"Teller operation is not supported.");

        /// <summary>
        /// This command is used to get information about detected items. It can be used to get information about individual items,
        /// all items of a certain classification, or all items that have information available.This information is available from
        /// the point where the first CashManagement.InfoAvailableEvent is generated until a
        /// transaction or replenishment command is executed including the following:
        ///
        /// CashManagement.Retract
        /// CashManagement.Reset
        /// CashManagement.OpenShutter
        /// CashManagement.CloseShutter
        /// CashManagement.CalibrateCashUnit
        /// CashDispenser.Dispense
        /// CashDispenser.Present
        /// CashDispenser.Reject
        /// CashDispenser.Count
        /// CashDispenser.TestCashUnits
        /// Storage.StartExchange
        /// Storage.EndExchange
        /// 
        /// In addition, since the item information is not cumulative and can be replaced by any command that can move notes, it is
        /// recommended that applications that are interested in the available information should query for it following the
        /// CashManagement.InfoAvailableEvent* but before any other command is executed.
        /// </summary>
        public GetItemInfoResult GetItemInfoInfo(GetItemInfoRequest request) => new(MessagePayload.CompletionCodeEnum.UnsupportedCommand);

        /// <summary>
        /// CashManagement Status
        /// </summary>
        public CashManagementStatusClass CashManagementStatus { get; set; }

        /// <summary>
        /// CashManagement Capabilities
        /// </summary>
        public CashManagementCapabilitiesClass CashManagementCapabilities { get; set; } = new CashManagementCapabilitiesClass(
            Positions: CashManagementCapabilitiesClass.PositionEnum.OutCenter | CashManagementCapabilitiesClass.PositionEnum.OutDefault,
            ShutterControl: false,
            RetractAreas: CashManagementCapabilitiesClass.RetractAreaEnum.Retract,
            RetractTransportActions: CashManagementCapabilitiesClass.RetractTransportActionEnum.Retract,
            RetractStackerActions: CashManagementCapabilitiesClass.RetractStackerActionEnum.Retract,
            ExchangeTypes: CashManagementCapabilitiesClass.ExchangeTypesEnum.ByHand,
            ItemInfoTypes: CashManagementCapabilitiesClass.ItemInfoTypesEnum.SerialNumber,
            CashBox: false,
            ClassificationList: false,
            AllBanknoteItems: AllBanknoteIDs
            );
        #endregion

        #region Storage Interface
        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCashStorageConfiguration(out Dictionary<string, CashUnitStorageConfiguration> newCashUnits)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return return cash unit counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitCounts(out Dictionary<string, CashUnitCountClass> unitCounts)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return cash unit initial counts maintained by the device class and only this method is called on the start of day/
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCashUnitInitialCounts(out Dictionary<string, StorageCashCountClass> initialCounts)
        {
            initialCounts = null;
            return false;
        }

        /// <summary>
        /// Return return cash storage status
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashStorageStatus(out Dictionary<string, CashUnitStorage.StatusEnum> storageStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return return cash unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashUnitStatus(out Dictionary<string, CashStatusClass.ReplenishmentStatusEnum> unitStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return accuracy of counts. This method is called if the device class supports feature for count accuray
        /// </summary>
        public void GetCashUnitAccuray(string storageId, out CashStatusClass.AccuracyEnum unitAccuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation)
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
        public bool GetCardStorageConfiguration(out Dictionary<string, CardUnitStorageConfiguration> newCardUnits) => throw new NotSupportedException($"The CashDispenser service provider doesn't support card related operations.");

        /// <summary>
        /// This method is call after card is moved to the storage. Move or Reset command.
        /// </summary>
        /// <returns>Return true if the device maintains hardware counters for the card units</returns>
        public bool GetCardUnitCounts(out Dictionary<string, CardUnitCount> unitCounts) => throw new NotSupportedException($"The CashDispenser service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware status by device class. the maintaining status by the framework will be overwritten.
        /// The framework can't handle threshold event if the device class maintains hardware storage status on threshold value is not zero.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card unit status</returns>
        public bool GetCardUnitStatus(out Dictionary<string, CardStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The CashDispenser service provider doesn't support card related operations.");

        /// <summary>
        /// Update card unit hardware storage status by device class.
        /// </summary>
        /// <returns>Return true if the device maintains hardware card storage status</returns>
        public bool GetCardStorageStatus(out Dictionary<string, CardUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The CashDispenser service provider doesn't support card related operations.");

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCardStorageResult> SetCardStorageAsync(SetCardStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The CashDispenser service provider doesn't support card related operations.");

        /// <summary>
        /// Return cheeck storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCheckStorageConfiguration(out Dictionary<string, CheckUnitStorageConfiguration> newCheckUnits) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit counts maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCheckUnitCounts(out Dictionary<string, StorageCheckCountClass> unitCounts) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");
        /// <summary>
        /// Return check unit initial counts maintained by the device class and only this method is called on the start of day
        /// </summary>
        /// <returns>Return true if the device class maintained initial counts, otherwise false</returns>
        public bool GetCheckUnitInitialCounts(out Dictionary<string, StorageCheckCountClass> initialCounts) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");

        /// <summary>
        /// Return check storage status.
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckStorageStatus(out Dictionary<string, CheckUnitStorage.StatusEnum> storageStatus) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");

        /// <summary>
        /// Return check unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCheckUnitStatus(out Dictionary<string, CheckStatusClass.ReplenishmentStatusEnum> unitStatus) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");

        /// <summary>
        /// Set new configuration and counters for check units
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public Task<SetCheckStorageResult> SetCheckStorageAsync(SetCheckStorageRequest request, CancellationToken cancellation) => throw new NotSupportedException($"The CashDispenser service provider doesn't support check related operations.");

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
                CashDispenserInterface: new CommonCapabilitiesClass.CashDispenserInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.Denominate,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.Dispense,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.Present,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.Reject,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.GetPresentStatus,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.Count,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.GetMixTypes,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.CommandEnum.GetMixTable,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.EventEnum.StartDispenseEvent,
                        CommonCapabilitiesClass.CashDispenserInterfaceClass.EventEnum.IncompleteDispenseEvent,
                    ]
                ),
                CashManagementInterface: new CommonCapabilitiesClass.CashManagementInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.Retract,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.OpenShutter,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.CloseShutter,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.CalibrateCashUnit,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.GetTellerInfo,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.SetTellerInfo,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ShutterStatusChangedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.NoteErrorEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsTakenEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsPresentedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsInsertedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.IncompleteRetractEvent,
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
                    new(
                            ModelName: "ModelName",
                            SerialNumber: "SerialNumber",
                            RevisionNumber: "RevisionNumber",
                            ModelDescription: "ModelDescription",
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
                EndToEndSecurity: null);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce()
        {
            throw new NotImplementedException();
        }
        public Task<DeviceResult> ClearCommandNonce()
        {
            throw new NotImplementedException();
        }
        #endregion

        private CashManagementStatusClass.PositionStatusClass positionStatus = new(CashManagementStatusClass.ShutterEnum.Closed,
                                                                                   CashManagementStatusClass.PositionStatusEnum.Empty,
                                                                                   CashManagementStatusClass.TransportEnum.Ok,
                                                                                   CashManagementStatusClass.TransportStatusEnum.Empty);
         
        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private readonly Dictionary<string, CashUnitCountClass> LastDispenseResult = new();

        private Dictionary<string, CashStorageInfo> CashUnitInfo { get; } = new();


        private sealed class CashStorageInfo
        {
            public CashStorageInfo( CashUnitStorageConfiguration CashUnitStorageConfig) 
            {
                throw new NotImplementedException();
            }

            public CashUnitStorage.StatusEnum StorageStatus { get; set; }

            public CashStatusClass.ReplenishmentStatusEnum UnitStatus { get; set; }

            public CashUnitCountClass UnitCount { get; init; }

            public CashUnitStorageConfiguration CashUnitStorageConfig { get; init; }
        }

        private static readonly Dictionary<string, CashManagementCapabilitiesClass.BanknoteItem> AllBanknoteIDs = new()
        {
            {
                "typeEUR5",
                new CashManagementCapabilitiesClass.BanknoteItem(1, "EUR", 5.0, 1, true)
            },
            {
                "typeEUR10",
                new CashManagementCapabilitiesClass.BanknoteItem(2, "EUR", 10.0, 1, true)
            },
            {
                "typeEUR20",
                new CashManagementCapabilitiesClass.BanknoteItem(3, "EUR", 20.0, 1, true)
            },
            {
                "typeEUR50",
                new CashManagementCapabilitiesClass.BanknoteItem(4, "EUR", 50.0, 1, true)
            },
            {
                "typeEUR100",
                new CashManagementCapabilitiesClass.BanknoteItem(5, "EUR", 100.0, 1, true)
            },
            {
                "typeEUR200",
                new CashManagementCapabilitiesClass.BanknoteItem(5, "EUR", 200.0, 1, true)
            },
            {
                "typeEUR500",
                new CashManagementCapabilitiesClass.BanknoteItem(6, "EUR", 500.0, 1, true)
            }
        };

        private XFS4IoT.ILogger Logger { get; }
    }
}