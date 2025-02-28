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
using XFS4IoT.Lights.Commands;
using XFS4IoT.Lights.Completions;

namespace TestClientForms.Devices
{
    internal class LightsDevice : CommonDevice
    {
        public LightsDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery([InterfaceClass.NameEnum.Lights, InterfaceClass.NameEnum.Common]);


        public async Task SetLight(string lightName, XFS4IoT.Lights.PositionStatusClass.FlashRateEnum flashRate)
        {
            var lights = new XFS4IoTClient.ClientConnection(new Uri($"{ServiceUriBox.Text}"));

            try
            {
                await lights.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            XFS4IoT.Lights.PositionStatusClass pos = new(flashRate, XFS4IoT.Lights.PositionStatusClass.ColorEnum.Red);
            Dictionary<string, XFS4IoT.Lights.PositionStatusClass> device = new() { { "center", pos } };

            var payload = new SetLightCommand.PayloadData(CardReader: device);

            var cmd = new SetLightCommand(RequestId.NewID(), payload, CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            object cmdResponse = await SendAndWaitForCompletionAsync(lights, cmd);
            if (cmdResponse is SetLightCompletion response)
            {
                base.OnXFS4IoTMessages(this,response.Serialise());
            }
        }
    }
}
