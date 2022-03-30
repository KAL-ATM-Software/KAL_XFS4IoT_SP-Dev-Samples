/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

namespace TestClientForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AcceptCard = new System.Windows.Forms.Button();
            this.EjectCard = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.ServiceDiscovery = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCardReader = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServiceURI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEvent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxStDevice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStMedia = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDeviceType = new System.Windows.Forms.TextBox();
            this.CaptureCard = new System.Windows.Forms.Button();
            this.testClientTabControl = new System.Windows.Forms.TabControl();
            this.CardReaderTab = new System.Windows.Forms.TabPage();
            this.ResetBinCount = new System.Windows.Forms.Button();
            this.GetStorage = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.DispenserTab = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.SetCashUnitInfo = new System.Windows.Forms.Button();
            this.DispenserRetract = new System.Windows.Forms.Button();
            this.DispenserReject = new System.Windows.Forms.Button();
            this.DispenserCloseShutter = new System.Windows.Forms.Button();
            this.DispenserOpenShutter = new System.Windows.Forms.Button();
            this.DispenserDispense = new System.Windows.Forms.Button();
            this.ClearCommandNonce = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DispenserDenominate = new System.Windows.Forms.Button();
            this.DispenserPresent = new System.Windows.Forms.Button();
            this.DispenserEndExchange = new System.Windows.Forms.Button();
            this.DispenserStartExchange = new System.Windows.Forms.Button();
            this.DispenserReset = new System.Windows.Forms.Button();
            this.DispenserGetPresentStatus = new System.Windows.Forms.Button();
            this.DispenserDeviceType = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.DispenserStDevice = new System.Windows.Forms.TextBox();
            this.DispenserGetMixTypes = new System.Windows.Forms.Button();
            this.DispenserCapabilities = new System.Windows.Forms.Button();
            this.DispenserStatus = new System.Windows.Forms.Button();
            this.DispenserGetCashUnitInfo = new System.Windows.Forms.Button();
            this.DispenserServiceURI = new System.Windows.Forms.TextBox();
            this.DispenserEvtBox = new System.Windows.Forms.TextBox();
            this.DispenserServiceDiscovery = new System.Windows.Forms.Button();
            this.DispenserPortNum = new System.Windows.Forms.TextBox();
            this.DispenserRspBox = new System.Windows.Forms.TextBox();
            this.DispenserCmdBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.DispenserDispURI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextTerminalTab = new System.Windows.Forms.TabPage();
            this.TextTerminalSetResolution = new System.Windows.Forms.Button();
            this.TextTerminalBeep = new System.Windows.Forms.Button();
            this.TextTerminalReset = new System.Windows.Forms.Button();
            this.TextTerminalGetKeyDetail = new System.Windows.Forms.Button();
            this.TextTerminalRead = new System.Windows.Forms.Button();
            this.TextTerminalWrite = new System.Windows.Forms.Button();
            this.TextTerminalClearScreen = new System.Windows.Forms.Button();
            this.TextTerminalDeviceType = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TextTerminalStDevice = new System.Windows.Forms.TextBox();
            this.TextTerminalCapabilities = new System.Windows.Forms.Button();
            this.TextTerminalStatus = new System.Windows.Forms.Button();
            this.TextTerminalServiceURI = new System.Windows.Forms.TextBox();
            this.TextTerminalEvtBox = new System.Windows.Forms.TextBox();
            this.TextTerminalServiceDiscovery = new System.Windows.Forms.Button();
            this.TextTerminalPortNum = new System.Windows.Forms.TextBox();
            this.TextTerminalRspBox = new System.Windows.Forms.TextBox();
            this.TextTerminalCmdBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TextTerminalURI = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.EncryptorTab = new System.Windows.Forms.TabPage();
            this.EncryptorDeleteKey = new System.Windows.Forms.Button();
            this.EncryptorGenerateMAC = new System.Windows.Forms.Button();
            this.EncryptorEncrypt = new System.Windows.Forms.Button();
            this.EncryptorGenerateRandom = new System.Windows.Forms.Button();
            this.EncryptorReset = new System.Windows.Forms.Button();
            this.EncryptorImportKey = new System.Windows.Forms.Button();
            this.EncryptorInitialization = new System.Windows.Forms.Button();
            this.EncryptorGetKeyNames = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.EncryptorKeyNamelistBox = new System.Windows.Forms.ListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.EncryptorEvtBox = new System.Windows.Forms.TextBox();
            this.EncryptorRspBox = new System.Windows.Forms.TextBox();
            this.EncryptorCmdBox = new System.Windows.Forms.TextBox();
            this.EncryptorMaxKeyNum = new System.Windows.Forms.TextBox();
            this.EncryptorStDevice = new System.Windows.Forms.TextBox();
            this.EncryptorCapabilities = new System.Windows.Forms.Button();
            this.EncryptorStatus = new System.Windows.Forms.Button();
            this.EncryptorServiceURI = new System.Windows.Forms.TextBox();
            this.EncryptorServiceDiscovery = new System.Windows.Forms.Button();
            this.EncryptorPortNum = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.EncryptorURI = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.PinPadTab = new System.Windows.Forms.TabPage();
            this.PinPadGetLayout = new System.Windows.Forms.Button();
            this.PinPadEnterData = new System.Windows.Forms.Button();
            this.PinPadFormatPin = new System.Windows.Forms.Button();
            this.PinPadEnterPin = new System.Windows.Forms.Button();
            this.PinPadLoadPinKey = new System.Windows.Forms.Button();
            this.PinPadSecureKeyEntryPart2 = new System.Windows.Forms.Button();
            this.PinPadSecureKeyEntryPart1 = new System.Windows.Forms.Button();
            this.PinPadDeleteKey = new System.Windows.Forms.Button();
            this.PinPadReset = new System.Windows.Forms.Button();
            this.PinPadImportKey = new System.Windows.Forms.Button();
            this.PinPadInitialization = new System.Windows.Forms.Button();
            this.PinPadGetKeyNames = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.PinPadKeyNamelistBox = new System.Windows.Forms.ListBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.PinPadEvtBox = new System.Windows.Forms.TextBox();
            this.PinPadRspBox = new System.Windows.Forms.TextBox();
            this.PinPadCmdBox = new System.Windows.Forms.TextBox();
            this.PinPadMaxKeyNum = new System.Windows.Forms.TextBox();
            this.PinPadStDevice = new System.Windows.Forms.TextBox();
            this.PinPadCapabilities = new System.Windows.Forms.Button();
            this.PinPadStatus = new System.Windows.Forms.Button();
            this.PinPadServiceURI = new System.Windows.Forms.TextBox();
            this.PinPadServiceDiscovery = new System.Windows.Forms.Button();
            this.PinPadPortNum = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.PinPadURI = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.PrinterTabPage = new System.Windows.Forms.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.PrinterFormFields = new System.Windows.Forms.TextBox();
            this.PrinterLoadDefinition = new System.Windows.Forms.Button();
            this.PrinterMediaListBox = new System.Windows.Forms.ListBox();
            this.PrinterQueryForm = new System.Windows.Forms.Button();
            this.PrinterEject = new System.Windows.Forms.Button();
            this.PrinterQueryMedia = new System.Windows.Forms.Button();
            this.PrinterGetMediaList = new System.Windows.Forms.Button();
            this.PrinterPrintForm = new System.Windows.Forms.Button();
            this.PrinterReset = new System.Windows.Forms.Button();
            this.PrinterPrintRaw = new System.Windows.Forms.Button();
            this.PrinterGetFormList = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.PrinterFormListBox = new System.Windows.Forms.ListBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.PrinterEvtBox = new System.Windows.Forms.TextBox();
            this.PrinterRspBox = new System.Windows.Forms.TextBox();
            this.PrinterCmdBox = new System.Windows.Forms.TextBox();
            this.PrinterType = new System.Windows.Forms.TextBox();
            this.PrinterStDevice = new System.Windows.Forms.TextBox();
            this.PrinterCapabilities = new System.Windows.Forms.Button();
            this.PrinterStatus = new System.Windows.Forms.Button();
            this.PrinterServiceURI = new System.Windows.Forms.TextBox();
            this.PrinterServiceDiscovery = new System.Windows.Forms.Button();
            this.PrinterPortNum = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.PrinterURI = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lightsTab = new System.Windows.Forms.TabPage();
            this.LightsServiceDiscovery = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.LightsFlashRate = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtLightName = new System.Windows.Forms.TextBox();
            this.LightsSetLight = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.LightsEvtBox = new System.Windows.Forms.TextBox();
            this.LightsRspBox = new System.Windows.Forms.TextBox();
            this.LightsCmdBox = new System.Windows.Forms.TextBox();
            this.lblLightsStatus = new System.Windows.Forms.TextBox();
            this.LightsCapabilities = new System.Windows.Forms.Button();
            this.LightsStatus = new System.Windows.Forms.Button();
            this.LightsServiceURI = new System.Windows.Forms.TextBox();
            this.LightsPortNum = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.LightsURI = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboAutoStartupModes = new System.Windows.Forms.ComboBox();
            this.btnSetAuxiliaries = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClearAutoStartup = new System.Windows.Forms.Button();
            this.btnGetAutoStartup = new System.Windows.Forms.Button();
            this.btnSetAutoStartup = new System.Windows.Forms.Button();
            this.autoStartupDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnAuxiliariesServiceDiscovery = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.AuxiliariesEvtBox = new System.Windows.Forms.TextBox();
            this.AuxiliariesRspBox = new System.Windows.Forms.TextBox();
            this.AuxiliariesCmdBox = new System.Windows.Forms.TextBox();
            this.AuxiliariesStatus = new System.Windows.Forms.TextBox();
            this.btnAuxiliariesCapabilities = new System.Windows.Forms.Button();
            this.btnAuxiliariesStatus = new System.Windows.Forms.Button();
            this.AuxiliariesServiceURI = new System.Windows.Forms.TextBox();
            this.AuxiliariesPortNum = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.AuxiliariesURI = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.VendorModeTabPage = new System.Windows.Forms.TabPage();
            this.buttonVDMExit = new System.Windows.Forms.Button();
            this.buttonVDMEnter = new System.Windows.Forms.Button();
            this.VendorModeServiceStatus = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.VendorModeEvtBox = new System.Windows.Forms.TextBox();
            this.VendorModeRspBox = new System.Windows.Forms.TextBox();
            this.VendorModeCmdBox = new System.Windows.Forms.TextBox();
            this.btnVendorModeServiceDiscovery = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.VendorModeStStatus = new System.Windows.Forms.TextBox();
            this.btnVendorModeStatus = new System.Windows.Forms.Button();
            this.VendorModeServiceURI = new System.Windows.Forms.TextBox();
            this.VendorModePortNum = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.VendorModeURI = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.VendorAppTabPage = new System.Windows.Forms.TabPage();
            this.label60 = new System.Windows.Forms.Label();
            this.textAppName = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.textActiveInterface = new System.Windows.Forms.TextBox();
            this.buttonGetActiveInterface = new System.Windows.Forms.Button();
            this.buttonStartLocalApplication = new System.Windows.Forms.Button();
            this.VendorAppEvtBox = new System.Windows.Forms.TextBox();
            this.VendorAppRspBox = new System.Windows.Forms.TextBox();
            this.VendorAppCmdBox = new System.Windows.Forms.TextBox();
            this.btnVendorAppServiceDiscovery = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.VendorAppStatus = new System.Windows.Forms.TextBox();
            this.btnVendorAppCapabilities = new System.Windows.Forms.Button();
            this.btnVendorAppStatus = new System.Windows.Forms.Button();
            this.VendorAppServiceURI = new System.Windows.Forms.TextBox();
            this.VendorAppPortNum = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.VendorAppURI = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.BarcodeReaderTabPage = new System.Windows.Forms.TabPage();
            this.BarcodeReaderReset = new System.Windows.Forms.Button();
            this.BarcodeReaderRead = new System.Windows.Forms.Button();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.BarcodeReaderEvtBox = new System.Windows.Forms.TextBox();
            this.BarcodeReaderRspBox = new System.Windows.Forms.TextBox();
            this.BarcodeReaderCmdBox = new System.Windows.Forms.TextBox();
            this.BarcodeReaderScannerStatus = new System.Windows.Forms.TextBox();
            this.BarcodeReaderStDevice = new System.Windows.Forms.TextBox();
            this.BarcodeReaderCapabilities = new System.Windows.Forms.Button();
            this.BarcodeReaderStatus = new System.Windows.Forms.Button();
            this.BarcodeReaderServiceURI = new System.Windows.Forms.TextBox();
            this.btnBarcodeReaderServiceDiscovery = new System.Windows.Forms.Button();
            this.BarcodeReaderPortNum = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.BarcodeReaderURI = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.BiometricPage = new System.Windows.Forms.TabPage();
            this.btnBiometricGetStorageInfo = new System.Windows.Forms.Button();
            this.BiometricStorageInfo = new System.Windows.Forms.ListBox();
            this.btnBiometricReadMatch = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.txtBiometricTemplateData = new System.Windows.Forms.TextBox();
            this.btnBiometricClear = new System.Windows.Forms.Button();
            this.btnBiometricMatch = new System.Windows.Forms.Button();
            this.btnBiometricImport = new System.Windows.Forms.Button();
            this.btnBiometricReset = new System.Windows.Forms.Button();
            this.btnBiometricRead = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.BiometricEvtBox = new System.Windows.Forms.TextBox();
            this.BiometricRspBox = new System.Windows.Forms.TextBox();
            this.BiometricCmdBox = new System.Windows.Forms.TextBox();
            this.BiometricStatus = new System.Windows.Forms.TextBox();
            this.btnBiometricCapabilities = new System.Windows.Forms.Button();
            this.btnBiometricStatus = new System.Windows.Forms.Button();
            this.BiometricServiceURI = new System.Windows.Forms.TextBox();
            this.btnBiometricServiceDiscovery = new System.Windows.Forms.Button();
            this.BiometricPortNum = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.BiometricURI = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.CashAccTabPage = new System.Windows.Forms.TabPage();
            this.CashAccSetCashUnitInfo = new System.Windows.Forms.Button();
            this.CashAccRetract = new System.Windows.Forms.Button();
            this.CashAccCashIn = new System.Windows.Forms.Button();
            this.CashAccConfigureNoteTypes = new System.Windows.Forms.Button();
            this.CashAccCashInEnd = new System.Windows.Forms.Button();
            this.CashAccCashInStart = new System.Windows.Forms.Button();
            this.CashAccCashInRollback = new System.Windows.Forms.Button();
            this.CashAccEndExchange = new System.Windows.Forms.Button();
            this.CashAccStartExchange = new System.Windows.Forms.Button();
            this.CashAccReset = new System.Windows.Forms.Button();
            this.CashAccCashInStatus = new System.Windows.Forms.Button();
            this.CashAccDeviceType = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.CashAccStDevice = new System.Windows.Forms.TextBox();
            this.CashAccPositionCapabilities = new System.Windows.Forms.Button();
            this.CashAccCapabilities = new System.Windows.Forms.Button();
            this.CashAccStatus = new System.Windows.Forms.Button();
            this.CashAccGetCashUnitInfo = new System.Windows.Forms.Button();
            this.CashAcceptorServiceURI = new System.Windows.Forms.TextBox();
            this.CashAcceptorEvtBox = new System.Windows.Forms.TextBox();
            this.CashAcceptorServiceDiscovery = new System.Windows.Forms.Button();
            this.CashAcceptorPortNum = new System.Windows.Forms.TextBox();
            this.CashAcceptorRspBox = new System.Windows.Forms.TextBox();
            this.CashAcceptorCmdBox = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.CashAcceptorAccURI = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.testClientTabControl.SuspendLayout();
            this.CardReaderTab.SuspendLayout();
            this.DispenserTab.SuspendLayout();
            this.TextTerminalTab.SuspendLayout();
            this.EncryptorTab.SuspendLayout();
            this.PinPadTab.SuspendLayout();
            this.PrinterTabPage.SuspendLayout();
            this.lightsTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.VendorModeTabPage.SuspendLayout();
            this.VendorAppTabPage.SuspendLayout();
            this.BarcodeReaderTabPage.SuspendLayout();
            this.BiometricPage.SuspendLayout();
            this.CashAccTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptCard
            // 
            this.AcceptCard.Location = new System.Drawing.Point(1098, 25);
            this.AcceptCard.Margin = new System.Windows.Forms.Padding(0);
            this.AcceptCard.Name = "AcceptCard";
            this.AcceptCard.Size = new System.Drawing.Size(106, 32);
            this.AcceptCard.TabIndex = 0;
            this.AcceptCard.Text = "AcceptCard";
            this.AcceptCard.UseVisualStyleBackColor = true;
            this.AcceptCard.Click += new System.EventHandler(this.AcceptCard_Click);
            // 
            // EjectCard
            // 
            this.EjectCard.Location = new System.Drawing.Point(1098, 72);
            this.EjectCard.Margin = new System.Windows.Forms.Padding(0);
            this.EjectCard.Name = "EjectCard";
            this.EjectCard.Size = new System.Drawing.Size(106, 32);
            this.EjectCard.TabIndex = 1;
            this.EjectCard.Text = "EjectCard";
            this.EjectCard.UseVisualStyleBackColor = true;
            this.EjectCard.Click += new System.EventHandler(this.EjectCard_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxCommand.Location = new System.Drawing.Point(17, 267);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCommand.MaxLength = 1048576;
            this.textBoxCommand.Multiline = true;
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommand.Size = new System.Drawing.Size(450, 408);
            this.textBoxCommand.TabIndex = 2;
            // 
            // ServiceDiscovery
            // 
            this.ServiceDiscovery.Location = new System.Drawing.Point(502, 136);
            this.ServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.ServiceDiscovery.Name = "ServiceDiscovery";
            this.ServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.ServiceDiscovery.TabIndex = 3;
            this.ServiceDiscovery.Text = "Service Discovery";
            this.ServiceDiscovery.UseVisualStyleBackColor = true;
            this.ServiceDiscovery.Click += new System.EventHandler(this.ServiceDiscovery_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(114, 57);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            this.textBoxPort.Size = new System.Drawing.Size(121, 27);
            this.textBoxPort.TabIndex = 4;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxResponse.Location = new System.Drawing.Point(488, 267);
            this.textBoxResponse.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxResponse.MaxLength = 1048576;
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(423, 408);
            this.textBoxResponse.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "CardReader URI";
            // 
            // textBoxCardReader
            // 
            this.textBoxCardReader.Location = new System.Drawing.Point(114, 88);
            this.textBoxCardReader.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCardReader.Name = "textBoxCardReader";
            this.textBoxCardReader.ReadOnly = true;
            this.textBoxCardReader.Size = new System.Drawing.Size(530, 27);
            this.textBoxCardReader.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port Number";
            // 
            // textBoxServiceURI
            // 
            this.textBoxServiceURI.Location = new System.Drawing.Point(114, 25);
            this.textBoxServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxServiceURI.Name = "textBoxServiceURI";
            this.textBoxServiceURI.Size = new System.Drawing.Size(530, 27);
            this.textBoxServiceURI.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Service URI";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(955, 43);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(96, 35);
            this.buttonStatus.TabIndex = 12;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Response";
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxEvent.Location = new System.Drawing.Point(930, 267);
            this.textBoxEvent.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEvent.MaxLength = 1048576;
            this.textBoxEvent.Multiline = true;
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEvent.Size = new System.Drawing.Size(405, 408);
            this.textBoxEvent.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(928, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Event";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(715, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Device status";
            // 
            // textBoxStDevice
            // 
            this.textBoxStDevice.Location = new System.Drawing.Point(815, 21);
            this.textBoxStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxStDevice.Name = "textBoxStDevice";
            this.textBoxStDevice.ReadOnly = true;
            this.textBoxStDevice.Size = new System.Drawing.Size(121, 27);
            this.textBoxStDevice.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(715, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Media Status";
            // 
            // textBoxStMedia
            // 
            this.textBoxStMedia.Location = new System.Drawing.Point(815, 55);
            this.textBoxStMedia.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxStMedia.Name = "textBoxStMedia";
            this.textBoxStMedia.ReadOnly = true;
            this.textBoxStMedia.Size = new System.Drawing.Size(121, 27);
            this.textBoxStMedia.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(955, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 36);
            this.button1.TabIndex = 21;
            this.button1.Text = "Capabilities";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(723, 125);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Device type";
            // 
            // textBoxDeviceType
            // 
            this.textBoxDeviceType.Location = new System.Drawing.Point(815, 125);
            this.textBoxDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDeviceType.Name = "textBoxDeviceType";
            this.textBoxDeviceType.ReadOnly = true;
            this.textBoxDeviceType.Size = new System.Drawing.Size(121, 27);
            this.textBoxDeviceType.TabIndex = 23;
            // 
            // CaptureCard
            // 
            this.CaptureCard.Location = new System.Drawing.Point(1098, 127);
            this.CaptureCard.Margin = new System.Windows.Forms.Padding(0);
            this.CaptureCard.Name = "CaptureCard";
            this.CaptureCard.Size = new System.Drawing.Size(106, 32);
            this.CaptureCard.TabIndex = 24;
            this.CaptureCard.Text = "CaptureCard";
            this.CaptureCard.UseVisualStyleBackColor = true;
            this.CaptureCard.Click += new System.EventHandler(this.CaptureCard_Click);
            // 
            // testClientTabControl
            // 
            this.testClientTabControl.Controls.Add(this.CardReaderTab);
            this.testClientTabControl.Controls.Add(this.DispenserTab);
            this.testClientTabControl.Controls.Add(this.TextTerminalTab);
            this.testClientTabControl.Controls.Add(this.EncryptorTab);
            this.testClientTabControl.Controls.Add(this.PinPadTab);
            this.testClientTabControl.Controls.Add(this.PrinterTabPage);
            this.testClientTabControl.Controls.Add(this.lightsTab);
            this.testClientTabControl.Controls.Add(this.tabPage2);
            this.testClientTabControl.Controls.Add(this.VendorModeTabPage);
            this.testClientTabControl.Controls.Add(this.VendorAppTabPage);
            this.testClientTabControl.Controls.Add(this.BarcodeReaderTabPage);
            this.testClientTabControl.Controls.Add(this.BiometricPage);
            this.testClientTabControl.Controls.Add(this.CashAccTabPage);
            this.testClientTabControl.Location = new System.Drawing.Point(8, 3);
            this.testClientTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testClientTabControl.Name = "testClientTabControl";
            this.testClientTabControl.SelectedIndex = 0;
            this.testClientTabControl.Size = new System.Drawing.Size(1354, 724);
            this.testClientTabControl.TabIndex = 25;
            // 
            // CardReaderTab
            // 
            this.CardReaderTab.Controls.Add(this.ResetBinCount);
            this.CardReaderTab.Controls.Add(this.GetStorage);
            this.CardReaderTab.Controls.Add(this.Reset);
            this.CardReaderTab.Controls.Add(this.textBoxServiceURI);
            this.CardReaderTab.Controls.Add(this.CaptureCard);
            this.CardReaderTab.Controls.Add(this.textBoxEvent);
            this.CardReaderTab.Controls.Add(this.ServiceDiscovery);
            this.CardReaderTab.Controls.Add(this.textBoxDeviceType);
            this.CardReaderTab.Controls.Add(this.textBoxPort);
            this.CardReaderTab.Controls.Add(this.textBoxResponse);
            this.CardReaderTab.Controls.Add(this.textBoxCommand);
            this.CardReaderTab.Controls.Add(this.label9);
            this.CardReaderTab.Controls.Add(this.label2);
            this.CardReaderTab.Controls.Add(this.button1);
            this.CardReaderTab.Controls.Add(this.textBoxCardReader);
            this.CardReaderTab.Controls.Add(this.textBoxStMedia);
            this.CardReaderTab.Controls.Add(this.label1);
            this.CardReaderTab.Controls.Add(this.label8);
            this.CardReaderTab.Controls.Add(this.label3);
            this.CardReaderTab.Controls.Add(this.textBoxStDevice);
            this.CardReaderTab.Controls.Add(this.label7);
            this.CardReaderTab.Controls.Add(this.AcceptCard);
            this.CardReaderTab.Controls.Add(this.EjectCard);
            this.CardReaderTab.Controls.Add(this.buttonStatus);
            this.CardReaderTab.Location = new System.Drawing.Point(4, 29);
            this.CardReaderTab.Margin = new System.Windows.Forms.Padding(1);
            this.CardReaderTab.Name = "CardReaderTab";
            this.CardReaderTab.Padding = new System.Windows.Forms.Padding(1);
            this.CardReaderTab.Size = new System.Drawing.Size(1346, 691);
            this.CardReaderTab.TabIndex = 0;
            this.CardReaderTab.Text = "CardReader";
            this.CardReaderTab.UseVisualStyleBackColor = true;
            // 
            // ResetBinCount
            // 
            this.ResetBinCount.Location = new System.Drawing.Point(1230, 72);
            this.ResetBinCount.Margin = new System.Windows.Forms.Padding(1);
            this.ResetBinCount.Name = "ResetBinCount";
            this.ResetBinCount.Size = new System.Drawing.Size(106, 32);
            this.ResetBinCount.TabIndex = 27;
            this.ResetBinCount.Text = "ResetBinCount";
            this.ResetBinCount.UseVisualStyleBackColor = true;
            this.ResetBinCount.Click += new System.EventHandler(this.ResetBinCount_Click);
            // 
            // GetStorage
            // 
            this.GetStorage.Location = new System.Drawing.Point(1230, 127);
            this.GetStorage.Margin = new System.Windows.Forms.Padding(1);
            this.GetStorage.Name = "GetStorage";
            this.GetStorage.Size = new System.Drawing.Size(106, 32);
            this.GetStorage.TabIndex = 26;
            this.GetStorage.Text = "GetStorage";
            this.GetStorage.UseVisualStyleBackColor = true;
            this.GetStorage.Click += new System.EventHandler(this.GetStorage_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1230, 25);
            this.Reset.Margin = new System.Windows.Forms.Padding(1);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(106, 32);
            this.Reset.TabIndex = 25;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // DispenserTab
            // 
            this.DispenserTab.Controls.Add(this.label32);
            this.DispenserTab.Controls.Add(this.SetCashUnitInfo);
            this.DispenserTab.Controls.Add(this.DispenserRetract);
            this.DispenserTab.Controls.Add(this.DispenserReject);
            this.DispenserTab.Controls.Add(this.DispenserCloseShutter);
            this.DispenserTab.Controls.Add(this.DispenserOpenShutter);
            this.DispenserTab.Controls.Add(this.DispenserDispense);
            this.DispenserTab.Controls.Add(this.ClearCommandNonce);
            this.DispenserTab.Controls.Add(this.button2);
            this.DispenserTab.Controls.Add(this.DispenserDenominate);
            this.DispenserTab.Controls.Add(this.DispenserPresent);
            this.DispenserTab.Controls.Add(this.DispenserEndExchange);
            this.DispenserTab.Controls.Add(this.DispenserStartExchange);
            this.DispenserTab.Controls.Add(this.DispenserReset);
            this.DispenserTab.Controls.Add(this.DispenserGetPresentStatus);
            this.DispenserTab.Controls.Add(this.DispenserDeviceType);
            this.DispenserTab.Controls.Add(this.label14);
            this.DispenserTab.Controls.Add(this.label13);
            this.DispenserTab.Controls.Add(this.DispenserStDevice);
            this.DispenserTab.Controls.Add(this.DispenserGetMixTypes);
            this.DispenserTab.Controls.Add(this.DispenserCapabilities);
            this.DispenserTab.Controls.Add(this.DispenserStatus);
            this.DispenserTab.Controls.Add(this.DispenserGetCashUnitInfo);
            this.DispenserTab.Controls.Add(this.DispenserServiceURI);
            this.DispenserTab.Controls.Add(this.DispenserEvtBox);
            this.DispenserTab.Controls.Add(this.DispenserServiceDiscovery);
            this.DispenserTab.Controls.Add(this.DispenserPortNum);
            this.DispenserTab.Controls.Add(this.DispenserRspBox);
            this.DispenserTab.Controls.Add(this.DispenserCmdBox);
            this.DispenserTab.Controls.Add(this.label10);
            this.DispenserTab.Controls.Add(this.TokenTextBox);
            this.DispenserTab.Controls.Add(this.DispenserDispURI);
            this.DispenserTab.Controls.Add(this.label11);
            this.DispenserTab.Controls.Add(this.label12);
            this.DispenserTab.Location = new System.Drawing.Point(4, 29);
            this.DispenserTab.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserTab.Name = "DispenserTab";
            this.DispenserTab.Padding = new System.Windows.Forms.Padding(1);
            this.DispenserTab.Size = new System.Drawing.Size(1346, 691);
            this.DispenserTab.TabIndex = 1;
            this.DispenserTab.Text = "CashDispenser";
            this.DispenserTab.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(18, 195);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(128, 20);
            this.label32.TabIndex = 45;
            this.label32.Text = "Command Nonce:";
            // 
            // SetCashUnitInfo
            // 
            this.SetCashUnitInfo.Location = new System.Drawing.Point(902, 99);
            this.SetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            this.SetCashUnitInfo.Name = "SetCashUnitInfo";
            this.SetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            this.SetCashUnitInfo.TabIndex = 44;
            this.SetCashUnitInfo.Text = "SetCashUnitInfo";
            this.SetCashUnitInfo.UseVisualStyleBackColor = true;
            this.SetCashUnitInfo.Click += new System.EventHandler(this.SetCashUnitInfo_Click);
            // 
            // DispenserRetract
            // 
            this.DispenserRetract.Location = new System.Drawing.Point(1053, 160);
            this.DispenserRetract.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserRetract.Name = "DispenserRetract";
            this.DispenserRetract.Size = new System.Drawing.Size(127, 28);
            this.DispenserRetract.TabIndex = 43;
            this.DispenserRetract.Text = "Retract";
            this.DispenserRetract.UseVisualStyleBackColor = true;
            this.DispenserRetract.Click += new System.EventHandler(this.DispenserRetract_Click);
            // 
            // DispenserReject
            // 
            this.DispenserReject.Location = new System.Drawing.Point(1053, 121);
            this.DispenserReject.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserReject.Name = "DispenserReject";
            this.DispenserReject.Size = new System.Drawing.Size(127, 28);
            this.DispenserReject.TabIndex = 42;
            this.DispenserReject.Text = "Reject";
            this.DispenserReject.UseVisualStyleBackColor = true;
            this.DispenserReject.Click += new System.EventHandler(this.DispenserReject_Click);
            // 
            // DispenserCloseShutter
            // 
            this.DispenserCloseShutter.Location = new System.Drawing.Point(1053, 85);
            this.DispenserCloseShutter.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCloseShutter.Name = "DispenserCloseShutter";
            this.DispenserCloseShutter.Size = new System.Drawing.Size(127, 28);
            this.DispenserCloseShutter.TabIndex = 41;
            this.DispenserCloseShutter.Text = "CloseShutter";
            this.DispenserCloseShutter.UseVisualStyleBackColor = true;
            this.DispenserCloseShutter.Click += new System.EventHandler(this.DispenserCloseShutter_Click);
            // 
            // DispenserOpenShutter
            // 
            this.DispenserOpenShutter.Location = new System.Drawing.Point(1053, 48);
            this.DispenserOpenShutter.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserOpenShutter.Name = "DispenserOpenShutter";
            this.DispenserOpenShutter.Size = new System.Drawing.Size(127, 29);
            this.DispenserOpenShutter.TabIndex = 40;
            this.DispenserOpenShutter.Text = "OpenShutter";
            this.DispenserOpenShutter.UseVisualStyleBackColor = true;
            this.DispenserOpenShutter.Click += new System.EventHandler(this.DispenserOpenShutter_Click);
            // 
            // DispenserDispense
            // 
            this.DispenserDispense.Location = new System.Drawing.Point(1202, 159);
            this.DispenserDispense.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDispense.Name = "DispenserDispense";
            this.DispenserDispense.Size = new System.Drawing.Size(127, 29);
            this.DispenserDispense.TabIndex = 39;
            this.DispenserDispense.Text = "Dispense";
            this.DispenserDispense.UseVisualStyleBackColor = true;
            this.DispenserDispense.Click += new System.EventHandler(this.DispenserDispense_Click);
            // 
            // ClearCommandNonce
            // 
            this.ClearCommandNonce.Location = new System.Drawing.Point(190, 160);
            this.ClearCommandNonce.Margin = new System.Windows.Forms.Padding(0);
            this.ClearCommandNonce.Name = "ClearCommandNonce";
            this.ClearCommandNonce.Size = new System.Drawing.Size(163, 31);
            this.ClearCommandNonce.TabIndex = 38;
            this.ClearCommandNonce.Text = "ClearCommandNonce";
            this.ClearCommandNonce.UseVisualStyleBackColor = true;
            this.ClearCommandNonce.Click += new System.EventHandler(this.DispenserClearCommandNonce_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 160);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 31);
            this.button2.TabIndex = 38;
            this.button2.Text = "GetCommandNonce";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DispenserGetCommandNonce_Click);
            // 
            // DispenserDenominate
            // 
            this.DispenserDenominate.Location = new System.Drawing.Point(1202, 120);
            this.DispenserDenominate.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDenominate.Name = "DispenserDenominate";
            this.DispenserDenominate.Size = new System.Drawing.Size(127, 29);
            this.DispenserDenominate.TabIndex = 38;
            this.DispenserDenominate.Text = "Denominate";
            this.DispenserDenominate.UseVisualStyleBackColor = true;
            this.DispenserDenominate.Click += new System.EventHandler(this.DispenserDenominate_Click);
            // 
            // DispenserPresent
            // 
            this.DispenserPresent.Location = new System.Drawing.Point(1202, 199);
            this.DispenserPresent.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserPresent.Name = "DispenserPresent";
            this.DispenserPresent.Size = new System.Drawing.Size(127, 29);
            this.DispenserPresent.TabIndex = 37;
            this.DispenserPresent.Text = "Present";
            this.DispenserPresent.UseVisualStyleBackColor = true;
            this.DispenserPresent.Click += new System.EventHandler(this.DispenserPresent_Click);
            // 
            // DispenserEndExchange
            // 
            this.DispenserEndExchange.Location = new System.Drawing.Point(1202, 48);
            this.DispenserEndExchange.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserEndExchange.Name = "DispenserEndExchange";
            this.DispenserEndExchange.Size = new System.Drawing.Size(127, 29);
            this.DispenserEndExchange.TabIndex = 36;
            this.DispenserEndExchange.Text = "EndExchange";
            this.DispenserEndExchange.UseVisualStyleBackColor = true;
            this.DispenserEndExchange.Click += new System.EventHandler(this.DispenserEndExchange_Click);
            // 
            // DispenserStartExchange
            // 
            this.DispenserStartExchange.Location = new System.Drawing.Point(1202, 11);
            this.DispenserStartExchange.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStartExchange.Name = "DispenserStartExchange";
            this.DispenserStartExchange.Size = new System.Drawing.Size(127, 29);
            this.DispenserStartExchange.TabIndex = 35;
            this.DispenserStartExchange.Text = "StartExchange";
            this.DispenserStartExchange.UseVisualStyleBackColor = true;
            this.DispenserStartExchange.Click += new System.EventHandler(this.DispenserStartExchange_Click);
            // 
            // DispenserReset
            // 
            this.DispenserReset.Location = new System.Drawing.Point(1053, 11);
            this.DispenserReset.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserReset.Name = "DispenserReset";
            this.DispenserReset.Size = new System.Drawing.Size(127, 29);
            this.DispenserReset.TabIndex = 34;
            this.DispenserReset.Text = "Reset";
            this.DispenserReset.UseVisualStyleBackColor = true;
            this.DispenserReset.Click += new System.EventHandler(this.DispenserReset_Click);
            // 
            // DispenserGetPresentStatus
            // 
            this.DispenserGetPresentStatus.Location = new System.Drawing.Point(902, 217);
            this.DispenserGetPresentStatus.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetPresentStatus.Name = "DispenserGetPresentStatus";
            this.DispenserGetPresentStatus.Size = new System.Drawing.Size(127, 29);
            this.DispenserGetPresentStatus.TabIndex = 33;
            this.DispenserGetPresentStatus.Text = "GetPresentStatus";
            this.DispenserGetPresentStatus.UseVisualStyleBackColor = true;
            this.DispenserGetPresentStatus.Click += new System.EventHandler(this.DispenserGetPresentStatus_Click);
            // 
            // DispenserDeviceType
            // 
            this.DispenserDeviceType.Location = new System.Drawing.Point(791, 57);
            this.DispenserDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDeviceType.Name = "DispenserDeviceType";
            this.DispenserDeviceType.ReadOnly = true;
            this.DispenserDeviceType.Size = new System.Drawing.Size(121, 27);
            this.DispenserDeviceType.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(696, 60);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Device type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(696, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Device status";
            // 
            // DispenserStDevice
            // 
            this.DispenserStDevice.Location = new System.Drawing.Point(791, 16);
            this.DispenserStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStDevice.Name = "DispenserStDevice";
            this.DispenserStDevice.ReadOnly = true;
            this.DispenserStDevice.Size = new System.Drawing.Size(121, 27);
            this.DispenserStDevice.TabIndex = 30;
            // 
            // DispenserGetMixTypes
            // 
            this.DispenserGetMixTypes.Location = new System.Drawing.Point(902, 179);
            this.DispenserGetMixTypes.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetMixTypes.Name = "DispenserGetMixTypes";
            this.DispenserGetMixTypes.Size = new System.Drawing.Size(127, 29);
            this.DispenserGetMixTypes.TabIndex = 29;
            this.DispenserGetMixTypes.Text = "GetMixTypes";
            this.DispenserGetMixTypes.UseVisualStyleBackColor = true;
            this.DispenserGetMixTypes.Click += new System.EventHandler(this.DispenserGetMixTypes_Click);
            // 
            // DispenserCapabilities
            // 
            this.DispenserCapabilities.Location = new System.Drawing.Point(926, 48);
            this.DispenserCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCapabilities.Name = "DispenserCapabilities";
            this.DispenserCapabilities.Size = new System.Drawing.Size(103, 29);
            this.DispenserCapabilities.TabIndex = 28;
            this.DispenserCapabilities.Text = "Capabilities";
            this.DispenserCapabilities.UseVisualStyleBackColor = true;
            this.DispenserCapabilities.Click += new System.EventHandler(this.DispenserCapabilities_Click);
            // 
            // DispenserStatus
            // 
            this.DispenserStatus.Location = new System.Drawing.Point(926, 11);
            this.DispenserStatus.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStatus.Name = "DispenserStatus";
            this.DispenserStatus.Size = new System.Drawing.Size(103, 29);
            this.DispenserStatus.TabIndex = 27;
            this.DispenserStatus.Text = "Status";
            this.DispenserStatus.UseVisualStyleBackColor = true;
            this.DispenserStatus.Click += new System.EventHandler(this.DispenserStatus_Click);
            // 
            // DispenserGetCashUnitInfo
            // 
            this.DispenserGetCashUnitInfo.Location = new System.Drawing.Point(902, 139);
            this.DispenserGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetCashUnitInfo.Name = "DispenserGetCashUnitInfo";
            this.DispenserGetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            this.DispenserGetCashUnitInfo.TabIndex = 26;
            this.DispenserGetCashUnitInfo.Text = "GetCashUnitInfo";
            this.DispenserGetCashUnitInfo.UseVisualStyleBackColor = true;
            this.DispenserGetCashUnitInfo.Click += new System.EventHandler(this.DispenserGetCashUnitInfo_Click);
            // 
            // DispenserServiceURI
            // 
            this.DispenserServiceURI.Location = new System.Drawing.Point(114, 25);
            this.DispenserServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserServiceURI.Name = "DispenserServiceURI";
            this.DispenserServiceURI.Size = new System.Drawing.Size(530, 27);
            this.DispenserServiceURI.TabIndex = 23;
            // 
            // DispenserEvtBox
            // 
            this.DispenserEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserEvtBox.Location = new System.Drawing.Point(933, 272);
            this.DispenserEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserEvtBox.MaxLength = 1048576;
            this.DispenserEvtBox.Multiline = true;
            this.DispenserEvtBox.Name = "DispenserEvtBox";
            this.DispenserEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserEvtBox.Size = new System.Drawing.Size(405, 408);
            this.DispenserEvtBox.TabIndex = 25;
            // 
            // DispenserServiceDiscovery
            // 
            this.DispenserServiceDiscovery.Location = new System.Drawing.Point(502, 136);
            this.DispenserServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserServiceDiscovery.Name = "DispenserServiceDiscovery";
            this.DispenserServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.DispenserServiceDiscovery.TabIndex = 17;
            this.DispenserServiceDiscovery.Text = "Service Discovery";
            this.DispenserServiceDiscovery.UseVisualStyleBackColor = true;
            this.DispenserServiceDiscovery.Click += new System.EventHandler(this.DispenserServiceDiscovery_Click);
            // 
            // DispenserPortNum
            // 
            this.DispenserPortNum.Location = new System.Drawing.Point(114, 57);
            this.DispenserPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserPortNum.Name = "DispenserPortNum";
            this.DispenserPortNum.ReadOnly = true;
            this.DispenserPortNum.Size = new System.Drawing.Size(121, 27);
            this.DispenserPortNum.TabIndex = 18;
            // 
            // DispenserRspBox
            // 
            this.DispenserRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserRspBox.Location = new System.Drawing.Point(488, 272);
            this.DispenserRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserRspBox.MaxLength = 1048576;
            this.DispenserRspBox.Multiline = true;
            this.DispenserRspBox.Name = "DispenserRspBox";
            this.DispenserRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserRspBox.Size = new System.Drawing.Size(423, 408);
            this.DispenserRspBox.TabIndex = 19;
            // 
            // DispenserCmdBox
            // 
            this.DispenserCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserCmdBox.Location = new System.Drawing.Point(18, 272);
            this.DispenserCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCmdBox.MaxLength = 1048576;
            this.DispenserCmdBox.Multiline = true;
            this.DispenserCmdBox.Name = "DispenserCmdBox";
            this.DispenserCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserCmdBox.Size = new System.Drawing.Size(450, 408);
            this.DispenserCmdBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 91);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dispenser URI";
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Location = new System.Drawing.Point(18, 219);
            this.TokenTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.ReadOnly = true;
            this.TokenTextBox.Size = new System.Drawing.Size(867, 27);
            this.TokenTextBox.TabIndex = 21;
            // 
            // DispenserDispURI
            // 
            this.DispenserDispURI.Location = new System.Drawing.Point(114, 88);
            this.DispenserDispURI.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDispURI.Name = "DispenserDispURI";
            this.DispenserDispURI.ReadOnly = true;
            this.DispenserDispURI.Size = new System.Drawing.Size(530, 27);
            this.DispenserDispURI.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 57);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Port Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Service URI";
            // 
            // TextTerminalTab
            // 
            this.TextTerminalTab.Controls.Add(this.TextTerminalSetResolution);
            this.TextTerminalTab.Controls.Add(this.TextTerminalBeep);
            this.TextTerminalTab.Controls.Add(this.TextTerminalReset);
            this.TextTerminalTab.Controls.Add(this.TextTerminalGetKeyDetail);
            this.TextTerminalTab.Controls.Add(this.TextTerminalRead);
            this.TextTerminalTab.Controls.Add(this.TextTerminalWrite);
            this.TextTerminalTab.Controls.Add(this.TextTerminalClearScreen);
            this.TextTerminalTab.Controls.Add(this.TextTerminalDeviceType);
            this.TextTerminalTab.Controls.Add(this.label15);
            this.TextTerminalTab.Controls.Add(this.label16);
            this.TextTerminalTab.Controls.Add(this.TextTerminalStDevice);
            this.TextTerminalTab.Controls.Add(this.TextTerminalCapabilities);
            this.TextTerminalTab.Controls.Add(this.TextTerminalStatus);
            this.TextTerminalTab.Controls.Add(this.TextTerminalServiceURI);
            this.TextTerminalTab.Controls.Add(this.TextTerminalEvtBox);
            this.TextTerminalTab.Controls.Add(this.TextTerminalServiceDiscovery);
            this.TextTerminalTab.Controls.Add(this.TextTerminalPortNum);
            this.TextTerminalTab.Controls.Add(this.TextTerminalRspBox);
            this.TextTerminalTab.Controls.Add(this.TextTerminalCmdBox);
            this.TextTerminalTab.Controls.Add(this.label17);
            this.TextTerminalTab.Controls.Add(this.TextTerminalURI);
            this.TextTerminalTab.Controls.Add(this.label18);
            this.TextTerminalTab.Controls.Add(this.label19);
            this.TextTerminalTab.Location = new System.Drawing.Point(4, 29);
            this.TextTerminalTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextTerminalTab.Name = "TextTerminalTab";
            this.TextTerminalTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextTerminalTab.Size = new System.Drawing.Size(1346, 691);
            this.TextTerminalTab.TabIndex = 2;
            this.TextTerminalTab.Text = "Text Terminal";
            this.TextTerminalTab.UseVisualStyleBackColor = true;
            // 
            // TextTerminalSetResolution
            // 
            this.TextTerminalSetResolution.Location = new System.Drawing.Point(1202, 107);
            this.TextTerminalSetResolution.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalSetResolution.Name = "TextTerminalSetResolution";
            this.TextTerminalSetResolution.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalSetResolution.TabIndex = 59;
            this.TextTerminalSetResolution.Text = "SetResolution";
            this.TextTerminalSetResolution.UseVisualStyleBackColor = true;
            this.TextTerminalSetResolution.Click += new System.EventHandler(this.TextTerminalSetResolution_Click);
            // 
            // TextTerminalBeep
            // 
            this.TextTerminalBeep.Location = new System.Drawing.Point(1073, 43);
            this.TextTerminalBeep.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalBeep.Name = "TextTerminalBeep";
            this.TextTerminalBeep.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalBeep.TabIndex = 56;
            this.TextTerminalBeep.Text = "Beep";
            this.TextTerminalBeep.UseVisualStyleBackColor = true;
            this.TextTerminalBeep.Click += new System.EventHandler(this.TextTerminalBeep_Click);
            // 
            // TextTerminalReset
            // 
            this.TextTerminalReset.Location = new System.Drawing.Point(1073, 11);
            this.TextTerminalReset.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalReset.Name = "TextTerminalReset";
            this.TextTerminalReset.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalReset.TabIndex = 53;
            this.TextTerminalReset.Text = "Reset";
            this.TextTerminalReset.UseVisualStyleBackColor = true;
            this.TextTerminalReset.Click += new System.EventHandler(this.TextTerminalReset_Click);
            // 
            // TextTerminalGetKeyDetail
            // 
            this.TextTerminalGetKeyDetail.Location = new System.Drawing.Point(1073, 75);
            this.TextTerminalGetKeyDetail.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalGetKeyDetail.Name = "TextTerminalGetKeyDetail";
            this.TextTerminalGetKeyDetail.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalGetKeyDetail.TabIndex = 52;
            this.TextTerminalGetKeyDetail.Text = "GetKeyDetail";
            this.TextTerminalGetKeyDetail.UseVisualStyleBackColor = true;
            this.TextTerminalGetKeyDetail.Click += new System.EventHandler(this.TextTerminalGetKeyDetail_Click);
            // 
            // TextTerminalRead
            // 
            this.TextTerminalRead.Location = new System.Drawing.Point(1202, 75);
            this.TextTerminalRead.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalRead.Name = "TextTerminalRead";
            this.TextTerminalRead.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalRead.TabIndex = 51;
            this.TextTerminalRead.Text = "Read";
            this.TextTerminalRead.UseVisualStyleBackColor = true;
            this.TextTerminalRead.Click += new System.EventHandler(this.TextTerminalRead_Click);
            // 
            // TextTerminalWrite
            // 
            this.TextTerminalWrite.Location = new System.Drawing.Point(1202, 43);
            this.TextTerminalWrite.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalWrite.Name = "TextTerminalWrite";
            this.TextTerminalWrite.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalWrite.TabIndex = 50;
            this.TextTerminalWrite.Text = "Write";
            this.TextTerminalWrite.UseVisualStyleBackColor = true;
            this.TextTerminalWrite.Click += new System.EventHandler(this.TextTerminalWrite_Click);
            // 
            // TextTerminalClearScreen
            // 
            this.TextTerminalClearScreen.Location = new System.Drawing.Point(1202, 11);
            this.TextTerminalClearScreen.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalClearScreen.Name = "TextTerminalClearScreen";
            this.TextTerminalClearScreen.Size = new System.Drawing.Size(127, 29);
            this.TextTerminalClearScreen.TabIndex = 49;
            this.TextTerminalClearScreen.Text = "ClearScreen";
            this.TextTerminalClearScreen.UseVisualStyleBackColor = true;
            this.TextTerminalClearScreen.Click += new System.EventHandler(this.TextTerminalClearScreen_Click);
            // 
            // TextTerminalDeviceType
            // 
            this.TextTerminalDeviceType.Location = new System.Drawing.Point(792, 55);
            this.TextTerminalDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalDeviceType.Name = "TextTerminalDeviceType";
            this.TextTerminalDeviceType.ReadOnly = true;
            this.TextTerminalDeviceType.Size = new System.Drawing.Size(121, 27);
            this.TextTerminalDeviceType.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(697, 57);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 20);
            this.label15.TabIndex = 47;
            this.label15.Text = "Device type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(697, 12);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 20);
            this.label16.TabIndex = 43;
            this.label16.Text = "Device status";
            // 
            // TextTerminalStDevice
            // 
            this.TextTerminalStDevice.Location = new System.Drawing.Point(792, 13);
            this.TextTerminalStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalStDevice.Name = "TextTerminalStDevice";
            this.TextTerminalStDevice.ReadOnly = true;
            this.TextTerminalStDevice.Size = new System.Drawing.Size(121, 27);
            this.TextTerminalStDevice.TabIndex = 46;
            // 
            // TextTerminalCapabilities
            // 
            this.TextTerminalCapabilities.Location = new System.Drawing.Point(927, 45);
            this.TextTerminalCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalCapabilities.Name = "TextTerminalCapabilities";
            this.TextTerminalCapabilities.Size = new System.Drawing.Size(103, 29);
            this.TextTerminalCapabilities.TabIndex = 45;
            this.TextTerminalCapabilities.Text = "Capabilities";
            this.TextTerminalCapabilities.UseVisualStyleBackColor = true;
            this.TextTerminalCapabilities.Click += new System.EventHandler(this.TextTerminalCapabilities_Click);
            // 
            // TextTerminalStatus
            // 
            this.TextTerminalStatus.Location = new System.Drawing.Point(927, 8);
            this.TextTerminalStatus.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalStatus.Name = "TextTerminalStatus";
            this.TextTerminalStatus.Size = new System.Drawing.Size(103, 29);
            this.TextTerminalStatus.TabIndex = 44;
            this.TextTerminalStatus.Text = "Status";
            this.TextTerminalStatus.UseVisualStyleBackColor = true;
            this.TextTerminalStatus.Click += new System.EventHandler(this.TextTerminalStatus_Click);
            // 
            // TextTerminalServiceURI
            // 
            this.TextTerminalServiceURI.Location = new System.Drawing.Point(115, 23);
            this.TextTerminalServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalServiceURI.Name = "TextTerminalServiceURI";
            this.TextTerminalServiceURI.Size = new System.Drawing.Size(530, 27);
            this.TextTerminalServiceURI.TabIndex = 40;
            // 
            // TextTerminalEvtBox
            // 
            this.TextTerminalEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalEvtBox.Location = new System.Drawing.Point(934, 269);
            this.TextTerminalEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalEvtBox.MaxLength = 1048576;
            this.TextTerminalEvtBox.Multiline = true;
            this.TextTerminalEvtBox.Name = "TextTerminalEvtBox";
            this.TextTerminalEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalEvtBox.Size = new System.Drawing.Size(405, 408);
            this.TextTerminalEvtBox.TabIndex = 42;
            // 
            // TextTerminalServiceDiscovery
            // 
            this.TextTerminalServiceDiscovery.Location = new System.Drawing.Point(503, 133);
            this.TextTerminalServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalServiceDiscovery.Name = "TextTerminalServiceDiscovery";
            this.TextTerminalServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.TextTerminalServiceDiscovery.TabIndex = 34;
            this.TextTerminalServiceDiscovery.Text = "Service Discovery";
            this.TextTerminalServiceDiscovery.UseVisualStyleBackColor = true;
            this.TextTerminalServiceDiscovery.Click += new System.EventHandler(this.TextTerminalServiceDiscovery_Click);
            // 
            // TextTerminalPortNum
            // 
            this.TextTerminalPortNum.Location = new System.Drawing.Point(115, 55);
            this.TextTerminalPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalPortNum.Name = "TextTerminalPortNum";
            this.TextTerminalPortNum.ReadOnly = true;
            this.TextTerminalPortNum.Size = new System.Drawing.Size(121, 27);
            this.TextTerminalPortNum.TabIndex = 35;
            // 
            // TextTerminalRspBox
            // 
            this.TextTerminalRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalRspBox.Location = new System.Drawing.Point(489, 269);
            this.TextTerminalRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalRspBox.MaxLength = 1048576;
            this.TextTerminalRspBox.Multiline = true;
            this.TextTerminalRspBox.Name = "TextTerminalRspBox";
            this.TextTerminalRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalRspBox.Size = new System.Drawing.Size(423, 408);
            this.TextTerminalRspBox.TabIndex = 36;
            // 
            // TextTerminalCmdBox
            // 
            this.TextTerminalCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalCmdBox.Location = new System.Drawing.Point(19, 269);
            this.TextTerminalCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalCmdBox.MaxLength = 1048576;
            this.TextTerminalCmdBox.Multiline = true;
            this.TextTerminalCmdBox.Name = "TextTerminalCmdBox";
            this.TextTerminalCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalCmdBox.Size = new System.Drawing.Size(450, 408);
            this.TextTerminalCmdBox.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 88);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 20);
            this.label17.TabIndex = 37;
            this.label17.Text = "TextTerminal URI";
            // 
            // TextTerminalURI
            // 
            this.TextTerminalURI.Location = new System.Drawing.Point(115, 85);
            this.TextTerminalURI.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalURI.Name = "TextTerminalURI";
            this.TextTerminalURI.ReadOnly = true;
            this.TextTerminalURI.Size = new System.Drawing.Size(530, 27);
            this.TextTerminalURI.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 55);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Port Number";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 23);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 20);
            this.label19.TabIndex = 41;
            this.label19.Text = "Service URI";
            // 
            // EncryptorTab
            // 
            this.EncryptorTab.Controls.Add(this.EncryptorDeleteKey);
            this.EncryptorTab.Controls.Add(this.EncryptorGenerateMAC);
            this.EncryptorTab.Controls.Add(this.EncryptorEncrypt);
            this.EncryptorTab.Controls.Add(this.EncryptorGenerateRandom);
            this.EncryptorTab.Controls.Add(this.EncryptorReset);
            this.EncryptorTab.Controls.Add(this.EncryptorImportKey);
            this.EncryptorTab.Controls.Add(this.EncryptorInitialization);
            this.EncryptorTab.Controls.Add(this.EncryptorGetKeyNames);
            this.EncryptorTab.Controls.Add(this.label25);
            this.EncryptorTab.Controls.Add(this.EncryptorKeyNamelistBox);
            this.EncryptorTab.Controls.Add(this.label23);
            this.EncryptorTab.Controls.Add(this.label24);
            this.EncryptorTab.Controls.Add(this.EncryptorEvtBox);
            this.EncryptorTab.Controls.Add(this.EncryptorRspBox);
            this.EncryptorTab.Controls.Add(this.EncryptorCmdBox);
            this.EncryptorTab.Controls.Add(this.EncryptorMaxKeyNum);
            this.EncryptorTab.Controls.Add(this.EncryptorStDevice);
            this.EncryptorTab.Controls.Add(this.EncryptorCapabilities);
            this.EncryptorTab.Controls.Add(this.EncryptorStatus);
            this.EncryptorTab.Controls.Add(this.EncryptorServiceURI);
            this.EncryptorTab.Controls.Add(this.EncryptorServiceDiscovery);
            this.EncryptorTab.Controls.Add(this.EncryptorPortNum);
            this.EncryptorTab.Controls.Add(this.label20);
            this.EncryptorTab.Controls.Add(this.EncryptorURI);
            this.EncryptorTab.Controls.Add(this.label21);
            this.EncryptorTab.Controls.Add(this.label22);
            this.EncryptorTab.Location = new System.Drawing.Point(4, 29);
            this.EncryptorTab.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorTab.Name = "EncryptorTab";
            this.EncryptorTab.Size = new System.Drawing.Size(1346, 691);
            this.EncryptorTab.TabIndex = 3;
            this.EncryptorTab.Text = "Encryptor";
            this.EncryptorTab.UseVisualStyleBackColor = true;
            // 
            // EncryptorDeleteKey
            // 
            this.EncryptorDeleteKey.Location = new System.Drawing.Point(1213, 55);
            this.EncryptorDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorDeleteKey.Name = "EncryptorDeleteKey";
            this.EncryptorDeleteKey.Size = new System.Drawing.Size(97, 28);
            this.EncryptorDeleteKey.TabIndex = 59;
            this.EncryptorDeleteKey.Text = "DeleteKey";
            this.EncryptorDeleteKey.UseVisualStyleBackColor = true;
            this.EncryptorDeleteKey.Click += new System.EventHandler(this.EncryptorDeleteKey_Click);
            // 
            // EncryptorGenerateMAC
            // 
            this.EncryptorGenerateMAC.Location = new System.Drawing.Point(1096, 144);
            this.EncryptorGenerateMAC.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGenerateMAC.Name = "EncryptorGenerateMAC";
            this.EncryptorGenerateMAC.Size = new System.Drawing.Size(106, 35);
            this.EncryptorGenerateMAC.TabIndex = 58;
            this.EncryptorGenerateMAC.Text = "GenerateMAC";
            this.EncryptorGenerateMAC.UseVisualStyleBackColor = true;
            this.EncryptorGenerateMAC.Click += new System.EventHandler(this.EncryptorGenerateMAC_Click);
            // 
            // EncryptorEncrypt
            // 
            this.EncryptorEncrypt.Location = new System.Drawing.Point(1096, 99);
            this.EncryptorEncrypt.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorEncrypt.Name = "EncryptorEncrypt";
            this.EncryptorEncrypt.Size = new System.Drawing.Size(106, 29);
            this.EncryptorEncrypt.TabIndex = 57;
            this.EncryptorEncrypt.Text = "Encrypt";
            this.EncryptorEncrypt.UseVisualStyleBackColor = true;
            this.EncryptorEncrypt.Click += new System.EventHandler(this.EncryptorEncrypt_Click);
            // 
            // EncryptorGenerateRandom
            // 
            this.EncryptorGenerateRandom.Location = new System.Drawing.Point(1096, 192);
            this.EncryptorGenerateRandom.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGenerateRandom.Name = "EncryptorGenerateRandom";
            this.EncryptorGenerateRandom.Size = new System.Drawing.Size(130, 32);
            this.EncryptorGenerateRandom.TabIndex = 56;
            this.EncryptorGenerateRandom.Text = "GenerateRandom";
            this.EncryptorGenerateRandom.UseVisualStyleBackColor = true;
            this.EncryptorGenerateRandom.Click += new System.EventHandler(this.EncryptorGenerateRandom_Click);
            // 
            // EncryptorReset
            // 
            this.EncryptorReset.Location = new System.Drawing.Point(1213, 13);
            this.EncryptorReset.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorReset.Name = "EncryptorReset";
            this.EncryptorReset.Size = new System.Drawing.Size(97, 29);
            this.EncryptorReset.TabIndex = 55;
            this.EncryptorReset.Text = "Reset";
            this.EncryptorReset.UseVisualStyleBackColor = true;
            this.EncryptorReset.Click += new System.EventHandler(this.EncryptorReset_Click);
            // 
            // EncryptorImportKey
            // 
            this.EncryptorImportKey.Location = new System.Drawing.Point(1096, 55);
            this.EncryptorImportKey.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorImportKey.Name = "EncryptorImportKey";
            this.EncryptorImportKey.Size = new System.Drawing.Size(105, 28);
            this.EncryptorImportKey.TabIndex = 54;
            this.EncryptorImportKey.Text = "ImportKey";
            this.EncryptorImportKey.UseVisualStyleBackColor = true;
            this.EncryptorImportKey.Click += new System.EventHandler(this.EncryptorImportKey_Click);
            // 
            // EncryptorInitialization
            // 
            this.EncryptorInitialization.Location = new System.Drawing.Point(1096, 13);
            this.EncryptorInitialization.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorInitialization.Name = "EncryptorInitialization";
            this.EncryptorInitialization.Size = new System.Drawing.Size(105, 29);
            this.EncryptorInitialization.TabIndex = 53;
            this.EncryptorInitialization.Text = "Initialization";
            this.EncryptorInitialization.UseVisualStyleBackColor = true;
            this.EncryptorInitialization.Click += new System.EventHandler(this.EncryptorInitialization_Click);
            // 
            // EncryptorGetKeyNames
            // 
            this.EncryptorGetKeyNames.Location = new System.Drawing.Point(930, 147);
            this.EncryptorGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGetKeyNames.Name = "EncryptorGetKeyNames";
            this.EncryptorGetKeyNames.Size = new System.Drawing.Size(103, 31);
            this.EncryptorGetKeyNames.TabIndex = 52;
            this.EncryptorGetKeyNames.Text = "GetKeyNames";
            this.EncryptorGetKeyNames.UseVisualStyleBackColor = true;
            this.EncryptorGetKeyNames.Click += new System.EventHandler(this.EncryptorGetKeyNames_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(677, 119);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 20);
            this.label25.TabIndex = 51;
            this.label25.Text = "Key Names";
            // 
            // EncryptorKeyNamelistBox
            // 
            this.EncryptorKeyNamelistBox.FormattingEnabled = true;
            this.EncryptorKeyNamelistBox.ItemHeight = 20;
            this.EncryptorKeyNamelistBox.Location = new System.Drawing.Point(677, 147);
            this.EncryptorKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorKeyNamelistBox.Name = "EncryptorKeyNamelistBox";
            this.EncryptorKeyNamelistBox.Size = new System.Drawing.Size(244, 104);
            this.EncryptorKeyNamelistBox.TabIndex = 50;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(677, 63);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 20);
            this.label23.TabIndex = 49;
            this.label23.Text = "Max key number";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(698, 19);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 20);
            this.label24.TabIndex = 48;
            this.label24.Text = "Device status";
            // 
            // EncryptorEvtBox
            // 
            this.EncryptorEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorEvtBox.Location = new System.Drawing.Point(930, 269);
            this.EncryptorEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorEvtBox.MaxLength = 1048576;
            this.EncryptorEvtBox.Multiline = true;
            this.EncryptorEvtBox.Name = "EncryptorEvtBox";
            this.EncryptorEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorEvtBox.Size = new System.Drawing.Size(405, 408);
            this.EncryptorEvtBox.TabIndex = 46;
            // 
            // EncryptorRspBox
            // 
            this.EncryptorRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorRspBox.Location = new System.Drawing.Point(486, 269);
            this.EncryptorRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorRspBox.MaxLength = 1048576;
            this.EncryptorRspBox.Multiline = true;
            this.EncryptorRspBox.Name = "EncryptorRspBox";
            this.EncryptorRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorRspBox.Size = new System.Drawing.Size(423, 408);
            this.EncryptorRspBox.TabIndex = 45;
            // 
            // EncryptorCmdBox
            // 
            this.EncryptorCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorCmdBox.Location = new System.Drawing.Point(16, 269);
            this.EncryptorCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorCmdBox.MaxLength = 1048576;
            this.EncryptorCmdBox.Multiline = true;
            this.EncryptorCmdBox.Name = "EncryptorCmdBox";
            this.EncryptorCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorCmdBox.Size = new System.Drawing.Size(450, 408);
            this.EncryptorCmdBox.TabIndex = 44;
            // 
            // EncryptorMaxKeyNum
            // 
            this.EncryptorMaxKeyNum.Location = new System.Drawing.Point(795, 60);
            this.EncryptorMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorMaxKeyNum.Name = "EncryptorMaxKeyNum";
            this.EncryptorMaxKeyNum.ReadOnly = true;
            this.EncryptorMaxKeyNum.Size = new System.Drawing.Size(121, 27);
            this.EncryptorMaxKeyNum.TabIndex = 43;
            // 
            // EncryptorStDevice
            // 
            this.EncryptorStDevice.Location = new System.Drawing.Point(795, 19);
            this.EncryptorStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorStDevice.Name = "EncryptorStDevice";
            this.EncryptorStDevice.ReadOnly = true;
            this.EncryptorStDevice.Size = new System.Drawing.Size(121, 27);
            this.EncryptorStDevice.TabIndex = 42;
            // 
            // EncryptorCapabilities
            // 
            this.EncryptorCapabilities.Location = new System.Drawing.Point(930, 51);
            this.EncryptorCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorCapabilities.Name = "EncryptorCapabilities";
            this.EncryptorCapabilities.Size = new System.Drawing.Size(103, 29);
            this.EncryptorCapabilities.TabIndex = 41;
            this.EncryptorCapabilities.Text = "Capabilities";
            this.EncryptorCapabilities.UseVisualStyleBackColor = true;
            this.EncryptorCapabilities.Click += new System.EventHandler(this.EncryptorCapabilities_Click);
            // 
            // EncryptorStatus
            // 
            this.EncryptorStatus.Location = new System.Drawing.Point(930, 13);
            this.EncryptorStatus.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorStatus.Name = "EncryptorStatus";
            this.EncryptorStatus.Size = new System.Drawing.Size(103, 29);
            this.EncryptorStatus.TabIndex = 40;
            this.EncryptorStatus.Text = "Status";
            this.EncryptorStatus.UseVisualStyleBackColor = true;
            this.EncryptorStatus.Click += new System.EventHandler(this.EncryptorStatus_Click);
            // 
            // EncryptorServiceURI
            // 
            this.EncryptorServiceURI.Location = new System.Drawing.Point(117, 16);
            this.EncryptorServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorServiceURI.Name = "EncryptorServiceURI";
            this.EncryptorServiceURI.Size = new System.Drawing.Size(530, 27);
            this.EncryptorServiceURI.TabIndex = 38;
            // 
            // EncryptorServiceDiscovery
            // 
            this.EncryptorServiceDiscovery.Location = new System.Drawing.Point(504, 127);
            this.EncryptorServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorServiceDiscovery.Name = "EncryptorServiceDiscovery";
            this.EncryptorServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.EncryptorServiceDiscovery.TabIndex = 33;
            this.EncryptorServiceDiscovery.Text = "Service Discovery";
            this.EncryptorServiceDiscovery.UseVisualStyleBackColor = true;
            this.EncryptorServiceDiscovery.Click += new System.EventHandler(this.EncryptorServiceDiscovery_Click);
            // 
            // EncryptorPortNum
            // 
            this.EncryptorPortNum.Location = new System.Drawing.Point(117, 49);
            this.EncryptorPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorPortNum.Name = "EncryptorPortNum";
            this.EncryptorPortNum.ReadOnly = true;
            this.EncryptorPortNum.Size = new System.Drawing.Size(121, 27);
            this.EncryptorPortNum.TabIndex = 34;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 81);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 20);
            this.label20.TabIndex = 35;
            this.label20.Text = "Encryptor URI";
            // 
            // EncryptorURI
            // 
            this.EncryptorURI.Location = new System.Drawing.Point(117, 79);
            this.EncryptorURI.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorURI.Name = "EncryptorURI";
            this.EncryptorURI.ReadOnly = true;
            this.EncryptorURI.Size = new System.Drawing.Size(530, 27);
            this.EncryptorURI.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 49);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 20);
            this.label21.TabIndex = 37;
            this.label21.Text = "Port Number";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 16);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 20);
            this.label22.TabIndex = 39;
            this.label22.Text = "Service URI";
            // 
            // PinPadTab
            // 
            this.PinPadTab.Controls.Add(this.PinPadGetLayout);
            this.PinPadTab.Controls.Add(this.PinPadEnterData);
            this.PinPadTab.Controls.Add(this.PinPadFormatPin);
            this.PinPadTab.Controls.Add(this.PinPadEnterPin);
            this.PinPadTab.Controls.Add(this.PinPadLoadPinKey);
            this.PinPadTab.Controls.Add(this.PinPadSecureKeyEntryPart2);
            this.PinPadTab.Controls.Add(this.PinPadSecureKeyEntryPart1);
            this.PinPadTab.Controls.Add(this.PinPadDeleteKey);
            this.PinPadTab.Controls.Add(this.PinPadReset);
            this.PinPadTab.Controls.Add(this.PinPadImportKey);
            this.PinPadTab.Controls.Add(this.PinPadInitialization);
            this.PinPadTab.Controls.Add(this.PinPadGetKeyNames);
            this.PinPadTab.Controls.Add(this.label26);
            this.PinPadTab.Controls.Add(this.PinPadKeyNamelistBox);
            this.PinPadTab.Controls.Add(this.label27);
            this.PinPadTab.Controls.Add(this.label28);
            this.PinPadTab.Controls.Add(this.PinPadEvtBox);
            this.PinPadTab.Controls.Add(this.PinPadRspBox);
            this.PinPadTab.Controls.Add(this.PinPadCmdBox);
            this.PinPadTab.Controls.Add(this.PinPadMaxKeyNum);
            this.PinPadTab.Controls.Add(this.PinPadStDevice);
            this.PinPadTab.Controls.Add(this.PinPadCapabilities);
            this.PinPadTab.Controls.Add(this.PinPadStatus);
            this.PinPadTab.Controls.Add(this.PinPadServiceURI);
            this.PinPadTab.Controls.Add(this.PinPadServiceDiscovery);
            this.PinPadTab.Controls.Add(this.PinPadPortNum);
            this.PinPadTab.Controls.Add(this.label29);
            this.PinPadTab.Controls.Add(this.PinPadURI);
            this.PinPadTab.Controls.Add(this.label30);
            this.PinPadTab.Controls.Add(this.label31);
            this.PinPadTab.Location = new System.Drawing.Point(4, 29);
            this.PinPadTab.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadTab.Name = "PinPadTab";
            this.PinPadTab.Size = new System.Drawing.Size(1346, 691);
            this.PinPadTab.TabIndex = 4;
            this.PinPadTab.Text = "PinPad";
            this.PinPadTab.UseVisualStyleBackColor = true;
            // 
            // PinPadGetLayout
            // 
            this.PinPadGetLayout.Location = new System.Drawing.Point(933, 191);
            this.PinPadGetLayout.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadGetLayout.Name = "PinPadGetLayout";
            this.PinPadGetLayout.Size = new System.Drawing.Size(103, 31);
            this.PinPadGetLayout.TabIndex = 92;
            this.PinPadGetLayout.Text = "Get Layout";
            this.PinPadGetLayout.UseVisualStyleBackColor = true;
            this.PinPadGetLayout.Click += new System.EventHandler(this.PinPadGetLayout_Click);
            // 
            // PinPadEnterData
            // 
            this.PinPadEnterData.Location = new System.Drawing.Point(1160, 52);
            this.PinPadEnterData.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEnterData.Name = "PinPadEnterData";
            this.PinPadEnterData.Size = new System.Drawing.Size(97, 28);
            this.PinPadEnterData.TabIndex = 91;
            this.PinPadEnterData.Text = "Enter Data";
            this.PinPadEnterData.UseVisualStyleBackColor = true;
            this.PinPadEnterData.Click += new System.EventHandler(this.PinPadEnterData_Click);
            // 
            // PinPadFormatPin
            // 
            this.PinPadFormatPin.Location = new System.Drawing.Point(1254, 221);
            this.PinPadFormatPin.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadFormatPin.Name = "PinPadFormatPin";
            this.PinPadFormatPin.Size = new System.Drawing.Size(88, 28);
            this.PinPadFormatPin.TabIndex = 90;
            this.PinPadFormatPin.Text = "Format PIN";
            this.PinPadFormatPin.UseVisualStyleBackColor = true;
            this.PinPadFormatPin.Click += new System.EventHandler(this.PinPadFormatPin_Click);
            // 
            // PinPadEnterPin
            // 
            this.PinPadEnterPin.Location = new System.Drawing.Point(1158, 221);
            this.PinPadEnterPin.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEnterPin.Name = "PinPadEnterPin";
            this.PinPadEnterPin.Size = new System.Drawing.Size(88, 28);
            this.PinPadEnterPin.TabIndex = 89;
            this.PinPadEnterPin.Text = "Enter PIN";
            this.PinPadEnterPin.UseVisualStyleBackColor = true;
            this.PinPadEnterPin.Click += new System.EventHandler(this.PinPadEnterPin_Click);
            // 
            // PinPadLoadPinKey
            // 
            this.PinPadLoadPinKey.Location = new System.Drawing.Point(1043, 221);
            this.PinPadLoadPinKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadLoadPinKey.Name = "PinPadLoadPinKey";
            this.PinPadLoadPinKey.Size = new System.Drawing.Size(106, 28);
            this.PinPadLoadPinKey.TabIndex = 88;
            this.PinPadLoadPinKey.Text = "Load PIN Key";
            this.PinPadLoadPinKey.UseVisualStyleBackColor = true;
            this.PinPadLoadPinKey.Click += new System.EventHandler(this.PinPadLoadPinKey_Click);
            // 
            // PinPadSecureKeyEntryPart2
            // 
            this.PinPadSecureKeyEntryPart2.Location = new System.Drawing.Point(1045, 136);
            this.PinPadSecureKeyEntryPart2.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadSecureKeyEntryPart2.Name = "PinPadSecureKeyEntryPart2";
            this.PinPadSecureKeyEntryPart2.Size = new System.Drawing.Size(168, 28);
            this.PinPadSecureKeyEntryPart2.TabIndex = 87;
            this.PinPadSecureKeyEntryPart2.Text = "SecureKeyEntry Part2";
            this.PinPadSecureKeyEntryPart2.UseVisualStyleBackColor = true;
            this.PinPadSecureKeyEntryPart2.Click += new System.EventHandler(this.PinPadSecureKeyEntryPart2_Click);
            // 
            // PinPadSecureKeyEntryPart1
            // 
            this.PinPadSecureKeyEntryPart1.Location = new System.Drawing.Point(1045, 100);
            this.PinPadSecureKeyEntryPart1.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadSecureKeyEntryPart1.Name = "PinPadSecureKeyEntryPart1";
            this.PinPadSecureKeyEntryPart1.Size = new System.Drawing.Size(168, 28);
            this.PinPadSecureKeyEntryPart1.TabIndex = 86;
            this.PinPadSecureKeyEntryPart1.Text = "SecureKeyEntry Part1";
            this.PinPadSecureKeyEntryPart1.UseVisualStyleBackColor = true;
            this.PinPadSecureKeyEntryPart1.Click += new System.EventHandler(this.PinPadSecureKeyEntryPart1_Click);
            // 
            // PinPadDeleteKey
            // 
            this.PinPadDeleteKey.Location = new System.Drawing.Point(1045, 52);
            this.PinPadDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadDeleteKey.Name = "PinPadDeleteKey";
            this.PinPadDeleteKey.Size = new System.Drawing.Size(106, 28);
            this.PinPadDeleteKey.TabIndex = 85;
            this.PinPadDeleteKey.Text = "DeleteKey";
            this.PinPadDeleteKey.UseVisualStyleBackColor = true;
            this.PinPadDeleteKey.Click += new System.EventHandler(this.PinPadDeleteKey_Click);
            // 
            // PinPadReset
            // 
            this.PinPadReset.Location = new System.Drawing.Point(1160, 13);
            this.PinPadReset.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadReset.Name = "PinPadReset";
            this.PinPadReset.Size = new System.Drawing.Size(97, 29);
            this.PinPadReset.TabIndex = 81;
            this.PinPadReset.Text = "Reset";
            this.PinPadReset.UseVisualStyleBackColor = true;
            this.PinPadReset.Click += new System.EventHandler(this.PinPadReset_Click);
            // 
            // PinPadImportKey
            // 
            this.PinPadImportKey.Location = new System.Drawing.Point(1045, 173);
            this.PinPadImportKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadImportKey.Name = "PinPadImportKey";
            this.PinPadImportKey.Size = new System.Drawing.Size(168, 28);
            this.PinPadImportKey.TabIndex = 80;
            this.PinPadImportKey.Text = "ImportKey (Secure)";
            this.PinPadImportKey.UseVisualStyleBackColor = true;
            this.PinPadImportKey.Click += new System.EventHandler(this.PinPadImportKey_Click);
            // 
            // PinPadInitialization
            // 
            this.PinPadInitialization.Location = new System.Drawing.Point(1045, 15);
            this.PinPadInitialization.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadInitialization.Name = "PinPadInitialization";
            this.PinPadInitialization.Size = new System.Drawing.Size(105, 29);
            this.PinPadInitialization.TabIndex = 79;
            this.PinPadInitialization.Text = "Initialization";
            this.PinPadInitialization.UseVisualStyleBackColor = true;
            this.PinPadInitialization.Click += new System.EventHandler(this.PinPadInitialization_Click);
            // 
            // PinPadGetKeyNames
            // 
            this.PinPadGetKeyNames.Location = new System.Drawing.Point(933, 148);
            this.PinPadGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadGetKeyNames.Name = "PinPadGetKeyNames";
            this.PinPadGetKeyNames.Size = new System.Drawing.Size(103, 31);
            this.PinPadGetKeyNames.TabIndex = 78;
            this.PinPadGetKeyNames.Text = "GetKeyNames";
            this.PinPadGetKeyNames.UseVisualStyleBackColor = true;
            this.PinPadGetKeyNames.Click += new System.EventHandler(this.PinPadGetKeyNames_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(679, 120);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 20);
            this.label26.TabIndex = 77;
            this.label26.Text = "Key Names";
            // 
            // PinPadKeyNamelistBox
            // 
            this.PinPadKeyNamelistBox.FormattingEnabled = true;
            this.PinPadKeyNamelistBox.ItemHeight = 20;
            this.PinPadKeyNamelistBox.Location = new System.Drawing.Point(679, 148);
            this.PinPadKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadKeyNamelistBox.Name = "PinPadKeyNamelistBox";
            this.PinPadKeyNamelistBox.Size = new System.Drawing.Size(244, 104);
            this.PinPadKeyNamelistBox.TabIndex = 76;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(679, 64);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(118, 20);
            this.label27.TabIndex = 75;
            this.label27.Text = "Max key number";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(702, 20);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 20);
            this.label28.TabIndex = 74;
            this.label28.Text = "Device status";
            // 
            // PinPadEvtBox
            // 
            this.PinPadEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadEvtBox.Location = new System.Drawing.Point(933, 271);
            this.PinPadEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEvtBox.MaxLength = 1048576;
            this.PinPadEvtBox.Multiline = true;
            this.PinPadEvtBox.Name = "PinPadEvtBox";
            this.PinPadEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadEvtBox.Size = new System.Drawing.Size(405, 408);
            this.PinPadEvtBox.TabIndex = 73;
            // 
            // PinPadRspBox
            // 
            this.PinPadRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadRspBox.Location = new System.Drawing.Point(488, 271);
            this.PinPadRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadRspBox.MaxLength = 1048576;
            this.PinPadRspBox.Multiline = true;
            this.PinPadRspBox.Name = "PinPadRspBox";
            this.PinPadRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadRspBox.Size = new System.Drawing.Size(423, 408);
            this.PinPadRspBox.TabIndex = 72;
            // 
            // PinPadCmdBox
            // 
            this.PinPadCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadCmdBox.Location = new System.Drawing.Point(18, 271);
            this.PinPadCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadCmdBox.MaxLength = 1048576;
            this.PinPadCmdBox.Multiline = true;
            this.PinPadCmdBox.Name = "PinPadCmdBox";
            this.PinPadCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadCmdBox.Size = new System.Drawing.Size(450, 408);
            this.PinPadCmdBox.TabIndex = 71;
            // 
            // PinPadMaxKeyNum
            // 
            this.PinPadMaxKeyNum.Location = new System.Drawing.Point(798, 61);
            this.PinPadMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadMaxKeyNum.Name = "PinPadMaxKeyNum";
            this.PinPadMaxKeyNum.ReadOnly = true;
            this.PinPadMaxKeyNum.Size = new System.Drawing.Size(121, 27);
            this.PinPadMaxKeyNum.TabIndex = 70;
            // 
            // PinPadStDevice
            // 
            this.PinPadStDevice.Location = new System.Drawing.Point(798, 20);
            this.PinPadStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadStDevice.Name = "PinPadStDevice";
            this.PinPadStDevice.ReadOnly = true;
            this.PinPadStDevice.Size = new System.Drawing.Size(121, 27);
            this.PinPadStDevice.TabIndex = 69;
            // 
            // PinPadCapabilities
            // 
            this.PinPadCapabilities.Location = new System.Drawing.Point(933, 51);
            this.PinPadCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadCapabilities.Name = "PinPadCapabilities";
            this.PinPadCapabilities.Size = new System.Drawing.Size(103, 29);
            this.PinPadCapabilities.TabIndex = 68;
            this.PinPadCapabilities.Text = "Capabilities";
            this.PinPadCapabilities.UseVisualStyleBackColor = true;
            this.PinPadCapabilities.Click += new System.EventHandler(this.PinPadCapabilities_Click);
            // 
            // PinPadStatus
            // 
            this.PinPadStatus.Location = new System.Drawing.Point(933, 15);
            this.PinPadStatus.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadStatus.Name = "PinPadStatus";
            this.PinPadStatus.Size = new System.Drawing.Size(103, 29);
            this.PinPadStatus.TabIndex = 67;
            this.PinPadStatus.Text = "Status";
            this.PinPadStatus.UseVisualStyleBackColor = true;
            this.PinPadStatus.Click += new System.EventHandler(this.PinPadStatus_Click);
            // 
            // PinPadServiceURI
            // 
            this.PinPadServiceURI.Location = new System.Drawing.Point(119, 17);
            this.PinPadServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadServiceURI.Name = "PinPadServiceURI";
            this.PinPadServiceURI.Size = new System.Drawing.Size(530, 27);
            this.PinPadServiceURI.TabIndex = 65;
            // 
            // PinPadServiceDiscovery
            // 
            this.PinPadServiceDiscovery.Location = new System.Drawing.Point(506, 128);
            this.PinPadServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadServiceDiscovery.Name = "PinPadServiceDiscovery";
            this.PinPadServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.PinPadServiceDiscovery.TabIndex = 60;
            this.PinPadServiceDiscovery.Text = "Service Discovery";
            this.PinPadServiceDiscovery.UseVisualStyleBackColor = true;
            this.PinPadServiceDiscovery.Click += new System.EventHandler(this.PinPadServiceDiscovery_Click);
            // 
            // PinPadPortNum
            // 
            this.PinPadPortNum.Location = new System.Drawing.Point(119, 49);
            this.PinPadPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadPortNum.Name = "PinPadPortNum";
            this.PinPadPortNum.ReadOnly = true;
            this.PinPadPortNum.Size = new System.Drawing.Size(121, 27);
            this.PinPadPortNum.TabIndex = 61;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 83);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 20);
            this.label29.TabIndex = 62;
            this.label29.Text = "Encryptor URI";
            // 
            // PinPadURI
            // 
            this.PinPadURI.Location = new System.Drawing.Point(119, 80);
            this.PinPadURI.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadURI.Name = "PinPadURI";
            this.PinPadURI.ReadOnly = true;
            this.PinPadURI.Size = new System.Drawing.Size(530, 27);
            this.PinPadURI.TabIndex = 63;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 49);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(93, 20);
            this.label30.TabIndex = 64;
            this.label30.Text = "Port Number";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 17);
            this.label31.Margin = new System.Windows.Forms.Padding(0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(83, 20);
            this.label31.TabIndex = 66;
            this.label31.Text = "Service URI";
            // 
            // PrinterTabPage
            // 
            this.PrinterTabPage.Controls.Add(this.label39);
            this.PrinterTabPage.Controls.Add(this.PrinterFormFields);
            this.PrinterTabPage.Controls.Add(this.PrinterLoadDefinition);
            this.PrinterTabPage.Controls.Add(this.PrinterMediaListBox);
            this.PrinterTabPage.Controls.Add(this.PrinterQueryForm);
            this.PrinterTabPage.Controls.Add(this.PrinterEject);
            this.PrinterTabPage.Controls.Add(this.PrinterQueryMedia);
            this.PrinterTabPage.Controls.Add(this.PrinterGetMediaList);
            this.PrinterTabPage.Controls.Add(this.PrinterPrintForm);
            this.PrinterTabPage.Controls.Add(this.PrinterReset);
            this.PrinterTabPage.Controls.Add(this.PrinterPrintRaw);
            this.PrinterTabPage.Controls.Add(this.PrinterGetFormList);
            this.PrinterTabPage.Controls.Add(this.label33);
            this.PrinterTabPage.Controls.Add(this.PrinterFormListBox);
            this.PrinterTabPage.Controls.Add(this.label34);
            this.PrinterTabPage.Controls.Add(this.label35);
            this.PrinterTabPage.Controls.Add(this.PrinterEvtBox);
            this.PrinterTabPage.Controls.Add(this.PrinterRspBox);
            this.PrinterTabPage.Controls.Add(this.PrinterCmdBox);
            this.PrinterTabPage.Controls.Add(this.PrinterType);
            this.PrinterTabPage.Controls.Add(this.PrinterStDevice);
            this.PrinterTabPage.Controls.Add(this.PrinterCapabilities);
            this.PrinterTabPage.Controls.Add(this.PrinterStatus);
            this.PrinterTabPage.Controls.Add(this.PrinterServiceURI);
            this.PrinterTabPage.Controls.Add(this.PrinterServiceDiscovery);
            this.PrinterTabPage.Controls.Add(this.PrinterPortNum);
            this.PrinterTabPage.Controls.Add(this.label36);
            this.PrinterTabPage.Controls.Add(this.PrinterURI);
            this.PrinterTabPage.Controls.Add(this.label37);
            this.PrinterTabPage.Controls.Add(this.label38);
            this.PrinterTabPage.Location = new System.Drawing.Point(4, 29);
            this.PrinterTabPage.Name = "PrinterTabPage";
            this.PrinterTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PrinterTabPage.Size = new System.Drawing.Size(1346, 691);
            this.PrinterTabPage.TabIndex = 5;
            this.PrinterTabPage.Text = "Printer";
            this.PrinterTabPage.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(16, 189);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 20);
            this.label39.TabIndex = 127;
            this.label39.Text = "Form Fields:";
            // 
            // PrinterFormFields
            // 
            this.PrinterFormFields.Location = new System.Drawing.Point(16, 225);
            this.PrinterFormFields.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterFormFields.Name = "PrinterFormFields";
            this.PrinterFormFields.Size = new System.Drawing.Size(630, 27);
            this.PrinterFormFields.TabIndex = 126;
            this.PrinterFormFields.Text = "Field1=Value1,Field2=Field Value2";
            // 
            // PrinterLoadDefinition
            // 
            this.PrinterLoadDefinition.Location = new System.Drawing.Point(1090, 48);
            this.PrinterLoadDefinition.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterLoadDefinition.Name = "PrinterLoadDefinition";
            this.PrinterLoadDefinition.Size = new System.Drawing.Size(113, 29);
            this.PrinterLoadDefinition.TabIndex = 124;
            this.PrinterLoadDefinition.Text = "LoadDefinition";
            this.PrinterLoadDefinition.UseVisualStyleBackColor = true;
            this.PrinterLoadDefinition.Click += new System.EventHandler(this.PrinterLoadDefinition_Click);
            // 
            // PrinterMediaListBox
            // 
            this.PrinterMediaListBox.FormattingEnabled = true;
            this.PrinterMediaListBox.ItemHeight = 20;
            this.PrinterMediaListBox.Location = new System.Drawing.Point(1022, 136);
            this.PrinterMediaListBox.Name = "PrinterMediaListBox";
            this.PrinterMediaListBox.Size = new System.Drawing.Size(181, 124);
            this.PrinterMediaListBox.TabIndex = 123;
            // 
            // PrinterQueryForm
            // 
            this.PrinterQueryForm.Location = new System.Drawing.Point(907, 177);
            this.PrinterQueryForm.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterQueryForm.Name = "PrinterQueryForm";
            this.PrinterQueryForm.Size = new System.Drawing.Size(103, 31);
            this.PrinterQueryForm.TabIndex = 122;
            this.PrinterQueryForm.Text = "QueryForm";
            this.PrinterQueryForm.UseVisualStyleBackColor = true;
            this.PrinterQueryForm.Click += new System.EventHandler(this.PrinterQueryForm_Click);
            // 
            // PrinterEject
            // 
            this.PrinterEject.Location = new System.Drawing.Point(1213, 48);
            this.PrinterEject.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterEject.Name = "PrinterEject";
            this.PrinterEject.Size = new System.Drawing.Size(106, 28);
            this.PrinterEject.TabIndex = 121;
            this.PrinterEject.Text = "Eject";
            this.PrinterEject.UseVisualStyleBackColor = true;
            this.PrinterEject.Click += new System.EventHandler(this.PrinterEject_Click);
            // 
            // PrinterQueryMedia
            // 
            this.PrinterQueryMedia.Location = new System.Drawing.Point(1216, 177);
            this.PrinterQueryMedia.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterQueryMedia.Name = "PrinterQueryMedia";
            this.PrinterQueryMedia.Size = new System.Drawing.Size(106, 28);
            this.PrinterQueryMedia.TabIndex = 119;
            this.PrinterQueryMedia.Text = "QueryMedia";
            this.PrinterQueryMedia.UseVisualStyleBackColor = true;
            this.PrinterQueryMedia.Click += new System.EventHandler(this.PrinterQueryMedia_Click);
            // 
            // PrinterGetMediaList
            // 
            this.PrinterGetMediaList.Location = new System.Drawing.Point(1216, 136);
            this.PrinterGetMediaList.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterGetMediaList.Name = "PrinterGetMediaList";
            this.PrinterGetMediaList.Size = new System.Drawing.Size(106, 28);
            this.PrinterGetMediaList.TabIndex = 118;
            this.PrinterGetMediaList.Text = "GetMediaList";
            this.PrinterGetMediaList.UseVisualStyleBackColor = true;
            this.PrinterGetMediaList.Click += new System.EventHandler(this.PrinterGetMediaList_Click);
            // 
            // PrinterPrintForm
            // 
            this.PrinterPrintForm.Location = new System.Drawing.Point(16, 160);
            this.PrinterPrintForm.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPrintForm.Name = "PrinterPrintForm";
            this.PrinterPrintForm.Size = new System.Drawing.Size(120, 28);
            this.PrinterPrintForm.TabIndex = 115;
            this.PrinterPrintForm.Text = "PrintForm";
            this.PrinterPrintForm.UseVisualStyleBackColor = true;
            this.PrinterPrintForm.Click += new System.EventHandler(this.PrinterPrintForm_Click);
            // 
            // PrinterReset
            // 
            this.PrinterReset.Location = new System.Drawing.Point(1213, 12);
            this.PrinterReset.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterReset.Name = "PrinterReset";
            this.PrinterReset.Size = new System.Drawing.Size(106, 29);
            this.PrinterReset.TabIndex = 114;
            this.PrinterReset.Text = "Reset";
            this.PrinterReset.UseVisualStyleBackColor = true;
            this.PrinterReset.Click += new System.EventHandler(this.PrinterReset_Click);
            // 
            // PrinterPrintRaw
            // 
            this.PrinterPrintRaw.Location = new System.Drawing.Point(1090, 15);
            this.PrinterPrintRaw.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPrintRaw.Name = "PrinterPrintRaw";
            this.PrinterPrintRaw.Size = new System.Drawing.Size(113, 29);
            this.PrinterPrintRaw.TabIndex = 112;
            this.PrinterPrintRaw.Text = "PrintRaw";
            this.PrinterPrintRaw.UseVisualStyleBackColor = true;
            this.PrinterPrintRaw.Click += new System.EventHandler(this.PrinterPrintRaw_Click);
            // 
            // PrinterGetFormList
            // 
            this.PrinterGetFormList.Location = new System.Drawing.Point(907, 135);
            this.PrinterGetFormList.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterGetFormList.Name = "PrinterGetFormList";
            this.PrinterGetFormList.Size = new System.Drawing.Size(103, 31);
            this.PrinterGetFormList.TabIndex = 111;
            this.PrinterGetFormList.Text = "GetFormList";
            this.PrinterGetFormList.UseVisualStyleBackColor = true;
            this.PrinterGetFormList.Click += new System.EventHandler(this.PrinterGetFormList_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(677, 107);
            this.label33.Margin = new System.Windows.Forms.Padding(0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(93, 20);
            this.label33.TabIndex = 110;
            this.label33.Text = "Form Names";
            // 
            // PrinterFormListBox
            // 
            this.PrinterFormListBox.FormattingEnabled = true;
            this.PrinterFormListBox.ItemHeight = 20;
            this.PrinterFormListBox.Location = new System.Drawing.Point(677, 135);
            this.PrinterFormListBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterFormListBox.Name = "PrinterFormListBox";
            this.PrinterFormListBox.Size = new System.Drawing.Size(217, 124);
            this.PrinterFormListBox.TabIndex = 109;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(677, 63);
            this.label34.Margin = new System.Windows.Forms.Padding(0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(87, 20);
            this.label34.TabIndex = 108;
            this.label34.Text = "Printer Type";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(677, 16);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(96, 20);
            this.label35.TabIndex = 107;
            this.label35.Text = "Device status";
            // 
            // PrinterEvtBox
            // 
            this.PrinterEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterEvtBox.Location = new System.Drawing.Point(931, 269);
            this.PrinterEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterEvtBox.MaxLength = 1048576;
            this.PrinterEvtBox.Multiline = true;
            this.PrinterEvtBox.Name = "PrinterEvtBox";
            this.PrinterEvtBox.ReadOnly = true;
            this.PrinterEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterEvtBox.Size = new System.Drawing.Size(405, 408);
            this.PrinterEvtBox.TabIndex = 106;
            // 
            // PrinterRspBox
            // 
            this.PrinterRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterRspBox.Location = new System.Drawing.Point(486, 269);
            this.PrinterRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterRspBox.MaxLength = 1048576;
            this.PrinterRspBox.Multiline = true;
            this.PrinterRspBox.Name = "PrinterRspBox";
            this.PrinterRspBox.ReadOnly = true;
            this.PrinterRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterRspBox.Size = new System.Drawing.Size(423, 408);
            this.PrinterRspBox.TabIndex = 105;
            // 
            // PrinterCmdBox
            // 
            this.PrinterCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterCmdBox.Location = new System.Drawing.Point(16, 269);
            this.PrinterCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterCmdBox.MaxLength = 1048576;
            this.PrinterCmdBox.Multiline = true;
            this.PrinterCmdBox.Name = "PrinterCmdBox";
            this.PrinterCmdBox.ReadOnly = true;
            this.PrinterCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterCmdBox.Size = new System.Drawing.Size(450, 408);
            this.PrinterCmdBox.TabIndex = 104;
            // 
            // PrinterType
            // 
            this.PrinterType.Location = new System.Drawing.Point(773, 60);
            this.PrinterType.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterType.Name = "PrinterType";
            this.PrinterType.ReadOnly = true;
            this.PrinterType.Size = new System.Drawing.Size(121, 27);
            this.PrinterType.TabIndex = 103;
            // 
            // PrinterStDevice
            // 
            this.PrinterStDevice.Location = new System.Drawing.Point(773, 16);
            this.PrinterStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterStDevice.Name = "PrinterStDevice";
            this.PrinterStDevice.ReadOnly = true;
            this.PrinterStDevice.Size = new System.Drawing.Size(121, 27);
            this.PrinterStDevice.TabIndex = 102;
            // 
            // PrinterCapabilities
            // 
            this.PrinterCapabilities.Location = new System.Drawing.Point(931, 51);
            this.PrinterCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterCapabilities.Name = "PrinterCapabilities";
            this.PrinterCapabilities.Size = new System.Drawing.Size(103, 29);
            this.PrinterCapabilities.TabIndex = 101;
            this.PrinterCapabilities.Text = "Capabilities";
            this.PrinterCapabilities.UseVisualStyleBackColor = true;
            this.PrinterCapabilities.Click += new System.EventHandler(this.PrinterCapabilities_Click);
            // 
            // PrinterStatus
            // 
            this.PrinterStatus.Location = new System.Drawing.Point(931, 13);
            this.PrinterStatus.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterStatus.Name = "PrinterStatus";
            this.PrinterStatus.Size = new System.Drawing.Size(103, 29);
            this.PrinterStatus.TabIndex = 100;
            this.PrinterStatus.Text = "Status";
            this.PrinterStatus.UseVisualStyleBackColor = true;
            this.PrinterStatus.Click += new System.EventHandler(this.PrinterStatus_Click);
            // 
            // PrinterServiceURI
            // 
            this.PrinterServiceURI.Location = new System.Drawing.Point(117, 16);
            this.PrinterServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterServiceURI.Name = "PrinterServiceURI";
            this.PrinterServiceURI.Size = new System.Drawing.Size(530, 27);
            this.PrinterServiceURI.TabIndex = 98;
            // 
            // PrinterServiceDiscovery
            // 
            this.PrinterServiceDiscovery.Location = new System.Drawing.Point(504, 127);
            this.PrinterServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterServiceDiscovery.Name = "PrinterServiceDiscovery";
            this.PrinterServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.PrinterServiceDiscovery.TabIndex = 93;
            this.PrinterServiceDiscovery.Text = "Service Discovery";
            this.PrinterServiceDiscovery.UseVisualStyleBackColor = true;
            this.PrinterServiceDiscovery.Click += new System.EventHandler(this.PrinterServiceDiscovery_Click);
            // 
            // PrinterPortNum
            // 
            this.PrinterPortNum.Location = new System.Drawing.Point(117, 48);
            this.PrinterPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPortNum.Name = "PrinterPortNum";
            this.PrinterPortNum.ReadOnly = true;
            this.PrinterPortNum.Size = new System.Drawing.Size(121, 27);
            this.PrinterPortNum.TabIndex = 94;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 83);
            this.label36.Margin = new System.Windows.Forms.Padding(0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(79, 20);
            this.label36.TabIndex = 95;
            this.label36.Text = "Printer URI";
            // 
            // PrinterURI
            // 
            this.PrinterURI.Location = new System.Drawing.Point(117, 79);
            this.PrinterURI.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterURI.Name = "PrinterURI";
            this.PrinterURI.ReadOnly = true;
            this.PrinterURI.Size = new System.Drawing.Size(530, 27);
            this.PrinterURI.TabIndex = 96;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 48);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(93, 20);
            this.label37.TabIndex = 97;
            this.label37.Text = "Port Number";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(9, 16);
            this.label38.Margin = new System.Windows.Forms.Padding(0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(83, 20);
            this.label38.TabIndex = 99;
            this.label38.Text = "Service URI";
            // 
            // lightsTab
            // 
            this.lightsTab.Controls.Add(this.LightsServiceDiscovery);
            this.lightsTab.Controls.Add(this.label45);
            this.lightsTab.Controls.Add(this.LightsFlashRate);
            this.lightsTab.Controls.Add(this.label40);
            this.lightsTab.Controls.Add(this.txtLightName);
            this.lightsTab.Controls.Add(this.LightsSetLight);
            this.lightsTab.Controls.Add(this.label41);
            this.lightsTab.Controls.Add(this.LightsEvtBox);
            this.lightsTab.Controls.Add(this.LightsRspBox);
            this.lightsTab.Controls.Add(this.LightsCmdBox);
            this.lightsTab.Controls.Add(this.lblLightsStatus);
            this.lightsTab.Controls.Add(this.LightsCapabilities);
            this.lightsTab.Controls.Add(this.LightsStatus);
            this.lightsTab.Controls.Add(this.LightsServiceURI);
            this.lightsTab.Controls.Add(this.LightsPortNum);
            this.lightsTab.Controls.Add(this.label42);
            this.lightsTab.Controls.Add(this.LightsURI);
            this.lightsTab.Controls.Add(this.label43);
            this.lightsTab.Controls.Add(this.label44);
            this.lightsTab.Location = new System.Drawing.Point(4, 29);
            this.lightsTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightsTab.Name = "lightsTab";
            this.lightsTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightsTab.Size = new System.Drawing.Size(1346, 691);
            this.lightsTab.TabIndex = 6;
            this.lightsTab.Text = "Lights";
            this.lightsTab.UseVisualStyleBackColor = true;
            // 
            // LightsServiceDiscovery
            // 
            this.LightsServiceDiscovery.Location = new System.Drawing.Point(514, 117);
            this.LightsServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.LightsServiceDiscovery.Name = "LightsServiceDiscovery";
            this.LightsServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.LightsServiceDiscovery.TabIndex = 135;
            this.LightsServiceDiscovery.Text = "Service Discovery";
            this.LightsServiceDiscovery.UseVisualStyleBackColor = true;
            this.LightsServiceDiscovery.Click += new System.EventHandler(this.LightsServiceDiscovery_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(1085, 60);
            this.label45.Margin = new System.Windows.Forms.Padding(0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(76, 20);
            this.label45.TabIndex = 134;
            this.label45.Text = "Flash Rate";
            // 
            // LightsFlashRate
            // 
            this.LightsFlashRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LightsFlashRate.FormattingEnabled = true;
            this.LightsFlashRate.Location = new System.Drawing.Point(1178, 56);
            this.LightsFlashRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LightsFlashRate.Name = "LightsFlashRate";
            this.LightsFlashRate.Size = new System.Drawing.Size(121, 28);
            this.LightsFlashRate.TabIndex = 133;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(1074, 12);
            this.label40.Margin = new System.Windows.Forms.Padding(0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(86, 20);
            this.label40.TabIndex = 132;
            this.label40.Text = "Light Name";
            // 
            // txtLightName
            // 
            this.txtLightName.Location = new System.Drawing.Point(1178, 12);
            this.txtLightName.Margin = new System.Windows.Forms.Padding(0);
            this.txtLightName.Name = "txtLightName";
            this.txtLightName.Size = new System.Drawing.Size(121, 27);
            this.txtLightName.TabIndex = 131;
            this.txtLightName.Text = "cardReader";
            // 
            // LightsSetLight
            // 
            this.LightsSetLight.Location = new System.Drawing.Point(1193, 119);
            this.LightsSetLight.Margin = new System.Windows.Forms.Padding(0);
            this.LightsSetLight.Name = "LightsSetLight";
            this.LightsSetLight.Size = new System.Drawing.Size(106, 29);
            this.LightsSetLight.TabIndex = 130;
            this.LightsSetLight.Text = "SetLight";
            this.LightsSetLight.UseVisualStyleBackColor = true;
            this.LightsSetLight.Click += new System.EventHandler(this.LightsSetLight_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(677, 13);
            this.label41.Margin = new System.Windows.Forms.Padding(0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(96, 20);
            this.label41.TabIndex = 128;
            this.label41.Text = "Device status";
            // 
            // LightsEvtBox
            // 
            this.LightsEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsEvtBox.Location = new System.Drawing.Point(931, 267);
            this.LightsEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsEvtBox.MaxLength = 1048576;
            this.LightsEvtBox.Multiline = true;
            this.LightsEvtBox.Name = "LightsEvtBox";
            this.LightsEvtBox.ReadOnly = true;
            this.LightsEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsEvtBox.Size = new System.Drawing.Size(405, 408);
            this.LightsEvtBox.TabIndex = 127;
            // 
            // LightsRspBox
            // 
            this.LightsRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsRspBox.Location = new System.Drawing.Point(486, 267);
            this.LightsRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsRspBox.MaxLength = 1048576;
            this.LightsRspBox.Multiline = true;
            this.LightsRspBox.Name = "LightsRspBox";
            this.LightsRspBox.ReadOnly = true;
            this.LightsRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsRspBox.Size = new System.Drawing.Size(423, 408);
            this.LightsRspBox.TabIndex = 126;
            // 
            // LightsCmdBox
            // 
            this.LightsCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsCmdBox.Location = new System.Drawing.Point(16, 267);
            this.LightsCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsCmdBox.MaxLength = 1048576;
            this.LightsCmdBox.Multiline = true;
            this.LightsCmdBox.Name = "LightsCmdBox";
            this.LightsCmdBox.ReadOnly = true;
            this.LightsCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsCmdBox.Size = new System.Drawing.Size(450, 408);
            this.LightsCmdBox.TabIndex = 125;
            // 
            // lblLightsStatus
            // 
            this.lblLightsStatus.Location = new System.Drawing.Point(773, 13);
            this.lblLightsStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightsStatus.Name = "lblLightsStatus";
            this.lblLightsStatus.ReadOnly = true;
            this.lblLightsStatus.Size = new System.Drawing.Size(121, 27);
            this.lblLightsStatus.TabIndex = 123;
            // 
            // LightsCapabilities
            // 
            this.LightsCapabilities.Location = new System.Drawing.Point(931, 51);
            this.LightsCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.LightsCapabilities.Name = "LightsCapabilities";
            this.LightsCapabilities.Size = new System.Drawing.Size(103, 29);
            this.LightsCapabilities.TabIndex = 122;
            this.LightsCapabilities.Text = "Capabilities";
            this.LightsCapabilities.UseVisualStyleBackColor = true;
            this.LightsCapabilities.Click += new System.EventHandler(this.LightsCapabilities_Click);
            // 
            // LightsStatus
            // 
            this.LightsStatus.Location = new System.Drawing.Point(931, 13);
            this.LightsStatus.Margin = new System.Windows.Forms.Padding(0);
            this.LightsStatus.Name = "LightsStatus";
            this.LightsStatus.Size = new System.Drawing.Size(103, 29);
            this.LightsStatus.TabIndex = 121;
            this.LightsStatus.Text = "Status";
            this.LightsStatus.UseVisualStyleBackColor = true;
            this.LightsStatus.Click += new System.EventHandler(this.LightsStatus_Click);
            // 
            // LightsServiceURI
            // 
            this.LightsServiceURI.Location = new System.Drawing.Point(117, 13);
            this.LightsServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.LightsServiceURI.Name = "LightsServiceURI";
            this.LightsServiceURI.Size = new System.Drawing.Size(530, 27);
            this.LightsServiceURI.TabIndex = 119;
            // 
            // LightsPortNum
            // 
            this.LightsPortNum.Location = new System.Drawing.Point(117, 45);
            this.LightsPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.LightsPortNum.Name = "LightsPortNum";
            this.LightsPortNum.ReadOnly = true;
            this.LightsPortNum.Size = new System.Drawing.Size(121, 27);
            this.LightsPortNum.TabIndex = 115;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(7, 80);
            this.label42.Margin = new System.Windows.Forms.Padding(0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(75, 20);
            this.label42.TabIndex = 116;
            this.label42.Text = "Lights URI";
            // 
            // LightsURI
            // 
            this.LightsURI.Location = new System.Drawing.Point(117, 76);
            this.LightsURI.Margin = new System.Windows.Forms.Padding(0);
            this.LightsURI.Name = "LightsURI";
            this.LightsURI.ReadOnly = true;
            this.LightsURI.Size = new System.Drawing.Size(530, 27);
            this.LightsURI.TabIndex = 117;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(9, 45);
            this.label43.Margin = new System.Windows.Forms.Padding(0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(93, 20);
            this.label43.TabIndex = 118;
            this.label43.Text = "Port Number";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(9, 13);
            this.label44.Margin = new System.Windows.Forms.Padding(0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(83, 20);
            this.label44.TabIndex = 120;
            this.label44.Text = "Service URI";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboAutoStartupModes);
            this.tabPage2.Controls.Add(this.btnSetAuxiliaries);
            this.tabPage2.Controls.Add(this.btnRegister);
            this.tabPage2.Controls.Add(this.btnClearAutoStartup);
            this.tabPage2.Controls.Add(this.btnGetAutoStartup);
            this.tabPage2.Controls.Add(this.btnSetAutoStartup);
            this.tabPage2.Controls.Add(this.autoStartupDateTime);
            this.tabPage2.Controls.Add(this.btnAuxiliariesServiceDiscovery);
            this.tabPage2.Controls.Add(this.label48);
            this.tabPage2.Controls.Add(this.AuxiliariesEvtBox);
            this.tabPage2.Controls.Add(this.AuxiliariesRspBox);
            this.tabPage2.Controls.Add(this.AuxiliariesCmdBox);
            this.tabPage2.Controls.Add(this.AuxiliariesStatus);
            this.tabPage2.Controls.Add(this.btnAuxiliariesCapabilities);
            this.tabPage2.Controls.Add(this.btnAuxiliariesStatus);
            this.tabPage2.Controls.Add(this.AuxiliariesServiceURI);
            this.tabPage2.Controls.Add(this.AuxiliariesPortNum);
            this.tabPage2.Controls.Add(this.label49);
            this.tabPage2.Controls.Add(this.AuxiliariesURI);
            this.tabPage2.Controls.Add(this.label50);
            this.tabPage2.Controls.Add(this.label51);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1346, 691);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "Auxiliaries";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboAutoStartupModes
            // 
            this.comboAutoStartupModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAutoStartupModes.FormattingEnabled = true;
            this.comboAutoStartupModes.Location = new System.Drawing.Point(1074, 51);
            this.comboAutoStartupModes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboAutoStartupModes.Name = "comboAutoStartupModes";
            this.comboAutoStartupModes.Size = new System.Drawing.Size(121, 28);
            this.comboAutoStartupModes.TabIndex = 161;
            // 
            // btnSetAuxiliaries
            // 
            this.btnSetAuxiliaries.Location = new System.Drawing.Point(1074, 129);
            this.btnSetAuxiliaries.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetAuxiliaries.Name = "btnSetAuxiliaries";
            this.btnSetAuxiliaries.Size = new System.Drawing.Size(103, 29);
            this.btnSetAuxiliaries.TabIndex = 160;
            this.btnSetAuxiliaries.Text = "SetAuxiliaries";
            this.btnSetAuxiliaries.UseVisualStyleBackColor = true;
            this.btnSetAuxiliaries.Click += new System.EventHandler(this.btnSetAuxiliaries_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(1074, 88);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(103, 29);
            this.btnRegister.TabIndex = 159;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClearAutoStartup
            // 
            this.btnClearAutoStartup.Location = new System.Drawing.Point(1211, 129);
            this.btnClearAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearAutoStartup.Name = "btnClearAutoStartup";
            this.btnClearAutoStartup.Size = new System.Drawing.Size(126, 29);
            this.btnClearAutoStartup.TabIndex = 158;
            this.btnClearAutoStartup.Text = "ClearAutoStartup";
            this.btnClearAutoStartup.UseVisualStyleBackColor = true;
            this.btnClearAutoStartup.Click += new System.EventHandler(this.btnClearAutoStartup_Click);
            // 
            // btnGetAutoStartup
            // 
            this.btnGetAutoStartup.Location = new System.Drawing.Point(1211, 88);
            this.btnGetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnGetAutoStartup.Name = "btnGetAutoStartup";
            this.btnGetAutoStartup.Size = new System.Drawing.Size(126, 29);
            this.btnGetAutoStartup.TabIndex = 157;
            this.btnGetAutoStartup.Text = "GetAutoStartup";
            this.btnGetAutoStartup.UseVisualStyleBackColor = true;
            this.btnGetAutoStartup.Click += new System.EventHandler(this.btnGetAutoStartup_Click);
            // 
            // btnSetAutoStartup
            // 
            this.btnSetAutoStartup.Location = new System.Drawing.Point(1211, 47);
            this.btnSetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetAutoStartup.Name = "btnSetAutoStartup";
            this.btnSetAutoStartup.Size = new System.Drawing.Size(126, 29);
            this.btnSetAutoStartup.TabIndex = 156;
            this.btnSetAutoStartup.Text = "SetAutoStartup";
            this.btnSetAutoStartup.UseVisualStyleBackColor = true;
            this.btnSetAutoStartup.Click += new System.EventHandler(this.btnSetAutoStartup_Click);
            // 
            // autoStartupDateTime
            // 
            this.autoStartupDateTime.CustomFormat = "yyyy.MM.dd HH:mm";
            this.autoStartupDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.autoStartupDateTime.Location = new System.Drawing.Point(1074, 12);
            this.autoStartupDateTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoStartupDateTime.Name = "autoStartupDateTime";
            this.autoStartupDateTime.Size = new System.Drawing.Size(262, 27);
            this.autoStartupDateTime.TabIndex = 155;
            // 
            // btnAuxiliariesServiceDiscovery
            // 
            this.btnAuxiliariesServiceDiscovery.Location = new System.Drawing.Point(514, 116);
            this.btnAuxiliariesServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesServiceDiscovery.Name = "btnAuxiliariesServiceDiscovery";
            this.btnAuxiliariesServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.btnAuxiliariesServiceDiscovery.TabIndex = 154;
            this.btnAuxiliariesServiceDiscovery.Text = "Service Discovery";
            this.btnAuxiliariesServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnAuxiliariesServiceDiscovery.Click += new System.EventHandler(this.btnAuxiliariesServiceDiscovery_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(677, 12);
            this.label48.Margin = new System.Windows.Forms.Padding(0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(96, 20);
            this.label48.TabIndex = 148;
            this.label48.Text = "Device status";
            // 
            // AuxiliariesEvtBox
            // 
            this.AuxiliariesEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesEvtBox.Location = new System.Drawing.Point(931, 265);
            this.AuxiliariesEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesEvtBox.MaxLength = 1048576;
            this.AuxiliariesEvtBox.Multiline = true;
            this.AuxiliariesEvtBox.Name = "AuxiliariesEvtBox";
            this.AuxiliariesEvtBox.ReadOnly = true;
            this.AuxiliariesEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesEvtBox.Size = new System.Drawing.Size(405, 408);
            this.AuxiliariesEvtBox.TabIndex = 147;
            // 
            // AuxiliariesRspBox
            // 
            this.AuxiliariesRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesRspBox.Location = new System.Drawing.Point(486, 265);
            this.AuxiliariesRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesRspBox.MaxLength = 1048576;
            this.AuxiliariesRspBox.Multiline = true;
            this.AuxiliariesRspBox.Name = "AuxiliariesRspBox";
            this.AuxiliariesRspBox.ReadOnly = true;
            this.AuxiliariesRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesRspBox.Size = new System.Drawing.Size(423, 408);
            this.AuxiliariesRspBox.TabIndex = 146;
            // 
            // AuxiliariesCmdBox
            // 
            this.AuxiliariesCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesCmdBox.Location = new System.Drawing.Point(16, 265);
            this.AuxiliariesCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesCmdBox.MaxLength = 1048576;
            this.AuxiliariesCmdBox.Multiline = true;
            this.AuxiliariesCmdBox.Name = "AuxiliariesCmdBox";
            this.AuxiliariesCmdBox.ReadOnly = true;
            this.AuxiliariesCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesCmdBox.Size = new System.Drawing.Size(450, 408);
            this.AuxiliariesCmdBox.TabIndex = 145;
            // 
            // AuxiliariesStatus
            // 
            this.AuxiliariesStatus.Location = new System.Drawing.Point(773, 12);
            this.AuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesStatus.Name = "AuxiliariesStatus";
            this.AuxiliariesStatus.ReadOnly = true;
            this.AuxiliariesStatus.Size = new System.Drawing.Size(121, 27);
            this.AuxiliariesStatus.TabIndex = 144;
            // 
            // btnAuxiliariesCapabilities
            // 
            this.btnAuxiliariesCapabilities.Location = new System.Drawing.Point(931, 49);
            this.btnAuxiliariesCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesCapabilities.Name = "btnAuxiliariesCapabilities";
            this.btnAuxiliariesCapabilities.Size = new System.Drawing.Size(103, 29);
            this.btnAuxiliariesCapabilities.TabIndex = 143;
            this.btnAuxiliariesCapabilities.Text = "Capabilities";
            this.btnAuxiliariesCapabilities.UseVisualStyleBackColor = true;
            this.btnAuxiliariesCapabilities.Click += new System.EventHandler(this.btnAuxiliariesCapabilities_Click);
            // 
            // btnAuxiliariesStatus
            // 
            this.btnAuxiliariesStatus.Location = new System.Drawing.Point(931, 12);
            this.btnAuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesStatus.Name = "btnAuxiliariesStatus";
            this.btnAuxiliariesStatus.Size = new System.Drawing.Size(103, 29);
            this.btnAuxiliariesStatus.TabIndex = 142;
            this.btnAuxiliariesStatus.Text = "Status";
            this.btnAuxiliariesStatus.UseVisualStyleBackColor = true;
            this.btnAuxiliariesStatus.Click += new System.EventHandler(this.btnAuxiliariesStatus_Click);
            // 
            // AuxiliariesServiceURI
            // 
            this.AuxiliariesServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AuxiliariesServiceURI.Location = new System.Drawing.Point(117, 12);
            this.AuxiliariesServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesServiceURI.Name = "AuxiliariesServiceURI";
            this.AuxiliariesServiceURI.Size = new System.Drawing.Size(530, 27);
            this.AuxiliariesServiceURI.TabIndex = 140;
            // 
            // AuxiliariesPortNum
            // 
            this.AuxiliariesPortNum.Location = new System.Drawing.Point(117, 44);
            this.AuxiliariesPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesPortNum.Name = "AuxiliariesPortNum";
            this.AuxiliariesPortNum.ReadOnly = true;
            this.AuxiliariesPortNum.Size = new System.Drawing.Size(121, 27);
            this.AuxiliariesPortNum.TabIndex = 136;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(7, 79);
            this.label49.Margin = new System.Windows.Forms.Padding(0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(104, 20);
            this.label49.TabIndex = 137;
            this.label49.Text = "Auxiliaries URI";
            // 
            // AuxiliariesURI
            // 
            this.AuxiliariesURI.Location = new System.Drawing.Point(117, 75);
            this.AuxiliariesURI.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesURI.Name = "AuxiliariesURI";
            this.AuxiliariesURI.ReadOnly = true;
            this.AuxiliariesURI.Size = new System.Drawing.Size(530, 27);
            this.AuxiliariesURI.TabIndex = 138;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(9, 44);
            this.label50.Margin = new System.Windows.Forms.Padding(0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(93, 20);
            this.label50.TabIndex = 139;
            this.label50.Text = "Port Number";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(9, 12);
            this.label51.Margin = new System.Windows.Forms.Padding(0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(83, 20);
            this.label51.TabIndex = 141;
            this.label51.Text = "Service URI";
            // 
            // VendorModeTabPage
            // 
            this.VendorModeTabPage.Controls.Add(this.buttonVDMExit);
            this.VendorModeTabPage.Controls.Add(this.buttonVDMEnter);
            this.VendorModeTabPage.Controls.Add(this.VendorModeServiceStatus);
            this.VendorModeTabPage.Controls.Add(this.label58);
            this.VendorModeTabPage.Controls.Add(this.VendorModeEvtBox);
            this.VendorModeTabPage.Controls.Add(this.VendorModeRspBox);
            this.VendorModeTabPage.Controls.Add(this.VendorModeCmdBox);
            this.VendorModeTabPage.Controls.Add(this.btnVendorModeServiceDiscovery);
            this.VendorModeTabPage.Controls.Add(this.label46);
            this.VendorModeTabPage.Controls.Add(this.VendorModeStStatus);
            this.VendorModeTabPage.Controls.Add(this.btnVendorModeStatus);
            this.VendorModeTabPage.Controls.Add(this.VendorModeServiceURI);
            this.VendorModeTabPage.Controls.Add(this.VendorModePortNum);
            this.VendorModeTabPage.Controls.Add(this.label47);
            this.VendorModeTabPage.Controls.Add(this.VendorModeURI);
            this.VendorModeTabPage.Controls.Add(this.label52);
            this.VendorModeTabPage.Controls.Add(this.label53);
            this.VendorModeTabPage.Location = new System.Drawing.Point(4, 29);
            this.VendorModeTabPage.Name = "VendorModeTabPage";
            this.VendorModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VendorModeTabPage.Size = new System.Drawing.Size(1346, 691);
            this.VendorModeTabPage.TabIndex = 8;
            this.VendorModeTabPage.Text = "VendorMode";
            this.VendorModeTabPage.UseVisualStyleBackColor = true;
            // 
            // buttonVDMExit
            // 
            this.buttonVDMExit.Location = new System.Drawing.Point(960, 188);
            this.buttonVDMExit.Name = "buttonVDMExit";
            this.buttonVDMExit.Size = new System.Drawing.Size(162, 29);
            this.buttonVDMExit.TabIndex = 172;
            this.buttonVDMExit.Text = "ExitModeRequest";
            this.buttonVDMExit.UseVisualStyleBackColor = true;
            this.buttonVDMExit.Click += new System.EventHandler(this.buttonVDMExit_Click);
            // 
            // buttonVDMEnter
            // 
            this.buttonVDMEnter.Location = new System.Drawing.Point(960, 139);
            this.buttonVDMEnter.Name = "buttonVDMEnter";
            this.buttonVDMEnter.Size = new System.Drawing.Size(162, 29);
            this.buttonVDMEnter.TabIndex = 171;
            this.buttonVDMEnter.Text = "EnterModeRequest";
            this.buttonVDMEnter.UseVisualStyleBackColor = true;
            this.buttonVDMEnter.Click += new System.EventHandler(this.buttonVDMEnter_Click);
            // 
            // VendorModeServiceStatus
            // 
            this.VendorModeServiceStatus.Location = new System.Drawing.Point(822, 68);
            this.VendorModeServiceStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeServiceStatus.Name = "VendorModeServiceStatus";
            this.VendorModeServiceStatus.ReadOnly = true;
            this.VendorModeServiceStatus.Size = new System.Drawing.Size(121, 27);
            this.VendorModeServiceStatus.TabIndex = 170;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(680, 71);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(139, 20);
            this.label58.TabIndex = 169;
            this.label58.Text = "VendorMode Status";
            // 
            // VendorModeEvtBox
            // 
            this.VendorModeEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeEvtBox.Location = new System.Drawing.Point(919, 280);
            this.VendorModeEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeEvtBox.MaxLength = 1048576;
            this.VendorModeEvtBox.Multiline = true;
            this.VendorModeEvtBox.Name = "VendorModeEvtBox";
            this.VendorModeEvtBox.ReadOnly = true;
            this.VendorModeEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeEvtBox.Size = new System.Drawing.Size(405, 408);
            this.VendorModeEvtBox.TabIndex = 168;
            // 
            // VendorModeRspBox
            // 
            this.VendorModeRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeRspBox.Location = new System.Drawing.Point(474, 280);
            this.VendorModeRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeRspBox.MaxLength = 1048576;
            this.VendorModeRspBox.Multiline = true;
            this.VendorModeRspBox.Name = "VendorModeRspBox";
            this.VendorModeRspBox.ReadOnly = true;
            this.VendorModeRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeRspBox.Size = new System.Drawing.Size(423, 408);
            this.VendorModeRspBox.TabIndex = 167;
            // 
            // VendorModeCmdBox
            // 
            this.VendorModeCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeCmdBox.Location = new System.Drawing.Point(5, 280);
            this.VendorModeCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeCmdBox.MaxLength = 1048576;
            this.VendorModeCmdBox.Multiline = true;
            this.VendorModeCmdBox.Name = "VendorModeCmdBox";
            this.VendorModeCmdBox.ReadOnly = true;
            this.VendorModeCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeCmdBox.Size = new System.Drawing.Size(450, 408);
            this.VendorModeCmdBox.TabIndex = 166;
            // 
            // btnVendorModeServiceDiscovery
            // 
            this.btnVendorModeServiceDiscovery.Location = new System.Drawing.Point(517, 121);
            this.btnVendorModeServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorModeServiceDiscovery.Name = "btnVendorModeServiceDiscovery";
            this.btnVendorModeServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.btnVendorModeServiceDiscovery.TabIndex = 165;
            this.btnVendorModeServiceDiscovery.Text = "Service Discovery";
            this.btnVendorModeServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnVendorModeServiceDiscovery.Click += new System.EventHandler(this.btnVendorModeServiceDiscovery_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(680, 17);
            this.label46.Margin = new System.Windows.Forms.Padding(0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(96, 20);
            this.label46.TabIndex = 164;
            this.label46.Text = "Device status";
            // 
            // VendorModeStStatus
            // 
            this.VendorModeStStatus.Location = new System.Drawing.Point(822, 19);
            this.VendorModeStStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeStStatus.Name = "VendorModeStStatus";
            this.VendorModeStStatus.ReadOnly = true;
            this.VendorModeStStatus.Size = new System.Drawing.Size(121, 27);
            this.VendorModeStStatus.TabIndex = 163;
            // 
            // btnVendorModeStatus
            // 
            this.btnVendorModeStatus.Location = new System.Drawing.Point(960, 17);
            this.btnVendorModeStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorModeStatus.Name = "btnVendorModeStatus";
            this.btnVendorModeStatus.Size = new System.Drawing.Size(103, 29);
            this.btnVendorModeStatus.TabIndex = 161;
            this.btnVendorModeStatus.Text = "Status";
            this.btnVendorModeStatus.UseVisualStyleBackColor = true;
            this.btnVendorModeStatus.Click += new System.EventHandler(this.btnVendorModeStatus_Click);
            // 
            // VendorModeServiceURI
            // 
            this.VendorModeServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.VendorModeServiceURI.Location = new System.Drawing.Point(120, 17);
            this.VendorModeServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeServiceURI.Name = "VendorModeServiceURI";
            this.VendorModeServiceURI.Size = new System.Drawing.Size(530, 27);
            this.VendorModeServiceURI.TabIndex = 159;
            // 
            // VendorModePortNum
            // 
            this.VendorModePortNum.Location = new System.Drawing.Point(120, 49);
            this.VendorModePortNum.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModePortNum.Name = "VendorModePortNum";
            this.VendorModePortNum.ReadOnly = true;
            this.VendorModePortNum.Size = new System.Drawing.Size(121, 27);
            this.VendorModePortNum.TabIndex = 155;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(8, 84);
            this.label47.Margin = new System.Windows.Forms.Padding(0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(122, 20);
            this.label47.TabIndex = 156;
            this.label47.Text = "VendorMode URI";
            // 
            // VendorModeURI
            // 
            this.VendorModeURI.Location = new System.Drawing.Point(120, 80);
            this.VendorModeURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeURI.Name = "VendorModeURI";
            this.VendorModeURI.ReadOnly = true;
            this.VendorModeURI.Size = new System.Drawing.Size(530, 27);
            this.VendorModeURI.TabIndex = 157;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(9, 49);
            this.label52.Margin = new System.Windows.Forms.Padding(0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(93, 20);
            this.label52.TabIndex = 158;
            this.label52.Text = "Port Number";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(9, 17);
            this.label53.Margin = new System.Windows.Forms.Padding(0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(83, 20);
            this.label53.TabIndex = 160;
            this.label53.Text = "Service URI";
            // 
            // VendorAppTabPage
            // 
            this.VendorAppTabPage.Controls.Add(this.label60);
            this.VendorAppTabPage.Controls.Add(this.textAppName);
            this.VendorAppTabPage.Controls.Add(this.label59);
            this.VendorAppTabPage.Controls.Add(this.textActiveInterface);
            this.VendorAppTabPage.Controls.Add(this.buttonGetActiveInterface);
            this.VendorAppTabPage.Controls.Add(this.buttonStartLocalApplication);
            this.VendorAppTabPage.Controls.Add(this.VendorAppEvtBox);
            this.VendorAppTabPage.Controls.Add(this.VendorAppRspBox);
            this.VendorAppTabPage.Controls.Add(this.VendorAppCmdBox);
            this.VendorAppTabPage.Controls.Add(this.btnVendorAppServiceDiscovery);
            this.VendorAppTabPage.Controls.Add(this.label54);
            this.VendorAppTabPage.Controls.Add(this.VendorAppStatus);
            this.VendorAppTabPage.Controls.Add(this.btnVendorAppCapabilities);
            this.VendorAppTabPage.Controls.Add(this.btnVendorAppStatus);
            this.VendorAppTabPage.Controls.Add(this.VendorAppServiceURI);
            this.VendorAppTabPage.Controls.Add(this.VendorAppPortNum);
            this.VendorAppTabPage.Controls.Add(this.label55);
            this.VendorAppTabPage.Controls.Add(this.VendorAppURI);
            this.VendorAppTabPage.Controls.Add(this.label56);
            this.VendorAppTabPage.Controls.Add(this.label57);
            this.VendorAppTabPage.Location = new System.Drawing.Point(4, 29);
            this.VendorAppTabPage.Name = "VendorAppTabPage";
            this.VendorAppTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VendorAppTabPage.Size = new System.Drawing.Size(1346, 691);
            this.VendorAppTabPage.TabIndex = 9;
            this.VendorAppTabPage.Text = "VendorApplication";
            this.VendorAppTabPage.UseVisualStyleBackColor = true;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(685, 152);
            this.label60.Margin = new System.Windows.Forms.Padding(0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(81, 20);
            this.label60.TabIndex = 177;
            this.label60.Text = "App Name";
            // 
            // textAppName
            // 
            this.textAppName.Location = new System.Drawing.Point(769, 145);
            this.textAppName.Name = "textAppName";
            this.textAppName.Size = new System.Drawing.Size(125, 27);
            this.textAppName.TabIndex = 176;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(657, 197);
            this.label59.Margin = new System.Windows.Forms.Padding(0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(112, 20);
            this.label59.TabIndex = 175;
            this.label59.Text = "Active Interface";
            // 
            // textActiveInterface
            // 
            this.textActiveInterface.Location = new System.Drawing.Point(769, 189);
            this.textActiveInterface.Margin = new System.Windows.Forms.Padding(0);
            this.textActiveInterface.Name = "textActiveInterface";
            this.textActiveInterface.ReadOnly = true;
            this.textActiveInterface.Size = new System.Drawing.Size(121, 27);
            this.textActiveInterface.TabIndex = 174;
            // 
            // buttonGetActiveInterface
            // 
            this.buttonGetActiveInterface.Location = new System.Drawing.Point(927, 188);
            this.buttonGetActiveInterface.Name = "buttonGetActiveInterface";
            this.buttonGetActiveInterface.Size = new System.Drawing.Size(203, 29);
            this.buttonGetActiveInterface.TabIndex = 173;
            this.buttonGetActiveInterface.Text = "GetActiveInterface";
            this.buttonGetActiveInterface.UseVisualStyleBackColor = true;
            this.buttonGetActiveInterface.Click += new System.EventHandler(this.buttonGetActiveInterface_Click);
            // 
            // buttonStartLocalApplication
            // 
            this.buttonStartLocalApplication.Location = new System.Drawing.Point(927, 143);
            this.buttonStartLocalApplication.Name = "buttonStartLocalApplication";
            this.buttonStartLocalApplication.Size = new System.Drawing.Size(211, 29);
            this.buttonStartLocalApplication.TabIndex = 172;
            this.buttonStartLocalApplication.Text = "StartLocalApplication";
            this.buttonStartLocalApplication.UseVisualStyleBackColor = true;
            this.buttonStartLocalApplication.Click += new System.EventHandler(this.buttonStartLocalApplication_Click);
            // 
            // VendorAppEvtBox
            // 
            this.VendorAppEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppEvtBox.Location = new System.Drawing.Point(921, 280);
            this.VendorAppEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppEvtBox.MaxLength = 1048576;
            this.VendorAppEvtBox.Multiline = true;
            this.VendorAppEvtBox.Name = "VendorAppEvtBox";
            this.VendorAppEvtBox.ReadOnly = true;
            this.VendorAppEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppEvtBox.Size = new System.Drawing.Size(405, 408);
            this.VendorAppEvtBox.TabIndex = 171;
            // 
            // VendorAppRspBox
            // 
            this.VendorAppRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppRspBox.Location = new System.Drawing.Point(475, 280);
            this.VendorAppRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppRspBox.MaxLength = 1048576;
            this.VendorAppRspBox.Multiline = true;
            this.VendorAppRspBox.Name = "VendorAppRspBox";
            this.VendorAppRspBox.ReadOnly = true;
            this.VendorAppRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppRspBox.Size = new System.Drawing.Size(423, 408);
            this.VendorAppRspBox.TabIndex = 170;
            // 
            // VendorAppCmdBox
            // 
            this.VendorAppCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppCmdBox.Location = new System.Drawing.Point(6, 280);
            this.VendorAppCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppCmdBox.MaxLength = 1048576;
            this.VendorAppCmdBox.Multiline = true;
            this.VendorAppCmdBox.Name = "VendorAppCmdBox";
            this.VendorAppCmdBox.ReadOnly = true;
            this.VendorAppCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppCmdBox.Size = new System.Drawing.Size(450, 408);
            this.VendorAppCmdBox.TabIndex = 169;
            // 
            // btnVendorAppServiceDiscovery
            // 
            this.btnVendorAppServiceDiscovery.Location = new System.Drawing.Point(510, 117);
            this.btnVendorAppServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppServiceDiscovery.Name = "btnVendorAppServiceDiscovery";
            this.btnVendorAppServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.btnVendorAppServiceDiscovery.TabIndex = 165;
            this.btnVendorAppServiceDiscovery.Text = "Service Discovery";
            this.btnVendorAppServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnVendorAppServiceDiscovery.Click += new System.EventHandler(this.btnVendorAppServiceDiscovery_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(673, 13);
            this.label54.Margin = new System.Windows.Forms.Padding(0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(96, 20);
            this.label54.TabIndex = 164;
            this.label54.Text = "Device status";
            // 
            // VendorAppStatus
            // 
            this.VendorAppStatus.Location = new System.Drawing.Point(769, 13);
            this.VendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppStatus.Name = "VendorAppStatus";
            this.VendorAppStatus.ReadOnly = true;
            this.VendorAppStatus.Size = new System.Drawing.Size(121, 27);
            this.VendorAppStatus.TabIndex = 163;
            // 
            // btnVendorAppCapabilities
            // 
            this.btnVendorAppCapabilities.Location = new System.Drawing.Point(927, 51);
            this.btnVendorAppCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppCapabilities.Name = "btnVendorAppCapabilities";
            this.btnVendorAppCapabilities.Size = new System.Drawing.Size(103, 29);
            this.btnVendorAppCapabilities.TabIndex = 162;
            this.btnVendorAppCapabilities.Text = "Capabilities";
            this.btnVendorAppCapabilities.UseVisualStyleBackColor = true;
            this.btnVendorAppCapabilities.Click += new System.EventHandler(this.btnVendorAppCapabilities_Click);
            // 
            // btnVendorAppStatus
            // 
            this.btnVendorAppStatus.Location = new System.Drawing.Point(927, 13);
            this.btnVendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppStatus.Name = "btnVendorAppStatus";
            this.btnVendorAppStatus.Size = new System.Drawing.Size(103, 29);
            this.btnVendorAppStatus.TabIndex = 161;
            this.btnVendorAppStatus.Text = "Status";
            this.btnVendorAppStatus.UseVisualStyleBackColor = true;
            this.btnVendorAppStatus.Click += new System.EventHandler(this.btnVendorAppStatus_Click);
            // 
            // VendorAppServiceURI
            // 
            this.VendorAppServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.VendorAppServiceURI.Location = new System.Drawing.Point(113, 13);
            this.VendorAppServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppServiceURI.Name = "VendorAppServiceURI";
            this.VendorAppServiceURI.Size = new System.Drawing.Size(530, 27);
            this.VendorAppServiceURI.TabIndex = 159;
            // 
            // VendorAppPortNum
            // 
            this.VendorAppPortNum.Location = new System.Drawing.Point(113, 45);
            this.VendorAppPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppPortNum.Name = "VendorAppPortNum";
            this.VendorAppPortNum.ReadOnly = true;
            this.VendorAppPortNum.Size = new System.Drawing.Size(121, 27);
            this.VendorAppPortNum.TabIndex = 155;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 81);
            this.label55.Margin = new System.Windows.Forms.Padding(0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(111, 20);
            this.label55.TabIndex = 156;
            this.label55.Text = "VendorApp URI";
            // 
            // VendorAppURI
            // 
            this.VendorAppURI.Location = new System.Drawing.Point(113, 77);
            this.VendorAppURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppURI.Name = "VendorAppURI";
            this.VendorAppURI.ReadOnly = true;
            this.VendorAppURI.Size = new System.Drawing.Size(530, 27);
            this.VendorAppURI.TabIndex = 157;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(5, 45);
            this.label56.Margin = new System.Windows.Forms.Padding(0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(93, 20);
            this.label56.TabIndex = 158;
            this.label56.Text = "Port Number";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(5, 13);
            this.label57.Margin = new System.Windows.Forms.Padding(0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(83, 20);
            this.label57.TabIndex = 160;
            this.label57.Text = "Service URI";
            // 
            // BarcodeReaderTabPage
            // 
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderReset);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderRead);
            this.BarcodeReaderTabPage.Controls.Add(this.label61);
            this.BarcodeReaderTabPage.Controls.Add(this.label62);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderEvtBox);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderRspBox);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderCmdBox);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderScannerStatus);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderStDevice);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderCapabilities);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderStatus);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderServiceURI);
            this.BarcodeReaderTabPage.Controls.Add(this.btnBarcodeReaderServiceDiscovery);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderPortNum);
            this.BarcodeReaderTabPage.Controls.Add(this.label63);
            this.BarcodeReaderTabPage.Controls.Add(this.BarcodeReaderURI);
            this.BarcodeReaderTabPage.Controls.Add(this.label64);
            this.BarcodeReaderTabPage.Controls.Add(this.label65);
            this.BarcodeReaderTabPage.Location = new System.Drawing.Point(4, 29);
            this.BarcodeReaderTabPage.Name = "BarcodeReaderTabPage";
            this.BarcodeReaderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.BarcodeReaderTabPage.Size = new System.Drawing.Size(1346, 691);
            this.BarcodeReaderTabPage.TabIndex = 10;
            this.BarcodeReaderTabPage.Text = "BarcodeReader";
            this.BarcodeReaderTabPage.UseVisualStyleBackColor = true;
            // 
            // BarcodeReaderReset
            // 
            this.BarcodeReaderReset.Location = new System.Drawing.Point(1215, 13);
            this.BarcodeReaderReset.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderReset.Name = "BarcodeReaderReset";
            this.BarcodeReaderReset.Size = new System.Drawing.Size(106, 29);
            this.BarcodeReaderReset.TabIndex = 132;
            this.BarcodeReaderReset.Text = "Reset";
            this.BarcodeReaderReset.UseVisualStyleBackColor = true;
            this.BarcodeReaderReset.Click += new System.EventHandler(this.BarcodeReaderReset_Click);
            // 
            // BarcodeReaderRead
            // 
            this.BarcodeReaderRead.Location = new System.Drawing.Point(1093, 16);
            this.BarcodeReaderRead.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderRead.Name = "BarcodeReaderRead";
            this.BarcodeReaderRead.Size = new System.Drawing.Size(113, 29);
            this.BarcodeReaderRead.TabIndex = 131;
            this.BarcodeReaderRead.Text = "Read";
            this.BarcodeReaderRead.UseVisualStyleBackColor = true;
            this.BarcodeReaderRead.Click += new System.EventHandler(this.BarcodeReaderRead_Click);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(670, 64);
            this.label61.Margin = new System.Windows.Forms.Padding(0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(105, 20);
            this.label61.TabIndex = 130;
            this.label61.Text = "Scanner Status";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(679, 17);
            this.label62.Margin = new System.Windows.Forms.Padding(0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(96, 20);
            this.label62.TabIndex = 129;
            this.label62.Text = "Device status";
            // 
            // BarcodeReaderEvtBox
            // 
            this.BarcodeReaderEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderEvtBox.Location = new System.Drawing.Point(933, 269);
            this.BarcodeReaderEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderEvtBox.MaxLength = 1048576;
            this.BarcodeReaderEvtBox.Multiline = true;
            this.BarcodeReaderEvtBox.Name = "BarcodeReaderEvtBox";
            this.BarcodeReaderEvtBox.ReadOnly = true;
            this.BarcodeReaderEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderEvtBox.Size = new System.Drawing.Size(405, 408);
            this.BarcodeReaderEvtBox.TabIndex = 128;
            // 
            // BarcodeReaderRspBox
            // 
            this.BarcodeReaderRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderRspBox.Location = new System.Drawing.Point(488, 269);
            this.BarcodeReaderRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderRspBox.MaxLength = 1048576;
            this.BarcodeReaderRspBox.Multiline = true;
            this.BarcodeReaderRspBox.Name = "BarcodeReaderRspBox";
            this.BarcodeReaderRspBox.ReadOnly = true;
            this.BarcodeReaderRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderRspBox.Size = new System.Drawing.Size(423, 408);
            this.BarcodeReaderRspBox.TabIndex = 127;
            // 
            // BarcodeReaderCmdBox
            // 
            this.BarcodeReaderCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderCmdBox.Location = new System.Drawing.Point(18, 269);
            this.BarcodeReaderCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderCmdBox.MaxLength = 1048576;
            this.BarcodeReaderCmdBox.Multiline = true;
            this.BarcodeReaderCmdBox.Name = "BarcodeReaderCmdBox";
            this.BarcodeReaderCmdBox.ReadOnly = true;
            this.BarcodeReaderCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderCmdBox.Size = new System.Drawing.Size(450, 408);
            this.BarcodeReaderCmdBox.TabIndex = 126;
            // 
            // BarcodeReaderScannerStatus
            // 
            this.BarcodeReaderScannerStatus.Location = new System.Drawing.Point(775, 61);
            this.BarcodeReaderScannerStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderScannerStatus.Name = "BarcodeReaderScannerStatus";
            this.BarcodeReaderScannerStatus.ReadOnly = true;
            this.BarcodeReaderScannerStatus.Size = new System.Drawing.Size(121, 27);
            this.BarcodeReaderScannerStatus.TabIndex = 125;
            // 
            // BarcodeReaderStDevice
            // 
            this.BarcodeReaderStDevice.Location = new System.Drawing.Point(775, 17);
            this.BarcodeReaderStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderStDevice.Name = "BarcodeReaderStDevice";
            this.BarcodeReaderStDevice.ReadOnly = true;
            this.BarcodeReaderStDevice.Size = new System.Drawing.Size(121, 27);
            this.BarcodeReaderStDevice.TabIndex = 124;
            // 
            // BarcodeReaderCapabilities
            // 
            this.BarcodeReaderCapabilities.Location = new System.Drawing.Point(933, 52);
            this.BarcodeReaderCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderCapabilities.Name = "BarcodeReaderCapabilities";
            this.BarcodeReaderCapabilities.Size = new System.Drawing.Size(103, 29);
            this.BarcodeReaderCapabilities.TabIndex = 123;
            this.BarcodeReaderCapabilities.Text = "Capabilities";
            this.BarcodeReaderCapabilities.UseVisualStyleBackColor = true;
            this.BarcodeReaderCapabilities.Click += new System.EventHandler(this.BarcodeReaderCapabilities_Click);
            // 
            // BarcodeReaderStatus
            // 
            this.BarcodeReaderStatus.Location = new System.Drawing.Point(933, 13);
            this.BarcodeReaderStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderStatus.Name = "BarcodeReaderStatus";
            this.BarcodeReaderStatus.Size = new System.Drawing.Size(103, 29);
            this.BarcodeReaderStatus.TabIndex = 122;
            this.BarcodeReaderStatus.Text = "Status";
            this.BarcodeReaderStatus.UseVisualStyleBackColor = true;
            this.BarcodeReaderStatus.Click += new System.EventHandler(this.BarcodeReaderStatus_Click);
            // 
            // BarcodeReaderServiceURI
            // 
            this.BarcodeReaderServiceURI.Location = new System.Drawing.Point(129, 17);
            this.BarcodeReaderServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderServiceURI.Name = "BarcodeReaderServiceURI";
            this.BarcodeReaderServiceURI.Size = new System.Drawing.Size(530, 27);
            this.BarcodeReaderServiceURI.TabIndex = 120;
            // 
            // btnBarcodeReaderServiceDiscovery
            // 
            this.btnBarcodeReaderServiceDiscovery.Location = new System.Drawing.Point(506, 128);
            this.btnBarcodeReaderServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnBarcodeReaderServiceDiscovery.Name = "btnBarcodeReaderServiceDiscovery";
            this.btnBarcodeReaderServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.btnBarcodeReaderServiceDiscovery.TabIndex = 115;
            this.btnBarcodeReaderServiceDiscovery.Text = "Service Discovery";
            this.btnBarcodeReaderServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnBarcodeReaderServiceDiscovery.Click += new System.EventHandler(this.btnBarcodeReaderServiceDiscovery_Click);
            // 
            // BarcodeReaderPortNum
            // 
            this.BarcodeReaderPortNum.Location = new System.Drawing.Point(129, 49);
            this.BarcodeReaderPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderPortNum.Name = "BarcodeReaderPortNum";
            this.BarcodeReaderPortNum.ReadOnly = true;
            this.BarcodeReaderPortNum.Size = new System.Drawing.Size(121, 27);
            this.BarcodeReaderPortNum.TabIndex = 116;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(5, 84);
            this.label63.Margin = new System.Windows.Forms.Padding(0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(138, 20);
            this.label63.TabIndex = 117;
            this.label63.Text = "BarcodeReader URI";
            // 
            // BarcodeReaderURI
            // 
            this.BarcodeReaderURI.Location = new System.Drawing.Point(129, 80);
            this.BarcodeReaderURI.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderURI.Name = "BarcodeReaderURI";
            this.BarcodeReaderURI.ReadOnly = true;
            this.BarcodeReaderURI.Size = new System.Drawing.Size(530, 27);
            this.BarcodeReaderURI.TabIndex = 118;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(7, 49);
            this.label64.Margin = new System.Windows.Forms.Padding(0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(93, 20);
            this.label64.TabIndex = 119;
            this.label64.Text = "Port Number";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(7, 17);
            this.label65.Margin = new System.Windows.Forms.Padding(0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(83, 20);
            this.label65.TabIndex = 121;
            this.label65.Text = "Service URI";
            // 
            // BiometricPage
            // 
            this.BiometricPage.Controls.Add(this.label77);
            this.BiometricPage.Controls.Add(this.label76);
            this.BiometricPage.Controls.Add(this.btnBiometricGetStorageInfo);
            this.BiometricPage.Controls.Add(this.BiometricStorageInfo);
            this.BiometricPage.Controls.Add(this.btnBiometricReadMatch);
            this.BiometricPage.Controls.Add(this.label71);
            this.BiometricPage.Controls.Add(this.txtBiometricTemplateData);
            this.BiometricPage.Controls.Add(this.btnBiometricClear);
            this.BiometricPage.Controls.Add(this.btnBiometricMatch);
            this.BiometricPage.Controls.Add(this.btnBiometricImport);
            this.BiometricPage.Controls.Add(this.btnBiometricReset);
            this.BiometricPage.Controls.Add(this.btnBiometricRead);
            this.BiometricPage.Controls.Add(this.label67);
            this.BiometricPage.Controls.Add(this.BiometricEvtBox);
            this.BiometricPage.Controls.Add(this.BiometricRspBox);
            this.BiometricPage.Controls.Add(this.BiometricCmdBox);
            this.BiometricPage.Controls.Add(this.BiometricStatus);
            this.BiometricPage.Controls.Add(this.btnBiometricCapabilities);
            this.BiometricPage.Controls.Add(this.btnBiometricStatus);
            this.BiometricPage.Controls.Add(this.BiometricServiceURI);
            this.BiometricPage.Controls.Add(this.btnBiometricServiceDiscovery);
            this.BiometricPage.Controls.Add(this.BiometricPortNum);
            this.BiometricPage.Controls.Add(this.label68);
            this.BiometricPage.Controls.Add(this.BiometricURI);
            this.BiometricPage.Controls.Add(this.label69);
            this.BiometricPage.Controls.Add(this.label70);
            this.BiometricPage.Location = new System.Drawing.Point(4, 29);
            this.BiometricPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BiometricPage.Name = "BiometricPage";
            this.BiometricPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BiometricPage.Size = new System.Drawing.Size(1346, 691);
            this.BiometricPage.TabIndex = 11;
            this.BiometricPage.Text = "Biometric";
            this.BiometricPage.UseVisualStyleBackColor = true;
            // 
            // btnBiometricGetStorageInfo
            // 
            this.btnBiometricGetStorageInfo.Location = new System.Drawing.Point(1089, 151);
            this.btnBiometricGetStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricGetStorageInfo.Name = "btnBiometricGetStorageInfo";
            this.btnBiometricGetStorageInfo.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricGetStorageInfo.TabIndex = 158;
            this.btnBiometricGetStorageInfo.Text = "GetStorageInfo";
            this.btnBiometricGetStorageInfo.UseVisualStyleBackColor = true;
            this.btnBiometricGetStorageInfo.Click += new System.EventHandler(this.btnBiometricGetStorageInfo_Click);
            // 
            // BiometricStorageInfo
            // 
            this.BiometricStorageInfo.FormattingEnabled = true;
            this.BiometricStorageInfo.ItemHeight = 20;
            this.BiometricStorageInfo.Location = new System.Drawing.Point(931, 105);
            this.BiometricStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricStorageInfo.Name = "BiometricStorageInfo";
            this.BiometricStorageInfo.Size = new System.Drawing.Size(118, 124);
            this.BiometricStorageInfo.TabIndex = 157;
            // 
            // btnBiometricReadMatch
            // 
            this.btnBiometricReadMatch.Location = new System.Drawing.Point(1214, 61);
            this.btnBiometricReadMatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricReadMatch.Name = "btnBiometricReadMatch";
            this.btnBiometricReadMatch.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricReadMatch.TabIndex = 156;
            this.btnBiometricReadMatch.Text = "Read(Match)";
            this.btnBiometricReadMatch.UseVisualStyleBackColor = true;
            this.btnBiometricReadMatch.Click += new System.EventHandler(this.btnBiometricReadMatch_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(17, 160);
            this.label71.Margin = new System.Windows.Forms.Padding(0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(161, 20);
            this.label71.TabIndex = 155;
            this.label71.Text = "Base64 Template Data:";
            // 
            // txtBiometricTemplateData
            // 
            this.txtBiometricTemplateData.Location = new System.Drawing.Point(17, 192);
            this.txtBiometricTemplateData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBiometricTemplateData.Name = "txtBiometricTemplateData";
            this.txtBiometricTemplateData.Size = new System.Drawing.Size(893, 27);
            this.txtBiometricTemplateData.TabIndex = 154;
            // 
            // btnBiometricClear
            // 
            this.btnBiometricClear.Location = new System.Drawing.Point(1089, 13);
            this.btnBiometricClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricClear.Name = "btnBiometricClear";
            this.btnBiometricClear.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricClear.TabIndex = 153;
            this.btnBiometricClear.Text = "Clear";
            this.btnBiometricClear.UseVisualStyleBackColor = true;
            this.btnBiometricClear.Click += new System.EventHandler(this.btnBiometricClear_Click);
            // 
            // btnBiometricMatch
            // 
            this.btnBiometricMatch.Location = new System.Drawing.Point(1214, 105);
            this.btnBiometricMatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricMatch.Name = "btnBiometricMatch";
            this.btnBiometricMatch.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricMatch.TabIndex = 152;
            this.btnBiometricMatch.Text = "Match";
            this.btnBiometricMatch.UseVisualStyleBackColor = true;
            this.btnBiometricMatch.Click += new System.EventHandler(this.btnBiometricMatch_Click);
            // 
            // btnBiometricImport
            // 
            this.btnBiometricImport.Location = new System.Drawing.Point(1089, 105);
            this.btnBiometricImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricImport.Name = "btnBiometricImport";
            this.btnBiometricImport.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricImport.TabIndex = 151;
            this.btnBiometricImport.Text = "Import";
            this.btnBiometricImport.UseVisualStyleBackColor = true;
            this.btnBiometricImport.Click += new System.EventHandler(this.btnBiometricImport_Click);
            // 
            // btnBiometricReset
            // 
            this.btnBiometricReset.Location = new System.Drawing.Point(1214, 13);
            this.btnBiometricReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricReset.Name = "btnBiometricReset";
            this.btnBiometricReset.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricReset.TabIndex = 150;
            this.btnBiometricReset.Text = "Reset";
            this.btnBiometricReset.UseVisualStyleBackColor = true;
            this.btnBiometricReset.Click += new System.EventHandler(this.btnBiometricReset_Click);
            // 
            // btnBiometricRead
            // 
            this.btnBiometricRead.Location = new System.Drawing.Point(1089, 61);
            this.btnBiometricRead.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricRead.Name = "btnBiometricRead";
            this.btnBiometricRead.Size = new System.Drawing.Size(113, 29);
            this.btnBiometricRead.TabIndex = 149;
            this.btnBiometricRead.Text = "Read(Scan)";
            this.btnBiometricRead.UseVisualStyleBackColor = true;
            this.btnBiometricRead.Click += new System.EventHandler(this.btnBiometricRead_Click);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(678, 15);
            this.label67.Margin = new System.Windows.Forms.Padding(0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(96, 20);
            this.label67.TabIndex = 147;
            this.label67.Text = "Device status";
            // 
            // BiometricEvtBox
            // 
            this.BiometricEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricEvtBox.Location = new System.Drawing.Point(931, 267);
            this.BiometricEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricEvtBox.MaxLength = 1048576;
            this.BiometricEvtBox.Multiline = true;
            this.BiometricEvtBox.Name = "BiometricEvtBox";
            this.BiometricEvtBox.ReadOnly = true;
            this.BiometricEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricEvtBox.Size = new System.Drawing.Size(405, 408);
            this.BiometricEvtBox.TabIndex = 146;
            // 
            // BiometricRspBox
            // 
            this.BiometricRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricRspBox.Location = new System.Drawing.Point(487, 267);
            this.BiometricRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricRspBox.MaxLength = 1048576;
            this.BiometricRspBox.Multiline = true;
            this.BiometricRspBox.Name = "BiometricRspBox";
            this.BiometricRspBox.ReadOnly = true;
            this.BiometricRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricRspBox.Size = new System.Drawing.Size(423, 408);
            this.BiometricRspBox.TabIndex = 145;
            // 
            // BiometricCmdBox
            // 
            this.BiometricCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricCmdBox.Location = new System.Drawing.Point(17, 267);
            this.BiometricCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricCmdBox.MaxLength = 1048576;
            this.BiometricCmdBox.Multiline = true;
            this.BiometricCmdBox.Name = "BiometricCmdBox";
            this.BiometricCmdBox.ReadOnly = true;
            this.BiometricCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricCmdBox.Size = new System.Drawing.Size(450, 408);
            this.BiometricCmdBox.TabIndex = 144;
            // 
            // BiometricStatus
            // 
            this.BiometricStatus.Location = new System.Drawing.Point(774, 15);
            this.BiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricStatus.Name = "BiometricStatus";
            this.BiometricStatus.ReadOnly = true;
            this.BiometricStatus.Size = new System.Drawing.Size(121, 27);
            this.BiometricStatus.TabIndex = 142;
            // 
            // btnBiometricCapabilities
            // 
            this.btnBiometricCapabilities.Location = new System.Drawing.Point(931, 49);
            this.btnBiometricCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricCapabilities.Name = "btnBiometricCapabilities";
            this.btnBiometricCapabilities.Size = new System.Drawing.Size(119, 29);
            this.btnBiometricCapabilities.TabIndex = 141;
            this.btnBiometricCapabilities.Text = "Capabilities";
            this.btnBiometricCapabilities.UseVisualStyleBackColor = true;
            this.btnBiometricCapabilities.Click += new System.EventHandler(this.btnBiometricCapabilities_Click);
            // 
            // btnBiometricStatus
            // 
            this.btnBiometricStatus.Location = new System.Drawing.Point(931, 11);
            this.btnBiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricStatus.Name = "btnBiometricStatus";
            this.btnBiometricStatus.Size = new System.Drawing.Size(119, 29);
            this.btnBiometricStatus.TabIndex = 140;
            this.btnBiometricStatus.Text = "Status";
            this.btnBiometricStatus.UseVisualStyleBackColor = true;
            this.btnBiometricStatus.Click += new System.EventHandler(this.btnBiometricStatus_Click);
            // 
            // BiometricServiceURI
            // 
            this.BiometricServiceURI.Location = new System.Drawing.Point(118, 15);
            this.BiometricServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricServiceURI.Name = "BiometricServiceURI";
            this.BiometricServiceURI.Size = new System.Drawing.Size(530, 27);
            this.BiometricServiceURI.TabIndex = 138;
            // 
            // btnBiometricServiceDiscovery
            // 
            this.btnBiometricServiceDiscovery.Location = new System.Drawing.Point(515, 129);
            this.btnBiometricServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricServiceDiscovery.Name = "btnBiometricServiceDiscovery";
            this.btnBiometricServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.btnBiometricServiceDiscovery.TabIndex = 133;
            this.btnBiometricServiceDiscovery.Text = "Service Discovery";
            this.btnBiometricServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnBiometricServiceDiscovery.Click += new System.EventHandler(this.btnBiometricServiceDiscovery_Click);
            // 
            // BiometricPortNum
            // 
            this.BiometricPortNum.Location = new System.Drawing.Point(118, 47);
            this.BiometricPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricPortNum.Name = "BiometricPortNum";
            this.BiometricPortNum.ReadOnly = true;
            this.BiometricPortNum.Size = new System.Drawing.Size(121, 27);
            this.BiometricPortNum.TabIndex = 134;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(8, 80);
            this.label68.Margin = new System.Windows.Forms.Padding(0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(100, 20);
            this.label68.TabIndex = 135;
            this.label68.Text = "Biometric URI";
            // 
            // BiometricURI
            // 
            this.BiometricURI.Location = new System.Drawing.Point(118, 77);
            this.BiometricURI.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricURI.Name = "BiometricURI";
            this.BiometricURI.ReadOnly = true;
            this.BiometricURI.Size = new System.Drawing.Size(530, 27);
            this.BiometricURI.TabIndex = 136;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(0, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(100, 23);
            this.label69.TabIndex = 159;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(100, 23);
            this.label70.TabIndex = 160;
            // 
            // CashAccTabPage
            // 
            this.CashAccTabPage.Controls.Add(this.CashAccSetCashUnitInfo);
            this.CashAccTabPage.Controls.Add(this.CashAccRetract);
            this.CashAccTabPage.Controls.Add(this.CashAccCashIn);
            this.CashAccTabPage.Controls.Add(this.CashAccConfigureNoteTypes);
            this.CashAccTabPage.Controls.Add(this.CashAccCashInEnd);
            this.CashAccTabPage.Controls.Add(this.CashAccCashInStart);
            this.CashAccTabPage.Controls.Add(this.CashAccCashInRollback);
            this.CashAccTabPage.Controls.Add(this.CashAccEndExchange);
            this.CashAccTabPage.Controls.Add(this.CashAccStartExchange);
            this.CashAccTabPage.Controls.Add(this.CashAccReset);
            this.CashAccTabPage.Controls.Add(this.CashAccCashInStatus);
            this.CashAccTabPage.Controls.Add(this.CashAccDeviceType);
            this.CashAccTabPage.Controls.Add(this.label66);
            this.CashAccTabPage.Controls.Add(this.label72);
            this.CashAccTabPage.Controls.Add(this.CashAccStDevice);
            this.CashAccTabPage.Controls.Add(this.CashAccPositionCapabilities);
            this.CashAccTabPage.Controls.Add(this.CashAccCapabilities);
            this.CashAccTabPage.Controls.Add(this.CashAccStatus);
            this.CashAccTabPage.Controls.Add(this.CashAccGetCashUnitInfo);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorServiceURI);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorEvtBox);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorServiceDiscovery);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorPortNum);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorRspBox);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorCmdBox);
            this.CashAccTabPage.Controls.Add(this.label73);
            this.CashAccTabPage.Controls.Add(this.CashAcceptorAccURI);
            this.CashAccTabPage.Controls.Add(this.label74);
            this.CashAccTabPage.Controls.Add(this.label75);
            this.CashAccTabPage.Location = new System.Drawing.Point(4, 29);
            this.CashAccTabPage.Name = "CashAccTabPage";
            this.CashAccTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CashAccTabPage.Size = new System.Drawing.Size(1346, 691);
            this.CashAccTabPage.TabIndex = 12;
            this.CashAccTabPage.Text = "CashAcceptor";
            this.CashAccTabPage.UseVisualStyleBackColor = true;
            // 
            // CashAccSetCashUnitInfo
            // 
            this.CashAccSetCashUnitInfo.Location = new System.Drawing.Point(904, 100);
            this.CashAccSetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            this.CashAccSetCashUnitInfo.Name = "CashAccSetCashUnitInfo";
            this.CashAccSetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            this.CashAccSetCashUnitInfo.TabIndex = 74;
            this.CashAccSetCashUnitInfo.Text = "SetCashUnitInfo";
            this.CashAccSetCashUnitInfo.UseVisualStyleBackColor = true;
            this.CashAccSetCashUnitInfo.Click += new System.EventHandler(this.CashAccSetCashUnitInfo_Click);
            // 
            // CashAccRetract
            // 
            this.CashAccRetract.Location = new System.Drawing.Point(1055, 217);
            this.CashAccRetract.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccRetract.Name = "CashAccRetract";
            this.CashAccRetract.Size = new System.Drawing.Size(127, 28);
            this.CashAccRetract.TabIndex = 73;
            this.CashAccRetract.Text = "Retract";
            this.CashAccRetract.UseVisualStyleBackColor = true;
            this.CashAccRetract.Click += new System.EventHandler(this.CashAccRetract_Click);
            // 
            // CashAccCashIn
            // 
            this.CashAccCashIn.Location = new System.Drawing.Point(1204, 144);
            this.CashAccCashIn.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCashIn.Name = "CashAccCashIn";
            this.CashAccCashIn.Size = new System.Drawing.Size(127, 28);
            this.CashAccCashIn.TabIndex = 72;
            this.CashAccCashIn.Text = "CashIn";
            this.CashAccCashIn.UseVisualStyleBackColor = true;
            this.CashAccCashIn.Click += new System.EventHandler(this.CashAccCashIn_Click);
            // 
            // CashAccConfigureNoteTypes
            // 
            this.CashAccConfigureNoteTypes.Location = new System.Drawing.Point(1033, 53);
            this.CashAccConfigureNoteTypes.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccConfigureNoteTypes.Name = "CashAccConfigureNoteTypes";
            this.CashAccConfigureNoteTypes.Size = new System.Drawing.Size(159, 29);
            this.CashAccConfigureNoteTypes.TabIndex = 70;
            this.CashAccConfigureNoteTypes.Text = "ConfigureNoteTypes";
            this.CashAccConfigureNoteTypes.UseVisualStyleBackColor = true;
            this.CashAccConfigureNoteTypes.Click += new System.EventHandler(this.CashAccConfigureNoteTypes_Click);
            // 
            // CashAccCashInEnd
            // 
            this.CashAccCashInEnd.Location = new System.Drawing.Point(1204, 180);
            this.CashAccCashInEnd.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCashInEnd.Name = "CashAccCashInEnd";
            this.CashAccCashInEnd.Size = new System.Drawing.Size(127, 29);
            this.CashAccCashInEnd.TabIndex = 69;
            this.CashAccCashInEnd.Text = "CashInEnd";
            this.CashAccCashInEnd.UseVisualStyleBackColor = true;
            this.CashAccCashInEnd.Click += new System.EventHandler(this.CashAccCashInEnd_Click);
            // 
            // CashAccCashInStart
            // 
            this.CashAccCashInStart.Location = new System.Drawing.Point(1055, 143);
            this.CashAccCashInStart.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCashInStart.Name = "CashAccCashInStart";
            this.CashAccCashInStart.Size = new System.Drawing.Size(127, 29);
            this.CashAccCashInStart.TabIndex = 68;
            this.CashAccCashInStart.Text = "CashInStart";
            this.CashAccCashInStart.UseVisualStyleBackColor = true;
            this.CashAccCashInStart.Click += new System.EventHandler(this.CashAccCashInStart_Click);
            // 
            // CashAccCashInRollback
            // 
            this.CashAccCashInRollback.Location = new System.Drawing.Point(1204, 216);
            this.CashAccCashInRollback.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCashInRollback.Name = "CashAccCashInRollback";
            this.CashAccCashInRollback.Size = new System.Drawing.Size(127, 29);
            this.CashAccCashInRollback.TabIndex = 67;
            this.CashAccCashInRollback.Text = "CashInRollback";
            this.CashAccCashInRollback.UseVisualStyleBackColor = true;
            this.CashAccCashInRollback.Click += new System.EventHandler(this.CashAccCashInRollback_Click);
            // 
            // CashAccEndExchange
            // 
            this.CashAccEndExchange.Location = new System.Drawing.Point(1204, 51);
            this.CashAccEndExchange.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccEndExchange.Name = "CashAccEndExchange";
            this.CashAccEndExchange.Size = new System.Drawing.Size(127, 29);
            this.CashAccEndExchange.TabIndex = 66;
            this.CashAccEndExchange.Text = "EndExchange";
            this.CashAccEndExchange.UseVisualStyleBackColor = true;
            this.CashAccEndExchange.Click += new System.EventHandler(this.CashAccEndExchange_Click);
            // 
            // CashAccStartExchange
            // 
            this.CashAccStartExchange.Location = new System.Drawing.Point(1204, 11);
            this.CashAccStartExchange.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccStartExchange.Name = "CashAccStartExchange";
            this.CashAccStartExchange.Size = new System.Drawing.Size(127, 29);
            this.CashAccStartExchange.TabIndex = 65;
            this.CashAccStartExchange.Text = "StartExchange";
            this.CashAccStartExchange.UseVisualStyleBackColor = true;
            this.CashAccStartExchange.Click += new System.EventHandler(this.CashAccStartExchange_Click);
            // 
            // CashAccReset
            // 
            this.CashAccReset.Location = new System.Drawing.Point(1033, 15);
            this.CashAccReset.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccReset.Name = "CashAccReset";
            this.CashAccReset.Size = new System.Drawing.Size(127, 29);
            this.CashAccReset.TabIndex = 64;
            this.CashAccReset.Text = "Reset";
            this.CashAccReset.UseVisualStyleBackColor = true;
            this.CashAccReset.Click += new System.EventHandler(this.CashAccReset_Click);
            // 
            // CashAccCashInStatus
            // 
            this.CashAccCashInStatus.Location = new System.Drawing.Point(904, 217);
            this.CashAccCashInStatus.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCashInStatus.Name = "CashAccCashInStatus";
            this.CashAccCashInStatus.Size = new System.Drawing.Size(127, 29);
            this.CashAccCashInStatus.TabIndex = 63;
            this.CashAccCashInStatus.Text = "GetCashInStatus";
            this.CashAccCashInStatus.UseVisualStyleBackColor = true;
            this.CashAccCashInStatus.Click += new System.EventHandler(this.CashAccCashInStatus_Click);
            // 
            // CashAccDeviceType
            // 
            this.CashAccDeviceType.Location = new System.Drawing.Point(776, 57);
            this.CashAccDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccDeviceType.Name = "CashAccDeviceType";
            this.CashAccDeviceType.ReadOnly = true;
            this.CashAccDeviceType.Size = new System.Drawing.Size(121, 27);
            this.CashAccDeviceType.TabIndex = 62;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(689, 60);
            this.label66.Margin = new System.Windows.Forms.Padding(0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(87, 20);
            this.label66.TabIndex = 61;
            this.label66.Text = "Device type";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(680, 20);
            this.label72.Margin = new System.Windows.Forms.Padding(0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(96, 20);
            this.label72.TabIndex = 56;
            this.label72.Text = "Device status";
            // 
            // CashAccStDevice
            // 
            this.CashAccStDevice.Location = new System.Drawing.Point(776, 17);
            this.CashAccStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccStDevice.Name = "CashAccStDevice";
            this.CashAccStDevice.ReadOnly = true;
            this.CashAccStDevice.Size = new System.Drawing.Size(121, 27);
            this.CashAccStDevice.TabIndex = 60;
            // 
            // CashAccPositionCapabilities
            // 
            this.CashAccPositionCapabilities.Location = new System.Drawing.Point(904, 179);
            this.CashAccPositionCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccPositionCapabilities.Name = "CashAccPositionCapabilities";
            this.CashAccPositionCapabilities.Size = new System.Drawing.Size(127, 29);
            this.CashAccPositionCapabilities.TabIndex = 59;
            this.CashAccPositionCapabilities.Text = "GetPositionCapabilities";
            this.CashAccPositionCapabilities.UseVisualStyleBackColor = true;
            this.CashAccPositionCapabilities.Click += new System.EventHandler(this.CashAccPositionCapabilities_Click);
            // 
            // CashAccCapabilities
            // 
            this.CashAccCapabilities.Location = new System.Drawing.Point(904, 56);
            this.CashAccCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccCapabilities.Name = "CashAccCapabilities";
            this.CashAccCapabilities.Size = new System.Drawing.Size(103, 29);
            this.CashAccCapabilities.TabIndex = 58;
            this.CashAccCapabilities.Text = "Capabilities";
            this.CashAccCapabilities.UseVisualStyleBackColor = true;
            this.CashAccCapabilities.Click += new System.EventHandler(this.CashAccCapabilities_Click);
            // 
            // CashAccStatus
            // 
            this.CashAccStatus.Location = new System.Drawing.Point(904, 16);
            this.CashAccStatus.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccStatus.Name = "CashAccStatus";
            this.CashAccStatus.Size = new System.Drawing.Size(103, 29);
            this.CashAccStatus.TabIndex = 57;
            this.CashAccStatus.Text = "Status";
            this.CashAccStatus.UseVisualStyleBackColor = true;
            this.CashAccStatus.Click += new System.EventHandler(this.CashAccStatus_Click);
            // 
            // CashAccGetCashUnitInfo
            // 
            this.CashAccGetCashUnitInfo.Location = new System.Drawing.Point(904, 139);
            this.CashAccGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            this.CashAccGetCashUnitInfo.Name = "CashAccGetCashUnitInfo";
            this.CashAccGetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            this.CashAccGetCashUnitInfo.TabIndex = 55;
            this.CashAccGetCashUnitInfo.Text = "GetCashUnitInfo";
            this.CashAccGetCashUnitInfo.UseVisualStyleBackColor = true;
            this.CashAccGetCashUnitInfo.Click += new System.EventHandler(this.CashAccGetCashUnitInfo_Click);
            // 
            // CashAcceptorServiceURI
            // 
            this.CashAcceptorServiceURI.Location = new System.Drawing.Point(116, 25);
            this.CashAcceptorServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorServiceURI.Name = "CashAcceptorServiceURI";
            this.CashAcceptorServiceURI.Size = new System.Drawing.Size(530, 27);
            this.CashAcceptorServiceURI.TabIndex = 52;
            // 
            // CashAcceptorEvtBox
            // 
            this.CashAcceptorEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CashAcceptorEvtBox.Location = new System.Drawing.Point(935, 272);
            this.CashAcceptorEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorEvtBox.MaxLength = 1048576;
            this.CashAcceptorEvtBox.Multiline = true;
            this.CashAcceptorEvtBox.Name = "CashAcceptorEvtBox";
            this.CashAcceptorEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CashAcceptorEvtBox.Size = new System.Drawing.Size(405, 408);
            this.CashAcceptorEvtBox.TabIndex = 54;
            // 
            // CashAcceptorServiceDiscovery
            // 
            this.CashAcceptorServiceDiscovery.Location = new System.Drawing.Point(504, 136);
            this.CashAcceptorServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorServiceDiscovery.Name = "CashAcceptorServiceDiscovery";
            this.CashAcceptorServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            this.CashAcceptorServiceDiscovery.TabIndex = 46;
            this.CashAcceptorServiceDiscovery.Text = "Service Discovery";
            this.CashAcceptorServiceDiscovery.UseVisualStyleBackColor = true;
            this.CashAcceptorServiceDiscovery.Click += new System.EventHandler(this.CashAcceptorServiceDiscovery_Click);
            // 
            // CashAcceptorPortNum
            // 
            this.CashAcceptorPortNum.Location = new System.Drawing.Point(116, 57);
            this.CashAcceptorPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorPortNum.Name = "CashAcceptorPortNum";
            this.CashAcceptorPortNum.ReadOnly = true;
            this.CashAcceptorPortNum.Size = new System.Drawing.Size(121, 27);
            this.CashAcceptorPortNum.TabIndex = 47;
            // 
            // CashAcceptorRspBox
            // 
            this.CashAcceptorRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CashAcceptorRspBox.Location = new System.Drawing.Point(490, 272);
            this.CashAcceptorRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorRspBox.MaxLength = 1048576;
            this.CashAcceptorRspBox.Multiline = true;
            this.CashAcceptorRspBox.Name = "CashAcceptorRspBox";
            this.CashAcceptorRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CashAcceptorRspBox.Size = new System.Drawing.Size(423, 408);
            this.CashAcceptorRspBox.TabIndex = 48;
            // 
            // CashAcceptorCmdBox
            // 
            this.CashAcceptorCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CashAcceptorCmdBox.Location = new System.Drawing.Point(20, 272);
            this.CashAcceptorCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorCmdBox.MaxLength = 1048576;
            this.CashAcceptorCmdBox.Multiline = true;
            this.CashAcceptorCmdBox.Name = "CashAcceptorCmdBox";
            this.CashAcceptorCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CashAcceptorCmdBox.Size = new System.Drawing.Size(450, 408);
            this.CashAcceptorCmdBox.TabIndex = 45;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(7, 91);
            this.label73.Margin = new System.Windows.Forms.Padding(0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(101, 20);
            this.label73.TabIndex = 49;
            this.label73.Text = "Dispenser URI";
            // 
            // CashAcceptorAccURI
            // 
            this.CashAcceptorAccURI.Location = new System.Drawing.Point(116, 88);
            this.CashAcceptorAccURI.Margin = new System.Windows.Forms.Padding(0);
            this.CashAcceptorAccURI.Name = "CashAcceptorAccURI";
            this.CashAcceptorAccURI.ReadOnly = true;
            this.CashAcceptorAccURI.Size = new System.Drawing.Size(530, 27);
            this.CashAcceptorAccURI.TabIndex = 50;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(9, 57);
            this.label74.Margin = new System.Windows.Forms.Padding(0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(93, 20);
            this.label74.TabIndex = 51;
            this.label74.Text = "Port Number";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(9, 25);
            this.label75.Margin = new System.Windows.Forms.Padding(0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(83, 20);
            this.label75.TabIndex = 53;
            this.label75.Text = "Service URI";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(8, 17);
            this.label76.Margin = new System.Windows.Forms.Padding(0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(83, 20);
            this.label76.TabIndex = 161;
            this.label76.Text = "Service URI";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(8, 50);
            this.label77.Margin = new System.Windows.Forms.Padding(0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(93, 20);
            this.label77.TabIndex = 162;
            this.label77.Text = "Port Number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 736);
            this.Controls.Add(this.testClientTabControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form1";
            this.Text = "TestClientForms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.testClientTabControl.ResumeLayout(false);
            this.CardReaderTab.ResumeLayout(false);
            this.CardReaderTab.PerformLayout();
            this.DispenserTab.ResumeLayout(false);
            this.DispenserTab.PerformLayout();
            this.TextTerminalTab.ResumeLayout(false);
            this.TextTerminalTab.PerformLayout();
            this.EncryptorTab.ResumeLayout(false);
            this.EncryptorTab.PerformLayout();
            this.PinPadTab.ResumeLayout(false);
            this.PinPadTab.PerformLayout();
            this.PrinterTabPage.ResumeLayout(false);
            this.PrinterTabPage.PerformLayout();
            this.lightsTab.ResumeLayout(false);
            this.lightsTab.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.VendorModeTabPage.ResumeLayout(false);
            this.VendorModeTabPage.PerformLayout();
            this.VendorAppTabPage.ResumeLayout(false);
            this.VendorAppTabPage.PerformLayout();
            this.BarcodeReaderTabPage.ResumeLayout(false);
            this.BarcodeReaderTabPage.PerformLayout();
            this.BiometricPage.ResumeLayout(false);
            this.BiometricPage.PerformLayout();
            this.CashAccTabPage.ResumeLayout(false);
            this.CashAccTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptCard;
        private System.Windows.Forms.Button EjectCard;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Button ServiceDiscovery;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCardReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServiceURI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEvent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxStDevice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStMedia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDeviceType;
		private System.Windows.Forms.Button CaptureCard;
        private System.Windows.Forms.TabControl testClientTabControl;
        private System.Windows.Forms.TabPage CardReaderTab;
        private System.Windows.Forms.TabPage DispenserTab;
        private System.Windows.Forms.TextBox DispenserServiceURI;
        private System.Windows.Forms.TextBox DispenserEvtBox;
        private System.Windows.Forms.Button DispenserServiceDiscovery;
        private System.Windows.Forms.TextBox DispenserPortNum;
        private System.Windows.Forms.TextBox DispenserRspBox;
        private System.Windows.Forms.TextBox DispenserCmdBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DispenserDispURI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button DispenserGetCashUnitInfo;
        private System.Windows.Forms.Button DispenserCapabilities;
        private System.Windows.Forms.Button DispenserStatus;
        private System.Windows.Forms.Button DispenserGetMixTypes;
        private System.Windows.Forms.TextBox DispenserDeviceType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox DispenserStDevice;
        private System.Windows.Forms.Button DispenserGetPresentStatus;
        private System.Windows.Forms.Button DispenserReset;
        private System.Windows.Forms.Button DispenserStartExchange;
        private System.Windows.Forms.Button DispenserEndExchange;
        private System.Windows.Forms.Button DispenserPresent;
        private System.Windows.Forms.Button DispenserDispense;
        private System.Windows.Forms.Button DispenserDenominate;
        private System.Windows.Forms.Button DispenserCloseShutter;
        private System.Windows.Forms.Button DispenserOpenShutter;
        private System.Windows.Forms.Button DispenserRetract;
        private System.Windows.Forms.Button DispenserReject;
        private System.Windows.Forms.TabPage TextTerminalTab;
        private System.Windows.Forms.TextBox TextTerminalDeviceType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextTerminalStDevice;
        private System.Windows.Forms.Button TextTerminalCapabilities;
        private System.Windows.Forms.Button TextTerminalStatus;
        private System.Windows.Forms.TextBox TextTerminalServiceURI;
        private System.Windows.Forms.TextBox TextTerminalEvtBox;
        private System.Windows.Forms.Button TextTerminalServiceDiscovery;
        private System.Windows.Forms.TextBox TextTerminalPortNum;
        private System.Windows.Forms.TextBox TextTerminalRspBox;
        private System.Windows.Forms.TextBox TextTerminalCmdBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TextTerminalURI;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button TextTerminalClearScreen;
        private System.Windows.Forms.Button TextTerminalWrite;
        private System.Windows.Forms.Button TextTerminalRead;
        private System.Windows.Forms.Button TextTerminalGetKeyDetail;
        private System.Windows.Forms.Button TextTerminalReset;
        private System.Windows.Forms.Button TextTerminalBeep;
        private System.Windows.Forms.Button TextTerminalSetResolution;
        private System.Windows.Forms.TabPage EncryptorTab;
        private System.Windows.Forms.TextBox EncryptorMaxKeyNum;
        private System.Windows.Forms.TextBox EncryptorStDevice;
        private System.Windows.Forms.Button EncryptorCapabilities;
        private System.Windows.Forms.Button EncryptorStatus;
        private System.Windows.Forms.TextBox EncryptorServiceURI;
        private System.Windows.Forms.Button EncryptorServiceDiscovery;
        private System.Windows.Forms.TextBox EncryptorPortNum;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox EncryptorURI;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox EncryptorEvtBox;
        private System.Windows.Forms.TextBox EncryptorRspBox;
        private System.Windows.Forms.TextBox EncryptorCmdBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button EncryptorImportKey;
        private System.Windows.Forms.Button EncryptorInitialization;
        private System.Windows.Forms.Button EncryptorGetKeyNames;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ListBox EncryptorKeyNamelistBox;
        private System.Windows.Forms.Button EncryptorReset;
        private System.Windows.Forms.Button EncryptorDeleteKey;
        private System.Windows.Forms.Button EncryptorGenerateMAC;
        private System.Windows.Forms.Button EncryptorEncrypt;
        private System.Windows.Forms.Button EncryptorGenerateRandom;
        private System.Windows.Forms.TabPage PinPadTab;
        private System.Windows.Forms.Button PinPadDeleteKey;
        private System.Windows.Forms.Button PinPadReset;
        private System.Windows.Forms.Button PinPadImportKey;
        private System.Windows.Forms.Button PinPadInitialization;
        private System.Windows.Forms.Button PinPadGetKeyNames;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox PinPadKeyNamelistBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox PinPadEvtBox;
        private System.Windows.Forms.TextBox PinPadRspBox;
        private System.Windows.Forms.TextBox PinPadCmdBox;
        private System.Windows.Forms.TextBox PinPadMaxKeyNum;
        private System.Windows.Forms.TextBox PinPadStDevice;
        private System.Windows.Forms.Button PinPadCapabilities;
        private System.Windows.Forms.Button PinPadStatus;
        private System.Windows.Forms.TextBox PinPadServiceURI;
        private System.Windows.Forms.Button PinPadServiceDiscovery;
        private System.Windows.Forms.TextBox PinPadPortNum;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox PinPadURI;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button PinPadFormatPin;
        private System.Windows.Forms.Button PinPadEnterPin;
        private System.Windows.Forms.Button PinPadLoadPinKey;
        private System.Windows.Forms.Button PinPadSecureKeyEntryPart2;
        private System.Windows.Forms.Button PinPadSecureKeyEntryPart1;
        private System.Windows.Forms.Button PinPadEnterData;
        private System.Windows.Forms.Button PinPadGetLayout;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TokenTextBox;
        private System.Windows.Forms.Button ClearCommandNonce;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button GetStorage;
        private System.Windows.Forms.Button ResetBinCount;
        private System.Windows.Forms.Button SetCashUnitInfo;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabPage PrinterTabPage;
        private System.Windows.Forms.ListBox PrinterMediaListBox;
        private System.Windows.Forms.Button PrinterQueryForm;
        private System.Windows.Forms.Button PrinterEject;
        private System.Windows.Forms.Button PrinterQueryMedia;
        private System.Windows.Forms.Button PrinterGetMediaList;
        private System.Windows.Forms.Button PrinterPrintForm;
        private System.Windows.Forms.Button PrinterReset;
        private System.Windows.Forms.Button PrinterPrintRaw;
        private System.Windows.Forms.Button PrinterGetFormList;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ListBox PrinterFormListBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox PrinterEvtBox;
        private System.Windows.Forms.TextBox PrinterRspBox;
        private System.Windows.Forms.TextBox PrinterCmdBox;
        private System.Windows.Forms.TextBox PrinterType;
        private System.Windows.Forms.TextBox PrinterStDevice;
        private System.Windows.Forms.Button PrinterCapabilities;
        private System.Windows.Forms.Button PrinterStatus;
        private System.Windows.Forms.TextBox PrinterServiceURI;
        private System.Windows.Forms.Button PrinterServiceDiscovery;
        private System.Windows.Forms.TextBox PrinterPortNum;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox PrinterURI;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button PrinterLoadDefinition;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox PrinterFormFields;
        private System.Windows.Forms.TabPage lightsTab;
        private System.Windows.Forms.Button LightsSetLight;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox LightsEvtBox;
        private System.Windows.Forms.TextBox LightsRspBox;
        private System.Windows.Forms.TextBox LightsCmdBox;
        private System.Windows.Forms.TextBox lblLightsStatus;
        private System.Windows.Forms.Button LightsCapabilities;
        private System.Windows.Forms.Button LightsStatus;
        private System.Windows.Forms.TextBox LightsServiceURI;
        private System.Windows.Forms.TextBox LightsPortNum;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox LightsURI;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtLightName;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox LightsFlashRate;
        private System.Windows.Forms.Button LightsServiceDiscovery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAuxiliariesServiceDiscovery;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox AuxiliariesEvtBox;
        private System.Windows.Forms.TextBox AuxiliariesRspBox;
        private System.Windows.Forms.TextBox AuxiliariesCmdBox;
        private System.Windows.Forms.TextBox AuxiliariesStatus;
        private System.Windows.Forms.Button btnAuxiliariesCapabilities;
        private System.Windows.Forms.Button btnAuxiliariesStatus;
        private System.Windows.Forms.TextBox AuxiliariesServiceURI;
        private System.Windows.Forms.TextBox AuxiliariesPortNum;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox AuxiliariesURI;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Button btnClearAutoStartup;
        private System.Windows.Forms.Button btnGetAutoStartup;
        private System.Windows.Forms.Button btnSetAutoStartup;
        private System.Windows.Forms.DateTimePicker autoStartupDateTime;
        private System.Windows.Forms.Button btnSetAuxiliaries;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox comboAutoStartupModes;
        private System.Windows.Forms.TabPage VendorModeTabPage;
        private System.Windows.Forms.TextBox VendorModeEvtBox;
        private System.Windows.Forms.TextBox VendorModeRspBox;
        private System.Windows.Forms.TextBox VendorModeCmdBox;
        private System.Windows.Forms.Button btnVendorModeServiceDiscovery;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox VendorModeStStatus;
        private System.Windows.Forms.Button btnVendorModeStatus;
        private System.Windows.Forms.TextBox VendorModeServiceURI;
        private System.Windows.Forms.TextBox VendorModePortNum;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox VendorModeURI;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TabPage VendorAppTabPage;
        private System.Windows.Forms.TextBox VendorAppEvtBox;
        private System.Windows.Forms.TextBox VendorAppRspBox;
        private System.Windows.Forms.TextBox VendorAppCmdBox;
        private System.Windows.Forms.Button btnVendorAppServiceDiscovery;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox VendorAppStatus;
        private System.Windows.Forms.Button btnVendorAppCapabilities;
        private System.Windows.Forms.Button btnVendorAppStatus;
        private System.Windows.Forms.TextBox VendorAppServiceURI;
        private System.Windows.Forms.TextBox VendorAppPortNum;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox VendorAppURI;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox VendorModeServiceStatus;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button buttonVDMExit;
        private System.Windows.Forms.Button buttonVDMEnter;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textActiveInterface;
        private System.Windows.Forms.Button buttonGetActiveInterface;
        private System.Windows.Forms.Button buttonStartLocalApplication;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox textAppName;
        private System.Windows.Forms.TabPage BarcodeReaderTabPage;
        private System.Windows.Forms.Button BarcodeReaderReset;
        private System.Windows.Forms.Button BarcodeReaderRead;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox BarcodeReaderEvtBox;
        private System.Windows.Forms.TextBox BarcodeReaderRspBox;
        private System.Windows.Forms.TextBox BarcodeReaderCmdBox;
        private System.Windows.Forms.TextBox BarcodeReaderScannerStatus;
        private System.Windows.Forms.TextBox BarcodeReaderStDevice;
        private System.Windows.Forms.Button BarcodeReaderCapabilities;
        private System.Windows.Forms.Button BarcodeReaderStatus;
        private System.Windows.Forms.TextBox BarcodeReaderServiceURI;
        private System.Windows.Forms.Button btnBarcodeReaderServiceDiscovery;
        private System.Windows.Forms.TextBox BarcodeReaderPortNum;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox BarcodeReaderURI;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TabPage BiometricPage;
        private System.Windows.Forms.Button btnBiometricReset;
        private System.Windows.Forms.Button btnBiometricRead;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox BiometricEvtBox;
        private System.Windows.Forms.TextBox BiometricRspBox;
        private System.Windows.Forms.TextBox BiometricCmdBox;
        private System.Windows.Forms.TextBox BiometricStatus;
        private System.Windows.Forms.Button btnBiometricCapabilities;
        private System.Windows.Forms.Button btnBiometricStatus;
        private System.Windows.Forms.TextBox BiometricServiceURI;
        private System.Windows.Forms.Button btnBiometricServiceDiscovery;
        private System.Windows.Forms.TextBox BiometricPortNum;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox BiometricURI;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox txtBiometricTemplateData;
        private System.Windows.Forms.Button btnBiometricClear;
        private System.Windows.Forms.Button btnBiometricMatch;
        private System.Windows.Forms.Button btnBiometricImport;
        private System.Windows.Forms.Button btnBiometricReadMatch;
        private System.Windows.Forms.Button btnBiometricGetStorageInfo;
        private System.Windows.Forms.ListBox BiometricStorageInfo;
        private System.Windows.Forms.TabPage CashAccTabPage;
        private System.Windows.Forms.Button CashAccSetCashUnitInfo;
        private System.Windows.Forms.Button CashAccRetract;
        private System.Windows.Forms.Button CashAccCashIn;
        private System.Windows.Forms.Button CashAccConfigureNoteTypes;
        private System.Windows.Forms.Button CashAccCashInEnd;
        private System.Windows.Forms.Button CashAccCashInStart;
        private System.Windows.Forms.Button CashAccCashInRollback;
        private System.Windows.Forms.Button CashAccEndExchange;
        private System.Windows.Forms.Button CashAccStartExchange;
        private System.Windows.Forms.Button CashAccReset;
        private System.Windows.Forms.Button CashAccCashInStatus;
        private System.Windows.Forms.TextBox CashAccDeviceType;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox CashAccStDevice;
        private System.Windows.Forms.Button CashAccPositionCapabilities;
        private System.Windows.Forms.Button CashAccCapabilities;
        private System.Windows.Forms.Button CashAccStatus;
        private System.Windows.Forms.Button CashAccGetCashUnitInfo;
        private System.Windows.Forms.TextBox CashAcceptorServiceURI;
        private System.Windows.Forms.TextBox CashAcceptorEvtBox;
        private System.Windows.Forms.Button CashAcceptorServiceDiscovery;
        private System.Windows.Forms.TextBox CashAcceptorPortNum;
        private System.Windows.Forms.TextBox CashAcceptorRspBox;
        private System.Windows.Forms.TextBox CashAcceptorCmdBox;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox CashAcceptorAccURI;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
    }
}

