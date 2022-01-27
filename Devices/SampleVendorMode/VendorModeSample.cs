/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
 * 
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoTFramework.VendorMode;
using XFS4IoTFramework.Common;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.VendorMode.Sample
{
    /// <summary>
    /// Sample VendorMode device class to implement
    /// </summary>
    public class VendorModeSample : IVendorModeDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public VendorModeSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(VendorModeSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;
        }

        #region VendorMode Interface

        /// <summary>
        /// This method is called after all registered clients are acknowledged to enter vendor mode.
        /// If there are any vendor specific operation required after entering VendorMode, process it in this method.
        /// Throw NotImplementedException if there is no specific operation required.
        /// </summary>
        public Task<DeviceResult> EnterVendorMode(CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// This method is called after all registered clients are acknowledged to exit vendor mode.
        /// If there are any vendor specific operation required after exiting VendorMode, process it in this method.
        /// /// Throw NotImplementedException if there is no specific operation required.
        /// </summary>
        public Task<DeviceResult> ExitVendorMode(CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        public async Task RunAsync()
        {
            return;
        }

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
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    }
                ),
                VendorModeInterface: new CommonCapabilitiesClass.VendorModeInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.VendorModeInterfaceClass.CommandEnum.EnterModeAcknowledge,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.CommandEnum.EnterModeRequest,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.CommandEnum.ExitModeAcknowledge,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.CommandEnum.ExitModeRequest,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.CommandEnum.Register,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.VendorModeInterfaceClass.EventEnum.EnterModeRequestEvent,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.EventEnum.ExitModeRequestEvent,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.EventEnum.ModeEnteredEvent,
                        CommonCapabilitiesClass.VendorModeInterfaceClass.EventEnum.ModeExitedEvent,
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
                AntiFraudModule: false,
                EndToEndSecurity: new CommonCapabilitiesClass.EndToEndSecurityClass
                (
                    Required: CommonCapabilitiesClass.EndToEndSecurityClass.RequiredEnum.IfConfigured,
                    HardwareSecurityElement: false, // Sample is software. Real hardware should use an HSE. 
                    ResponseSecurityEnabled: CommonCapabilitiesClass.EndToEndSecurityClass.ResponseSecurityEnabledEnum.NotSupported // ToDo: GetPresentStatus token support
                ));


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