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
using System.Text;
using System.Linq;
using XFS4IoT;
using XFS4IoTFramework.Lights;
using XFS4IoTFramework.Common;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.Lights.Sample
{
    /// <summary>
    /// Sample Lights device class to implement
    /// </summary>
    public class LightsSample : ILightsDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public LightsSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(LightsSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(Device: CommonStatusClass.DeviceEnum.Online,
                                                 DevicePosition: CommonStatusClass.PositionStatusEnum.InPosition,
                                                 PowerSaveRecoveryTime: 0,
                                                 AntiFraudModule: CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 Exchange: CommonStatusClass.ExchangeEnum.NotSupported,
                                                 EndToEndSecurity: CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            LightsStatus.Status = new()
            {
                { LightsCapabilitiesClass.DeviceEnum.CardReader, CardReaderLightStatus }
            };
        }

        #region Lights Interface

        /// <summary>
        /// This command is used to set the status of a light.
        /// For guidelights, the slow and medium flash rates must not be greater than 2.0 Hz. 
        /// It should be noted that in order to comply with American Disabilities Act guidelines only a slow or medium flash rate must be used.
        /// </summary>
        public async Task<SetLightResult> SetLightAsync(SetLightRequest request, CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            if (!request.StdLights.ContainsKey(LightsCapabilitiesClass.DeviceEnum.CardReader))
            {
                return new SetLightResult(MessagePayload.CompletionCodeEnum.InvalidData, $"Unsupported light received. {request.StdLights.Keys}");
            }
            LightsStatus.Status[LightsCapabilitiesClass.DeviceEnum.CardReader] = new(LightsStatusClass.LightOperation.PositionEnum.Center, request.StdLights[LightsCapabilitiesClass.DeviceEnum.CardReader].FlashRate, LightsStatusClass.LightOperation.ColourEnum.Default, LightsStatusClass.LightOperation.DirectionEnum.None);
            return new SetLightResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// Lights Capabilities
        /// </summary>
        public LightsCapabilitiesClass LightsCapabilities { get; set; } = new LightsCapabilitiesClass(
            new Dictionary<LightsCapabilitiesClass.DeviceEnum, LightsCapabilitiesClass.Light>() 
            { 
                { 
                    LightsCapabilitiesClass.DeviceEnum .CardReader, 
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
        public LightsStatusClass LightsStatus { get; set; } = new ();

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        /// <returns></returns>
        public Task RunAsync()
        {
            return Task.CompletedTask;
        }

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

        private LightsStatusClass.LightOperation CardReaderLightStatus = new (LightsStatusClass.LightOperation.PositionEnum.Center, LightsStatusClass.LightOperation.FlashRateEnum.Off, LightsStatusClass.LightOperation.ColourEnum.Default, LightsStatusClass.LightOperation.DirectionEnum.None);
    }
}