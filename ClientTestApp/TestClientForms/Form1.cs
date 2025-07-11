﻿/***********************************************************************************************\
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
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json.Nodes;
using static System.Net.Mime.MediaTypeNames;

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
            CameraServiceURI.Text = "ws://localhost";
            CheckScannerServiceURI.Text = "ws://localhost";
            IBNSServiceURI.Text = "ws://localhost";

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
            CameraDev = new("Camera", CameraServiceURI, CameraPortNum, CameraURI);
            CheckScannerDev = new("ChecKScanner", CheckScannerServiceURI, CheckScannerPortNum, CheckScannerURI);
            IBNSDev = new("IBNS", IBNSServiceURI, IBNSPortNum, IBNSURI);

            LightsFlashRate.DataSource = Enum.GetValues(typeof(XFS4IoT.Lights.PositionStatusClass.FlashRateEnum));
            LightsFlashRate.SelectedItem = XFS4IoT.Lights.PositionStatusClass.FlashRateEnum.Continuous;

            comboLightDevice.DataSource = new List<string>() { "cardReader" };
            LightsFlashRate.SelectedItem = "cardReader";

            comboAutoStartupModes.DataSource = Enum.GetValues(typeof(XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum));
            comboAutoStartupModes.SelectedItem = XFS4IoT.Auxiliaries.Commands.SetAutoStartupTimeCommand.PayloadData.ModeEnum.Specific;

            comboSetProtection.DataSource = Enum.GetValues(typeof(XFS4IoT.BanknoteNeutralization.Commands.SetProtectionCommand.PayloadData.NewStateEnum));
            comboSetProtection.SelectedItem = XFS4IoT.BanknoteNeutralization.Commands.SetProtectionCommand.PayloadData.NewStateEnum.Arm;


            comboTriggerNeutralization.DataSource = Enum.GetValues(typeof(XFS4IoT.BanknoteNeutralization.Commands.TriggerNeutralizationCommand.PayloadData.NeutralizationActionEnum));
            comboTriggerNeutralization.SelectedItem = XFS4IoT.BanknoteNeutralization.Commands.TriggerNeutralizationCommand.PayloadData.NeutralizationActionEnum.Trigger;
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
        private CameraDevice CameraDev { get; init; }
        private CheckScannerDevice CheckScannerDev { get; init; }
        private IBNSDevice IBNSDev { get; init; }

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
                    cameraTreeView.AfterSelect += TreeView_AfterSelect;
                    checkScannerTreeView.AfterSelect += TreeView_AfterSelect;
                    ibnsTreeView.AfterSelect += TreeView_AfterSelect;

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
                    CameraDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    CheckScannerDev.XFS4IoTMessages += Device_XFS4IoTMessages;
                    IBNSDev.XFS4IoTMessages += Device_XFS4IoTMessages;
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
                    cameraTreeView.AfterSelect -= TreeView_AfterSelect;
                    checkScannerTreeView.AfterSelect -= TreeView_AfterSelect;
                    ibnsTreeView.AfterSelect -= TreeView_AfterSelect;

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
                    CameraDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    CheckScannerDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
                    IBNSDev.XFS4IoTMessages -= Device_XFS4IoTMessages;
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

        private async void buttonEMVClessQueryApplications_Click(object sender, EventArgs e)
        {
            await CardReaderDev.EMVClessQueryApplications();
        }

        private async void buttonEMVClessPerformTransaction_Click(object sender, EventArgs e)
        {
            await CardReaderDev.EMVClessPerformTransaction();
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
            await CashDispenserDev.GetPresentStatus(NonceTextBox.Text);
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

            Dictionary<string, List<string>> fields = [];
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
                    List<string> list = [split[1]];
                    fields.Add(split[0], list);
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
                Title = "Select json form to load."
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(ofd.FileName))
                    return;

                string contents = await File.ReadAllTextAsync(ofd.FileName);
                await PrinterDev.DoSetFormOrMedia(contents, true);
            }
        }

        private async void PrinterSetMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Title = "Select json media to load."
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(ofd.FileName))
                    return;

                string contents = await File.ReadAllTextAsync(ofd.FileName);
                await PrinterDev.DoSetFormOrMedia(contents, false);
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
            await LightsDev.SetLight((string)comboLightDevice.SelectedItem, (XFS4IoT.Lights.PositionStatusClass.FlashRateEnum)LightsFlashRate.SelectedItem);
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

        #region Camera
        private async void CameraServiceDiscovery_Click(object sender, EventArgs e)
        {
            await CameraDev.DoServiceDiscovery();
        }

        private async void CameraStatus_Click(object sender, EventArgs e)
        {
            var status = await CameraDev.GetStatus();
            StCamera.Text = status?.Payload?.Common?.Device?.ToString() ?? "";
        }

        private async void CameraCapabilities_Click(object sender, EventArgs e)
        {
            await CameraDev.GetCapabilities();
        }

        private async void CameraReset_Click(object sender, EventArgs e)
        {
            await CameraDev.Reset();
        }

        private async void TakePic_Click(object sender, EventArgs e)
        {
            await CameraDev.TakePitcure();
        }

        #endregion

        #region CheckScanner

        private async void ChecKScannerServiceDiscovery_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.DoServiceDiscovery();
        }

        private async void CheckScannerStatus_Click(object sender, EventArgs e)
        {
            var status = await CheckScannerDev.GetStatus();
            StCheck.Text = status?.Payload?.Common?.Device?.ToString() ?? "";
        }

        private async void CheckScannerCapabilities_Click(object sender, EventArgs e)
        {
            var caps = await CheckScannerDev.GetCapabilities();
            CheckDeviceType.Text = caps?.Payload?.Check?.Type?.ToString();
        }

        private async void CheckScannerSetCheckUnitInfo_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.SetCheckUnitInfo();
        }

        private async void CheckScannerGetCheckUnitInfo_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.GetCheckUnitInfo();
        }

        private async void CheckScannerGetTransactionStatus_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.GetTransactionStatus();
        }

        private async void CheckScannerReset_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.Reset();
        }

        private async void CheckScannerRetract_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.Retract();
        }

        private async void CheckScannerStartExchange_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.StartExchange();
        }

        private async void CheckScannerEndExchange_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.EndExchange();
        }

        private async void CheckScannerMediaIn_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.MediaIn();
        }

        private async void CheckScannerMediaInEnd_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.MediaInEnd();
        }

        private async void CheckScannerMediaInRollback_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.MediaInRollback();
        }

        private async void viewTxnStatus_Click(object sender, EventArgs e)
        {
            await CheckScannerDev.ShowTransactionStatus();
        }

        #endregion

        #region IBNS

        private async void IBNSServiceDiscovery_Click(object sender, EventArgs e)
        {
            await IBNSDev.DoServiceDiscovery();
        }

        private async void IBNSStatus_Click(object sender, EventArgs e)
        {
            var status = await IBNSDev.GetStatus();
            StIBNS.Text = status?.Payload?.Common?.Device?.ToString() ?? "";
        }

        private async void IBNSCapabilities_Click(object sender, EventArgs e)
        {
            var caps = await IBNSDev.GetCapabilities();
        }

        private async void IBNSSetProtection_Click(object sender, EventArgs e)
        {
            await IBNSDev.SetProtection((XFS4IoT.BanknoteNeutralization.Commands.SetProtectionCommand.PayloadData.NewStateEnum)comboSetProtection.SelectedItem);
        }

        private async void GetIBNSUnitInfo_Click(object sender, EventArgs e)
        {
            await IBNSDev.GetUnitInfo();
        }

        private async void IBNSTriggerNeutralization_Click(object sender, EventArgs e)
        {
            await IBNSDev.TriggerNeutralization((XFS4IoT.BanknoteNeutralization.Commands.TriggerNeutralizationCommand.PayloadData.NeutralizationActionEnum)comboTriggerNeutralization.SelectedItem);
        }

        #endregion

        #region TreeViews manage 
        private void LoadXFS4IoTMsgToTreeView(System.Windows.Forms.TreeView jsonTreeView, string jsonString)
        {
            if (jsonString == null || jsonString.Equals(string.Empty) || jsonString.Equals("<Unknown Event>"))
                return;

            try
            {
                if (jsonTreeView != null)
                {
                    JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
                    (string Description, Color FontColor) tDecoration = NodeDecoration(jsonDocument);
                    TreeNode rootNode = new($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}] {tDecoration.Description}");
                    rootNode.Tag = ReturnPretifiedJson(jsonDocument);
                    rootNode.ForeColor = tDecoration.FontColor;
                    jsonTreeView.Nodes.Add(rootNode);
                    AddNode(jsonDocument.RootElement, rootNode);
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

        private string ReturnPretifiedJson(JsonDocument jsonDocument)
        {
            string json = string.Empty;
            using (var stream = new MemoryStream())
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                jsonDocument.WriteTo(writer);
                writer.Flush();
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            return json;
        }

        private (string Description, Color FontColor) NodeDecoration(JsonDocument jsonObject)
        {
            (string Description, Color FontColor) tDecoration = ("unknown", Color.Red);
            try
            {
                JsonElement jHeader = jsonObject.RootElement.GetProperty("header");
                switch (jHeader.GetProperty("type").ToString())
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

                tDecoration.Description = string.Empty;
                if (jHeader.TryGetProperty("name", out JsonElement element))
                    tDecoration.Description += element + " - ";

                if (jHeader.TryGetProperty("type", out JsonElement element2))
                    tDecoration.Description += element2 + " - ";

                if (jHeader.TryGetProperty("requestId", out JsonElement element3))
                    tDecoration.Description += element3 + " - ";

                tDecoration.Description = tDecoration.Description.Substring(0, tDecoration.Description.Length - 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"'NodeDecoration' method exception {Environment.NewLine} {ex.Message}");
            }

            return tDecoration;
        }

        private void AddNode(JsonElement token, TreeNode parentNode)
        {
            try
            {
                switch (token.ValueKind)
                {
                    case JsonValueKind.Object:
                        // for each object property add a new tree node 
                        // for primitive type show the keypair 'property : bvalue' on node description
                        foreach (var childProperty in token.EnumerateObject())
                        {
                            string descriptioNode = childProperty.Name;
                            if (IsPrimitiveType(childProperty.Value))
                                descriptioNode += $" : {childProperty.Value}";

                            TreeNode childNode = new TreeNode(descriptioNode);
                            childNode.Tag = childProperty.Value;
                            parentNode.Nodes.Add(childNode);
                            if (!IsPrimitiveType(childProperty.Value))
                                AddNode(childProperty.Value, childNode);
                        }
                        break;

                    case JsonValueKind.Array:
                        // for each array element add a new tree node 
                        for (int i = 0; i < token.GetArrayLength(); i++)
                        {
                            TreeNode childNode = new TreeNode("[" + i + "]");
                            childNode.Tag = token[i];
                            parentNode.Nodes.Add(childNode);
                            AddNode(token[i], childNode);
                        }
                        break;
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

        private bool IsPrimitiveType(JsonElement typeJson)
        {
            bool isPrimitiveType = false;

            switch (typeJson.ValueKind)
            {
                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Null:
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
                    else if (sender is CameraDevice)
                        treeViewToUpdate = cameraTreeView;
                    else if (sender is CheckScannerDevice)
                        treeViewToUpdate = checkScannerTreeView;
                    else if (sender is IBNSDevice)
                        treeViewToUpdate = ibnsTreeView;
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
            var selectedNode = e.Node.Tag;
            string stringifySelectedNode = string.Empty;
            try
            {
                if (selectedNode.GetType() == typeof(string))
                    stringifySelectedNode = (string)selectedNode;
                else if (selectedNode.GetType() == typeof(JsonElement))
                    stringifySelectedNode = selectedNode.ToString();

                //Show the content of tree node to multiline textbox
                if (sender != null)
                {
                    TreeView treeViewSelected = sender as TreeView;
                    switch (treeViewSelected.Name)
                    {
                        case "cashDispenserTreeView":
                            cashDispenserRawBox.Text = stringifySelectedNode;
                            break;
                        case "textTerminalTreeView":
                            textTerminalRawBox.Text = stringifySelectedNode;
                            break;
                        case "cardReaderTreeView":
                            cardReaderRawBox.Text = stringifySelectedNode;
                            break;
                        case "encryptorTreeView":
                            encryptorRawBox.Text = stringifySelectedNode;
                            break;
                        case "pinPadTreeView":
                            pinPadRawBox.Text = stringifySelectedNode;
                            break;
                        case "printerTreeView":
                            printerRawBox.Text = stringifySelectedNode;
                            break;
                        case "lightsTreeView":
                            lightsRawBox.Text = stringifySelectedNode;
                            break;
                        case "auxiliariesTreeView":
                            auxiliariesRawBox.Text = stringifySelectedNode;
                            break;
                        case "vendorModeTreeView":
                            vendorModeRawBox.Text = stringifySelectedNode;
                            break;
                        case "vendorApplicationTreeView":
                            vendorApplicationRawBox.Text = stringifySelectedNode;
                            break;
                        case "barcodeReaderTreeView":
                            barcodeReaderRawBox.Text = stringifySelectedNode;
                            break;
                        case "biometricTreeView":
                            biometricRawBox.Text = stringifySelectedNode;
                            break;
                        case "cashAcceptorTreeView":
                            cashAcceptorRawBox.Text = stringifySelectedNode;
                            break;
                        case "cameraTreeView":
                            cameraRawBox.Text = stringifySelectedNode;
                            break;
                        case "checkScannerTreeView":
                            checkScannerRawBox.Text = stringifySelectedNode;
                            break;
                        case "ibnsTreeView":
                            ibnsRawBox.Text = stringifySelectedNode;
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
