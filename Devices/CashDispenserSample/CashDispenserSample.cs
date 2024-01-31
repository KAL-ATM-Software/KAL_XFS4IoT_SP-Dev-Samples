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

namespace KAL.XFS4IoTSP.CashDispenser.Sample
{
    /// <summary>
    /// Sample CashDispenser device class to implement
    /// </summary>
    public class CashDispenserSample : ICashManagementDevice, ICashDispenserDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling ItemsTakenEvent after cash is presented and taken by customer.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync(CancellationToken cancel)
        {
            CashDispenserServiceProvider cashDispenserServiceProvider = SetServiceProvider as CashDispenserServiceProvider;
            for (; ; )
            {
                // Check if presented cash is taken. When cash is taken, set output position empty, shutter closed and fire ItemsTakenEvent
                await cashTakenSignal?.WaitAsync();
                if (positionStatus.PositionStatus != CashManagementStatusClass.PositionStatusEnum.NotEmpty)
                    continue;
                positionStatus.PositionStatus = CashManagementStatusClass.PositionStatusEnum.Empty;
                positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;
                await cashDispenserServiceProvider.ItemsTakenEvent(CashManagementCapabilitiesClass.PositionEnum.OutCenter);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public CashDispenserSample(XFS4IoT.ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CashDispenserSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.Inactive,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotEnforced);

            CashDispenserStatus = new CashDispenserStatusClass(CashDispenserStatusClass.IntermediateStackerEnum.Empty,
                                                               new()
                                                               {
                                                                   { CashManagementCapabilitiesClass.OutputPositionEnum.Center, positionStatus },
                                                                   { CashManagementCapabilitiesClass.OutputPositionEnum.Default, positionStatus },
                                                               });

            CashManagementStatus = new CashManagementStatusClass(CashManagementStatusClass.DispenserEnum.Ok,
                                                                 CashManagementStatusClass.AcceptorEnum.NotSupported);

                        Firmware = Firmware.GetFirmware(new FirmwareLogger(Logger));
        }

        internal class FirmwareLogger : ILogger
        {
            private readonly XFS4IoT.ILogger Logger;

            public FirmwareLogger(XFS4IoT.ILogger Logger)
            {
                this.Logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            }
            public override void Log(string Message) => this.Logger.Log("Firmware", Message);
        }

        #region CashDispenser Interface
        public async Task<DispenseResult> DispenseAsync(DispenseCommandEvents events, DispenseRequest dispenseInfo, CancellationToken cancellation)
		{
            if (dispenseInfo.E2EToken is null)
                return new DispenseResult(MessagePayload.CompletionCodeEnum.InvalidToken, 
                                          "An end to end security token is required to dispense");

            if (dispenseInfo.Values is null ||
                dispenseInfo.Values.Count == 0)
            {
                return new DispenseResult(MessagePayload.CompletionCodeEnum.Success,
                                          $"Empty denominate value received from the framework.",
                                          DispenseCompletion.PayloadData.ErrorCodeEnum.NotDispensable);
            }

            var currencies = from info in CashUnitInfo
                             from dis in dispenseInfo.Values
                             where info.Key == dis.Key
                             select info.Value.CashUnitStorageConfig.Configuration.Currency;
            if( currencies.Distinct().Count() > 1 )
            {
                return new DispenseResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                          $"Sample dispenser currencly only supports one currency at a time.",
                                          DispenseCompletion.PayloadData.ErrorCodeEnum.NotDispensable);
            }
            string currency = currencies.First();
            
            double totalDouble = (
                             from info in CashUnitInfo
                             from dis in dispenseInfo.Values
                             where info.Key == dis.Key
                             select (info.Value.CashUnitStorageConfig.Configuration.Value * dis.Value)
                             )
                             .Sum();
            
            if( totalDouble > Int32.MaxValue )
                return new DispenseResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                          $"Requested dispense value is too large to handle",
                                          DispenseCompletion.PayloadData.ErrorCodeEnum.NotDispensable);
            
            int total = (Int32)Math.Floor(totalDouble);
            if( totalDouble % 1 != 0 )
                return new DispenseResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                          $"Cannot dispense fractional amounts",
                                          DispenseCompletion.PayloadData.ErrorCodeEnum.NotDispensable);

            // The firmware should check the E2E token to make sure that the dispense has been authorised. 
            // It should then actually do the dispense - the two things need to happen together in the firmware. 
            // It's not sufficient to check the token and _then_ dispense, since an attacker could just skip the 
            // varify and send a dispense command. 
            // (Normally this command should take the dispense details
            // Note that this MUST be async, either directly or through the thread pool. 
            bool dispenseResult = await Task.Run(() =>
            {
                return Firmware.VerifyAndDispense(dispenseInfo.E2EToken, currency, total);
            });
            if (!dispenseResult)
            {
                return new DispenseResult(MessagePayload.CompletionCodeEnum.InvalidToken, dispenseInfo.Values, LastDispenseResult);
            }

            // Record the new status. 
            CashDispenserStatus.IntermediateStacker = CashDispenserStatusClass.IntermediateStackerEnum.NotEmpty;

            foreach (var item in dispenseInfo.Values)
            {
                CashUnitInfo.ContainsKey(item.Key).IsTrue($"Invalid cash unit ID supplied by the framework.");

                string noteId = CashUnitInfo[item.Key].CashUnitStorageConfig.Configuration.BanknoteItems[0];
                if (LastDispenseResult.ContainsKey(item.Key))
                {
                    if (LastDispenseResult[item.Key].StorageCashOutCount.Stacked.ItemCounts.ContainsKey(noteId))
                    {
                        LastDispenseResult[item.Key].StorageCashOutCount.Stacked.ItemCounts[noteId].Fit += item.Value;
                    }
                }
                else
                {
                    StorageCashOutCountClass stacked = new();
                    stacked.Stacked = new StorageCashCountClass(0, new Dictionary<string, CashItemCountClass>()
                    {
                        {
                            noteId,
                            new CashItemCountClass(item.Value, 0, 0, 0, 0)
                        }
                    });

                    LastDispenseResult.Add(item.Key, new CashUnitCountClass(stacked, null, -1 *stacked.Stacked.Total));
                }
            }

            return new DispenseResult(MessagePayload.CompletionCodeEnum.Success, dispenseInfo.Values, LastDispenseResult);
        }

        public async Task<PresentCashResult> PresentCashAsync(PresentCashCommandEvents events, PresentCashRequest presentInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);
            
            if (CashDispenserStatus.IntermediateStacker == CashDispenserStatusClass.IntermediateStackerEnum.Empty || LastDispenseResult.Count == 0)
			{
                return new PresentCashResult(MessagePayload.CompletionCodeEnum.CommandErrorCode, 
                                             "No cash to present", 
                                             PresentCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            // When cash is presented successfully, set StackerStatus, OutputPositionStatus and shutter status
            CashDispenserStatus.IntermediateStacker = CashDispenserStatusClass.IntermediateStackerEnum.Empty;
            positionStatus.PositionStatus = CashManagementStatusClass.PositionStatusEnum.NotEmpty;
            positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Open;

            foreach (var item in LastDispenseResult)
            {
                if (LastDispenseResult.ContainsKey(item.Key))
                {
                    LastDispenseResult[item.Key].StorageCashOutCount.Presented = LastDispenseResult[item.Key].StorageCashOutCount.Stacked;
                    LastDispenseResult[item.Key].StorageCashOutCount.Stacked = new();
                    LastDispenseResult[item.Key].Count = 0;
                }
            }
            
            new Thread(CashTakenThread).IsNotNull().Start();

            return new PresentCashResult(MessagePayload.CompletionCodeEnum.Success, 0, LastDispenseResult);
        }

        public async Task<RejectResult> RejectAsync(RejectCommandEvents events, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if ((CashDispenserStatus.IntermediateStacker == CashDispenserStatusClass.IntermediateStackerEnum.Empty &&
                 positionStatus.PositionStatus == CashManagementStatusClass.PositionStatusEnum.Empty) || 
                LastDispenseResult.Count == 0)
            {
                return new RejectResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                        "No cash to reject",
                                        RejectCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            CashDispenserStatus.IntermediateStacker = CashDispenserStatusClass.IntermediateStackerEnum.Empty;
            positionStatus.PositionStatus = CashManagementStatusClass.PositionStatusEnum.Empty;
            positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Rejected = new StorageCashCountClass(3, new()
            {
                { "typeEUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "typeEUR20", new CashItemCountClass(2, 0, 0, 0, 0) }
            });
            cashMovement.Add("unit1", new CashUnitCountClass(null, cashInCount, cashInCount.Rejected.Total));

            LastDispenseResult.Clear();

            return new RejectResult(MessagePayload.CompletionCodeEnum.Success, cashMovement);
        }

        /// <summary>
        /// This method is used to test cash units following replenishment.
        /// All physical cash units which are testable (i.e. that have a status of ok or low and no application lock in the the physical cash unit) are tested.
        /// If the hardware is able to do so tests are continued even if an error occurs while testing one of the cash units. 
        /// The method completes with success if the device successfully manages to test all of the testable cash units regardless of the outcome of the test. 
        /// This is the case if all testable cash units could be tested and a dispense was possible from at least one of the cash units.
        /// </summary>
        public async Task<TestCashUnitsResult> TestCashUnitsAsync(TestCashUnitsCommandEvents events, TestCashUnitsRequest testCashUnitsInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            // TesCash normally moves dispensed cash to Reject cassette, but can be other supported position
            // If it is reject cassette, dispense one item from each cash unit
            // In the end update count and status of tested cash units and the reject cassette 

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Rejected = new StorageCashCountClass(0, new()
            {
                { "typeEUR5", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "tupeEUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "typeEUR20", new CashItemCountClass(1, 0, 0, 0, 0) }
            });
            StorageCashOutCountClass cashOutCount = new();
            cashOutCount.Rejected = new StorageCashCountClass(0, new()
            {
                { "typeEUR5", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "typeEUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "typeEUR20", new CashItemCountClass(1, 0, 0, 0, 0) }
            });
            cashMovement.Add("PH2", new CashUnitCountClass(cashOutCount, cashInCount, cashOutCount.Rejected.Total));

            return new TestCashUnitsResult(MessagePayload.CompletionCodeEnum.Success, cashMovement);
        }

        /// <summary>
        /// CountAsync
        /// Perform count operation to empty the specified physical cash unit(s). 
        /// All items dispensed from the cash unit are counted and moved to the specified output location.
        /// </summary>
        public async Task<CountResult> CountAsync(CountCommandEvents events, CountRequest countInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            if (countInfo.StorageUnitIds is not null)
            {
                foreach (var id in countInfo.StorageUnitIds)
                {
                    if (CashUnitInfo[id].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.CashOutRetract) ||
                        CashUnitInfo[id].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.Reject))
                    {
                        return new CountResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                               $"Specified cash unit can't be emptied. {id}");
                    }

                    Contracts.Assert(CashUnitInfo[id].CashUnitStorageConfig.Configuration.BanknoteItems.Count > 1, "Unexpected banknote types assigned");
                    cashMovement.Add(id, new CashUnitCountClass(null, null, CashUnitInfo[id].UnitCount.Count));
                }
            }
            

            return new CountResult(MessagePayload.CompletionCodeEnum.Success, cashMovement);
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
        public CashDispenserPresentStatus GetPresentStatus(CashManagementCapabilitiesClass.OutputPositionEnum position)
        {
            // Example for EUR 200 was presented
            Dictionary<string, double> Amounts = new();
            Amounts.Add("EUR", 500.00);

            Dictionary<string, int> Values = new();
            Values.Add("unit3", 2); // EUR 5 x 2
            Values.Add("unit4", 4); // EUR 20 x 5

            Denomination Denom = new(Amounts, Values); 
            return new CashDispenserPresentStatus(CashDispenserPresentStatus.PresentStatusEnum.Presented, Denom);
        }

        /// <summary>
        /// Calculate the token which will validate the data in the GetPresentStatus result.
        /// </summary>
        /// <param name="nonce">Value that will be unique for each token</param>
        /// <returns>Token string, including nonce and HMAC, or null if E2E is not supported</returns>
        public async Task<string> GetPresentStatusTokenAsync(string nonce)
        {
            string token = await Task.Run(() =>
            {
                return Firmware.GetPresentStatusToken(nonce);
            });
            return token;
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
                IntermediateStacker: true,
                ItemsTakenSensor: true,
                OutputPositions: CashManagementCapabilitiesClass.OutputPositionEnum.Center | CashManagementCapabilitiesClass.OutputPositionEnum.Default,
                MoveItems: CashDispenserCapabilitiesClass.MoveItemEnum.ToCashUnit | CashDispenserCapabilitiesClass.MoveItemEnum.ToTransport | CashDispenserCapabilitiesClass.MoveItemEnum.ToStacker);

        #endregion 

        #region CashManagement Interface
        /// <summary>
        /// This method will retract items which may have been in customer access from an output position or from internal areas within the CashDispenser. 
        /// Retracted items will be moved to either a retract cash unit, a reject cash unit, item cash units, the transport or the intermediate stacker. 
        /// After the items are retracted the shutter is closed automatically, even if the ShutterControl capability is set to false.
        /// </summary>
        public async Task<RetractResult> RetractAsync(RetractCommandEvents events, RetractRequest retractInfo, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            if (CashDispenserStatus.IntermediateStacker == CashDispenserStatusClass.IntermediateStackerEnum.Empty &&
                positionStatus.PositionStatus == CashManagementStatusClass.PositionStatusEnum.Empty)
            {
                return new RetractResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                         "No cash to retract",
                                         RetractCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            CashDispenserStatus.IntermediateStacker = CashDispenserStatusClass.IntermediateStackerEnum.Empty;
            positionStatus.PositionStatus = CashManagementStatusClass.PositionStatusEnum.Empty;
            positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Retracted = new StorageCashCountClass(3, new() 
                                                                 { 
                                                                    { "typeEUR5",  new CashItemCountClass(1, 0, 0, 0, 0) },
                                                                    { "typeEUR20", new CashItemCountClass(3, 0, 0, 0, 0) } 
                                                                 });
            cashMovement.Add("unit2", new CashUnitCountClass(null, cashInCount, cashInCount.Retracted.Total));

            CashDispenserStatus.IntermediateStacker = CashDispenserStatusClass.IntermediateStackerEnum.Empty;
            positionStatus.PositionStatus = CashManagementStatusClass.PositionStatusEnum.Empty;
            positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;

            return new RetractResult(MessagePayload.CompletionCodeEnum.Success, cashMovement);
        }

        /// <summary>
        /// OpenCloseShutterAsync
        /// Perform shutter operation to open or close.
        /// </summary>
        public async Task<OpenCloseShutterResult> OpenCloseShutterAsync(OpenCloseShutterRequest shutterInfo, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            if (shutterInfo.Action == OpenCloseShutterRequest.ActionEnum.Open)
                positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Open;
            if (shutterInfo.Action == OpenCloseShutterRequest.ActionEnum.Close)
                positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;

            return new OpenCloseShutterResult(MessagePayload.CompletionCodeEnum.Success);
        }


        /// <summary>
        /// ResetDeviceAsync
        /// Perform a hardware reset which will attempt to return the CashDispenser device to a known good state.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(ResetCommandEvents events, ResetDeviceRequest resetDeviceInfo, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            positionStatus.Transport = CashManagementStatusClass.TransportEnum.Ok;
            positionStatus.Shutter = CashManagementStatusClass.ShutterEnum.Closed;

            return new ResetDeviceResult(MessagePayload.CompletionCodeEnum.Success, MovementResult:null);
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
            ShutterControl: true,
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
            if (CashUnitInfo.Count == 0)
            {
                CashStorageInfo reject = new (new ("REJ",
                                              "PHP1",
                                              2000,
                                              "sn90376878-0209",
                                              new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.Reject,
                                                                        CashCapabilitiesClass.ItemsEnum.Fit |
                                                                        CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                        CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                        true,
                                                                        1,
                                                                        new List<string>(AllBanknoteIDs.Keys)),
                                              new CashConfigurationClass(CashCapabilitiesClass.TypesEnum.Reject,
                                                                         CashCapabilitiesClass.ItemsEnum.Fit |
                                                                         CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                         CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                         "",
                                                                         0,
                                                                         1900,
                                                                         50,
                                                                         false,
                                                                         false,
                                                                         new List<string>(AllBanknoteIDs.Keys)),
                                              new CashUnitAdditionalInfoClass(1, false)));

                CashUnitInfo.Add("unit1", reject);

                CashStorageInfo retract = new (new ("RET",
                                                    "PHP2",
                                                    2000,
                                                    "sn90376878-0228",
                                                    new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOutRetract,
                                                                                CashCapabilitiesClass.ItemsEnum.Fit |
                                                                                CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                                CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                                true,
                                                                                1,
                                                                                new List<string>(AllBanknoteIDs.Keys)),
                                                    new CashConfigurationClass(CashCapabilitiesClass.TypesEnum.CashOutRetract,
                                                                                CashCapabilitiesClass.ItemsEnum.Fit |
                                                                                CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                                CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                                "",
                                                                                0,
                                                                                1900,
                                                                                50,
                                                                                false,
                                                                                false,
                                                                                new List<string>(AllBanknoteIDs.Keys)),
                                                    new CashUnitAdditionalInfoClass(2, false)));

                CashUnitInfo.Add("unit2", retract);

                CashStorageInfo eur5 = new (new ("LOG1",
                                                 "PHP3",
                                                 1500,
                                                 "sn90376878-0228",
                                                 new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                           CashCapabilitiesClass.ItemsEnum.Fit |
                                                                           CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                           true,
                                                                           0,
                                                                           new List<string>(AllBanknoteIDs.Keys)),
                                                 new CashConfigurationClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                            CashCapabilitiesClass.ItemsEnum.Fit,
                                                                            "EUR",
                                                                            5.0,
                                                                            1400,
                                                                            50,
                                                                            false,
                                                                            false,
                                                                            new()
                                                                            {
                                                                                "typeEUR5"
                                                                            }),
                                                new CashUnitAdditionalInfoClass(3, false)));

                CashUnitInfo.Add("unit3", eur5);

                CashStorageInfo eur10 = new (new ("LOG2", 
                                                  "PHP4",
                                                  1500,
                                                  "sn90376878-0229",
                                                  new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                            CashCapabilitiesClass.ItemsEnum.Fit |
                                                                            CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                            true,
                                                                            0,
                                                                            new List<string>(AllBanknoteIDs.Keys)),
                                                  new CashConfigurationClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                             CashCapabilitiesClass.ItemsEnum.Fit,
                                                                             "EUR",
                                                                             10.0,
                                                                             1400,
                                                                             50,
                                                                             false,
                                                                             false,
                                                                             new()
                                                                             {
                                                                                 "typeEUR10"
                                                                             }),
                                                  new CashUnitAdditionalInfoClass(4, false)));

                CashUnitInfo.Add("unit4", eur10);

                CashStorageInfo eur20 = new (new ("LOG3", 
                                                  "PHP5",
                                                  1500,
                                                  "sn90376878-0230",
                                                  new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                            CashCapabilitiesClass.ItemsEnum.Fit |
                                                                            CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                            true,
                                                                            0,
                                                                            new List<string>(AllBanknoteIDs.Keys)),
                                                  new CashConfigurationClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                             CashCapabilitiesClass.ItemsEnum.Fit,
                                                                             "EUR",
                                                                             20.0,
                                                                             1400,
                                                                             50,
                                                                             false,
                                                                             false,
                                                                             new()
                                                                             {
                                                                                 "typeEUR20"
                                                                             }),
                                                  new CashUnitAdditionalInfoClass(5, false)));

                CashUnitInfo.Add("unit5", eur20);
            }

            newCashUnits = new();
            foreach (var unit in CashUnitInfo)
            {
                newCashUnits.Add(unit.Key, unit.Value.CashUnitStorageConfig);
            }

            return true;
        }

        /// <summary>
        /// Return return cash unit counts maintained by the device
        /// </summary>
        /// <returns>Return true if the device class maintained counts, otherwise false</returns>
        public bool GetCashUnitCounts(out Dictionary<string, CashUnitCountClass> unitCounts)
        {
            unitCounts = new();
            foreach (var unit in CashUnitInfo)
            {
                unitCounts.Add(unit.Key, unit.Value.UnitCount);
            }

            return false;
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
            storageStatus = new();
            foreach (var unit in CashUnitInfo)
            {
                storageStatus.Add(unit.Key, unit.Value.StorageStatus);
            }

            return true;
        }

        /// <summary>
        /// Return return cash unit status maintained by the device class
        /// </summary>
        /// <returns>Return true if the device class uses hardware status, otherwise false</returns>
        public bool GetCashUnitStatus(out Dictionary<string, CashStatusClass.ReplenishmentStatusEnum> unitStatus)
        {
            unitStatus = new();
            foreach (var unit in CashUnitInfo)
            {
                unitStatus.Add(unit.Key, unit.Value.UnitStatus);
            }

            return false;
        }

        /// <summary>
        /// Return accuracy of counts. This method is called if the device class supports feature for count accuray
        /// </summary>
        public void GetCashUnitAccuray(string storageId, out CashStatusClass.AccuracyEnum unitAccuracy)
        {
            unitAccuracy = CashStatusClass.AccuracyEnum.NotSupported;
        }

        /// <summary>
        /// Set new configuration and counters
        /// </summary>
        /// <returns>Return operation is completed successfully or not and report updates storage information.</returns>
        public async Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            foreach (var unit in request.CashStorageToSet)
            {
                if (!CashUnitInfo.ContainsKey(unit.Key))
                    continue;

                if (unit.Value.Configuration?.AppLockIn is not null)
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.AppLockIn = (bool)unit.Value.Configuration.AppLockIn;
                if (unit.Value.Configuration?.AppLockOut is not null)
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.AppLockOut = (bool)unit.Value.Configuration.AppLockOut;
                if (unit.Value.Configuration?.BanknoteItems is not null &&
                    unit.Value.Configuration?.BanknoteItems.Count == 0)
                {
                    if (unit.Value.Configuration.BanknoteItems.Count == 0)
                    {
                        return new SetCashStorageResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                        $"Empty banknote items are set. {unit.Key}");
                    }
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.BanknoteItems = unit.Value.Configuration.BanknoteItems;
                }
                if (!string.IsNullOrEmpty(unit.Value.Configuration?.Currency))
                {
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Currency = unit.Value.Configuration.Currency;
                }
                if (unit.Value.Configuration?.HighThreshold is not null)
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.HighThreshold = (int)unit.Value.Configuration.HighThreshold;
                if (unit.Value.Configuration?.LowThreshold is not null)
                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.LowThreshold = (int)unit.Value.Configuration.LowThreshold;
                if (unit.Value.Configuration?.Items is not null)
                {
                    if (CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.CashOut) &&
                        unit.Value.Configuration?.Items != CashCapabilitiesClass.ItemsEnum.Fit)
                    {
                        return new SetCashStorageResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                        $"The cash out unit can only set fit type of cash. {unit.Value.Configuration.Items}");
                    }
                }
                if (unit.Value.Configuration?.Value is not null)
                {
                    if (CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.CashOut) &&
                        ((double)unit.Value.Configuration.Value != 5 &&
                         (double)unit.Value.Configuration.Value != 10 &&
                         (double)unit.Value.Configuration.Value != 20))
                    {
                        return new SetCashStorageResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                        $"The cash out unit can only set denomination 5, 10 or 20 Euros. {unit.Value.Configuration.Items}");
                    }

                    if ((CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.Reject) ||
                         CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Types.HasFlag(CashCapabilitiesClass.TypesEnum.CashOutRetract)) &&
                        ((double)unit.Value.Configuration.Value != 0))
                    {
                        return new SetCashStorageResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                        $"The reject or retract unit can only set denomination 0. {unit.Value.Configuration.Items}");
                    }

                    CashUnitInfo[unit.Key].CashUnitStorageConfig.Configuration.Value = (double)unit.Value.Configuration.Value;
                }

                if (unit.Value.InitialCounts is not null)
                {
                    // Clear counts and set initial count
                    CashUnitInfo[unit.Key].UnitCount.StorageCashOutCount = new();
                    CashUnitInfo[unit.Key].UnitCount.Count = unit.Value.InitialCounts.Total;
                }
            }

            return new SetCashStorageResult(MessagePayload.CompletionCodeEnum.Success, request.CashStorageToSet);
        }

        /// <summary>
        /// Start cash unit exchange operation
        /// </summary>
        public async Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Prepare for the cash unit exchange operation

            return new StartExchangeResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// Complete cash unit exchange operation
        /// </summary>
        public async Task<EndExchangeResult> EndExchangeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Complete for the cash unit exchange operation

            return new EndExchangeResult(MessagePayload.CompletionCodeEnum.Success);
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
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.GetCommandNonce,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.ClearCommandNonce,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.StatusChangedEvent,
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.ErrorEvent,
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.NonceClearedEvent,
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
                AntiFraudModule: false,
                EndToEndSecurity: new CommonCapabilitiesClass.EndToEndSecurityClass
                (
                    Required: CommonCapabilitiesClass.EndToEndSecurityClass.RequiredEnum.Always,
                    HardwareSecurityElement: false, // Sample is software. Real hardware should use an HSE. 
                    ResponseSecurityEnabled: CommonCapabilitiesClass.EndToEndSecurityClass.ResponseSecurityEnabledEnum.NotSupported // ToDo: GetPresentStatus token support
                ));

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce()
        {
            string nonce = Firmware.GetCommandNonce();

            return Task.FromResult(new GetCommandNonceResult(MessagePayload.CompletionCodeEnum.Success,
                                                             nonce));
        }
        public Task<DeviceResult> ClearCommandNonce()
        {
            Firmware.ClearCommandNonce();

            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
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
                StorageStatus = CashUnitStorage.StatusEnum.Good;
                UnitStatus = CashStatusClass.ReplenishmentStatusEnum.Healthy;
                UnitCount = new CashUnitCountClass(StorageCashOutCount: new(), StorageCashInCount: null, 0);
                this.CashUnitStorageConfig = CashUnitStorageConfig;
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

        /// <summary>
        /// Thread for simulate cash taken event to be fired
        /// </summary>
        private void CashTakenThread()
        {
            Thread.Sleep(5000);

            cashTakenSignal.Release();
        }

        private XFS4IoT.ILogger Logger { get; }

        private readonly SemaphoreSlim cashTakenSignal = new(0, 1);

        private readonly Firmware Firmware; 
    }
}