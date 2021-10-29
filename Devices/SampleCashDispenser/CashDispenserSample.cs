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
using XFS4IoTFramework.CashDispenser;
using XFS4IoTFramework.CashManagement;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Storage;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.CashDispenser.Events;
using XFS4IoT.CashDispenser;
using XFS4IoT.CashDispenser.Commands;
using XFS4IoT.CashDispenser.Completions;
using XFS4IoT.CashManagement.Completions;
using XFS4IoT.Storage.Completions;
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
        /// Here is an example of handling ItemsTakenEvent after card is presented and taken by customer.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            for (; ; )
            {
                // Check if presented cash is taken. When cash is taken, set output position empty, shutter closed and fire ItemsTakenEvent
                await cashTakenSignal?.WaitAsync();
                OutputPositionStatus = OutPosClass.PositionStatusEnum.Empty;
                ShutterStatus = OutPosClass.ShutterEnum.Closed;
                CashDispenserServiceProvider cashDispenserServiceProvider = SetServiceProvider as CashDispenserServiceProvider;
                //await cashDispenserServiceProvider.IsNotNull().ItemsTakenEvent(new ItemsTakenEvent.PayloadData(ItemsTakenEvent.PayloadData.PositionEnum.Center));
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

        #region CashDispenser Interface
        public async Task<DispenseResult> DispenseAsync(IDispenseEvents events, DispenseRequest dispenseInfo, CancellationToken cancellation)
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
            StackerStatus = StatusClass.IntermediateStackerEnum.NotEmpty;

            foreach (var item in dispenseInfo.Values)
            {
                CashUnitInfo.ContainsKey(item.Key).IsTrue($"Invalid cash unit ID supplied by the framework.");

                string noteId = string.Empty;
                foreach (var banknoteItem in CashUnitInfo[item.Key].CashUnitStorageConfig.Configuration.BanknoteItems)
                {
                    noteId = banknoteItem.Key;
                    break;
                }
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

        public async Task<PresentCashResult> PresentCashAsync(IPresentEvents events, PresentCashRequest presentInfo, CancellationToken cancellation)
		{
            // When we present cash we want to cancel any existing tokens so that they can't be used twice. 
            // We can do this by clearing the nonce - if there's no nonce then it can't match any tokens. 
            // We do this before we present the cash to avoid any race conditions. 
            Firmware.ClearCommandNonce(); 

            await Task.Delay(1000, cancellation);

            if (StackerStatus == StatusClass.IntermediateStackerEnum.Empty || LastDispenseResult.Count == 0)
			{
                return new PresentCashResult(MessagePayload.CompletionCodeEnum.CommandErrorCode, 
                                             "No cash to present", 
                                             PresentCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            // When cash is presented successfully, set StackerStatus, OutputpoistionStatus and shutter status
            StackerStatus = StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutPosClass.PositionStatusEnum.NotEmpty;
            ShutterStatus = OutPosClass.ShutterEnum.Open;

            foreach (var item in LastDispenseResult)
            {
                if (LastDispenseResult.ContainsKey(item.Key))
                {
                    LastDispenseResult[item.Key].StorageCashOutCount.Presented = LastDispenseResult[item.Key].StorageCashOutCount.Stacked;
                    LastDispenseResult[item.Key].StorageCashOutCount.Stacked = new();
                    LastDispenseResult[item.Key].Count = 0;
                }
            }

            return new PresentCashResult(MessagePayload.CompletionCodeEnum.Success, 0, LastDispenseResult);
        }

        public async Task<RejectResult> RejectAsync(IRejectEvents events, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            if ((StackerStatus == StatusClass.IntermediateStackerEnum.Empty && 
                 OutputPositionStatus == OutPosClass.PositionStatusEnum.Empty) || 
                LastDispenseResult.Count == 0)
            {
                return new RejectResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                        "No cash to reject",
                                        RejectCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            StackerStatus = StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutPosClass.PositionStatusEnum.Empty;
            ShutterStatus = OutPosClass.ShutterEnum.Closed;

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Rejected = new StorageCashCountClass(3, new()
            {
                { "EUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "EUR20", new CashItemCountClass(2, 0, 0, 0, 0) }
            });
            cashMovement.Add("PHP1", new CashUnitCountClass(null, cashInCount, cashInCount.Rejected.Total));

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
        public async Task<TestCashUnitsResult> TestCashUnitsAsync(ITestCashUnitsEvents events, TestCashUnitsRequest testCashUnitsInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            // TesCash normally moves dispensed cash to Reject cassette, but can be other supported position
            // If it is reject cassette, dispense one item from each cash unit
            // In the end update count and status of tested cash units and the reject cassette 

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Rejected = new StorageCashCountClass(0, new()
            {
                { "EUR5", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "EUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "EUR20", new CashItemCountClass(1, 0, 0, 0, 0) }
            });
            StorageCashOutCountClass cashOutCount = new();
            cashOutCount.Rejected = new StorageCashCountClass(0, new()
            {
                { "EUR5", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "EUR10", new CashItemCountClass(1, 0, 0, 0, 0) },
                { "EUR20", new CashItemCountClass(1, 0, 0, 0, 0) }
            });
            cashMovement.Add("PH2", new CashUnitCountClass(cashOutCount, cashInCount, cashOutCount.Rejected.Total));

            return new TestCashUnitsResult(MessagePayload.CompletionCodeEnum.Success, cashMovement);
        }

        /// <summary>
        /// CountAsync
        /// Perform count operation to empty the specified physical cash unit(s). 
        /// All items dispensed from the cash unit are counted and moved to the specified output location.
        /// </summary>
        public async Task<CountResult> CountAsync(ICountEvents events, CountRequest countInfo, CancellationToken cancellation)
		{
            await Task.Delay(1000, cancellation);

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashOutCountClass cashOutCount = new();
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
        public PresentStatus GetPresentStatus(CashDispenserCapabilitiesClass.OutputPositionEnum position)
        {
            // Example for EUR 200 was presented
            Dictionary<string, double> Amounts = new();
            Amounts.Add("EUR", 500.00);

            Dictionary<string, int> Values = new();
            Values.Add("PHP3", 2); // EUR 5 x 2
            Values.Add("PHP4", 4); // EUR 20 x 5

            Denomination Denom = new(Amounts, Values); 
            return new PresentStatus(PresentStatus.PresentStatusEnum.Presented, Denom);
        }
        #endregion 

        #region CashManagement Interface
        /// <summary>
        /// This method will retract items which may have been in customer access from an output position or from internal areas within the CashDispenser. 
        /// Retracted items will be moved to either a retract cash unit, a reject cash unit, item cash units, the transport or the intermediate stacker. 
        /// After the items are retracted the shutter is closed automatically, even if the ShutterControl capability is set to false.
        /// </summary>
        public async Task<RetractResult> RetractAsync(IRetractEvents events, RetractRequest retractInfo, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            if (StackerStatus == StatusClass.IntermediateStackerEnum.Empty && 
                OutputPositionStatus == OutPosClass.PositionStatusEnum.Empty)
            {
                return new RetractResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                         "No cash to retract",
                                         RetractCompletion.PayloadData.ErrorCodeEnum.NoItems);
            }

            StackerStatus = StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutPosClass.PositionStatusEnum.Empty;
            ShutterStatus = OutPosClass.ShutterEnum.Closed;

            Dictionary<string, CashUnitCountClass> cashMovement = new();
            StorageCashInCountClass cashInCount = new();
            cashInCount.Retracted = new StorageCashCountClass(3, new() 
                                                                 { 
                                                                    { "EUR5",  new CashItemCountClass(1, 0, 0, 0, 0) },
                                                                    { "EUR20", new CashItemCountClass(3, 0, 0, 0, 0) } 
                                                                 });
            cashMovement.Add("PHP2", new CashUnitCountClass(null, cashInCount, cashInCount.Retracted.Total));

            StackerStatus = StatusClass.IntermediateStackerEnum.Empty;
            OutputPositionStatus = OutPosClass.PositionStatusEnum.Empty;
            ShutterStatus = OutPosClass.ShutterEnum.Closed;

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
                ShutterStatus = OutPosClass.ShutterEnum.Open;
            if (shutterInfo.Action == OpenCloseShutterRequest.ActionEnum.Close)
                ShutterStatus = OutPosClass.ShutterEnum.Closed;

            return new OpenCloseShutterResult(MessagePayload.CompletionCodeEnum.Success);
        }


        /// <summary>
        /// ResetDeviceAsync
        /// Perform a hardware reset which will attempt to return the CashDispenser device to a known good state.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(IResetEvents events, ResetDeviceRequest resetDeviceInfo, CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            Transport = OutPosClass.TransportEnum.Ok;
            ShutterStatus = OutPosClass.ShutterEnum.Closed;

            return new ResetDeviceResult(MessagePayload.CompletionCodeEnum.Success, MovementResult:null);
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
        /// This method will cause a vendor dependent sequence of hardware events which will calibrate one or more physical cash units associated with a logical cash unit.
        /// </summary>
        public Task<CalibrateCashUnitResult> CalibrateCashUnitAsync(ICalibrateCashUnitEvents events,
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
        #endregion

        #region Storage Interface
        /// <summary>
        /// Return storage information for current configuration and capabilities on the startup.
        /// </summary>
        /// <returns>Return true if the cash unit configuration or capabilities are changed, otherwise false</returns>
        public bool GetCashStorageConfiguration(out Dictionary<string, CashUnitStorageConfiguration> newCardUnits)
        {
            if (CashUnitInfo.Count == 0)
            {
                CashStorageInfo reject = new (new ("PHP1",
                                              2000,
                                              "sn90376878-0209",
                                              new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.Reject,
                                                                        CashCapabilitiesClass.ItemsEnum.Fit |
                                                                        CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                        CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                        true,
                                                                        1,
                                                                        AllBanknoteIDs),
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
                                                                         AllBanknoteIDs),
                                              new CashUnitAdditionalInfoClass(1, false)));

                CashUnitInfo.Add(reject.CashUnitStorageConfig.PositionName, reject);

                CashStorageInfo retract = new (new ("PHP2",
                                                    2000,
                                                    "sn90376878-0228",
                                                    new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOutRetract,
                                                                                CashCapabilitiesClass.ItemsEnum.Fit |
                                                                                CashCapabilitiesClass.ItemsEnum.Unrecognized |
                                                                                CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                                true,
                                                                                1,
                                                                                AllBanknoteIDs),
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
                                                                                AllBanknoteIDs),
                                                    new CashUnitAdditionalInfoClass(2, false)));

                CashUnitInfo.Add(retract.CashUnitStorageConfig.PositionName, retract);

                CashStorageInfo eur5 = new (new ("PHP3",
                                                 1500,
                                                 "sn90376878-0228",
                                                 new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                           CashCapabilitiesClass.ItemsEnum.Fit |
                                                                           CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                           true,
                                                                           0,
                                                                           AllBanknoteIDs),
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
                                                                                { "EUR5", AllBanknoteIDs["EUR5"] }
                                                                            }),
                                                new CashUnitAdditionalInfoClass(3, false)));

                CashUnitInfo.Add(eur5.CashUnitStorageConfig.PositionName, eur5);

                CashStorageInfo eur10 = new (new ("PHP4",
                                                  1500,
                                                  "sn90376878-0229",
                                                  new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                            CashCapabilitiesClass.ItemsEnum.Fit |
                                                                            CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                            true,
                                                                            1,
                                                                            AllBanknoteIDs),
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
                                                                                 { "EUR10", AllBanknoteIDs["EUR10"] }
                                                                             }),
                                                  new CashUnitAdditionalInfoClass(4, false)));

                CashUnitInfo.Add(eur10.CashUnitStorageConfig.PositionName, eur10);

                CashStorageInfo eur20 = new (new ("PHP5",
                                                  1500,
                                                  "sn90376878-0230",
                                                  new CashCapabilitiesClass(CashCapabilitiesClass.TypesEnum.CashOut,
                                                                            CashCapabilitiesClass.ItemsEnum.Fit |
                                                                            CashCapabilitiesClass.ItemsEnum.Unfit,
                                                                            true,
                                                                            1,
                                                                            AllBanknoteIDs),
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
                                                                                  { "EUR20", AllBanknoteIDs["EUR20"] }
                                                                             }),
                                                  new CashUnitAdditionalInfoClass(5, false)));

                CashUnitInfo.Add(eur20.CashUnitStorageConfig.PositionName, eur20);
            }

            newCardUnits = new();
            foreach (var unit in CashUnitInfo)
            {
                newCardUnits.Add(unit.Key, unit.Value.CashUnitStorageConfig);
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
        /// $ref: ../Docs/StartExchangeDescription.md
        /// </summary>
        public async Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            // Prepare for the cash unit exchange operation

            return new StartExchangeResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// $ref: ../Docs/EndExchangeDescription.md
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
        /// This command is used to obtain the overall status of any XFS4IoT service. The status includes common status information and can include zero or more interface specific status objects, depending on the implemented interfaces of the service. It may also return vendor-specific status information.
        /// </summary>
        public StatusCompletion.PayloadData Status()
        {
            StatusPropertiesClass common = new(
                Device: DeviceStatus,
                DevicePosition: PositionStatusEnum.InPosition,
                PowerSaveRecoveryTime: 0,
                AntiFraudModule: StatusPropertiesClass.AntiFraudModuleEnum.Ok);

            List<OutPosClass> Positions = new ();

            OutPosClass OutPos = new(Position: XFS4IoT.CashManagement.OutputPositionEnum.OutCenter,
                                     Shutter: ShutterStatus,
                                     PositionStatus: OutputPositionStatus,
                                     Transport: Transport,
                                     TransportStatus: TransportStatus,
                                     JammedShutterPosition: OutPosClass.JammedShutterPositionEnum.NotSupported);
            Positions.Add(OutPos);

            StatusClass cashDispenser = new(IntermediateStacker: StackerStatus,
                                            Positions: Positions);

            XFS4IoT.CashManagement.StatusClass cashManagement = new(SafeDoor: SafeDoorStatus,
                                                                    Dispenser: DispenserStatus);

            return new StatusCompletion.PayloadData(MessagePayload.CompletionCodeEnum.Success,
                                                    null,
                                                    Common: common,
                                                    CashDispenser: cashDispenser,
                                                    CashManagement: cashManagement);
        }

        public CapabilitiesCompletion.PayloadData Capabilities()
        {
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
                PowerSaveControl: false,
                AntiFraudModule: false,
                SynchronizableCommands: new List<string>(),
                EndToEndSecurity: true,
                HardwareSecurityElement: false, // Sample is software. Real hardware should use an HSE. 
                ResponseSecurityEnabled: false  // ToDo: GetPresentStatus token support
                );

            CapabilitiesClass cashDispenser = new(
                Type: CapabilitiesClass.TypeEnum.SelfServiceBill,
                MaxDispenseItems: 200,
                ShutterControl: false,
                RetractAreas: new CapabilitiesClass.RetractAreasClass(
                                    Retract: true,
                                    Transport: true,
                                    Stacker: true,
                                    Reject: true,
                                    ItemCassette: true),
                RetractTransportActions: new CapabilitiesClass.RetractTransportActionsClass(
                                                Present: true,
                                                Retract: true,
                                                Reject: true,
                                                ItemCassette: true),
                RetractStackerActions: new CapabilitiesClass.RetractStackerActionsClass(
                                                Present: true,
                                                Retract: true,
                                                Reject: true,
                                                ItemCassette: true),
                IntermediateStacker: true,
                ItemsTakenSensor: true,
                Positions: new CapabilitiesClass.PositionsClass(Center: true),
                MoveItems: new CapabilitiesClass.MoveItemsClass(
                                    FromCashUnit: true,
                                    ToCashUnit: false,
                                    ToTransport: false,
                                    ToStacker: true));

            XFS4IoT.CashManagement.CapabilitiesClass cashManagement = new(
                SafeDoor: true,
                CashBox: null,
                ExchangeType: new(true));

            List<InterfaceClass> interfaces = new()
            {
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.Common,
                    Commands: new()
                    {
                        { "Common.Status", null },
                        { "Common.Capabilities", null },
                    },
                    Events: new(),
                    MaximumRequests: 1000,
                    AuthenticationRequired: new List<string>()),
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.CashDispenser,
                    Commands: new()
                    {
                        { "CashDispenser.Denominate", null },
                        { "CashDispenser.Dispense", null },
                        { "CashDispenser.PresentCash", null },
                        { "CashDispenser.Reject", null },
                        { "CashDispenser.TestCashUnits", null },
                        { "CashDispenser.Count", null },
                        { "CashDispenser.GetMixTypes", null },
                    },
                    Events: new()
                    {
                        { "CashDispenser.StartDispenseEvent", null },
                        { "CashDispenser.IncompleteDispenseEvent", null },
                    },
                    MaximumRequests: 1000,
                    AuthenticationRequired: new()),
                new InterfaceClass(
                    Name: InterfaceClass.NameEnum.CashManagement,
                    Commands: new()
                    {
                        { "CashManagement.Retract", null },
                        { "CashManagement.OpenShutter", null },
                        { "CashManagement.CloseShutter", null },
                        { "CashManagement.CalibrateCashUnit", null },
                        { "CashManagement.Reset", null },
                        { "CashManagement.GetTellerInfo", null },
                        { "CashManagement.SetTellerInfo", null },
                    },
                    Events: new()
                    {
                        { "CashDispenser.SafeDoorClosedEvent", null },
                        { "CashDispenser.SafeDoorOpenEvent", null },
                        { "CashDispenser.ShutterStatusChangedEvent", null },
                        { "CashDispenser.NoteErrorEvent", null },
                        { "CashDispenser.ItemsTakenEvent", null },
                        { "CashDispenser.ItemsPresentedEvent", null },
                        { "CashDispenser.ItemsInsertedEvent", null },
                        { "CashDispenser.IncompleteRetractEvent", null },
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

        public Task<PowerSaveControlCompletion.PayloadData> PowerSaveControl(PowerSaveControlCommand.PayloadData payload) => throw new NotImplementedException();
        public Task<SynchronizeCommandCompletion.PayloadData> SynchronizeCommand(SynchronizeCommandCommand.PayloadData payload) => throw new NotImplementedException();
        public Task<SetTransactionStateCompletion.PayloadData> SetTransactionState(SetTransactionStateCommand.PayloadData payload) => throw new NotImplementedException();
        public GetTransactionStateCompletion.PayloadData GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceCompletion.PayloadData> GetCommandNonce()
        {
            string nonce = Firmware.GetCommandNonce();

            return Task.FromResult(
                        new GetCommandNonceCompletion.PayloadData(CompletionCode: MessagePayload.CompletionCodeEnum.Success, ErrorDescription: "",
                                                  nonce )
                        );
            throw new NotImplementedException();
        }
        public Task<ClearCommandNonceCompletion.PayloadData> ClearCommandNonce()
        {
            Firmware.ClearCommandNonce();

            return Task.FromResult(
                        new ClearCommandNonceCompletion.PayloadData(CompletionCode: MessagePayload.CompletionCodeEnum.Success, ErrorDescription: "" )
                        );
            throw new NotImplementedException();
        }
        #endregion

        public StatusPropertiesClass.DeviceEnum DeviceStatus { get; private set; } = StatusPropertiesClass.DeviceEnum.Online; 
        public StatusClass.IntermediateStackerEnum StackerStatus { get; private set; } = StatusClass.IntermediateStackerEnum.Empty;

        private XFS4IoT.CashManagement.StatusClass.SafeDoorEnum SafeDoorStatus { get; set; } = XFS4IoT.CashManagement.StatusClass.SafeDoorEnum.DoorClosed;
        private XFS4IoT.CashManagement.StatusClass.DispenserEnum DispenserStatus { get; set; } = XFS4IoT.CashManagement.StatusClass.DispenserEnum.Ok;

        public OutPosClass.ShutterEnum ShutterStatus { get; private set; } = OutPosClass.ShutterEnum.Closed;
        public OutPosClass.PositionStatusEnum OutputPositionStatus { get; private set; } = OutPosClass.PositionStatusEnum.Empty;
        public OutPosClass.TransportEnum Transport { get; private set; } = OutPosClass.TransportEnum.Ok;
        public OutPosClass.TransportStatusEnum TransportStatus { get; private set; } = OutPosClass.TransportStatusEnum.Empty;


        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private Dictionary<string, CashUnitCountClass> LastDispenseResult = new();

        private Dictionary<string, CashStorageInfo> CashUnitInfo { get; set; } = new();


        private sealed class CashStorageInfo
        {
            public CashStorageInfo(CashUnitStorageConfiguration CashUnitStorageConfig)
            {
                StorageStatus = CashUnitStorage.StatusEnum.Good;
                UnitStatus = CashStatusClass.ReplenishmentStatusEnum.Healthy;
                this.UnitCount = new CashUnitCountClass(StorageCashOutCount: new(), StorageCashInCount: null, 0);
                this.CashUnitStorageConfig = CashUnitStorageConfig;
            }

            public CashUnitStorage.StatusEnum StorageStatus { get; set; }
            
            public CashStatusClass.ReplenishmentStatusEnum UnitStatus { get; set; }

            public CashUnitCountClass UnitCount { get; init; }

            public CashUnitStorageConfiguration CashUnitStorageConfig { get; init; }
        }

        private readonly Dictionary<string, BanknoteItem> AllBanknoteIDs = new()
        {
            {
                "EUR5",
                new BanknoteItem(1, "EUR", 5.0, 1)
            },
            {
                "EUR10",
                new BanknoteItem(2, "EUR", 10.0, 1)
            },
            {
                "EUR20",
                new BanknoteItem(3, "EUR", 20.0, 1)
            },
            {
                "EUR50",
                new BanknoteItem(4, "EUR", 50.0, 1)
            },
            {
                "EUR100",
                new BanknoteItem(5, "EUR", 100.0, 1)
            },
            {
                "EUR500",
                new BanknoteItem(6, "EUR", 500.0, 1)
            }
        };

        private ILogger Logger { get; }

        private readonly SemaphoreSlim cashTakenSignal = new(0, 1);

        private readonly Firmware Firmware = new(); 
    }
}