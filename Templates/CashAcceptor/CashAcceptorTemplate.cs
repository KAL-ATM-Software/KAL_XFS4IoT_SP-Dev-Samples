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
using XFS4IoTFramework.CashAcceptor;
using XFS4IoTFramework.CashManagement;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Storage;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.CashAcceptor;
using XFS4IoT.CashAcceptor.Completions;
using XFS4IoT.CashManagement.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace CashAcceptor.CashAcceptorTemplate
{
    /// <summary>
    /// Sample CashAcceptor device class to implement
    /// </summary>
    public class CashAcceptorTemplate : ICashManagementDevice, ICashAcceptorDevice, ICommonDevice, IStorageDevice
    {
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling ItemsTakenEvent after cash is returned and taken by customer.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync(CancellationToken Token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public CashAcceptorTemplate(XFS4IoT.ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CashAcceptorTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.Inactive,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            CashAcceptorStatus = new CashAcceptorStatusClass(CashAcceptorStatusClass.IntermediateStackerEnum.Empty,
                                                             CashAcceptorStatusClass.StackerItemsEnum.NoItems,
                                                             CashAcceptorStatusClass.BanknoteReaderEnum.Ok,
                                                             false,
                                                             new()
                                                               {
                                                                   { CashManagementCapabilitiesClass.PositionEnum.InCenter,  positionStatus },
                                                                   { CashManagementCapabilitiesClass.PositionEnum.InDefault, positionStatus },
                                                                   { CashManagementCapabilitiesClass.PositionEnum.OutCenter, positionStatus },
                                                                   { CashManagementCapabilitiesClass.PositionEnum.OutDefault,positionStatus },
                                                             });

            CashManagementStatus = new CashManagementStatusClass(CashManagementStatusClass.SafeDoorEnum.Closed,
                                                                 CashManagementStatusClass.DispenserEnum.Ok,
                                                                 CashManagementStatusClass.AcceptorEnum.NotSupported);
        }

        #region CashAcceptor Interface
        /// <summary>
        /// Before initiating a cash-in operation, an application must issue the CashInStart command to begin a cash-in transaction.
        /// During a cash-in transaction any number of CashIn commands may be issued. 
        /// The transaction is ended when either a CashInRollback, CashInEnd, Storage.Retract or Reset command is sent. 
        /// Where the capabilities ShutterControl is false, this command precedes any explicit operation of the shutters.
        /// The Storage.Retract will terminate a transaction.
        /// In this case CashInEnd, CashInRollback and CashIn will report NoCashInActive command error.
        /// If an application wishes to determine where the notes went during a transaction it can execute a Storage.GetStorage before and after the transaction and then derive the difference.
        /// A hardware failure during the cash-in transaction does not reset the note number list information; 
        /// instead the note number list information will include items that could be accepted and identified up to the point of the hardware failure.
        /// </summary>
        public async Task<CashInStartResult> CashInStart(CashInStartRequest rquest, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command moves items into the cash device from an input position.
        /// On devices with implicit shutter control, the CashAcceptor.InsertItemsEvent will be
        /// generated when the device is ready to start accepting media.
        /// The items may pass through the banknote reader for identification.Failure to identify items does not mean that the
        /// command has failed - even if some or all of the items are rejected by the banknote reader the command may return
        /// success. In this case one or more CashAcceptor.InputRefuseEvent events will be sent
        /// to report the rejection.See also the paragraph below about returning refused items.
        /// If the device does not have a banknote reader then the completion message will be empty.
        /// 
        /// If the device has a cash-in stacker then this command will cause inserted genuine items (see
        /// Note Classification) to be moved there after
        /// validation.Counterfeit, suspect or inked items may also be moved to the cash-in stacker, but some devices may immediately move
        /// them to a designated storage unit. Items on the stacker will remain there until the current cash-in transaction is either
        /// cancelled by the CashAcceptor.CashInRollback command or confirmed by the
        /// CashAcceptor.CashInEnd command. These commands will cause any non-genuine items on the
        /// cash-in stacker to be moved to the appropriate storage unit.If there is no cash-in stacker then this command will move
        /// items directly to the storage units and the CashAcceptor.CashInRollback command will not be supported. Storage unit
        /// information will be updated accordingly whenever notes are moved to a storage unit during this command.
        /// 
        /// Note that the acceptor status field may change value
        /// during a cash-in transaction.If media has been retained to storage units during a cash-in transaction, it may mean that
        /// Acceptor is set to Stop, which means subsequent cash-in operations may not be possible.In this case, the subsequent
        /// command fails with cashUnitError.
        /// 
        /// The shutterControl field will determine
        /// whether the shutter is controlled implicitly by this command or whether the application must explicitly open and close
        /// the shutter using the CashManagement.OpenShutter,CashManagement.CloseShutter or CashAcceptor.PresentMedia
        /// commands. If shutterControl is false then this command does not operate the shutter in any way, the application is
        /// responsible for all shutter control. If shutterControl is true this command opens the shutter at the start of the
        /// command and closes it once bills are inserted.
        /// 
        /// The presentControl field will determine
        /// whether or not it is necessary to call the CashAcceptor.PresentMedia command in order to move items to the output
        /// position. If presentControl is true then all items are moved immediately to the correct output position for removal (a
        /// CashManagement.OpenShutter command will be needed in the case of explicit shutter control). If presentControl is false then items
        /// are not returned immediately and must be presented to the correct output position for removal using the
        /// CashAcceptor.PresentMedia command.
        /// It is possible that a device may divide bill or coin accepting into a series of sub-operations under hardware control.
        /// In this case a CashAcceptor.SubCashInEvent may be sent after each sub-operation, if the
        /// hardware capabilities allow it.
        /// Returning items (single bunch):
        /// If shutterControl is true, and a single bunch of items is returned then this command will complete once the notes have
        /// been returned. A CashManagement.ItemsPresentedEvent will be generated.
        /// 
        /// If shutterControl is false, and a single bunch of items is returned then this command will complete without generating
        /// a CashManagement.ItemsPresentedEvent, instead the event will be generated by the
        /// subsequent CashManagement.OpenShutter or CashAcceptor.PresentMedia command.
        /// Returning items (multiple bunches):
        /// It is possible that a device will in certain situations return refused items in multiple bunches. In this case, this
        /// command will not complete until the final bunch has been presented and after the last
        /// CashManagement.ItemsPresentedEvent has been generated. For these devices
        /// shutterControl and presentControl fields of the positionCapabilities structure returned from the
        /// Common.Capabilities CashAcceptor.PositionCapabilities query must both be true otherwise it will not be possible to
        /// return multiple bunches. Additionally it may be possible to request the completion of this command with a
        /// Common.Cancel before the final bunch is presented so that after the completion of this command the
        /// CashManagement.Retract or CashManagement.Reset command can be used to
        /// move the remaining bunches, although the ability to do this will be hardware dependent.
        /// </summary>
        public async Task<CashInResult> CashIn(CashInCommandEvents events,
                                               CashInRequest request,
                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command ends a cash-in transaction. If cash items are on the stacker as a result of a
        /// CashAcceptor.CashIn command these items are moved to the appropriate storage units.
        /// 
        /// The cash-in transaction is ended even if this command does not complete successfully.
        /// In the special case where all the items inserted by the customer are classified as counterfeit and/or suspect items and the
        /// Service is configured to automatically retain these item types then the command will complete with success even if the
        /// hardware may have already moved the counterfeit and/or suspect items to their respective storage units on the
        /// CashAcceptor.CashIn command and there are no items on the stacker at the start of the command. This allows the
        /// location of the notes retained to be reported in the output parameter.If no items are available for cash-in for any
        /// other reason, the NoItems error code is returned.
        /// </summary>
        public async Task<CashInEndResult> CashInEnd(ItemErrorCommandEvents events,
                                                     CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to roll back a cash-in transaction. It causes all the cash items cashed in since the last
        /// CashAcceptor.CashInStart command to be returned to the customer.
        /// This command ends the current cash-in transaction.The cash-in transaction is ended even if this command does not
        /// complete successfully.
        /// 
        /// The shutterControl property in the capabilities will determine
        /// whether the shutter is controlled implicitly by this command or whether the application must explicitly open and close
        /// the shutter using the CashManagement.OpenShutter, CashManagement.CloseShutter or CashAcceptor.PresentMedia
        /// commands. If shutterControl is false then this command does not operate the shutter in any way, the application is
        /// responsible for all shutter control. If shutterControl is true then this command opens the shutter and it is closed
        /// when all items are removed.
        /// 
        /// The presentControl property in the capabilities will determine
        /// whether or not it is necessary to call the CashAcceptor.PresentMedia command in order to move items to the output
        /// position. If presentControl is true then all items are moved immediately to the correct output position for removal (a
        /// CashManagement.OpenShutter command will be needed in the case of explicit shutter control). If presentControl is false then items are
        /// not returned immediately and must be presented to the correct output position for removal using the CashAcceptor.PresentMedia command.
        /// Items are returned in a single bunch or multiple bunches in the same way as described for the
        /// CashAcceptor.CashIn command.
        /// In the special case where all the items inserted by the customer are classified as counterfeit and/or suspect, and
        /// the Service is configured to automatically retain these item types, then the command
        /// will complete with Success even though no items are returned to the customer. This allows the location of the notes
        /// retained to be reported in the output parameter.The application can tell if items have been returned or not via the
        /// CashManagement.ItemsPresentedEvent](#cashmanagement.itemspresentedevent). This event will be generated before the command completes when items are returned.
        /// This event will not be generated if no items are returned. If no items are available to rollback for any other reason,
        /// the NoItems error code is returned.
        /// </summary>
        public async Task<CashInRollbackResult> CashInRollback(ItemInfoAvailableCommandEvent events,
                                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to change the note types the banknote reader should accept during cash-in. 
        /// Only note typeswhich are to be changed need to be specified in the command payload. 
        /// If an unknown note type is given the UnsupportedData will be returned.
        /// The values set by this command are persistent.
        /// </summary>
        public async Task<ConfigureNoteTypesResult> ConfigureNoteTypes(ConfigureNoteTypesRequest request,
                                                                       CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to create a reference signature which can be compared with the available signatures of the cash-in
        /// transactions to track back the customer.
        /// 
        /// When this command is executed, the device waits for a note to be inserted at the input position, transports the note to
        /// the recognition module, creates the signature and then returns the note to the output position.
        /// 
        /// The shutterControl property in the capabilities will determine
        /// whether the shutter is controlled implicitly by this command or whether the application must explicitly open and close
        /// the shutter using the CashManagement.OpenShutter, CashManagement.CloseShutter or CashAcceptor.PresentMedia
        /// commands. If shutterControl is false then this command does not operate the shutter in any way, and the application is
        /// responsible for all shutter control.If shutterControl is true then this command opens and closes the shutter at
        /// various times during the command execution and the shutter is finally closed when all items are removed.
        /// 
        /// The presentControl property in the capabilities will determine
        /// whether or not it is necessary to call the CashAcceptor.PresentMedia command in order to move items to the output
        /// position. If presentControl is true then all items are moved immediately to the correct output position for removal (a
        /// CashManagement.OpenShutter command will be needed in the case of explicit shutter control). If presentControl is false then items
        /// are not returned immediately and must be presented to the correct output position for removal using the
        /// CashAcceptor.PresentMedia command.
        /// 
        /// On devices with implicit shutter control, the CashAcceptor.InsertItemsEvent will be
        /// generated when the device is ready to start accepting media.
        /// 
        /// The application may have to execute this command repeatedly to make sure that all possible signatures are captured.
        /// If a single note is entered and returned to the customer but cannot be processed fully (e.g.no recognition software in
        /// the recognition module, the note is not recognized, etc.) then a
        /// CashAcceptor.InputRefuseEvent](#cashacceptor.inputrefuseevent) will be sent and the command will complete. In this
        /// case, no note specific output properties will be returned.
        /// </summary>
        public Task<CreateSignatureResult> CreateSignature(CashInCommonCommandEvents events,
                                                           CashInRequest request,
                                                           CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command is used to configure the currencydescription configuration data into the banknote reader module. 
        /// Theformat and location of the configuration data is vendor and/or hardwaredependent.
        /// </summary>
        public async Task<ConfigureNoteReaderResult> ConfigureNoteReader(ConfigureNoteReaderRequest request,
                                                                         CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// $ref: "../Docs/CompareSignatureDescription.md
        /// </summary>
        public Task<CompareSignatureResult> CompareSignature(CompareSignatureRequest request,
                                                             CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command replenishes items from a single storage unit to multiple storage units. Applications can use this command to
        /// ensure that there is the optimum number of items in the cassettes by moving items from a source storage unit to a target
        /// storage unit.This is especially applicable if a replenishment storage unit is used for the replenishment and can help to
        /// minimize manual replenishment operations.
        /// 
        /// The CashAcceptor.GetReplenishTarget command can be used to determine what storage unit.
        /// can be specified as target storage units for a given source storage unit.Any items which are removed from the source cash
        /// unit that are not of the correct currency and value for the target storage unit during execution of this command will be
        /// returned to the source storage unit.
        /// 
        /// The counts returned with the Storage.GetStorage command will be updated as part of the execution
        /// of this command.
        /// 
        /// If the command fails after some items have been moved, the command will complete with an appropriate error code, and a
        /// CashAcceptor.IncompleteReplenishEvent will be sent.
        /// </summary>
        public Task<ReplenishResult> Replenish(ReplenishCommandEvents events,
                                               ReplenishRequest request,
                                               CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command counts the items in the storage unit(s). If it is necessary to move items internally to count them,
        /// the items should be returned to the unit from which they originated before completion of the command. If items could not
        /// be moved back to the storage unit they originated from and did not get rejected, the command will complete with an
        /// appropriate error.
        /// 
        /// During the execution of this command one Storage.StorageChangedEvent will be
        /// generated for each storage unit that has been counted successfully, or if the counts have changed, even if the overall
        /// command fails.
        /// 
        /// If an application wishes to determine where the notes went during the command it can execute a
        /// Storage.GetStorage command before and after the transaction and then derive the difference.
        /// 
        /// This command is designed to be used on devices where the counts cannot be guaranteed to be accurate and therefore may
        /// need to be automatically counted periodically. Upon successful completion, for those storage units that have been
        /// counted, the counts are accurately reported with the Storage.GetStorage command.
        /// </summary>
        public async Task<CashUnitCountResult> CashUnitCount(ItemErrorCommandEvents events,
                                                             CashUnitCountRequest request,
                                                             CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command can be used to lock or unlock a CashAcceptor device or one or more storage units.
        /// CashAcceptor.GetDeviceLockStatus can be used to obtain the current lock state of any items which support locking.
        /// 
        /// During normal device operation the device and storage units will be locked and removal will not be possible.If supported,
        /// the device or storage units can be unlocked, ready for removal.In this situation the device will still remain online and
        /// cash-in or dispense operations will be possible, as long as the device or storage units are not physically removed from
        /// their normal operating position.
        /// 
        /// If the lock action is specified and the device or storage units are already locked, or if the unlock action is specified
        /// and the device or storage units are already unlocked then the action will complete successfully.
        /// 
        /// Once a storage unit has been removed and reinserted it may then have a manipulated status. This status can only
        /// be cleared by issuing a Storage.StartExchange / Storage.EndExchange command sequence.
        /// 
        /// The device and all storage units will also be locked implicitly as part of the execution of the Storage.EndExchange or
        /// the CashManagement.Reset command.
        /// 
        /// The normal command sequence is as follows:
        /// 1. CashAcceptor.DeviceLockControl command is executed to unlock the device and some or all of the storage units.
        /// 2. Optionally a cash-in transaction or a dispense transaction on a cash recycler device may be performed.
        /// 3. The operator was not required to remove any of the storage units, all storage units are still in their original position.
        /// 4. CashAcceptor.DeviceLockControl command is executed to lock the device and the storage units.
        /// 
        /// The relation of lock/unlock control with the Storage.StartExchange and the Storage.EndExchange commands is as follows:
        /// 1. CashAcceptor.DeviceLockControl command is executed to unlock the device and some or all of the storage units.
        /// 2. Optionally a CashAcceptor.CashInStart / CashAcceptor.CashIn / CashAcceptor.CashInEnd cash-in transaction or a
        /// CashDispenser.Dispense / CashDispenser.Present transaction on a 
        /// cash recycler device may be performed.
        /// 
        /// The operator removes and reinserts one or more of the previously unlocked storage units. The associated
        /// Storage.StorageChangedEvent will be posted and after the reinsertion the storage unit 
        /// will show the status manualInsertion.
        /// Storage.StartExchange command is executed.
        /// Storage.EndExchange command is executed.During this command execution the Service implicitly locks the device and
        /// all previously unlocked storage units. The status of the previously removed unit will be reset.
        /// </summary>
        public Task<DeviceLockResult> DeviceLockControl(DeviceLockRequest request,
                                                        CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command opens the shutter and presents items to be taken by the customer. The shutter is automatically closed after
        /// the media is taken.The command can be called after a[CashAcceptor.CashIn] (#cashacceptor.cashin),
        /// CashAcceptor.CashInRollback, CashManagement.Reset or
        /// CashAcceptor.CreateSignature command and can be used with explicit and implicit
        /// shutter control. The command is only valid on positions where Usage reported by the
        /// CashAcceptor.GetPositionCapabilities command is Rollback or Rrefuse and
        /// where PresentControl reported by the CashAcceptor.GetPositionCapabilities command is false.
        /// </summary>
        public Task<PresentMediaResult> PresentMedia(PresentMediaRequest request,
                                                     CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command moves items from multiple storage units to a single storage unit. Applications can use this command to ensure
        /// that there are the optimum number of items in the cassettes by moving items from source storage units to a target storage unit.
        /// This is especially applicable if surplus items are removed from multiple recycle storage units to a replenishment storage unit
        /// and can help to minimize manual replenishment operations.
        /// 
        /// The CashAcceptor.GetDepleteSource command can be used to determine what storage units can
        /// be specified as source storage units for a given target storage unit.
        /// 
        /// The counts returned by the Storage.GetStorage command will be updated as part of the execution of this command.
        /// 
        /// If the command fails after some items have been moved, the command will complete with an appropriate error code, and a
        /// CashAcceptor.IncompleteDepleteEvent will be sent.
        /// </summary>
        public Task<DepleteResult> Deplete(DepleteCommandEvents events,
                                           DepleteRequest request,
                                           CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// In cases where multiple bunches are to be returned under explicit shutter control, 
        /// this command is used for the purpose of moving a remaining bunch to the output position explicitly before using the following commands:
        /// CashManagement.OpenShutter
        /// CashAcceptor.PresentMedia
        /// The application can tell whether the additional items were left by using the CashAcceptor.GetPresentStatus command.
        /// This command does not affect the status of the current cash-in transaction.
        /// </summary>
        public Task<PreparePresentResult> PreparePresent(ItemInfoAvailableCommandEvent events,
                                                         PreparePresentRequest request,
                                                         CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This command allows the application to get additional information about the use assigned to each position available in the device.
        /// </summary>
        public Dictionary<CashManagementCapabilitiesClass.PositionEnum, PositionCapabilitiesClass> GetPositionCapabilities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The deplete target and destination information
        /// Key - The storage id can be used for target of the depletion operation.
        /// Value - List of storage id can be used for source of the depletion operation
        /// </summary>
        public Dictionary<string, List<string>> GetDepleteCashUnitSources() => new();

        /// <summary>
        /// Which storage units can be specified as targets for a given source storage unit with the CashAcceptor.Replenish command
        /// </summary>
        public List<string> ReplenishTargets() => new();

        /// <summary>
        /// CashAcceptor Status
        /// </summary>
        public CashAcceptorStatusClass CashAcceptorStatus { get; set; }

        /// <summary>
        /// CashAcceptor Capabilities
        /// </summary>
        public CashAcceptorCapabilitiesClass CashAcceptorCapabilities { get; set; } = new(
                Type: CashManagementCapabilitiesClass.TypeEnum.SelfServiceBill,
                MaxCashInItems: 0,
                Shutter: false,
                ShutterControl: false,
                IntermediateStacker: 0,
                ItemsTakenSensor: false,
                Positions: CashManagementCapabilitiesClass.PositionEnum.InCenter | 
                           CashManagementCapabilitiesClass.PositionEnum.InDefault |
                           CashManagementCapabilitiesClass.PositionEnum.OutCenter |
                           CashManagementCapabilitiesClass.PositionEnum.OutDefault,
                RetractAreas: CashManagementCapabilitiesClass.RetractAreaEnum.Retract,
                RetractTransportActions: CashManagementCapabilitiesClass.RetractTransportActionEnum.Retract,
                RetractStackerActions: CashManagementCapabilitiesClass.RetractStackerActionEnum.Retract,
                CashInLimit: CashAcceptorCapabilitiesClass.CashInLimitEnum.NotSupported,
                CountActions: CashAcceptorCapabilitiesClass.CountActionEnum.All,
                CounterfeitAction: CashAcceptorCapabilitiesClass.CounterfeitActionEnum.None);

        /// <summary>
        /// Status of current cash-in operation.
        /// if this property is set to null, the framework maitains cash-in status
        /// </summary>
        public CashInStatusClass CashInStatus { get; set; } = null;

        /// <summary>
        /// The physical lock/unlock status of the CashAcceptor device and storages.
        /// </summary>
        public DeviceLockStatusClass DeviceLockStatus { get; set; } = null;

        #endregion 

        #region CashManagement Interface
        /// <summary>
        /// This method will retract items which may have been in customer access from an output position or from internal areas within the CashDispenser. 
        /// Retracted items will be moved to either a retract cash unit, a reject cash unit, item cash units, the transport or the intermediate stacker. 
        /// After the items are retracted the shutter is closed automatically, even if the ShutterControl capability is set to false.
        /// </summary>
        public async Task<RetractResult> RetractAsync(RetractCommandEvents events, RetractRequest retractInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// OpenCloseShutterAsync
        /// Perform shutter operation to open or close.
        /// </summary>
        public Task<OpenCloseShutterResult> OpenCloseShutterAsync(OpenCloseShutterRequest shutterInfo, CancellationToken cancellation) => Task.FromResult(new OpenCloseShutterResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand));


        /// <summary>
        /// ResetDeviceAsync
        /// Perform a hardware reset which will attempt to return the CashDispenser device to a known good state.
        /// </summary>
        public async Task<ResetDeviceResult> ResetDeviceAsync(ResetCommandEvents events, ResetDeviceRequest resetDeviceInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method unlocks the safe door or starts the timedelay count down prior to unlocking the safe door, 
        /// if the device supports it. The command completes when the door is unlocked or the timer has started.
        /// </summary>
        public async Task<UnlockSafeResult> UnlockSafeAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method will cause a vendor dependent sequence of hardware events which will calibrate one or more physical cash units associated with a logical cash unit.
        /// </summary>
        public Task<CalibrateCashUnitResult> CalibrateCashUnitAsync(ItemErrorCommandEvents events,
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
        /// CashAcceptor.CashInStart
        /// CashAcceptor.CashIn
        /// CashAcceptor.CashInEnd
        /// CashAcceptor.CashInRollback
        /// CashAcceptor.CreateSignature
        /// CashAcceptor.Replenish
        /// CashAcceptor.CashUnitCount
        /// CashAcceptor.Deplete
        /// CashManagement.Retract
        /// CashManagement.Reset
        /// CashManagement.OpenShutter
        /// CashManagement.CloseShutter
        /// CashManagement.CalibrateCashUnit
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
        public async Task<SetCashStorageResult> SetCashStorageAsync(SetCashStorageRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start cash unit exchange operation
        /// </summary>
        public async Task<StartExchangeResult> StartExchangeAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Complete cash unit exchange operation
        /// </summary>
        public async Task<EndExchangeResult> EndExchangeAsync(CancellationToken cancellation)
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
                CashAcceptorInterface: new CommonCapabilitiesClass.CashAcceptorInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.CashInStart,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.CashIn,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.CashInEnd,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.CashInRollback,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.CashUnitCount,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.ConfigureNoteReader,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.ConfigureNoteTypes,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.GetCashInStatus,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.GetPositionCapabilities,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.CommandEnum.GetPresentStatus,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.EventEnum.InputRefuseEvent,
                        CommonCapabilitiesClass.CashAcceptorInterfaceClass.EventEnum.InsertItemsEvent,
                    }
                ),
                CashManagementInterface: new CommonCapabilitiesClass.CashManagementInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.Retract,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.OpenShutter,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.CloseShutter,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.CalibrateCashUnit,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.GetTellerInfo,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.CommandEnum.SetTellerInfo,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.SafeDoorClosedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.SafeDoorOpenEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ShutterStatusChangedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.NoteErrorEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsTakenEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsPresentedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.ItemsInsertedEvent,
                        CommonCapabilitiesClass.CashManagementInterfaceClass.EventEnum.IncompleteRetractEvent,
                    }
                ),
                StorageInterface: new CommonCapabilitiesClass.StorageInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.StartExchange,
                        CommonCapabilitiesClass.StorageInterfaceClass.CommandEnum.EndExchange,
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
                            ModelName: "ModelName",
                            SerialNumber: "SerialNumber",
                            RevisionNumber: "RevisionNumber",
                            ModelDescription: "ModelDescription",
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
                EndToEndSecurity: null);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();
        #endregion

        private CashManagementStatusClass.PositionStatusClass positionStatus = new(CashManagementStatusClass.ShutterEnum.Closed,
                                                                                   CashManagementStatusClass.PositionStatusEnum.Empty,
                                                                                   CashManagementStatusClass.TransportEnum.Ok,
                                                                                   CashManagementStatusClass.TransportStatusEnum.Empty);
         

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;
        private CashAcceptorServiceProvider CashAcceptorService { get; set; } = null;

        private Dictionary<string, CashStorageInfo> CashUnitInfo { get; } = new();

        // Holding identified and accepted note types and counts
        private Dictionary<string, CashItemCountClass> AcceptedItems { get;  } = new();

        private sealed class CashStorageInfo
        {
            public CashStorageInfo(CashUnitStorageConfiguration CashUnitStorageConfig)
            {
                StorageStatus = CashUnitStorage.StatusEnum.Good;
                UnitStatus = CashStatusClass.ReplenishmentStatusEnum.Healthy;
                UnitCount = new CashUnitCountClass(StorageCashOutCount: null, StorageCashInCount: new(), 0);
                this.CashUnitStorageConfig = CashUnitStorageConfig;
                Accuracy = CashUnitStorageConfig.CashUnitAdditionalInfo.AccuracySupported ? CashStatusClass.AccuracyEnum.Unknown : CashStatusClass.AccuracyEnum.NotSupported;
            }

            public CashUnitStorage.StatusEnum StorageStatus { get; set; }
            
            public CashStatusClass.ReplenishmentStatusEnum UnitStatus { get; set; }

            public CashUnitCountClass UnitCount { get; init; }

            public CashUnitStorageConfiguration CashUnitStorageConfig { get; init; }

            public CashStatusClass.AccuracyEnum Accuracy { get; set; }
        }

        private static readonly Dictionary<string, CashManagementCapabilitiesClass.BanknoteItem> AllBanknoteIDs; 

        /// <summary>
        /// Thread for simulate cash taken event to be fired
        /// </summary>
        private void CashTakenThread()
        {
            throw new NotImplementedException();
        }

        private XFS4IoT.ILogger Logger { get; }

        private readonly SemaphoreSlim cashTakenSignal = new(0, 1);
    }
}