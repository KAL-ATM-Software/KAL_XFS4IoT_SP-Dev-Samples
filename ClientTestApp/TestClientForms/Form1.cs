/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;
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
            TextTerminalServiceURI.Text = "ws://localhost";
            EncryptorServiceURI.Text = "ws://localhost";
            PinPadServiceURI.Text = "ws://localhost";

            DispenserDev = new("Dispenser", DispenserCmdBox, DispenserRspBox, DispenserEvtBox, DispenserServiceURI, DispenserPortNum, DispenserDispURI);
            TextTerminalDev = new("TextTerminal", TextTerminalCmdBox, TextTerminalRspBox, TextTerminalEvtBox, TextTerminalServiceURI, TextTerminalPortNum, TextTerminalURI);
            CardReaderDev = new("CardReader", textBoxCommand, textBoxResponse, textBoxEvent, textBoxServiceURI, textBoxPort, textBoxCardReader);
            EncryptorDev = new("Encryptor", EncryptorCmdBox, EncryptorRspBox, EncryptorEvtBox, EncryptorServiceURI, EncryptorPortNum, EncryptorURI);
            PinPadDev = new("PinPad", PinPadCmdBox, PinPadRspBox, PinPadEvtBox, PinPadServiceURI, PinPadPortNum, PinPadURI);
        }
        
        private DispenserDevice DispenserDev { get; init; }
        private CardReaderDevice CardReaderDev { get; init; }
        private TextTerminalDevice TextTerminalDev { get; init; }
        private EncryptorDevice EncryptorDev { get; init; }
        private PinPadDevice PinPadDev { get; init; }

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
        private async void DispenserReject_Click(object sender, EventArgs e)
        {
            await DispenserDev.Reject();
        }

        private async void DispenserRetract_Click(object sender, EventArgs e)
        {
            await DispenserDev.Retract();
        }

        #endregion

        #region TextTerminal Tab

        private async void TextTerminalServiceDiscovery_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.DoServiceDiscovery();
        }

        private async void TextTerminalStatus_Click(object sender, EventArgs e)
        {
            var status = await TextTerminalDev.GetStatus();
            if (status != null)
                TextTerminalStDevice.Text = status.Payload?.Common?.Device?.ToString();

        }

        private async void TextTerminalCapabilities_Click(object sender, EventArgs e)
        {
            var capabilities = await TextTerminalDev.GetCapabilities();
            if (capabilities != null)
                TextTerminalDeviceType.Text = capabilities.Payload?.TextTerminal?.Type?.ToString();
        }

        private async void TextTerminalClearScreen_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.ClearScreen();
        }

        private async void TextTerminalWrite_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.Write();
        }

        private async void TextTerminalRead_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.Read();
        }

        private async void TextTerminalGetKeyDetail_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.GetKeyDetail();
        }

        private async void TextTerminalBeep_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.Beep();
        }

        private async void TextTerminalReset_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.Reset();
        }

        private async void TextTerminalSetResolution_Click(object sender, EventArgs e)
        {
            await TextTerminalDev.SetResolution();
        }

        #endregion

        #region Encryptor Tab

        private async void EncryptorServiceDiscovery_Click(object sender, EventArgs e)
        {
            await EncryptorDev.DoServiceDiscovery();
        }

        private async void EncryptorStatus_Click(object sender, EventArgs e)
        {
            var result = await EncryptorDev.GetStatus();
            if (result is not null)
                EncryptorStDevice.Text = result.Payload?.Common?.Device?.ToString();

        }

        private async void EncryptorCapabilities_Click(object sender, EventArgs e)
        {
            var result = await EncryptorDev.GetCapabilities();
            if (result is not null)
                EncryptorMaxKeyNum.Text = result.Payload?.KeyManagement?.KeyNum?.ToString();
        }

        private async void EncryptorGetKeyNames_Click(object sender, EventArgs e)
        {
            EncryptorKeyNamelistBox.Items.Clear();

            var result = await EncryptorDev.GetKeyNames();
            if (result is not null &&
                result.Payload is not null &&
                result.Payload.KeyDetails is not null)
            {
                foreach (var keyName in result.Payload.KeyDetails)
                {
                    EncryptorKeyNamelistBox.Items.Add(keyName.Key);
                }
            }
        }

        private async void EncryptorInitialization_Click(object sender, EventArgs e)
        {
            await EncryptorDev.Initialization();
        }

        private async void EncryptorImportKey_Click(object sender, EventArgs e)
        {
            List<byte> data = new() { 0xb1, 0x88, 0x68, 0x12, 0x3c, 0x16, 0x57, 0x9f, 0x52, 0x78, 0x3f, 0x2e, 0x5a, 0x00, 0x1f, 0xfe };
            await EncryptorDev.LoadKey("CryptKey", "D0", "E", data); 
            await EncryptorDev.LoadKey("MACKey", "M0", "G", data); 
        }
        private async void EncryptorReset_Click(object sender, EventArgs e)
        {
            await EncryptorDev.Reset(); 
        }

        private async void EncryptorEncrypt_Click(object sender, EventArgs e)
        {
            List<byte> data = new() { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8 };
            await EncryptorDev.Encrypt("CryptKey", data); 
        }

        private async void EncryptorDeleteKey_Click(object sender, EventArgs e)
        {
            int index = EncryptorKeyNamelistBox.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Select key name to delete.");
                return;
            }

            string keyName = (string)EncryptorKeyNamelistBox.Items[index];
            if (keyName != "CryptKey" &&
                keyName != "MACKey")
            {
                MessageBox.Show("Only CryptKey or MACKey can be deleted.");
                return;
            }

            await EncryptorDev.DeleteKey(keyName); 
        }

        private async void EncryptorGenerateMAC_Click(object sender, EventArgs e)
        {
            List<byte> data = new() { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8 };
            await EncryptorDev.GenerateMAC("MACKey", data); 
        }

        private async void EncryptorGenerateRandom_Click(object sender, EventArgs e)
        {
            await EncryptorDev.GenerateRandom(); 
        }

        #endregion

        #region PinPad Tab
        private async void PinPadServiceDiscovery_Click(object sender, EventArgs e)
        {
            await PinPadDev.DoServiceDiscovery();
        }

        private async void PinPadStatus_Click(object sender, EventArgs e)
        {
            var result = await PinPadDev.GetStatus();
            if (result is not null)
                PinPadStDevice.Text = result.Payload?.Common?.Device?.ToString();
        }

        private async void PinPadCapabilities_Click(object sender, EventArgs e)
        {
            var result = await PinPadDev.GetCapabilities();
            if (result is not null)
                PinPadMaxKeyNum.Text = result.Payload?.KeyManagement?.KeyNum?.ToString();
        }

        private async void PinPadInitialization_Click(object sender, EventArgs e)
        {
            await PinPadDev.Initialization();
        }

        private async void PinPadDeleteKey_Click(object sender, EventArgs e)
        {
            int index = PinPadKeyNamelistBox.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Select key name to delete.");
                return;
            }

            string keyName = (string)PinPadKeyNamelistBox.Items[index];

            await PinPadDev.DeleteKey(keyName); 
        }

        private async void PinPadReset_Click(object sender, EventArgs e)
        {
            await PinPadDev.Reset(); 
        }

        private async void PinPadEnterData_Click(object sender, EventArgs e)
        {
            await PinPadDev.GetData();
        }

        private async void PinPadGetKeyNames_Click(object sender, EventArgs e)
        {
            PinPadKeyNamelistBox.Items.Clear();

            var result = await PinPadDev.GetKeyNames();
            if (result is not null &&
                result.Payload is not null &&
                result.Payload.KeyDetails is not null)
            {
                foreach (var keyName in result.Payload.KeyDetails)
                {
                    PinPadKeyNamelistBox.Items.Add(keyName.Key);
                }
            }
        }

        private async void PinPadSecureKeyEntryPart1_Click(object sender, EventArgs e)
        {
            await PinPadDev.SecureKeyEntryPart1();
        }

        private async void PinPadSecureKeyEntryPart2_Click(object sender, EventArgs e)
        {
            await PinPadDev.SecureKeyEntryPart2();
        }

        private async void PinPadImportKey_Click(object sender, EventArgs e)
        {
            await PinPadDev.ImportAssmblyKey();
        }

        private async void PinPadLoadPinKey_Click(object sender, EventArgs e)
        {
            List<byte> data = new() { 0xb1, 0x88, 0x68, 0x12, 0x3c, 0x16, 0x57, 0x9f, 0x52, 0x78, 0x3f, 0x2e, 0x5a, 0x00, 0x1f, 0xfe };
            await PinPadDev.LoadKey("PinKey", "P0", "E", data); 
        }

        private async void PinPadEnterPin_Click(object sender, EventArgs e)
        {
            await PinPadDev.PinEntry();
        }

        private async void PinPadFormatPin_Click(object senser, EventArgs e)
        {
            await PinPadDev.FormatPin();
        }

        private async void PinPadGetLayout_Click(object sender, EventArgs e)
        {
            await PinPadDev.GetLayout();
        }

        #endregion

        
    }
}
