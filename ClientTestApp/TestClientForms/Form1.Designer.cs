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
            AcceptCard = new System.Windows.Forms.Button();
            EjectCard = new System.Windows.Forms.Button();
            ServiceDiscovery = new System.Windows.Forms.Button();
            textBoxPort = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBoxCardReader = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            textBoxServiceURI = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            buttonStatus = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            textBoxStDevice = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            textBoxStMedia = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            textBoxDeviceType = new System.Windows.Forms.TextBox();
            CaptureCard = new System.Windows.Forms.Button();
            testClientTabControl = new System.Windows.Forms.TabControl();
            CardReaderTab = new System.Windows.Forms.TabPage();
            buttonEMVClessPerformTransaction = new System.Windows.Forms.Button();
            buttonEMVClessQueryApplications = new System.Windows.Forms.Button();
            cardReaderRawBox = new System.Windows.Forms.TextBox();
            cardReaderTreeView = new System.Windows.Forms.TreeView();
            ResetBinCount = new System.Windows.Forms.Button();
            GetStorage = new System.Windows.Forms.Button();
            Reset = new System.Windows.Forms.Button();
            DispenserTab = new System.Windows.Forms.TabPage();
            cashDispenserRawBox = new System.Windows.Forms.TextBox();
            cashDispenserTreeView = new System.Windows.Forms.TreeView();
            label78 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            SetCashUnitInfo = new System.Windows.Forms.Button();
            DispenserRetract = new System.Windows.Forms.Button();
            DispenserReject = new System.Windows.Forms.Button();
            DispenserCloseShutter = new System.Windows.Forms.Button();
            DispenserOpenShutter = new System.Windows.Forms.Button();
            DispenserDispense = new System.Windows.Forms.Button();
            ClearCommandNonce = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            DispenserDenominate = new System.Windows.Forms.Button();
            DispenserPresent = new System.Windows.Forms.Button();
            DispenserEndExchange = new System.Windows.Forms.Button();
            DispenserStartExchange = new System.Windows.Forms.Button();
            DispenserReset = new System.Windows.Forms.Button();
            DispenserGetPresentStatus = new System.Windows.Forms.Button();
            DispenserDeviceType = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            DispenserStDevice = new System.Windows.Forms.TextBox();
            DispenserGetMixTypes = new System.Windows.Forms.Button();
            DispenserCapabilities = new System.Windows.Forms.Button();
            DispenserStatus = new System.Windows.Forms.Button();
            DispenserGetCashUnitInfo = new System.Windows.Forms.Button();
            DispenserServiceURI = new System.Windows.Forms.TextBox();
            DispenserServiceDiscovery = new System.Windows.Forms.Button();
            DispenserPortNum = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            NonceTextBox = new System.Windows.Forms.TextBox();
            TokenTextBox = new System.Windows.Forms.TextBox();
            DispenserDispURI = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            TextTerminalTab = new System.Windows.Forms.TabPage();
            textTerminalRawBox = new System.Windows.Forms.TextBox();
            textTerminalTreeView = new System.Windows.Forms.TreeView();
            TextTerminalSetResolution = new System.Windows.Forms.Button();
            TextTerminalBeep = new System.Windows.Forms.Button();
            TextTerminalReset = new System.Windows.Forms.Button();
            TextTerminalGetKeyDetail = new System.Windows.Forms.Button();
            TextTerminalRead = new System.Windows.Forms.Button();
            TextTerminalWrite = new System.Windows.Forms.Button();
            TextTerminalClearScreen = new System.Windows.Forms.Button();
            TextTerminalDeviceType = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            TextTerminalStDevice = new System.Windows.Forms.TextBox();
            TextTerminalCapabilities = new System.Windows.Forms.Button();
            TextTerminalStatus = new System.Windows.Forms.Button();
            TextTerminalServiceURI = new System.Windows.Forms.TextBox();
            TextTerminalServiceDiscovery = new System.Windows.Forms.Button();
            TextTerminalPortNum = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            TextTerminalURI = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            EncryptorTab = new System.Windows.Forms.TabPage();
            encryptorTreeView = new System.Windows.Forms.TreeView();
            encryptorRawBox = new System.Windows.Forms.TextBox();
            EncryptorDeleteKey = new System.Windows.Forms.Button();
            EncryptorGenerateMAC = new System.Windows.Forms.Button();
            EncryptorEncrypt = new System.Windows.Forms.Button();
            EncryptorGenerateRandom = new System.Windows.Forms.Button();
            EncryptorReset = new System.Windows.Forms.Button();
            EncryptorImportKey = new System.Windows.Forms.Button();
            EncryptorInitialization = new System.Windows.Forms.Button();
            EncryptorGetKeyNames = new System.Windows.Forms.Button();
            label25 = new System.Windows.Forms.Label();
            EncryptorKeyNamelistBox = new System.Windows.Forms.ListBox();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            EncryptorMaxKeyNum = new System.Windows.Forms.TextBox();
            EncryptorStDevice = new System.Windows.Forms.TextBox();
            EncryptorCapabilities = new System.Windows.Forms.Button();
            EncryptorStatus = new System.Windows.Forms.Button();
            EncryptorServiceURI = new System.Windows.Forms.TextBox();
            EncryptorServiceDiscovery = new System.Windows.Forms.Button();
            EncryptorPortNum = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            EncryptorURI = new System.Windows.Forms.TextBox();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            PinPadTab = new System.Windows.Forms.TabPage();
            pinPadTreeView = new System.Windows.Forms.TreeView();
            pinPadRawBox = new System.Windows.Forms.TextBox();
            PinPadGetLayout = new System.Windows.Forms.Button();
            PinPadEnterData = new System.Windows.Forms.Button();
            PinPadFormatPin = new System.Windows.Forms.Button();
            PinPadEnterPin = new System.Windows.Forms.Button();
            PinPadLoadPinKey = new System.Windows.Forms.Button();
            PinPadSecureKeyEntryPart2 = new System.Windows.Forms.Button();
            PinPadSecureKeyEntryPart1 = new System.Windows.Forms.Button();
            PinPadDeleteKey = new System.Windows.Forms.Button();
            PinPadReset = new System.Windows.Forms.Button();
            PinPadImportKey = new System.Windows.Forms.Button();
            PinPadInitialization = new System.Windows.Forms.Button();
            PinPadGetKeyNames = new System.Windows.Forms.Button();
            label26 = new System.Windows.Forms.Label();
            PinPadKeyNamelistBox = new System.Windows.Forms.ListBox();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            PinPadMaxKeyNum = new System.Windows.Forms.TextBox();
            PinPadStDevice = new System.Windows.Forms.TextBox();
            PinPadCapabilities = new System.Windows.Forms.Button();
            PinPadStatus = new System.Windows.Forms.Button();
            PinPadServiceURI = new System.Windows.Forms.TextBox();
            PinPadServiceDiscovery = new System.Windows.Forms.Button();
            PinPadPortNum = new System.Windows.Forms.TextBox();
            label29 = new System.Windows.Forms.Label();
            PinPadURI = new System.Windows.Forms.TextBox();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            PrinterTabPage = new System.Windows.Forms.TabPage();
            PrinterSetMedia = new System.Windows.Forms.Button();
            printerRawBox = new System.Windows.Forms.TextBox();
            printerTreeView = new System.Windows.Forms.TreeView();
            label39 = new System.Windows.Forms.Label();
            PrinterFormFields = new System.Windows.Forms.TextBox();
            PrinterSetForm = new System.Windows.Forms.Button();
            PrinterMediaListBox = new System.Windows.Forms.ListBox();
            PrinterQueryForm = new System.Windows.Forms.Button();
            PrinterEject = new System.Windows.Forms.Button();
            PrinterQueryMedia = new System.Windows.Forms.Button();
            PrinterGetMediaList = new System.Windows.Forms.Button();
            PrinterPrintForm = new System.Windows.Forms.Button();
            PrinterReset = new System.Windows.Forms.Button();
            PrinterPrintRaw = new System.Windows.Forms.Button();
            PrinterGetFormList = new System.Windows.Forms.Button();
            label33 = new System.Windows.Forms.Label();
            PrinterFormListBox = new System.Windows.Forms.ListBox();
            label34 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            PrinterType = new System.Windows.Forms.TextBox();
            PrinterStDevice = new System.Windows.Forms.TextBox();
            PrinterCapabilities = new System.Windows.Forms.Button();
            PrinterStatus = new System.Windows.Forms.Button();
            PrinterServiceURI = new System.Windows.Forms.TextBox();
            PrinterServiceDiscovery = new System.Windows.Forms.Button();
            PrinterPortNum = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            PrinterURI = new System.Windows.Forms.TextBox();
            label37 = new System.Windows.Forms.Label();
            label38 = new System.Windows.Forms.Label();
            lightsTab = new System.Windows.Forms.TabPage();
            lightsTreeView = new System.Windows.Forms.TreeView();
            lightsRawBox = new System.Windows.Forms.TextBox();
            LightsServiceDiscovery = new System.Windows.Forms.Button();
            label45 = new System.Windows.Forms.Label();
            LightsFlashRate = new System.Windows.Forms.ComboBox();
            label40 = new System.Windows.Forms.Label();
            LightsSetLight = new System.Windows.Forms.Button();
            label41 = new System.Windows.Forms.Label();
            lblLightsStatus = new System.Windows.Forms.TextBox();
            LightsCapabilities = new System.Windows.Forms.Button();
            LightsStatus = new System.Windows.Forms.Button();
            LightsServiceURI = new System.Windows.Forms.TextBox();
            LightsPortNum = new System.Windows.Forms.TextBox();
            label42 = new System.Windows.Forms.Label();
            LightsURI = new System.Windows.Forms.TextBox();
            label43 = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            auxiliariesTreeView = new System.Windows.Forms.TreeView();
            auxiliariesRawBox = new System.Windows.Forms.TextBox();
            comboAutoStartupModes = new System.Windows.Forms.ComboBox();
            btnSetAuxiliaries = new System.Windows.Forms.Button();
            btnRegister = new System.Windows.Forms.Button();
            btnClearAutoStartup = new System.Windows.Forms.Button();
            btnGetAutoStartup = new System.Windows.Forms.Button();
            btnSetAutoStartup = new System.Windows.Forms.Button();
            autoStartupDateTime = new System.Windows.Forms.DateTimePicker();
            btnAuxiliariesServiceDiscovery = new System.Windows.Forms.Button();
            label48 = new System.Windows.Forms.Label();
            AuxiliariesStatus = new System.Windows.Forms.TextBox();
            btnAuxiliariesCapabilities = new System.Windows.Forms.Button();
            btnAuxiliariesStatus = new System.Windows.Forms.Button();
            AuxiliariesServiceURI = new System.Windows.Forms.TextBox();
            AuxiliariesPortNum = new System.Windows.Forms.TextBox();
            label49 = new System.Windows.Forms.Label();
            AuxiliariesURI = new System.Windows.Forms.TextBox();
            label50 = new System.Windows.Forms.Label();
            label51 = new System.Windows.Forms.Label();
            VendorModeTabPage = new System.Windows.Forms.TabPage();
            vendorModeTreeView = new System.Windows.Forms.TreeView();
            vendorModeRawBox = new System.Windows.Forms.TextBox();
            buttonVDMExit = new System.Windows.Forms.Button();
            buttonVDMEnter = new System.Windows.Forms.Button();
            VendorModeServiceStatus = new System.Windows.Forms.TextBox();
            label58 = new System.Windows.Forms.Label();
            btnVendorModeServiceDiscovery = new System.Windows.Forms.Button();
            label46 = new System.Windows.Forms.Label();
            VendorModeStStatus = new System.Windows.Forms.TextBox();
            btnVendorModeStatus = new System.Windows.Forms.Button();
            VendorModeServiceURI = new System.Windows.Forms.TextBox();
            VendorModePortNum = new System.Windows.Forms.TextBox();
            label47 = new System.Windows.Forms.Label();
            VendorModeURI = new System.Windows.Forms.TextBox();
            label52 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            VendorAppTabPage = new System.Windows.Forms.TabPage();
            vendorApplicationTreeView = new System.Windows.Forms.TreeView();
            vendorApplicationRawBox = new System.Windows.Forms.TextBox();
            label60 = new System.Windows.Forms.Label();
            textAppName = new System.Windows.Forms.TextBox();
            label59 = new System.Windows.Forms.Label();
            textActiveInterface = new System.Windows.Forms.TextBox();
            buttonGetActiveInterface = new System.Windows.Forms.Button();
            buttonStartLocalApplication = new System.Windows.Forms.Button();
            btnVendorAppServiceDiscovery = new System.Windows.Forms.Button();
            label54 = new System.Windows.Forms.Label();
            VendorAppStatus = new System.Windows.Forms.TextBox();
            btnVendorAppCapabilities = new System.Windows.Forms.Button();
            btnVendorAppStatus = new System.Windows.Forms.Button();
            VendorAppServiceURI = new System.Windows.Forms.TextBox();
            VendorAppPortNum = new System.Windows.Forms.TextBox();
            label55 = new System.Windows.Forms.Label();
            VendorAppURI = new System.Windows.Forms.TextBox();
            label56 = new System.Windows.Forms.Label();
            label57 = new System.Windows.Forms.Label();
            BarcodeReaderTabPage = new System.Windows.Forms.TabPage();
            barcodeReaderTreeView = new System.Windows.Forms.TreeView();
            barcodeReaderRawBox = new System.Windows.Forms.TextBox();
            BarcodeReaderReset = new System.Windows.Forms.Button();
            BarcodeReaderRead = new System.Windows.Forms.Button();
            label61 = new System.Windows.Forms.Label();
            label62 = new System.Windows.Forms.Label();
            BarcodeReaderScannerStatus = new System.Windows.Forms.TextBox();
            BarcodeReaderStDevice = new System.Windows.Forms.TextBox();
            BarcodeReaderCapabilities = new System.Windows.Forms.Button();
            BarcodeReaderStatus = new System.Windows.Forms.Button();
            BarcodeReaderServiceURI = new System.Windows.Forms.TextBox();
            btnBarcodeReaderServiceDiscovery = new System.Windows.Forms.Button();
            BarcodeReaderPortNum = new System.Windows.Forms.TextBox();
            label63 = new System.Windows.Forms.Label();
            BarcodeReaderURI = new System.Windows.Forms.TextBox();
            label64 = new System.Windows.Forms.Label();
            label65 = new System.Windows.Forms.Label();
            BiometricPage = new System.Windows.Forms.TabPage();
            biometricTreeView = new System.Windows.Forms.TreeView();
            biometricRawBox = new System.Windows.Forms.TextBox();
            label77 = new System.Windows.Forms.Label();
            label76 = new System.Windows.Forms.Label();
            btnBiometricGetStorageInfo = new System.Windows.Forms.Button();
            BiometricStorageInfo = new System.Windows.Forms.ListBox();
            btnBiometricReadMatch = new System.Windows.Forms.Button();
            label71 = new System.Windows.Forms.Label();
            txtBiometricTemplateData = new System.Windows.Forms.TextBox();
            btnBiometricClear = new System.Windows.Forms.Button();
            btnBiometricMatch = new System.Windows.Forms.Button();
            btnBiometricImport = new System.Windows.Forms.Button();
            btnBiometricReset = new System.Windows.Forms.Button();
            btnBiometricRead = new System.Windows.Forms.Button();
            label67 = new System.Windows.Forms.Label();
            BiometricStatus = new System.Windows.Forms.TextBox();
            btnBiometricCapabilities = new System.Windows.Forms.Button();
            btnBiometricStatus = new System.Windows.Forms.Button();
            BiometricServiceURI = new System.Windows.Forms.TextBox();
            btnBiometricServiceDiscovery = new System.Windows.Forms.Button();
            BiometricPortNum = new System.Windows.Forms.TextBox();
            label68 = new System.Windows.Forms.Label();
            BiometricURI = new System.Windows.Forms.TextBox();
            label69 = new System.Windows.Forms.Label();
            label70 = new System.Windows.Forms.Label();
            CashAccTabPage = new System.Windows.Forms.TabPage();
            cashAcceptorTreeView = new System.Windows.Forms.TreeView();
            cashAcceptorRawBox = new System.Windows.Forms.TextBox();
            CashAccSetCashUnitInfo = new System.Windows.Forms.Button();
            CashAccRetract = new System.Windows.Forms.Button();
            CashAccCashIn = new System.Windows.Forms.Button();
            CashAccConfigureNoteTypes = new System.Windows.Forms.Button();
            CashAccCashInEnd = new System.Windows.Forms.Button();
            CashAccCashInStart = new System.Windows.Forms.Button();
            CashAccCashInRollback = new System.Windows.Forms.Button();
            CashAccEndExchange = new System.Windows.Forms.Button();
            CashAccStartExchange = new System.Windows.Forms.Button();
            CashAccReset = new System.Windows.Forms.Button();
            CashAccCashInStatus = new System.Windows.Forms.Button();
            CashAccDeviceType = new System.Windows.Forms.TextBox();
            label66 = new System.Windows.Forms.Label();
            label72 = new System.Windows.Forms.Label();
            CashAccStDevice = new System.Windows.Forms.TextBox();
            CashAccCapabilities = new System.Windows.Forms.Button();
            CashAccStatus = new System.Windows.Forms.Button();
            CashAccGetCashUnitInfo = new System.Windows.Forms.Button();
            CashAcceptorServiceURI = new System.Windows.Forms.TextBox();
            CashAcceptorServiceDiscovery = new System.Windows.Forms.Button();
            CashAcceptorPortNum = new System.Windows.Forms.TextBox();
            label73 = new System.Windows.Forms.Label();
            CashAcceptorAccURI = new System.Windows.Forms.TextBox();
            label74 = new System.Windows.Forms.Label();
            label75 = new System.Windows.Forms.Label();
            CamTabPage = new System.Windows.Forms.TabPage();
            TakePic = new System.Windows.Forms.Button();
            cameraTreeView = new System.Windows.Forms.TreeView();
            cameraRawBox = new System.Windows.Forms.TextBox();
            CameraReset = new System.Windows.Forms.Button();
            label79 = new System.Windows.Forms.Label();
            StCamera = new System.Windows.Forms.TextBox();
            CameraCapabilities = new System.Windows.Forms.Button();
            CameraStatus = new System.Windows.Forms.Button();
            CameraServiceURI = new System.Windows.Forms.TextBox();
            CameraServiceDiscovery = new System.Windows.Forms.Button();
            CameraPortNum = new System.Windows.Forms.TextBox();
            label80 = new System.Windows.Forms.Label();
            CameraURI = new System.Windows.Forms.TextBox();
            label81 = new System.Windows.Forms.Label();
            label82 = new System.Windows.Forms.Label();
            CheckTabPage = new System.Windows.Forms.TabPage();
            viewTxnStatus = new System.Windows.Forms.Button();
            checkScannerTreeView = new System.Windows.Forms.TreeView();
            checkScannerRawBox = new System.Windows.Forms.TextBox();
            CheckScannerSetCheckUnitInfo = new System.Windows.Forms.Button();
            CheckScannerRetract = new System.Windows.Forms.Button();
            CheckScannerMediaIn = new System.Windows.Forms.Button();
            CheckScannerMediaInEnd = new System.Windows.Forms.Button();
            CheckScannerMediaInRollback = new System.Windows.Forms.Button();
            CheckScannerEndExchange = new System.Windows.Forms.Button();
            CheckScannerStartExchange = new System.Windows.Forms.Button();
            CheckScannerReset = new System.Windows.Forms.Button();
            CheckScannerGetTransactionStatus = new System.Windows.Forms.Button();
            CheckDeviceType = new System.Windows.Forms.TextBox();
            label83 = new System.Windows.Forms.Label();
            label84 = new System.Windows.Forms.Label();
            StCheck = new System.Windows.Forms.TextBox();
            CheckScannerCapabilities = new System.Windows.Forms.Button();
            CheckScannerStatus = new System.Windows.Forms.Button();
            CheckScannerGetCheckUnitInfo = new System.Windows.Forms.Button();
            CheckScannerServiceURI = new System.Windows.Forms.TextBox();
            CheckScannerServiceDiscovery = new System.Windows.Forms.Button();
            CheckScannerPortNum = new System.Windows.Forms.TextBox();
            label85 = new System.Windows.Forms.Label();
            CheckScannerURI = new System.Windows.Forms.TextBox();
            label86 = new System.Windows.Forms.Label();
            label87 = new System.Windows.Forms.Label();
            comboLightDevice = new System.Windows.Forms.ComboBox();
            testClientTabControl.SuspendLayout();
            CardReaderTab.SuspendLayout();
            DispenserTab.SuspendLayout();
            TextTerminalTab.SuspendLayout();
            EncryptorTab.SuspendLayout();
            PinPadTab.SuspendLayout();
            PrinterTabPage.SuspendLayout();
            lightsTab.SuspendLayout();
            tabPage2.SuspendLayout();
            VendorModeTabPage.SuspendLayout();
            VendorAppTabPage.SuspendLayout();
            BarcodeReaderTabPage.SuspendLayout();
            BiometricPage.SuspendLayout();
            CashAccTabPage.SuspendLayout();
            CamTabPage.SuspendLayout();
            CheckTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // AcceptCard
            // 
            AcceptCard.Location = new System.Drawing.Point(1098, 25);
            AcceptCard.Margin = new System.Windows.Forms.Padding(0);
            AcceptCard.Name = "AcceptCard";
            AcceptCard.Size = new System.Drawing.Size(106, 32);
            AcceptCard.TabIndex = 0;
            AcceptCard.Text = "AcceptCard";
            AcceptCard.UseVisualStyleBackColor = true;
            AcceptCard.Click += AcceptCard_Click;
            // 
            // EjectCard
            // 
            EjectCard.Location = new System.Drawing.Point(1098, 72);
            EjectCard.Margin = new System.Windows.Forms.Padding(0);
            EjectCard.Name = "EjectCard";
            EjectCard.Size = new System.Drawing.Size(106, 32);
            EjectCard.TabIndex = 1;
            EjectCard.Text = "EjectCard";
            EjectCard.UseVisualStyleBackColor = true;
            EjectCard.Click += EjectCard_Click;
            // 
            // ServiceDiscovery
            // 
            ServiceDiscovery.Location = new System.Drawing.Point(502, 136);
            ServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            ServiceDiscovery.Name = "ServiceDiscovery";
            ServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            ServiceDiscovery.TabIndex = 3;
            ServiceDiscovery.Text = "Service Discovery";
            ServiceDiscovery.UseVisualStyleBackColor = true;
            ServiceDiscovery.Click += ServiceDiscovery_Click;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new System.Drawing.Point(114, 57);
            textBoxPort.Margin = new System.Windows.Forms.Padding(0);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.ReadOnly = true;
            textBoxPort.Size = new System.Drawing.Size(121, 27);
            textBoxPort.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 91);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 20);
            label2.TabIndex = 7;
            label2.Text = "CardReader URI";
            // 
            // textBoxCardReader
            // 
            textBoxCardReader.Location = new System.Drawing.Point(114, 88);
            textBoxCardReader.Margin = new System.Windows.Forms.Padding(0);
            textBoxCardReader.Name = "textBoxCardReader";
            textBoxCardReader.ReadOnly = true;
            textBoxCardReader.Size = new System.Drawing.Size(530, 27);
            textBoxCardReader.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 57);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 20);
            label1.TabIndex = 9;
            label1.Text = "Port Number";
            // 
            // textBoxServiceURI
            // 
            textBoxServiceURI.Location = new System.Drawing.Point(114, 25);
            textBoxServiceURI.Margin = new System.Windows.Forms.Padding(0);
            textBoxServiceURI.Name = "textBoxServiceURI";
            textBoxServiceURI.Size = new System.Drawing.Size(530, 27);
            textBoxServiceURI.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 25);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 20);
            label3.TabIndex = 11;
            label3.Text = "Service URI";
            // 
            // buttonStatus
            // 
            buttonStatus.Location = new System.Drawing.Point(955, 43);
            buttonStatus.Margin = new System.Windows.Forms.Padding(0);
            buttonStatus.Name = "buttonStatus";
            buttonStatus.Size = new System.Drawing.Size(96, 35);
            buttonStatus.TabIndex = 12;
            buttonStatus.Text = "Status";
            buttonStatus.UseVisualStyleBackColor = true;
            buttonStatus.Click += buttonStatus_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 175);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(78, 20);
            label4.TabIndex = 13;
            label4.Text = "Command";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(501, 175);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(72, 20);
            label5.TabIndex = 14;
            label5.Text = "Response";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(928, 175);
            label6.Margin = new System.Windows.Forms.Padding(0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(45, 20);
            label6.TabIndex = 16;
            label6.Text = "Event";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(715, 21);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(96, 20);
            label7.TabIndex = 17;
            label7.Text = "Device status";
            // 
            // textBoxStDevice
            // 
            textBoxStDevice.Location = new System.Drawing.Point(815, 21);
            textBoxStDevice.Margin = new System.Windows.Forms.Padding(0);
            textBoxStDevice.Name = "textBoxStDevice";
            textBoxStDevice.ReadOnly = true;
            textBoxStDevice.Size = new System.Drawing.Size(121, 27);
            textBoxStDevice.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(715, 56);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(95, 20);
            label8.TabIndex = 19;
            label8.Text = "Media Status";
            // 
            // textBoxStMedia
            // 
            textBoxStMedia.Location = new System.Drawing.Point(815, 55);
            textBoxStMedia.Margin = new System.Windows.Forms.Padding(0);
            textBoxStMedia.Name = "textBoxStMedia";
            textBoxStMedia.ReadOnly = true;
            textBoxStMedia.Size = new System.Drawing.Size(121, 27);
            textBoxStMedia.TabIndex = 20;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(955, 112);
            button1.Margin = new System.Windows.Forms.Padding(0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(96, 36);
            button1.TabIndex = 21;
            button1.Text = "Capabilities";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(723, 125);
            label9.Margin = new System.Windows.Forms.Padding(0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(87, 20);
            label9.TabIndex = 22;
            label9.Text = "Device type";
            // 
            // textBoxDeviceType
            // 
            textBoxDeviceType.Location = new System.Drawing.Point(815, 125);
            textBoxDeviceType.Margin = new System.Windows.Forms.Padding(0);
            textBoxDeviceType.Name = "textBoxDeviceType";
            textBoxDeviceType.ReadOnly = true;
            textBoxDeviceType.Size = new System.Drawing.Size(121, 27);
            textBoxDeviceType.TabIndex = 23;
            // 
            // CaptureCard
            // 
            CaptureCard.Location = new System.Drawing.Point(1098, 127);
            CaptureCard.Margin = new System.Windows.Forms.Padding(0);
            CaptureCard.Name = "CaptureCard";
            CaptureCard.Size = new System.Drawing.Size(106, 32);
            CaptureCard.TabIndex = 24;
            CaptureCard.Text = "CaptureCard";
            CaptureCard.UseVisualStyleBackColor = true;
            CaptureCard.Click += CaptureCard_Click;
            // 
            // testClientTabControl
            // 
            testClientTabControl.Controls.Add(CardReaderTab);
            testClientTabControl.Controls.Add(DispenserTab);
            testClientTabControl.Controls.Add(TextTerminalTab);
            testClientTabControl.Controls.Add(EncryptorTab);
            testClientTabControl.Controls.Add(PinPadTab);
            testClientTabControl.Controls.Add(PrinterTabPage);
            testClientTabControl.Controls.Add(lightsTab);
            testClientTabControl.Controls.Add(tabPage2);
            testClientTabControl.Controls.Add(VendorModeTabPage);
            testClientTabControl.Controls.Add(VendorAppTabPage);
            testClientTabControl.Controls.Add(BarcodeReaderTabPage);
            testClientTabControl.Controls.Add(BiometricPage);
            testClientTabControl.Controls.Add(CashAccTabPage);
            testClientTabControl.Controls.Add(CamTabPage);
            testClientTabControl.Controls.Add(CheckTabPage);
            testClientTabControl.Location = new System.Drawing.Point(8, 3);
            testClientTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            testClientTabControl.Name = "testClientTabControl";
            testClientTabControl.SelectedIndex = 0;
            testClientTabControl.Size = new System.Drawing.Size(1354, 724);
            testClientTabControl.TabIndex = 25;
            // 
            // CardReaderTab
            // 
            CardReaderTab.Controls.Add(buttonEMVClessPerformTransaction);
            CardReaderTab.Controls.Add(buttonEMVClessQueryApplications);
            CardReaderTab.Controls.Add(cardReaderRawBox);
            CardReaderTab.Controls.Add(cardReaderTreeView);
            CardReaderTab.Controls.Add(ResetBinCount);
            CardReaderTab.Controls.Add(GetStorage);
            CardReaderTab.Controls.Add(Reset);
            CardReaderTab.Controls.Add(textBoxServiceURI);
            CardReaderTab.Controls.Add(CaptureCard);
            CardReaderTab.Controls.Add(ServiceDiscovery);
            CardReaderTab.Controls.Add(textBoxDeviceType);
            CardReaderTab.Controls.Add(textBoxPort);
            CardReaderTab.Controls.Add(label9);
            CardReaderTab.Controls.Add(label2);
            CardReaderTab.Controls.Add(button1);
            CardReaderTab.Controls.Add(textBoxCardReader);
            CardReaderTab.Controls.Add(textBoxStMedia);
            CardReaderTab.Controls.Add(label1);
            CardReaderTab.Controls.Add(label8);
            CardReaderTab.Controls.Add(label3);
            CardReaderTab.Controls.Add(textBoxStDevice);
            CardReaderTab.Controls.Add(label7);
            CardReaderTab.Controls.Add(AcceptCard);
            CardReaderTab.Controls.Add(EjectCard);
            CardReaderTab.Controls.Add(buttonStatus);
            CardReaderTab.Location = new System.Drawing.Point(4, 29);
            CardReaderTab.Margin = new System.Windows.Forms.Padding(1);
            CardReaderTab.Name = "CardReaderTab";
            CardReaderTab.Padding = new System.Windows.Forms.Padding(1);
            CardReaderTab.Size = new System.Drawing.Size(1346, 691);
            CardReaderTab.TabIndex = 0;
            CardReaderTab.Text = "CardReader";
            CardReaderTab.UseVisualStyleBackColor = true;
            // 
            // buttonEMVClessPerformTransaction
            // 
            buttonEMVClessPerformTransaction.Location = new System.Drawing.Point(955, 223);
            buttonEMVClessPerformTransaction.Name = "buttonEMVClessPerformTransaction";
            buttonEMVClessPerformTransaction.Size = new System.Drawing.Size(249, 29);
            buttonEMVClessPerformTransaction.TabIndex = 132;
            buttonEMVClessPerformTransaction.Text = "EMVClessPerformTransaction";
            buttonEMVClessPerformTransaction.UseVisualStyleBackColor = true;
            buttonEMVClessPerformTransaction.Click += buttonEMVClessPerformTransaction_Click;
            // 
            // buttonEMVClessQueryApplications
            // 
            buttonEMVClessQueryApplications.Location = new System.Drawing.Point(955, 179);
            buttonEMVClessQueryApplications.Name = "buttonEMVClessQueryApplications";
            buttonEMVClessQueryApplications.Size = new System.Drawing.Size(249, 29);
            buttonEMVClessQueryApplications.TabIndex = 131;
            buttonEMVClessQueryApplications.Text = "EMVClessQueryApplications";
            buttonEMVClessQueryApplications.UseVisualStyleBackColor = true;
            buttonEMVClessQueryApplications.Click += buttonEMVClessQueryApplications_Click;
            // 
            // cardReaderRawBox
            // 
            cardReaderRawBox.Location = new System.Drawing.Point(931, 268);
            cardReaderRawBox.Multiline = true;
            cardReaderRawBox.Name = "cardReaderRawBox";
            cardReaderRawBox.ReadOnly = true;
            cardReaderRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            cardReaderRawBox.Size = new System.Drawing.Size(383, 407);
            cardReaderRawBox.TabIndex = 130;
            // 
            // cardReaderTreeView
            // 
            cardReaderTreeView.Location = new System.Drawing.Point(17, 267);
            cardReaderTreeView.Name = "cardReaderTreeView";
            cardReaderTreeView.Size = new System.Drawing.Size(893, 408);
            cardReaderTreeView.TabIndex = 129;
            // 
            // ResetBinCount
            // 
            ResetBinCount.Location = new System.Drawing.Point(1230, 72);
            ResetBinCount.Margin = new System.Windows.Forms.Padding(1);
            ResetBinCount.Name = "ResetBinCount";
            ResetBinCount.Size = new System.Drawing.Size(106, 32);
            ResetBinCount.TabIndex = 27;
            ResetBinCount.Text = "ResetBinCount";
            ResetBinCount.UseVisualStyleBackColor = true;
            ResetBinCount.Click += ResetBinCount_Click;
            // 
            // GetStorage
            // 
            GetStorage.Location = new System.Drawing.Point(1230, 127);
            GetStorage.Margin = new System.Windows.Forms.Padding(1);
            GetStorage.Name = "GetStorage";
            GetStorage.Size = new System.Drawing.Size(106, 32);
            GetStorage.TabIndex = 26;
            GetStorage.Text = "GetStorage";
            GetStorage.UseVisualStyleBackColor = true;
            GetStorage.Click += GetStorage_Click;
            // 
            // Reset
            // 
            Reset.Location = new System.Drawing.Point(1230, 25);
            Reset.Margin = new System.Windows.Forms.Padding(1);
            Reset.Name = "Reset";
            Reset.Size = new System.Drawing.Size(106, 32);
            Reset.TabIndex = 25;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += Reset_Click;
            // 
            // DispenserTab
            // 
            DispenserTab.Controls.Add(cashDispenserRawBox);
            DispenserTab.Controls.Add(cashDispenserTreeView);
            DispenserTab.Controls.Add(label78);
            DispenserTab.Controls.Add(label32);
            DispenserTab.Controls.Add(SetCashUnitInfo);
            DispenserTab.Controls.Add(DispenserRetract);
            DispenserTab.Controls.Add(DispenserReject);
            DispenserTab.Controls.Add(DispenserCloseShutter);
            DispenserTab.Controls.Add(DispenserOpenShutter);
            DispenserTab.Controls.Add(DispenserDispense);
            DispenserTab.Controls.Add(ClearCommandNonce);
            DispenserTab.Controls.Add(button2);
            DispenserTab.Controls.Add(DispenserDenominate);
            DispenserTab.Controls.Add(DispenserPresent);
            DispenserTab.Controls.Add(DispenserEndExchange);
            DispenserTab.Controls.Add(DispenserStartExchange);
            DispenserTab.Controls.Add(DispenserReset);
            DispenserTab.Controls.Add(DispenserGetPresentStatus);
            DispenserTab.Controls.Add(DispenserDeviceType);
            DispenserTab.Controls.Add(label14);
            DispenserTab.Controls.Add(label13);
            DispenserTab.Controls.Add(DispenserStDevice);
            DispenserTab.Controls.Add(DispenserGetMixTypes);
            DispenserTab.Controls.Add(DispenserCapabilities);
            DispenserTab.Controls.Add(DispenserStatus);
            DispenserTab.Controls.Add(DispenserGetCashUnitInfo);
            DispenserTab.Controls.Add(DispenserServiceURI);
            DispenserTab.Controls.Add(DispenserServiceDiscovery);
            DispenserTab.Controls.Add(DispenserPortNum);
            DispenserTab.Controls.Add(label10);
            DispenserTab.Controls.Add(NonceTextBox);
            DispenserTab.Controls.Add(TokenTextBox);
            DispenserTab.Controls.Add(DispenserDispURI);
            DispenserTab.Controls.Add(label11);
            DispenserTab.Controls.Add(label12);
            DispenserTab.Location = new System.Drawing.Point(4, 29);
            DispenserTab.Margin = new System.Windows.Forms.Padding(1);
            DispenserTab.Name = "DispenserTab";
            DispenserTab.Padding = new System.Windows.Forms.Padding(1);
            DispenserTab.Size = new System.Drawing.Size(1346, 691);
            DispenserTab.TabIndex = 1;
            DispenserTab.Text = "CashDispenser";
            DispenserTab.UseVisualStyleBackColor = true;
            // 
            // cashDispenserRawBox
            // 
            cashDispenserRawBox.Location = new System.Drawing.Point(930, 272);
            cashDispenserRawBox.Multiline = true;
            cashDispenserRawBox.Name = "cashDispenserRawBox";
            cashDispenserRawBox.ReadOnly = true;
            cashDispenserRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            cashDispenserRawBox.Size = new System.Drawing.Size(399, 408);
            cashDispenserRawBox.TabIndex = 47;
            // 
            // cashDispenserTreeView
            // 
            cashDispenserTreeView.Location = new System.Drawing.Point(18, 272);
            cashDispenserTreeView.Name = "cashDispenserTreeView";
            cashDispenserTreeView.Size = new System.Drawing.Size(894, 408);
            cashDispenserTreeView.TabIndex = 46;
            // 
            // label78
            // 
            label78.AutoSize = true;
            label78.Location = new System.Drawing.Point(696, 195);
            label78.Name = "label78";
            label78.Size = new System.Drawing.Size(170, 20);
            label78.TabIndex = 45;
            label78.Text = "GetPresentStatus Nonce:";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(18, 195);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(128, 20);
            label32.TabIndex = 45;
            label32.Text = "Command Nonce:";
            // 
            // SetCashUnitInfo
            // 
            SetCashUnitInfo.Location = new System.Drawing.Point(902, 99);
            SetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            SetCashUnitInfo.Name = "SetCashUnitInfo";
            SetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            SetCashUnitInfo.TabIndex = 44;
            SetCashUnitInfo.Text = "SetCashUnitInfo";
            SetCashUnitInfo.UseVisualStyleBackColor = true;
            SetCashUnitInfo.Click += SetCashUnitInfo_Click;
            // 
            // DispenserRetract
            // 
            DispenserRetract.Location = new System.Drawing.Point(1053, 160);
            DispenserRetract.Margin = new System.Windows.Forms.Padding(0);
            DispenserRetract.Name = "DispenserRetract";
            DispenserRetract.Size = new System.Drawing.Size(127, 28);
            DispenserRetract.TabIndex = 43;
            DispenserRetract.Text = "Retract";
            DispenserRetract.UseVisualStyleBackColor = true;
            DispenserRetract.Click += DispenserRetract_Click;
            // 
            // DispenserReject
            // 
            DispenserReject.Location = new System.Drawing.Point(1053, 121);
            DispenserReject.Margin = new System.Windows.Forms.Padding(0);
            DispenserReject.Name = "DispenserReject";
            DispenserReject.Size = new System.Drawing.Size(127, 28);
            DispenserReject.TabIndex = 42;
            DispenserReject.Text = "Reject";
            DispenserReject.UseVisualStyleBackColor = true;
            DispenserReject.Click += DispenserReject_Click;
            // 
            // DispenserCloseShutter
            // 
            DispenserCloseShutter.Location = new System.Drawing.Point(1053, 85);
            DispenserCloseShutter.Margin = new System.Windows.Forms.Padding(0);
            DispenserCloseShutter.Name = "DispenserCloseShutter";
            DispenserCloseShutter.Size = new System.Drawing.Size(127, 28);
            DispenserCloseShutter.TabIndex = 41;
            DispenserCloseShutter.Text = "CloseShutter";
            DispenserCloseShutter.UseVisualStyleBackColor = true;
            DispenserCloseShutter.Click += DispenserCloseShutter_Click;
            // 
            // DispenserOpenShutter
            // 
            DispenserOpenShutter.Location = new System.Drawing.Point(1053, 48);
            DispenserOpenShutter.Margin = new System.Windows.Forms.Padding(0);
            DispenserOpenShutter.Name = "DispenserOpenShutter";
            DispenserOpenShutter.Size = new System.Drawing.Size(127, 29);
            DispenserOpenShutter.TabIndex = 40;
            DispenserOpenShutter.Text = "OpenShutter";
            DispenserOpenShutter.UseVisualStyleBackColor = true;
            DispenserOpenShutter.Click += DispenserOpenShutter_Click;
            // 
            // DispenserDispense
            // 
            DispenserDispense.Location = new System.Drawing.Point(1202, 159);
            DispenserDispense.Margin = new System.Windows.Forms.Padding(0);
            DispenserDispense.Name = "DispenserDispense";
            DispenserDispense.Size = new System.Drawing.Size(127, 29);
            DispenserDispense.TabIndex = 39;
            DispenserDispense.Text = "Dispense";
            DispenserDispense.UseVisualStyleBackColor = true;
            DispenserDispense.Click += DispenserDispense_Click;
            // 
            // ClearCommandNonce
            // 
            ClearCommandNonce.Location = new System.Drawing.Point(190, 160);
            ClearCommandNonce.Margin = new System.Windows.Forms.Padding(0);
            ClearCommandNonce.Name = "ClearCommandNonce";
            ClearCommandNonce.Size = new System.Drawing.Size(163, 31);
            ClearCommandNonce.TabIndex = 38;
            ClearCommandNonce.Text = "ClearCommandNonce";
            ClearCommandNonce.UseVisualStyleBackColor = true;
            ClearCommandNonce.Click += DispenserClearCommandNonce_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(18, 160);
            button2.Margin = new System.Windows.Forms.Padding(0);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(158, 31);
            button2.TabIndex = 38;
            button2.Text = "GetCommandNonce";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DispenserGetCommandNonce_Click;
            // 
            // DispenserDenominate
            // 
            DispenserDenominate.Location = new System.Drawing.Point(1202, 120);
            DispenserDenominate.Margin = new System.Windows.Forms.Padding(0);
            DispenserDenominate.Name = "DispenserDenominate";
            DispenserDenominate.Size = new System.Drawing.Size(127, 29);
            DispenserDenominate.TabIndex = 38;
            DispenserDenominate.Text = "Denominate";
            DispenserDenominate.UseVisualStyleBackColor = true;
            DispenserDenominate.Click += DispenserDenominate_Click;
            // 
            // DispenserPresent
            // 
            DispenserPresent.Location = new System.Drawing.Point(1202, 199);
            DispenserPresent.Margin = new System.Windows.Forms.Padding(0);
            DispenserPresent.Name = "DispenserPresent";
            DispenserPresent.Size = new System.Drawing.Size(127, 29);
            DispenserPresent.TabIndex = 37;
            DispenserPresent.Text = "Present";
            DispenserPresent.UseVisualStyleBackColor = true;
            DispenserPresent.Click += DispenserPresent_Click;
            // 
            // DispenserEndExchange
            // 
            DispenserEndExchange.Location = new System.Drawing.Point(1202, 48);
            DispenserEndExchange.Margin = new System.Windows.Forms.Padding(0);
            DispenserEndExchange.Name = "DispenserEndExchange";
            DispenserEndExchange.Size = new System.Drawing.Size(127, 29);
            DispenserEndExchange.TabIndex = 36;
            DispenserEndExchange.Text = "EndExchange";
            DispenserEndExchange.UseVisualStyleBackColor = true;
            DispenserEndExchange.Click += DispenserEndExchange_Click;
            // 
            // DispenserStartExchange
            // 
            DispenserStartExchange.Location = new System.Drawing.Point(1202, 11);
            DispenserStartExchange.Margin = new System.Windows.Forms.Padding(0);
            DispenserStartExchange.Name = "DispenserStartExchange";
            DispenserStartExchange.Size = new System.Drawing.Size(127, 29);
            DispenserStartExchange.TabIndex = 35;
            DispenserStartExchange.Text = "StartExchange";
            DispenserStartExchange.UseVisualStyleBackColor = true;
            DispenserStartExchange.Click += DispenserStartExchange_Click;
            // 
            // DispenserReset
            // 
            DispenserReset.Location = new System.Drawing.Point(1053, 11);
            DispenserReset.Margin = new System.Windows.Forms.Padding(0);
            DispenserReset.Name = "DispenserReset";
            DispenserReset.Size = new System.Drawing.Size(127, 29);
            DispenserReset.TabIndex = 34;
            DispenserReset.Text = "Reset";
            DispenserReset.UseVisualStyleBackColor = true;
            DispenserReset.Click += DispenserReset_Click;
            // 
            // DispenserGetPresentStatus
            // 
            DispenserGetPresentStatus.Location = new System.Drawing.Point(902, 217);
            DispenserGetPresentStatus.Margin = new System.Windows.Forms.Padding(0);
            DispenserGetPresentStatus.Name = "DispenserGetPresentStatus";
            DispenserGetPresentStatus.Size = new System.Drawing.Size(127, 29);
            DispenserGetPresentStatus.TabIndex = 33;
            DispenserGetPresentStatus.Text = "GetPresentStatus";
            DispenserGetPresentStatus.UseVisualStyleBackColor = true;
            DispenserGetPresentStatus.Click += DispenserGetPresentStatus_Click;
            // 
            // DispenserDeviceType
            // 
            DispenserDeviceType.Location = new System.Drawing.Point(791, 57);
            DispenserDeviceType.Margin = new System.Windows.Forms.Padding(0);
            DispenserDeviceType.Name = "DispenserDeviceType";
            DispenserDeviceType.ReadOnly = true;
            DispenserDeviceType.Size = new System.Drawing.Size(121, 27);
            DispenserDeviceType.TabIndex = 32;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(696, 60);
            label14.Margin = new System.Windows.Forms.Padding(0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(87, 20);
            label14.TabIndex = 31;
            label14.Text = "Device type";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(696, 15);
            label13.Margin = new System.Windows.Forms.Padding(0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(96, 20);
            label13.TabIndex = 26;
            label13.Text = "Device status";
            // 
            // DispenserStDevice
            // 
            DispenserStDevice.Location = new System.Drawing.Point(791, 16);
            DispenserStDevice.Margin = new System.Windows.Forms.Padding(0);
            DispenserStDevice.Name = "DispenserStDevice";
            DispenserStDevice.ReadOnly = true;
            DispenserStDevice.Size = new System.Drawing.Size(121, 27);
            DispenserStDevice.TabIndex = 30;
            // 
            // DispenserGetMixTypes
            // 
            DispenserGetMixTypes.Location = new System.Drawing.Point(902, 179);
            DispenserGetMixTypes.Margin = new System.Windows.Forms.Padding(0);
            DispenserGetMixTypes.Name = "DispenserGetMixTypes";
            DispenserGetMixTypes.Size = new System.Drawing.Size(127, 29);
            DispenserGetMixTypes.TabIndex = 29;
            DispenserGetMixTypes.Text = "GetMixTypes";
            DispenserGetMixTypes.UseVisualStyleBackColor = true;
            DispenserGetMixTypes.Click += DispenserGetMixTypes_Click;
            // 
            // DispenserCapabilities
            // 
            DispenserCapabilities.Location = new System.Drawing.Point(926, 48);
            DispenserCapabilities.Margin = new System.Windows.Forms.Padding(0);
            DispenserCapabilities.Name = "DispenserCapabilities";
            DispenserCapabilities.Size = new System.Drawing.Size(103, 29);
            DispenserCapabilities.TabIndex = 28;
            DispenserCapabilities.Text = "Capabilities";
            DispenserCapabilities.UseVisualStyleBackColor = true;
            DispenserCapabilities.Click += DispenserCapabilities_Click;
            // 
            // DispenserStatus
            // 
            DispenserStatus.Location = new System.Drawing.Point(926, 11);
            DispenserStatus.Margin = new System.Windows.Forms.Padding(0);
            DispenserStatus.Name = "DispenserStatus";
            DispenserStatus.Size = new System.Drawing.Size(103, 29);
            DispenserStatus.TabIndex = 27;
            DispenserStatus.Text = "Status";
            DispenserStatus.UseVisualStyleBackColor = true;
            DispenserStatus.Click += DispenserStatus_Click;
            // 
            // DispenserGetCashUnitInfo
            // 
            DispenserGetCashUnitInfo.Location = new System.Drawing.Point(902, 139);
            DispenserGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            DispenserGetCashUnitInfo.Name = "DispenserGetCashUnitInfo";
            DispenserGetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            DispenserGetCashUnitInfo.TabIndex = 26;
            DispenserGetCashUnitInfo.Text = "GetCashUnitInfo";
            DispenserGetCashUnitInfo.UseVisualStyleBackColor = true;
            DispenserGetCashUnitInfo.Click += DispenserGetCashUnitInfo_Click;
            // 
            // DispenserServiceURI
            // 
            DispenserServiceURI.Location = new System.Drawing.Point(114, 25);
            DispenserServiceURI.Margin = new System.Windows.Forms.Padding(0);
            DispenserServiceURI.Name = "DispenserServiceURI";
            DispenserServiceURI.Size = new System.Drawing.Size(530, 27);
            DispenserServiceURI.TabIndex = 23;
            // 
            // DispenserServiceDiscovery
            // 
            DispenserServiceDiscovery.Location = new System.Drawing.Point(502, 136);
            DispenserServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            DispenserServiceDiscovery.Name = "DispenserServiceDiscovery";
            DispenserServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            DispenserServiceDiscovery.TabIndex = 17;
            DispenserServiceDiscovery.Text = "Service Discovery";
            DispenserServiceDiscovery.UseVisualStyleBackColor = true;
            DispenserServiceDiscovery.Click += DispenserServiceDiscovery_Click;
            // 
            // DispenserPortNum
            // 
            DispenserPortNum.Location = new System.Drawing.Point(114, 57);
            DispenserPortNum.Margin = new System.Windows.Forms.Padding(0);
            DispenserPortNum.Name = "DispenserPortNum";
            DispenserPortNum.ReadOnly = true;
            DispenserPortNum.Size = new System.Drawing.Size(121, 27);
            DispenserPortNum.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(5, 91);
            label10.Margin = new System.Windows.Forms.Padding(0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(101, 20);
            label10.TabIndex = 20;
            label10.Text = "Dispenser URI";
            // 
            // NonceTextBox
            // 
            NonceTextBox.Location = new System.Drawing.Point(696, 219);
            NonceTextBox.Margin = new System.Windows.Forms.Padding(0);
            NonceTextBox.Name = "NonceTextBox";
            NonceTextBox.Size = new System.Drawing.Size(187, 27);
            NonceTextBox.TabIndex = 21;
            // 
            // TokenTextBox
            // 
            TokenTextBox.Location = new System.Drawing.Point(18, 219);
            TokenTextBox.Margin = new System.Windows.Forms.Padding(0);
            TokenTextBox.Name = "TokenTextBox";
            TokenTextBox.ReadOnly = true;
            TokenTextBox.Size = new System.Drawing.Size(660, 27);
            TokenTextBox.TabIndex = 21;
            // 
            // DispenserDispURI
            // 
            DispenserDispURI.Location = new System.Drawing.Point(114, 88);
            DispenserDispURI.Margin = new System.Windows.Forms.Padding(0);
            DispenserDispURI.Name = "DispenserDispURI";
            DispenserDispURI.ReadOnly = true;
            DispenserDispURI.Size = new System.Drawing.Size(530, 27);
            DispenserDispURI.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(7, 57);
            label11.Margin = new System.Windows.Forms.Padding(0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(93, 20);
            label11.TabIndex = 22;
            label11.Text = "Port Number";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(7, 25);
            label12.Margin = new System.Windows.Forms.Padding(0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(83, 20);
            label12.TabIndex = 24;
            label12.Text = "Service URI";
            // 
            // TextTerminalTab
            // 
            TextTerminalTab.Controls.Add(textTerminalRawBox);
            TextTerminalTab.Controls.Add(textTerminalTreeView);
            TextTerminalTab.Controls.Add(TextTerminalSetResolution);
            TextTerminalTab.Controls.Add(TextTerminalBeep);
            TextTerminalTab.Controls.Add(TextTerminalReset);
            TextTerminalTab.Controls.Add(TextTerminalGetKeyDetail);
            TextTerminalTab.Controls.Add(TextTerminalRead);
            TextTerminalTab.Controls.Add(TextTerminalWrite);
            TextTerminalTab.Controls.Add(TextTerminalClearScreen);
            TextTerminalTab.Controls.Add(TextTerminalDeviceType);
            TextTerminalTab.Controls.Add(label15);
            TextTerminalTab.Controls.Add(label16);
            TextTerminalTab.Controls.Add(TextTerminalStDevice);
            TextTerminalTab.Controls.Add(TextTerminalCapabilities);
            TextTerminalTab.Controls.Add(TextTerminalStatus);
            TextTerminalTab.Controls.Add(TextTerminalServiceURI);
            TextTerminalTab.Controls.Add(TextTerminalServiceDiscovery);
            TextTerminalTab.Controls.Add(TextTerminalPortNum);
            TextTerminalTab.Controls.Add(label17);
            TextTerminalTab.Controls.Add(TextTerminalURI);
            TextTerminalTab.Controls.Add(label18);
            TextTerminalTab.Controls.Add(label19);
            TextTerminalTab.Location = new System.Drawing.Point(4, 29);
            TextTerminalTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TextTerminalTab.Name = "TextTerminalTab";
            TextTerminalTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            TextTerminalTab.Size = new System.Drawing.Size(1346, 691);
            TextTerminalTab.TabIndex = 2;
            TextTerminalTab.Text = "Text Terminal";
            TextTerminalTab.UseVisualStyleBackColor = true;
            // 
            // textTerminalRawBox
            // 
            textTerminalRawBox.Location = new System.Drawing.Point(927, 269);
            textTerminalRawBox.Multiline = true;
            textTerminalRawBox.Name = "textTerminalRawBox";
            textTerminalRawBox.ReadOnly = true;
            textTerminalRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textTerminalRawBox.Size = new System.Drawing.Size(401, 408);
            textTerminalRawBox.TabIndex = 61;
            // 
            // textTerminalTreeView
            // 
            textTerminalTreeView.Location = new System.Drawing.Point(8, 269);
            textTerminalTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textTerminalTreeView.Name = "textTerminalTreeView";
            textTerminalTreeView.Size = new System.Drawing.Size(905, 408);
            textTerminalTreeView.TabIndex = 60;
            // 
            // TextTerminalSetResolution
            // 
            TextTerminalSetResolution.Location = new System.Drawing.Point(1202, 107);
            TextTerminalSetResolution.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalSetResolution.Name = "TextTerminalSetResolution";
            TextTerminalSetResolution.Size = new System.Drawing.Size(127, 29);
            TextTerminalSetResolution.TabIndex = 59;
            TextTerminalSetResolution.Text = "SetResolution";
            TextTerminalSetResolution.UseVisualStyleBackColor = true;
            TextTerminalSetResolution.Click += TextTerminalSetResolution_Click;
            // 
            // TextTerminalBeep
            // 
            TextTerminalBeep.Location = new System.Drawing.Point(1073, 43);
            TextTerminalBeep.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalBeep.Name = "TextTerminalBeep";
            TextTerminalBeep.Size = new System.Drawing.Size(127, 29);
            TextTerminalBeep.TabIndex = 56;
            TextTerminalBeep.Text = "Beep";
            TextTerminalBeep.UseVisualStyleBackColor = true;
            TextTerminalBeep.Click += TextTerminalBeep_Click;
            // 
            // TextTerminalReset
            // 
            TextTerminalReset.Location = new System.Drawing.Point(1073, 11);
            TextTerminalReset.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalReset.Name = "TextTerminalReset";
            TextTerminalReset.Size = new System.Drawing.Size(127, 29);
            TextTerminalReset.TabIndex = 53;
            TextTerminalReset.Text = "Reset";
            TextTerminalReset.UseVisualStyleBackColor = true;
            TextTerminalReset.Click += TextTerminalReset_Click;
            // 
            // TextTerminalGetKeyDetail
            // 
            TextTerminalGetKeyDetail.Location = new System.Drawing.Point(1073, 75);
            TextTerminalGetKeyDetail.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalGetKeyDetail.Name = "TextTerminalGetKeyDetail";
            TextTerminalGetKeyDetail.Size = new System.Drawing.Size(127, 29);
            TextTerminalGetKeyDetail.TabIndex = 52;
            TextTerminalGetKeyDetail.Text = "GetKeyDetail";
            TextTerminalGetKeyDetail.UseVisualStyleBackColor = true;
            TextTerminalGetKeyDetail.Click += TextTerminalGetKeyDetail_Click;
            // 
            // TextTerminalRead
            // 
            TextTerminalRead.Location = new System.Drawing.Point(1202, 75);
            TextTerminalRead.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalRead.Name = "TextTerminalRead";
            TextTerminalRead.Size = new System.Drawing.Size(127, 29);
            TextTerminalRead.TabIndex = 51;
            TextTerminalRead.Text = "Read";
            TextTerminalRead.UseVisualStyleBackColor = true;
            TextTerminalRead.Click += TextTerminalRead_Click;
            // 
            // TextTerminalWrite
            // 
            TextTerminalWrite.Location = new System.Drawing.Point(1202, 43);
            TextTerminalWrite.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalWrite.Name = "TextTerminalWrite";
            TextTerminalWrite.Size = new System.Drawing.Size(127, 29);
            TextTerminalWrite.TabIndex = 50;
            TextTerminalWrite.Text = "Write";
            TextTerminalWrite.UseVisualStyleBackColor = true;
            TextTerminalWrite.Click += TextTerminalWrite_Click;
            // 
            // TextTerminalClearScreen
            // 
            TextTerminalClearScreen.Location = new System.Drawing.Point(1202, 11);
            TextTerminalClearScreen.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalClearScreen.Name = "TextTerminalClearScreen";
            TextTerminalClearScreen.Size = new System.Drawing.Size(127, 29);
            TextTerminalClearScreen.TabIndex = 49;
            TextTerminalClearScreen.Text = "ClearScreen";
            TextTerminalClearScreen.UseVisualStyleBackColor = true;
            TextTerminalClearScreen.Click += TextTerminalClearScreen_Click;
            // 
            // TextTerminalDeviceType
            // 
            TextTerminalDeviceType.Location = new System.Drawing.Point(792, 55);
            TextTerminalDeviceType.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalDeviceType.Name = "TextTerminalDeviceType";
            TextTerminalDeviceType.ReadOnly = true;
            TextTerminalDeviceType.Size = new System.Drawing.Size(121, 27);
            TextTerminalDeviceType.TabIndex = 48;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(697, 57);
            label15.Margin = new System.Windows.Forms.Padding(0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(87, 20);
            label15.TabIndex = 47;
            label15.Text = "Device type";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(697, 12);
            label16.Margin = new System.Windows.Forms.Padding(0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(96, 20);
            label16.TabIndex = 43;
            label16.Text = "Device status";
            // 
            // TextTerminalStDevice
            // 
            TextTerminalStDevice.Location = new System.Drawing.Point(792, 13);
            TextTerminalStDevice.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalStDevice.Name = "TextTerminalStDevice";
            TextTerminalStDevice.ReadOnly = true;
            TextTerminalStDevice.Size = new System.Drawing.Size(121, 27);
            TextTerminalStDevice.TabIndex = 46;
            // 
            // TextTerminalCapabilities
            // 
            TextTerminalCapabilities.Location = new System.Drawing.Point(927, 45);
            TextTerminalCapabilities.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalCapabilities.Name = "TextTerminalCapabilities";
            TextTerminalCapabilities.Size = new System.Drawing.Size(103, 29);
            TextTerminalCapabilities.TabIndex = 45;
            TextTerminalCapabilities.Text = "Capabilities";
            TextTerminalCapabilities.UseVisualStyleBackColor = true;
            TextTerminalCapabilities.Click += TextTerminalCapabilities_Click;
            // 
            // TextTerminalStatus
            // 
            TextTerminalStatus.Location = new System.Drawing.Point(927, 8);
            TextTerminalStatus.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalStatus.Name = "TextTerminalStatus";
            TextTerminalStatus.Size = new System.Drawing.Size(103, 29);
            TextTerminalStatus.TabIndex = 44;
            TextTerminalStatus.Text = "Status";
            TextTerminalStatus.UseVisualStyleBackColor = true;
            TextTerminalStatus.Click += TextTerminalStatus_Click;
            // 
            // TextTerminalServiceURI
            // 
            TextTerminalServiceURI.Location = new System.Drawing.Point(115, 23);
            TextTerminalServiceURI.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalServiceURI.Name = "TextTerminalServiceURI";
            TextTerminalServiceURI.Size = new System.Drawing.Size(530, 27);
            TextTerminalServiceURI.TabIndex = 40;
            // 
            // TextTerminalServiceDiscovery
            // 
            TextTerminalServiceDiscovery.Location = new System.Drawing.Point(503, 133);
            TextTerminalServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalServiceDiscovery.Name = "TextTerminalServiceDiscovery";
            TextTerminalServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            TextTerminalServiceDiscovery.TabIndex = 34;
            TextTerminalServiceDiscovery.Text = "Service Discovery";
            TextTerminalServiceDiscovery.UseVisualStyleBackColor = true;
            TextTerminalServiceDiscovery.Click += TextTerminalServiceDiscovery_Click;
            // 
            // TextTerminalPortNum
            // 
            TextTerminalPortNum.Location = new System.Drawing.Point(115, 55);
            TextTerminalPortNum.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalPortNum.Name = "TextTerminalPortNum";
            TextTerminalPortNum.ReadOnly = true;
            TextTerminalPortNum.Size = new System.Drawing.Size(121, 27);
            TextTerminalPortNum.TabIndex = 35;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 88);
            label17.Margin = new System.Windows.Forms.Padding(0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(120, 20);
            label17.TabIndex = 37;
            label17.Text = "TextTerminal URI";
            // 
            // TextTerminalURI
            // 
            TextTerminalURI.Location = new System.Drawing.Point(115, 85);
            TextTerminalURI.Margin = new System.Windows.Forms.Padding(0);
            TextTerminalURI.Name = "TextTerminalURI";
            TextTerminalURI.ReadOnly = true;
            TextTerminalURI.Size = new System.Drawing.Size(530, 27);
            TextTerminalURI.TabIndex = 38;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(8, 55);
            label18.Margin = new System.Windows.Forms.Padding(0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(93, 20);
            label18.TabIndex = 39;
            label18.Text = "Port Number";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(8, 23);
            label19.Margin = new System.Windows.Forms.Padding(0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(83, 20);
            label19.TabIndex = 41;
            label19.Text = "Service URI";
            // 
            // EncryptorTab
            // 
            EncryptorTab.Controls.Add(encryptorTreeView);
            EncryptorTab.Controls.Add(encryptorRawBox);
            EncryptorTab.Controls.Add(EncryptorDeleteKey);
            EncryptorTab.Controls.Add(EncryptorGenerateMAC);
            EncryptorTab.Controls.Add(EncryptorEncrypt);
            EncryptorTab.Controls.Add(EncryptorGenerateRandom);
            EncryptorTab.Controls.Add(EncryptorReset);
            EncryptorTab.Controls.Add(EncryptorImportKey);
            EncryptorTab.Controls.Add(EncryptorInitialization);
            EncryptorTab.Controls.Add(EncryptorGetKeyNames);
            EncryptorTab.Controls.Add(label25);
            EncryptorTab.Controls.Add(EncryptorKeyNamelistBox);
            EncryptorTab.Controls.Add(label23);
            EncryptorTab.Controls.Add(label24);
            EncryptorTab.Controls.Add(EncryptorMaxKeyNum);
            EncryptorTab.Controls.Add(EncryptorStDevice);
            EncryptorTab.Controls.Add(EncryptorCapabilities);
            EncryptorTab.Controls.Add(EncryptorStatus);
            EncryptorTab.Controls.Add(EncryptorServiceURI);
            EncryptorTab.Controls.Add(EncryptorServiceDiscovery);
            EncryptorTab.Controls.Add(EncryptorPortNum);
            EncryptorTab.Controls.Add(label20);
            EncryptorTab.Controls.Add(EncryptorURI);
            EncryptorTab.Controls.Add(label21);
            EncryptorTab.Controls.Add(label22);
            EncryptorTab.Location = new System.Drawing.Point(4, 29);
            EncryptorTab.Margin = new System.Windows.Forms.Padding(0);
            EncryptorTab.Name = "EncryptorTab";
            EncryptorTab.Size = new System.Drawing.Size(1346, 691);
            EncryptorTab.TabIndex = 3;
            EncryptorTab.Text = "Encryptor";
            EncryptorTab.UseVisualStyleBackColor = true;
            // 
            // encryptorTreeView
            // 
            encryptorTreeView.Location = new System.Drawing.Point(16, 269);
            encryptorTreeView.Name = "encryptorTreeView";
            encryptorTreeView.Size = new System.Drawing.Size(893, 408);
            encryptorTreeView.TabIndex = 61;
            // 
            // encryptorRawBox
            // 
            encryptorRawBox.Location = new System.Drawing.Point(930, 269);
            encryptorRawBox.Multiline = true;
            encryptorRawBox.Name = "encryptorRawBox";
            encryptorRawBox.ReadOnly = true;
            encryptorRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            encryptorRawBox.Size = new System.Drawing.Size(405, 408);
            encryptorRawBox.TabIndex = 60;
            // 
            // EncryptorDeleteKey
            // 
            EncryptorDeleteKey.Location = new System.Drawing.Point(1213, 55);
            EncryptorDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            EncryptorDeleteKey.Name = "EncryptorDeleteKey";
            EncryptorDeleteKey.Size = new System.Drawing.Size(97, 28);
            EncryptorDeleteKey.TabIndex = 59;
            EncryptorDeleteKey.Text = "DeleteKey";
            EncryptorDeleteKey.UseVisualStyleBackColor = true;
            EncryptorDeleteKey.Click += EncryptorDeleteKey_Click;
            // 
            // EncryptorGenerateMAC
            // 
            EncryptorGenerateMAC.Location = new System.Drawing.Point(1096, 144);
            EncryptorGenerateMAC.Margin = new System.Windows.Forms.Padding(0);
            EncryptorGenerateMAC.Name = "EncryptorGenerateMAC";
            EncryptorGenerateMAC.Size = new System.Drawing.Size(106, 35);
            EncryptorGenerateMAC.TabIndex = 58;
            EncryptorGenerateMAC.Text = "GenerateMAC";
            EncryptorGenerateMAC.UseVisualStyleBackColor = true;
            EncryptorGenerateMAC.Click += EncryptorGenerateMAC_Click;
            // 
            // EncryptorEncrypt
            // 
            EncryptorEncrypt.Location = new System.Drawing.Point(1096, 99);
            EncryptorEncrypt.Margin = new System.Windows.Forms.Padding(0);
            EncryptorEncrypt.Name = "EncryptorEncrypt";
            EncryptorEncrypt.Size = new System.Drawing.Size(106, 29);
            EncryptorEncrypt.TabIndex = 57;
            EncryptorEncrypt.Text = "Encrypt";
            EncryptorEncrypt.UseVisualStyleBackColor = true;
            EncryptorEncrypt.Click += EncryptorEncrypt_Click;
            // 
            // EncryptorGenerateRandom
            // 
            EncryptorGenerateRandom.Location = new System.Drawing.Point(1096, 192);
            EncryptorGenerateRandom.Margin = new System.Windows.Forms.Padding(0);
            EncryptorGenerateRandom.Name = "EncryptorGenerateRandom";
            EncryptorGenerateRandom.Size = new System.Drawing.Size(130, 32);
            EncryptorGenerateRandom.TabIndex = 56;
            EncryptorGenerateRandom.Text = "GenerateRandom";
            EncryptorGenerateRandom.UseVisualStyleBackColor = true;
            EncryptorGenerateRandom.Click += EncryptorGenerateRandom_Click;
            // 
            // EncryptorReset
            // 
            EncryptorReset.Location = new System.Drawing.Point(1213, 13);
            EncryptorReset.Margin = new System.Windows.Forms.Padding(0);
            EncryptorReset.Name = "EncryptorReset";
            EncryptorReset.Size = new System.Drawing.Size(97, 29);
            EncryptorReset.TabIndex = 55;
            EncryptorReset.Text = "Reset";
            EncryptorReset.UseVisualStyleBackColor = true;
            EncryptorReset.Click += EncryptorReset_Click;
            // 
            // EncryptorImportKey
            // 
            EncryptorImportKey.Location = new System.Drawing.Point(1096, 55);
            EncryptorImportKey.Margin = new System.Windows.Forms.Padding(0);
            EncryptorImportKey.Name = "EncryptorImportKey";
            EncryptorImportKey.Size = new System.Drawing.Size(105, 28);
            EncryptorImportKey.TabIndex = 54;
            EncryptorImportKey.Text = "ImportKey";
            EncryptorImportKey.UseVisualStyleBackColor = true;
            EncryptorImportKey.Click += EncryptorImportKey_Click;
            // 
            // EncryptorInitialization
            // 
            EncryptorInitialization.Location = new System.Drawing.Point(1096, 13);
            EncryptorInitialization.Margin = new System.Windows.Forms.Padding(0);
            EncryptorInitialization.Name = "EncryptorInitialization";
            EncryptorInitialization.Size = new System.Drawing.Size(105, 29);
            EncryptorInitialization.TabIndex = 53;
            EncryptorInitialization.Text = "Initialization";
            EncryptorInitialization.UseVisualStyleBackColor = true;
            EncryptorInitialization.Click += EncryptorInitialization_Click;
            // 
            // EncryptorGetKeyNames
            // 
            EncryptorGetKeyNames.Location = new System.Drawing.Point(930, 147);
            EncryptorGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            EncryptorGetKeyNames.Name = "EncryptorGetKeyNames";
            EncryptorGetKeyNames.Size = new System.Drawing.Size(103, 31);
            EncryptorGetKeyNames.TabIndex = 52;
            EncryptorGetKeyNames.Text = "GetKeyNames";
            EncryptorGetKeyNames.UseVisualStyleBackColor = true;
            EncryptorGetKeyNames.Click += EncryptorGetKeyNames_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(677, 119);
            label25.Margin = new System.Windows.Forms.Padding(0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(83, 20);
            label25.TabIndex = 51;
            label25.Text = "Key Names";
            // 
            // EncryptorKeyNamelistBox
            // 
            EncryptorKeyNamelistBox.FormattingEnabled = true;
            EncryptorKeyNamelistBox.Location = new System.Drawing.Point(677, 147);
            EncryptorKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            EncryptorKeyNamelistBox.Name = "EncryptorKeyNamelistBox";
            EncryptorKeyNamelistBox.Size = new System.Drawing.Size(244, 104);
            EncryptorKeyNamelistBox.TabIndex = 50;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(677, 63);
            label23.Margin = new System.Windows.Forms.Padding(0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(118, 20);
            label23.TabIndex = 49;
            label23.Text = "Max key number";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(698, 19);
            label24.Margin = new System.Windows.Forms.Padding(0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(96, 20);
            label24.TabIndex = 48;
            label24.Text = "Device status";
            // 
            // EncryptorMaxKeyNum
            // 
            EncryptorMaxKeyNum.Location = new System.Drawing.Point(795, 60);
            EncryptorMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            EncryptorMaxKeyNum.Name = "EncryptorMaxKeyNum";
            EncryptorMaxKeyNum.ReadOnly = true;
            EncryptorMaxKeyNum.Size = new System.Drawing.Size(121, 27);
            EncryptorMaxKeyNum.TabIndex = 43;
            // 
            // EncryptorStDevice
            // 
            EncryptorStDevice.Location = new System.Drawing.Point(795, 19);
            EncryptorStDevice.Margin = new System.Windows.Forms.Padding(0);
            EncryptorStDevice.Name = "EncryptorStDevice";
            EncryptorStDevice.ReadOnly = true;
            EncryptorStDevice.Size = new System.Drawing.Size(121, 27);
            EncryptorStDevice.TabIndex = 42;
            // 
            // EncryptorCapabilities
            // 
            EncryptorCapabilities.Location = new System.Drawing.Point(930, 51);
            EncryptorCapabilities.Margin = new System.Windows.Forms.Padding(0);
            EncryptorCapabilities.Name = "EncryptorCapabilities";
            EncryptorCapabilities.Size = new System.Drawing.Size(103, 29);
            EncryptorCapabilities.TabIndex = 41;
            EncryptorCapabilities.Text = "Capabilities";
            EncryptorCapabilities.UseVisualStyleBackColor = true;
            EncryptorCapabilities.Click += EncryptorCapabilities_Click;
            // 
            // EncryptorStatus
            // 
            EncryptorStatus.Location = new System.Drawing.Point(930, 13);
            EncryptorStatus.Margin = new System.Windows.Forms.Padding(0);
            EncryptorStatus.Name = "EncryptorStatus";
            EncryptorStatus.Size = new System.Drawing.Size(103, 29);
            EncryptorStatus.TabIndex = 40;
            EncryptorStatus.Text = "Status";
            EncryptorStatus.UseVisualStyleBackColor = true;
            EncryptorStatus.Click += EncryptorStatus_Click;
            // 
            // EncryptorServiceURI
            // 
            EncryptorServiceURI.Location = new System.Drawing.Point(117, 16);
            EncryptorServiceURI.Margin = new System.Windows.Forms.Padding(0);
            EncryptorServiceURI.Name = "EncryptorServiceURI";
            EncryptorServiceURI.Size = new System.Drawing.Size(530, 27);
            EncryptorServiceURI.TabIndex = 38;
            // 
            // EncryptorServiceDiscovery
            // 
            EncryptorServiceDiscovery.Location = new System.Drawing.Point(504, 127);
            EncryptorServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            EncryptorServiceDiscovery.Name = "EncryptorServiceDiscovery";
            EncryptorServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            EncryptorServiceDiscovery.TabIndex = 33;
            EncryptorServiceDiscovery.Text = "Service Discovery";
            EncryptorServiceDiscovery.UseVisualStyleBackColor = true;
            EncryptorServiceDiscovery.Click += EncryptorServiceDiscovery_Click;
            // 
            // EncryptorPortNum
            // 
            EncryptorPortNum.Location = new System.Drawing.Point(117, 49);
            EncryptorPortNum.Margin = new System.Windows.Forms.Padding(0);
            EncryptorPortNum.Name = "EncryptorPortNum";
            EncryptorPortNum.ReadOnly = true;
            EncryptorPortNum.Size = new System.Drawing.Size(121, 27);
            EncryptorPortNum.TabIndex = 34;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(7, 81);
            label20.Margin = new System.Windows.Forms.Padding(0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(99, 20);
            label20.TabIndex = 35;
            label20.Text = "Encryptor URI";
            // 
            // EncryptorURI
            // 
            EncryptorURI.Location = new System.Drawing.Point(117, 79);
            EncryptorURI.Margin = new System.Windows.Forms.Padding(0);
            EncryptorURI.Name = "EncryptorURI";
            EncryptorURI.ReadOnly = true;
            EncryptorURI.Size = new System.Drawing.Size(530, 27);
            EncryptorURI.TabIndex = 36;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(9, 49);
            label21.Margin = new System.Windows.Forms.Padding(0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(93, 20);
            label21.TabIndex = 37;
            label21.Text = "Port Number";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(9, 16);
            label22.Margin = new System.Windows.Forms.Padding(0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(83, 20);
            label22.TabIndex = 39;
            label22.Text = "Service URI";
            // 
            // PinPadTab
            // 
            PinPadTab.Controls.Add(pinPadTreeView);
            PinPadTab.Controls.Add(pinPadRawBox);
            PinPadTab.Controls.Add(PinPadGetLayout);
            PinPadTab.Controls.Add(PinPadEnterData);
            PinPadTab.Controls.Add(PinPadFormatPin);
            PinPadTab.Controls.Add(PinPadEnterPin);
            PinPadTab.Controls.Add(PinPadLoadPinKey);
            PinPadTab.Controls.Add(PinPadSecureKeyEntryPart2);
            PinPadTab.Controls.Add(PinPadSecureKeyEntryPart1);
            PinPadTab.Controls.Add(PinPadDeleteKey);
            PinPadTab.Controls.Add(PinPadReset);
            PinPadTab.Controls.Add(PinPadImportKey);
            PinPadTab.Controls.Add(PinPadInitialization);
            PinPadTab.Controls.Add(PinPadGetKeyNames);
            PinPadTab.Controls.Add(label26);
            PinPadTab.Controls.Add(PinPadKeyNamelistBox);
            PinPadTab.Controls.Add(label27);
            PinPadTab.Controls.Add(label28);
            PinPadTab.Controls.Add(PinPadMaxKeyNum);
            PinPadTab.Controls.Add(PinPadStDevice);
            PinPadTab.Controls.Add(PinPadCapabilities);
            PinPadTab.Controls.Add(PinPadStatus);
            PinPadTab.Controls.Add(PinPadServiceURI);
            PinPadTab.Controls.Add(PinPadServiceDiscovery);
            PinPadTab.Controls.Add(PinPadPortNum);
            PinPadTab.Controls.Add(label29);
            PinPadTab.Controls.Add(PinPadURI);
            PinPadTab.Controls.Add(label30);
            PinPadTab.Controls.Add(label31);
            PinPadTab.Location = new System.Drawing.Point(4, 29);
            PinPadTab.Margin = new System.Windows.Forms.Padding(0);
            PinPadTab.Name = "PinPadTab";
            PinPadTab.Size = new System.Drawing.Size(1346, 691);
            PinPadTab.TabIndex = 4;
            PinPadTab.Text = "PinPad";
            PinPadTab.UseVisualStyleBackColor = true;
            // 
            // pinPadTreeView
            // 
            pinPadTreeView.Location = new System.Drawing.Point(18, 271);
            pinPadTreeView.Name = "pinPadTreeView";
            pinPadTreeView.Size = new System.Drawing.Size(901, 408);
            pinPadTreeView.TabIndex = 94;
            // 
            // pinPadRawBox
            // 
            pinPadRawBox.Location = new System.Drawing.Point(933, 271);
            pinPadRawBox.Multiline = true;
            pinPadRawBox.Name = "pinPadRawBox";
            pinPadRawBox.ReadOnly = true;
            pinPadRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            pinPadRawBox.Size = new System.Drawing.Size(405, 408);
            pinPadRawBox.TabIndex = 93;
            // 
            // PinPadGetLayout
            // 
            PinPadGetLayout.Location = new System.Drawing.Point(933, 191);
            PinPadGetLayout.Margin = new System.Windows.Forms.Padding(0);
            PinPadGetLayout.Name = "PinPadGetLayout";
            PinPadGetLayout.Size = new System.Drawing.Size(103, 31);
            PinPadGetLayout.TabIndex = 92;
            PinPadGetLayout.Text = "Get Layout";
            PinPadGetLayout.UseVisualStyleBackColor = true;
            PinPadGetLayout.Click += PinPadGetLayout_Click;
            // 
            // PinPadEnterData
            // 
            PinPadEnterData.Location = new System.Drawing.Point(1160, 52);
            PinPadEnterData.Margin = new System.Windows.Forms.Padding(0);
            PinPadEnterData.Name = "PinPadEnterData";
            PinPadEnterData.Size = new System.Drawing.Size(97, 28);
            PinPadEnterData.TabIndex = 91;
            PinPadEnterData.Text = "Enter Data";
            PinPadEnterData.UseVisualStyleBackColor = true;
            PinPadEnterData.Click += PinPadEnterData_Click;
            // 
            // PinPadFormatPin
            // 
            PinPadFormatPin.Location = new System.Drawing.Point(1254, 221);
            PinPadFormatPin.Margin = new System.Windows.Forms.Padding(0);
            PinPadFormatPin.Name = "PinPadFormatPin";
            PinPadFormatPin.Size = new System.Drawing.Size(88, 28);
            PinPadFormatPin.TabIndex = 90;
            PinPadFormatPin.Text = "Format PIN";
            PinPadFormatPin.UseVisualStyleBackColor = true;
            PinPadFormatPin.Click += PinPadFormatPin_Click;
            // 
            // PinPadEnterPin
            // 
            PinPadEnterPin.Location = new System.Drawing.Point(1158, 221);
            PinPadEnterPin.Margin = new System.Windows.Forms.Padding(0);
            PinPadEnterPin.Name = "PinPadEnterPin";
            PinPadEnterPin.Size = new System.Drawing.Size(88, 28);
            PinPadEnterPin.TabIndex = 89;
            PinPadEnterPin.Text = "Enter PIN";
            PinPadEnterPin.UseVisualStyleBackColor = true;
            PinPadEnterPin.Click += PinPadEnterPin_Click;
            // 
            // PinPadLoadPinKey
            // 
            PinPadLoadPinKey.Location = new System.Drawing.Point(1043, 221);
            PinPadLoadPinKey.Margin = new System.Windows.Forms.Padding(0);
            PinPadLoadPinKey.Name = "PinPadLoadPinKey";
            PinPadLoadPinKey.Size = new System.Drawing.Size(106, 28);
            PinPadLoadPinKey.TabIndex = 88;
            PinPadLoadPinKey.Text = "Load PIN Key";
            PinPadLoadPinKey.UseVisualStyleBackColor = true;
            PinPadLoadPinKey.Click += PinPadLoadPinKey_Click;
            // 
            // PinPadSecureKeyEntryPart2
            // 
            PinPadSecureKeyEntryPart2.Location = new System.Drawing.Point(1045, 136);
            PinPadSecureKeyEntryPart2.Margin = new System.Windows.Forms.Padding(0);
            PinPadSecureKeyEntryPart2.Name = "PinPadSecureKeyEntryPart2";
            PinPadSecureKeyEntryPart2.Size = new System.Drawing.Size(168, 28);
            PinPadSecureKeyEntryPart2.TabIndex = 87;
            PinPadSecureKeyEntryPart2.Text = "SecureKeyEntry Part2";
            PinPadSecureKeyEntryPart2.UseVisualStyleBackColor = true;
            PinPadSecureKeyEntryPart2.Click += PinPadSecureKeyEntryPart2_Click;
            // 
            // PinPadSecureKeyEntryPart1
            // 
            PinPadSecureKeyEntryPart1.Location = new System.Drawing.Point(1045, 100);
            PinPadSecureKeyEntryPart1.Margin = new System.Windows.Forms.Padding(0);
            PinPadSecureKeyEntryPart1.Name = "PinPadSecureKeyEntryPart1";
            PinPadSecureKeyEntryPart1.Size = new System.Drawing.Size(168, 28);
            PinPadSecureKeyEntryPart1.TabIndex = 86;
            PinPadSecureKeyEntryPart1.Text = "SecureKeyEntry Part1";
            PinPadSecureKeyEntryPart1.UseVisualStyleBackColor = true;
            PinPadSecureKeyEntryPart1.Click += PinPadSecureKeyEntryPart1_Click;
            // 
            // PinPadDeleteKey
            // 
            PinPadDeleteKey.Location = new System.Drawing.Point(1045, 52);
            PinPadDeleteKey.Margin = new System.Windows.Forms.Padding(0);
            PinPadDeleteKey.Name = "PinPadDeleteKey";
            PinPadDeleteKey.Size = new System.Drawing.Size(106, 28);
            PinPadDeleteKey.TabIndex = 85;
            PinPadDeleteKey.Text = "DeleteKey";
            PinPadDeleteKey.UseVisualStyleBackColor = true;
            PinPadDeleteKey.Click += PinPadDeleteKey_Click;
            // 
            // PinPadReset
            // 
            PinPadReset.Location = new System.Drawing.Point(1160, 13);
            PinPadReset.Margin = new System.Windows.Forms.Padding(0);
            PinPadReset.Name = "PinPadReset";
            PinPadReset.Size = new System.Drawing.Size(97, 29);
            PinPadReset.TabIndex = 81;
            PinPadReset.Text = "Reset";
            PinPadReset.UseVisualStyleBackColor = true;
            PinPadReset.Click += PinPadReset_Click;
            // 
            // PinPadImportKey
            // 
            PinPadImportKey.Location = new System.Drawing.Point(1045, 173);
            PinPadImportKey.Margin = new System.Windows.Forms.Padding(0);
            PinPadImportKey.Name = "PinPadImportKey";
            PinPadImportKey.Size = new System.Drawing.Size(168, 28);
            PinPadImportKey.TabIndex = 80;
            PinPadImportKey.Text = "ImportKey (Secure)";
            PinPadImportKey.UseVisualStyleBackColor = true;
            PinPadImportKey.Click += PinPadImportKey_Click;
            // 
            // PinPadInitialization
            // 
            PinPadInitialization.Location = new System.Drawing.Point(1045, 15);
            PinPadInitialization.Margin = new System.Windows.Forms.Padding(0);
            PinPadInitialization.Name = "PinPadInitialization";
            PinPadInitialization.Size = new System.Drawing.Size(105, 29);
            PinPadInitialization.TabIndex = 79;
            PinPadInitialization.Text = "Initialization";
            PinPadInitialization.UseVisualStyleBackColor = true;
            PinPadInitialization.Click += PinPadInitialization_Click;
            // 
            // PinPadGetKeyNames
            // 
            PinPadGetKeyNames.Location = new System.Drawing.Point(933, 148);
            PinPadGetKeyNames.Margin = new System.Windows.Forms.Padding(0);
            PinPadGetKeyNames.Name = "PinPadGetKeyNames";
            PinPadGetKeyNames.Size = new System.Drawing.Size(103, 31);
            PinPadGetKeyNames.TabIndex = 78;
            PinPadGetKeyNames.Text = "GetKeyNames";
            PinPadGetKeyNames.UseVisualStyleBackColor = true;
            PinPadGetKeyNames.Click += PinPadGetKeyNames_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(679, 120);
            label26.Margin = new System.Windows.Forms.Padding(0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(83, 20);
            label26.TabIndex = 77;
            label26.Text = "Key Names";
            // 
            // PinPadKeyNamelistBox
            // 
            PinPadKeyNamelistBox.FormattingEnabled = true;
            PinPadKeyNamelistBox.Location = new System.Drawing.Point(679, 148);
            PinPadKeyNamelistBox.Margin = new System.Windows.Forms.Padding(0);
            PinPadKeyNamelistBox.Name = "PinPadKeyNamelistBox";
            PinPadKeyNamelistBox.Size = new System.Drawing.Size(244, 104);
            PinPadKeyNamelistBox.TabIndex = 76;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(679, 64);
            label27.Margin = new System.Windows.Forms.Padding(0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(118, 20);
            label27.TabIndex = 75;
            label27.Text = "Max key number";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(702, 20);
            label28.Margin = new System.Windows.Forms.Padding(0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(96, 20);
            label28.TabIndex = 74;
            label28.Text = "Device status";
            // 
            // PinPadMaxKeyNum
            // 
            PinPadMaxKeyNum.Location = new System.Drawing.Point(798, 61);
            PinPadMaxKeyNum.Margin = new System.Windows.Forms.Padding(0);
            PinPadMaxKeyNum.Name = "PinPadMaxKeyNum";
            PinPadMaxKeyNum.ReadOnly = true;
            PinPadMaxKeyNum.Size = new System.Drawing.Size(121, 27);
            PinPadMaxKeyNum.TabIndex = 70;
            // 
            // PinPadStDevice
            // 
            PinPadStDevice.Location = new System.Drawing.Point(798, 20);
            PinPadStDevice.Margin = new System.Windows.Forms.Padding(0);
            PinPadStDevice.Name = "PinPadStDevice";
            PinPadStDevice.ReadOnly = true;
            PinPadStDevice.Size = new System.Drawing.Size(121, 27);
            PinPadStDevice.TabIndex = 69;
            // 
            // PinPadCapabilities
            // 
            PinPadCapabilities.Location = new System.Drawing.Point(933, 51);
            PinPadCapabilities.Margin = new System.Windows.Forms.Padding(0);
            PinPadCapabilities.Name = "PinPadCapabilities";
            PinPadCapabilities.Size = new System.Drawing.Size(103, 29);
            PinPadCapabilities.TabIndex = 68;
            PinPadCapabilities.Text = "Capabilities";
            PinPadCapabilities.UseVisualStyleBackColor = true;
            PinPadCapabilities.Click += PinPadCapabilities_Click;
            // 
            // PinPadStatus
            // 
            PinPadStatus.Location = new System.Drawing.Point(933, 15);
            PinPadStatus.Margin = new System.Windows.Forms.Padding(0);
            PinPadStatus.Name = "PinPadStatus";
            PinPadStatus.Size = new System.Drawing.Size(103, 29);
            PinPadStatus.TabIndex = 67;
            PinPadStatus.Text = "Status";
            PinPadStatus.UseVisualStyleBackColor = true;
            PinPadStatus.Click += PinPadStatus_Click;
            // 
            // PinPadServiceURI
            // 
            PinPadServiceURI.Location = new System.Drawing.Point(119, 17);
            PinPadServiceURI.Margin = new System.Windows.Forms.Padding(0);
            PinPadServiceURI.Name = "PinPadServiceURI";
            PinPadServiceURI.Size = new System.Drawing.Size(530, 27);
            PinPadServiceURI.TabIndex = 65;
            // 
            // PinPadServiceDiscovery
            // 
            PinPadServiceDiscovery.Location = new System.Drawing.Point(506, 128);
            PinPadServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            PinPadServiceDiscovery.Name = "PinPadServiceDiscovery";
            PinPadServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            PinPadServiceDiscovery.TabIndex = 60;
            PinPadServiceDiscovery.Text = "Service Discovery";
            PinPadServiceDiscovery.UseVisualStyleBackColor = true;
            PinPadServiceDiscovery.Click += PinPadServiceDiscovery_Click;
            // 
            // PinPadPortNum
            // 
            PinPadPortNum.Location = new System.Drawing.Point(119, 49);
            PinPadPortNum.Margin = new System.Windows.Forms.Padding(0);
            PinPadPortNum.Name = "PinPadPortNum";
            PinPadPortNum.ReadOnly = true;
            PinPadPortNum.Size = new System.Drawing.Size(121, 27);
            PinPadPortNum.TabIndex = 61;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(9, 83);
            label29.Margin = new System.Windows.Forms.Padding(0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(80, 20);
            label29.TabIndex = 62;
            label29.Text = "PinPad URI";
            // 
            // PinPadURI
            // 
            PinPadURI.Location = new System.Drawing.Point(119, 80);
            PinPadURI.Margin = new System.Windows.Forms.Padding(0);
            PinPadURI.Name = "PinPadURI";
            PinPadURI.ReadOnly = true;
            PinPadURI.Size = new System.Drawing.Size(530, 27);
            PinPadURI.TabIndex = 63;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(11, 49);
            label30.Margin = new System.Windows.Forms.Padding(0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(93, 20);
            label30.TabIndex = 64;
            label30.Text = "Port Number";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(11, 17);
            label31.Margin = new System.Windows.Forms.Padding(0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(83, 20);
            label31.TabIndex = 66;
            label31.Text = "Service URI";
            // 
            // PrinterTabPage
            // 
            PrinterTabPage.Controls.Add(PrinterSetMedia);
            PrinterTabPage.Controls.Add(printerRawBox);
            PrinterTabPage.Controls.Add(printerTreeView);
            PrinterTabPage.Controls.Add(label39);
            PrinterTabPage.Controls.Add(PrinterFormFields);
            PrinterTabPage.Controls.Add(PrinterSetForm);
            PrinterTabPage.Controls.Add(PrinterMediaListBox);
            PrinterTabPage.Controls.Add(PrinterQueryForm);
            PrinterTabPage.Controls.Add(PrinterEject);
            PrinterTabPage.Controls.Add(PrinterQueryMedia);
            PrinterTabPage.Controls.Add(PrinterGetMediaList);
            PrinterTabPage.Controls.Add(PrinterPrintForm);
            PrinterTabPage.Controls.Add(PrinterReset);
            PrinterTabPage.Controls.Add(PrinterPrintRaw);
            PrinterTabPage.Controls.Add(PrinterGetFormList);
            PrinterTabPage.Controls.Add(label33);
            PrinterTabPage.Controls.Add(PrinterFormListBox);
            PrinterTabPage.Controls.Add(label34);
            PrinterTabPage.Controls.Add(label35);
            PrinterTabPage.Controls.Add(PrinterType);
            PrinterTabPage.Controls.Add(PrinterStDevice);
            PrinterTabPage.Controls.Add(PrinterCapabilities);
            PrinterTabPage.Controls.Add(PrinterStatus);
            PrinterTabPage.Controls.Add(PrinterServiceURI);
            PrinterTabPage.Controls.Add(PrinterServiceDiscovery);
            PrinterTabPage.Controls.Add(PrinterPortNum);
            PrinterTabPage.Controls.Add(label36);
            PrinterTabPage.Controls.Add(PrinterURI);
            PrinterTabPage.Controls.Add(label37);
            PrinterTabPage.Controls.Add(label38);
            PrinterTabPage.Location = new System.Drawing.Point(4, 29);
            PrinterTabPage.Name = "PrinterTabPage";
            PrinterTabPage.Padding = new System.Windows.Forms.Padding(3);
            PrinterTabPage.Size = new System.Drawing.Size(1346, 691);
            PrinterTabPage.TabIndex = 5;
            PrinterTabPage.Text = "Printer";
            PrinterTabPage.UseVisualStyleBackColor = true;
            // 
            // PrinterSetMedia
            // 
            PrinterSetMedia.Location = new System.Drawing.Point(1090, 83);
            PrinterSetMedia.Name = "PrinterSetMedia";
            PrinterSetMedia.Size = new System.Drawing.Size(113, 29);
            PrinterSetMedia.TabIndex = 130;
            PrinterSetMedia.Text = "SetMedia";
            PrinterSetMedia.UseVisualStyleBackColor = true;
            PrinterSetMedia.Click += PrinterSetMedia_Click;
            // 
            // printerRawBox
            // 
            printerRawBox.Location = new System.Drawing.Point(931, 283);
            printerRawBox.Multiline = true;
            printerRawBox.Name = "printerRawBox";
            printerRawBox.ReadOnly = true;
            printerRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            printerRawBox.Size = new System.Drawing.Size(405, 401);
            printerRawBox.TabIndex = 129;
            // 
            // printerTreeView
            // 
            printerTreeView.Location = new System.Drawing.Point(16, 283);
            printerTreeView.Name = "printerTreeView";
            printerTreeView.Size = new System.Drawing.Size(897, 401);
            printerTreeView.TabIndex = 128;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new System.Drawing.Point(16, 189);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(88, 20);
            label39.TabIndex = 127;
            label39.Text = "Form Fields:";
            // 
            // PrinterFormFields
            // 
            PrinterFormFields.Location = new System.Drawing.Point(16, 225);
            PrinterFormFields.Margin = new System.Windows.Forms.Padding(0);
            PrinterFormFields.Name = "PrinterFormFields";
            PrinterFormFields.Size = new System.Drawing.Size(630, 27);
            PrinterFormFields.TabIndex = 126;
            PrinterFormFields.Text = "Field1=Value1,Field2=Field Value2";
            // 
            // PrinterSetForm
            // 
            PrinterSetForm.Location = new System.Drawing.Point(1090, 48);
            PrinterSetForm.Margin = new System.Windows.Forms.Padding(0);
            PrinterSetForm.Name = "PrinterSetForm";
            PrinterSetForm.Size = new System.Drawing.Size(113, 29);
            PrinterSetForm.TabIndex = 124;
            PrinterSetForm.Text = "SetForm";
            PrinterSetForm.UseVisualStyleBackColor = true;
            PrinterSetForm.Click += PrinterLoadDefinition_Click;
            // 
            // PrinterMediaListBox
            // 
            PrinterMediaListBox.FormattingEnabled = true;
            PrinterMediaListBox.Location = new System.Drawing.Point(1022, 136);
            PrinterMediaListBox.Name = "PrinterMediaListBox";
            PrinterMediaListBox.Size = new System.Drawing.Size(181, 124);
            PrinterMediaListBox.TabIndex = 123;
            // 
            // PrinterQueryForm
            // 
            PrinterQueryForm.Location = new System.Drawing.Point(907, 177);
            PrinterQueryForm.Margin = new System.Windows.Forms.Padding(0);
            PrinterQueryForm.Name = "PrinterQueryForm";
            PrinterQueryForm.Size = new System.Drawing.Size(103, 31);
            PrinterQueryForm.TabIndex = 122;
            PrinterQueryForm.Text = "QueryForm";
            PrinterQueryForm.UseVisualStyleBackColor = true;
            PrinterQueryForm.Click += PrinterQueryForm_Click;
            // 
            // PrinterEject
            // 
            PrinterEject.Location = new System.Drawing.Point(1213, 48);
            PrinterEject.Margin = new System.Windows.Forms.Padding(0);
            PrinterEject.Name = "PrinterEject";
            PrinterEject.Size = new System.Drawing.Size(106, 28);
            PrinterEject.TabIndex = 121;
            PrinterEject.Text = "Eject";
            PrinterEject.UseVisualStyleBackColor = true;
            PrinterEject.Click += PrinterEject_Click;
            // 
            // PrinterQueryMedia
            // 
            PrinterQueryMedia.Location = new System.Drawing.Point(1216, 177);
            PrinterQueryMedia.Margin = new System.Windows.Forms.Padding(0);
            PrinterQueryMedia.Name = "PrinterQueryMedia";
            PrinterQueryMedia.Size = new System.Drawing.Size(106, 28);
            PrinterQueryMedia.TabIndex = 119;
            PrinterQueryMedia.Text = "QueryMedia";
            PrinterQueryMedia.UseVisualStyleBackColor = true;
            PrinterQueryMedia.Click += PrinterQueryMedia_Click;
            // 
            // PrinterGetMediaList
            // 
            PrinterGetMediaList.Location = new System.Drawing.Point(1216, 136);
            PrinterGetMediaList.Margin = new System.Windows.Forms.Padding(0);
            PrinterGetMediaList.Name = "PrinterGetMediaList";
            PrinterGetMediaList.Size = new System.Drawing.Size(106, 28);
            PrinterGetMediaList.TabIndex = 118;
            PrinterGetMediaList.Text = "GetMediaList";
            PrinterGetMediaList.UseVisualStyleBackColor = true;
            PrinterGetMediaList.Click += PrinterGetMediaList_Click;
            // 
            // PrinterPrintForm
            // 
            PrinterPrintForm.Location = new System.Drawing.Point(16, 160);
            PrinterPrintForm.Margin = new System.Windows.Forms.Padding(0);
            PrinterPrintForm.Name = "PrinterPrintForm";
            PrinterPrintForm.Size = new System.Drawing.Size(120, 28);
            PrinterPrintForm.TabIndex = 115;
            PrinterPrintForm.Text = "PrintForm";
            PrinterPrintForm.UseVisualStyleBackColor = true;
            PrinterPrintForm.Click += PrinterPrintForm_Click;
            // 
            // PrinterReset
            // 
            PrinterReset.Location = new System.Drawing.Point(1213, 12);
            PrinterReset.Margin = new System.Windows.Forms.Padding(0);
            PrinterReset.Name = "PrinterReset";
            PrinterReset.Size = new System.Drawing.Size(106, 29);
            PrinterReset.TabIndex = 114;
            PrinterReset.Text = "Reset";
            PrinterReset.UseVisualStyleBackColor = true;
            PrinterReset.Click += PrinterReset_Click;
            // 
            // PrinterPrintRaw
            // 
            PrinterPrintRaw.Location = new System.Drawing.Point(1090, 15);
            PrinterPrintRaw.Margin = new System.Windows.Forms.Padding(0);
            PrinterPrintRaw.Name = "PrinterPrintRaw";
            PrinterPrintRaw.Size = new System.Drawing.Size(113, 29);
            PrinterPrintRaw.TabIndex = 112;
            PrinterPrintRaw.Text = "PrintRaw";
            PrinterPrintRaw.UseVisualStyleBackColor = true;
            PrinterPrintRaw.Click += PrinterPrintRaw_Click;
            // 
            // PrinterGetFormList
            // 
            PrinterGetFormList.Location = new System.Drawing.Point(907, 135);
            PrinterGetFormList.Margin = new System.Windows.Forms.Padding(0);
            PrinterGetFormList.Name = "PrinterGetFormList";
            PrinterGetFormList.Size = new System.Drawing.Size(103, 31);
            PrinterGetFormList.TabIndex = 111;
            PrinterGetFormList.Text = "GetFormList";
            PrinterGetFormList.UseVisualStyleBackColor = true;
            PrinterGetFormList.Click += PrinterGetFormList_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new System.Drawing.Point(677, 107);
            label33.Margin = new System.Windows.Forms.Padding(0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(93, 20);
            label33.TabIndex = 110;
            label33.Text = "Form Names";
            // 
            // PrinterFormListBox
            // 
            PrinterFormListBox.FormattingEnabled = true;
            PrinterFormListBox.Location = new System.Drawing.Point(677, 135);
            PrinterFormListBox.Margin = new System.Windows.Forms.Padding(0);
            PrinterFormListBox.Name = "PrinterFormListBox";
            PrinterFormListBox.Size = new System.Drawing.Size(217, 124);
            PrinterFormListBox.TabIndex = 109;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(677, 63);
            label34.Margin = new System.Windows.Forms.Padding(0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(87, 20);
            label34.TabIndex = 108;
            label34.Text = "Printer Type";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(677, 16);
            label35.Margin = new System.Windows.Forms.Padding(0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(96, 20);
            label35.TabIndex = 107;
            label35.Text = "Device status";
            // 
            // PrinterType
            // 
            PrinterType.Location = new System.Drawing.Point(773, 60);
            PrinterType.Margin = new System.Windows.Forms.Padding(0);
            PrinterType.Name = "PrinterType";
            PrinterType.ReadOnly = true;
            PrinterType.Size = new System.Drawing.Size(121, 27);
            PrinterType.TabIndex = 103;
            // 
            // PrinterStDevice
            // 
            PrinterStDevice.Location = new System.Drawing.Point(773, 16);
            PrinterStDevice.Margin = new System.Windows.Forms.Padding(0);
            PrinterStDevice.Name = "PrinterStDevice";
            PrinterStDevice.ReadOnly = true;
            PrinterStDevice.Size = new System.Drawing.Size(121, 27);
            PrinterStDevice.TabIndex = 102;
            // 
            // PrinterCapabilities
            // 
            PrinterCapabilities.Location = new System.Drawing.Point(931, 51);
            PrinterCapabilities.Margin = new System.Windows.Forms.Padding(0);
            PrinterCapabilities.Name = "PrinterCapabilities";
            PrinterCapabilities.Size = new System.Drawing.Size(103, 29);
            PrinterCapabilities.TabIndex = 101;
            PrinterCapabilities.Text = "Capabilities";
            PrinterCapabilities.UseVisualStyleBackColor = true;
            PrinterCapabilities.Click += PrinterCapabilities_Click;
            // 
            // PrinterStatus
            // 
            PrinterStatus.Location = new System.Drawing.Point(931, 13);
            PrinterStatus.Margin = new System.Windows.Forms.Padding(0);
            PrinterStatus.Name = "PrinterStatus";
            PrinterStatus.Size = new System.Drawing.Size(103, 29);
            PrinterStatus.TabIndex = 100;
            PrinterStatus.Text = "Status";
            PrinterStatus.UseVisualStyleBackColor = true;
            PrinterStatus.Click += PrinterStatus_Click;
            // 
            // PrinterServiceURI
            // 
            PrinterServiceURI.Location = new System.Drawing.Point(117, 16);
            PrinterServiceURI.Margin = new System.Windows.Forms.Padding(0);
            PrinterServiceURI.Name = "PrinterServiceURI";
            PrinterServiceURI.Size = new System.Drawing.Size(530, 27);
            PrinterServiceURI.TabIndex = 98;
            // 
            // PrinterServiceDiscovery
            // 
            PrinterServiceDiscovery.Location = new System.Drawing.Point(504, 127);
            PrinterServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            PrinterServiceDiscovery.Name = "PrinterServiceDiscovery";
            PrinterServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            PrinterServiceDiscovery.TabIndex = 93;
            PrinterServiceDiscovery.Text = "Service Discovery";
            PrinterServiceDiscovery.UseVisualStyleBackColor = true;
            PrinterServiceDiscovery.Click += PrinterServiceDiscovery_Click;
            // 
            // PrinterPortNum
            // 
            PrinterPortNum.Location = new System.Drawing.Point(117, 48);
            PrinterPortNum.Margin = new System.Windows.Forms.Padding(0);
            PrinterPortNum.Name = "PrinterPortNum";
            PrinterPortNum.ReadOnly = true;
            PrinterPortNum.Size = new System.Drawing.Size(121, 27);
            PrinterPortNum.TabIndex = 94;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(7, 83);
            label36.Margin = new System.Windows.Forms.Padding(0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(79, 20);
            label36.TabIndex = 95;
            label36.Text = "Printer URI";
            // 
            // PrinterURI
            // 
            PrinterURI.Location = new System.Drawing.Point(117, 79);
            PrinterURI.Margin = new System.Windows.Forms.Padding(0);
            PrinterURI.Name = "PrinterURI";
            PrinterURI.ReadOnly = true;
            PrinterURI.Size = new System.Drawing.Size(530, 27);
            PrinterURI.TabIndex = 96;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new System.Drawing.Point(9, 48);
            label37.Margin = new System.Windows.Forms.Padding(0);
            label37.Name = "label37";
            label37.Size = new System.Drawing.Size(93, 20);
            label37.TabIndex = 97;
            label37.Text = "Port Number";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new System.Drawing.Point(9, 16);
            label38.Margin = new System.Windows.Forms.Padding(0);
            label38.Name = "label38";
            label38.Size = new System.Drawing.Size(83, 20);
            label38.TabIndex = 99;
            label38.Text = "Service URI";
            // 
            // lightsTab
            // 
            lightsTab.Controls.Add(comboLightDevice);
            lightsTab.Controls.Add(lightsTreeView);
            lightsTab.Controls.Add(lightsRawBox);
            lightsTab.Controls.Add(LightsServiceDiscovery);
            lightsTab.Controls.Add(label45);
            lightsTab.Controls.Add(LightsFlashRate);
            lightsTab.Controls.Add(label40);
            lightsTab.Controls.Add(LightsSetLight);
            lightsTab.Controls.Add(label41);
            lightsTab.Controls.Add(lblLightsStatus);
            lightsTab.Controls.Add(LightsCapabilities);
            lightsTab.Controls.Add(LightsStatus);
            lightsTab.Controls.Add(LightsServiceURI);
            lightsTab.Controls.Add(LightsPortNum);
            lightsTab.Controls.Add(label42);
            lightsTab.Controls.Add(LightsURI);
            lightsTab.Controls.Add(label43);
            lightsTab.Controls.Add(label44);
            lightsTab.Location = new System.Drawing.Point(4, 29);
            lightsTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lightsTab.Name = "lightsTab";
            lightsTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lightsTab.Size = new System.Drawing.Size(1346, 691);
            lightsTab.TabIndex = 6;
            lightsTab.Text = "Lights";
            lightsTab.UseVisualStyleBackColor = true;
            // 
            // lightsTreeView
            // 
            lightsTreeView.Location = new System.Drawing.Point(16, 267);
            lightsTreeView.Name = "lightsTreeView";
            lightsTreeView.Size = new System.Drawing.Size(893, 408);
            lightsTreeView.TabIndex = 137;
            // 
            // lightsRawBox
            // 
            lightsRawBox.Location = new System.Drawing.Point(931, 267);
            lightsRawBox.Multiline = true;
            lightsRawBox.Name = "lightsRawBox";
            lightsRawBox.ReadOnly = true;
            lightsRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            lightsRawBox.Size = new System.Drawing.Size(405, 408);
            lightsRawBox.TabIndex = 136;
            // 
            // LightsServiceDiscovery
            // 
            LightsServiceDiscovery.Location = new System.Drawing.Point(514, 117);
            LightsServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            LightsServiceDiscovery.Name = "LightsServiceDiscovery";
            LightsServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            LightsServiceDiscovery.TabIndex = 135;
            LightsServiceDiscovery.Text = "Service Discovery";
            LightsServiceDiscovery.UseVisualStyleBackColor = true;
            LightsServiceDiscovery.Click += LightsServiceDiscovery_Click;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new System.Drawing.Point(1085, 60);
            label45.Margin = new System.Windows.Forms.Padding(0);
            label45.Name = "label45";
            label45.Size = new System.Drawing.Size(76, 20);
            label45.TabIndex = 134;
            label45.Text = "Flash Rate";
            // 
            // LightsFlashRate
            // 
            LightsFlashRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            LightsFlashRate.FormattingEnabled = true;
            LightsFlashRate.Location = new System.Drawing.Point(1178, 56);
            LightsFlashRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            LightsFlashRate.Name = "LightsFlashRate";
            LightsFlashRate.Size = new System.Drawing.Size(121, 28);
            LightsFlashRate.TabIndex = 133;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new System.Drawing.Point(1074, 12);
            label40.Margin = new System.Windows.Forms.Padding(0);
            label40.Name = "label40";
            label40.Size = new System.Drawing.Size(86, 20);
            label40.TabIndex = 132;
            label40.Text = "Light Name";
            // 
            // LightsSetLight
            // 
            LightsSetLight.Location = new System.Drawing.Point(1193, 119);
            LightsSetLight.Margin = new System.Windows.Forms.Padding(0);
            LightsSetLight.Name = "LightsSetLight";
            LightsSetLight.Size = new System.Drawing.Size(106, 29);
            LightsSetLight.TabIndex = 130;
            LightsSetLight.Text = "SetLight";
            LightsSetLight.UseVisualStyleBackColor = true;
            LightsSetLight.Click += LightsSetLight_Click;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new System.Drawing.Point(677, 13);
            label41.Margin = new System.Windows.Forms.Padding(0);
            label41.Name = "label41";
            label41.Size = new System.Drawing.Size(96, 20);
            label41.TabIndex = 128;
            label41.Text = "Device status";
            // 
            // lblLightsStatus
            // 
            lblLightsStatus.Location = new System.Drawing.Point(773, 13);
            lblLightsStatus.Margin = new System.Windows.Forms.Padding(0);
            lblLightsStatus.Name = "lblLightsStatus";
            lblLightsStatus.ReadOnly = true;
            lblLightsStatus.Size = new System.Drawing.Size(121, 27);
            lblLightsStatus.TabIndex = 123;
            // 
            // LightsCapabilities
            // 
            LightsCapabilities.Location = new System.Drawing.Point(931, 51);
            LightsCapabilities.Margin = new System.Windows.Forms.Padding(0);
            LightsCapabilities.Name = "LightsCapabilities";
            LightsCapabilities.Size = new System.Drawing.Size(103, 29);
            LightsCapabilities.TabIndex = 122;
            LightsCapabilities.Text = "Capabilities";
            LightsCapabilities.UseVisualStyleBackColor = true;
            LightsCapabilities.Click += LightsCapabilities_Click;
            // 
            // LightsStatus
            // 
            LightsStatus.Location = new System.Drawing.Point(931, 13);
            LightsStatus.Margin = new System.Windows.Forms.Padding(0);
            LightsStatus.Name = "LightsStatus";
            LightsStatus.Size = new System.Drawing.Size(103, 29);
            LightsStatus.TabIndex = 121;
            LightsStatus.Text = "Status";
            LightsStatus.UseVisualStyleBackColor = true;
            LightsStatus.Click += LightsStatus_Click;
            // 
            // LightsServiceURI
            // 
            LightsServiceURI.Location = new System.Drawing.Point(117, 13);
            LightsServiceURI.Margin = new System.Windows.Forms.Padding(0);
            LightsServiceURI.Name = "LightsServiceURI";
            LightsServiceURI.Size = new System.Drawing.Size(530, 27);
            LightsServiceURI.TabIndex = 119;
            // 
            // LightsPortNum
            // 
            LightsPortNum.Location = new System.Drawing.Point(117, 45);
            LightsPortNum.Margin = new System.Windows.Forms.Padding(0);
            LightsPortNum.Name = "LightsPortNum";
            LightsPortNum.ReadOnly = true;
            LightsPortNum.Size = new System.Drawing.Size(121, 27);
            LightsPortNum.TabIndex = 115;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new System.Drawing.Point(7, 80);
            label42.Margin = new System.Windows.Forms.Padding(0);
            label42.Name = "label42";
            label42.Size = new System.Drawing.Size(75, 20);
            label42.TabIndex = 116;
            label42.Text = "Lights URI";
            // 
            // LightsURI
            // 
            LightsURI.Location = new System.Drawing.Point(117, 76);
            LightsURI.Margin = new System.Windows.Forms.Padding(0);
            LightsURI.Name = "LightsURI";
            LightsURI.ReadOnly = true;
            LightsURI.Size = new System.Drawing.Size(530, 27);
            LightsURI.TabIndex = 117;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new System.Drawing.Point(9, 45);
            label43.Margin = new System.Windows.Forms.Padding(0);
            label43.Name = "label43";
            label43.Size = new System.Drawing.Size(93, 20);
            label43.TabIndex = 118;
            label43.Text = "Port Number";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new System.Drawing.Point(9, 13);
            label44.Margin = new System.Windows.Forms.Padding(0);
            label44.Name = "label44";
            label44.Size = new System.Drawing.Size(83, 20);
            label44.TabIndex = 120;
            label44.Text = "Service URI";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(auxiliariesTreeView);
            tabPage2.Controls.Add(auxiliariesRawBox);
            tabPage2.Controls.Add(comboAutoStartupModes);
            tabPage2.Controls.Add(btnSetAuxiliaries);
            tabPage2.Controls.Add(btnRegister);
            tabPage2.Controls.Add(btnClearAutoStartup);
            tabPage2.Controls.Add(btnGetAutoStartup);
            tabPage2.Controls.Add(btnSetAutoStartup);
            tabPage2.Controls.Add(autoStartupDateTime);
            tabPage2.Controls.Add(btnAuxiliariesServiceDiscovery);
            tabPage2.Controls.Add(label48);
            tabPage2.Controls.Add(AuxiliariesStatus);
            tabPage2.Controls.Add(btnAuxiliariesCapabilities);
            tabPage2.Controls.Add(btnAuxiliariesStatus);
            tabPage2.Controls.Add(AuxiliariesServiceURI);
            tabPage2.Controls.Add(AuxiliariesPortNum);
            tabPage2.Controls.Add(label49);
            tabPage2.Controls.Add(AuxiliariesURI);
            tabPage2.Controls.Add(label50);
            tabPage2.Controls.Add(label51);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabPage2.Size = new System.Drawing.Size(1346, 691);
            tabPage2.TabIndex = 7;
            tabPage2.Text = "Auxiliaries";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // auxiliariesTreeView
            // 
            auxiliariesTreeView.Location = new System.Drawing.Point(27, 265);
            auxiliariesTreeView.Name = "auxiliariesTreeView";
            auxiliariesTreeView.Size = new System.Drawing.Size(882, 408);
            auxiliariesTreeView.TabIndex = 163;
            // 
            // auxiliariesRawBox
            // 
            auxiliariesRawBox.Location = new System.Drawing.Point(931, 265);
            auxiliariesRawBox.Multiline = true;
            auxiliariesRawBox.Name = "auxiliariesRawBox";
            auxiliariesRawBox.ReadOnly = true;
            auxiliariesRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            auxiliariesRawBox.Size = new System.Drawing.Size(393, 408);
            auxiliariesRawBox.TabIndex = 162;
            // 
            // comboAutoStartupModes
            // 
            comboAutoStartupModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboAutoStartupModes.FormattingEnabled = true;
            comboAutoStartupModes.Location = new System.Drawing.Point(1074, 51);
            comboAutoStartupModes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboAutoStartupModes.Name = "comboAutoStartupModes";
            comboAutoStartupModes.Size = new System.Drawing.Size(121, 28);
            comboAutoStartupModes.TabIndex = 161;
            // 
            // btnSetAuxiliaries
            // 
            btnSetAuxiliaries.Location = new System.Drawing.Point(1074, 129);
            btnSetAuxiliaries.Margin = new System.Windows.Forms.Padding(0);
            btnSetAuxiliaries.Name = "btnSetAuxiliaries";
            btnSetAuxiliaries.Size = new System.Drawing.Size(103, 29);
            btnSetAuxiliaries.TabIndex = 160;
            btnSetAuxiliaries.Text = "SetAuxiliaries";
            btnSetAuxiliaries.UseVisualStyleBackColor = true;
            btnSetAuxiliaries.Click += btnSetAuxiliaries_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new System.Drawing.Point(1074, 88);
            btnRegister.Margin = new System.Windows.Forms.Padding(0);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(103, 29);
            btnRegister.TabIndex = 159;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClearAutoStartup
            // 
            btnClearAutoStartup.Location = new System.Drawing.Point(1211, 129);
            btnClearAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            btnClearAutoStartup.Name = "btnClearAutoStartup";
            btnClearAutoStartup.Size = new System.Drawing.Size(126, 29);
            btnClearAutoStartup.TabIndex = 158;
            btnClearAutoStartup.Text = "ClearAutoStartup";
            btnClearAutoStartup.UseVisualStyleBackColor = true;
            btnClearAutoStartup.Click += btnClearAutoStartup_Click;
            // 
            // btnGetAutoStartup
            // 
            btnGetAutoStartup.Location = new System.Drawing.Point(1211, 88);
            btnGetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            btnGetAutoStartup.Name = "btnGetAutoStartup";
            btnGetAutoStartup.Size = new System.Drawing.Size(126, 29);
            btnGetAutoStartup.TabIndex = 157;
            btnGetAutoStartup.Text = "GetAutoStartup";
            btnGetAutoStartup.UseVisualStyleBackColor = true;
            btnGetAutoStartup.Click += btnGetAutoStartup_Click;
            // 
            // btnSetAutoStartup
            // 
            btnSetAutoStartup.Location = new System.Drawing.Point(1211, 47);
            btnSetAutoStartup.Margin = new System.Windows.Forms.Padding(0);
            btnSetAutoStartup.Name = "btnSetAutoStartup";
            btnSetAutoStartup.Size = new System.Drawing.Size(126, 29);
            btnSetAutoStartup.TabIndex = 156;
            btnSetAutoStartup.Text = "SetAutoStartup";
            btnSetAutoStartup.UseVisualStyleBackColor = true;
            btnSetAutoStartup.Click += btnSetAutoStartup_Click;
            // 
            // autoStartupDateTime
            // 
            autoStartupDateTime.CustomFormat = "yyyy.MM.dd HH:mm";
            autoStartupDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            autoStartupDateTime.Location = new System.Drawing.Point(1074, 12);
            autoStartupDateTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            autoStartupDateTime.Name = "autoStartupDateTime";
            autoStartupDateTime.Size = new System.Drawing.Size(262, 27);
            autoStartupDateTime.TabIndex = 155;
            // 
            // btnAuxiliariesServiceDiscovery
            // 
            btnAuxiliariesServiceDiscovery.Location = new System.Drawing.Point(514, 116);
            btnAuxiliariesServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            btnAuxiliariesServiceDiscovery.Name = "btnAuxiliariesServiceDiscovery";
            btnAuxiliariesServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            btnAuxiliariesServiceDiscovery.TabIndex = 154;
            btnAuxiliariesServiceDiscovery.Text = "Service Discovery";
            btnAuxiliariesServiceDiscovery.UseVisualStyleBackColor = true;
            btnAuxiliariesServiceDiscovery.Click += btnAuxiliariesServiceDiscovery_Click;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new System.Drawing.Point(677, 12);
            label48.Margin = new System.Windows.Forms.Padding(0);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(96, 20);
            label48.TabIndex = 148;
            label48.Text = "Device status";
            // 
            // AuxiliariesStatus
            // 
            AuxiliariesStatus.Location = new System.Drawing.Point(773, 12);
            AuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            AuxiliariesStatus.Name = "AuxiliariesStatus";
            AuxiliariesStatus.ReadOnly = true;
            AuxiliariesStatus.Size = new System.Drawing.Size(121, 27);
            AuxiliariesStatus.TabIndex = 144;
            // 
            // btnAuxiliariesCapabilities
            // 
            btnAuxiliariesCapabilities.Location = new System.Drawing.Point(931, 49);
            btnAuxiliariesCapabilities.Margin = new System.Windows.Forms.Padding(0);
            btnAuxiliariesCapabilities.Name = "btnAuxiliariesCapabilities";
            btnAuxiliariesCapabilities.Size = new System.Drawing.Size(103, 29);
            btnAuxiliariesCapabilities.TabIndex = 143;
            btnAuxiliariesCapabilities.Text = "Capabilities";
            btnAuxiliariesCapabilities.UseVisualStyleBackColor = true;
            btnAuxiliariesCapabilities.Click += btnAuxiliariesCapabilities_Click;
            // 
            // btnAuxiliariesStatus
            // 
            btnAuxiliariesStatus.Location = new System.Drawing.Point(931, 12);
            btnAuxiliariesStatus.Margin = new System.Windows.Forms.Padding(0);
            btnAuxiliariesStatus.Name = "btnAuxiliariesStatus";
            btnAuxiliariesStatus.Size = new System.Drawing.Size(103, 29);
            btnAuxiliariesStatus.TabIndex = 142;
            btnAuxiliariesStatus.Text = "Status";
            btnAuxiliariesStatus.UseVisualStyleBackColor = true;
            btnAuxiliariesStatus.Click += btnAuxiliariesStatus_Click;
            // 
            // AuxiliariesServiceURI
            // 
            AuxiliariesServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            AuxiliariesServiceURI.Location = new System.Drawing.Point(117, 12);
            AuxiliariesServiceURI.Margin = new System.Windows.Forms.Padding(0);
            AuxiliariesServiceURI.Name = "AuxiliariesServiceURI";
            AuxiliariesServiceURI.Size = new System.Drawing.Size(530, 27);
            AuxiliariesServiceURI.TabIndex = 140;
            // 
            // AuxiliariesPortNum
            // 
            AuxiliariesPortNum.Location = new System.Drawing.Point(117, 44);
            AuxiliariesPortNum.Margin = new System.Windows.Forms.Padding(0);
            AuxiliariesPortNum.Name = "AuxiliariesPortNum";
            AuxiliariesPortNum.ReadOnly = true;
            AuxiliariesPortNum.Size = new System.Drawing.Size(121, 27);
            AuxiliariesPortNum.TabIndex = 136;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new System.Drawing.Point(7, 79);
            label49.Margin = new System.Windows.Forms.Padding(0);
            label49.Name = "label49";
            label49.Size = new System.Drawing.Size(104, 20);
            label49.TabIndex = 137;
            label49.Text = "Auxiliaries URI";
            // 
            // AuxiliariesURI
            // 
            AuxiliariesURI.Location = new System.Drawing.Point(117, 75);
            AuxiliariesURI.Margin = new System.Windows.Forms.Padding(0);
            AuxiliariesURI.Name = "AuxiliariesURI";
            AuxiliariesURI.ReadOnly = true;
            AuxiliariesURI.Size = new System.Drawing.Size(530, 27);
            AuxiliariesURI.TabIndex = 138;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new System.Drawing.Point(9, 44);
            label50.Margin = new System.Windows.Forms.Padding(0);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(93, 20);
            label50.TabIndex = 139;
            label50.Text = "Port Number";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new System.Drawing.Point(9, 12);
            label51.Margin = new System.Windows.Forms.Padding(0);
            label51.Name = "label51";
            label51.Size = new System.Drawing.Size(83, 20);
            label51.TabIndex = 141;
            label51.Text = "Service URI";
            // 
            // VendorModeTabPage
            // 
            VendorModeTabPage.Controls.Add(vendorModeTreeView);
            VendorModeTabPage.Controls.Add(vendorModeRawBox);
            VendorModeTabPage.Controls.Add(buttonVDMExit);
            VendorModeTabPage.Controls.Add(buttonVDMEnter);
            VendorModeTabPage.Controls.Add(VendorModeServiceStatus);
            VendorModeTabPage.Controls.Add(label58);
            VendorModeTabPage.Controls.Add(btnVendorModeServiceDiscovery);
            VendorModeTabPage.Controls.Add(label46);
            VendorModeTabPage.Controls.Add(VendorModeStStatus);
            VendorModeTabPage.Controls.Add(btnVendorModeStatus);
            VendorModeTabPage.Controls.Add(VendorModeServiceURI);
            VendorModeTabPage.Controls.Add(VendorModePortNum);
            VendorModeTabPage.Controls.Add(label47);
            VendorModeTabPage.Controls.Add(VendorModeURI);
            VendorModeTabPage.Controls.Add(label52);
            VendorModeTabPage.Controls.Add(label53);
            VendorModeTabPage.Location = new System.Drawing.Point(4, 29);
            VendorModeTabPage.Name = "VendorModeTabPage";
            VendorModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            VendorModeTabPage.Size = new System.Drawing.Size(1346, 691);
            VendorModeTabPage.TabIndex = 8;
            VendorModeTabPage.Text = "VendorMode";
            VendorModeTabPage.UseVisualStyleBackColor = true;
            // 
            // vendorModeTreeView
            // 
            vendorModeTreeView.Location = new System.Drawing.Point(9, 280);
            vendorModeTreeView.Name = "vendorModeTreeView";
            vendorModeTreeView.Size = new System.Drawing.Size(889, 411);
            vendorModeTreeView.TabIndex = 174;
            // 
            // vendorModeRawBox
            // 
            vendorModeRawBox.Location = new System.Drawing.Point(917, 280);
            vendorModeRawBox.Multiline = true;
            vendorModeRawBox.Name = "vendorModeRawBox";
            vendorModeRawBox.ReadOnly = true;
            vendorModeRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            vendorModeRawBox.Size = new System.Drawing.Size(409, 411);
            vendorModeRawBox.TabIndex = 173;
            // 
            // buttonVDMExit
            // 
            buttonVDMExit.Location = new System.Drawing.Point(960, 188);
            buttonVDMExit.Name = "buttonVDMExit";
            buttonVDMExit.Size = new System.Drawing.Size(162, 29);
            buttonVDMExit.TabIndex = 172;
            buttonVDMExit.Text = "ExitModeRequest";
            buttonVDMExit.UseVisualStyleBackColor = true;
            buttonVDMExit.Click += buttonVDMExit_Click;
            // 
            // buttonVDMEnter
            // 
            buttonVDMEnter.Location = new System.Drawing.Point(960, 139);
            buttonVDMEnter.Name = "buttonVDMEnter";
            buttonVDMEnter.Size = new System.Drawing.Size(162, 29);
            buttonVDMEnter.TabIndex = 171;
            buttonVDMEnter.Text = "EnterModeRequest";
            buttonVDMEnter.UseVisualStyleBackColor = true;
            buttonVDMEnter.Click += buttonVDMEnter_Click;
            // 
            // VendorModeServiceStatus
            // 
            VendorModeServiceStatus.Location = new System.Drawing.Point(822, 68);
            VendorModeServiceStatus.Margin = new System.Windows.Forms.Padding(0);
            VendorModeServiceStatus.Name = "VendorModeServiceStatus";
            VendorModeServiceStatus.ReadOnly = true;
            VendorModeServiceStatus.Size = new System.Drawing.Size(121, 27);
            VendorModeServiceStatus.TabIndex = 170;
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Location = new System.Drawing.Point(680, 71);
            label58.Name = "label58";
            label58.Size = new System.Drawing.Size(139, 20);
            label58.TabIndex = 169;
            label58.Text = "VendorMode Status";
            // 
            // btnVendorModeServiceDiscovery
            // 
            btnVendorModeServiceDiscovery.Location = new System.Drawing.Point(517, 121);
            btnVendorModeServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            btnVendorModeServiceDiscovery.Name = "btnVendorModeServiceDiscovery";
            btnVendorModeServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            btnVendorModeServiceDiscovery.TabIndex = 165;
            btnVendorModeServiceDiscovery.Text = "Service Discovery";
            btnVendorModeServiceDiscovery.UseVisualStyleBackColor = true;
            btnVendorModeServiceDiscovery.Click += btnVendorModeServiceDiscovery_Click;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new System.Drawing.Point(680, 17);
            label46.Margin = new System.Windows.Forms.Padding(0);
            label46.Name = "label46";
            label46.Size = new System.Drawing.Size(96, 20);
            label46.TabIndex = 164;
            label46.Text = "Device status";
            // 
            // VendorModeStStatus
            // 
            VendorModeStStatus.Location = new System.Drawing.Point(822, 19);
            VendorModeStStatus.Margin = new System.Windows.Forms.Padding(0);
            VendorModeStStatus.Name = "VendorModeStStatus";
            VendorModeStStatus.ReadOnly = true;
            VendorModeStStatus.Size = new System.Drawing.Size(121, 27);
            VendorModeStStatus.TabIndex = 163;
            // 
            // btnVendorModeStatus
            // 
            btnVendorModeStatus.Location = new System.Drawing.Point(960, 17);
            btnVendorModeStatus.Margin = new System.Windows.Forms.Padding(0);
            btnVendorModeStatus.Name = "btnVendorModeStatus";
            btnVendorModeStatus.Size = new System.Drawing.Size(103, 29);
            btnVendorModeStatus.TabIndex = 161;
            btnVendorModeStatus.Text = "Status";
            btnVendorModeStatus.UseVisualStyleBackColor = true;
            btnVendorModeStatus.Click += btnVendorModeStatus_Click;
            // 
            // VendorModeServiceURI
            // 
            VendorModeServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            VendorModeServiceURI.Location = new System.Drawing.Point(120, 17);
            VendorModeServiceURI.Margin = new System.Windows.Forms.Padding(0);
            VendorModeServiceURI.Name = "VendorModeServiceURI";
            VendorModeServiceURI.Size = new System.Drawing.Size(530, 27);
            VendorModeServiceURI.TabIndex = 159;
            // 
            // VendorModePortNum
            // 
            VendorModePortNum.Location = new System.Drawing.Point(120, 49);
            VendorModePortNum.Margin = new System.Windows.Forms.Padding(0);
            VendorModePortNum.Name = "VendorModePortNum";
            VendorModePortNum.ReadOnly = true;
            VendorModePortNum.Size = new System.Drawing.Size(121, 27);
            VendorModePortNum.TabIndex = 155;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new System.Drawing.Point(8, 84);
            label47.Margin = new System.Windows.Forms.Padding(0);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(122, 20);
            label47.TabIndex = 156;
            label47.Text = "VendorMode URI";
            // 
            // VendorModeURI
            // 
            VendorModeURI.Location = new System.Drawing.Point(120, 80);
            VendorModeURI.Margin = new System.Windows.Forms.Padding(0);
            VendorModeURI.Name = "VendorModeURI";
            VendorModeURI.ReadOnly = true;
            VendorModeURI.Size = new System.Drawing.Size(530, 27);
            VendorModeURI.TabIndex = 157;
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new System.Drawing.Point(9, 49);
            label52.Margin = new System.Windows.Forms.Padding(0);
            label52.Name = "label52";
            label52.Size = new System.Drawing.Size(93, 20);
            label52.TabIndex = 158;
            label52.Text = "Port Number";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(9, 17);
            label53.Margin = new System.Windows.Forms.Padding(0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(83, 20);
            label53.TabIndex = 160;
            label53.Text = "Service URI";
            // 
            // VendorAppTabPage
            // 
            VendorAppTabPage.Controls.Add(vendorApplicationTreeView);
            VendorAppTabPage.Controls.Add(vendorApplicationRawBox);
            VendorAppTabPage.Controls.Add(label60);
            VendorAppTabPage.Controls.Add(textAppName);
            VendorAppTabPage.Controls.Add(label59);
            VendorAppTabPage.Controls.Add(textActiveInterface);
            VendorAppTabPage.Controls.Add(buttonGetActiveInterface);
            VendorAppTabPage.Controls.Add(buttonStartLocalApplication);
            VendorAppTabPage.Controls.Add(btnVendorAppServiceDiscovery);
            VendorAppTabPage.Controls.Add(label54);
            VendorAppTabPage.Controls.Add(VendorAppStatus);
            VendorAppTabPage.Controls.Add(btnVendorAppCapabilities);
            VendorAppTabPage.Controls.Add(btnVendorAppStatus);
            VendorAppTabPage.Controls.Add(VendorAppServiceURI);
            VendorAppTabPage.Controls.Add(VendorAppPortNum);
            VendorAppTabPage.Controls.Add(label55);
            VendorAppTabPage.Controls.Add(VendorAppURI);
            VendorAppTabPage.Controls.Add(label56);
            VendorAppTabPage.Controls.Add(label57);
            VendorAppTabPage.Location = new System.Drawing.Point(4, 29);
            VendorAppTabPage.Name = "VendorAppTabPage";
            VendorAppTabPage.Padding = new System.Windows.Forms.Padding(3);
            VendorAppTabPage.Size = new System.Drawing.Size(1346, 691);
            VendorAppTabPage.TabIndex = 9;
            VendorAppTabPage.Text = "VendorApplication";
            VendorAppTabPage.UseVisualStyleBackColor = true;
            // 
            // vendorApplicationTreeView
            // 
            vendorApplicationTreeView.Location = new System.Drawing.Point(6, 285);
            vendorApplicationTreeView.Name = "vendorApplicationTreeView";
            vendorApplicationTreeView.Size = new System.Drawing.Size(892, 400);
            vendorApplicationTreeView.TabIndex = 179;
            // 
            // vendorApplicationRawBox
            // 
            vendorApplicationRawBox.Location = new System.Drawing.Point(915, 285);
            vendorApplicationRawBox.Multiline = true;
            vendorApplicationRawBox.Name = "vendorApplicationRawBox";
            vendorApplicationRawBox.ReadOnly = true;
            vendorApplicationRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            vendorApplicationRawBox.Size = new System.Drawing.Size(411, 400);
            vendorApplicationRawBox.TabIndex = 178;
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Location = new System.Drawing.Point(685, 152);
            label60.Margin = new System.Windows.Forms.Padding(0);
            label60.Name = "label60";
            label60.Size = new System.Drawing.Size(81, 20);
            label60.TabIndex = 177;
            label60.Text = "App Name";
            // 
            // textAppName
            // 
            textAppName.Location = new System.Drawing.Point(769, 145);
            textAppName.Name = "textAppName";
            textAppName.Size = new System.Drawing.Size(125, 27);
            textAppName.TabIndex = 176;
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new System.Drawing.Point(657, 197);
            label59.Margin = new System.Windows.Forms.Padding(0);
            label59.Name = "label59";
            label59.Size = new System.Drawing.Size(112, 20);
            label59.TabIndex = 175;
            label59.Text = "Active Interface";
            // 
            // textActiveInterface
            // 
            textActiveInterface.Location = new System.Drawing.Point(769, 189);
            textActiveInterface.Margin = new System.Windows.Forms.Padding(0);
            textActiveInterface.Name = "textActiveInterface";
            textActiveInterface.ReadOnly = true;
            textActiveInterface.Size = new System.Drawing.Size(121, 27);
            textActiveInterface.TabIndex = 174;
            // 
            // buttonGetActiveInterface
            // 
            buttonGetActiveInterface.Location = new System.Drawing.Point(927, 188);
            buttonGetActiveInterface.Name = "buttonGetActiveInterface";
            buttonGetActiveInterface.Size = new System.Drawing.Size(203, 29);
            buttonGetActiveInterface.TabIndex = 173;
            buttonGetActiveInterface.Text = "GetActiveInterface";
            buttonGetActiveInterface.UseVisualStyleBackColor = true;
            buttonGetActiveInterface.Click += buttonGetActiveInterface_Click;
            // 
            // buttonStartLocalApplication
            // 
            buttonStartLocalApplication.Location = new System.Drawing.Point(927, 143);
            buttonStartLocalApplication.Name = "buttonStartLocalApplication";
            buttonStartLocalApplication.Size = new System.Drawing.Size(211, 29);
            buttonStartLocalApplication.TabIndex = 172;
            buttonStartLocalApplication.Text = "StartLocalApplication";
            buttonStartLocalApplication.UseVisualStyleBackColor = true;
            buttonStartLocalApplication.Click += buttonStartLocalApplication_Click;
            // 
            // btnVendorAppServiceDiscovery
            // 
            btnVendorAppServiceDiscovery.Location = new System.Drawing.Point(510, 117);
            btnVendorAppServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            btnVendorAppServiceDiscovery.Name = "btnVendorAppServiceDiscovery";
            btnVendorAppServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            btnVendorAppServiceDiscovery.TabIndex = 165;
            btnVendorAppServiceDiscovery.Text = "Service Discovery";
            btnVendorAppServiceDiscovery.UseVisualStyleBackColor = true;
            btnVendorAppServiceDiscovery.Click += btnVendorAppServiceDiscovery_Click;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new System.Drawing.Point(673, 13);
            label54.Margin = new System.Windows.Forms.Padding(0);
            label54.Name = "label54";
            label54.Size = new System.Drawing.Size(96, 20);
            label54.TabIndex = 164;
            label54.Text = "Device status";
            // 
            // VendorAppStatus
            // 
            VendorAppStatus.Location = new System.Drawing.Point(769, 13);
            VendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            VendorAppStatus.Name = "VendorAppStatus";
            VendorAppStatus.ReadOnly = true;
            VendorAppStatus.Size = new System.Drawing.Size(121, 27);
            VendorAppStatus.TabIndex = 163;
            // 
            // btnVendorAppCapabilities
            // 
            btnVendorAppCapabilities.Location = new System.Drawing.Point(927, 51);
            btnVendorAppCapabilities.Margin = new System.Windows.Forms.Padding(0);
            btnVendorAppCapabilities.Name = "btnVendorAppCapabilities";
            btnVendorAppCapabilities.Size = new System.Drawing.Size(103, 29);
            btnVendorAppCapabilities.TabIndex = 162;
            btnVendorAppCapabilities.Text = "Capabilities";
            btnVendorAppCapabilities.UseVisualStyleBackColor = true;
            btnVendorAppCapabilities.Click += btnVendorAppCapabilities_Click;
            // 
            // btnVendorAppStatus
            // 
            btnVendorAppStatus.Location = new System.Drawing.Point(927, 13);
            btnVendorAppStatus.Margin = new System.Windows.Forms.Padding(0);
            btnVendorAppStatus.Name = "btnVendorAppStatus";
            btnVendorAppStatus.Size = new System.Drawing.Size(103, 29);
            btnVendorAppStatus.TabIndex = 161;
            btnVendorAppStatus.Text = "Status";
            btnVendorAppStatus.UseVisualStyleBackColor = true;
            btnVendorAppStatus.Click += btnVendorAppStatus_Click;
            // 
            // VendorAppServiceURI
            // 
            VendorAppServiceURI.ImeMode = System.Windows.Forms.ImeMode.Off;
            VendorAppServiceURI.Location = new System.Drawing.Point(113, 13);
            VendorAppServiceURI.Margin = new System.Windows.Forms.Padding(0);
            VendorAppServiceURI.Name = "VendorAppServiceURI";
            VendorAppServiceURI.Size = new System.Drawing.Size(530, 27);
            VendorAppServiceURI.TabIndex = 159;
            // 
            // VendorAppPortNum
            // 
            VendorAppPortNum.Location = new System.Drawing.Point(113, 45);
            VendorAppPortNum.Margin = new System.Windows.Forms.Padding(0);
            VendorAppPortNum.Name = "VendorAppPortNum";
            VendorAppPortNum.ReadOnly = true;
            VendorAppPortNum.Size = new System.Drawing.Size(121, 27);
            VendorAppPortNum.TabIndex = 155;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new System.Drawing.Point(3, 81);
            label55.Margin = new System.Windows.Forms.Padding(0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(111, 20);
            label55.TabIndex = 156;
            label55.Text = "VendorApp URI";
            // 
            // VendorAppURI
            // 
            VendorAppURI.Location = new System.Drawing.Point(113, 77);
            VendorAppURI.Margin = new System.Windows.Forms.Padding(0);
            VendorAppURI.Name = "VendorAppURI";
            VendorAppURI.ReadOnly = true;
            VendorAppURI.Size = new System.Drawing.Size(530, 27);
            VendorAppURI.TabIndex = 157;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new System.Drawing.Point(5, 45);
            label56.Margin = new System.Windows.Forms.Padding(0);
            label56.Name = "label56";
            label56.Size = new System.Drawing.Size(93, 20);
            label56.TabIndex = 158;
            label56.Text = "Port Number";
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new System.Drawing.Point(5, 13);
            label57.Margin = new System.Windows.Forms.Padding(0);
            label57.Name = "label57";
            label57.Size = new System.Drawing.Size(83, 20);
            label57.TabIndex = 160;
            label57.Text = "Service URI";
            // 
            // BarcodeReaderTabPage
            // 
            BarcodeReaderTabPage.Controls.Add(barcodeReaderTreeView);
            BarcodeReaderTabPage.Controls.Add(barcodeReaderRawBox);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderReset);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderRead);
            BarcodeReaderTabPage.Controls.Add(label61);
            BarcodeReaderTabPage.Controls.Add(label62);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderScannerStatus);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderStDevice);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderCapabilities);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderStatus);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderServiceURI);
            BarcodeReaderTabPage.Controls.Add(btnBarcodeReaderServiceDiscovery);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderPortNum);
            BarcodeReaderTabPage.Controls.Add(label63);
            BarcodeReaderTabPage.Controls.Add(BarcodeReaderURI);
            BarcodeReaderTabPage.Controls.Add(label64);
            BarcodeReaderTabPage.Controls.Add(label65);
            BarcodeReaderTabPage.Location = new System.Drawing.Point(4, 29);
            BarcodeReaderTabPage.Name = "BarcodeReaderTabPage";
            BarcodeReaderTabPage.Padding = new System.Windows.Forms.Padding(3);
            BarcodeReaderTabPage.Size = new System.Drawing.Size(1346, 691);
            BarcodeReaderTabPage.TabIndex = 10;
            BarcodeReaderTabPage.Text = "BarcodeReader";
            BarcodeReaderTabPage.UseVisualStyleBackColor = true;
            // 
            // barcodeReaderTreeView
            // 
            barcodeReaderTreeView.Location = new System.Drawing.Point(18, 271);
            barcodeReaderTreeView.Name = "barcodeReaderTreeView";
            barcodeReaderTreeView.Size = new System.Drawing.Size(887, 407);
            barcodeReaderTreeView.TabIndex = 134;
            // 
            // barcodeReaderRawBox
            // 
            barcodeReaderRawBox.Location = new System.Drawing.Point(923, 271);
            barcodeReaderRawBox.Multiline = true;
            barcodeReaderRawBox.Name = "barcodeReaderRawBox";
            barcodeReaderRawBox.ReadOnly = true;
            barcodeReaderRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            barcodeReaderRawBox.Size = new System.Drawing.Size(412, 407);
            barcodeReaderRawBox.TabIndex = 133;
            // 
            // BarcodeReaderReset
            // 
            BarcodeReaderReset.Location = new System.Drawing.Point(1215, 13);
            BarcodeReaderReset.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderReset.Name = "BarcodeReaderReset";
            BarcodeReaderReset.Size = new System.Drawing.Size(106, 29);
            BarcodeReaderReset.TabIndex = 132;
            BarcodeReaderReset.Text = "Reset";
            BarcodeReaderReset.UseVisualStyleBackColor = true;
            BarcodeReaderReset.Click += BarcodeReaderReset_Click;
            // 
            // BarcodeReaderRead
            // 
            BarcodeReaderRead.Location = new System.Drawing.Point(1093, 16);
            BarcodeReaderRead.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderRead.Name = "BarcodeReaderRead";
            BarcodeReaderRead.Size = new System.Drawing.Size(113, 29);
            BarcodeReaderRead.TabIndex = 131;
            BarcodeReaderRead.Text = "Read";
            BarcodeReaderRead.UseVisualStyleBackColor = true;
            BarcodeReaderRead.Click += BarcodeReaderRead_Click;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new System.Drawing.Point(670, 64);
            label61.Margin = new System.Windows.Forms.Padding(0);
            label61.Name = "label61";
            label61.Size = new System.Drawing.Size(105, 20);
            label61.TabIndex = 130;
            label61.Text = "Scanner Status";
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Location = new System.Drawing.Point(679, 17);
            label62.Margin = new System.Windows.Forms.Padding(0);
            label62.Name = "label62";
            label62.Size = new System.Drawing.Size(96, 20);
            label62.TabIndex = 129;
            label62.Text = "Device status";
            // 
            // BarcodeReaderScannerStatus
            // 
            BarcodeReaderScannerStatus.Location = new System.Drawing.Point(775, 61);
            BarcodeReaderScannerStatus.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderScannerStatus.Name = "BarcodeReaderScannerStatus";
            BarcodeReaderScannerStatus.ReadOnly = true;
            BarcodeReaderScannerStatus.Size = new System.Drawing.Size(121, 27);
            BarcodeReaderScannerStatus.TabIndex = 125;
            // 
            // BarcodeReaderStDevice
            // 
            BarcodeReaderStDevice.Location = new System.Drawing.Point(775, 17);
            BarcodeReaderStDevice.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderStDevice.Name = "BarcodeReaderStDevice";
            BarcodeReaderStDevice.ReadOnly = true;
            BarcodeReaderStDevice.Size = new System.Drawing.Size(121, 27);
            BarcodeReaderStDevice.TabIndex = 124;
            // 
            // BarcodeReaderCapabilities
            // 
            BarcodeReaderCapabilities.Location = new System.Drawing.Point(933, 52);
            BarcodeReaderCapabilities.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderCapabilities.Name = "BarcodeReaderCapabilities";
            BarcodeReaderCapabilities.Size = new System.Drawing.Size(103, 29);
            BarcodeReaderCapabilities.TabIndex = 123;
            BarcodeReaderCapabilities.Text = "Capabilities";
            BarcodeReaderCapabilities.UseVisualStyleBackColor = true;
            BarcodeReaderCapabilities.Click += BarcodeReaderCapabilities_Click;
            // 
            // BarcodeReaderStatus
            // 
            BarcodeReaderStatus.Location = new System.Drawing.Point(933, 13);
            BarcodeReaderStatus.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderStatus.Name = "BarcodeReaderStatus";
            BarcodeReaderStatus.Size = new System.Drawing.Size(103, 29);
            BarcodeReaderStatus.TabIndex = 122;
            BarcodeReaderStatus.Text = "Status";
            BarcodeReaderStatus.UseVisualStyleBackColor = true;
            BarcodeReaderStatus.Click += BarcodeReaderStatus_Click;
            // 
            // BarcodeReaderServiceURI
            // 
            BarcodeReaderServiceURI.Location = new System.Drawing.Point(129, 17);
            BarcodeReaderServiceURI.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderServiceURI.Name = "BarcodeReaderServiceURI";
            BarcodeReaderServiceURI.Size = new System.Drawing.Size(530, 27);
            BarcodeReaderServiceURI.TabIndex = 120;
            // 
            // btnBarcodeReaderServiceDiscovery
            // 
            btnBarcodeReaderServiceDiscovery.Location = new System.Drawing.Point(506, 128);
            btnBarcodeReaderServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            btnBarcodeReaderServiceDiscovery.Name = "btnBarcodeReaderServiceDiscovery";
            btnBarcodeReaderServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            btnBarcodeReaderServiceDiscovery.TabIndex = 115;
            btnBarcodeReaderServiceDiscovery.Text = "Service Discovery";
            btnBarcodeReaderServiceDiscovery.UseVisualStyleBackColor = true;
            btnBarcodeReaderServiceDiscovery.Click += btnBarcodeReaderServiceDiscovery_Click;
            // 
            // BarcodeReaderPortNum
            // 
            BarcodeReaderPortNum.Location = new System.Drawing.Point(129, 49);
            BarcodeReaderPortNum.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderPortNum.Name = "BarcodeReaderPortNum";
            BarcodeReaderPortNum.ReadOnly = true;
            BarcodeReaderPortNum.Size = new System.Drawing.Size(121, 27);
            BarcodeReaderPortNum.TabIndex = 116;
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Location = new System.Drawing.Point(5, 84);
            label63.Margin = new System.Windows.Forms.Padding(0);
            label63.Name = "label63";
            label63.Size = new System.Drawing.Size(138, 20);
            label63.TabIndex = 117;
            label63.Text = "BarcodeReader URI";
            // 
            // BarcodeReaderURI
            // 
            BarcodeReaderURI.Location = new System.Drawing.Point(129, 80);
            BarcodeReaderURI.Margin = new System.Windows.Forms.Padding(0);
            BarcodeReaderURI.Name = "BarcodeReaderURI";
            BarcodeReaderURI.ReadOnly = true;
            BarcodeReaderURI.Size = new System.Drawing.Size(530, 27);
            BarcodeReaderURI.TabIndex = 118;
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new System.Drawing.Point(7, 49);
            label64.Margin = new System.Windows.Forms.Padding(0);
            label64.Name = "label64";
            label64.Size = new System.Drawing.Size(93, 20);
            label64.TabIndex = 119;
            label64.Text = "Port Number";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new System.Drawing.Point(7, 17);
            label65.Margin = new System.Windows.Forms.Padding(0);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(83, 20);
            label65.TabIndex = 121;
            label65.Text = "Service URI";
            // 
            // BiometricPage
            // 
            BiometricPage.Controls.Add(biometricTreeView);
            BiometricPage.Controls.Add(biometricRawBox);
            BiometricPage.Controls.Add(label77);
            BiometricPage.Controls.Add(label76);
            BiometricPage.Controls.Add(btnBiometricGetStorageInfo);
            BiometricPage.Controls.Add(BiometricStorageInfo);
            BiometricPage.Controls.Add(btnBiometricReadMatch);
            BiometricPage.Controls.Add(label71);
            BiometricPage.Controls.Add(txtBiometricTemplateData);
            BiometricPage.Controls.Add(btnBiometricClear);
            BiometricPage.Controls.Add(btnBiometricMatch);
            BiometricPage.Controls.Add(btnBiometricImport);
            BiometricPage.Controls.Add(btnBiometricReset);
            BiometricPage.Controls.Add(btnBiometricRead);
            BiometricPage.Controls.Add(label67);
            BiometricPage.Controls.Add(BiometricStatus);
            BiometricPage.Controls.Add(btnBiometricCapabilities);
            BiometricPage.Controls.Add(btnBiometricStatus);
            BiometricPage.Controls.Add(BiometricServiceURI);
            BiometricPage.Controls.Add(btnBiometricServiceDiscovery);
            BiometricPage.Controls.Add(BiometricPortNum);
            BiometricPage.Controls.Add(label68);
            BiometricPage.Controls.Add(BiometricURI);
            BiometricPage.Controls.Add(label69);
            BiometricPage.Controls.Add(label70);
            BiometricPage.Location = new System.Drawing.Point(4, 29);
            BiometricPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BiometricPage.Name = "BiometricPage";
            BiometricPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            BiometricPage.Size = new System.Drawing.Size(1346, 691);
            BiometricPage.TabIndex = 11;
            BiometricPage.Text = "Biometric";
            BiometricPage.UseVisualStyleBackColor = true;
            // 
            // biometricTreeView
            // 
            biometricTreeView.Location = new System.Drawing.Point(17, 269);
            biometricTreeView.Name = "biometricTreeView";
            biometricTreeView.Size = new System.Drawing.Size(889, 405);
            biometricTreeView.TabIndex = 164;
            // 
            // biometricRawBox
            // 
            biometricRawBox.Location = new System.Drawing.Point(927, 269);
            biometricRawBox.Multiline = true;
            biometricRawBox.Name = "biometricRawBox";
            biometricRawBox.ReadOnly = true;
            biometricRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            biometricRawBox.Size = new System.Drawing.Size(409, 405);
            biometricRawBox.TabIndex = 163;
            // 
            // label77
            // 
            label77.AutoSize = true;
            label77.Location = new System.Drawing.Point(8, 51);
            label77.Margin = new System.Windows.Forms.Padding(0);
            label77.Name = "label77";
            label77.Size = new System.Drawing.Size(93, 20);
            label77.TabIndex = 162;
            label77.Text = "Port Number";
            // 
            // label76
            // 
            label76.AutoSize = true;
            label76.Location = new System.Drawing.Point(8, 17);
            label76.Margin = new System.Windows.Forms.Padding(0);
            label76.Name = "label76";
            label76.Size = new System.Drawing.Size(83, 20);
            label76.TabIndex = 161;
            label76.Text = "Service URI";
            // 
            // btnBiometricGetStorageInfo
            // 
            btnBiometricGetStorageInfo.Location = new System.Drawing.Point(1089, 151);
            btnBiometricGetStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricGetStorageInfo.Name = "btnBiometricGetStorageInfo";
            btnBiometricGetStorageInfo.Size = new System.Drawing.Size(113, 29);
            btnBiometricGetStorageInfo.TabIndex = 158;
            btnBiometricGetStorageInfo.Text = "GetStorageInfo";
            btnBiometricGetStorageInfo.UseVisualStyleBackColor = true;
            btnBiometricGetStorageInfo.Click += btnBiometricGetStorageInfo_Click;
            // 
            // BiometricStorageInfo
            // 
            BiometricStorageInfo.FormattingEnabled = true;
            BiometricStorageInfo.Location = new System.Drawing.Point(931, 105);
            BiometricStorageInfo.Margin = new System.Windows.Forms.Padding(0);
            BiometricStorageInfo.Name = "BiometricStorageInfo";
            BiometricStorageInfo.Size = new System.Drawing.Size(118, 124);
            BiometricStorageInfo.TabIndex = 157;
            // 
            // btnBiometricReadMatch
            // 
            btnBiometricReadMatch.Location = new System.Drawing.Point(1214, 61);
            btnBiometricReadMatch.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricReadMatch.Name = "btnBiometricReadMatch";
            btnBiometricReadMatch.Size = new System.Drawing.Size(113, 29);
            btnBiometricReadMatch.TabIndex = 156;
            btnBiometricReadMatch.Text = "Read(Match)";
            btnBiometricReadMatch.UseVisualStyleBackColor = true;
            btnBiometricReadMatch.Click += btnBiometricReadMatch_Click;
            // 
            // label71
            // 
            label71.AutoSize = true;
            label71.Location = new System.Drawing.Point(17, 160);
            label71.Margin = new System.Windows.Forms.Padding(0);
            label71.Name = "label71";
            label71.Size = new System.Drawing.Size(161, 20);
            label71.TabIndex = 155;
            label71.Text = "Base64 Template Data:";
            // 
            // txtBiometricTemplateData
            // 
            txtBiometricTemplateData.Location = new System.Drawing.Point(17, 192);
            txtBiometricTemplateData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtBiometricTemplateData.Name = "txtBiometricTemplateData";
            txtBiometricTemplateData.Size = new System.Drawing.Size(893, 27);
            txtBiometricTemplateData.TabIndex = 154;
            // 
            // btnBiometricClear
            // 
            btnBiometricClear.Location = new System.Drawing.Point(1089, 13);
            btnBiometricClear.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricClear.Name = "btnBiometricClear";
            btnBiometricClear.Size = new System.Drawing.Size(113, 29);
            btnBiometricClear.TabIndex = 153;
            btnBiometricClear.Text = "Clear";
            btnBiometricClear.UseVisualStyleBackColor = true;
            btnBiometricClear.Click += btnBiometricClear_Click;
            // 
            // btnBiometricMatch
            // 
            btnBiometricMatch.Location = new System.Drawing.Point(1214, 105);
            btnBiometricMatch.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricMatch.Name = "btnBiometricMatch";
            btnBiometricMatch.Size = new System.Drawing.Size(113, 29);
            btnBiometricMatch.TabIndex = 152;
            btnBiometricMatch.Text = "Match";
            btnBiometricMatch.UseVisualStyleBackColor = true;
            btnBiometricMatch.Click += btnBiometricMatch_Click;
            // 
            // btnBiometricImport
            // 
            btnBiometricImport.Location = new System.Drawing.Point(1089, 105);
            btnBiometricImport.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricImport.Name = "btnBiometricImport";
            btnBiometricImport.Size = new System.Drawing.Size(113, 29);
            btnBiometricImport.TabIndex = 151;
            btnBiometricImport.Text = "Import";
            btnBiometricImport.UseVisualStyleBackColor = true;
            btnBiometricImport.Click += btnBiometricImport_Click;
            // 
            // btnBiometricReset
            // 
            btnBiometricReset.Location = new System.Drawing.Point(1214, 13);
            btnBiometricReset.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricReset.Name = "btnBiometricReset";
            btnBiometricReset.Size = new System.Drawing.Size(113, 29);
            btnBiometricReset.TabIndex = 150;
            btnBiometricReset.Text = "Reset";
            btnBiometricReset.UseVisualStyleBackColor = true;
            btnBiometricReset.Click += btnBiometricReset_Click;
            // 
            // btnBiometricRead
            // 
            btnBiometricRead.Location = new System.Drawing.Point(1089, 61);
            btnBiometricRead.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricRead.Name = "btnBiometricRead";
            btnBiometricRead.Size = new System.Drawing.Size(113, 29);
            btnBiometricRead.TabIndex = 149;
            btnBiometricRead.Text = "Read(Scan)";
            btnBiometricRead.UseVisualStyleBackColor = true;
            btnBiometricRead.Click += btnBiometricRead_Click;
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new System.Drawing.Point(678, 15);
            label67.Margin = new System.Windows.Forms.Padding(0);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(96, 20);
            label67.TabIndex = 147;
            label67.Text = "Device status";
            // 
            // BiometricStatus
            // 
            BiometricStatus.Location = new System.Drawing.Point(774, 15);
            BiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            BiometricStatus.Name = "BiometricStatus";
            BiometricStatus.ReadOnly = true;
            BiometricStatus.Size = new System.Drawing.Size(121, 27);
            BiometricStatus.TabIndex = 142;
            // 
            // btnBiometricCapabilities
            // 
            btnBiometricCapabilities.Location = new System.Drawing.Point(931, 49);
            btnBiometricCapabilities.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricCapabilities.Name = "btnBiometricCapabilities";
            btnBiometricCapabilities.Size = new System.Drawing.Size(119, 29);
            btnBiometricCapabilities.TabIndex = 141;
            btnBiometricCapabilities.Text = "Capabilities";
            btnBiometricCapabilities.UseVisualStyleBackColor = true;
            btnBiometricCapabilities.Click += btnBiometricCapabilities_Click;
            // 
            // btnBiometricStatus
            // 
            btnBiometricStatus.Location = new System.Drawing.Point(931, 11);
            btnBiometricStatus.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricStatus.Name = "btnBiometricStatus";
            btnBiometricStatus.Size = new System.Drawing.Size(119, 29);
            btnBiometricStatus.TabIndex = 140;
            btnBiometricStatus.Text = "Status";
            btnBiometricStatus.UseVisualStyleBackColor = true;
            btnBiometricStatus.Click += btnBiometricStatus_Click;
            // 
            // BiometricServiceURI
            // 
            BiometricServiceURI.Location = new System.Drawing.Point(118, 15);
            BiometricServiceURI.Margin = new System.Windows.Forms.Padding(0);
            BiometricServiceURI.Name = "BiometricServiceURI";
            BiometricServiceURI.Size = new System.Drawing.Size(530, 27);
            BiometricServiceURI.TabIndex = 138;
            // 
            // btnBiometricServiceDiscovery
            // 
            btnBiometricServiceDiscovery.Location = new System.Drawing.Point(515, 129);
            btnBiometricServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            btnBiometricServiceDiscovery.Name = "btnBiometricServiceDiscovery";
            btnBiometricServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            btnBiometricServiceDiscovery.TabIndex = 133;
            btnBiometricServiceDiscovery.Text = "Service Discovery";
            btnBiometricServiceDiscovery.UseVisualStyleBackColor = true;
            btnBiometricServiceDiscovery.Click += btnBiometricServiceDiscovery_Click;
            // 
            // BiometricPortNum
            // 
            BiometricPortNum.Location = new System.Drawing.Point(118, 47);
            BiometricPortNum.Margin = new System.Windows.Forms.Padding(0);
            BiometricPortNum.Name = "BiometricPortNum";
            BiometricPortNum.ReadOnly = true;
            BiometricPortNum.Size = new System.Drawing.Size(121, 27);
            BiometricPortNum.TabIndex = 134;
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Location = new System.Drawing.Point(8, 80);
            label68.Margin = new System.Windows.Forms.Padding(0);
            label68.Name = "label68";
            label68.Size = new System.Drawing.Size(100, 20);
            label68.TabIndex = 135;
            label68.Text = "Biometric URI";
            // 
            // BiometricURI
            // 
            BiometricURI.Location = new System.Drawing.Point(118, 77);
            BiometricURI.Margin = new System.Windows.Forms.Padding(0);
            BiometricURI.Name = "BiometricURI";
            BiometricURI.ReadOnly = true;
            BiometricURI.Size = new System.Drawing.Size(530, 27);
            BiometricURI.TabIndex = 136;
            // 
            // label69
            // 
            label69.Location = new System.Drawing.Point(0, 0);
            label69.Name = "label69";
            label69.Size = new System.Drawing.Size(101, 23);
            label69.TabIndex = 159;
            // 
            // label70
            // 
            label70.Location = new System.Drawing.Point(0, 0);
            label70.Name = "label70";
            label70.Size = new System.Drawing.Size(101, 23);
            label70.TabIndex = 160;
            // 
            // CashAccTabPage
            // 
            CashAccTabPage.Controls.Add(cashAcceptorTreeView);
            CashAccTabPage.Controls.Add(cashAcceptorRawBox);
            CashAccTabPage.Controls.Add(CashAccSetCashUnitInfo);
            CashAccTabPage.Controls.Add(CashAccRetract);
            CashAccTabPage.Controls.Add(CashAccCashIn);
            CashAccTabPage.Controls.Add(CashAccConfigureNoteTypes);
            CashAccTabPage.Controls.Add(CashAccCashInEnd);
            CashAccTabPage.Controls.Add(CashAccCashInStart);
            CashAccTabPage.Controls.Add(CashAccCashInRollback);
            CashAccTabPage.Controls.Add(CashAccEndExchange);
            CashAccTabPage.Controls.Add(CashAccStartExchange);
            CashAccTabPage.Controls.Add(CashAccReset);
            CashAccTabPage.Controls.Add(CashAccCashInStatus);
            CashAccTabPage.Controls.Add(CashAccDeviceType);
            CashAccTabPage.Controls.Add(label66);
            CashAccTabPage.Controls.Add(label72);
            CashAccTabPage.Controls.Add(CashAccStDevice);
            CashAccTabPage.Controls.Add(CashAccCapabilities);
            CashAccTabPage.Controls.Add(CashAccStatus);
            CashAccTabPage.Controls.Add(CashAccGetCashUnitInfo);
            CashAccTabPage.Controls.Add(CashAcceptorServiceURI);
            CashAccTabPage.Controls.Add(CashAcceptorServiceDiscovery);
            CashAccTabPage.Controls.Add(CashAcceptorPortNum);
            CashAccTabPage.Controls.Add(label73);
            CashAccTabPage.Controls.Add(CashAcceptorAccURI);
            CashAccTabPage.Controls.Add(label74);
            CashAccTabPage.Controls.Add(label75);
            CashAccTabPage.Location = new System.Drawing.Point(4, 29);
            CashAccTabPage.Name = "CashAccTabPage";
            CashAccTabPage.Padding = new System.Windows.Forms.Padding(3);
            CashAccTabPage.Size = new System.Drawing.Size(1346, 691);
            CashAccTabPage.TabIndex = 12;
            CashAccTabPage.Text = "CashAcceptor";
            CashAccTabPage.UseVisualStyleBackColor = true;
            // 
            // cashAcceptorTreeView
            // 
            cashAcceptorTreeView.Location = new System.Drawing.Point(21, 275);
            cashAcceptorTreeView.Name = "cashAcceptorTreeView";
            cashAcceptorTreeView.Size = new System.Drawing.Size(892, 405);
            cashAcceptorTreeView.TabIndex = 76;
            // 
            // cashAcceptorRawBox
            // 
            cashAcceptorRawBox.Location = new System.Drawing.Point(929, 275);
            cashAcceptorRawBox.Multiline = true;
            cashAcceptorRawBox.Name = "cashAcceptorRawBox";
            cashAcceptorRawBox.ReadOnly = true;
            cashAcceptorRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            cashAcceptorRawBox.Size = new System.Drawing.Size(407, 405);
            cashAcceptorRawBox.TabIndex = 75;
            // 
            // CashAccSetCashUnitInfo
            // 
            CashAccSetCashUnitInfo.Location = new System.Drawing.Point(904, 100);
            CashAccSetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            CashAccSetCashUnitInfo.Name = "CashAccSetCashUnitInfo";
            CashAccSetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            CashAccSetCashUnitInfo.TabIndex = 74;
            CashAccSetCashUnitInfo.Text = "SetCashUnitInfo";
            CashAccSetCashUnitInfo.UseVisualStyleBackColor = true;
            CashAccSetCashUnitInfo.Click += CashAccSetCashUnitInfo_Click;
            // 
            // CashAccRetract
            // 
            CashAccRetract.Location = new System.Drawing.Point(1055, 217);
            CashAccRetract.Margin = new System.Windows.Forms.Padding(0);
            CashAccRetract.Name = "CashAccRetract";
            CashAccRetract.Size = new System.Drawing.Size(127, 28);
            CashAccRetract.TabIndex = 73;
            CashAccRetract.Text = "Retract";
            CashAccRetract.UseVisualStyleBackColor = true;
            CashAccRetract.Click += CashAccRetract_Click;
            // 
            // CashAccCashIn
            // 
            CashAccCashIn.Location = new System.Drawing.Point(1205, 144);
            CashAccCashIn.Margin = new System.Windows.Forms.Padding(0);
            CashAccCashIn.Name = "CashAccCashIn";
            CashAccCashIn.Size = new System.Drawing.Size(127, 28);
            CashAccCashIn.TabIndex = 72;
            CashAccCashIn.Text = "CashIn";
            CashAccCashIn.UseVisualStyleBackColor = true;
            CashAccCashIn.Click += CashAccCashIn_Click;
            // 
            // CashAccConfigureNoteTypes
            // 
            CashAccConfigureNoteTypes.Location = new System.Drawing.Point(1033, 53);
            CashAccConfigureNoteTypes.Margin = new System.Windows.Forms.Padding(0);
            CashAccConfigureNoteTypes.Name = "CashAccConfigureNoteTypes";
            CashAccConfigureNoteTypes.Size = new System.Drawing.Size(159, 29);
            CashAccConfigureNoteTypes.TabIndex = 70;
            CashAccConfigureNoteTypes.Text = "ConfigureNoteTypes";
            CashAccConfigureNoteTypes.UseVisualStyleBackColor = true;
            CashAccConfigureNoteTypes.Click += CashAccConfigureNoteTypes_Click;
            // 
            // CashAccCashInEnd
            // 
            CashAccCashInEnd.Location = new System.Drawing.Point(1205, 180);
            CashAccCashInEnd.Margin = new System.Windows.Forms.Padding(0);
            CashAccCashInEnd.Name = "CashAccCashInEnd";
            CashAccCashInEnd.Size = new System.Drawing.Size(127, 29);
            CashAccCashInEnd.TabIndex = 69;
            CashAccCashInEnd.Text = "CashInEnd";
            CashAccCashInEnd.UseVisualStyleBackColor = true;
            CashAccCashInEnd.Click += CashAccCashInEnd_Click;
            // 
            // CashAccCashInStart
            // 
            CashAccCashInStart.Location = new System.Drawing.Point(1055, 143);
            CashAccCashInStart.Margin = new System.Windows.Forms.Padding(0);
            CashAccCashInStart.Name = "CashAccCashInStart";
            CashAccCashInStart.Size = new System.Drawing.Size(127, 29);
            CashAccCashInStart.TabIndex = 68;
            CashAccCashInStart.Text = "CashInStart";
            CashAccCashInStart.UseVisualStyleBackColor = true;
            CashAccCashInStart.Click += CashAccCashInStart_Click;
            // 
            // CashAccCashInRollback
            // 
            CashAccCashInRollback.Location = new System.Drawing.Point(1205, 216);
            CashAccCashInRollback.Margin = new System.Windows.Forms.Padding(0);
            CashAccCashInRollback.Name = "CashAccCashInRollback";
            CashAccCashInRollback.Size = new System.Drawing.Size(127, 29);
            CashAccCashInRollback.TabIndex = 67;
            CashAccCashInRollback.Text = "CashInRollback";
            CashAccCashInRollback.UseVisualStyleBackColor = true;
            CashAccCashInRollback.Click += CashAccCashInRollback_Click;
            // 
            // CashAccEndExchange
            // 
            CashAccEndExchange.Location = new System.Drawing.Point(1205, 51);
            CashAccEndExchange.Margin = new System.Windows.Forms.Padding(0);
            CashAccEndExchange.Name = "CashAccEndExchange";
            CashAccEndExchange.Size = new System.Drawing.Size(127, 29);
            CashAccEndExchange.TabIndex = 66;
            CashAccEndExchange.Text = "EndExchange";
            CashAccEndExchange.UseVisualStyleBackColor = true;
            CashAccEndExchange.Click += CashAccEndExchange_Click;
            // 
            // CashAccStartExchange
            // 
            CashAccStartExchange.Location = new System.Drawing.Point(1205, 11);
            CashAccStartExchange.Margin = new System.Windows.Forms.Padding(0);
            CashAccStartExchange.Name = "CashAccStartExchange";
            CashAccStartExchange.Size = new System.Drawing.Size(127, 29);
            CashAccStartExchange.TabIndex = 65;
            CashAccStartExchange.Text = "StartExchange";
            CashAccStartExchange.UseVisualStyleBackColor = true;
            CashAccStartExchange.Click += CashAccStartExchange_Click;
            // 
            // CashAccReset
            // 
            CashAccReset.Location = new System.Drawing.Point(1033, 15);
            CashAccReset.Margin = new System.Windows.Forms.Padding(0);
            CashAccReset.Name = "CashAccReset";
            CashAccReset.Size = new System.Drawing.Size(127, 29);
            CashAccReset.TabIndex = 64;
            CashAccReset.Text = "Reset";
            CashAccReset.UseVisualStyleBackColor = true;
            CashAccReset.Click += CashAccReset_Click;
            // 
            // CashAccCashInStatus
            // 
            CashAccCashInStatus.Location = new System.Drawing.Point(904, 217);
            CashAccCashInStatus.Margin = new System.Windows.Forms.Padding(0);
            CashAccCashInStatus.Name = "CashAccCashInStatus";
            CashAccCashInStatus.Size = new System.Drawing.Size(127, 29);
            CashAccCashInStatus.TabIndex = 63;
            CashAccCashInStatus.Text = "GetCashInStatus";
            CashAccCashInStatus.UseVisualStyleBackColor = true;
            CashAccCashInStatus.Click += CashAccCashInStatus_Click;
            // 
            // CashAccDeviceType
            // 
            CashAccDeviceType.Location = new System.Drawing.Point(776, 57);
            CashAccDeviceType.Margin = new System.Windows.Forms.Padding(0);
            CashAccDeviceType.Name = "CashAccDeviceType";
            CashAccDeviceType.ReadOnly = true;
            CashAccDeviceType.Size = new System.Drawing.Size(121, 27);
            CashAccDeviceType.TabIndex = 62;
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Location = new System.Drawing.Point(689, 60);
            label66.Margin = new System.Windows.Forms.Padding(0);
            label66.Name = "label66";
            label66.Size = new System.Drawing.Size(87, 20);
            label66.TabIndex = 61;
            label66.Text = "Device type";
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Location = new System.Drawing.Point(680, 20);
            label72.Margin = new System.Windows.Forms.Padding(0);
            label72.Name = "label72";
            label72.Size = new System.Drawing.Size(96, 20);
            label72.TabIndex = 56;
            label72.Text = "Device status";
            // 
            // CashAccStDevice
            // 
            CashAccStDevice.Location = new System.Drawing.Point(776, 17);
            CashAccStDevice.Margin = new System.Windows.Forms.Padding(0);
            CashAccStDevice.Name = "CashAccStDevice";
            CashAccStDevice.ReadOnly = true;
            CashAccStDevice.Size = new System.Drawing.Size(121, 27);
            CashAccStDevice.TabIndex = 60;
            // 
            // CashAccCapabilities
            // 
            CashAccCapabilities.Location = new System.Drawing.Point(904, 56);
            CashAccCapabilities.Margin = new System.Windows.Forms.Padding(0);
            CashAccCapabilities.Name = "CashAccCapabilities";
            CashAccCapabilities.Size = new System.Drawing.Size(103, 29);
            CashAccCapabilities.TabIndex = 58;
            CashAccCapabilities.Text = "Capabilities";
            CashAccCapabilities.UseVisualStyleBackColor = true;
            CashAccCapabilities.Click += CashAccCapabilities_Click;
            // 
            // CashAccStatus
            // 
            CashAccStatus.Location = new System.Drawing.Point(904, 16);
            CashAccStatus.Margin = new System.Windows.Forms.Padding(0);
            CashAccStatus.Name = "CashAccStatus";
            CashAccStatus.Size = new System.Drawing.Size(103, 29);
            CashAccStatus.TabIndex = 57;
            CashAccStatus.Text = "Status";
            CashAccStatus.UseVisualStyleBackColor = true;
            CashAccStatus.Click += CashAccStatus_Click;
            // 
            // CashAccGetCashUnitInfo
            // 
            CashAccGetCashUnitInfo.Location = new System.Drawing.Point(904, 139);
            CashAccGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            CashAccGetCashUnitInfo.Name = "CashAccGetCashUnitInfo";
            CashAccGetCashUnitInfo.Size = new System.Drawing.Size(127, 29);
            CashAccGetCashUnitInfo.TabIndex = 55;
            CashAccGetCashUnitInfo.Text = "GetCashUnitInfo";
            CashAccGetCashUnitInfo.UseVisualStyleBackColor = true;
            CashAccGetCashUnitInfo.Click += CashAccGetCashUnitInfo_Click;
            // 
            // CashAcceptorServiceURI
            // 
            CashAcceptorServiceURI.Location = new System.Drawing.Point(117, 25);
            CashAcceptorServiceURI.Margin = new System.Windows.Forms.Padding(0);
            CashAcceptorServiceURI.Name = "CashAcceptorServiceURI";
            CashAcceptorServiceURI.Size = new System.Drawing.Size(530, 27);
            CashAcceptorServiceURI.TabIndex = 52;
            // 
            // CashAcceptorServiceDiscovery
            // 
            CashAcceptorServiceDiscovery.Location = new System.Drawing.Point(504, 136);
            CashAcceptorServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            CashAcceptorServiceDiscovery.Name = "CashAcceptorServiceDiscovery";
            CashAcceptorServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            CashAcceptorServiceDiscovery.TabIndex = 46;
            CashAcceptorServiceDiscovery.Text = "Service Discovery";
            CashAcceptorServiceDiscovery.UseVisualStyleBackColor = true;
            CashAcceptorServiceDiscovery.Click += CashAcceptorServiceDiscovery_Click;
            // 
            // CashAcceptorPortNum
            // 
            CashAcceptorPortNum.Location = new System.Drawing.Point(117, 57);
            CashAcceptorPortNum.Margin = new System.Windows.Forms.Padding(0);
            CashAcceptorPortNum.Name = "CashAcceptorPortNum";
            CashAcceptorPortNum.ReadOnly = true;
            CashAcceptorPortNum.Size = new System.Drawing.Size(121, 27);
            CashAcceptorPortNum.TabIndex = 47;
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Location = new System.Drawing.Point(7, 91);
            label73.Margin = new System.Windows.Forms.Padding(0);
            label73.Name = "label73";
            label73.Size = new System.Drawing.Size(96, 20);
            label73.TabIndex = 49;
            label73.Text = "Acceptor URI";
            // 
            // CashAcceptorAccURI
            // 
            CashAcceptorAccURI.Location = new System.Drawing.Point(117, 88);
            CashAcceptorAccURI.Margin = new System.Windows.Forms.Padding(0);
            CashAcceptorAccURI.Name = "CashAcceptorAccURI";
            CashAcceptorAccURI.ReadOnly = true;
            CashAcceptorAccURI.Size = new System.Drawing.Size(530, 27);
            CashAcceptorAccURI.TabIndex = 50;
            // 
            // label74
            // 
            label74.AutoSize = true;
            label74.Location = new System.Drawing.Point(9, 57);
            label74.Margin = new System.Windows.Forms.Padding(0);
            label74.Name = "label74";
            label74.Size = new System.Drawing.Size(93, 20);
            label74.TabIndex = 51;
            label74.Text = "Port Number";
            // 
            // label75
            // 
            label75.AutoSize = true;
            label75.Location = new System.Drawing.Point(9, 25);
            label75.Margin = new System.Windows.Forms.Padding(0);
            label75.Name = "label75";
            label75.Size = new System.Drawing.Size(83, 20);
            label75.TabIndex = 53;
            label75.Text = "Service URI";
            // 
            // CamTabPage
            // 
            CamTabPage.Controls.Add(TakePic);
            CamTabPage.Controls.Add(cameraTreeView);
            CamTabPage.Controls.Add(cameraRawBox);
            CamTabPage.Controls.Add(CameraReset);
            CamTabPage.Controls.Add(label79);
            CamTabPage.Controls.Add(StCamera);
            CamTabPage.Controls.Add(CameraCapabilities);
            CamTabPage.Controls.Add(CameraStatus);
            CamTabPage.Controls.Add(CameraServiceURI);
            CamTabPage.Controls.Add(CameraServiceDiscovery);
            CamTabPage.Controls.Add(CameraPortNum);
            CamTabPage.Controls.Add(label80);
            CamTabPage.Controls.Add(CameraURI);
            CamTabPage.Controls.Add(label81);
            CamTabPage.Controls.Add(label82);
            CamTabPage.Location = new System.Drawing.Point(4, 29);
            CamTabPage.Name = "CamTabPage";
            CamTabPage.Padding = new System.Windows.Forms.Padding(3);
            CamTabPage.Size = new System.Drawing.Size(1346, 691);
            CamTabPage.TabIndex = 13;
            CamTabPage.Text = "Camera";
            CamTabPage.UseVisualStyleBackColor = true;
            // 
            // TakePic
            // 
            TakePic.Location = new System.Drawing.Point(1211, 13);
            TakePic.Margin = new System.Windows.Forms.Padding(0);
            TakePic.Name = "TakePic";
            TakePic.Size = new System.Drawing.Size(127, 29);
            TakePic.TabIndex = 91;
            TakePic.Text = "TakePicture";
            TakePic.UseVisualStyleBackColor = true;
            TakePic.Click += TakePic_Click;
            // 
            // cameraTreeView
            // 
            cameraTreeView.Location = new System.Drawing.Point(23, 273);
            cameraTreeView.Name = "cameraTreeView";
            cameraTreeView.Size = new System.Drawing.Size(892, 405);
            cameraTreeView.TabIndex = 90;
            // 
            // cameraRawBox
            // 
            cameraRawBox.Location = new System.Drawing.Point(931, 273);
            cameraRawBox.Multiline = true;
            cameraRawBox.Name = "cameraRawBox";
            cameraRawBox.ReadOnly = true;
            cameraRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            cameraRawBox.Size = new System.Drawing.Size(407, 405);
            cameraRawBox.TabIndex = 89;
            cameraRawBox.WordWrap = false;
            // 
            // CameraReset
            // 
            CameraReset.Location = new System.Drawing.Point(1211, 53);
            CameraReset.Margin = new System.Windows.Forms.Padding(0);
            CameraReset.Name = "CameraReset";
            CameraReset.Size = new System.Drawing.Size(127, 29);
            CameraReset.TabIndex = 88;
            CameraReset.Text = "Reset";
            CameraReset.UseVisualStyleBackColor = true;
            CameraReset.Click += CameraReset_Click;
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Location = new System.Drawing.Point(682, 19);
            label79.Margin = new System.Windows.Forms.Padding(0);
            label79.Name = "label79";
            label79.Size = new System.Drawing.Size(96, 20);
            label79.TabIndex = 84;
            label79.Text = "Device status";
            // 
            // StCamera
            // 
            StCamera.Location = new System.Drawing.Point(778, 15);
            StCamera.Margin = new System.Windows.Forms.Padding(0);
            StCamera.Name = "StCamera";
            StCamera.ReadOnly = true;
            StCamera.Size = new System.Drawing.Size(121, 27);
            StCamera.TabIndex = 87;
            // 
            // CameraCapabilities
            // 
            CameraCapabilities.Location = new System.Drawing.Point(906, 53);
            CameraCapabilities.Margin = new System.Windows.Forms.Padding(0);
            CameraCapabilities.Name = "CameraCapabilities";
            CameraCapabilities.Size = new System.Drawing.Size(103, 29);
            CameraCapabilities.TabIndex = 86;
            CameraCapabilities.Text = "Capabilities";
            CameraCapabilities.UseVisualStyleBackColor = true;
            CameraCapabilities.Click += CameraCapabilities_Click;
            // 
            // CameraStatus
            // 
            CameraStatus.Location = new System.Drawing.Point(906, 13);
            CameraStatus.Margin = new System.Windows.Forms.Padding(0);
            CameraStatus.Name = "CameraStatus";
            CameraStatus.Size = new System.Drawing.Size(103, 29);
            CameraStatus.TabIndex = 85;
            CameraStatus.Text = "Status";
            CameraStatus.UseVisualStyleBackColor = true;
            CameraStatus.Click += CameraStatus_Click;
            // 
            // CameraServiceURI
            // 
            CameraServiceURI.Location = new System.Drawing.Point(119, 23);
            CameraServiceURI.Margin = new System.Windows.Forms.Padding(0);
            CameraServiceURI.Name = "CameraServiceURI";
            CameraServiceURI.Size = new System.Drawing.Size(530, 27);
            CameraServiceURI.TabIndex = 82;
            // 
            // CameraServiceDiscovery
            // 
            CameraServiceDiscovery.Location = new System.Drawing.Point(506, 133);
            CameraServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            CameraServiceDiscovery.Name = "CameraServiceDiscovery";
            CameraServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            CameraServiceDiscovery.TabIndex = 77;
            CameraServiceDiscovery.Text = "Service Discovery";
            CameraServiceDiscovery.UseVisualStyleBackColor = true;
            CameraServiceDiscovery.Click += CameraServiceDiscovery_Click;
            // 
            // CameraPortNum
            // 
            CameraPortNum.Location = new System.Drawing.Point(119, 55);
            CameraPortNum.Margin = new System.Windows.Forms.Padding(0);
            CameraPortNum.Name = "CameraPortNum";
            CameraPortNum.ReadOnly = true;
            CameraPortNum.Size = new System.Drawing.Size(121, 27);
            CameraPortNum.TabIndex = 78;
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Location = new System.Drawing.Point(9, 89);
            label80.Margin = new System.Windows.Forms.Padding(0);
            label80.Name = "label80";
            label80.Size = new System.Drawing.Size(87, 20);
            label80.TabIndex = 79;
            label80.Text = "Camera URI";
            // 
            // CameraURI
            // 
            CameraURI.Location = new System.Drawing.Point(119, 85);
            CameraURI.Margin = new System.Windows.Forms.Padding(0);
            CameraURI.Name = "CameraURI";
            CameraURI.ReadOnly = true;
            CameraURI.Size = new System.Drawing.Size(530, 27);
            CameraURI.TabIndex = 80;
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Location = new System.Drawing.Point(11, 55);
            label81.Margin = new System.Windows.Forms.Padding(0);
            label81.Name = "label81";
            label81.Size = new System.Drawing.Size(93, 20);
            label81.TabIndex = 81;
            label81.Text = "Port Number";
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Location = new System.Drawing.Point(11, 23);
            label82.Margin = new System.Windows.Forms.Padding(0);
            label82.Name = "label82";
            label82.Size = new System.Drawing.Size(83, 20);
            label82.TabIndex = 83;
            label82.Text = "Service URI";
            // 
            // CheckTabPage
            // 
            CheckTabPage.Controls.Add(viewTxnStatus);
            CheckTabPage.Controls.Add(checkScannerTreeView);
            CheckTabPage.Controls.Add(checkScannerRawBox);
            CheckTabPage.Controls.Add(CheckScannerSetCheckUnitInfo);
            CheckTabPage.Controls.Add(CheckScannerRetract);
            CheckTabPage.Controls.Add(CheckScannerMediaIn);
            CheckTabPage.Controls.Add(CheckScannerMediaInEnd);
            CheckTabPage.Controls.Add(CheckScannerMediaInRollback);
            CheckTabPage.Controls.Add(CheckScannerEndExchange);
            CheckTabPage.Controls.Add(CheckScannerStartExchange);
            CheckTabPage.Controls.Add(CheckScannerReset);
            CheckTabPage.Controls.Add(CheckScannerGetTransactionStatus);
            CheckTabPage.Controls.Add(CheckDeviceType);
            CheckTabPage.Controls.Add(label83);
            CheckTabPage.Controls.Add(label84);
            CheckTabPage.Controls.Add(StCheck);
            CheckTabPage.Controls.Add(CheckScannerCapabilities);
            CheckTabPage.Controls.Add(CheckScannerStatus);
            CheckTabPage.Controls.Add(CheckScannerGetCheckUnitInfo);
            CheckTabPage.Controls.Add(CheckScannerServiceURI);
            CheckTabPage.Controls.Add(CheckScannerServiceDiscovery);
            CheckTabPage.Controls.Add(CheckScannerPortNum);
            CheckTabPage.Controls.Add(label85);
            CheckTabPage.Controls.Add(CheckScannerURI);
            CheckTabPage.Controls.Add(label86);
            CheckTabPage.Controls.Add(label87);
            CheckTabPage.Location = new System.Drawing.Point(4, 29);
            CheckTabPage.Name = "CheckTabPage";
            CheckTabPage.Padding = new System.Windows.Forms.Padding(3);
            CheckTabPage.Size = new System.Drawing.Size(1346, 691);
            CheckTabPage.TabIndex = 14;
            CheckTabPage.Text = "CheckScanner";
            CheckTabPage.UseVisualStyleBackColor = true;
            // 
            // viewTxnStatus
            // 
            viewTxnStatus.Location = new System.Drawing.Point(848, 231);
            viewTxnStatus.Margin = new System.Windows.Forms.Padding(0);
            viewTxnStatus.Name = "viewTxnStatus";
            viewTxnStatus.Size = new System.Drawing.Size(185, 29);
            viewTxnStatus.TabIndex = 103;
            viewTxnStatus.Text = "View TransactionStatus";
            viewTxnStatus.UseVisualStyleBackColor = true;
            viewTxnStatus.Click += viewTxnStatus_Click;
            // 
            // checkScannerTreeView
            // 
            checkScannerTreeView.Location = new System.Drawing.Point(23, 275);
            checkScannerTreeView.Name = "checkScannerTreeView";
            checkScannerTreeView.Size = new System.Drawing.Size(892, 405);
            checkScannerTreeView.TabIndex = 102;
            // 
            // checkScannerRawBox
            // 
            checkScannerRawBox.Location = new System.Drawing.Point(931, 275);
            checkScannerRawBox.Multiline = true;
            checkScannerRawBox.Name = "checkScannerRawBox";
            checkScannerRawBox.ReadOnly = true;
            checkScannerRawBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            checkScannerRawBox.Size = new System.Drawing.Size(407, 405);
            checkScannerRawBox.TabIndex = 101;
            // 
            // CheckScannerSetCheckUnitInfo
            // 
            CheckScannerSetCheckUnitInfo.Location = new System.Drawing.Point(899, 100);
            CheckScannerSetCheckUnitInfo.Margin = new System.Windows.Forms.Padding(1);
            CheckScannerSetCheckUnitInfo.Name = "CheckScannerSetCheckUnitInfo";
            CheckScannerSetCheckUnitInfo.Size = new System.Drawing.Size(134, 29);
            CheckScannerSetCheckUnitInfo.TabIndex = 100;
            CheckScannerSetCheckUnitInfo.Text = "SetCheckUnitInfo";
            CheckScannerSetCheckUnitInfo.UseVisualStyleBackColor = true;
            CheckScannerSetCheckUnitInfo.Click += CheckScannerSetCheckUnitInfo_Click;
            // 
            // CheckScannerRetract
            // 
            CheckScannerRetract.Location = new System.Drawing.Point(1057, 232);
            CheckScannerRetract.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerRetract.Name = "CheckScannerRetract";
            CheckScannerRetract.Size = new System.Drawing.Size(127, 28);
            CheckScannerRetract.TabIndex = 99;
            CheckScannerRetract.Text = "Retract";
            CheckScannerRetract.UseVisualStyleBackColor = true;
            CheckScannerRetract.Click += CheckScannerRetract_Click;
            // 
            // CheckScannerMediaIn
            // 
            CheckScannerMediaIn.Location = new System.Drawing.Point(1201, 155);
            CheckScannerMediaIn.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerMediaIn.Name = "CheckScannerMediaIn";
            CheckScannerMediaIn.Size = new System.Drawing.Size(133, 28);
            CheckScannerMediaIn.TabIndex = 98;
            CheckScannerMediaIn.Text = "MediaIn";
            CheckScannerMediaIn.UseVisualStyleBackColor = true;
            CheckScannerMediaIn.Click += CheckScannerMediaIn_Click;
            // 
            // CheckScannerMediaInEnd
            // 
            CheckScannerMediaInEnd.Location = new System.Drawing.Point(1201, 192);
            CheckScannerMediaInEnd.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerMediaInEnd.Name = "CheckScannerMediaInEnd";
            CheckScannerMediaInEnd.Size = new System.Drawing.Size(133, 29);
            CheckScannerMediaInEnd.TabIndex = 97;
            CheckScannerMediaInEnd.Text = "MediaInInEnd";
            CheckScannerMediaInEnd.UseVisualStyleBackColor = true;
            CheckScannerMediaInEnd.Click += CheckScannerMediaInEnd_Click;
            // 
            // CheckScannerMediaInRollback
            // 
            CheckScannerMediaInRollback.Location = new System.Drawing.Point(1201, 231);
            CheckScannerMediaInRollback.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerMediaInRollback.Name = "CheckScannerMediaInRollback";
            CheckScannerMediaInRollback.Size = new System.Drawing.Size(133, 29);
            CheckScannerMediaInRollback.TabIndex = 95;
            CheckScannerMediaInRollback.Text = "MediaInRollback";
            CheckScannerMediaInRollback.UseVisualStyleBackColor = true;
            CheckScannerMediaInRollback.Click += CheckScannerMediaInRollback_Click;
            // 
            // CheckScannerEndExchange
            // 
            CheckScannerEndExchange.Location = new System.Drawing.Point(1201, 60);
            CheckScannerEndExchange.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerEndExchange.Name = "CheckScannerEndExchange";
            CheckScannerEndExchange.Size = new System.Drawing.Size(133, 29);
            CheckScannerEndExchange.TabIndex = 94;
            CheckScannerEndExchange.Text = "EndExchange";
            CheckScannerEndExchange.UseVisualStyleBackColor = true;
            CheckScannerEndExchange.Click += CheckScannerEndExchange_Click;
            // 
            // CheckScannerStartExchange
            // 
            CheckScannerStartExchange.Location = new System.Drawing.Point(1201, 17);
            CheckScannerStartExchange.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerStartExchange.Name = "CheckScannerStartExchange";
            CheckScannerStartExchange.Size = new System.Drawing.Size(133, 29);
            CheckScannerStartExchange.TabIndex = 93;
            CheckScannerStartExchange.Text = "StartExchange";
            CheckScannerStartExchange.UseVisualStyleBackColor = true;
            CheckScannerStartExchange.Click += CheckScannerStartExchange_Click;
            // 
            // CheckScannerReset
            // 
            CheckScannerReset.Location = new System.Drawing.Point(1057, 15);
            CheckScannerReset.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerReset.Name = "CheckScannerReset";
            CheckScannerReset.Size = new System.Drawing.Size(127, 29);
            CheckScannerReset.TabIndex = 92;
            CheckScannerReset.Text = "Reset";
            CheckScannerReset.UseVisualStyleBackColor = true;
            CheckScannerReset.Click += CheckScannerReset_Click;
            // 
            // CheckScannerGetTransactionStatus
            // 
            CheckScannerGetTransactionStatus.Location = new System.Drawing.Point(848, 192);
            CheckScannerGetTransactionStatus.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerGetTransactionStatus.Name = "CheckScannerGetTransactionStatus";
            CheckScannerGetTransactionStatus.Size = new System.Drawing.Size(185, 29);
            CheckScannerGetTransactionStatus.TabIndex = 91;
            CheckScannerGetTransactionStatus.Text = "GetTransactionStatus";
            CheckScannerGetTransactionStatus.UseVisualStyleBackColor = true;
            CheckScannerGetTransactionStatus.Click += CheckScannerGetTransactionStatus_Click;
            // 
            // CheckDeviceType
            // 
            CheckDeviceType.Location = new System.Drawing.Point(794, 57);
            CheckDeviceType.Margin = new System.Windows.Forms.Padding(0);
            CheckDeviceType.Name = "CheckDeviceType";
            CheckDeviceType.ReadOnly = true;
            CheckDeviceType.Size = new System.Drawing.Size(121, 27);
            CheckDeviceType.TabIndex = 90;
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Location = new System.Drawing.Point(700, 60);
            label83.Margin = new System.Windows.Forms.Padding(0);
            label83.Name = "label83";
            label83.Size = new System.Drawing.Size(87, 20);
            label83.TabIndex = 89;
            label83.Text = "Device type";
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Location = new System.Drawing.Point(691, 20);
            label84.Margin = new System.Windows.Forms.Padding(0);
            label84.Name = "label84";
            label84.Size = new System.Drawing.Size(96, 20);
            label84.TabIndex = 85;
            label84.Text = "Device status";
            // 
            // StCheck
            // 
            StCheck.Location = new System.Drawing.Point(794, 17);
            StCheck.Margin = new System.Windows.Forms.Padding(0);
            StCheck.Name = "StCheck";
            StCheck.ReadOnly = true;
            StCheck.Size = new System.Drawing.Size(121, 27);
            StCheck.TabIndex = 88;
            // 
            // CheckScannerCapabilities
            // 
            CheckScannerCapabilities.Location = new System.Drawing.Point(930, 57);
            CheckScannerCapabilities.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerCapabilities.Name = "CheckScannerCapabilities";
            CheckScannerCapabilities.Size = new System.Drawing.Size(103, 29);
            CheckScannerCapabilities.TabIndex = 87;
            CheckScannerCapabilities.Text = "Capabilities";
            CheckScannerCapabilities.UseVisualStyleBackColor = true;
            CheckScannerCapabilities.Click += CheckScannerCapabilities_Click;
            // 
            // CheckScannerStatus
            // 
            CheckScannerStatus.Location = new System.Drawing.Point(930, 16);
            CheckScannerStatus.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerStatus.Name = "CheckScannerStatus";
            CheckScannerStatus.Size = new System.Drawing.Size(103, 29);
            CheckScannerStatus.TabIndex = 86;
            CheckScannerStatus.Text = "Status";
            CheckScannerStatus.UseVisualStyleBackColor = true;
            CheckScannerStatus.Click += CheckScannerStatus_Click;
            // 
            // CheckScannerGetCheckUnitInfo
            // 
            CheckScannerGetCheckUnitInfo.Location = new System.Drawing.Point(899, 139);
            CheckScannerGetCheckUnitInfo.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerGetCheckUnitInfo.Name = "CheckScannerGetCheckUnitInfo";
            CheckScannerGetCheckUnitInfo.Size = new System.Drawing.Size(134, 29);
            CheckScannerGetCheckUnitInfo.TabIndex = 84;
            CheckScannerGetCheckUnitInfo.Text = "GetCheckUnitInfo";
            CheckScannerGetCheckUnitInfo.UseVisualStyleBackColor = true;
            CheckScannerGetCheckUnitInfo.Click += CheckScannerGetCheckUnitInfo_Click;
            // 
            // CheckScannerServiceURI
            // 
            CheckScannerServiceURI.Location = new System.Drawing.Point(119, 25);
            CheckScannerServiceURI.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerServiceURI.Name = "CheckScannerServiceURI";
            CheckScannerServiceURI.Size = new System.Drawing.Size(530, 27);
            CheckScannerServiceURI.TabIndex = 82;
            // 
            // CheckScannerServiceDiscovery
            // 
            CheckScannerServiceDiscovery.Location = new System.Drawing.Point(506, 136);
            CheckScannerServiceDiscovery.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerServiceDiscovery.Name = "CheckScannerServiceDiscovery";
            CheckScannerServiceDiscovery.Size = new System.Drawing.Size(133, 31);
            CheckScannerServiceDiscovery.TabIndex = 77;
            CheckScannerServiceDiscovery.Text = "Service Discovery";
            CheckScannerServiceDiscovery.UseVisualStyleBackColor = true;
            CheckScannerServiceDiscovery.Click += ChecKScannerServiceDiscovery_Click;
            // 
            // CheckScannerPortNum
            // 
            CheckScannerPortNum.Location = new System.Drawing.Point(119, 57);
            CheckScannerPortNum.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerPortNum.Name = "CheckScannerPortNum";
            CheckScannerPortNum.ReadOnly = true;
            CheckScannerPortNum.Size = new System.Drawing.Size(121, 27);
            CheckScannerPortNum.TabIndex = 78;
            // 
            // label85
            // 
            label85.AutoSize = true;
            label85.Location = new System.Drawing.Point(9, 91);
            label85.Margin = new System.Windows.Forms.Padding(0);
            label85.Name = "label85";
            label85.Size = new System.Drawing.Size(75, 20);
            label85.TabIndex = 79;
            label85.Text = "Check URI";
            // 
            // CheckScannerURI
            // 
            CheckScannerURI.Location = new System.Drawing.Point(119, 88);
            CheckScannerURI.Margin = new System.Windows.Forms.Padding(0);
            CheckScannerURI.Name = "CheckScannerURI";
            CheckScannerURI.ReadOnly = true;
            CheckScannerURI.Size = new System.Drawing.Size(530, 27);
            CheckScannerURI.TabIndex = 80;
            // 
            // label86
            // 
            label86.AutoSize = true;
            label86.Location = new System.Drawing.Point(11, 57);
            label86.Margin = new System.Windows.Forms.Padding(0);
            label86.Name = "label86";
            label86.Size = new System.Drawing.Size(93, 20);
            label86.TabIndex = 81;
            label86.Text = "Port Number";
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Location = new System.Drawing.Point(11, 25);
            label87.Margin = new System.Windows.Forms.Padding(0);
            label87.Name = "label87";
            label87.Size = new System.Drawing.Size(83, 20);
            label87.TabIndex = 83;
            label87.Text = "Service URI";
            // 
            // comboLightDevice
            // 
            comboLightDevice.FormattingEnabled = true;
            comboLightDevice.Location = new System.Drawing.Point(1178, 12);
            comboLightDevice.Name = "comboLightDevice";
            comboLightDevice.Size = new System.Drawing.Size(121, 28);
            comboLightDevice.TabIndex = 138;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1370, 736);
            Controls.Add(testClientTabControl);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Margin = new System.Windows.Forms.Padding(0);
            Name = "Form1";
            Text = "TestClientForms";
            Load += Form1_Load;
            testClientTabControl.ResumeLayout(false);
            CardReaderTab.ResumeLayout(false);
            CardReaderTab.PerformLayout();
            DispenserTab.ResumeLayout(false);
            DispenserTab.PerformLayout();
            TextTerminalTab.ResumeLayout(false);
            TextTerminalTab.PerformLayout();
            EncryptorTab.ResumeLayout(false);
            EncryptorTab.PerformLayout();
            PinPadTab.ResumeLayout(false);
            PinPadTab.PerformLayout();
            PrinterTabPage.ResumeLayout(false);
            PrinterTabPage.PerformLayout();
            lightsTab.ResumeLayout(false);
            lightsTab.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            VendorModeTabPage.ResumeLayout(false);
            VendorModeTabPage.PerformLayout();
            VendorAppTabPage.ResumeLayout(false);
            VendorAppTabPage.PerformLayout();
            BarcodeReaderTabPage.ResumeLayout(false);
            BarcodeReaderTabPage.PerformLayout();
            BiometricPage.ResumeLayout(false);
            BiometricPage.PerformLayout();
            CashAccTabPage.ResumeLayout(false);
            CashAccTabPage.PerformLayout();
            CamTabPage.ResumeLayout(false);
            CamTabPage.PerformLayout();
            CheckTabPage.ResumeLayout(false);
            CheckTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button AcceptCard;
        private System.Windows.Forms.Button EjectCard;
        private System.Windows.Forms.Button ServiceDiscovery;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCardReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServiceURI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button DispenserServiceDiscovery;
        private System.Windows.Forms.TextBox DispenserPortNum;
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
        private System.Windows.Forms.Button TextTerminalServiceDiscovery;
        private System.Windows.Forms.TextBox TextTerminalPortNum;
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
        private System.Windows.Forms.Button PrinterSetForm;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox PrinterFormFields;
        private System.Windows.Forms.TabPage lightsTab;
        private System.Windows.Forms.Button LightsSetLight;
        private System.Windows.Forms.Label label41;
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
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox LightsFlashRate;
        private System.Windows.Forms.Button LightsServiceDiscovery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAuxiliariesServiceDiscovery;
        private System.Windows.Forms.Label label48;
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
        private System.Windows.Forms.Button CashAccCapabilities;
        private System.Windows.Forms.Button CashAccStatus;
        private System.Windows.Forms.Button CashAccGetCashUnitInfo;
        private System.Windows.Forms.TextBox CashAcceptorServiceURI;
        private System.Windows.Forms.Button CashAcceptorServiceDiscovery;
        private System.Windows.Forms.TextBox CashAcceptorPortNum;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox CashAcceptorAccURI;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private global::System.Windows.Forms.TextBox printerRawBox;
        private global::System.Windows.Forms.TreeView printerTreeView;
        private global::System.Windows.Forms.TreeView cardReaderTreeView;
        private global::System.Windows.Forms.TextBox cardReaderRawBox;
        private global::System.Windows.Forms.TreeView cashDispenserTreeView;
        private global::System.Windows.Forms.TreeView textTerminalTreeView;
        private global::System.Windows.Forms.TextBox cashDispenserRawBox;
        private global::System.Windows.Forms.TextBox textTerminalRawBox;
        private global::System.Windows.Forms.TextBox encryptorRawBox;
        private global::System.Windows.Forms.TreeView encryptorTreeView;
        private global::System.Windows.Forms.TextBox pinPadRawBox;
        private global::System.Windows.Forms.TreeView pinPadTreeView;
        private global::System.Windows.Forms.TextBox lightsRawBox;
        private global::System.Windows.Forms.TreeView lightsTreeView;
        private global::System.Windows.Forms.TextBox auxiliariesRawBox;
        private global::System.Windows.Forms.TreeView auxiliariesTreeView;
        private global::System.Windows.Forms.TextBox vendorModeRawBox;
        private global::System.Windows.Forms.TreeView vendorModeTreeView;
        private global::System.Windows.Forms.TreeView vendorApplicationTreeView;
        private global::System.Windows.Forms.TextBox vendorApplicationRawBox;
        private global::System.Windows.Forms.TextBox barcodeReaderRawBox;
        private global::System.Windows.Forms.TreeView barcodeReaderTreeView;
        private global::System.Windows.Forms.TextBox biometricRawBox;
        private global::System.Windows.Forms.TreeView biometricTreeView;
        private global::System.Windows.Forms.TextBox cashAcceptorRawBox;
        private global::System.Windows.Forms.TreeView cashAcceptorTreeView;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox NonceTextBox;
        private System.Windows.Forms.TabPage CamTabPage;
        private System.Windows.Forms.TreeView cameraTreeView;
        private System.Windows.Forms.Button CameraReset;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox StCamera;
        private System.Windows.Forms.Button CameraCapabilities;
        private System.Windows.Forms.Button CameraStatus;
        private System.Windows.Forms.TextBox CameraServiceURI;
        private System.Windows.Forms.Button CameraServiceDiscovery;
        private System.Windows.Forms.TextBox CameraPortNum;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox CameraURI;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Button TakePic;
        private System.Windows.Forms.TextBox cameraRawBox;
        private System.Windows.Forms.TabPage CheckTabPage;
        private System.Windows.Forms.TreeView checkScannerTreeView;
        private System.Windows.Forms.TextBox checkScannerRawBox;
        private System.Windows.Forms.Button CheckScannerSetCheckUnitInfo;
        private System.Windows.Forms.Button CheckScannerMediaIn;
        private System.Windows.Forms.Button CheckScannerMediaInEnd;
        private System.Windows.Forms.Button CheckScannerMediaInRollback;
        private System.Windows.Forms.Button CheckScannerRetract;
        private System.Windows.Forms.Button CheckScannerStartExchange;
        private System.Windows.Forms.Button CheckScannerEndExchange;
        private System.Windows.Forms.Button CheckScannerReset;
        private System.Windows.Forms.Button CheckScannerGetTransactionStatus;
        private System.Windows.Forms.TextBox CheckDeviceType;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox StCheck;
        private System.Windows.Forms.Button CheckScannerCapabilities;
        private System.Windows.Forms.Button CheckScannerStatus;
        private System.Windows.Forms.Button CheckScannerGetCheckUnitInfo;
        private System.Windows.Forms.TextBox CheckScannerServiceURI;
        private System.Windows.Forms.Button CheckScannerServiceDiscovery;
        private System.Windows.Forms.TextBox CheckScannerPortNum;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.TextBox CheckScannerURI;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Button viewTxnStatus;
        private System.Windows.Forms.Button buttonEMVClessPerformTransaction;
        private System.Windows.Forms.Button buttonEMVClessQueryApplications;
        private System.Windows.Forms.Button PrinterSetMedia;
        private System.Windows.Forms.ComboBox comboLightDevice;
    }
}

