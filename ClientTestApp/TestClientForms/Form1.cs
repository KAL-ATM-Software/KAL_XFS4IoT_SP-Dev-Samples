/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TestClientForms.Devices;

namespace TestClientForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            textBoxServiceURI.Text = "ws://localhost";
            DispenserServiceURI.Text = "ws://localhost";

            DispenserDev = new("Dispenser", DispenserCmdBox, DispenserRspBox, DispenserEvtBox, DispenserServiceURI, DispenserPortNum, DispenserDispURI);
            CardReaderDev = new("CardReader", textBoxCommand, textBoxResponse, textBoxEvent, textBoxServiceURI, textBoxPort, textBoxCardReader);
        }
        
        private DispenserDevice DispenserDev { get; init; }
        private CardReaderDevice CardReaderDev { get; init; }


        private void Form1_Load(object sender, EventArgs e)
        { }

        private async void AcceptCard_Click(object sender, EventArgs e)
        {
            await CardReaderDev.AcceptCard();
        }

        private async void EjectCard_Click(object sender, EventArgs e)
        {
            await CardReaderDev.EjectCard();
        }

        private async void buttonStatus_Click(object sender, EventArgs e)
        {
            var status = await CardReaderDev.GetStatus();

            if (status != null)
            {
                textBoxStDevice.Text = status.Payload?.Common?.Device?.ToString();
                textBoxStMedia.Text = status.Payload?.CardReader?.Media?.ToString();
            }
            else
                MessageBox.Show("Failed to get CardReader status.");
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var capabilities = await CardReaderDev.GetCapabilities();

            if (capabilities != null)
            {
                textBoxDeviceType.Text = capabilities.Payload.CardReader.Type.ToString();
            }
            else
                MessageBox.Show("Failed to get CardReader capabilities.");
        }

        private async void ServiceDiscovery_Click(object sender, EventArgs e)
        {
            await CardReaderDev.DoServiceDiscovery();
        }
        private async void CaptureCard_Click(object sender, EventArgs e)
        {
            await CardReaderDev.CaptureCard();
        }


        #region Dispenser Tab

        private async void DispenserServiceDiscovery_Click(object sender, EventArgs e)
        {
            await DispenserDev.DoServiceDiscovery();
        }

        private async void DispenserGetCashUnitInfo_Click(object sender, EventArgs e)
        {
            await DispenserDev.GetCashUnitInfo();
        }

        private async void DispenserStatus_Click(object sender, EventArgs e)
        {
            var status = await DispenserDev.GetStatus();
            if (status != null)
                DispenserStDevice.Text = status.Payload?.Common?.Device?.ToString();
        }

        private async void DispenserCapabilities_Click(object sender, EventArgs e)
        {
            var capabilities = await DispenserDev.GetCapabilities();
            if (capabilities != null)
                DispenserDeviceType.Text = capabilities.Payload?.CashDispenser?.Type?.ToString();
        }

        private async void DispenserGetMixTypes_Click(object sender, EventArgs e)
        {
            await DispenserDev.GetMixTypes();
        }

        private async void DispenserGetPresentStatus_Click(object sender, EventArgs e)
        {
            await DispenserDev.GetPresentStatus();
        }

        private async void DispenserReset_Click(object sender, EventArgs e)
        {
            await DispenserDev.Reset();
        }

        private async void DispenserStartExchange_Click(object sender, EventArgs e)
        {
            await DispenserDev.StartExchange();
        }

        private async void DispenserEndExchange_Click(object sender, EventArgs e)
        {
            await DispenserDev.EndExchange();
        }

        private async void DispenserPresent_Click(object sender, EventArgs e)
        {
            await DispenserDev.Present();
        }

        private async void DispenserDenominate_Click(object sender, EventArgs e)
        {
            await DispenserDev.Denominate();
        }

        private async void DispenserDispense_Click(object sender, EventArgs e)
        {
            await DispenserDev.Dispense();
        }

        private async void DispenserOpenShutter_Click(object sender, EventArgs e)
        {
            await DispenserDev.OpenShutter();
        }

        private async void DispenserCloseShutter_Click(object sender, EventArgs e)
        {
            await DispenserDev.CloseShutter();
        }

        #endregion

        private async void DispenserReject_Click(object sender, EventArgs e)
        {
            await DispenserDev.Reject();
        }

        private async void DispenserRetract_Click(object sender, EventArgs e)
        {
            await DispenserDev.Retract();
        }
    }
}
