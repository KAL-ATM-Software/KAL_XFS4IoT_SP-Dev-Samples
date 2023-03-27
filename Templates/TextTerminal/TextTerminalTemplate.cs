/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoT.Common;
using XFS4IoT.Common.Completions;
using XFS4IoT.Completions;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.TextTerminal;
using XFS4IoTFramework.Lights;
using XFS4IoTServer;
using System.Threading;
using XFS4IoT.TextTerminal.Completions;

namespace TextTerminal.TextTerminalTemplate
{
    public class TextTerminalTemplate : ITextTerminalDevice, ILightsDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public TextTerminalTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(TextTerminalTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.NotSupported,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            TextTerminalStatus = new TextTerminalStatusClass(TextTerminalStatusClass.KeyboardEnum.Off,
                                                             TextTerminalStatusClass.KeyLockEnum.NotAvailable,
                                                             0, 0);
        }

        /// <summary>
        /// Start up the TextTerminal UI in a separate thread to avoid blocking the SP.
        /// </summary>
        public Task RunAsync(CancellationToken Token)
        {
            return Task.CompletedTask;
        }


        #region TEXTTERMINAL interface

        /// <summary>
        /// Return the valid keys and command keys for the device.
        /// Will be called once and cached within the Framework.
        /// </summary>
        public GetKeyDetailCompletion.PayloadData GetKeyDetail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Beep command for the device
        /// </summary>
        public Task<DeviceResult> BeepAsync(BeepRequest beepInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear the displayed text.
        /// The framework will check the rectangle is valid and handle absolute or relative mode based on the CurrentX and CurrentY cursor position.
        /// </summary>
        public Task<DeviceResult> ClearScreenAsync(ClearScreenRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the display resolution.
        /// Framework will call ClearScreenAsync first to clear the display.
        /// SizeX and SizeY will be checked against reported capabilities to ensure valid.
        /// </summary>
        public Task<DeviceResult> SetResolutionAsync(SetResolutionRequest resolutionInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write the text at the specified position.
        /// The framework will handle new lines and ensure the text fits within the display width.
        /// If required, ScrollAsync will be called to scroll the text displayed.
        /// </summary>
        public Task<DeviceResult> WriteAsync(WriteRequest writeInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to start a read operation on the device.
        /// A KeyPress event should be triggered for each valid key.
        /// The method will return once a termination key is pressed or if the numChars is reached when AutoEnd is true.
        /// </summary>
        public Task<ReadResult> ReadAsync(ReadCommandEvents events, ReadRequest readInfo, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Scroll the display.
        /// Called during a write operation if the CurrentHeight is reached.
        /// The next write will be to the final line on the display.
        /// </summary>
        public Task<DeviceResult> ScrollAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reset the device
        /// </summary>
        public Task<DeviceResult> ResetDeviceAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TextTerminal Status
        /// </summary>
        public TextTerminalStatusClass TextTerminalStatus { get; set; }

        /// <summary>
        /// TextTerminal Capabilities
        /// </summary>
        public TextTerminalCapabilitiesClass TextTerminalCapabilities { get; set; } 
            = new TextTerminalCapabilitiesClass(
                Type: TextTerminalCapabilitiesClass.TypeEnum.Fixed,
                Resolutions: new()
                { new(32, 16), new(16, 16) },
                KeyLock: false,
                Cursor: true,
                Forms: false
            );

        #endregion

        #region COMMON interface

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
                TextTerminalInterface: new CommonCapabilitiesClass.TextTerminalInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.Beep,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.ClearScreen,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.GetKeyDetail,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.Read,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.SetResolution,
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.CommandEnum.Write,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.TextTerminalInterfaceClass.EventEnum.KeyEvent,
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
        public Task<SetLightResult> SetLightAsync(SetLightRequest request, CancellationToken cancellation) => throw new NotImplementedException();

        /// <summary>
        /// Lights Capabilities
        /// </summary>
        public LightsCapabilitiesClass LightsCapabilities { get; set; } = new(null);
        /// <summary>
        /// Stores light status
        /// </summary>
        public LightsStatusClass LightsStatus { get; set; } = new();

        #endregion
        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;
        private ILogger Logger { get; }

        /// <summary>
        /// CurrentWidth for the device resolution.
        /// </summary>
        public int CurrentWidth { get; set; }
        /// <summary>
        /// CurrentHeight for the device resolution.
        /// </summary>
        public int CurrentHeight { get; set; }


        /// <summary>
        /// Current X position for the cursor.
        /// </summary>
        public int CurrentX { get; set; }
        /// <summary>
        /// Current Y position for the cursor.
        /// </summary>
        public int CurrentY { get; set; }

        /// <summary>
        /// Controls if the Framework should call ScrollAsync during a Write operation.
        /// If set to false and the text overwrites the display area then the Write operation will end.
        /// If set to true the Framework will make space for the text by calling ScrollAsync.
        /// </summary>
        public bool ScrollingSupported => true;

    }
}