/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
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
            this.testClientTabControl.SuspendLayout();
            this.CardReaderTab.SuspendLayout();
            this.DispenserTab.SuspendLayout();
            this.TextTerminalTab.SuspendLayout();
            this.EncryptorTab.SuspendLayout();
            this.PinPadTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.lightsTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.BiometricPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptCard
            // 
            this.AcceptCard.Location = new System.Drawing.Point(961, 19);
            this.AcceptCard.Margin = new System.Windows.Forms.Padding(0);
            this.AcceptCard.Name = "AcceptCard";
            this.AcceptCard.Size = new System.Drawing.Size(93, 24);
            this.AcceptCard.TabIndex = 0;
            this.AcceptCard.Text = "AcceptCard";
            this.AcceptCard.UseVisualStyleBackColor = true;
            this.AcceptCard.Click += new System.EventHandler(this.AcceptCard_Click);
            // 
            // EjectCard
            // 
            this.EjectCard.Location = new System.Drawing.Point(961, 54);
            this.EjectCard.Margin = new System.Windows.Forms.Padding(0);
            this.EjectCard.Name = "EjectCard";
            this.EjectCard.Size = new System.Drawing.Size(93, 24);
            this.EjectCard.TabIndex = 1;
            this.EjectCard.Text = "EjectCard";
            this.EjectCard.UseVisualStyleBackColor = true;
            this.EjectCard.Click += new System.EventHandler(this.EjectCard_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxCommand.Location = new System.Drawing.Point(15, 200);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCommand.MaxLength = 1048576;
            this.textBoxCommand.Multiline = true;
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommand.Size = new System.Drawing.Size(394, 307);
            this.textBoxCommand.TabIndex = 2;
            // 
            // ServiceDiscovery
            // 
            this.ServiceDiscovery.Location = new System.Drawing.Point(439, 102);
            this.ServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.ServiceDiscovery.Name = "ServiceDiscovery";
            this.ServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.ServiceDiscovery.TabIndex = 3;
            this.ServiceDiscovery.Text = "Service Discovery";
            this.ServiceDiscovery.UseVisualStyleBackColor = true;
            this.ServiceDiscovery.Click += new System.EventHandler(this.ServiceDiscovery_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(100, 43);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            this.textBoxPort.Size = new System.Drawing.Size(106, 23);
            this.textBoxPort.TabIndex = 4;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxResponse.Location = new System.Drawing.Point(427, 200);
            this.textBoxResponse.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxResponse.MaxLength = 1048576;
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(371, 307);
            this.textBoxResponse.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "CardReader URI";
            // 
            // textBoxCardReader
            // 
            this.textBoxCardReader.Location = new System.Drawing.Point(100, 66);
            this.textBoxCardReader.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCardReader.Name = "textBoxCardReader";
            this.textBoxCardReader.ReadOnly = true;
            this.textBoxCardReader.Size = new System.Drawing.Size(464, 23);
            this.textBoxCardReader.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port Number";
            // 
            // textBoxServiceURI
            // 
            this.textBoxServiceURI.Location = new System.Drawing.Point(100, 19);
            this.textBoxServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxServiceURI.Name = "textBoxServiceURI";
            this.textBoxServiceURI.Size = new System.Drawing.Size(464, 23);
            this.textBoxServiceURI.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Service URI";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(836, 32);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(84, 26);
            this.buttonStatus.TabIndex = 12;
            this.buttonStatus.Text = "Status";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Response";
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxEvent.Location = new System.Drawing.Point(814, 200);
            this.textBoxEvent.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxEvent.MaxLength = 1048576;
            this.textBoxEvent.Multiline = true;
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEvent.Size = new System.Drawing.Size(355, 307);
            this.textBoxEvent.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(812, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Event";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(626, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Device status";
            // 
            // textBoxStDevice
            // 
            this.textBoxStDevice.Location = new System.Drawing.Point(713, 16);
            this.textBoxStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxStDevice.Name = "textBoxStDevice";
            this.textBoxStDevice.ReadOnly = true;
            this.textBoxStDevice.Size = new System.Drawing.Size(106, 23);
            this.textBoxStDevice.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Media Status";
            // 
            // textBoxStMedia
            // 
            this.textBoxStMedia.Location = new System.Drawing.Point(713, 41);
            this.textBoxStMedia.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxStMedia.Name = "textBoxStMedia";
            this.textBoxStMedia.ReadOnly = true;
            this.textBoxStMedia.Size = new System.Drawing.Size(106, 23);
            this.textBoxStMedia.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "Capabilities";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(633, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Device type";
            // 
            // textBoxDeviceType
            // 
            this.textBoxDeviceType.Location = new System.Drawing.Point(713, 94);
            this.textBoxDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDeviceType.Name = "textBoxDeviceType";
            this.textBoxDeviceType.ReadOnly = true;
            this.textBoxDeviceType.Size = new System.Drawing.Size(106, 23);
            this.textBoxDeviceType.TabIndex = 23;
            // 
            // CaptureCard
            // 
            this.CaptureCard.Location = new System.Drawing.Point(961, 95);
            this.CaptureCard.Margin = new System.Windows.Forms.Padding(0);
            this.CaptureCard.Name = "CaptureCard";
            this.CaptureCard.Size = new System.Drawing.Size(93, 24);
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
            this.testClientTabControl.Controls.Add(this.tabPage1);
            this.testClientTabControl.Controls.Add(this.lightsTab);
            this.testClientTabControl.Controls.Add(this.tabPage2);
            this.testClientTabControl.Controls.Add(this.tabPage3);
            this.testClientTabControl.Controls.Add(this.tabPage4);
            this.testClientTabControl.Controls.Add(this.tabPage5);
            this.testClientTabControl.Controls.Add(this.BiometricPage);
            this.testClientTabControl.Location = new System.Drawing.Point(7, 2);
            this.testClientTabControl.Name = "testClientTabControl";
            this.testClientTabControl.SelectedIndex = 0;
            this.testClientTabControl.Size = new System.Drawing.Size(1185, 543);
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
            this.CardReaderTab.Location = new System.Drawing.Point(4, 24);
            this.CardReaderTab.Margin = new System.Windows.Forms.Padding(1);
            this.CardReaderTab.Name = "CardReaderTab";
            this.CardReaderTab.Padding = new System.Windows.Forms.Padding(1);
            this.CardReaderTab.Size = new System.Drawing.Size(1177, 515);
            this.CardReaderTab.TabIndex = 0;
            this.CardReaderTab.Text = "Card Reader";
            this.CardReaderTab.UseVisualStyleBackColor = true;
            // 
            // ResetBinCount
            // 
            this.ResetBinCount.Location = new System.Drawing.Point(1076, 54);
            this.ResetBinCount.Margin = new System.Windows.Forms.Padding(1);
            this.ResetBinCount.Name = "ResetBinCount";
            this.ResetBinCount.Size = new System.Drawing.Size(93, 24);
            this.ResetBinCount.TabIndex = 27;
            this.ResetBinCount.Text = "ResetBinCount";
            this.ResetBinCount.UseVisualStyleBackColor = true;
            this.ResetBinCount.Click += new System.EventHandler(this.ResetBinCount_Click);
            // 
            // GetStorage
            // 
            this.GetStorage.Location = new System.Drawing.Point(1076, 95);
            this.GetStorage.Margin = new System.Windows.Forms.Padding(1);
            this.GetStorage.Name = "GetStorage";
            this.GetStorage.Size = new System.Drawing.Size(93, 24);
            this.GetStorage.TabIndex = 26;
            this.GetStorage.Text = "GetStorage";
            this.GetStorage.UseVisualStyleBackColor = true;
            this.GetStorage.Click += new System.EventHandler(this.GetStorage_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1076, 19);
            this.Reset.Margin = new System.Windows.Forms.Padding(1);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(93, 24);
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
            this.DispenserTab.Location = new System.Drawing.Point(4, 24);
            this.DispenserTab.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserTab.Name = "DispenserTab";
            this.DispenserTab.Padding = new System.Windows.Forms.Padding(1);
            this.DispenserTab.Size = new System.Drawing.Size(1177, 515);
            this.DispenserTab.TabIndex = 1;
            this.DispenserTab.Text = "Dispenser";
            this.DispenserTab.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 146);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(105, 15);
            this.label32.TabIndex = 45;
            this.label32.Text = "Command Nonce:";
            // 
            // SetCashUnitInfo
            // 
            this.SetCashUnitInfo.Location = new System.Drawing.Point(789, 74);
            this.SetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            this.SetCashUnitInfo.Name = "SetCashUnitInfo";
            this.SetCashUnitInfo.Size = new System.Drawing.Size(111, 22);
            this.SetCashUnitInfo.TabIndex = 44;
            this.SetCashUnitInfo.Text = "SetCashUnitInfo";
            this.SetCashUnitInfo.UseVisualStyleBackColor = true;
            this.SetCashUnitInfo.Click += new System.EventHandler(this.SetCashUnitInfo_Click);
            // 
            // DispenserRetract
            // 
            this.DispenserRetract.Location = new System.Drawing.Point(921, 120);
            this.DispenserRetract.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserRetract.Name = "DispenserRetract";
            this.DispenserRetract.Size = new System.Drawing.Size(111, 21);
            this.DispenserRetract.TabIndex = 43;
            this.DispenserRetract.Text = "Retract";
            this.DispenserRetract.UseVisualStyleBackColor = true;
            this.DispenserRetract.Click += new System.EventHandler(this.DispenserRetract_Click);
            // 
            // DispenserReject
            // 
            this.DispenserReject.Location = new System.Drawing.Point(921, 91);
            this.DispenserReject.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserReject.Name = "DispenserReject";
            this.DispenserReject.Size = new System.Drawing.Size(111, 21);
            this.DispenserReject.TabIndex = 42;
            this.DispenserReject.Text = "Reject";
            this.DispenserReject.UseVisualStyleBackColor = true;
            this.DispenserReject.Click += new System.EventHandler(this.DispenserReject_Click);
            // 
            // DispenserCloseShutter
            // 
            this.DispenserCloseShutter.Location = new System.Drawing.Point(921, 64);
            this.DispenserCloseShutter.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCloseShutter.Name = "DispenserCloseShutter";
            this.DispenserCloseShutter.Size = new System.Drawing.Size(111, 21);
            this.DispenserCloseShutter.TabIndex = 41;
            this.DispenserCloseShutter.Text = "CloseShutter";
            this.DispenserCloseShutter.UseVisualStyleBackColor = true;
            this.DispenserCloseShutter.Click += new System.EventHandler(this.DispenserCloseShutter_Click);
            // 
            // DispenserOpenShutter
            // 
            this.DispenserOpenShutter.Location = new System.Drawing.Point(921, 36);
            this.DispenserOpenShutter.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserOpenShutter.Name = "DispenserOpenShutter";
            this.DispenserOpenShutter.Size = new System.Drawing.Size(111, 22);
            this.DispenserOpenShutter.TabIndex = 40;
            this.DispenserOpenShutter.Text = "OpenShutter";
            this.DispenserOpenShutter.UseVisualStyleBackColor = true;
            this.DispenserOpenShutter.Click += new System.EventHandler(this.DispenserOpenShutter_Click);
            // 
            // DispenserDispense
            // 
            this.DispenserDispense.Location = new System.Drawing.Point(1052, 119);
            this.DispenserDispense.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDispense.Name = "DispenserDispense";
            this.DispenserDispense.Size = new System.Drawing.Size(111, 22);
            this.DispenserDispense.TabIndex = 39;
            this.DispenserDispense.Text = "Dispense";
            this.DispenserDispense.UseVisualStyleBackColor = true;
            this.DispenserDispense.Click += new System.EventHandler(this.DispenserDispense_Click);
            // 
            // ClearCommandNonce
            // 
            this.ClearCommandNonce.Location = new System.Drawing.Point(166, 120);
            this.ClearCommandNonce.Margin = new System.Windows.Forms.Padding(0);
            this.ClearCommandNonce.Name = "ClearCommandNonce";
            this.ClearCommandNonce.Size = new System.Drawing.Size(143, 23);
            this.ClearCommandNonce.TabIndex = 38;
            this.ClearCommandNonce.Text = "ClearCommandNonce";
            this.ClearCommandNonce.UseVisualStyleBackColor = true;
            this.ClearCommandNonce.Click += new System.EventHandler(this.DispenserClearCommandNonce_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 120);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "GetCommandNonce";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DispenserGetCommandNonce_Click);
            // 
            // DispenserDenominate
            // 
            this.DispenserDenominate.Location = new System.Drawing.Point(1052, 90);
            this.DispenserDenominate.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDenominate.Name = "DispenserDenominate";
            this.DispenserDenominate.Size = new System.Drawing.Size(111, 22);
            this.DispenserDenominate.TabIndex = 38;
            this.DispenserDenominate.Text = "Denominate";
            this.DispenserDenominate.UseVisualStyleBackColor = true;
            this.DispenserDenominate.Click += new System.EventHandler(this.DispenserDenominate_Click);
            // 
            // DispenserPresent
            // 
            this.DispenserPresent.Location = new System.Drawing.Point(1052, 149);
            this.DispenserPresent.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserPresent.Name = "DispenserPresent";
            this.DispenserPresent.Size = new System.Drawing.Size(111, 22);
            this.DispenserPresent.TabIndex = 37;
            this.DispenserPresent.Text = "Present";
            this.DispenserPresent.UseVisualStyleBackColor = true;
            this.DispenserPresent.Click += new System.EventHandler(this.DispenserPresent_Click);
            // 
            // DispenserEndExchange
            // 
            this.DispenserEndExchange.Location = new System.Drawing.Point(1052, 36);
            this.DispenserEndExchange.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserEndExchange.Name = "DispenserEndExchange";
            this.DispenserEndExchange.Size = new System.Drawing.Size(111, 22);
            this.DispenserEndExchange.TabIndex = 36;
            this.DispenserEndExchange.Text = "EndExchange";
            this.DispenserEndExchange.UseVisualStyleBackColor = true;
            this.DispenserEndExchange.Click += new System.EventHandler(this.DispenserEndExchange_Click);
            // 
            // DispenserStartExchange
            // 
            this.DispenserStartExchange.Location = new System.Drawing.Point(1052, 8);
            this.DispenserStartExchange.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStartExchange.Name = "DispenserStartExchange";
            this.DispenserStartExchange.Size = new System.Drawing.Size(111, 22);
            this.DispenserStartExchange.TabIndex = 35;
            this.DispenserStartExchange.Text = "StartExchange";
            this.DispenserStartExchange.UseVisualStyleBackColor = true;
            this.DispenserStartExchange.Click += new System.EventHandler(this.DispenserStartExchange_Click);
            // 
            // DispenserReset
            // 
            this.DispenserReset.Location = new System.Drawing.Point(921, 8);
            this.DispenserReset.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserReset.Name = "DispenserReset";
            this.DispenserReset.Size = new System.Drawing.Size(111, 22);
            this.DispenserReset.TabIndex = 34;
            this.DispenserReset.Text = "Reset";
            this.DispenserReset.UseVisualStyleBackColor = true;
            this.DispenserReset.Click += new System.EventHandler(this.DispenserReset_Click);
            // 
            // DispenserGetPresentStatus
            // 
            this.DispenserGetPresentStatus.Location = new System.Drawing.Point(789, 163);
            this.DispenserGetPresentStatus.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetPresentStatus.Name = "DispenserGetPresentStatus";
            this.DispenserGetPresentStatus.Size = new System.Drawing.Size(111, 22);
            this.DispenserGetPresentStatus.TabIndex = 33;
            this.DispenserGetPresentStatus.Text = "GetPresentStatus";
            this.DispenserGetPresentStatus.UseVisualStyleBackColor = true;
            this.DispenserGetPresentStatus.Click += new System.EventHandler(this.DispenserGetPresentStatus_Click);
            // 
            // DispenserDeviceType
            // 
            this.DispenserDeviceType.Location = new System.Drawing.Point(692, 43);
            this.DispenserDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDeviceType.Name = "DispenserDeviceType";
            this.DispenserDeviceType.ReadOnly = true;
            this.DispenserDeviceType.Size = new System.Drawing.Size(106, 23);
            this.DispenserDeviceType.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(609, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Device type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(609, 11);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Device status";
            // 
            // DispenserStDevice
            // 
            this.DispenserStDevice.Location = new System.Drawing.Point(692, 12);
            this.DispenserStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStDevice.Name = "DispenserStDevice";
            this.DispenserStDevice.ReadOnly = true;
            this.DispenserStDevice.Size = new System.Drawing.Size(106, 23);
            this.DispenserStDevice.TabIndex = 30;
            // 
            // DispenserGetMixTypes
            // 
            this.DispenserGetMixTypes.Location = new System.Drawing.Point(789, 134);
            this.DispenserGetMixTypes.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetMixTypes.Name = "DispenserGetMixTypes";
            this.DispenserGetMixTypes.Size = new System.Drawing.Size(111, 22);
            this.DispenserGetMixTypes.TabIndex = 29;
            this.DispenserGetMixTypes.Text = "GetMixTypes";
            this.DispenserGetMixTypes.UseVisualStyleBackColor = true;
            this.DispenserGetMixTypes.Click += new System.EventHandler(this.DispenserGetMixTypes_Click);
            // 
            // DispenserCapabilities
            // 
            this.DispenserCapabilities.Location = new System.Drawing.Point(810, 36);
            this.DispenserCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCapabilities.Name = "DispenserCapabilities";
            this.DispenserCapabilities.Size = new System.Drawing.Size(90, 22);
            this.DispenserCapabilities.TabIndex = 28;
            this.DispenserCapabilities.Text = "Capabilities";
            this.DispenserCapabilities.UseVisualStyleBackColor = true;
            this.DispenserCapabilities.Click += new System.EventHandler(this.DispenserCapabilities_Click);
            // 
            // DispenserStatus
            // 
            this.DispenserStatus.Location = new System.Drawing.Point(810, 8);
            this.DispenserStatus.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserStatus.Name = "DispenserStatus";
            this.DispenserStatus.Size = new System.Drawing.Size(90, 22);
            this.DispenserStatus.TabIndex = 27;
            this.DispenserStatus.Text = "Status";
            this.DispenserStatus.UseVisualStyleBackColor = true;
            this.DispenserStatus.Click += new System.EventHandler(this.DispenserStatus_Click);
            // 
            // DispenserGetCashUnitInfo
            // 
            this.DispenserGetCashUnitInfo.Location = new System.Drawing.Point(789, 104);
            this.DispenserGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserGetCashUnitInfo.Name = "DispenserGetCashUnitInfo";
            this.DispenserGetCashUnitInfo.Size = new System.Drawing.Size(111, 22);
            this.DispenserGetCashUnitInfo.TabIndex = 26;
            this.DispenserGetCashUnitInfo.Text = "GetCashUnitInfo";
            this.DispenserGetCashUnitInfo.UseVisualStyleBackColor = true;
            this.DispenserGetCashUnitInfo.Click += new System.EventHandler(this.DispenserGetCashUnitInfo_Click);
            // 
            // DispenserServiceURI
            // 
            this.DispenserServiceURI.Location = new System.Drawing.Point(100, 19);
            this.DispenserServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserServiceURI.Name = "DispenserServiceURI";
            this.DispenserServiceURI.Size = new System.Drawing.Size(464, 23);
            this.DispenserServiceURI.TabIndex = 23;
            // 
            // DispenserEvtBox
            // 
            this.DispenserEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserEvtBox.Location = new System.Drawing.Point(816, 204);
            this.DispenserEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserEvtBox.MaxLength = 1048576;
            this.DispenserEvtBox.Multiline = true;
            this.DispenserEvtBox.Name = "DispenserEvtBox";
            this.DispenserEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserEvtBox.Size = new System.Drawing.Size(355, 307);
            this.DispenserEvtBox.TabIndex = 25;
            // 
            // DispenserServiceDiscovery
            // 
            this.DispenserServiceDiscovery.Location = new System.Drawing.Point(439, 102);
            this.DispenserServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserServiceDiscovery.Name = "DispenserServiceDiscovery";
            this.DispenserServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.DispenserServiceDiscovery.TabIndex = 17;
            this.DispenserServiceDiscovery.Text = "Service Discovery";
            this.DispenserServiceDiscovery.UseVisualStyleBackColor = true;
            this.DispenserServiceDiscovery.Click += new System.EventHandler(this.DispenserServiceDiscovery_Click);
            // 
            // DispenserPortNum
            // 
            this.DispenserPortNum.Location = new System.Drawing.Point(100, 43);
            this.DispenserPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserPortNum.Name = "DispenserPortNum";
            this.DispenserPortNum.ReadOnly = true;
            this.DispenserPortNum.Size = new System.Drawing.Size(106, 23);
            this.DispenserPortNum.TabIndex = 18;
            // 
            // DispenserRspBox
            // 
            this.DispenserRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserRspBox.Location = new System.Drawing.Point(427, 204);
            this.DispenserRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserRspBox.MaxLength = 1048576;
            this.DispenserRspBox.Multiline = true;
            this.DispenserRspBox.Name = "DispenserRspBox";
            this.DispenserRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserRspBox.Size = new System.Drawing.Size(371, 307);
            this.DispenserRspBox.TabIndex = 19;
            // 
            // DispenserCmdBox
            // 
            this.DispenserCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserCmdBox.Location = new System.Drawing.Point(16, 204);
            this.DispenserCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserCmdBox.MaxLength = 1048576;
            this.DispenserCmdBox.Multiline = true;
            this.DispenserCmdBox.Name = "DispenserCmdBox";
            this.DispenserCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispenserCmdBox.Size = new System.Drawing.Size(394, 307);
            this.DispenserCmdBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dispenser URI";
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Location = new System.Drawing.Point(16, 164);
            this.TokenTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.ReadOnly = true;
            this.TokenTextBox.Size = new System.Drawing.Size(759, 23);
            this.TokenTextBox.TabIndex = 21;
            // 
            // DispenserDispURI
            // 
            this.DispenserDispURI.Location = new System.Drawing.Point(100, 66);
            this.DispenserDispURI.Margin = new System.Windows.Forms.Padding(0);
            this.DispenserDispURI.Name = "DispenserDispURI";
            this.DispenserDispURI.ReadOnly = true;
            this.DispenserDispURI.Size = new System.Drawing.Size(464, 23);
            this.DispenserDispURI.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Port Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
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
            this.TextTerminalTab.Location = new System.Drawing.Point(4, 24);
            this.TextTerminalTab.Name = "TextTerminalTab";
            this.TextTerminalTab.Padding = new System.Windows.Forms.Padding(3);
            this.TextTerminalTab.Size = new System.Drawing.Size(1177, 515);
            this.TextTerminalTab.TabIndex = 2;
            this.TextTerminalTab.Text = "Text Terminal";
            this.TextTerminalTab.UseVisualStyleBackColor = true;
            // 
            // TextTerminalSetResolution
            // 
            this.TextTerminalSetResolution.Location = new System.Drawing.Point(1052, 80);
            this.TextTerminalSetResolution.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalSetResolution.Name = "TextTerminalSetResolution";
            this.TextTerminalSetResolution.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalSetResolution.TabIndex = 59;
            this.TextTerminalSetResolution.Text = "SetResolution";
            this.TextTerminalSetResolution.UseVisualStyleBackColor = true;
            this.TextTerminalSetResolution.Click += new System.EventHandler(this.TextTerminalSetResolution_Click);
            // 
            // TextTerminalBeep
            // 
            this.TextTerminalBeep.Location = new System.Drawing.Point(939, 32);
            this.TextTerminalBeep.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalBeep.Name = "TextTerminalBeep";
            this.TextTerminalBeep.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalBeep.TabIndex = 56;
            this.TextTerminalBeep.Text = "Beep";
            this.TextTerminalBeep.UseVisualStyleBackColor = true;
            this.TextTerminalBeep.Click += new System.EventHandler(this.TextTerminalBeep_Click);
            // 
            // TextTerminalReset
            // 
            this.TextTerminalReset.Location = new System.Drawing.Point(939, 8);
            this.TextTerminalReset.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalReset.Name = "TextTerminalReset";
            this.TextTerminalReset.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalReset.TabIndex = 53;
            this.TextTerminalReset.Text = "Reset";
            this.TextTerminalReset.UseVisualStyleBackColor = true;
            this.TextTerminalReset.Click += new System.EventHandler(this.TextTerminalReset_Click);
            // 
            // TextTerminalGetKeyDetail
            // 
            this.TextTerminalGetKeyDetail.Location = new System.Drawing.Point(939, 56);
            this.TextTerminalGetKeyDetail.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalGetKeyDetail.Name = "TextTerminalGetKeyDetail";
            this.TextTerminalGetKeyDetail.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalGetKeyDetail.TabIndex = 52;
            this.TextTerminalGetKeyDetail.Text = "GetKeyDetail";
            this.TextTerminalGetKeyDetail.UseVisualStyleBackColor = true;
            this.TextTerminalGetKeyDetail.Click += new System.EventHandler(this.TextTerminalGetKeyDetail_Click);
            // 
            // TextTerminalRead
            // 
            this.TextTerminalRead.Location = new System.Drawing.Point(1052, 56);
            this.TextTerminalRead.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalRead.Name = "TextTerminalRead";
            this.TextTerminalRead.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalRead.TabIndex = 51;
            this.TextTerminalRead.Text = "Read";
            this.TextTerminalRead.UseVisualStyleBackColor = true;
            this.TextTerminalRead.Click += new System.EventHandler(this.TextTerminalRead_Click);
            // 
            // TextTerminalWrite
            // 
            this.TextTerminalWrite.Location = new System.Drawing.Point(1052, 32);
            this.TextTerminalWrite.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalWrite.Name = "TextTerminalWrite";
            this.TextTerminalWrite.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalWrite.TabIndex = 50;
            this.TextTerminalWrite.Text = "Write";
            this.TextTerminalWrite.UseVisualStyleBackColor = true;
            this.TextTerminalWrite.Click += new System.EventHandler(this.TextTerminalWrite_Click);
            // 
            // TextTerminalClearScreen
            // 
            this.TextTerminalClearScreen.Location = new System.Drawing.Point(1052, 8);
            this.TextTerminalClearScreen.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalClearScreen.Name = "TextTerminalClearScreen";
            this.TextTerminalClearScreen.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalClearScreen.TabIndex = 49;
            this.TextTerminalClearScreen.Text = "ClearScreen";
            this.TextTerminalClearScreen.UseVisualStyleBackColor = true;
            this.TextTerminalClearScreen.Click += new System.EventHandler(this.TextTerminalClearScreen_Click);
            // 
            // TextTerminalDeviceType
            // 
            this.TextTerminalDeviceType.Location = new System.Drawing.Point(693, 41);
            this.TextTerminalDeviceType.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalDeviceType.Name = "TextTerminalDeviceType";
            this.TextTerminalDeviceType.ReadOnly = true;
            this.TextTerminalDeviceType.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalDeviceType.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(610, 43);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
            this.label15.TabIndex = 47;
            this.label15.Text = "Device type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(610, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 15);
            this.label16.TabIndex = 43;
            this.label16.Text = "Device status";
            // 
            // TextTerminalStDevice
            // 
            this.TextTerminalStDevice.Location = new System.Drawing.Point(693, 10);
            this.TextTerminalStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalStDevice.Name = "TextTerminalStDevice";
            this.TextTerminalStDevice.ReadOnly = true;
            this.TextTerminalStDevice.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalStDevice.TabIndex = 46;
            // 
            // TextTerminalCapabilities
            // 
            this.TextTerminalCapabilities.Location = new System.Drawing.Point(811, 34);
            this.TextTerminalCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalCapabilities.Name = "TextTerminalCapabilities";
            this.TextTerminalCapabilities.Size = new System.Drawing.Size(90, 22);
            this.TextTerminalCapabilities.TabIndex = 45;
            this.TextTerminalCapabilities.Text = "Capabilities";
            this.TextTerminalCapabilities.UseVisualStyleBackColor = true;
            this.TextTerminalCapabilities.Click += new System.EventHandler(this.TextTerminalCapabilities_Click);
            // 
            // TextTerminalStatus
            // 
            this.TextTerminalStatus.Location = new System.Drawing.Point(811, 6);
            this.TextTerminalStatus.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalStatus.Name = "TextTerminalStatus";
            this.TextTerminalStatus.Size = new System.Drawing.Size(90, 22);
            this.TextTerminalStatus.TabIndex = 44;
            this.TextTerminalStatus.Text = "Status";
            this.TextTerminalStatus.UseVisualStyleBackColor = true;
            this.TextTerminalStatus.Click += new System.EventHandler(this.TextTerminalStatus_Click);
            // 
            // TextTerminalServiceURI
            // 
            this.TextTerminalServiceURI.Location = new System.Drawing.Point(101, 17);
            this.TextTerminalServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalServiceURI.Name = "TextTerminalServiceURI";
            this.TextTerminalServiceURI.Size = new System.Drawing.Size(464, 23);
            this.TextTerminalServiceURI.TabIndex = 40;
            // 
            // TextTerminalEvtBox
            // 
            this.TextTerminalEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalEvtBox.Location = new System.Drawing.Point(817, 202);
            this.TextTerminalEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalEvtBox.MaxLength = 1048576;
            this.TextTerminalEvtBox.Multiline = true;
            this.TextTerminalEvtBox.Name = "TextTerminalEvtBox";
            this.TextTerminalEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalEvtBox.Size = new System.Drawing.Size(355, 307);
            this.TextTerminalEvtBox.TabIndex = 42;
            // 
            // TextTerminalServiceDiscovery
            // 
            this.TextTerminalServiceDiscovery.Location = new System.Drawing.Point(440, 100);
            this.TextTerminalServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalServiceDiscovery.Name = "TextTerminalServiceDiscovery";
            this.TextTerminalServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.TextTerminalServiceDiscovery.TabIndex = 34;
            this.TextTerminalServiceDiscovery.Text = "Service Discovery";
            this.TextTerminalServiceDiscovery.UseVisualStyleBackColor = true;
            this.TextTerminalServiceDiscovery.Click += new System.EventHandler(this.TextTerminalServiceDiscovery_Click);
            // 
            // TextTerminalPortNum
            // 
            this.TextTerminalPortNum.Location = new System.Drawing.Point(101, 41);
            this.TextTerminalPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalPortNum.Name = "TextTerminalPortNum";
            this.TextTerminalPortNum.ReadOnly = true;
            this.TextTerminalPortNum.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalPortNum.TabIndex = 35;
            // 
            // TextTerminalRspBox
            // 
            this.TextTerminalRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalRspBox.Location = new System.Drawing.Point(428, 202);
            this.TextTerminalRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalRspBox.MaxLength = 1048576;
            this.TextTerminalRspBox.Multiline = true;
            this.TextTerminalRspBox.Name = "TextTerminalRspBox";
            this.TextTerminalRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalRspBox.Size = new System.Drawing.Size(371, 307);
            this.TextTerminalRspBox.TabIndex = 36;
            // 
            // TextTerminalCmdBox
            // 
            this.TextTerminalCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalCmdBox.Location = new System.Drawing.Point(17, 202);
            this.TextTerminalCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalCmdBox.MaxLength = 1048576;
            this.TextTerminalCmdBox.Multiline = true;
            this.TextTerminalCmdBox.Name = "TextTerminalCmdBox";
            this.TextTerminalCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTerminalCmdBox.Size = new System.Drawing.Size(394, 307);
            this.TextTerminalCmdBox.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 66);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 15);
            this.label17.TabIndex = 37;
            this.label17.Text = "TextTerminal URI";
            // 
            // TextTerminalURI
            // 
            this.TextTerminalURI.Location = new System.Drawing.Point(101, 64);
            this.TextTerminalURI.Margin = new System.Windows.Forms.Padding(0);
            this.TextTerminalURI.Name = "TextTerminalURI";
            this.TextTerminalURI.ReadOnly = true;
            this.TextTerminalURI.Size = new System.Drawing.Size(464, 23);
            this.TextTerminalURI.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 41);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 15);
            this.label18.TabIndex = 39;
            this.label18.Text = "Port Number";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 15);
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
            this.EncryptorTab.Location = new System.Drawing.Point(4, 24);
            this.EncryptorTab.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorTab.Name = "EncryptorTab";
            this.EncryptorTab.Size = new System.Drawing.Size(1177, 515);
            this.EncryptorTab.TabIndex = 3;
            this.EncryptorTab.Text = "Encryptor";
            this.EncryptorTab.UseVisualStyleBackColor = true;
            // 
            // EncryptorDeleteKey
            // 
            this.EncryptorDeleteKey.Location = new System.Drawing.Point(1061, 41);
            this.EncryptorDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorDeleteKey.Name = "EncryptorDeleteKey";
            this.EncryptorDeleteKey.Size = new System.Drawing.Size(85, 21);
            this.EncryptorDeleteKey.TabIndex = 59;
            this.EncryptorDeleteKey.Text = "DeleteKey";
            this.EncryptorDeleteKey.UseVisualStyleBackColor = true;
            this.EncryptorDeleteKey.Click += new System.EventHandler(this.EncryptorDeleteKey_Click);
            // 
            // EncryptorGenerateMAC
            // 
            this.EncryptorGenerateMAC.Location = new System.Drawing.Point(959, 108);
            this.EncryptorGenerateMAC.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGenerateMAC.Name = "EncryptorGenerateMAC";
            this.EncryptorGenerateMAC.Size = new System.Drawing.Size(93, 26);
            this.EncryptorGenerateMAC.TabIndex = 58;
            this.EncryptorGenerateMAC.Text = "GenerateMAC";
            this.EncryptorGenerateMAC.UseVisualStyleBackColor = true;
            this.EncryptorGenerateMAC.Click += new System.EventHandler(this.EncryptorGenerateMAC_Click);
            // 
            // EncryptorEncrypt
            // 
            this.EncryptorEncrypt.Location = new System.Drawing.Point(959, 74);
            this.EncryptorEncrypt.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorEncrypt.Name = "EncryptorEncrypt";
            this.EncryptorEncrypt.Size = new System.Drawing.Size(93, 22);
            this.EncryptorEncrypt.TabIndex = 57;
            this.EncryptorEncrypt.Text = "Encrypt";
            this.EncryptorEncrypt.UseVisualStyleBackColor = true;
            this.EncryptorEncrypt.Click += new System.EventHandler(this.EncryptorEncrypt_Click);
            // 
            // EncryptorGenerateRandom
            // 
            this.EncryptorGenerateRandom.Location = new System.Drawing.Point(959, 144);
            this.EncryptorGenerateRandom.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGenerateRandom.Name = "EncryptorGenerateRandom";
            this.EncryptorGenerateRandom.Size = new System.Drawing.Size(114, 24);
            this.EncryptorGenerateRandom.TabIndex = 56;
            this.EncryptorGenerateRandom.Text = "GenerateRandom";
            this.EncryptorGenerateRandom.UseVisualStyleBackColor = true;
            this.EncryptorGenerateRandom.Click += new System.EventHandler(this.EncryptorGenerateRandom_Click);
            // 
            // EncryptorReset
            // 
            this.EncryptorReset.Location = new System.Drawing.Point(1061, 10);
            this.EncryptorReset.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorReset.Name = "EncryptorReset";
            this.EncryptorReset.Size = new System.Drawing.Size(85, 22);
            this.EncryptorReset.TabIndex = 55;
            this.EncryptorReset.Text = "Reset";
            this.EncryptorReset.UseVisualStyleBackColor = true;
            this.EncryptorReset.Click += new System.EventHandler(this.EncryptorReset_Click);
            // 
            // EncryptorImportKey
            // 
            this.EncryptorImportKey.Location = new System.Drawing.Point(959, 41);
            this.EncryptorImportKey.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorImportKey.Name = "EncryptorImportKey";
            this.EncryptorImportKey.Size = new System.Drawing.Size(92, 21);
            this.EncryptorImportKey.TabIndex = 54;
            this.EncryptorImportKey.Text = "ImportKey";
            this.EncryptorImportKey.UseVisualStyleBackColor = true;
            this.EncryptorImportKey.Click += new System.EventHandler(this.EncryptorImportKey_Click);
            // 
            // EncryptorInitialization
            // 
            this.EncryptorInitialization.Location = new System.Drawing.Point(959, 10);
            this.EncryptorInitialization.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorInitialization.Name = "EncryptorInitialization";
            this.EncryptorInitialization.Size = new System.Drawing.Size(92, 22);
            this.EncryptorInitialization.TabIndex = 53;
            this.EncryptorInitialization.Text = "Initialization";
            this.EncryptorInitialization.UseVisualStyleBackColor = true;
            this.EncryptorInitialization.Click += new System.EventHandler(this.EncryptorInitialization_Click);
            // 
            // EncryptorGetKeyNames
            // 
            this.EncryptorGetKeyNames.Location = new System.Drawing.Point(814, 110);
            this.EncryptorGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorGetKeyNames.Name = "EncryptorGetKeyNames";
            this.EncryptorGetKeyNames.Size = new System.Drawing.Size(90, 23);
            this.EncryptorGetKeyNames.TabIndex = 52;
            this.EncryptorGetKeyNames.Text = "GetKeyNames";
            this.EncryptorGetKeyNames.UseVisualStyleBackColor = true;
            this.EncryptorGetKeyNames.Click += new System.EventHandler(this.EncryptorGetKeyNames_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(592, 89);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 15);
            this.label25.TabIndex = 51;
            this.label25.Text = "Key Names";
            // 
            // EncryptorKeyNamelistBox
            // 
            this.EncryptorKeyNamelistBox.FormattingEnabled = true;
            this.EncryptorKeyNamelistBox.ItemHeight = 15;
            this.EncryptorKeyNamelistBox.Location = new System.Drawing.Point(592, 110);
            this.EncryptorKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorKeyNamelistBox.Name = "EncryptorKeyNamelistBox";
            this.EncryptorKeyNamelistBox.Size = new System.Drawing.Size(214, 79);
            this.EncryptorKeyNamelistBox.TabIndex = 50;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(592, 47);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(96, 15);
            this.label23.TabIndex = 49;
            this.label23.Text = "Max key number";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(611, 14);
            this.label24.Margin = new System.Windows.Forms.Padding(0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 15);
            this.label24.TabIndex = 48;
            this.label24.Text = "Device status";
            // 
            // EncryptorEvtBox
            // 
            this.EncryptorEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorEvtBox.Location = new System.Drawing.Point(814, 202);
            this.EncryptorEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorEvtBox.MaxLength = 1048576;
            this.EncryptorEvtBox.Multiline = true;
            this.EncryptorEvtBox.Name = "EncryptorEvtBox";
            this.EncryptorEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorEvtBox.Size = new System.Drawing.Size(355, 307);
            this.EncryptorEvtBox.TabIndex = 46;
            // 
            // EncryptorRspBox
            // 
            this.EncryptorRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorRspBox.Location = new System.Drawing.Point(425, 202);
            this.EncryptorRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorRspBox.MaxLength = 1048576;
            this.EncryptorRspBox.Multiline = true;
            this.EncryptorRspBox.Name = "EncryptorRspBox";
            this.EncryptorRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorRspBox.Size = new System.Drawing.Size(371, 307);
            this.EncryptorRspBox.TabIndex = 45;
            // 
            // EncryptorCmdBox
            // 
            this.EncryptorCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EncryptorCmdBox.Location = new System.Drawing.Point(14, 202);
            this.EncryptorCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorCmdBox.MaxLength = 1048576;
            this.EncryptorCmdBox.Multiline = true;
            this.EncryptorCmdBox.Name = "EncryptorCmdBox";
            this.EncryptorCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EncryptorCmdBox.Size = new System.Drawing.Size(394, 307);
            this.EncryptorCmdBox.TabIndex = 44;
            // 
            // EncryptorMaxKeyNum
            // 
            this.EncryptorMaxKeyNum.Location = new System.Drawing.Point(696, 45);
            this.EncryptorMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorMaxKeyNum.Name = "EncryptorMaxKeyNum";
            this.EncryptorMaxKeyNum.ReadOnly = true;
            this.EncryptorMaxKeyNum.Size = new System.Drawing.Size(106, 23);
            this.EncryptorMaxKeyNum.TabIndex = 43;
            // 
            // EncryptorStDevice
            // 
            this.EncryptorStDevice.Location = new System.Drawing.Point(696, 14);
            this.EncryptorStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorStDevice.Name = "EncryptorStDevice";
            this.EncryptorStDevice.ReadOnly = true;
            this.EncryptorStDevice.Size = new System.Drawing.Size(106, 23);
            this.EncryptorStDevice.TabIndex = 42;
            // 
            // EncryptorCapabilities
            // 
            this.EncryptorCapabilities.Location = new System.Drawing.Point(814, 38);
            this.EncryptorCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorCapabilities.Name = "EncryptorCapabilities";
            this.EncryptorCapabilities.Size = new System.Drawing.Size(90, 22);
            this.EncryptorCapabilities.TabIndex = 41;
            this.EncryptorCapabilities.Text = "Capabilities";
            this.EncryptorCapabilities.UseVisualStyleBackColor = true;
            this.EncryptorCapabilities.Click += new System.EventHandler(this.EncryptorCapabilities_Click);
            // 
            // EncryptorStatus
            // 
            this.EncryptorStatus.Location = new System.Drawing.Point(814, 10);
            this.EncryptorStatus.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorStatus.Name = "EncryptorStatus";
            this.EncryptorStatus.Size = new System.Drawing.Size(90, 22);
            this.EncryptorStatus.TabIndex = 40;
            this.EncryptorStatus.Text = "Status";
            this.EncryptorStatus.UseVisualStyleBackColor = true;
            this.EncryptorStatus.Click += new System.EventHandler(this.EncryptorStatus_Click);
            // 
            // EncryptorServiceURI
            // 
            this.EncryptorServiceURI.Location = new System.Drawing.Point(102, 12);
            this.EncryptorServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorServiceURI.Name = "EncryptorServiceURI";
            this.EncryptorServiceURI.Size = new System.Drawing.Size(464, 23);
            this.EncryptorServiceURI.TabIndex = 38;
            // 
            // EncryptorServiceDiscovery
            // 
            this.EncryptorServiceDiscovery.Location = new System.Drawing.Point(441, 95);
            this.EncryptorServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorServiceDiscovery.Name = "EncryptorServiceDiscovery";
            this.EncryptorServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.EncryptorServiceDiscovery.TabIndex = 33;
            this.EncryptorServiceDiscovery.Text = "Service Discovery";
            this.EncryptorServiceDiscovery.UseVisualStyleBackColor = true;
            this.EncryptorServiceDiscovery.Click += new System.EventHandler(this.EncryptorServiceDiscovery_Click);
            // 
            // EncryptorPortNum
            // 
            this.EncryptorPortNum.Location = new System.Drawing.Point(102, 37);
            this.EncryptorPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorPortNum.Name = "EncryptorPortNum";
            this.EncryptorPortNum.ReadOnly = true;
            this.EncryptorPortNum.Size = new System.Drawing.Size(106, 23);
            this.EncryptorPortNum.TabIndex = 34;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 61);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 15);
            this.label20.TabIndex = 35;
            this.label20.Text = "Encryptor URI";
            // 
            // EncryptorURI
            // 
            this.EncryptorURI.Location = new System.Drawing.Point(102, 59);
            this.EncryptorURI.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptorURI.Name = "EncryptorURI";
            this.EncryptorURI.ReadOnly = true;
            this.EncryptorURI.Size = new System.Drawing.Size(464, 23);
            this.EncryptorURI.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 37);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 15);
            this.label21.TabIndex = 37;
            this.label21.Text = "Port Number";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 12);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 15);
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
            this.PinPadTab.Location = new System.Drawing.Point(4, 24);
            this.PinPadTab.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadTab.Name = "PinPadTab";
            this.PinPadTab.Size = new System.Drawing.Size(1177, 515);
            this.PinPadTab.TabIndex = 4;
            this.PinPadTab.Text = "PinPad";
            this.PinPadTab.UseVisualStyleBackColor = true;
            // 
            // PinPadGetLayout
            // 
            this.PinPadGetLayout.Location = new System.Drawing.Point(816, 143);
            this.PinPadGetLayout.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadGetLayout.Name = "PinPadGetLayout";
            this.PinPadGetLayout.Size = new System.Drawing.Size(90, 23);
            this.PinPadGetLayout.TabIndex = 92;
            this.PinPadGetLayout.Text = "Get Layout";
            this.PinPadGetLayout.UseVisualStyleBackColor = true;
            this.PinPadGetLayout.Click += new System.EventHandler(this.PinPadGetLayout_Click);
            // 
            // PinPadEnterData
            // 
            this.PinPadEnterData.Location = new System.Drawing.Point(1015, 39);
            this.PinPadEnterData.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEnterData.Name = "PinPadEnterData";
            this.PinPadEnterData.Size = new System.Drawing.Size(85, 21);
            this.PinPadEnterData.TabIndex = 91;
            this.PinPadEnterData.Text = "Enter Data";
            this.PinPadEnterData.UseVisualStyleBackColor = true;
            this.PinPadEnterData.Click += new System.EventHandler(this.PinPadEnterData_Click);
            // 
            // PinPadFormatPin
            // 
            this.PinPadFormatPin.Location = new System.Drawing.Point(1097, 166);
            this.PinPadFormatPin.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadFormatPin.Name = "PinPadFormatPin";
            this.PinPadFormatPin.Size = new System.Drawing.Size(77, 21);
            this.PinPadFormatPin.TabIndex = 90;
            this.PinPadFormatPin.Text = "Format PIN";
            this.PinPadFormatPin.UseVisualStyleBackColor = true;
            this.PinPadFormatPin.Click += new System.EventHandler(this.PinPadFormatPin_Click);
            // 
            // PinPadEnterPin
            // 
            this.PinPadEnterPin.Location = new System.Drawing.Point(1013, 166);
            this.PinPadEnterPin.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEnterPin.Name = "PinPadEnterPin";
            this.PinPadEnterPin.Size = new System.Drawing.Size(77, 21);
            this.PinPadEnterPin.TabIndex = 89;
            this.PinPadEnterPin.Text = "Enter PIN";
            this.PinPadEnterPin.UseVisualStyleBackColor = true;
            this.PinPadEnterPin.Click += new System.EventHandler(this.PinPadEnterPin_Click);
            // 
            // PinPadLoadPinKey
            // 
            this.PinPadLoadPinKey.Location = new System.Drawing.Point(913, 166);
            this.PinPadLoadPinKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadLoadPinKey.Name = "PinPadLoadPinKey";
            this.PinPadLoadPinKey.Size = new System.Drawing.Size(93, 21);
            this.PinPadLoadPinKey.TabIndex = 88;
            this.PinPadLoadPinKey.Text = "Load PIN Key";
            this.PinPadLoadPinKey.UseVisualStyleBackColor = true;
            this.PinPadLoadPinKey.Click += new System.EventHandler(this.PinPadLoadPinKey_Click);
            // 
            // PinPadSecureKeyEntryPart2
            // 
            this.PinPadSecureKeyEntryPart2.Location = new System.Drawing.Point(914, 102);
            this.PinPadSecureKeyEntryPart2.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadSecureKeyEntryPart2.Name = "PinPadSecureKeyEntryPart2";
            this.PinPadSecureKeyEntryPart2.Size = new System.Drawing.Size(147, 21);
            this.PinPadSecureKeyEntryPart2.TabIndex = 87;
            this.PinPadSecureKeyEntryPart2.Text = "SecureKeyEntry Part2";
            this.PinPadSecureKeyEntryPart2.UseVisualStyleBackColor = true;
            this.PinPadSecureKeyEntryPart2.Click += new System.EventHandler(this.PinPadSecureKeyEntryPart2_Click);
            // 
            // PinPadSecureKeyEntryPart1
            // 
            this.PinPadSecureKeyEntryPart1.Location = new System.Drawing.Point(914, 75);
            this.PinPadSecureKeyEntryPart1.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadSecureKeyEntryPart1.Name = "PinPadSecureKeyEntryPart1";
            this.PinPadSecureKeyEntryPart1.Size = new System.Drawing.Size(147, 21);
            this.PinPadSecureKeyEntryPart1.TabIndex = 86;
            this.PinPadSecureKeyEntryPart1.Text = "SecureKeyEntry Part1";
            this.PinPadSecureKeyEntryPart1.UseVisualStyleBackColor = true;
            this.PinPadSecureKeyEntryPart1.Click += new System.EventHandler(this.PinPadSecureKeyEntryPart1_Click);
            // 
            // PinPadDeleteKey
            // 
            this.PinPadDeleteKey.Location = new System.Drawing.Point(914, 39);
            this.PinPadDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadDeleteKey.Name = "PinPadDeleteKey";
            this.PinPadDeleteKey.Size = new System.Drawing.Size(93, 21);
            this.PinPadDeleteKey.TabIndex = 85;
            this.PinPadDeleteKey.Text = "DeleteKey";
            this.PinPadDeleteKey.UseVisualStyleBackColor = true;
            this.PinPadDeleteKey.Click += new System.EventHandler(this.PinPadDeleteKey_Click);
            // 
            // PinPadReset
            // 
            this.PinPadReset.Location = new System.Drawing.Point(1015, 10);
            this.PinPadReset.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadReset.Name = "PinPadReset";
            this.PinPadReset.Size = new System.Drawing.Size(85, 22);
            this.PinPadReset.TabIndex = 81;
            this.PinPadReset.Text = "Reset";
            this.PinPadReset.UseVisualStyleBackColor = true;
            this.PinPadReset.Click += new System.EventHandler(this.PinPadReset_Click);
            // 
            // PinPadImportKey
            // 
            this.PinPadImportKey.Location = new System.Drawing.Point(914, 130);
            this.PinPadImportKey.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadImportKey.Name = "PinPadImportKey";
            this.PinPadImportKey.Size = new System.Drawing.Size(147, 21);
            this.PinPadImportKey.TabIndex = 80;
            this.PinPadImportKey.Text = "ImportKey (Secure)";
            this.PinPadImportKey.UseVisualStyleBackColor = true;
            this.PinPadImportKey.Click += new System.EventHandler(this.PinPadImportKey_Click);
            // 
            // PinPadInitialization
            // 
            this.PinPadInitialization.Location = new System.Drawing.Point(914, 11);
            this.PinPadInitialization.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadInitialization.Name = "PinPadInitialization";
            this.PinPadInitialization.Size = new System.Drawing.Size(92, 22);
            this.PinPadInitialization.TabIndex = 79;
            this.PinPadInitialization.Text = "Initialization";
            this.PinPadInitialization.UseVisualStyleBackColor = true;
            this.PinPadInitialization.Click += new System.EventHandler(this.PinPadInitialization_Click);
            // 
            // PinPadGetKeyNames
            // 
            this.PinPadGetKeyNames.Location = new System.Drawing.Point(816, 111);
            this.PinPadGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadGetKeyNames.Name = "PinPadGetKeyNames";
            this.PinPadGetKeyNames.Size = new System.Drawing.Size(90, 23);
            this.PinPadGetKeyNames.TabIndex = 78;
            this.PinPadGetKeyNames.Text = "GetKeyNames";
            this.PinPadGetKeyNames.UseVisualStyleBackColor = true;
            this.PinPadGetKeyNames.Click += new System.EventHandler(this.PinPadGetKeyNames_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(594, 90);
            this.label26.Margin = new System.Windows.Forms.Padding(0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 15);
            this.label26.TabIndex = 77;
            this.label26.Text = "Key Names";
            // 
            // PinPadKeyNamelistBox
            // 
            this.PinPadKeyNamelistBox.FormattingEnabled = true;
            this.PinPadKeyNamelistBox.ItemHeight = 15;
            this.PinPadKeyNamelistBox.Location = new System.Drawing.Point(594, 111);
            this.PinPadKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadKeyNamelistBox.Name = "PinPadKeyNamelistBox";
            this.PinPadKeyNamelistBox.Size = new System.Drawing.Size(214, 79);
            this.PinPadKeyNamelistBox.TabIndex = 76;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(594, 48);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 15);
            this.label27.TabIndex = 75;
            this.label27.Text = "Max key number";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(614, 15);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(76, 15);
            this.label28.TabIndex = 74;
            this.label28.Text = "Device status";
            // 
            // PinPadEvtBox
            // 
            this.PinPadEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadEvtBox.Location = new System.Drawing.Point(816, 203);
            this.PinPadEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadEvtBox.MaxLength = 1048576;
            this.PinPadEvtBox.Multiline = true;
            this.PinPadEvtBox.Name = "PinPadEvtBox";
            this.PinPadEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadEvtBox.Size = new System.Drawing.Size(355, 307);
            this.PinPadEvtBox.TabIndex = 73;
            // 
            // PinPadRspBox
            // 
            this.PinPadRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadRspBox.Location = new System.Drawing.Point(427, 203);
            this.PinPadRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadRspBox.MaxLength = 1048576;
            this.PinPadRspBox.Multiline = true;
            this.PinPadRspBox.Name = "PinPadRspBox";
            this.PinPadRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadRspBox.Size = new System.Drawing.Size(371, 307);
            this.PinPadRspBox.TabIndex = 72;
            // 
            // PinPadCmdBox
            // 
            this.PinPadCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PinPadCmdBox.Location = new System.Drawing.Point(16, 203);
            this.PinPadCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadCmdBox.MaxLength = 1048576;
            this.PinPadCmdBox.Multiline = true;
            this.PinPadCmdBox.Name = "PinPadCmdBox";
            this.PinPadCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PinPadCmdBox.Size = new System.Drawing.Size(394, 307);
            this.PinPadCmdBox.TabIndex = 71;
            // 
            // PinPadMaxKeyNum
            // 
            this.PinPadMaxKeyNum.Location = new System.Drawing.Point(698, 46);
            this.PinPadMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadMaxKeyNum.Name = "PinPadMaxKeyNum";
            this.PinPadMaxKeyNum.ReadOnly = true;
            this.PinPadMaxKeyNum.Size = new System.Drawing.Size(106, 23);
            this.PinPadMaxKeyNum.TabIndex = 70;
            // 
            // PinPadStDevice
            // 
            this.PinPadStDevice.Location = new System.Drawing.Point(698, 15);
            this.PinPadStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadStDevice.Name = "PinPadStDevice";
            this.PinPadStDevice.ReadOnly = true;
            this.PinPadStDevice.Size = new System.Drawing.Size(106, 23);
            this.PinPadStDevice.TabIndex = 69;
            // 
            // PinPadCapabilities
            // 
            this.PinPadCapabilities.Location = new System.Drawing.Point(816, 38);
            this.PinPadCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadCapabilities.Name = "PinPadCapabilities";
            this.PinPadCapabilities.Size = new System.Drawing.Size(90, 22);
            this.PinPadCapabilities.TabIndex = 68;
            this.PinPadCapabilities.Text = "Capabilities";
            this.PinPadCapabilities.UseVisualStyleBackColor = true;
            this.PinPadCapabilities.Click += new System.EventHandler(this.PinPadCapabilities_Click);
            // 
            // PinPadStatus
            // 
            this.PinPadStatus.Location = new System.Drawing.Point(816, 11);
            this.PinPadStatus.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadStatus.Name = "PinPadStatus";
            this.PinPadStatus.Size = new System.Drawing.Size(90, 22);
            this.PinPadStatus.TabIndex = 67;
            this.PinPadStatus.Text = "Status";
            this.PinPadStatus.UseVisualStyleBackColor = true;
            this.PinPadStatus.Click += new System.EventHandler(this.PinPadStatus_Click);
            // 
            // PinPadServiceURI
            // 
            this.PinPadServiceURI.Location = new System.Drawing.Point(104, 13);
            this.PinPadServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadServiceURI.Name = "PinPadServiceURI";
            this.PinPadServiceURI.Size = new System.Drawing.Size(464, 23);
            this.PinPadServiceURI.TabIndex = 65;
            // 
            // PinPadServiceDiscovery
            // 
            this.PinPadServiceDiscovery.Location = new System.Drawing.Point(443, 96);
            this.PinPadServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadServiceDiscovery.Name = "PinPadServiceDiscovery";
            this.PinPadServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.PinPadServiceDiscovery.TabIndex = 60;
            this.PinPadServiceDiscovery.Text = "Service Discovery";
            this.PinPadServiceDiscovery.UseVisualStyleBackColor = true;
            this.PinPadServiceDiscovery.Click += new System.EventHandler(this.PinPadServiceDiscovery_Click);
            // 
            // PinPadPortNum
            // 
            this.PinPadPortNum.Location = new System.Drawing.Point(104, 37);
            this.PinPadPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadPortNum.Name = "PinPadPortNum";
            this.PinPadPortNum.ReadOnly = true;
            this.PinPadPortNum.Size = new System.Drawing.Size(106, 23);
            this.PinPadPortNum.TabIndex = 61;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 62);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 15);
            this.label29.TabIndex = 62;
            this.label29.Text = "Encryptor URI";
            // 
            // PinPadURI
            // 
            this.PinPadURI.Location = new System.Drawing.Point(104, 60);
            this.PinPadURI.Margin = new System.Windows.Forms.Padding(0);
            this.PinPadURI.Name = "PinPadURI";
            this.PinPadURI.ReadOnly = true;
            this.PinPadURI.Size = new System.Drawing.Size(464, 23);
            this.PinPadURI.TabIndex = 63;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(10, 37);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(76, 15);
            this.label30.TabIndex = 64;
            this.label30.Text = "Port Number";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(10, 13);
            this.label31.Margin = new System.Windows.Forms.Padding(0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 15);
            this.label31.TabIndex = 66;
            this.label31.Text = "Service URI";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label39);
            this.tabPage1.Controls.Add(this.PrinterFormFields);
            this.tabPage1.Controls.Add(this.PrinterLoadDefinition);
            this.tabPage1.Controls.Add(this.PrinterMediaListBox);
            this.tabPage1.Controls.Add(this.PrinterQueryForm);
            this.tabPage1.Controls.Add(this.PrinterEject);
            this.tabPage1.Controls.Add(this.PrinterQueryMedia);
            this.tabPage1.Controls.Add(this.PrinterGetMediaList);
            this.tabPage1.Controls.Add(this.PrinterPrintForm);
            this.tabPage1.Controls.Add(this.PrinterReset);
            this.tabPage1.Controls.Add(this.PrinterPrintRaw);
            this.tabPage1.Controls.Add(this.PrinterGetFormList);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.PrinterFormListBox);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.PrinterEvtBox);
            this.tabPage1.Controls.Add(this.PrinterRspBox);
            this.tabPage1.Controls.Add(this.PrinterCmdBox);
            this.tabPage1.Controls.Add(this.PrinterType);
            this.tabPage1.Controls.Add(this.PrinterStDevice);
            this.tabPage1.Controls.Add(this.PrinterCapabilities);
            this.tabPage1.Controls.Add(this.PrinterStatus);
            this.tabPage1.Controls.Add(this.PrinterServiceURI);
            this.tabPage1.Controls.Add(this.PrinterServiceDiscovery);
            this.tabPage1.Controls.Add(this.PrinterPortNum);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.PrinterURI);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1177, 515);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Printer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(14, 142);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(71, 15);
            this.label39.TabIndex = 127;
            this.label39.Text = "Form Fields:";
            // 
            // PrinterFormFields
            // 
            this.PrinterFormFields.Location = new System.Drawing.Point(14, 169);
            this.PrinterFormFields.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterFormFields.Name = "PrinterFormFields";
            this.PrinterFormFields.Size = new System.Drawing.Size(552, 23);
            this.PrinterFormFields.TabIndex = 126;
            this.PrinterFormFields.Text = "Field1=Value1,Field2=Field Value2";
            // 
            // PrinterLoadDefinition
            // 
            this.PrinterLoadDefinition.Location = new System.Drawing.Point(954, 36);
            this.PrinterLoadDefinition.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterLoadDefinition.Name = "PrinterLoadDefinition";
            this.PrinterLoadDefinition.Size = new System.Drawing.Size(99, 22);
            this.PrinterLoadDefinition.TabIndex = 124;
            this.PrinterLoadDefinition.Text = "LoadDefinition";
            this.PrinterLoadDefinition.UseVisualStyleBackColor = true;
            this.PrinterLoadDefinition.Click += new System.EventHandler(this.PrinterLoadDefinition_Click);
            // 
            // PrinterMediaListBox
            // 
            this.PrinterMediaListBox.FormattingEnabled = true;
            this.PrinterMediaListBox.ItemHeight = 15;
            this.PrinterMediaListBox.Location = new System.Drawing.Point(894, 102);
            this.PrinterMediaListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrinterMediaListBox.Name = "PrinterMediaListBox";
            this.PrinterMediaListBox.Size = new System.Drawing.Size(159, 94);
            this.PrinterMediaListBox.TabIndex = 123;
            // 
            // PrinterQueryForm
            // 
            this.PrinterQueryForm.Location = new System.Drawing.Point(794, 133);
            this.PrinterQueryForm.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterQueryForm.Name = "PrinterQueryForm";
            this.PrinterQueryForm.Size = new System.Drawing.Size(90, 23);
            this.PrinterQueryForm.TabIndex = 122;
            this.PrinterQueryForm.Text = "QueryForm";
            this.PrinterQueryForm.UseVisualStyleBackColor = true;
            this.PrinterQueryForm.Click += new System.EventHandler(this.PrinterQueryForm_Click);
            // 
            // PrinterEject
            // 
            this.PrinterEject.Location = new System.Drawing.Point(1061, 36);
            this.PrinterEject.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterEject.Name = "PrinterEject";
            this.PrinterEject.Size = new System.Drawing.Size(93, 21);
            this.PrinterEject.TabIndex = 121;
            this.PrinterEject.Text = "Eject";
            this.PrinterEject.UseVisualStyleBackColor = true;
            this.PrinterEject.Click += new System.EventHandler(this.PrinterEject_Click);
            // 
            // PrinterQueryMedia
            // 
            this.PrinterQueryMedia.Location = new System.Drawing.Point(1064, 133);
            this.PrinterQueryMedia.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterQueryMedia.Name = "PrinterQueryMedia";
            this.PrinterQueryMedia.Size = new System.Drawing.Size(93, 21);
            this.PrinterQueryMedia.TabIndex = 119;
            this.PrinterQueryMedia.Text = "QueryMedia";
            this.PrinterQueryMedia.UseVisualStyleBackColor = true;
            this.PrinterQueryMedia.Click += new System.EventHandler(this.PrinterQueryMedia_Click);
            // 
            // PrinterGetMediaList
            // 
            this.PrinterGetMediaList.Location = new System.Drawing.Point(1064, 102);
            this.PrinterGetMediaList.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterGetMediaList.Name = "PrinterGetMediaList";
            this.PrinterGetMediaList.Size = new System.Drawing.Size(93, 21);
            this.PrinterGetMediaList.TabIndex = 118;
            this.PrinterGetMediaList.Text = "GetMediaList";
            this.PrinterGetMediaList.UseVisualStyleBackColor = true;
            this.PrinterGetMediaList.Click += new System.EventHandler(this.PrinterGetMediaList_Click);
            // 
            // PrinterPrintForm
            // 
            this.PrinterPrintForm.Location = new System.Drawing.Point(14, 120);
            this.PrinterPrintForm.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPrintForm.Name = "PrinterPrintForm";
            this.PrinterPrintForm.Size = new System.Drawing.Size(105, 21);
            this.PrinterPrintForm.TabIndex = 115;
            this.PrinterPrintForm.Text = "PrintForm";
            this.PrinterPrintForm.UseVisualStyleBackColor = true;
            this.PrinterPrintForm.Click += new System.EventHandler(this.PrinterPrintForm_Click);
            // 
            // PrinterReset
            // 
            this.PrinterReset.Location = new System.Drawing.Point(1061, 9);
            this.PrinterReset.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterReset.Name = "PrinterReset";
            this.PrinterReset.Size = new System.Drawing.Size(93, 22);
            this.PrinterReset.TabIndex = 114;
            this.PrinterReset.Text = "Reset";
            this.PrinterReset.UseVisualStyleBackColor = true;
            this.PrinterReset.Click += new System.EventHandler(this.PrinterReset_Click);
            // 
            // PrinterPrintRaw
            // 
            this.PrinterPrintRaw.Location = new System.Drawing.Point(954, 11);
            this.PrinterPrintRaw.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPrintRaw.Name = "PrinterPrintRaw";
            this.PrinterPrintRaw.Size = new System.Drawing.Size(99, 22);
            this.PrinterPrintRaw.TabIndex = 112;
            this.PrinterPrintRaw.Text = "PrintRaw";
            this.PrinterPrintRaw.UseVisualStyleBackColor = true;
            this.PrinterPrintRaw.Click += new System.EventHandler(this.PrinterPrintRaw_Click);
            // 
            // PrinterGetFormList
            // 
            this.PrinterGetFormList.Location = new System.Drawing.Point(794, 101);
            this.PrinterGetFormList.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterGetFormList.Name = "PrinterGetFormList";
            this.PrinterGetFormList.Size = new System.Drawing.Size(90, 23);
            this.PrinterGetFormList.TabIndex = 111;
            this.PrinterGetFormList.Text = "GetFormList";
            this.PrinterGetFormList.UseVisualStyleBackColor = true;
            this.PrinterGetFormList.Click += new System.EventHandler(this.PrinterGetFormList_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(592, 80);
            this.label33.Margin = new System.Windows.Forms.Padding(0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 15);
            this.label33.TabIndex = 110;
            this.label33.Text = "Form Names";
            // 
            // PrinterFormListBox
            // 
            this.PrinterFormListBox.FormattingEnabled = true;
            this.PrinterFormListBox.ItemHeight = 15;
            this.PrinterFormListBox.Location = new System.Drawing.Point(592, 101);
            this.PrinterFormListBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterFormListBox.Name = "PrinterFormListBox";
            this.PrinterFormListBox.Size = new System.Drawing.Size(190, 94);
            this.PrinterFormListBox.TabIndex = 109;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(592, 47);
            this.label34.Margin = new System.Windows.Forms.Padding(0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 15);
            this.label34.TabIndex = 108;
            this.label34.Text = "Printer Type";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(592, 12);
            this.label35.Margin = new System.Windows.Forms.Padding(0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(76, 15);
            this.label35.TabIndex = 107;
            this.label35.Text = "Device status";
            // 
            // PrinterEvtBox
            // 
            this.PrinterEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterEvtBox.Location = new System.Drawing.Point(815, 202);
            this.PrinterEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterEvtBox.MaxLength = 1048576;
            this.PrinterEvtBox.Multiline = true;
            this.PrinterEvtBox.Name = "PrinterEvtBox";
            this.PrinterEvtBox.ReadOnly = true;
            this.PrinterEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterEvtBox.Size = new System.Drawing.Size(355, 307);
            this.PrinterEvtBox.TabIndex = 106;
            // 
            // PrinterRspBox
            // 
            this.PrinterRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterRspBox.Location = new System.Drawing.Point(425, 202);
            this.PrinterRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterRspBox.MaxLength = 1048576;
            this.PrinterRspBox.Multiline = true;
            this.PrinterRspBox.Name = "PrinterRspBox";
            this.PrinterRspBox.ReadOnly = true;
            this.PrinterRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterRspBox.Size = new System.Drawing.Size(371, 307);
            this.PrinterRspBox.TabIndex = 105;
            // 
            // PrinterCmdBox
            // 
            this.PrinterCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrinterCmdBox.Location = new System.Drawing.Point(14, 202);
            this.PrinterCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterCmdBox.MaxLength = 1048576;
            this.PrinterCmdBox.Multiline = true;
            this.PrinterCmdBox.Name = "PrinterCmdBox";
            this.PrinterCmdBox.ReadOnly = true;
            this.PrinterCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinterCmdBox.Size = new System.Drawing.Size(394, 307);
            this.PrinterCmdBox.TabIndex = 104;
            // 
            // PrinterType
            // 
            this.PrinterType.Location = new System.Drawing.Point(676, 45);
            this.PrinterType.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterType.Name = "PrinterType";
            this.PrinterType.ReadOnly = true;
            this.PrinterType.Size = new System.Drawing.Size(106, 23);
            this.PrinterType.TabIndex = 103;
            // 
            // PrinterStDevice
            // 
            this.PrinterStDevice.Location = new System.Drawing.Point(676, 12);
            this.PrinterStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterStDevice.Name = "PrinterStDevice";
            this.PrinterStDevice.ReadOnly = true;
            this.PrinterStDevice.Size = new System.Drawing.Size(106, 23);
            this.PrinterStDevice.TabIndex = 102;
            // 
            // PrinterCapabilities
            // 
            this.PrinterCapabilities.Location = new System.Drawing.Point(815, 38);
            this.PrinterCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterCapabilities.Name = "PrinterCapabilities";
            this.PrinterCapabilities.Size = new System.Drawing.Size(90, 22);
            this.PrinterCapabilities.TabIndex = 101;
            this.PrinterCapabilities.Text = "Capabilities";
            this.PrinterCapabilities.UseVisualStyleBackColor = true;
            this.PrinterCapabilities.Click += new System.EventHandler(this.PrinterCapabilities_Click);
            // 
            // PrinterStatus
            // 
            this.PrinterStatus.Location = new System.Drawing.Point(815, 10);
            this.PrinterStatus.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterStatus.Name = "PrinterStatus";
            this.PrinterStatus.Size = new System.Drawing.Size(90, 22);
            this.PrinterStatus.TabIndex = 100;
            this.PrinterStatus.Text = "Status";
            this.PrinterStatus.UseVisualStyleBackColor = true;
            this.PrinterStatus.Click += new System.EventHandler(this.PrinterStatus_Click);
            // 
            // PrinterServiceURI
            // 
            this.PrinterServiceURI.Location = new System.Drawing.Point(102, 12);
            this.PrinterServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterServiceURI.Name = "PrinterServiceURI";
            this.PrinterServiceURI.Size = new System.Drawing.Size(464, 23);
            this.PrinterServiceURI.TabIndex = 98;
            // 
            // PrinterServiceDiscovery
            // 
            this.PrinterServiceDiscovery.Location = new System.Drawing.Point(441, 95);
            this.PrinterServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterServiceDiscovery.Name = "PrinterServiceDiscovery";
            this.PrinterServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.PrinterServiceDiscovery.TabIndex = 93;
            this.PrinterServiceDiscovery.Text = "Service Discovery";
            this.PrinterServiceDiscovery.UseVisualStyleBackColor = true;
            this.PrinterServiceDiscovery.Click += new System.EventHandler(this.PrinterServiceDiscovery_Click);
            // 
            // PrinterPortNum
            // 
            this.PrinterPortNum.Location = new System.Drawing.Point(102, 36);
            this.PrinterPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterPortNum.Name = "PrinterPortNum";
            this.PrinterPortNum.ReadOnly = true;
            this.PrinterPortNum.Size = new System.Drawing.Size(106, 23);
            this.PrinterPortNum.TabIndex = 94;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 62);
            this.label36.Margin = new System.Windows.Forms.Padding(0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 15);
            this.label36.TabIndex = 95;
            this.label36.Text = "Printer URI";
            // 
            // PrinterURI
            // 
            this.PrinterURI.Location = new System.Drawing.Point(102, 59);
            this.PrinterURI.Margin = new System.Windows.Forms.Padding(0);
            this.PrinterURI.Name = "PrinterURI";
            this.PrinterURI.ReadOnly = true;
            this.PrinterURI.Size = new System.Drawing.Size(464, 23);
            this.PrinterURI.TabIndex = 96;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(8, 36);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(76, 15);
            this.label37.TabIndex = 97;
            this.label37.Text = "Port Number";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 12);
            this.label38.Margin = new System.Windows.Forms.Padding(0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 15);
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
            this.lightsTab.Location = new System.Drawing.Point(4, 24);
            this.lightsTab.Name = "lightsTab";
            this.lightsTab.Padding = new System.Windows.Forms.Padding(3);
            this.lightsTab.Size = new System.Drawing.Size(1177, 515);
            this.lightsTab.TabIndex = 6;
            this.lightsTab.Text = "Lights";
            this.lightsTab.UseVisualStyleBackColor = true;
            // 
            // LightsServiceDiscovery
            // 
            this.LightsServiceDiscovery.Location = new System.Drawing.Point(450, 88);
            this.LightsServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.LightsServiceDiscovery.Name = "LightsServiceDiscovery";
            this.LightsServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.LightsServiceDiscovery.TabIndex = 135;
            this.LightsServiceDiscovery.Text = "Service Discovery";
            this.LightsServiceDiscovery.UseVisualStyleBackColor = true;
            this.LightsServiceDiscovery.Click += new System.EventHandler(this.LightsServiceDiscovery_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(949, 45);
            this.label45.Margin = new System.Windows.Forms.Padding(0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(60, 15);
            this.label45.TabIndex = 134;
            this.label45.Text = "Flash Rate";
            // 
            // LightsFlashRate
            // 
            this.LightsFlashRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LightsFlashRate.FormattingEnabled = true;
            this.LightsFlashRate.Location = new System.Drawing.Point(1031, 42);
            this.LightsFlashRate.Name = "LightsFlashRate";
            this.LightsFlashRate.Size = new System.Drawing.Size(106, 23);
            this.LightsFlashRate.TabIndex = 133;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(940, 9);
            this.label40.Margin = new System.Windows.Forms.Padding(0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(69, 15);
            this.label40.TabIndex = 132;
            this.label40.Text = "Light Name";
            // 
            // txtLightName
            // 
            this.txtLightName.Location = new System.Drawing.Point(1031, 9);
            this.txtLightName.Margin = new System.Windows.Forms.Padding(0);
            this.txtLightName.Name = "txtLightName";
            this.txtLightName.Size = new System.Drawing.Size(106, 23);
            this.txtLightName.TabIndex = 131;
            this.txtLightName.Text = "cardReader";
            // 
            // LightsSetLight
            // 
            this.LightsSetLight.Location = new System.Drawing.Point(1044, 89);
            this.LightsSetLight.Margin = new System.Windows.Forms.Padding(0);
            this.LightsSetLight.Name = "LightsSetLight";
            this.LightsSetLight.Size = new System.Drawing.Size(93, 22);
            this.LightsSetLight.TabIndex = 130;
            this.LightsSetLight.Text = "SetLight";
            this.LightsSetLight.UseVisualStyleBackColor = true;
            this.LightsSetLight.Click += new System.EventHandler(this.LightsSetLight_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(592, 10);
            this.label41.Margin = new System.Windows.Forms.Padding(0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(76, 15);
            this.label41.TabIndex = 128;
            this.label41.Text = "Device status";
            // 
            // LightsEvtBox
            // 
            this.LightsEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsEvtBox.Location = new System.Drawing.Point(815, 200);
            this.LightsEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsEvtBox.MaxLength = 1048576;
            this.LightsEvtBox.Multiline = true;
            this.LightsEvtBox.Name = "LightsEvtBox";
            this.LightsEvtBox.ReadOnly = true;
            this.LightsEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsEvtBox.Size = new System.Drawing.Size(355, 307);
            this.LightsEvtBox.TabIndex = 127;
            // 
            // LightsRspBox
            // 
            this.LightsRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsRspBox.Location = new System.Drawing.Point(425, 200);
            this.LightsRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsRspBox.MaxLength = 1048576;
            this.LightsRspBox.Multiline = true;
            this.LightsRspBox.Name = "LightsRspBox";
            this.LightsRspBox.ReadOnly = true;
            this.LightsRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsRspBox.Size = new System.Drawing.Size(371, 307);
            this.LightsRspBox.TabIndex = 126;
            // 
            // LightsCmdBox
            // 
            this.LightsCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LightsCmdBox.Location = new System.Drawing.Point(14, 200);
            this.LightsCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.LightsCmdBox.MaxLength = 1048576;
            this.LightsCmdBox.Multiline = true;
            this.LightsCmdBox.Name = "LightsCmdBox";
            this.LightsCmdBox.ReadOnly = true;
            this.LightsCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LightsCmdBox.Size = new System.Drawing.Size(394, 307);
            this.LightsCmdBox.TabIndex = 125;
            // 
            // lblLightsStatus
            // 
            this.lblLightsStatus.Location = new System.Drawing.Point(676, 10);
            this.lblLightsStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightsStatus.Name = "lblLightsStatus";
            this.lblLightsStatus.ReadOnly = true;
            this.lblLightsStatus.Size = new System.Drawing.Size(106, 23);
            this.lblLightsStatus.TabIndex = 123;
            // 
            // LightsCapabilities
            // 
            this.LightsCapabilities.Location = new System.Drawing.Point(815, 38);
            this.LightsCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.LightsCapabilities.Name = "LightsCapabilities";
            this.LightsCapabilities.Size = new System.Drawing.Size(90, 22);
            this.LightsCapabilities.TabIndex = 122;
            this.LightsCapabilities.Text = "Capabilities";
            this.LightsCapabilities.UseVisualStyleBackColor = true;
            this.LightsCapabilities.Click += new System.EventHandler(this.LightsCapabilities_Click);
            // 
            // LightsStatus
            // 
            this.LightsStatus.Location = new System.Drawing.Point(815, 10);
            this.LightsStatus.Margin = new System.Windows.Forms.Padding(0);
            this.LightsStatus.Name = "LightsStatus";
            this.LightsStatus.Size = new System.Drawing.Size(90, 22);
            this.LightsStatus.TabIndex = 121;
            this.LightsStatus.Text = "Status";
            this.LightsStatus.UseVisualStyleBackColor = true;
            this.LightsStatus.Click += new System.EventHandler(this.LightsStatus_Click);
            // 
            // LightsServiceURI
            // 
            this.LightsServiceURI.Location = new System.Drawing.Point(102, 10);
            this.LightsServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.LightsServiceURI.Name = "LightsServiceURI";
            this.LightsServiceURI.Size = new System.Drawing.Size(464, 23);
            this.LightsServiceURI.TabIndex = 119;
            // 
            // LightsPortNum
            // 
            this.LightsPortNum.Location = new System.Drawing.Point(102, 34);
            this.LightsPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.LightsPortNum.Name = "LightsPortNum";
            this.LightsPortNum.ReadOnly = true;
            this.LightsPortNum.Size = new System.Drawing.Size(106, 23);
            this.LightsPortNum.TabIndex = 115;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 60);
            this.label42.Margin = new System.Windows.Forms.Padding(0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(60, 15);
            this.label42.TabIndex = 116;
            this.label42.Text = "Lights URI";
            // 
            // LightsURI
            // 
            this.LightsURI.Location = new System.Drawing.Point(102, 57);
            this.LightsURI.Margin = new System.Windows.Forms.Padding(0);
            this.LightsURI.Name = "LightsURI";
            this.LightsURI.ReadOnly = true;
            this.LightsURI.Size = new System.Drawing.Size(464, 23);
            this.LightsURI.TabIndex = 117;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 34);
            this.label43.Margin = new System.Windows.Forms.Padding(0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(76, 15);
            this.label43.TabIndex = 118;
            this.label43.Text = "Port Number";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 10);
            this.label44.Margin = new System.Windows.Forms.Padding(0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 15);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1177, 515);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "Auxiliaries";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboAutoStartupModes
            // 
            this.comboAutoStartupModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAutoStartupModes.FormattingEnabled = true;
            this.comboAutoStartupModes.Location = new System.Drawing.Point(940, 38);
            this.comboAutoStartupModes.Name = "comboAutoStartupModes";
            this.comboAutoStartupModes.Size = new System.Drawing.Size(106, 23);
            this.comboAutoStartupModes.TabIndex = 161;
            // 
            // btnSetAuxiliaries
            // 
            this.btnSetAuxiliaries.Location = new System.Drawing.Point(940, 97);
            this.btnSetAuxiliaries.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetAuxiliaries.Name = "btnSetAuxiliaries";
            this.btnSetAuxiliaries.Size = new System.Drawing.Size(90, 22);
            this.btnSetAuxiliaries.TabIndex = 160;
            this.btnSetAuxiliaries.Text = "SetAuxiliaries";
            this.btnSetAuxiliaries.UseVisualStyleBackColor = true;
            this.btnSetAuxiliaries.Click += new System.EventHandler(this.btnSetAuxiliaries_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(940, 66);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 22);
            this.btnRegister.TabIndex = 159;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClearAutoStartup
            // 
            this.btnClearAutoStartup.Location = new System.Drawing.Point(1060, 97);
            this.btnClearAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearAutoStartup.Name = "btnClearAutoStartup";
            this.btnClearAutoStartup.Size = new System.Drawing.Size(110, 22);
            this.btnClearAutoStartup.TabIndex = 158;
            this.btnClearAutoStartup.Text = "ClearAutoStartup";
            this.btnClearAutoStartup.UseVisualStyleBackColor = true;
            this.btnClearAutoStartup.Click += new System.EventHandler(this.btnClearAutoStartup_Click);
            // 
            // btnGetAutoStartup
            // 
            this.btnGetAutoStartup.Location = new System.Drawing.Point(1060, 66);
            this.btnGetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnGetAutoStartup.Name = "btnGetAutoStartup";
            this.btnGetAutoStartup.Size = new System.Drawing.Size(110, 22);
            this.btnGetAutoStartup.TabIndex = 157;
            this.btnGetAutoStartup.Text = "GetAutoStartup";
            this.btnGetAutoStartup.UseVisualStyleBackColor = true;
            this.btnGetAutoStartup.Click += new System.EventHandler(this.btnGetAutoStartup_Click);
            // 
            // btnSetAutoStartup
            // 
            this.btnSetAutoStartup.Location = new System.Drawing.Point(1060, 35);
            this.btnSetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetAutoStartup.Name = "btnSetAutoStartup";
            this.btnSetAutoStartup.Size = new System.Drawing.Size(110, 22);
            this.btnSetAutoStartup.TabIndex = 156;
            this.btnSetAutoStartup.Text = "SetAutoStartup";
            this.btnSetAutoStartup.UseVisualStyleBackColor = true;
            this.btnSetAutoStartup.Click += new System.EventHandler(this.btnSetAutoStartup_Click);
            // 
            // autoStartupDateTime
            // 
            this.autoStartupDateTime.CustomFormat = "yyyy.MM.dd HH:mm";
            this.autoStartupDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.autoStartupDateTime.Location = new System.Drawing.Point(940, 9);
            this.autoStartupDateTime.Name = "autoStartupDateTime";
            this.autoStartupDateTime.Size = new System.Drawing.Size(230, 23);
            this.autoStartupDateTime.TabIndex = 155;
            // 
            // btnAuxiliariesServiceDiscovery
            // 
            this.btnAuxiliariesServiceDiscovery.Location = new System.Drawing.Point(450, 87);
            this.btnAuxiliariesServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesServiceDiscovery.Name = "btnAuxiliariesServiceDiscovery";
            this.btnAuxiliariesServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.btnAuxiliariesServiceDiscovery.TabIndex = 154;
            this.btnAuxiliariesServiceDiscovery.Text = "Service Discovery";
            this.btnAuxiliariesServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnAuxiliariesServiceDiscovery.Click += new System.EventHandler(this.btnAuxiliariesServiceDiscovery_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(592, 9);
            this.label48.Margin = new System.Windows.Forms.Padding(0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(76, 15);
            this.label48.TabIndex = 148;
            this.label48.Text = "Device status";
            // 
            // AuxiliariesEvtBox
            // 
            this.AuxiliariesEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesEvtBox.Location = new System.Drawing.Point(815, 199);
            this.AuxiliariesEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesEvtBox.MaxLength = 1048576;
            this.AuxiliariesEvtBox.Multiline = true;
            this.AuxiliariesEvtBox.Name = "AuxiliariesEvtBox";
            this.AuxiliariesEvtBox.ReadOnly = true;
            this.AuxiliariesEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesEvtBox.Size = new System.Drawing.Size(355, 307);
            this.AuxiliariesEvtBox.TabIndex = 147;
            // 
            // AuxiliariesRspBox
            // 
            this.AuxiliariesRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesRspBox.Location = new System.Drawing.Point(425, 199);
            this.AuxiliariesRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesRspBox.MaxLength = 1048576;
            this.AuxiliariesRspBox.Multiline = true;
            this.AuxiliariesRspBox.Name = "AuxiliariesRspBox";
            this.AuxiliariesRspBox.ReadOnly = true;
            this.AuxiliariesRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesRspBox.Size = new System.Drawing.Size(371, 307);
            this.AuxiliariesRspBox.TabIndex = 146;
            // 
            // AuxiliariesCmdBox
            // 
            this.AuxiliariesCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AuxiliariesCmdBox.Location = new System.Drawing.Point(14, 199);
            this.AuxiliariesCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesCmdBox.MaxLength = 1048576;
            this.AuxiliariesCmdBox.Multiline = true;
            this.AuxiliariesCmdBox.Name = "AuxiliariesCmdBox";
            this.AuxiliariesCmdBox.ReadOnly = true;
            this.AuxiliariesCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AuxiliariesCmdBox.Size = new System.Drawing.Size(394, 307);
            this.AuxiliariesCmdBox.TabIndex = 145;
            // 
            // AuxiliariesStatus
            // 
            this.AuxiliariesStatus.Location = new System.Drawing.Point(676, 9);
            this.AuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesStatus.Name = "AuxiliariesStatus";
            this.AuxiliariesStatus.ReadOnly = true;
            this.AuxiliariesStatus.Size = new System.Drawing.Size(106, 23);
            this.AuxiliariesStatus.TabIndex = 144;
            // 
            // btnAuxiliariesCapabilities
            // 
            this.btnAuxiliariesCapabilities.Location = new System.Drawing.Point(815, 37);
            this.btnAuxiliariesCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesCapabilities.Name = "btnAuxiliariesCapabilities";
            this.btnAuxiliariesCapabilities.Size = new System.Drawing.Size(90, 22);
            this.btnAuxiliariesCapabilities.TabIndex = 143;
            this.btnAuxiliariesCapabilities.Text = "Capabilities";
            this.btnAuxiliariesCapabilities.UseVisualStyleBackColor = true;
            this.btnAuxiliariesCapabilities.Click += new System.EventHandler(this.btnAuxiliariesCapabilities_Click);
            // 
            // btnAuxiliariesStatus
            // 
            this.btnAuxiliariesStatus.Location = new System.Drawing.Point(815, 9);
            this.btnAuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuxiliariesStatus.Name = "btnAuxiliariesStatus";
            this.btnAuxiliariesStatus.Size = new System.Drawing.Size(90, 22);
            this.btnAuxiliariesStatus.TabIndex = 142;
            this.btnAuxiliariesStatus.Text = "Status";
            this.btnAuxiliariesStatus.UseVisualStyleBackColor = true;
            this.btnAuxiliariesStatus.Click += new System.EventHandler(this.btnAuxiliariesStatus_Click);
            // 
            // AuxiliariesServiceURI
            // 
            this.AuxiliariesServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AuxiliariesServiceURI.Location = new System.Drawing.Point(102, 9);
            this.AuxiliariesServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesServiceURI.Name = "AuxiliariesServiceURI";
            this.AuxiliariesServiceURI.Size = new System.Drawing.Size(464, 23);
            this.AuxiliariesServiceURI.TabIndex = 140;
            // 
            // AuxiliariesPortNum
            // 
            this.AuxiliariesPortNum.Location = new System.Drawing.Point(102, 33);
            this.AuxiliariesPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesPortNum.Name = "AuxiliariesPortNum";
            this.AuxiliariesPortNum.ReadOnly = true;
            this.AuxiliariesPortNum.Size = new System.Drawing.Size(106, 23);
            this.AuxiliariesPortNum.TabIndex = 136;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 59);
            this.label49.Margin = new System.Windows.Forms.Padding(0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(82, 15);
            this.label49.TabIndex = 137;
            this.label49.Text = "Auxiliaries URI";
            // 
            // AuxiliariesURI
            // 
            this.AuxiliariesURI.Location = new System.Drawing.Point(102, 56);
            this.AuxiliariesURI.Margin = new System.Windows.Forms.Padding(0);
            this.AuxiliariesURI.Name = "AuxiliariesURI";
            this.AuxiliariesURI.ReadOnly = true;
            this.AuxiliariesURI.Size = new System.Drawing.Size(464, 23);
            this.AuxiliariesURI.TabIndex = 138;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(8, 33);
            this.label50.Margin = new System.Windows.Forms.Padding(0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(76, 15);
            this.label50.TabIndex = 139;
            this.label50.Text = "Port Number";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(8, 9);
            this.label51.Margin = new System.Windows.Forms.Padding(0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 15);
            this.label51.TabIndex = 141;
            this.label51.Text = "Service URI";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonVDMExit);
            this.tabPage3.Controls.Add(this.buttonVDMEnter);
            this.tabPage3.Controls.Add(this.VendorModeServiceStatus);
            this.tabPage3.Controls.Add(this.label58);
            this.tabPage3.Controls.Add(this.VendorModeEvtBox);
            this.tabPage3.Controls.Add(this.VendorModeRspBox);
            this.tabPage3.Controls.Add(this.VendorModeCmdBox);
            this.tabPage3.Controls.Add(this.btnVendorModeServiceDiscovery);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.VendorModeStStatus);
            this.tabPage3.Controls.Add(this.btnVendorModeStatus);
            this.tabPage3.Controls.Add(this.VendorModeServiceURI);
            this.tabPage3.Controls.Add(this.VendorModePortNum);
            this.tabPage3.Controls.Add(this.label47);
            this.tabPage3.Controls.Add(this.VendorModeURI);
            this.tabPage3.Controls.Add(this.label52);
            this.tabPage3.Controls.Add(this.label53);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1177, 515);
            this.tabPage3.TabIndex = 8;
            this.tabPage3.Text = "VendorMode";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonVDMExit
            // 
            this.buttonVDMExit.Location = new System.Drawing.Point(840, 141);
            this.buttonVDMExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVDMExit.Name = "buttonVDMExit";
            this.buttonVDMExit.Size = new System.Drawing.Size(142, 22);
            this.buttonVDMExit.TabIndex = 172;
            this.buttonVDMExit.Text = "ExitModeRequest";
            this.buttonVDMExit.UseVisualStyleBackColor = true;
            this.buttonVDMExit.Click += new System.EventHandler(this.buttonVDMExit_Click);
            // 
            // buttonVDMEnter
            // 
            this.buttonVDMEnter.Location = new System.Drawing.Point(840, 104);
            this.buttonVDMEnter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonVDMEnter.Name = "buttonVDMEnter";
            this.buttonVDMEnter.Size = new System.Drawing.Size(142, 22);
            this.buttonVDMEnter.TabIndex = 171;
            this.buttonVDMEnter.Text = "EnterModeRequest";
            this.buttonVDMEnter.UseVisualStyleBackColor = true;
            this.buttonVDMEnter.Click += new System.EventHandler(this.buttonVDMEnter_Click);
            // 
            // VendorModeServiceStatus
            // 
            this.VendorModeServiceStatus.Location = new System.Drawing.Point(719, 51);
            this.VendorModeServiceStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeServiceStatus.Name = "VendorModeServiceStatus";
            this.VendorModeServiceStatus.ReadOnly = true;
            this.VendorModeServiceStatus.Size = new System.Drawing.Size(106, 23);
            this.VendorModeServiceStatus.TabIndex = 170;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(595, 53);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(110, 15);
            this.label58.TabIndex = 169;
            this.label58.Text = "VendorMode Status";
            // 
            // VendorModeEvtBox
            // 
            this.VendorModeEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeEvtBox.Location = new System.Drawing.Point(804, 210);
            this.VendorModeEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeEvtBox.MaxLength = 1048576;
            this.VendorModeEvtBox.Multiline = true;
            this.VendorModeEvtBox.Name = "VendorModeEvtBox";
            this.VendorModeEvtBox.ReadOnly = true;
            this.VendorModeEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeEvtBox.Size = new System.Drawing.Size(355, 307);
            this.VendorModeEvtBox.TabIndex = 168;
            // 
            // VendorModeRspBox
            // 
            this.VendorModeRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeRspBox.Location = new System.Drawing.Point(415, 210);
            this.VendorModeRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeRspBox.MaxLength = 1048576;
            this.VendorModeRspBox.Multiline = true;
            this.VendorModeRspBox.Name = "VendorModeRspBox";
            this.VendorModeRspBox.ReadOnly = true;
            this.VendorModeRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeRspBox.Size = new System.Drawing.Size(371, 307);
            this.VendorModeRspBox.TabIndex = 167;
            // 
            // VendorModeCmdBox
            // 
            this.VendorModeCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorModeCmdBox.Location = new System.Drawing.Point(4, 210);
            this.VendorModeCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeCmdBox.MaxLength = 1048576;
            this.VendorModeCmdBox.Multiline = true;
            this.VendorModeCmdBox.Name = "VendorModeCmdBox";
            this.VendorModeCmdBox.ReadOnly = true;
            this.VendorModeCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorModeCmdBox.Size = new System.Drawing.Size(394, 307);
            this.VendorModeCmdBox.TabIndex = 166;
            // 
            // btnVendorModeServiceDiscovery
            // 
            this.btnVendorModeServiceDiscovery.Location = new System.Drawing.Point(452, 91);
            this.btnVendorModeServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorModeServiceDiscovery.Name = "btnVendorModeServiceDiscovery";
            this.btnVendorModeServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.btnVendorModeServiceDiscovery.TabIndex = 165;
            this.btnVendorModeServiceDiscovery.Text = "Service Discovery";
            this.btnVendorModeServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnVendorModeServiceDiscovery.Click += new System.EventHandler(this.btnVendorModeServiceDiscovery_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(595, 13);
            this.label46.Margin = new System.Windows.Forms.Padding(0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(76, 15);
            this.label46.TabIndex = 164;
            this.label46.Text = "Device status";
            // 
            // VendorModeStStatus
            // 
            this.VendorModeStStatus.Location = new System.Drawing.Point(719, 14);
            this.VendorModeStStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeStStatus.Name = "VendorModeStStatus";
            this.VendorModeStStatus.ReadOnly = true;
            this.VendorModeStStatus.Size = new System.Drawing.Size(106, 23);
            this.VendorModeStStatus.TabIndex = 163;
            // 
            // btnVendorModeStatus
            // 
            this.btnVendorModeStatus.Location = new System.Drawing.Point(840, 13);
            this.btnVendorModeStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorModeStatus.Name = "btnVendorModeStatus";
            this.btnVendorModeStatus.Size = new System.Drawing.Size(90, 22);
            this.btnVendorModeStatus.TabIndex = 161;
            this.btnVendorModeStatus.Text = "Status";
            this.btnVendorModeStatus.UseVisualStyleBackColor = true;
            this.btnVendorModeStatus.Click += new System.EventHandler(this.btnVendorModeStatus_Click);
            // 
            // VendorModeServiceURI
            // 
            this.VendorModeServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.VendorModeServiceURI.Location = new System.Drawing.Point(105, 13);
            this.VendorModeServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeServiceURI.Name = "VendorModeServiceURI";
            this.VendorModeServiceURI.Size = new System.Drawing.Size(464, 23);
            this.VendorModeServiceURI.TabIndex = 159;
            // 
            // VendorModePortNum
            // 
            this.VendorModePortNum.Location = new System.Drawing.Point(105, 37);
            this.VendorModePortNum.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModePortNum.Name = "VendorModePortNum";
            this.VendorModePortNum.ReadOnly = true;
            this.VendorModePortNum.Size = new System.Drawing.Size(106, 23);
            this.VendorModePortNum.TabIndex = 155;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 63);
            this.label47.Margin = new System.Windows.Forms.Padding(0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(96, 15);
            this.label47.TabIndex = 156;
            this.label47.Text = "VendorMode URI";
            // 
            // VendorModeURI
            // 
            this.VendorModeURI.Location = new System.Drawing.Point(105, 60);
            this.VendorModeURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorModeURI.Name = "VendorModeURI";
            this.VendorModeURI.ReadOnly = true;
            this.VendorModeURI.Size = new System.Drawing.Size(464, 23);
            this.VendorModeURI.TabIndex = 157;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(8, 37);
            this.label52.Margin = new System.Windows.Forms.Padding(0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(76, 15);
            this.label52.TabIndex = 158;
            this.label52.Text = "Port Number";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(8, 13);
            this.label53.Margin = new System.Windows.Forms.Padding(0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(65, 15);
            this.label53.TabIndex = 160;
            this.label53.Text = "Service URI";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label60);
            this.tabPage4.Controls.Add(this.textAppName);
            this.tabPage4.Controls.Add(this.label59);
            this.tabPage4.Controls.Add(this.textActiveInterface);
            this.tabPage4.Controls.Add(this.buttonGetActiveInterface);
            this.tabPage4.Controls.Add(this.buttonStartLocalApplication);
            this.tabPage4.Controls.Add(this.VendorAppEvtBox);
            this.tabPage4.Controls.Add(this.VendorAppRspBox);
            this.tabPage4.Controls.Add(this.VendorAppCmdBox);
            this.tabPage4.Controls.Add(this.btnVendorAppServiceDiscovery);
            this.tabPage4.Controls.Add(this.label54);
            this.tabPage4.Controls.Add(this.VendorAppStatus);
            this.tabPage4.Controls.Add(this.btnVendorAppCapabilities);
            this.tabPage4.Controls.Add(this.btnVendorAppStatus);
            this.tabPage4.Controls.Add(this.VendorAppServiceURI);
            this.tabPage4.Controls.Add(this.VendorAppPortNum);
            this.tabPage4.Controls.Add(this.label55);
            this.tabPage4.Controls.Add(this.VendorAppURI);
            this.tabPage4.Controls.Add(this.label56);
            this.tabPage4.Controls.Add(this.label57);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1177, 515);
            this.tabPage4.TabIndex = 9;
            this.tabPage4.Text = "VendorApplication";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(599, 114);
            this.label60.Margin = new System.Windows.Forms.Padding(0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(64, 15);
            this.label60.TabIndex = 177;
            this.label60.Text = "App Name";
            // 
            // textAppName
            // 
            this.textAppName.Location = new System.Drawing.Point(673, 109);
            this.textAppName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAppName.Name = "textAppName";
            this.textAppName.Size = new System.Drawing.Size(110, 23);
            this.textAppName.TabIndex = 176;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(575, 148);
            this.label59.Margin = new System.Windows.Forms.Padding(0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(89, 15);
            this.label59.TabIndex = 175;
            this.label59.Text = "Active Interface";
            // 
            // textActiveInterface
            // 
            this.textActiveInterface.Location = new System.Drawing.Point(673, 142);
            this.textActiveInterface.Margin = new System.Windows.Forms.Padding(0);
            this.textActiveInterface.Name = "textActiveInterface";
            this.textActiveInterface.ReadOnly = true;
            this.textActiveInterface.Size = new System.Drawing.Size(106, 23);
            this.textActiveInterface.TabIndex = 174;
            // 
            // buttonGetActiveInterface
            // 
            this.buttonGetActiveInterface.Location = new System.Drawing.Point(811, 141);
            this.buttonGetActiveInterface.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetActiveInterface.Name = "buttonGetActiveInterface";
            this.buttonGetActiveInterface.Size = new System.Drawing.Size(178, 22);
            this.buttonGetActiveInterface.TabIndex = 173;
            this.buttonGetActiveInterface.Text = "GetActiveInterface";
            this.buttonGetActiveInterface.UseVisualStyleBackColor = true;
            this.buttonGetActiveInterface.Click += new System.EventHandler(this.buttonGetActiveInterface_Click);
            // 
            // buttonStartLocalApplication
            // 
            this.buttonStartLocalApplication.Location = new System.Drawing.Point(811, 107);
            this.buttonStartLocalApplication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartLocalApplication.Name = "buttonStartLocalApplication";
            this.buttonStartLocalApplication.Size = new System.Drawing.Size(185, 22);
            this.buttonStartLocalApplication.TabIndex = 172;
            this.buttonStartLocalApplication.Text = "StartLocalApplication";
            this.buttonStartLocalApplication.UseVisualStyleBackColor = true;
            this.buttonStartLocalApplication.Click += new System.EventHandler(this.buttonStartLocalApplication_Click);
            // 
            // VendorAppEvtBox
            // 
            this.VendorAppEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppEvtBox.Location = new System.Drawing.Point(806, 210);
            this.VendorAppEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppEvtBox.MaxLength = 1048576;
            this.VendorAppEvtBox.Multiline = true;
            this.VendorAppEvtBox.Name = "VendorAppEvtBox";
            this.VendorAppEvtBox.ReadOnly = true;
            this.VendorAppEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppEvtBox.Size = new System.Drawing.Size(355, 307);
            this.VendorAppEvtBox.TabIndex = 171;
            // 
            // VendorAppRspBox
            // 
            this.VendorAppRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppRspBox.Location = new System.Drawing.Point(416, 210);
            this.VendorAppRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppRspBox.MaxLength = 1048576;
            this.VendorAppRspBox.Multiline = true;
            this.VendorAppRspBox.Name = "VendorAppRspBox";
            this.VendorAppRspBox.ReadOnly = true;
            this.VendorAppRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppRspBox.Size = new System.Drawing.Size(371, 307);
            this.VendorAppRspBox.TabIndex = 170;
            // 
            // VendorAppCmdBox
            // 
            this.VendorAppCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VendorAppCmdBox.Location = new System.Drawing.Point(5, 210);
            this.VendorAppCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppCmdBox.MaxLength = 1048576;
            this.VendorAppCmdBox.Multiline = true;
            this.VendorAppCmdBox.Name = "VendorAppCmdBox";
            this.VendorAppCmdBox.ReadOnly = true;
            this.VendorAppCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VendorAppCmdBox.Size = new System.Drawing.Size(394, 307);
            this.VendorAppCmdBox.TabIndex = 169;
            // 
            // btnVendorAppServiceDiscovery
            // 
            this.btnVendorAppServiceDiscovery.Location = new System.Drawing.Point(446, 88);
            this.btnVendorAppServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppServiceDiscovery.Name = "btnVendorAppServiceDiscovery";
            this.btnVendorAppServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.btnVendorAppServiceDiscovery.TabIndex = 165;
            this.btnVendorAppServiceDiscovery.Text = "Service Discovery";
            this.btnVendorAppServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnVendorAppServiceDiscovery.Click += new System.EventHandler(this.btnVendorAppServiceDiscovery_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(589, 10);
            this.label54.Margin = new System.Windows.Forms.Padding(0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(76, 15);
            this.label54.TabIndex = 164;
            this.label54.Text = "Device status";
            // 
            // VendorAppStatus
            // 
            this.VendorAppStatus.Location = new System.Drawing.Point(673, 10);
            this.VendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppStatus.Name = "VendorAppStatus";
            this.VendorAppStatus.ReadOnly = true;
            this.VendorAppStatus.Size = new System.Drawing.Size(106, 23);
            this.VendorAppStatus.TabIndex = 163;
            // 
            // btnVendorAppCapabilities
            // 
            this.btnVendorAppCapabilities.Location = new System.Drawing.Point(811, 38);
            this.btnVendorAppCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppCapabilities.Name = "btnVendorAppCapabilities";
            this.btnVendorAppCapabilities.Size = new System.Drawing.Size(90, 22);
            this.btnVendorAppCapabilities.TabIndex = 162;
            this.btnVendorAppCapabilities.Text = "Capabilities";
            this.btnVendorAppCapabilities.UseVisualStyleBackColor = true;
            this.btnVendorAppCapabilities.Click += new System.EventHandler(this.btnVendorAppCapabilities_Click);
            // 
            // btnVendorAppStatus
            // 
            this.btnVendorAppStatus.Location = new System.Drawing.Point(811, 10);
            this.btnVendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnVendorAppStatus.Name = "btnVendorAppStatus";
            this.btnVendorAppStatus.Size = new System.Drawing.Size(90, 22);
            this.btnVendorAppStatus.TabIndex = 161;
            this.btnVendorAppStatus.Text = "Status";
            this.btnVendorAppStatus.UseVisualStyleBackColor = true;
            this.btnVendorAppStatus.Click += new System.EventHandler(this.btnVendorAppStatus_Click);
            // 
            // VendorAppServiceURI
            // 
            this.VendorAppServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.VendorAppServiceURI.Location = new System.Drawing.Point(99, 10);
            this.VendorAppServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppServiceURI.Name = "VendorAppServiceURI";
            this.VendorAppServiceURI.Size = new System.Drawing.Size(464, 23);
            this.VendorAppServiceURI.TabIndex = 159;
            // 
            // VendorAppPortNum
            // 
            this.VendorAppPortNum.Location = new System.Drawing.Point(99, 34);
            this.VendorAppPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppPortNum.Name = "VendorAppPortNum";
            this.VendorAppPortNum.ReadOnly = true;
            this.VendorAppPortNum.Size = new System.Drawing.Size(106, 23);
            this.VendorAppPortNum.TabIndex = 155;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 61);
            this.label55.Margin = new System.Windows.Forms.Padding(0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(87, 15);
            this.label55.TabIndex = 156;
            this.label55.Text = "VendorApp URI";
            // 
            // VendorAppURI
            // 
            this.VendorAppURI.Location = new System.Drawing.Point(99, 58);
            this.VendorAppURI.Margin = new System.Windows.Forms.Padding(0);
            this.VendorAppURI.Name = "VendorAppURI";
            this.VendorAppURI.ReadOnly = true;
            this.VendorAppURI.Size = new System.Drawing.Size(464, 23);
            this.VendorAppURI.TabIndex = 157;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(4, 34);
            this.label56.Margin = new System.Windows.Forms.Padding(0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(76, 15);
            this.label56.TabIndex = 158;
            this.label56.Text = "Port Number";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(4, 10);
            this.label57.Margin = new System.Windows.Forms.Padding(0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(65, 15);
            this.label57.TabIndex = 160;
            this.label57.Text = "Service URI";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BarcodeReaderReset);
            this.tabPage5.Controls.Add(this.BarcodeReaderRead);
            this.tabPage5.Controls.Add(this.label61);
            this.tabPage5.Controls.Add(this.label62);
            this.tabPage5.Controls.Add(this.BarcodeReaderEvtBox);
            this.tabPage5.Controls.Add(this.BarcodeReaderRspBox);
            this.tabPage5.Controls.Add(this.BarcodeReaderCmdBox);
            this.tabPage5.Controls.Add(this.BarcodeReaderScannerStatus);
            this.tabPage5.Controls.Add(this.BarcodeReaderStDevice);
            this.tabPage5.Controls.Add(this.BarcodeReaderCapabilities);
            this.tabPage5.Controls.Add(this.BarcodeReaderStatus);
            this.tabPage5.Controls.Add(this.BarcodeReaderServiceURI);
            this.tabPage5.Controls.Add(this.btnBarcodeReaderServiceDiscovery);
            this.tabPage5.Controls.Add(this.BarcodeReaderPortNum);
            this.tabPage5.Controls.Add(this.label63);
            this.tabPage5.Controls.Add(this.BarcodeReaderURI);
            this.tabPage5.Controls.Add(this.label64);
            this.tabPage5.Controls.Add(this.label65);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1177, 515);
            this.tabPage5.TabIndex = 10;
            this.tabPage5.Text = "BarcodeReader";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BarcodeReaderReset
            // 
            this.BarcodeReaderReset.Location = new System.Drawing.Point(1063, 10);
            this.BarcodeReaderReset.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderReset.Name = "BarcodeReaderReset";
            this.BarcodeReaderReset.Size = new System.Drawing.Size(93, 22);
            this.BarcodeReaderReset.TabIndex = 132;
            this.BarcodeReaderReset.Text = "Reset";
            this.BarcodeReaderReset.UseVisualStyleBackColor = true;
            this.BarcodeReaderReset.Click += new System.EventHandler(this.BarcodeReaderReset_Click);
            // 
            // BarcodeReaderRead
            // 
            this.BarcodeReaderRead.Location = new System.Drawing.Point(956, 12);
            this.BarcodeReaderRead.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderRead.Name = "BarcodeReaderRead";
            this.BarcodeReaderRead.Size = new System.Drawing.Size(99, 22);
            this.BarcodeReaderRead.TabIndex = 131;
            this.BarcodeReaderRead.Text = "Read";
            this.BarcodeReaderRead.UseVisualStyleBackColor = true;
            this.BarcodeReaderRead.Click += new System.EventHandler(this.BarcodeReaderRead_Click);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(586, 48);
            this.label61.Margin = new System.Windows.Forms.Padding(0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(84, 15);
            this.label61.TabIndex = 130;
            this.label61.Text = "Scanner Status";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(594, 13);
            this.label62.Margin = new System.Windows.Forms.Padding(0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(76, 15);
            this.label62.TabIndex = 129;
            this.label62.Text = "Device status";
            // 
            // BarcodeReaderEvtBox
            // 
            this.BarcodeReaderEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderEvtBox.Location = new System.Drawing.Point(816, 202);
            this.BarcodeReaderEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderEvtBox.MaxLength = 1048576;
            this.BarcodeReaderEvtBox.Multiline = true;
            this.BarcodeReaderEvtBox.Name = "BarcodeReaderEvtBox";
            this.BarcodeReaderEvtBox.ReadOnly = true;
            this.BarcodeReaderEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderEvtBox.Size = new System.Drawing.Size(355, 307);
            this.BarcodeReaderEvtBox.TabIndex = 128;
            // 
            // BarcodeReaderRspBox
            // 
            this.BarcodeReaderRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderRspBox.Location = new System.Drawing.Point(427, 202);
            this.BarcodeReaderRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderRspBox.MaxLength = 1048576;
            this.BarcodeReaderRspBox.Multiline = true;
            this.BarcodeReaderRspBox.Name = "BarcodeReaderRspBox";
            this.BarcodeReaderRspBox.ReadOnly = true;
            this.BarcodeReaderRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderRspBox.Size = new System.Drawing.Size(371, 307);
            this.BarcodeReaderRspBox.TabIndex = 127;
            // 
            // BarcodeReaderCmdBox
            // 
            this.BarcodeReaderCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BarcodeReaderCmdBox.Location = new System.Drawing.Point(16, 202);
            this.BarcodeReaderCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderCmdBox.MaxLength = 1048576;
            this.BarcodeReaderCmdBox.Multiline = true;
            this.BarcodeReaderCmdBox.Name = "BarcodeReaderCmdBox";
            this.BarcodeReaderCmdBox.ReadOnly = true;
            this.BarcodeReaderCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BarcodeReaderCmdBox.Size = new System.Drawing.Size(394, 307);
            this.BarcodeReaderCmdBox.TabIndex = 126;
            // 
            // BarcodeReaderScannerStatus
            // 
            this.BarcodeReaderScannerStatus.Location = new System.Drawing.Point(678, 46);
            this.BarcodeReaderScannerStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderScannerStatus.Name = "BarcodeReaderScannerStatus";
            this.BarcodeReaderScannerStatus.ReadOnly = true;
            this.BarcodeReaderScannerStatus.Size = new System.Drawing.Size(106, 23);
            this.BarcodeReaderScannerStatus.TabIndex = 125;
            // 
            // BarcodeReaderStDevice
            // 
            this.BarcodeReaderStDevice.Location = new System.Drawing.Point(678, 13);
            this.BarcodeReaderStDevice.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderStDevice.Name = "BarcodeReaderStDevice";
            this.BarcodeReaderStDevice.ReadOnly = true;
            this.BarcodeReaderStDevice.Size = new System.Drawing.Size(106, 23);
            this.BarcodeReaderStDevice.TabIndex = 124;
            // 
            // BarcodeReaderCapabilities
            // 
            this.BarcodeReaderCapabilities.Location = new System.Drawing.Point(816, 39);
            this.BarcodeReaderCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderCapabilities.Name = "BarcodeReaderCapabilities";
            this.BarcodeReaderCapabilities.Size = new System.Drawing.Size(90, 22);
            this.BarcodeReaderCapabilities.TabIndex = 123;
            this.BarcodeReaderCapabilities.Text = "Capabilities";
            this.BarcodeReaderCapabilities.UseVisualStyleBackColor = true;
            this.BarcodeReaderCapabilities.Click += new System.EventHandler(this.BarcodeReaderCapabilities_Click);
            // 
            // BarcodeReaderStatus
            // 
            this.BarcodeReaderStatus.Location = new System.Drawing.Point(816, 10);
            this.BarcodeReaderStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderStatus.Name = "BarcodeReaderStatus";
            this.BarcodeReaderStatus.Size = new System.Drawing.Size(90, 22);
            this.BarcodeReaderStatus.TabIndex = 122;
            this.BarcodeReaderStatus.Text = "Status";
            this.BarcodeReaderStatus.UseVisualStyleBackColor = true;
            this.BarcodeReaderStatus.Click += new System.EventHandler(this.BarcodeReaderStatus_Click);
            // 
            // BarcodeReaderServiceURI
            // 
            this.BarcodeReaderServiceURI.Location = new System.Drawing.Point(113, 13);
            this.BarcodeReaderServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderServiceURI.Name = "BarcodeReaderServiceURI";
            this.BarcodeReaderServiceURI.Size = new System.Drawing.Size(464, 23);
            this.BarcodeReaderServiceURI.TabIndex = 120;
            // 
            // btnBarcodeReaderServiceDiscovery
            // 
            this.btnBarcodeReaderServiceDiscovery.Location = new System.Drawing.Point(443, 96);
            this.btnBarcodeReaderServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnBarcodeReaderServiceDiscovery.Name = "btnBarcodeReaderServiceDiscovery";
            this.btnBarcodeReaderServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.btnBarcodeReaderServiceDiscovery.TabIndex = 115;
            this.btnBarcodeReaderServiceDiscovery.Text = "Service Discovery";
            this.btnBarcodeReaderServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnBarcodeReaderServiceDiscovery.Click += new System.EventHandler(this.btnBarcodeReaderServiceDiscovery_Click);
            // 
            // BarcodeReaderPortNum
            // 
            this.BarcodeReaderPortNum.Location = new System.Drawing.Point(113, 37);
            this.BarcodeReaderPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderPortNum.Name = "BarcodeReaderPortNum";
            this.BarcodeReaderPortNum.ReadOnly = true;
            this.BarcodeReaderPortNum.Size = new System.Drawing.Size(106, 23);
            this.BarcodeReaderPortNum.TabIndex = 116;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(4, 63);
            this.label63.Margin = new System.Windows.Forms.Padding(0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(107, 15);
            this.label63.TabIndex = 117;
            this.label63.Text = "BarcodeReader URI";
            // 
            // BarcodeReaderURI
            // 
            this.BarcodeReaderURI.Location = new System.Drawing.Point(113, 60);
            this.BarcodeReaderURI.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeReaderURI.Name = "BarcodeReaderURI";
            this.BarcodeReaderURI.ReadOnly = true;
            this.BarcodeReaderURI.Size = new System.Drawing.Size(464, 23);
            this.BarcodeReaderURI.TabIndex = 118;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(6, 37);
            this.label64.Margin = new System.Windows.Forms.Padding(0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(76, 15);
            this.label64.TabIndex = 119;
            this.label64.Text = "Port Number";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(6, 13);
            this.label65.Margin = new System.Windows.Forms.Padding(0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(65, 15);
            this.label65.TabIndex = 121;
            this.label65.Text = "Service URI";
            // 
            // BiometricPage
            // 
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
            this.BiometricPage.Location = new System.Drawing.Point(4, 24);
            this.BiometricPage.Name = "BiometricPage";
            this.BiometricPage.Padding = new System.Windows.Forms.Padding(3);
            this.BiometricPage.Size = new System.Drawing.Size(1177, 515);
            this.BiometricPage.TabIndex = 11;
            this.BiometricPage.Text = "Biometric";
            this.BiometricPage.UseVisualStyleBackColor = true;
            // 
            // btnBiometricGetStorageInfo
            // 
            this.btnBiometricGetStorageInfo.Location = new System.Drawing.Point(953, 113);
            this.btnBiometricGetStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricGetStorageInfo.Name = "btnBiometricGetStorageInfo";
            this.btnBiometricGetStorageInfo.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricGetStorageInfo.TabIndex = 158;
            this.btnBiometricGetStorageInfo.Text = "GetStorageInfo";
            this.btnBiometricGetStorageInfo.UseVisualStyleBackColor = true;
            this.btnBiometricGetStorageInfo.Click += new System.EventHandler(this.btnBiometricGetStorageInfo_Click);
            // 
            // BiometricStorageInfo
            // 
            this.BiometricStorageInfo.FormattingEnabled = true;
            this.BiometricStorageInfo.ItemHeight = 15;
            this.BiometricStorageInfo.Location = new System.Drawing.Point(815, 79);
            this.BiometricStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricStorageInfo.Name = "BiometricStorageInfo";
            this.BiometricStorageInfo.Size = new System.Drawing.Size(104, 94);
            this.BiometricStorageInfo.TabIndex = 157;
            // 
            // btnBiometricReadMatch
            // 
            this.btnBiometricReadMatch.Location = new System.Drawing.Point(1062, 46);
            this.btnBiometricReadMatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricReadMatch.Name = "btnBiometricReadMatch";
            this.btnBiometricReadMatch.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricReadMatch.TabIndex = 156;
            this.btnBiometricReadMatch.Text = "Read(Match)";
            this.btnBiometricReadMatch.UseVisualStyleBackColor = true;
            this.btnBiometricReadMatch.Click += new System.EventHandler(this.btnBiometricReadMatch_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(15, 120);
            this.label71.Margin = new System.Windows.Forms.Padding(0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(124, 15);
            this.label71.TabIndex = 155;
            this.label71.Text = "Base64 Template Data:";
            // 
            // txtBiometricTemplateData
            // 
            this.txtBiometricTemplateData.Location = new System.Drawing.Point(15, 144);
            this.txtBiometricTemplateData.Name = "txtBiometricTemplateData";
            this.txtBiometricTemplateData.Size = new System.Drawing.Size(782, 23);
            this.txtBiometricTemplateData.TabIndex = 154;
            // 
            // btnBiometricClear
            // 
            this.btnBiometricClear.Location = new System.Drawing.Point(953, 10);
            this.btnBiometricClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricClear.Name = "btnBiometricClear";
            this.btnBiometricClear.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricClear.TabIndex = 153;
            this.btnBiometricClear.Text = "Clear";
            this.btnBiometricClear.UseVisualStyleBackColor = true;
            this.btnBiometricClear.Click += new System.EventHandler(this.btnBiometricClear_Click);
            // 
            // btnBiometricMatch
            // 
            this.btnBiometricMatch.Location = new System.Drawing.Point(1062, 79);
            this.btnBiometricMatch.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricMatch.Name = "btnBiometricMatch";
            this.btnBiometricMatch.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricMatch.TabIndex = 152;
            this.btnBiometricMatch.Text = "Match";
            this.btnBiometricMatch.UseVisualStyleBackColor = true;
            this.btnBiometricMatch.Click += new System.EventHandler(this.btnBiometricMatch_Click);
            // 
            // btnBiometricImport
            // 
            this.btnBiometricImport.Location = new System.Drawing.Point(953, 79);
            this.btnBiometricImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricImport.Name = "btnBiometricImport";
            this.btnBiometricImport.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricImport.TabIndex = 151;
            this.btnBiometricImport.Text = "Import";
            this.btnBiometricImport.UseVisualStyleBackColor = true;
            this.btnBiometricImport.Click += new System.EventHandler(this.btnBiometricImport_Click);
            // 
            // btnBiometricReset
            // 
            this.btnBiometricReset.Location = new System.Drawing.Point(1062, 10);
            this.btnBiometricReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricReset.Name = "btnBiometricReset";
            this.btnBiometricReset.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricReset.TabIndex = 150;
            this.btnBiometricReset.Text = "Reset";
            this.btnBiometricReset.UseVisualStyleBackColor = true;
            this.btnBiometricReset.Click += new System.EventHandler(this.btnBiometricReset_Click);
            // 
            // btnBiometricRead
            // 
            this.btnBiometricRead.Location = new System.Drawing.Point(953, 46);
            this.btnBiometricRead.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricRead.Name = "btnBiometricRead";
            this.btnBiometricRead.Size = new System.Drawing.Size(99, 22);
            this.btnBiometricRead.TabIndex = 149;
            this.btnBiometricRead.Text = "Read(Scan)";
            this.btnBiometricRead.UseVisualStyleBackColor = true;
            this.btnBiometricRead.Click += new System.EventHandler(this.btnBiometricRead_Click);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(593, 11);
            this.label67.Margin = new System.Windows.Forms.Padding(0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(76, 15);
            this.label67.TabIndex = 147;
            this.label67.Text = "Device status";
            // 
            // BiometricEvtBox
            // 
            this.BiometricEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricEvtBox.Location = new System.Drawing.Point(815, 200);
            this.BiometricEvtBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricEvtBox.MaxLength = 1048576;
            this.BiometricEvtBox.Multiline = true;
            this.BiometricEvtBox.Name = "BiometricEvtBox";
            this.BiometricEvtBox.ReadOnly = true;
            this.BiometricEvtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricEvtBox.Size = new System.Drawing.Size(355, 307);
            this.BiometricEvtBox.TabIndex = 146;
            // 
            // BiometricRspBox
            // 
            this.BiometricRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricRspBox.Location = new System.Drawing.Point(426, 200);
            this.BiometricRspBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricRspBox.MaxLength = 1048576;
            this.BiometricRspBox.Multiline = true;
            this.BiometricRspBox.Name = "BiometricRspBox";
            this.BiometricRspBox.ReadOnly = true;
            this.BiometricRspBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricRspBox.Size = new System.Drawing.Size(371, 307);
            this.BiometricRspBox.TabIndex = 145;
            // 
            // BiometricCmdBox
            // 
            this.BiometricCmdBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BiometricCmdBox.Location = new System.Drawing.Point(15, 200);
            this.BiometricCmdBox.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricCmdBox.MaxLength = 1048576;
            this.BiometricCmdBox.Multiline = true;
            this.BiometricCmdBox.Name = "BiometricCmdBox";
            this.BiometricCmdBox.ReadOnly = true;
            this.BiometricCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BiometricCmdBox.Size = new System.Drawing.Size(394, 307);
            this.BiometricCmdBox.TabIndex = 144;
            // 
            // BiometricStatus
            // 
            this.BiometricStatus.Location = new System.Drawing.Point(677, 11);
            this.BiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricStatus.Name = "BiometricStatus";
            this.BiometricStatus.ReadOnly = true;
            this.BiometricStatus.Size = new System.Drawing.Size(106, 23);
            this.BiometricStatus.TabIndex = 142;
            // 
            // btnBiometricCapabilities
            // 
            this.btnBiometricCapabilities.Location = new System.Drawing.Point(815, 37);
            this.btnBiometricCapabilities.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricCapabilities.Name = "btnBiometricCapabilities";
            this.btnBiometricCapabilities.Size = new System.Drawing.Size(104, 22);
            this.btnBiometricCapabilities.TabIndex = 141;
            this.btnBiometricCapabilities.Text = "Capabilities";
            this.btnBiometricCapabilities.UseVisualStyleBackColor = true;
            this.btnBiometricCapabilities.Click += new System.EventHandler(this.btnBiometricCapabilities_Click);
            // 
            // btnBiometricStatus
            // 
            this.btnBiometricStatus.Location = new System.Drawing.Point(815, 8);
            this.btnBiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricStatus.Name = "btnBiometricStatus";
            this.btnBiometricStatus.Size = new System.Drawing.Size(104, 22);
            this.btnBiometricStatus.TabIndex = 140;
            this.btnBiometricStatus.Text = "Status";
            this.btnBiometricStatus.UseVisualStyleBackColor = true;
            this.btnBiometricStatus.Click += new System.EventHandler(this.btnBiometricStatus_Click);
            // 
            // BiometricServiceURI
            // 
            this.BiometricServiceURI.Location = new System.Drawing.Point(103, 11);
            this.BiometricServiceURI.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricServiceURI.Name = "BiometricServiceURI";
            this.BiometricServiceURI.Size = new System.Drawing.Size(464, 23);
            this.BiometricServiceURI.TabIndex = 138;
            // 
            // btnBiometricServiceDiscovery
            // 
            this.btnBiometricServiceDiscovery.Location = new System.Drawing.Point(451, 97);
            this.btnBiometricServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiometricServiceDiscovery.Name = "btnBiometricServiceDiscovery";
            this.btnBiometricServiceDiscovery.Size = new System.Drawing.Size(116, 23);
            this.btnBiometricServiceDiscovery.TabIndex = 133;
            this.btnBiometricServiceDiscovery.Text = "Service Discovery";
            this.btnBiometricServiceDiscovery.UseVisualStyleBackColor = true;
            this.btnBiometricServiceDiscovery.Click += new System.EventHandler(this.btnBiometricServiceDiscovery_Click);
            // 
            // BiometricPortNum
            // 
            this.BiometricPortNum.Location = new System.Drawing.Point(103, 35);
            this.BiometricPortNum.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricPortNum.Name = "BiometricPortNum";
            this.BiometricPortNum.ReadOnly = true;
            this.BiometricPortNum.Size = new System.Drawing.Size(106, 23);
            this.BiometricPortNum.TabIndex = 134;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(7, 61);
            this.label68.Margin = new System.Windows.Forms.Padding(0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(79, 15);
            this.label68.TabIndex = 135;
            this.label68.Text = "Biometric URI";
            // 
            // BiometricURI
            // 
            this.BiometricURI.Location = new System.Drawing.Point(103, 58);
            this.BiometricURI.Margin = new System.Windows.Forms.Padding(0);
            this.BiometricURI.Name = "BiometricURI";
            this.BiometricURI.ReadOnly = true;
            this.BiometricURI.Size = new System.Drawing.Size(464, 23);
            this.BiometricURI.TabIndex = 136;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(9, 35);
            this.label69.Margin = new System.Windows.Forms.Padding(0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(76, 15);
            this.label69.TabIndex = 137;
            this.label69.Text = "Port Number";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(9, 11);
            this.label70.Margin = new System.Windows.Forms.Padding(0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(65, 15);
            this.label70.TabIndex = 139;
            this.label70.Text = "Service URI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 552);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.lightsTab.ResumeLayout(false);
            this.lightsTab.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.BiometricPage.ResumeLayout(false);
            this.BiometricPage.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.TabPage tabPage3;
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
        private System.Windows.Forms.TabPage tabPage4;
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
        private System.Windows.Forms.TabPage tabPage5;
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
    }
}

