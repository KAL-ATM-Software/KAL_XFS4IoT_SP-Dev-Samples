/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
 * 
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoTFramework.Auxiliaries;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.Lights;
using XFS4IoTServer;
using static XFS4IoT.Completions.MessagePayload;

namespace Auxiliaries.AuxiliariesTemplate
{
    public class AuxiliariesTemplate : IAuxiliariesDevice, ICommonDevice, ILightsDevice
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public AuxiliariesTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(AuxiliariesTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;
        }

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; }

        public AuxiliariesCapabilities AuxiliariesCapabilities { get; set; } = new AuxiliariesCapabilities(HandsetSensor: AuxiliariesCapabilities.HandsetSensorCapabilities.Manual | AuxiliariesCapabilities.HandsetSensorCapabilities.Microphone | AuxiliariesCapabilities.HandsetSensorCapabilities.Auto | AuxiliariesCapabilities.HandsetSensorCapabilities.SemiAuto,
                                                                                                           AutoStartupMode: AuxiliariesCapabilities.AutoStartupModes.Daily | AuxiliariesCapabilities.AutoStartupModes.Weekly | AuxiliariesCapabilities.AutoStartupModes.Specific,
                                                                                                           AuxiliariesSupported: AuxiliariesCapabilities.AuxiliariesSupportedEnum.Heating);
        public AuxiliariesStatus AuxiliariesStatus { get; set; } = new AuxiliariesStatus(HandsetSensor: AuxiliariesStatus.HandsetSensorStatusEnum.OffTheHook, Heating: AuxiliariesStatus.SensorEnum.Off);
        private ILogger Logger { get; }

        AutoStartupTimeModeEnum AutoStartupTimeModeEnum { get; set; } = AutoStartupTimeModeEnum.Clear;
        StartupTime AutoStartupTime { get; set; } = null;


        public Task<DeviceResult> ClearAutoStartupTime(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<GetAutostartupTimeResult> GetAutoStartupTime(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        public async Task RunAsync(CancellationToken Token)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceResult> SetAutostartupTime(SetAutostartupTimeRequest autoStartupInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceResult> SetAuxiliaries(SetAuxiliariesRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        #region Common Interface

        public CommonStatusClass CommonStatus { get; set; } = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.NotSupported,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new CommonCapabilitiesClass(
                CommonInterface: new CommonCapabilitiesClass.CommonInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    }
                ),
                AuxiliariesInterface: new CommonCapabilitiesClass.AuxiliariesInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.CommandEnum.SetAutoStartUpTime,
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.CommandEnum.ClearAutoStartUpTime,
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.CommandEnum.GetAutoStartUpTime,
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.CommandEnum.SetAuxiliaries,
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.CommandEnum.Register,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.AuxiliariesInterfaceClass.EventEnum.AuxiliaryStatusEvent,
                    }
                ),
                LightsInterface: new CommonCapabilitiesClass.LightsInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.LightsInterfaceClass.CommandEnum.SetLight,
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

        #region Lights Interface

        /// <summary>
        /// This command is used to set the status of a light.
        /// For guidelights, the slow and medium flash rates must not be greater than 2.0 Hz. 
        /// It should be noted that in order to comply with American Disabilities Act guidelines only a slow or medium flash rate must be used.
        /// </summary>
        public async Task<SetLightResult> SetLightAsync(SetLightRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lights Capabilities
        /// </summary>
        public LightsCapabilitiesClass LightsCapabilities { get; set; } = new LightsCapabilitiesClass(
            new Dictionary<LightsCapabilitiesClass.DeviceEnum, LightsCapabilitiesClass.Light>()
            {
                {
                    LightsCapabilitiesClass.DeviceEnum.CardReader,
                        new LightsCapabilitiesClass.Light(
                            (LightsCapabilitiesClass.FlashRateEnum.Continuous |
                             LightsCapabilitiesClass.FlashRateEnum.Medium |
                             LightsCapabilitiesClass.FlashRateEnum.Quick |
                             LightsCapabilitiesClass.FlashRateEnum.Slow |
                             LightsCapabilitiesClass.FlashRateEnum.Off),
                            LightsCapabilitiesClass.ColorEnum.Default,
                            LightsCapabilitiesClass.DirectionEnum.NotSupported,
                            LightsCapabilitiesClass.LightPostionEnum.Center)
                }
            });

        /// <summary>
        /// Stores light status
        /// </summary>
        public LightsStatusClass LightsStatus { get; set; } = new();

        #endregion


        private readonly SemaphoreSlim sendStatusChangedEventSignal = new(0, 1);
    }
}
