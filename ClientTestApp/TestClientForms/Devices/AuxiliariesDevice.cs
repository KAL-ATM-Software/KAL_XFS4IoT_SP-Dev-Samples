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
using XFS4IoT.Auxiliaries.Commands;
using XFS4IoT.Auxiliaries.Completions;
using XFS4IoT.Common.Events;
using XFS4IoT.Common;

namespace TestClientForms.Devices
{
    public class AuxiliariesDevice : CommonDevice
    {
        public AuxiliariesDevice(string serviceName, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Auxiliaries, InterfaceClass.NameEnum.Lights, InterfaceClass.NameEnum.Common });


        public async Task Register()
        {
            var device = await GetConnection();

            var cmd = new RegisterCommand(RequestId.NewID(), new RegisterCommand.PayloadData(HandsetSensor: RegisterCommand.PayloadData.HandsetSensorEnum.Register), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is RegisterCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task SetAutoStartupTime(DateTime time, XFS4IoT.Auxiliaries.Commands.SetAutoStartUpTimeCommand.PayloadData.ModeEnum mode)
        {
            var device = await GetConnection();

            var cmd = new SetAutoStartUpTimeCommand(RequestId.NewID(), new SetAutoStartUpTimeCommand.PayloadData(mode, new(time.Year, time.Month, time.DayOfWeek switch
            {
                DayOfWeek.Monday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Monday,
                DayOfWeek.Tuesday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Tuesday,
                DayOfWeek.Wednesday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Wednesday,
                DayOfWeek.Thursday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Thursday,
                DayOfWeek.Friday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Friday,
                DayOfWeek.Saturday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Saturday,
                DayOfWeek.Sunday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Sunday,
                _ => throw new NotImplementedException($"Unexpected DayOfWeek in {nameof(SetAutoStartupTime)}")
            }, time.Day, time.Hour, time.Minute)),
            CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is SetAutoStartUpTimeCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task ClearAutoStartupTime()
        {
            var device = await GetConnection();

            var cmd = new ClearAutoStartUpTimeCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ClearAutoStartUpTimeCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task GetAutoStartupTime()
        {
            var device = await GetConnection();

            var cmd = new GetAutoStartUpTimeCommand(RequestId.NewID(), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetAutoStartUpTimeCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

        public async Task SetAuxiliaries()
        {
            var device = await GetConnection();

            var cmd = new SetAuxiliariesCommand(RequestId.NewID(), new SetAuxiliariesCommand.PayloadData(Heating: SetAuxiliariesCommand.PayloadData.HeatingEnum.On), CommandTimeout);

            base.OnXFS4IoTMessages(this, cmd.Serialise());

            await device.SendCommandAsync(cmd);

            
            

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is SetAuxiliariesCompletion response)
                {
                    base.OnXFS4IoTMessages(this,response.Serialise());
                    completed = true;
                }
                else if (cmdResponse is StatusChangedEvent eventResp)
                {
                    base.OnXFS4IoTMessages(this, eventResp.Serialise());
                }
            } while (!completed);
        }

    }
}
