using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.Auxiliaries.Commands;
using XFS4IoT.Auxiliaries.Events;
using XFS4IoT.Auxiliaries.Completions;
using XFS4IoT.Common;

namespace TestClientForms.Devices
{
    public class AuxiliariesDevice : CommonDevice
    {
        public AuxiliariesDevice(string serviceName, TextBox cmdBox, TextBox rspBox, TextBox evtBox, TextBox uriBox, TextBox portBox, TextBox serviceUriBox)
            : base(serviceName, cmdBox, rspBox, evtBox, uriBox, portBox, serviceUriBox, true)
        {
        }

        public Task DoServiceDiscovery()
            => DoServiceDiscovery(new InterfaceClass.NameEnum[] { InterfaceClass.NameEnum.Auxiliaries, InterfaceClass.NameEnum.Lights, InterfaceClass.NameEnum.Common });


        public async Task Register()
        {
            var device = await GetConnection();

            var cmd = new RegisterCommand(RequestId.NewID(), new RegisterCommand.PayloadData(CommandTimeout, HandsetSensor: RegisterCommand.PayloadData.HandsetSensorEnum.Register));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is RegisterCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is AuxiliaryStatusEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                }
            } while (!completed);
        }

        public async Task SetAutoStartupTime(DateTime time, XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum mode)
        {
            var device = await GetConnection();

            var cmd = new SetAutoStartupTimeCommand(RequestId.NewID(), new SetAutoStartupTimeCommand.PayloadData(CommandTimeout, mode, new(time.Year, time.Month, time.DayOfWeek switch
            {
                DayOfWeek.Monday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Monday,
                DayOfWeek.Tuesday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Tuesday,
                DayOfWeek.Wednesday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Wednesday,
                DayOfWeek.Thursday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Thursday,
                DayOfWeek.Friday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Friday,
                DayOfWeek.Saturday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Saturday,
                DayOfWeek.Sunday => XFS4IoT.Auxiliaries.SystemTimeClass.DayOfWeekEnum.Sunday,
                _ => throw new NotImplementedException($"Unexpected DayOfWeek in {nameof(SetAutoStartupTime)}")
            }, time.Day, time.Hour, time.Minute)));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is SetAutoStartupTimeCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is AuxiliaryStatusEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                }
            } while (!completed);
        }

        public async Task ClearAutoStartupTime()
        {
            var device = await GetConnection();

            var cmd = new ClearAutoStartupTimeCommand(RequestId.NewID(), new ClearAutoStartupTimeCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is ClearAutoStartupTimeCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is AuxiliaryStatusEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                }
            } while (!completed);
        }

        public async Task GetAutoStartupTime()
        {
            var device = await GetConnection();

            var cmd = new GetAutoStartupTimeCommand(RequestId.NewID(), new GetAutoStartupTimeCommand.PayloadData(CommandTimeout));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is GetAutoStartupTimeCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is AuxiliaryStatusEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                }
            } while (!completed);
        }

        public async Task SetAuxiliaries()
        {
            var device = await GetConnection();

            var cmd = new SetAuxiliariesCommand(RequestId.NewID(), new SetAuxiliariesCommand.PayloadData(CommandTimeout, Heating: SetAuxiliariesCommand.PayloadData.HeatingEnum.On));

            CmdBox.Text = cmd.Serialise();

            await device.SendCommandAsync(cmd);

            RspBox.Text = string.Empty;
            EvtBox.Text = string.Empty;

            bool completed = false;
            do
            {
                object cmdResponse = await device.ReceiveMessageAsync();
                if (cmdResponse is SetAuxiliariesCompletion response)
                {
                    RspBox.Text = response.Serialise();
                    completed = true;
                }
                else if (cmdResponse is AuxiliaryStatusEvent eventResp)
                {
                    EvtBox.Text = eventResp.Serialise();
                }
            } while (!completed);
        }

    }
}
