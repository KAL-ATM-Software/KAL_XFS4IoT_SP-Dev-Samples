/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2024
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
using XFS4IoTFramework.Camera;
using XFS4IoTFramework.Common;
using XFS4IoTServer;
using XFS4IoT.Completions;

namespace Camera.CameraTemplate
{
    /// <summary>
    /// Sample indipendent CameraSample device class to implement
    /// </summary>
    public class CameraTemplate : ICameraDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public CameraTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(CameraTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CameraStatus = new(
                CameraLocationStatus: new()
                {
                    { CameraStatusClass.CameraLocationStatusClass.CameraLocationEnum.Room, RoomCamStatus }
                },
                CustomCameraLocationStatus: null);

            RoomCamStatus.CamerasState = CameraStatusClass.CameraLocationStatusClass.CamerasStateEnum.Ok;
        }

        #region Camera Interface

        /// <summary>
        /// This command is used to start the recording of the camera system. It is possible to select which camera or which camera position should be used to take a picture. Data to be displayed on the photo can be specified using the *camData* property.
        /// </summary>
        public Task<TakePictureResponse> TakePictureAsync(TakePictureRequest request, CancellationToken cancellation)
        {
            //RoomCamStatus.NumberOfPictures++;
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used by the client to perform a hardware reset which will attempt to return the camera device to a known good state.
        /// </summary>
        public Task<DeviceResult> ResetDeviceAsync(CancellationToken cancellation)
        {
            //CommonStatus.Device = CommonStatusClass.DeviceEnum.Online;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Camera Status
        /// </summary>
        public CameraStatusClass CameraStatus { get; set; }

        /// <summary>
        /// Camera Capabilities
        /// </summary>
        public CameraCapabilitiesClass CameraCapabilities { get; set; } = new(
            Type: CameraCapabilitiesClass.CameraTypeEnum.Cam,
            Cameras: new()
            {
                { CameraCapabilitiesClass.CameraEnum.Room, true },
                { CameraCapabilitiesClass.CameraEnum.Person, false },
                { CameraCapabilitiesClass.CameraEnum.ExitSlot, false }
            },
            CustomCameras: null,
            MaxPictures: 100,
            CamData: CameraCapabilitiesClass.CamDataMethodsEnum.ManualAdd);


        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// </summary>
        /// <returns></returns>
        public Task RunAsync(CancellationToken cancel)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region Common Interface
        /// <summary>
        /// Stores Commons status
        /// </summary>
        public CommonStatusClass CommonStatus { get; set; } = new(
            CommonStatusClass.DeviceEnum.Online,
            CommonStatusClass.PositionStatusEnum.InPosition,
            0,
            CommonStatusClass.AntiFraudModuleEnum.NotSupported,
            CommonStatusClass.ExchangeEnum.NotSupported,
            CommonStatusClass.EndToEndSecurityEnum.NotSupported);

        /// <summary>
        /// Stores Common Capabilities
        /// </summary>
        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new(
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
                CameraInterface: new CommonCapabilitiesClass.CameraInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CameraInterfaceClass.CommandEnum.TakePicture,
                        CommonCapabilitiesClass.CameraInterfaceClass.CommandEnum.Reset,
                    ]
                ),
                DeviceInformation:
                [
                    new CommonCapabilitiesClass.DeviceInformationClass(
                            ModelName: "Simulator",
                            SerialNumber: "123456-78900001",
                            RevisionNumber: "1.0",
                            ModelDescription: "Cam Template",
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

        private readonly CameraStatusClass.CameraLocationStatusClass RoomCamStatus = new(CameraStatusClass.CameraLocationStatusClass.MediaStateEnum.Ok, 0);
    }
}