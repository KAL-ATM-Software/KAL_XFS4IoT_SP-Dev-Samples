/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.Dispenser;
using XFS4IoTFramework.CashManagement;
using XFS4IoTFramework.Common;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.Dispenser.Events;
using XFS4IoT.Dispenser;
using XFS4IoT.Dispenser.Commands;
using XFS4IoT.Dispenser.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.CashDispenser.Sample
{
    /// <summary>
    /// Sample CashDispenser device class to implement
    /// </summary>
    public class CashDispenserSample : ICashManagementDevice, IDispenserDevice, ICommonDevice
    {
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling ItemsTakenEvent after card is presented and taken by customer.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            for (; ; )
            {
                // Check if presented cash is taken. When cash is taken, set output position empty, shutter closed and fire ItemsTakenEvent
                await cashTakenSignal?.WaitAsync();
                OutputPositionStatus = OutposClass.PositionStatusEnum.Empty;
                ShutterStatus = OutposClass.ShutterEnum.Closed;
                DispenserServiceProvider cashDispenserServiceProvider = SetServiceProvider as DispenserServiceProvider;
                await cashDispenserServiceProvider.IsNotNull().ItemsTakenEvent(new ItemsTakenEvent.PayloadData(ItemsTakenEvent.PayloadData.PositionEnum.Center));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public CashDispenserSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CashDispenserSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;
        }

        /// <summary>
        /// This command is used to obtain the overall status of any XFS4IoT service. The status includes common status information and can include zero or more interface specific status objects, depending on the implemented interfaces of the service. It may also return vendor-specific status information.
        /// </summary>
        public StatusCompletion.PayloadData Status() 
        {
            StatusPropertiesClass common = new(
                Device: DeviceStatus,
                Extra: new List<string>(),
                GuideLights: new List<StatusPropertiesClass.GuideLightsClass>(){ new StatusPropertiesClass.GuideLightsClass(
                    StatusPropertiesClass.GuideLightsClass.FlashRateEnum.Off,
                    StatusPropertiesClass.GuideLightsClass.ColorEnum.Green,
                    StatusPropertiesClass.GuideLightsClass.DirectionEnum.Off) },
                DevicePosition: PositionStatusEnum.Inposition,
                PowerSaveRecoveryTime: 0,
                AntiFraudModule: StatusPropertiesClass.AntiFraudModuleEnum.Ok);

            List<OutposClass> Positions = new List<OutposClass>();
            
            OutposClass OutPos = new(Position: OutposClass.PositionEnum.Center,
                                     Shutter: ShutterStatus,
                                     PositionStatus: OutputPositionStatus,
                                     Transport: Transport,
                                     TransportStatus: TransportStatus,
                                     JammedShutterPosition: OutposClass.JammedShutterPositionEnum.NotSupported);
            Positions.Add(OutPos);

            XFS4IoT.Dispenser.StatusClass cashDispenser = new(
                                                              IntermediateStacker: StackerStatus,
                                                              Positions: Positions);

            XFS4IoT.CashManagement.StatusClass cashManagement = new(
                                                                    SafeDoor: SafeDoorStatus,
                                                                    Dispenser: DispenserStatus);

            return new StatusCompletion.PayloadData(MessagePayload.CompletionCodeEnum.Success,
                                                    null,
                                                    common,
                                                    null,
                                                    null,
                                                    cashDispenser,
                                                    cashManagement);
        }

        public CapabilitiesCompletion.PayloadData Capabilities()
		{
            List<CapabilityPropertiesClass.GuideLightsClass> guideLights = new()
            {
                new(new CapabilityPropertiesClass.GuideLightsClass.FlashRateClass(true, true, true, true),
                new CapabilityPropertiesClass.GuideLightsClass.ColorClass(true, true, true, true, true, true, true),
                new CapabilityPropertiesClass.GuideLightsClass.DirectionClass(false, false))
            };

            CapabilityPropertiesClass common = new(
                ServiceVersion: "1.0",
                DeviceInformation: new List<DeviceInformationClass>() { new DeviceInformationClass(
                    ModelName: "Simulator",
                    SerialNumber: "123456-78900001",
                    RevisionNumber: "1.0",
                    ModelDescription: "KAL simualtor",
                    Firmware: new List<FirmwareClass>() {new FirmwareClass(
                                                                           FirmwareName: "XFS4 SP",
                                                                           FirmwareVersion: "1.0",
                                                                           HardwareRevision: "1.0") },
                    Software: new List<SoftwareClass>(){ new SoftwareClass(
                                                                           SoftwareName: "XFS4 SP",
                                                                           SoftwareVersion: "1.0") }) },
                VendorModeIformation: new VendorModeInfoClass(
                    AllowOpenSessions: true,
                    AllowedExecuteCommands: new List<string>()
                    {
                        "CashDispenser.Dispense",
                        "CashDispenser.Reset",
                        "CashDispenser.PresentCash",
                        "CashDispenser.Reject",
                        "CashDispenser.Retract",
                        "CashDispenser.OpenShutter",
                        "CashDispenser.CloseShutter",
                        "CashDispenser.TestCashUnits",
                        "CashDispenser.Count",
                    }),
                Extra: new List<string>(),
                GuideLights: guideLights,
                PowerSaveControl: false,
                AntiFraudModule: false,
                SynchronizableCommands: new List<string>(),
                EndToEndSecurity: false,
                HardwareSecurityElement: false,
                ResponseSecurityEnabled: false);

            XFS4IoT.Dispenser.CapabilitiesClass cashDispenser = new(
                Type: XFS4IoT.Dispenser.CapabilitiesClass.TypeEnum.SelfServiceBill,
                MaxDispenseItems: 200,
                Shutter: true,
                ShutterControl: false,
                RetractAreas: new XFS4IoT.Dispenser.CapabilitiesClass.RetractAreasClass(true, true, true, true, true),
                RetractTransportActions: new XFS4IoT.Dispenser.CapabilitiesClass.RetractTransportActionsClass(true, true, true, true),
                RetractStackerActions:  new XFS4IoT.Dispenser.CapabilitiesClass.RetractStackerActionsClass(true, true, true, true),
                IntermediateStacker: true,
                ItemsTakenSensor: true,
                Positions: new XFS4IoT.Dispenser.CapabilitiesClass.PositionsClass(false, false, true),
                MoveItems: new XFS4IoT.Dispenser.CapabilitiesClass.MoveItemsClass(true, false, false, true),
                PrepareDispense: false);

            XFS4IoT.CashManagement.CapabilitiesClass cashManagement = new(
                SafeDoor: true,
                CashBox: null,
                ExchangeType: new(true));

            List<InterfaceClass> interfaces = new()
            {
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.Common,
                    Commands: new List<string>()
                    {
                        "Common.Status",
                        "Common.Capabilities"
                    },
                    Events: new List<string>(),
                    MaximumRequests: 1000,
                    AuthenticationRequired: new List<string>()),
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.CashDispenser,
                    Commands: new List<string>
                    {
                        "CashDispenser.Dispense",
                        "CashDispenser.Reset",
                        "CashDispenser.PresentCash",
                        "CashDispenser.Reject",
                        "CashDispenser.Retract",
                        "CashDispenser.OpenShutter",
                        "CashDispenser.CloseShutter",
                        "CashDispenser.TestCashUnits",
                        "CashDispenser.Count",
                    },
                    Events: new List<string>
                    {
                        "CashDispenser.CashUnitErrorEvent",
                        "CashDispenser.NoteErrorEvent",
                    },
                    MaximumRequests: 1000,
                    AuthenticationRequired: new List<string>()),
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.CashManagement,
                    Commands: new List<string>()
                    {
                        "CashManagement.GetCashUnitStatus",
                        "CashManagement.SetCashUnitInfo",
                        "CashManagement.UnlockSafe",
                        "CashManagement.InitiateExchange",
                        "CashManagement.CompleteExchange",
                        "CashManagement.CalibrateCashUnit",
                    },
                    Events: new List<string>()
                    {
                        "CashManagement.CashUnitErrorEvent",
                        "CashManagement.CashUnitErrorEvent",
                        "CashManagement.NoteErrorEvent",
                    },
                    MaximumRequests: 1000,
                    AuthenticationRequired: new List<string>())
            };

            return new CapabilitiesCompletion.PayloadData(MessagePayload.CompletionCodeEnum.Success,
                                                          null,
                                                          interfaces,
                                                          common,
                                                          null, null,
                                                          cashDispenser,
                                                          cashManagement);
        }

        public async Task<DispenseResult> DispenseAsync(IDispenseEvents events, DispenseRequest dispenseInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);
            
            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.NotEmpty;

            if (dispenseInfo.Values is null ||
                dispenseInfo.Values.Count == 0)
            {
                return new DispenseResult(MessagePayload.CompletionCodeEnum.Success,
                                          $"Empty denominate value received from the framework.",
                                          DispenseCompletion.PayloadData.ErrorCodeEnum.NotDispensable);
            }

            foreach (var item in dispenseInfo.Values)
            {
                ItemMovement movement = new(item.Value); // set dispensed count. If necessary, need to set reject count too
                if (LastDispenseResult.ContainsKey(item.Key))
                    LastDispenseResult[item.Key].DispensedCount += item.Value;
                else
                    LastDispenseResult.Add(item.Key, movement);
            }

            return new DispenseResult(MessagePayload.CompletionCodeEnum.Success, dispenseInfo.Values, LastDispenseResult);
        }

        public async Task<PresentCashResult> PresentCashAsync(IPresentEvents events, PresentCashRequest presentInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if (StackerStatus == XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty || LastDispenseResult.Count == 0)
			{
                return new PresentCashResult(MessagePayload.CompletionCodeEnum.Success, 
                                             "No cash to present", 
                                             PresentCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            // When cash is presented successfully, set StackerStatus, OutputpoistionStatus and shutter status
            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutposClass.PositionStatusEnum.NotEmpty;
            ShutterStatus = OutposClass.ShutterEnum.Open;

            LastPresentResult.Clear();
            foreach (var item in LastDispenseResult)
            {
                ItemMovement movement = new(null, item.Value.DispensedCount); // set presented count.
                LastPresentResult.Add(item.Key, movement);
            }

            LastDispenseResult.Clear(); // Dispensed cash is now presented

            return new PresentCashResult(MessagePayload.CompletionCodeEnum.Success, 0, LastPresentResult);
        }

        public async Task<RejectResult> RejectAsync(IRejectEvents events, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if ((StackerStatus == XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty && OutputPositionStatus == OutposClass.PositionStatusEnum.Empty) || LastDispenseResult.Count == 0)
            {
                return new RejectResult(MessagePayload.CompletionCodeEnum.Success,
                                             "No cash to reject",
                                             RejectCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutposClass.PositionStatusEnum.Empty;
            ShutterStatus = OutposClass.ShutterEnum.Closed;

            Dictionary<string, ItemMovement> ItemMovementResult = new(LastDispenseResult);
            LastDispenseResult.Clear();

            return new RejectResult(MessagePayload.CompletionCodeEnum.Success, ItemMovementResult);
        }

        /// <summary>
        /// This method will retract items which may have been in customer access from an output position or from internal areas within the CashDispenser. 
        /// Retracted items will be moved to either a retract cash unit, a reject cash unit, item cash units, the transport or the intermediate stacker. 
        /// After the items are retracted the shutter is closed automatically, even if the ShutterControl capability is set to false.
        /// </summary>
        public async Task<RetractResult> RetractAsync(IRetractEvents events, RetractRequest retractInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if ((StackerStatus == XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty && OutputPositionStatus == OutposClass.PositionStatusEnum.Empty) || LastPresentResult.Count == 0)
            {
                return new RetractResult(MessagePayload.CompletionCodeEnum.Success,
                                         "No cash to retract",
                                         RetractCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutposClass.PositionStatusEnum.Empty;
            ShutterStatus = OutposClass.ShutterEnum.Closed;

            List<RetractResult.BankNoteItem> CashMovement = new();

            RetractResult.BankNoteItem NoteItem1 = new("EUR", 10.00, 5, 0);
            CashMovement.Add(NoteItem1);

            RetractResult.BankNoteItem NoteItem2 = new("EUR", 20.00, 8, 0);
            CashMovement.Add(NoteItem2);

            RetractResult.BankNoteItem NoteItem3 = new("", 0.00, 7, 0); // Unkown item
            CashMovement.Add(NoteItem3);

            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutposClass.PositionStatusEnum.Empty;
            ShutterStatus = OutposClass.ShutterEnum.Closed;

            return new RetractResult(MessagePayload.CompletionCodeEnum.Success, CashMovement);
        }

        /// <summary>
        /// OpenCloseShutterAsync
        /// Perform shutter operation to open or close.
        /// </summary>
        public async Task<OpenCloseShutterResult> OpenCloseShutterAsync(OpenCloseShutterRequest shutterInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if (shutterInfo.Action == OpenCloseShutterRequest.ActionEnum.Open)
                ShutterStatus = OutposClass.ShutterEnum.Open;
            if (shutterInfo.Action == OpenCloseShutterRequest.ActionEnum.Close)
                ShutterStatus = OutposClass.ShutterEnum.Closed;

            return new OpenCloseShutterResult(MessagePayload.CompletionCodeEnum.Success);
        }


        /// <summary>
        /// ResetDeviceAsync
        /// Perform a hardware reset which will attempt to return the CashDispenser device to a known good state.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(IResetEvents events, ResetDeviceRequest resetDeviceInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            Dictionary<string, ItemMovement> CashMovement = null;

            if (StackerStatus == XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.NotEmpty ||
                OutputPositionStatus == OutposClass.PositionStatusEnum.NotEmpty ||
                TransportStatus == OutposClass.TransportStatusEnum.NotEmpty)
            {
                OutputPositionStatus = OutposClass.PositionStatusEnum.Empty;
                StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;
                TransportStatus = OutposClass.TransportStatusEnum.Empty;

                if (resetDeviceInfo.Position.OutputPosition != null)
                {
                    OutputPositionStatus = OutposClass.PositionStatusEnum.NotEmpty;
                }
                else if (!string.IsNullOrEmpty(resetDeviceInfo.Position.CashUnit))
                {
                    // Update cash unit count and status: CashUnitCounts, CashUnitStatus
                }
                else
                {
                    switch (resetDeviceInfo.Position.RetractArea.RetractArea)
                    {
                        case CashDispenserCapabilitiesClass.RetractAreaEnum.Stacker:
                            StackerStatus = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.NotEmpty;
                            break;
                        case CashDispenserCapabilitiesClass.RetractAreaEnum.Transport:
                            TransportStatus = OutposClass.TransportStatusEnum.NotEmpty;
                            break;
                        case CashDispenserCapabilitiesClass.RetractAreaEnum.Reject:
                            // Update reject cassette count and status
                            break;
                        case CashDispenserCapabilitiesClass.RetractAreaEnum.Retract:
                            // Update retract cassette count and status
                            break;
                        case CashDispenserCapabilitiesClass.RetractAreaEnum.ItemCassette:
                            // Update cash cassettes count and status
                            break;
                        default:
                            break;
                    }
                }
            }

            Transport = OutposClass.TransportEnum.Ok;
            ShutterStatus = OutposClass.ShutterEnum.Closed;
            
            return new ResetDeviceResult(MessagePayload.CompletionCodeEnum.Success, CashMovement);
        }

        /// <summary>
        /// This method is used to test cash units following replenishment.
        /// All physical cash units which are testable (i.e. that have a status of ok or low and no application lock in the the physical cash unit) are tested.
        /// If the hardware is able to do so tests are continued even if an error occurs while testing one of the cash units. 
        /// The method completes with success if the device successfully manages to test all of the testable cash units regardless of the outcome of the test. 
        /// This is the case if all testable cash units could be tested and a dispense was possible from at least one of the cash units.
        /// </summary>
        public async Task<TestCashUnitsResult> TestCashUnitsAsync(ITestCashUnitsEvents events, TestCashUnitsRequest testCashUnitsInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            // TesCash normally moves dispensed cash to Reject cassette, but can be other supported position
            // If it is reject cassette, dispense one item from each cash unit
            // In the end update count and status of tested cash units and the reject cassette 

            Dictionary<string, ItemMovement> MovementResult = new();
            ItemMovement im = new(1); // dispensed 1 item
            MovementResult.Add("CASS1", im);
            MovementResult.Add("CASS2", im);
            MovementResult.Add("CASS3", im);
            // ....

            return new TestCashUnitsResult(MessagePayload.CompletionCodeEnum.Success, MovementResult);
        }

        /// <summary>
        /// CountAsync
        /// Perform count operation to empty the specified physical cash unit(s). 
        /// All items dispensed from the cash unit are counted and moved to the specified output location.
        /// </summary>
        public async Task<CountResult> CountAsync(ICountEvents events, CountRequest countInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            Dictionary<string, ItemMovement> MovementResult = new();

            if (countInfo.EmptyAll)
			{
                // Empty all cash units
                // Set all cash unit count to 0 and status to empty

                // For example, if 2000 items in each cash unit, the cash movement result will be
                ItemMovement im = new(2000, 0, 0, 0);
                MovementResult.Add("PHP3", im);
                MovementResult.Add("PHP4", im);
                MovementResult.Add("PHP5", im);
                MovementResult.Add("PHP6", im);
            }
            else
			{
                // empty the specified cash unit
                ItemMovement im = new(2000, 0, 0, 0);
                MovementResult.Add(countInfo.PhysicalPositionName, im);
                // Set the physical cassette status to empty
            }

            return new CountResult(MessagePayload.CompletionCodeEnum.Success, MovementResult);
        }

        /// <summary>
        /// PrepareDispenseAsync
        /// On some hardware it can take a significant amount of time for the dispenser to get ready to dispense media. 
        /// On this type of hardware the this method can be used to improve transaction performance.
        /// </summary>
        public async Task<PrepareDispenseResult> PrepareDispenseAsync(PrepareDispenseRequest prepareDispenseInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            return new PrepareDispenseResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand);
		}


        /// <summary>
        /// GetPresentStatus
        /// This method returns the status of the most recent attempt to dispense and/or present items to the customer from a specified output position.
        /// Throw NotImplementedException if the device specific class doesn't support to manage present status.
        /// </summary>
        public PresentStatus GetPresentStatus(CashDispenserCapabilitiesClass.OutputPositionEnum position)
        {
            // If USD 500 was presented
            Dictionary<string, double> Amounts = new();
            Amounts.Add("EUR", 500.00);

            Dictionary<string, int> Values = new();
            Values.Add("PHP3", 2); // USD 50 x 2
            Values.Add("PHP4", 4); // USD 100 x 4

            Denomination Denom = new(Amounts, Values); 
            return new PresentStatus(PresentStatus.PresentStatusEnum.Presented, Denom);
        }


        // CASH MANAGEMENT SP interfaces

        /// <summary>
        /// This method is called when the client application send CashUnitInfo command first time since executable runs or while exchange is in progress.
        /// Return true if the cash unit configuration is being changed since last call, otherwise false
        /// The key representing physical position name associated with the CashUnit structure.
        /// The key name should be unique to identify Physical Cash Unit
        /// </summary>
        public bool GetCashUnitConfiguration(out Dictionary<string, CashUnitConfiguration> CashUnits)
        {
            if (AllBanknoteIDs.Count == 0)
                AllBanknoteIDs = new List<int> { 0x0001, 0x0002, 0x0003, 0x0004 };

            if (CashUnitConfig.Count == 0)
            {
                CashUnitConfiguration reject = new(CashUnit.TypeEnum.RejectCassette,    // Type
                                                   "",  // CurrencyID
                                                   0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "REJECT", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP1",  // PhysicalPositionName
                                                   "REJECT",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.All, // ItemTypes,
                                                   AllBanknoteIDs);
                CashUnitConfig.Add("PHP1", reject);

                CashUnitConfiguration retract = new(CashUnit.TypeEnum.RetractCassette,    // Type
                                                   "",  // CurrencyID
                                                   0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "RETRACT", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP2",  // PhysicalPositionName
                                                   "RETRACT",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.All, // ItemTypes,
                                                   AllBanknoteIDs);
                CashUnitConfig.Add("PHP2", retract);

                CashUnitConfiguration usd10 = new(CashUnit.TypeEnum.BillCassette,    // Type
                                                   "EUR",  // CurrencyID
                                                   10.0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "EUR10", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP3",  // PhysicalPositionName
                                                   "EUR10",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.Individual, // ItemTypes,
                                                   new List<int> { 0x0001 });
                CashUnitConfig.Add("PHP3", usd10);

                CashUnitConfiguration usd20 = new(CashUnit.TypeEnum.BillCassette,    // Type
                                                   "EUR",  // CurrencyID
                                                   20.0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "EUR20", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP4",  // PhysicalPositionName
                                                   "EUR20",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.Individual, // ItemTypes,
                                                   new List<int> { 0x0002 });
                CashUnitConfig.Add("PHP4", usd20);

                CashUnitConfiguration usd50 = new(CashUnit.TypeEnum.BillCassette,    // Type
                                                   "EUR",  // CurrencyID
                                                   50.0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "EUR50", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP5",  // PhysicalPositionName
                                                   "EUR50",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.Individual, // ItemTypes,
                                                   new List<int> { 0x0003 });
                CashUnitConfig.Add("PHP5", usd50);

                CashUnitConfiguration usd100 = new(CashUnit.TypeEnum.BillCassette,    // Type
                                                   "EUR",  // CurrencyID
                                                   100.0,   // Value
                                                   2000,    // Maximum
                                                   false,    // AppLock
                                                   "EUR100", // CashUnitName
                                                   0,   // Minimum
                                                   "PHP6",  // PhysicalPositionName
                                                   "EUR100",    // UnitID
                                                   2000, // MaximumCapacity,
                                                   true, // HardwareSensor,
                                                   CashUnit.ItemTypesEnum.Individual, // ItemTypes,
                                                   new List<int> { 0x0004 });
                CashUnitConfig.Add("PHP6", usd100);
            }

            CashUnits = new(CashUnitConfig);

            return true;
        }

        /// <summary>
        /// This method is called after device operation is completed involving cash movement
        /// returning false if the device doesn't support maintaining counters and framework will maintain counters.
        /// However if the device doesn't support maintaining counters, the counts are not guaranteed.
        /// The key name should be used for the GetCashUnitConfiguration output.
        /// </summary>
        public Dictionary<string, CashUnitAccounting> GetCashUnitAccounting()
        {
            if (CashUnitCounts.Count == 0)
            {
                CashUnitCounts.Add("PHP1", new(0, 0, 0, 0, 0, 0, 0, 0, new List<BankNoteNumber>())); // Reject cassette
                CashUnitCounts.Add("PHP2", new(0, 0, 0, 0, 0, 0, 0, 0, new List<BankNoteNumber>())); // Retract cassette
                CashUnitCounts.Add("PHP3", new(1000, 2000, 1000, 1000, 0, 0, 1000, 0, new List<BankNoteNumber>() { new(0x0001, 1000) })); // USD10 cassette
                CashUnitCounts.Add("PHP4", new(1000, 2000, 1000, 1000, 0, 0, 1000, 0, new List<BankNoteNumber>() { new(0x0002, 1000) })); // USD20 cassette
                CashUnitCounts.Add("PHP5", new(1000, 2000, 1000, 1000, 0, 0, 1000, 0, new List<BankNoteNumber>() { new(0x0003, 1000) })); // USD50 cassette
                CashUnitCounts.Add("PHP6", new(1000, 2000, 1000, 1000, 0, 0, 1000, 0, new List<BankNoteNumber>() { new(0x0004, 1000) })); // USD100 cassette
            }

            return CashUnitCounts;
        }

        /// <summary>
        /// This method is called after device operation is completed involving cash movement
        /// Return false if the device doesn't support handware sensor to detect cash unit status.
        /// The framework will use decide the cash unit status from the counts maintained by the framework.
        /// The key name should be used for the GetCashUnitConfiguration output.
        /// </summary>
        public Dictionary<string, CashUnit.StatusEnum> GetCashUnitStatus()
        {
            if (CashUnitStatus.Count == 0)
            {
                CashUnitStatus.Add("PHP1", CashUnit.StatusEnum.Empty); // Reject cassette
                CashUnitStatus.Add("PHP2", CashUnit.StatusEnum.Empty); // Retract cassette
                CashUnitStatus.Add("PHP3", CashUnit.StatusEnum.Ok); // USD10 cassette
                CashUnitStatus.Add("PHP4", CashUnit.StatusEnum.Ok); // USD20 cassette
                CashUnitStatus.Add("PHP5", CashUnit.StatusEnum.Ok); // USD50 cassette
                CashUnitStatus.Add("PHP6", CashUnit.StatusEnum.Ok); // USD100 cassette
            }

            return CashUnitStatus;
        }

        /// <summary>
        /// This method is used to adjust information about the status and contents of the cash units present in the CashDispenser or CashAcceptor device.
        /// </summary>
        public async Task<SetCashUnitInfoResult> SetCashUnitInfoAsync(ISetCashUnitInfoEvents events,
                                                                      SetCashUnitInfoRequest setCashUnitInfo,
                                                                      CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            CashUnitConfig.Clear();
            CashUnitCounts.Clear();
            AllBanknoteIDs.Clear();
            CashUnitStatus.Clear();

            foreach (var config in setCashUnitInfo.CashUnitConfigurations)
            {
                CashUnitConfig.Add(config.Key, new CashUnitConfiguration(config.Value.Type.Value,
                                                                         config.Value.CurrencyID,
                                                                         config.Value.Value.Value,
                                                                         config.Value.Maximum.Value,
                                                                         config.Value.AppLock.Value,
                                                                         config.Value.CashUnitName,
                                                                         config.Value.Minimum.Value,
                                                                         config.Value.PhysicalPositionName,
                                                                         config.Value.UnitID,
                                                                         config.Value.MaximumCapacity.Value,
                                                                         config.Value.HardwareSensor.Value,
                                                                         config.Value.ItemTypes.Value,
                                                                         config.Value.BanknoteIDs));

                if (config.Value.BanknoteIDs != null && config.Value.BanknoteIDs.Count > 0)
                {
                    foreach (var id in config.Value.BanknoteIDs)
                    {
                        if (!AllBanknoteIDs.Contains(id))
                            AllBanknoteIDs.Add(id);
                    }
                }
            }

            foreach (var count in setCashUnitInfo.CashUnitAccountings)
            {
                CashUnitCounts.Add(count.Key, new CashUnitAccounting(count.Value.LogicalCount.Value,
                                                                     count.Value.InitialCount.Value,
                                                                     count.Value.DispensedCount.Value,
                                                                     count.Value.PresentedCount.Value,
                                                                     count.Value.RetractedCount.Value,
                                                                     count.Value.RejectCount.Value,
                                                                     count.Value.Count.Value,
                                                                     count.Value.CashInCount.Value,
                                                                     count.Value.BankNoteNumberList));


            }

            return new SetCashUnitInfoResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method unlocks the safe door or starts the timedelay count down prior to unlocking the safe door, 
        /// if the device supports it. The command completes when the door is unlocked or the timer has started.
        /// </summary>
        public async Task<UnlockSafeResult> UnlockSafeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Unlock the safe door if it is supported, if door is open after unlock, set SafeDoor status
            // SafeDoorStatus = StatusClass.SafeDoorEnum.DoorOpen;

            return new UnlockSafeResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// InitiateExchange
        /// This method is called when the application initiated cash unit exchange by hand
        /// </summary>
        public async Task<InitiateExchangeResult> InitiateExchangeAsync(IStartExchangeEvents events,
                                                                       InitiateExchangeRequest exchangeInfo,
                                                                       CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // start cash unit exchange

            return new InitiateExchangeResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// InitiateClearRecyclerRequest
        /// This method is called when the application initiated to empty recycler units
        /// </summary>
        public async Task<InitiateExchangeResult> InitiateExchangeClearRecyclerAsync(IStartExchangeEvents events,
                                                                                    InitiateClearRecyclerRequest exchangeInfo,
                                                                                    CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            return new InitiateExchangeResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand, "It is not a recycler");
        }


        /// <summary>
        /// InitiateExchangeDepositIntoAsync
        /// This method is called when the application initiated to filling cash into the cash units via cash-in operation.
        /// Items will be moved from the deposit entrance to the bill cash units.
        /// </summary>
        public async Task<InitiateExchangeResult> InitiateExchangeDepositIntoAsync(IStartExchangeEvents events,
                                                                                   CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            return new InitiateExchangeResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand, "It does not have an accetpor device");
        }

        /// <summary>
        /// CompleteExchangeAsync
        /// This method will end the exchange state
        /// </summary>
        public async Task<CompleteExchangeResult> CompleteExchangeAsync(IEndExchangeEvents events,
                                                                        CompleteExchangeRequest exchangeInfo,
                                                                        CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // If safe door can be locked, lock it here
            // Complete cash unit exchange

            return new CompleteExchangeResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This method will cause a vendor dependent sequence of hardware events which will calibrate one or more physical cash units associated with a logical cash unit.
        /// </summary>
        public async Task<CalibrateCashUnitResult> CalibrateCashUnitAsync(ICalibrateCashUnitEvents events,
                                                                          CalibrateCashUnitRequest calibrationInfo,
                                                                          CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            return new CalibrateCashUnitResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand);
        }

        public Task<PowerSaveControlCompletion.PayloadData> PowerSaveControl(PowerSaveControlCommand.PayloadData payload) => throw new NotImplementedException();
        public Task<SynchronizeCommandCompletion.PayloadData> SynchronizeCommand(SynchronizeCommandCommand.PayloadData payload) => throw new NotImplementedException();
        public Task<SetTransactionStateCompletion.PayloadData> SetTransactionState(SetTransactionStateCommand.PayloadData payload) => throw new NotImplementedException();
        public GetTransactionStateCompletion.PayloadData GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandRandomNumberResult> GetCommandRandomNumber() => throw new NotImplementedException();

        public StatusPropertiesClass.DeviceEnum DeviceStatus { get; private set; } = StatusPropertiesClass.DeviceEnum.Online; 
        public XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum StackerStatus { get; private set; } = XFS4IoT.Dispenser.StatusClass.IntermediateStackerEnum.Empty;

        private XFS4IoT.CashManagement.StatusClass.SafeDoorEnum SafeDoorStatus { get; set; } = XFS4IoT.CashManagement.StatusClass.SafeDoorEnum.DoorClosed;
        private XFS4IoT.CashManagement.StatusClass.DispenserEnum DispenserStatus { get; set; } = XFS4IoT.CashManagement.StatusClass.DispenserEnum.Ok;

        public OutposClass.ShutterEnum ShutterStatus { get; private set; } = OutposClass.ShutterEnum.Closed;
        public OutposClass.PositionStatusEnum OutputPositionStatus { get; private set; } = OutposClass.PositionStatusEnum.Empty;
        public OutposClass.TransportEnum Transport { get; private set; } = OutposClass.TransportEnum.Ok;
        public OutposClass.TransportStatusEnum TransportStatus { get; private set; } = OutposClass.TransportStatusEnum.Empty;


        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private Dictionary<string, ItemMovement> LastDispenseResult = new();
        private Dictionary<string, ItemMovement> LastPresentResult = new();

        private Dictionary<string, CashUnitConfiguration> CashUnitConfig = new();
        private Dictionary<string, CashUnitAccounting> CashUnitCounts = new();
        private Dictionary<string, CashUnit.StatusEnum> CashUnitStatus = new();
        private List<int> AllBanknoteIDs = new();

        private ILogger Logger { get; }

        private readonly SemaphoreSlim cashTakenSignal = new(0, 1);
    }
}