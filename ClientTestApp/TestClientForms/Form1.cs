/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
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
using System.IO;
using System.Drawing;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

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
            PrinterServiceURI.Text = "ws://localhost";
            LightsServiceURI.Text = "ws://localhost";
            AuxiliariesServiceURI.Text = "ws://localhost";
            VendorModeServiceURI.Text = "ws://localhost";
            VendorAppServiceURI.Text = "ws://localhost";
            BarcodeReaderServiceURI.Text = "ws://localhost";
            BiometricServiceURI.Text = "ws://localhost";
            CashAcceptorServiceURI.Text = "ws://localhost";

            CashDispenserDev = new("CashDispenser", DispenserServiceURI, DispenserPortNum, DispenserDispURI);
            TextTerminalDev = new("TextTerminal", TextTerminalServiceURI, TextTerminalPortNum, TextTerminalURI);
            CardReaderDev = new("CardReader", textBoxServiceURI, textBoxPort, textBoxCardReader);
            EncryptorDev = new("Encryptor", EncryptorServiceURI, EncryptorPortNum, EncryptorURI);
            PinPadDev = new("PinPad", PinPadServiceURI, PinPadPortNum, PinPadURI);
            PrinterDev = new("Printer", PrinterServiceURI, PrinterPortNum, PrinterURI);
            LightsDev = new("Lights", LightsServiceURI, LightsPortNum, LightsURI);
            AuxDev = new("Auxiliaries", AuxiliariesServiceURI, AuxiliariesPortNum, AuxiliariesURI);
            VendorModeDev = new("VendorMode", VendorModeServiceURI, VendorModePortNum, VendorModeURI);
            VendorAppDev = new("VendorApplication", VendorAppServiceURI, VendorAppPortNum, VendorAppURI);
            BarcodeReaderDev = new("BarcodeReader", BarcodeReaderServiceURI, BarcodeReaderPortNum, BarcodeReaderURI);
            BiometricDev = new("Biometric", BiometricServiceURI, BiometricPortNum, BiometricURI);
            CashAcceptorDev = new("CashAcceptor", CashAcceptorServiceURI, CashAcceptorPortNum, CashAcceptorAccURI);

            LightsFlashRate.DataSource = Enum.GetValues(typeof(XFS4IoT.Lights.LightStateClass.FlashRateEnum));
            LightsFlashRate.SelectedItem = XFS4IoT.Lights.LightStateClass.FlashRateEnum.Continuous;

            comboAutoStartupModes.DataSource = Enum.GetValues(typeof(XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum));
            comboAutoStartupModes.SelectedItem = XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum.Clear;
        }

                

        private CashDispenserDevice CashDispenserDev { get; init; }
        private CardReaderDevice CardReaderDev { get; init; }
        private TextTerminalDevice TextTerminalDev { get; init; }
        private EncryptorDevice EncryptorDev { get; init; }
        private PinPadDevice PinPadDev { get; init; }
        private PrinterDevice PrinterDev { get; init; }
        private LightsDevice LightsDev { get; init; }
        private AuxiliariesDevice AuxDev { get; init; }
        private VendorModeDevice VendorModeDev { get; init; }
        private VendorAppDevice VendorAppDev { get; init; }
        private BarcodeReaderDevice BarcodeReaderDev { get; init; }
        private BiometricDevice BiometricDev { get; init; }
        private CashAcceptorDevice CashAcceptorDev { get; init; }





        #region init Form Windows

        private void Form1_Load(object sender, EventArgs e)
        {            
            this.FormClosing += Form1_FormClosing;
            RegisterEvents(true);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegisterEvents(false);
        }

        private void RegisterEvents(bool bRegister = true)
        {
            try
            {
                if (bRegister)
                {
                    cashDispenserTreeView.AfterSelect += TreeView_AfterSelect;
                    textTerminalTreeView.AfterSelect += TreeView_AfterSelect;
                    cardReaderTreeView.AfterSelect += TreeView_AfterSelect;
                    encryptorTreeView.AfterSelect += TreeView_AfterSelect;
                    pinPadTreeView.AfterSelect += TreeView_AfterSelect;
                    printerTreeView.AfterSelect += TreeView_AfterSelect;
                    lightsTreeView.AfterSelect += TreeView_AfterSelect;
                    auxiliariesTreeView.AfterSelect += TreeView_AfterSelect;
                    vendorModeTreeView.AfterSelect += TreeView_AfterSelect;
                    vendorApplicationTreeView.AfterSelect += TreeView_AfterSelect;
                    barcodeReaderTreeView.AfterSelect += TreeView_AfterSelect;
                    biometricTreeView.AfterSelect += TreeView_AfterSelect;
                    cashAcceptorTreeView.AfterSelect += TreeView_AfterSelect;

                    CashDispenserDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    TextTerminalDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    CardReaderDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    EncryptorDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    PinPadDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    PrinterDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    LightsDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    AuxDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    VendorModeDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    VendorAppDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    BarcodeReaderDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    BiometricDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    CashAcceptorDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                }
                else
                {
                    cashDispenserTreeView.AfterSelect -= TreeView_AfterSelect;
                    textTerminalTreeView.AfterSelect -= TreeView_AfterSelect;
                    cardReaderTreeView.AfterSelect -= TreeView_AfterSelect;
                    encryptorTreeView.AfterSelect -= TreeView_AfterSelect;
                    pinPadTreeView.AfterSelect -= TreeView_AfterSelect;
                    printerTreeView.AfterSelect -= TreeView_AfterSelect;
                    lightsTreeView.AfterSelect -= TreeView_AfterSelect;
                    auxiliariesTreeView.AfterSelect -= TreeView_AfterSelect;
                    vendorModeTreeView.AfterSelect -= TreeView_AfterSelect;
                    vendorApplicationTreeView.AfterSelect -= TreeView_AfterSelect;
                    barcodeReaderTreeView.AfterSelect -= TreeView_AfterSelect;
                    biometricTreeView.AfterSelect -= TreeView_AfterSelect;
                    cashAcceptorTreeView.AfterSelect -= TreeView_AfterSelect;

                    CashDispenserDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    TextTerminalDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    CardReaderDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    EncryptorDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    PinPadDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    PrinterDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    LightsDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    AuxDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    VendorModeDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    VendorAppDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    BarcodeReaderDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    BiometricDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    CashAcceptorDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"'RegisterEvents' method exception {Environment.NewLine} {ex.Message}");
            }
        }
        #endregion


        #region CardReader
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

        private async void Reset_Click(object sender, EventArgs e)
        {
            await CardReaderDev.Reset();
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

        private async void GetStorage_Click(object sender, EventArgs e)
        {
            await CardReaderDev.GetStorage();
        }

        private async void ResetBinCount_Click(object sender, EventArgs e)
        {
            await CardReaderDev.ResetBinCount();
        }
        #endregion

        #region CashDispenser

        private async void DispenserServiceDiscovery_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.DoServiceDiscovery();
        }

        private async void DispenserGetCashUnitInfo_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.GetCashUnitInfo();
        }

        private async void DispenserStatus_Click(object sender, EventArgs e)
        {
            var status = await CashDispenserDev.GetStatus();
            DispenserStDevice.Text = status?.Payload?.Common?.Device?.ToString();
        }

        private async void DispenserCapabilities_Click(object sender, EventArgs e)
        {
            var capabilities = await CashDispenserDev.GetCapabilities();
            DispenserDeviceType.Text = capabilities?.Payload?.CashDispenser?.Type?.ToString();
        }

        private async void DispenserGetMixTypes_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.GetMixTypes();
        }

        private async void DispenserGetPresentStatus_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.GetPresentStatus();
        }

        private async void DispenserReset_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Reset();
        }

        private async void DispenserStartExchange_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.StartExchange();
        }

        private async void DispenserEndExchange_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.EndExchange();
        }

        private async void DispenserPresent_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Present();
        }

        private async void DispenserDenominate_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Denominate();
        }

        private async void DispenserDispense_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Dispense(TokenTextBox.Text);
        }

        private async void DispenserOpenShutter_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.OpenShutter();
        }

        private async void DispenserCloseShutter_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.CloseShutter();
        }
        private async void DispenserReject_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Reject();
        }

        private async void DispenserRetract_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.Retract();
        }

        private async void SetCashUnitInfo_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.SetCashUnitInfo();
        }

        private async void DispenserGetCommandNonce_Click(object sender, EventArgs e)
        {
            string Nonce = await CashDispenserDev.GetCommandNonce();
            TokenTextBox.Text = Nonce;
        }

        private async void DispenserClearCommandNonce_Click(object sender, EventArgs e)
        {
            await CashDispenserDev.ClearCommandNonce();
        }


        #endregion

        #region TextTerminal

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

        #region Encryptor

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

        #region PinPad
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

        #region Printer
        private async void PrinterStatus_Click(object sender, EventArgs e)
        {
            var status = await PrinterDev.GetStatus();

            if (status != null)
            {
                PrinterStDevice.Text = status.Payload?.Common?.Device?.ToString();
            }
            else
                MessageBox.Show("Failed to get Printer status.");
        }

        private async void PrinterCapabilities_Click(object sender, EventArgs e)
        {
            var caps = await PrinterDev.GetCapabilities();
            if (caps != null)
            {
                PrinterType.Text = string.Empty;
                if (caps.Payload?.Printer?.Type?.Receipt is not null && (bool)caps.Payload?.Printer?.Type?.Receipt)
                {
                    PrinterType.Text = "Receipt";
                }
                else if (caps.Payload?.Printer?.Type?.Journal is not null && (bool)caps.Payload?.Printer?.Type?.Journal)
                {
                    PrinterType.Text = "Journal";
                }
                else if (caps.Payload?.Printer?.Type?.Passbook is not null && (bool)caps.Payload?.Printer?.Type?.Passbook)
                {
                    PrinterType.Text = "Passbook";
                }
                else if (caps.Payload?.Printer?.Type?.Scanner is not null && (bool)caps.Payload?.Printer?.Type?.Scanner)
                {
                    PrinterType.Text = "Scanner";
                }
            }
            else
                MessageBox.Show("Failed to get Printer status.");
        }

        private async void PrinterGetFormList_Click(object sender, EventArgs e)
        {
            var result = await PrinterDev.GetFormList();
            PrinterFormListBox.Items.Clear();

            if (result is not null &&
                result.Payload is not null &&
                result.Payload.FormList is not null)
            {
                foreach (var name in result.Payload.FormList)
                {
                    PrinterFormListBox.Items.Add(name);
                }
            }
        }

        private async void PrinterQueryForm_Click(object sender, EventArgs e)
        {
            int index = PrinterFormListBox.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Select form name to query.");
                return;
            }

            string selectedForm = (string)PrinterFormListBox.Items[index];
            await PrinterDev.GetQueryForm(selectedForm);
        }

        private async void PrinterGetMediaList_Click(object sender, EventArgs e)
        {
            var result = await PrinterDev.GetMediaList();
            PrinterMediaListBox.Items.Clear();

            if (result is not null &&
                result.Payload is not null &&
                result.Payload.MediaList is not null)
            {
                foreach (var name in result.Payload.MediaList)
                {
                    PrinterMediaListBox.Items.Add(name);
                }
            }
        }

        private async void PrinterQueryMedia_Click(object sender, EventArgs e)
        {
            int index = PrinterMediaListBox.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Select media name to query.");
                return;
            }

            string selectedMedia = (string)PrinterMediaListBox.Items[index];
            await PrinterDev.GetQueryMedia(selectedMedia);
        }

        private async void PrinterPrintForm_Click(object sender, EventArgs e)
        {
            int formIndex = PrinterFormListBox.SelectedIndex;
            if (formIndex < 0)
            {
                MessageBox.Show("Select form name name to print.");
                return;
            }

            string selectedForm = (string)PrinterFormListBox.Items[formIndex];

            int mediaIndex = PrinterMediaListBox.SelectedIndex;
            if (mediaIndex < 0)
            {
                MessageBox.Show("Select media name name to print.");
                return;
            }

            string selectedMedia = (string)PrinterMediaListBox.Items[mediaIndex];

            Dictionary<string, string> fields = new();
            if (!string.IsNullOrWhiteSpace(PrinterFormFields.Text))
            {
                string[] pairs = PrinterFormFields.Text.Split(',');
                foreach (string pair in pairs)
                {
                    var split = pair.Split('=');
                    if (split.Length != 2)
                    {
                        MessageBox.Show($"Invalid form field \"{pair}\"");
                        return;
                    }
                    fields.Add(split[0], split[1]);
                }
            }

            await PrinterDev.PrintForm(selectedForm, selectedMedia, fields);
        }

        private async void PrinterEject_Click(object sender, EventArgs e)
        {
            await PrinterDev.Eject();
        }

        private async void PrinterPrintRaw_Click(object sender, EventArgs e)
        {
            string testPrintData = "TEST PRINT";
            await PrinterDev.PrintRaw(System.Text.Encoding.ASCII.GetBytes(testPrintData));
        }

        private async void PrinterReset_Click(object sender, EventArgs e)
        {
            await PrinterDev.Reset();
        }

        private async void PrinterServiceDiscovery_Click(object sender, EventArgs e)
        {
            await PrinterDev.DoServiceDiscovery();
        }

        private async void PrinterLoadDefinition_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Title = "Select definition file to load."
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(ofd.FileName))
                    return;

                string contents = await File.ReadAllTextAsync(ofd.FileName);
                await PrinterDev.DoLoadDefinition(contents);
            }
        }
        #endregion

        #region Lights
        private async void LightsStatus_Click(object sender, EventArgs e)
        {
            var status = await LightsDev.GetStatus();
            lblLightsStatus.Text = status?.Payload?.Common?.Device.ToString() ?? string.Empty;
        }

        private async void LightsCapabilities_Click(object sender, EventArgs e)
        {
            await LightsDev.GetCapabilities();
        }

        private async void LightsSetLight_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLightName.Text))
            {
                MessageBox.Show("Light name must be specified.");
                return;
            }

            await LightsDev.SetLight(txtLightName.Text, (XFS4IoT.Lights.LightStateClass.FlashRateEnum)LightsFlashRate.SelectedItem);
        }

        private async void LightsServiceDiscovery_Click(object sender, EventArgs e)
        {
            await LightsDev.DoServiceDiscovery();
        }
        #endregion

        #region Auxiliaries
        private async void btnAuxiliariesServiceDiscovery_Click(object sender, EventArgs e)
        {
            await AuxDev.DoServiceDiscovery();
        }

        private async void btnAuxiliariesStatus_Click(object sender, EventArgs e)
        {
            var status = await AuxDev.GetStatus();
            AuxiliariesStatus.Text = status?.Payload?.Common?.Device.ToString() ?? string.Empty;
        }

        private async void btnAuxiliariesCapabilities_Click(object sender, EventArgs e)
        {
            await AuxDev.GetCapabilities();
        }

        private async void btnSetAutoStartup_Click(object sender, EventArgs e)
        {
            await AuxDev.SetAutoStartupTime(autoStartupDateTime.Value, (XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum)comboAutoStartupModes.SelectedItem);
        }

        private async void btnGetAutoStartup_Click(object sender, EventArgs e)
        {
            await AuxDev.GetAutoStartupTime();
        }

        private async void btnClearAutoStartup_Click(object sender, EventArgs e)
        {
            await AuxDev.ClearAutoStartupTime();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            await AuxDev.Register();
        }

        private async void btnSetAuxiliaries_Click(object sender, EventArgs e)
        {
            await AuxDev.SetAuxiliaries();
        }
        #endregion

        #region VendorMode

        private async void btnVendorModeServiceDiscovery_Click(object sender, EventArgs e)
        {
            await VendorModeDev.DoServiceDiscovery();
        }

        private async void btnVendorModeStatus_Click(object sender, EventArgs e)
        {
            var status = await VendorModeDev.GetStatus();
            VendorModeStStatus.Text = status?.Payload?.Common?.Device?.ToString() ?? string.Empty;
            VendorModeServiceStatus.Text = status?.Payload?.VendorMode?.Service?.ToString() ?? string.Empty;
        }

        private async void buttonVDMEnter_Click(object sender, EventArgs e)
        {
            await VendorModeDev.EnterModeRequest();
        }

        private async void buttonVDMExit_Click(object sender, EventArgs e)
        {
            await VendorModeDev.ExitModeRequest();
        }

        #endregion

        #region VendorApp
        private async void btnVendorAppServiceDiscovery_Click(object sender, EventArgs e)
        {
            await VendorAppDev.DoServiceDiscovery();
        }

        private async void btnVendorAppStatus_Click(object sender, EventArgs e)
        {
            var status = await VendorAppDev.GetStatus();
            VendorAppStatus.Text = status?.Payload?.Common?.Device?.ToString() ?? string.Empty;
        }

        private async void btnVendorAppCapabilities_Click(object sender, EventArgs e)
        {
            await VendorAppDev.GetCapabilities();
        }

        private async void buttonStartLocalApplication_Click(object sender, EventArgs e)
        {
            await VendorAppDev.StartLocalApplication(textAppName.Text);
        }

        private async void buttonGetActiveInterface_Click(object sender, EventArgs e)
        {
            var activeInterface = await VendorAppDev.GetActiveInterface();
            textActiveInterface.Text = activeInterface?.Payload.ActiveInterface.ToString();
        }

        #endregion

        #region BarcodeReader
        private async void btnBarcodeReaderServiceDiscovery_Click(object sender, EventArgs e)
        {
            await BarcodeReaderDev.DoServiceDiscovery();
        }

        private async void BarcodeReaderStatus_Click(object sender, EventArgs e)
        {
            var status = await BarcodeReaderDev.GetStatus();
            BarcodeReaderStDevice.Text = status?.Payload?.Common?.Device?.ToString() ?? string.Empty;
            BarcodeReaderScannerStatus.Text = status?.Payload?.BarcodeReader?.Scanner?.ToString() ?? string.Empty;
        }

        private async void BarcodeReaderCapabilities_Click(object sender, EventArgs e)
        {
            await BarcodeReaderDev.GetCapabilities();
        }

        private async void BarcodeReaderRead_Click(object sender, EventArgs e)
        {
            await BarcodeReaderDev.Read();
        }

        private async void BarcodeReaderReset_Click(object sender, EventArgs e)
        {
            await BarcodeReaderDev.Reset();
        }
        #endregion

        #region Biometric
        private async void btnBiometricStatus_Click(object sender, EventArgs e)
        {
            var status = await BiometricDev.GetStatus();
            BiometricStatus.Text = status?.Payload?.Common?.Device?.ToString() ?? "";
        }

        private async void btnBiometricCapabilities_Click(object sender, EventArgs e)
        {
            var capabilities = await BiometricDev.GetCapabilities();
        }

        private async void btnBiometricClear_Click(object sender, EventArgs e)
        {
            await BiometricDev.Clear();
        }

        private async void btnBiometricRead_Click(object sender, EventArgs e)
        {
            txtBiometricTemplateData.Text = "";
            var read = await BiometricDev.Read();

            txtBiometricTemplateData.Text = read;
        }

        private async void btnBiometricMatch_Click(object sender, EventArgs e)
        {
            if (BiometricStorageInfo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(BiometricStorageInfo.SelectedItem as string))
            {
                MessageBox.Show("Select template to match with.");
                return;
            }
            await BiometricDev.Match(BiometricStorageInfo.SelectedItem as string);
        }

        private async void btnBiometricReset_Click(object sender, EventArgs e)
        {
            await BiometricDev.Reset();
        }

        private async void btnBiometricImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBiometricTemplateData.Text))
            {
                MessageBox.Show("Must call Read(Scan) first to get template data for import.");
                return;
            }

            await BiometricDev.Import(txtBiometricTemplateData.Text);
        }

        private async void btnBiometricServiceDiscovery_Click(object sender, EventArgs e)
        {
            await BiometricDev.DoServiceDiscovery();
        }

        private async void btnBiometricReadMatch_Click(object sender, EventArgs e)
        {
            await BiometricDev.ReadMatch();
        }

        private async void btnBiometricGetStorageInfo_Click(object sender, EventArgs e)
        {
            var storageInfo = await BiometricDev.GetStorageInfo();
            BiometricStorageInfo.Items.Clear();
            foreach (var item in storageInfo)
                BiometricStorageInfo.Items.Add(item);
        }
        #endregion

        #region CashAcceptor
        private async void CashAcceptorServiceDiscovery_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.DoServiceDiscovery();
        }

        private async void CashAccStatus_Click(object sender, EventArgs e)
        {
            var status = await CashAcceptorDev.GetStatus();
            CashAccStDevice.Text = status?.Payload?.Common?.Device?.ToString() ?? "";
        }

        private async void CashAccCapabilities_Click(object sender, EventArgs e)
        {
            var capabilities = await CashAcceptorDev.GetCapabilities();
            CashAccDeviceType.Text = capabilities?.Payload?.CashAcceptor?.Type?.ToString();
        }

        private async void CashAccSetCashUnitInfo_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.SetCashUnitInfo();
        }

        private async void CashAccGetCashUnitInfo_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.GetCashUnitInfo();
        }

        private async void CashAccPositionCapabilities_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.GetPositionCapabilities();
        }

        private async void CashAccCashInStatus_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.GetCashInStatus();
        }

        private async void CashAccReset_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.Reset();
        }

        private async void CashAccConfigureNoteTypes_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.ConfigureBanknoteTypes();
        }

        private async void CashAccCashInStart_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.CashInStart();
        }

        private async void CashAccRetract_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.Retract();
        }

        private async void CashAccStartExchange_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.StartExchange();
        }

        private async void CashAccEndExchange_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.EndExchange();
        }

        private async void CashAccCashIn_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.CashIn();
        }

        private async void CashAccCashInEnd_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.CashInEnd();
        }

        private async void CashAccCashInRollback_Click(object sender, EventArgs e)
        {
            await CashAcceptorDev.CashInRollback();
        }
        #endregion


        #region TreeViews manage 
        private void LoadXFS4IoTMsgToTreeView(System.Windows.Forms.TreeView jsonTreeView, string jsonString)
        {
            try
            {
                if (jsonTreeView != null)
                {
                    // Deserializza il testo JSON in un oggetto JObject
                    JObject jsonObject = JObject.Parse(jsonString);
                    (string Description, Color FontColor) tDecoration = NodeDecoration(jsonObject);
                    // Aggiunge un nodo radice alla TreeView
                    TreeNode rootNode = new TreeNode($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}] {tDecoration.Description}");
                    rootNode.Tag = (JToken)jsonObject;
                    rootNode.ForeColor = tDecoration.FontColor;
                    jsonTreeView.Nodes.Add(rootNode);

                    // Aggiunge l'albero JSON come sottoalbero del nodo radice
                    AddNode(jsonObject, rootNode);

                    if (jsonTreeView.Nodes.Count > 0)
                    {
                        jsonTreeView.SelectedNode = jsonTreeView.Nodes[jsonTreeView.Nodes.Count - 1];
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"'LoadXFS4IoTMsgToTreeView' method exception {Environment.NewLine} {ex.Message}");
            }
        }

        private (string Description, Color FontColor) NodeDecoration(JToken jsonObject)
        {
            (string Description, Color FontColor) tDecoration = ("unknown", Color.Red);

            try
            {
                JToken jHeader = jsonObject["header"];

                switch (jHeader["type"].ToString())
                {
                    case "command":
                        tDecoration.FontColor = Color.Black;
                        break;
                    case "completion":
                        tDecoration.FontColor = Color.Blue;
                        break;
                    case "event":
                        tDecoration.FontColor = Color.Orange;
                        break;
                    default:
                        break;
                }

                tDecoration.Description = $"{jHeader["name"]} - {jHeader["type"]} - {jHeader["requestId"]}";
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"'NodeDecoration' method exception {Environment.NewLine} {ex.Message}");
            }

            return tDecoration;
        }

        private void AddNode(JToken token, TreeNode parentNode)
        {
            try
            {
                switch (token.Type)
                {
                    case JTokenType.Object:
                        JObject obj = (JObject)token;
                        // for each object property add a new tree node 
                        // for primitive type show the keypair 'property : bvalue' on node description
                        foreach (JProperty childProperty in obj.Properties())
                        {
                            string descriptioNode = childProperty.Name;
                            if (IsPrimitiveType(childProperty.Value.Type))
                                descriptioNode += $" : {childProperty.Value}";

                            TreeNode childNode = new TreeNode(descriptioNode);
                            childNode.Tag = childProperty.Value;
                            parentNode.Nodes.Add(childNode);

                            if (!IsPrimitiveType(childProperty.Value.Type))
                                AddNode(childProperty.Value, childNode);
                        }
                        break;

                    case JTokenType.Array:
                        JArray array = (JArray)token;
                        // for each array element add a new tree node 
                        for (int i = 0; i < array.Count; i++)
                        {
                            TreeNode childNode = new TreeNode("[" + i + "]");
                            childNode.Tag = array[i];
                            parentNode.Nodes.Add(childNode);

                            AddNode(array[i], childNode);
                        }
                        break;

                    case JTokenType.Property:
                        /*
                        JProperty property = (JProperty)token;
                        TreeNode propertyNode = new TreeNode(property.Name);
                        propertyNode.Tag = property.Value;
                        parentNode.Nodes.Add(propertyNode);

                        AddNode(property.Value, propertyNode);*/
                        break;

                    case JTokenType.String:
                    case JTokenType.Integer:
                    case JTokenType.Float:
                    case JTokenType.Boolean:
                    case JTokenType.Null:
                    default:
                        // no action
                        break;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"'AddNode' method exception {Environment.NewLine} {ex.Message}");
            }
        }

        private bool IsPrimitiveType(JTokenType typeJson)
        {
            bool isPrimitiveType = false;

            switch (typeJson)
            {
                case JTokenType.String:
                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.Boolean:
                case JTokenType.Null:
                    isPrimitiveType = true;
                    break;
                default:
                    break;
            }

            return isPrimitiveType;
        }

        private void Device_XFS4IoTMessages(object sender, string msg)
        {
            try
            {
                if (sender != null)
                {
                    TreeView treeViewToUpdate = null;
                    if (sender is CashDispenserDevice)
                        treeViewToUpdate = cashDispenserTreeView;
                    else if (sender is TextTerminalDevice)
                        treeViewToUpdate = textTerminalTreeView;
                    else if (sender is CardReaderDevice)
                        treeViewToUpdate = cardReaderTreeView;
                    else if (sender is PinPadDevice)
                        treeViewToUpdate = pinPadTreeView;
                    else if (sender is EncryptorDevice)
                        treeViewToUpdate = encryptorTreeView;
                    else if (sender is PrinterDevice)
                        treeViewToUpdate = printerTreeView;
                    else if (sender is LightsDevice)
                        treeViewToUpdate = lightsTreeView;
                    else if (sender is AuxiliariesDevice)
                        treeViewToUpdate = auxiliariesTreeView;
                    else if (sender is VendorModeDevice)
                        treeViewToUpdate = vendorModeTreeView;
                    else if (sender is VendorAppDevice)
                        treeViewToUpdate = vendorApplicationTreeView;
                    else if (sender is BarcodeReaderDevice)
                        treeViewToUpdate = barcodeReaderTreeView;
                    else if (sender is BiometricDevice)
                        treeViewToUpdate = biometricTreeView;
                    else if (sender is CashAcceptorDevice)
                        treeViewToUpdate = cashAcceptorTreeView;
                    else
                        treeViewToUpdate = null;

                    if (treeViewToUpdate != null)
                        LoadXFS4IoTMsgToTreeView(treeViewToUpdate, msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"'Device_XFS4IoTMessages' method exception {Environment.NewLine} {ex.Message}");
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //Show the content of tree node to multiline textbox
                JToken selectedNode = (JToken)e.Node.Tag;

                if (sender != null)
                {
                    TreeView treeViewSelected = sender as TreeView;

                    switch (treeViewSelected.Name)
                    {
                        case "cashDispenserTreeView":
                            cashDispenserRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "textTerminalTreeView":
                            textTerminalRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "cardReaderTreeView":
                            cardReaderRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "encryptorTreeView":
                            encryptorRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "pinPadTreeView":
                            pinPadRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "printerTreeView":
                            printerRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "lightsTreeView":
                            lightsRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "auxiliariesTreeView":
                            auxiliariesRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "vendorModeTreeView":
                            vendorModeRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "vendorApplicationTreeView":
                            vendorApplicationRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "barcodeReaderTreeView":
                            barcodeReaderRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "biometricTreeView":
                            biometricRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        case "cashAcceptorTreeView":
                            cashAcceptorRawBox.Text = selectedNode.ToString(Newtonsoft.Json.Formatting.Indented);
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"'TreeView_AfterSelect' method exception {Environment.NewLine} {ex.Message}");
            }
        }
        #endregion
    }
}
