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
using XFS4IoTFramework.VendorApplication;
using XFS4IoTFramework.Common;
using XFS4IoTServer;
using XFS4IoT.Completions;

namespace VendorApplication.VendorApplicationTemplate
{
    /// <summary>
    /// Sample indipendent VendorApplication device class to implement
    /// </summary>
    public class VendorApplicationTemplate : IVendorApplicationDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public VendorApplicationTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(VendorApplicationTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;
        }

        #region VendorApplication Interface

        /// <summary>
        /// This command is issued by an application to start a local application which provides vendor dependent services. 
        /// It can be used in conjunction with the Vendor Mode interface to manage vendor independent services and start vendor specific services, 
        /// e.g. maintenance oriented applications.
        /// </summary>
        public async Task<DeviceResult> StartLocalApplication(StartLocalApplicationRequest request,
                                                              CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to retrieve the interface that should be used by the vendor dependent application.
        /// </summary>
        public GetActiveInterfaceResult GetActiveInterface()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to indicate which interface should be displayed by a vendor dependent application.
        /// An application can issue this command to ensure that a vendor dependent application starts on the correct interface, 
        /// or to change the interface while running.
        /// </summary>
        public async Task<DeviceResult> SetActiveInterface(SetActiveInterfaceRequest request,
                                                           CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        public async Task RunAsync(CancellationToken Token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stores vendor application capabilites
        /// </summary>
        public VendorApplicationCapabilitiesClass VendorApplicationCapabilities { get; set; } = new VendorApplicationCapabilitiesClass(VendorApplicationCapabilitiesClass.SupportedAccessLevelEnum.Basic);

        // <summary>
        /// Stores vendor application status
        /// </summary>
        public VendorApplicationStatusClass VendorApplicationStatus { get; set; } = new VendorApplicationStatusClass(VendorApplicationStatusClass.AccessLevelEnum.Basic);

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
                VendorApplicationInterface: new CommonCapabilitiesClass.VendorApplicationInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.VendorApplicationInterfaceClass.CommandEnum.GetActiveInterface,
                        CommonCapabilitiesClass.VendorApplicationInterfaceClass.CommandEnum.SetActiveInterface,
                        CommonCapabilitiesClass.VendorApplicationInterfaceClass.CommandEnum.StartLocalApplication,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.VendorApplicationInterfaceClass.EventEnum.InterfaceChangedEvent,
                        CommonCapabilitiesClass.VendorApplicationInterfaceClass.EventEnum.VendorAppExitedEvent,
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
                AntiFraudModule: false);

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();

        #endregion 

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;

        private ILogger Logger { get; }

        private ActiveInterfaceEnum CurrentActiveInterface { get; set; } = ActiveInterfaceEnum.Operator;

        private Process process { get; set; } = null;
        private readonly SemaphoreSlim appStartedSignal = new(0, 1);
    }
}