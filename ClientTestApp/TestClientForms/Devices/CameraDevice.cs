/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.Common;
using XFS4IoT.Camera.Commands;
using XFS4IoT.Camera.Completions;
using XFS4IoT.Common.Events;
using XFS4IoTServer;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata;

namespace TestClientForms.Devices
{
    internal class CameraDevice : CommonDevice
    {
        public CameraDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
            PreviewWindow = new();
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.Camera, InterfaceClass.NameEnum.Common]);

        private CamPreview PreviewWindow;

        public async Task Reset()
        {
            var cmd = new ResetCommand(RequestId.NewID(), CommandTimeout);

            var device = await GetConnection();

            base.OnXFS4IoTMessages(this, cmd.Serialise());
            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ResetCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task TakePitcure()
        {
            LastBitmap = null;

            var cmd = new TakePictureCommand(
                RequestId.NewID(),
                Payload: new(TakePictureCommand.PayloadData.CameraEnum.Room, "Sample Text"),
                CommandTimeout);

            var device = await GetConnection();

            base.OnXFS4IoTMessages(this, cmd.Serialise());
            await device.SendCommandAsync(cmd);

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is TakePictureCompletion response)
                {
                    base.OnXFS4IoTMessages(this, response.Serialise());
                    completed = true;

                    if (response.Payload.PictureFile?.Count > 0)
                    {
                        using MemoryStream stream = new();
                        stream.Write(response.Payload.PictureFile.ToArray(), 0, response.Payload.PictureFile.ToArray().Length);
                        stream.Seek(0, SeekOrigin.Begin);
                        LastBitmap = new Bitmap(stream);

                        if (PreviewWindow.IsDisposed)
                        {
                            PreviewWindow = new();
                        }
                        
                        PreviewWindow.Show();
                        PreviewWindow.UpdateImage(LastBitmap);
                        PreviewWindow.BringToFront();
                    }
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public Bitmap LastBitmap { get; private set; } = null;
    }
}
