/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
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
using XFS4IoT.Common.Commands;
using XFS4IoTServer;
using System.Threading;
using XFS4IoT.TextTerminal.Completions;
using System.Threading.Channels;
using TextTerminalProvider;

namespace TextTerminalSample
{
    public class TextTerminalSample : ITextTerminalDevice, ICommonDevice
    {

        /// <summary>
        /// Channel to await KeyPress from the UI.
        /// <code>var key = await readPressChannel.Reader.ReadAsync()</code>
        /// </summary>
        public static readonly Channel<string> readPressChannel = Channel.CreateUnbounded<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public TextTerminalSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(TextTerminalSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.NotSupported);

            TextTerminalStatus = new TextTerminalStatusClass(TextTerminalStatusClass.KeyboardEnum.Off,
                                                             TextTerminalStatusClass.KeyLockEnum.NotAvailable,
                                                             0, 0);
        }

        /// <summary>
        /// Start up the TextTerminal UI in a separate thread to avoid blocking the SP.
        /// </summary>
        public async Task RunAsync()
        {
            UITask = Task.Run(() =>
            {
                TextTerminalUI = new TextTerminalUI();
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.Run(TextTerminalUI);
            });
            await UITask;
        }


        #region TEXTTERMINAL interface

        /// <summary>
        /// Return the valid keys and command keys for the device.
        /// Will be called once and cached within the Framework.
        /// </summary>
        public GetKeyDetailCompletion.PayloadData GetKeyDetail()
        {
            return new GetKeyDetailCompletion.PayloadData(MessagePayload.CompletionCodeEnum.Success,
                                                          null,
                                                          "0123456789",
                                                          new()
                                                          {
                                                              "enter", "cancel", "clear",
                                                              "fdk01", "fdk02", "fdk03",
                                                              "fdk04", "fdk05", "fdk06",
                                                              "fdk07", "fdk08",
                                                          });
        }

        /// <summary>
        /// Beep command for the device
        /// </summary>
        public Task<DeviceResult> BeepAsync(BeepRequest beepInfo, CancellationToken cancellation)
        {
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// Clear the displayed text.
        /// The framework will check the rectangle is valid and handle absolute or relative mode based on the CurrentX and CurrentY cursor position.
        /// </summary>
        public Task<DeviceResult> ClearScreenAsync(ClearScreenRequest request, CancellationToken cancellation)
        {
            TextTerminalUI.ClearArea(request.PositionX, request.PositionY, request.Width, request.Height);
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// Set the display resolution.
        /// Framework will call ClearScreenAsync first to clear the display.
        /// SizeX and SizeY will be checked against reported capabilities to ensure valid.
        /// </summary>
        public Task<DeviceResult> SetResolutionAsync(SetResolutionRequest resolutionInfo, CancellationToken cancellation)
        {
            TextTerminalUI.SetResolution(resolutionInfo.SizeX, resolutionInfo.SizeY);
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// Write the text at the specified position.
        /// The framework will handle new lines and ensure the text fits within the display width.
        /// If required, ScrollAsync will be called to scroll the text displayed.
        /// </summary>
        public Task<DeviceResult> WriteAsync(WriteRequest writeInfo, CancellationToken cancellation)
        {
            TextTerminalUI.WriteAt(writeInfo.PosX, writeInfo.PosY, writeInfo.Text);
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// This command is used to start a read operation on the device.
        /// A KeyPress event should be triggered for each valid key.
        /// The method will return once a termination key is pressed or if the numChars is reached when AutoEnd is true.
        /// </summary>
        public async Task<ReadResult> ReadAsync(ReadRequest readInfo, CancellationToken cancellation)
        {
            TextTerminalUI.SetReading(true);
            StringBuilder buffer = new StringBuilder(readInfo.NumChars);

            for (; buffer.Length < readInfo.NumChars || !readInfo.AutoEnd;)
            {
                //Await key press 
                var key = await readPressChannel.Reader.ReadAsync(cancellation);

                //Check if key is a terminate key.
                if (readInfo.TerminateCommandKeys.Contains(key))
                {
                    await SetServiceProvider.IsA<TextTerminalServiceProvider>().KeyEvent(string.Empty, key);
                    break; //Terminate read.
                }
                //Check if key is a command key.
                else if (readInfo.ActiveCommandKeys.Contains(key))
                {
                    await SetServiceProvider.IsA<TextTerminalServiceProvider>().KeyEvent(string.Empty, key);
                    switch (key)
                    {
                        //Sample SP only supports "clear". Clear the buffered keys.
                        case "clear":
                            TextTerminalUI.WriteAt(readInfo.PositionX, readInfo.PositionY, new string(' ', buffer.Length));
                            buffer.Clear();
                            break;
                            //Default - Send KeyEvent only
                    }
                }
                //Check if key is a valid active key.
                else if (readInfo.ActiveKeys.Contains(key) && buffer.Length < readInfo.NumChars)
                {
                    //Add to buffer and write to display.
                    buffer.Append(key);
                    TextTerminalUI.WriteAt(readInfo.PositionX + buffer.Length - 1, readInfo.PositionY, key);
                    await SetServiceProvider.IsA<TextTerminalServiceProvider>().KeyEvent(key, string.Empty);
                }
                else
                {
                    //Key is invalid or numChars reached, discard.
                }
            }
            TextTerminalUI.SetReading(false); //Read complete - stop sending keys to the channel.
            return new(MessagePayload.CompletionCodeEnum.Success, null, buffer.ToString());
        }

        /// <summary>
        /// Scroll the display.
        /// Called during a write operation if the CurrentHeight is reached.
        /// The next write will be to the final line on the display.
        /// </summary>
        public Task<DeviceResult> ScrollAsync(CancellationToken cancellation)
        {
            TextTerminalUI.ScrollTextBox();
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// Reset the device
        /// </summary>
        public Task<DeviceResult> ResetDeviceAsync(CancellationToken cancellation)
        {
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        /// <summary>
        /// TextTerminal Status
        /// </summary>
        public TextTerminalStatusClass TextTerminalStatus { get; set; }

        /// <summary>
        /// TextTerminal Capabilities
        /// </summary>
        public TextTerminalCapabilitiesClass TextTerminalCapabilities { get; set; } = new TextTerminalCapabilitiesClass(
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
        public Task<DeviceResult> SynchronizeCommand(SynchronizeCommandRequest request) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();


        #endregion

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; } = null;
        private ILogger Logger { get; }

        /// <summary>
        /// Task for the UI. Started using Task.Run();
        /// </summary>
        private Task UITask { get; set; }
        /// <summary>
        /// UI form.
        /// </summary>
        private TextTerminalUI TextTerminalUI { get; set; }

        /// <summary>
        /// CurrentWidth for the device resolution.
        /// </summary>
        public int CurrentWidth { get => TextTerminalUI.GetCurrentWidth(); }
        /// <summary>
        /// CurrentHeight for the device resolution.
        /// </summary>
        public int CurrentHeight { get => TextTerminalUI.GetCurrentHeight(); }


        /// <summary>
        /// Current X position for the cursor.
        /// </summary>
        public int CurrentX { get => TextTerminalUI.GetCurrentX(); }
        /// <summary>
        /// Current Y position for the cursor.
        /// </summary>
        public int CurrentY { get => TextTerminalUI.GetCurrentY(); }

        /// <summary>
        /// Controls if the Framework should call ScrollAsync during a Write operation.
        /// If set to false and the text overwrites the display area then the Write operation will end.
        /// If set to true the Framework will make space for the text by calling ScrollAsync.
        /// </summary>
        public bool ScrollingSupported => true;

    }
}