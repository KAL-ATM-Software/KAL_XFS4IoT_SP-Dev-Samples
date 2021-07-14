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
            this.DispenserTab = new System.Windows.Forms.TabPage();
            this.DispenserRetract = new System.Windows.Forms.Button();
            this.DispenserReject = new System.Windows.Forms.Button();
            this.DispenserCloseShutter = new System.Windows.Forms.Button();
            this.DispenserOpenShutter = new System.Windows.Forms.Button();
            this.DispenserDispense = new System.Windows.Forms.Button();
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
            this.DispenserDispURI = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextTerminalTab = new System.Windows.Forms.TabPage();
            this.TextTerminalBeep = new System.Windows.Forms.Button();
            this.TextTerminalTurnOffLED = new System.Windows.Forms.Button();
            this.TextTerminalTurnOnLED = new System.Windows.Forms.Button();
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
            this.TextTerminalDispLightOff = new System.Windows.Forms.Button();
            this.TextTerminalDispLightOn = new System.Windows.Forms.Button();
            this.TextTerminalSetResolution = new System.Windows.Forms.Button();
            this.testClientTabControl.SuspendLayout();
            this.CardReaderTab.SuspendLayout();
            this.DispenserTab.SuspendLayout();
            this.TextTerminalTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptCard
            // 
            this.AcceptCard.Location = new System.Drawing.Point(1038, 28);
            this.AcceptCard.Margin = new System.Windows.Forms.Padding(1);
            this.AcceptCard.Name = "AcceptCard";
            this.AcceptCard.Size = new System.Drawing.Size(93, 22);
            this.AcceptCard.TabIndex = 0;
            this.AcceptCard.Text = "AcceptCard";
            this.AcceptCard.UseVisualStyleBackColor = true;
            this.AcceptCard.Click += new System.EventHandler(this.AcceptCard_Click);
            // 
            // EjectCard
            // 
            this.EjectCard.Location = new System.Drawing.Point(1038, 63);
            this.EjectCard.Margin = new System.Windows.Forms.Padding(1);
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
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(1);
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
            this.ServiceDiscovery.Margin = new System.Windows.Forms.Padding(1);
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
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.ReadOnly = true;
            this.textBoxPort.Size = new System.Drawing.Size(106, 23);
            this.textBoxPort.TabIndex = 4;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxResponse.Location = new System.Drawing.Point(427, 200);
            this.textBoxResponse.Margin = new System.Windows.Forms.Padding(1);
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
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "CardReader URI";
            // 
            // textBoxCardReader
            // 
            this.textBoxCardReader.Location = new System.Drawing.Point(100, 66);
            this.textBoxCardReader.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxCardReader.Name = "textBoxCardReader";
            this.textBoxCardReader.ReadOnly = true;
            this.textBoxCardReader.Size = new System.Drawing.Size(464, 23);
            this.textBoxCardReader.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port Number";
            // 
            // textBoxServiceURI
            // 
            this.textBoxServiceURI.Location = new System.Drawing.Point(100, 19);
            this.textBoxServiceURI.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxServiceURI.Name = "textBoxServiceURI";
            this.textBoxServiceURI.Size = new System.Drawing.Size(464, 23);
            this.textBoxServiceURI.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Service URI";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Location = new System.Drawing.Point(836, 32);
            this.buttonStatus.Margin = new System.Windows.Forms.Padding(1);
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
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 131);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Response";
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxEvent.Location = new System.Drawing.Point(814, 200);
            this.textBoxEvent.Margin = new System.Windows.Forms.Padding(1);
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
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Event";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(626, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Device status";
            // 
            // textBoxStDevice
            // 
            this.textBoxStDevice.Location = new System.Drawing.Point(713, 16);
            this.textBoxStDevice.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxStDevice.Name = "textBoxStDevice";
            this.textBoxStDevice.ReadOnly = true;
            this.textBoxStDevice.Size = new System.Drawing.Size(106, 23);
            this.textBoxStDevice.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Media Status";
            // 
            // textBoxStMedia
            // 
            this.textBoxStMedia.Location = new System.Drawing.Point(713, 41);
            this.textBoxStMedia.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxStMedia.Name = "textBoxStMedia";
            this.textBoxStMedia.ReadOnly = true;
            this.textBoxStMedia.Size = new System.Drawing.Size(106, 23);
            this.textBoxStMedia.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
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
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Device type";
            // 
            // textBoxDeviceType
            // 
            this.textBoxDeviceType.Location = new System.Drawing.Point(713, 94);
            this.textBoxDeviceType.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxDeviceType.Name = "textBoxDeviceType";
            this.textBoxDeviceType.ReadOnly = true;
            this.textBoxDeviceType.Size = new System.Drawing.Size(106, 23);
            this.textBoxDeviceType.TabIndex = 23;
            // 
            // CaptureCard
            // 
            this.CaptureCard.Location = new System.Drawing.Point(1038, 104);
            this.CaptureCard.Margin = new System.Windows.Forms.Padding(1);
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
            this.testClientTabControl.Location = new System.Drawing.Point(7, 2);
            this.testClientTabControl.Name = "testClientTabControl";
            this.testClientTabControl.SelectedIndex = 0;
            this.testClientTabControl.Size = new System.Drawing.Size(1185, 543);
            this.testClientTabControl.TabIndex = 25;
            // 
            // CardReaderTab
            // 
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
            this.CardReaderTab.Name = "CardReaderTab";
            this.CardReaderTab.Padding = new System.Windows.Forms.Padding(3);
            this.CardReaderTab.Size = new System.Drawing.Size(1177, 515);
            this.CardReaderTab.TabIndex = 0;
            this.CardReaderTab.Text = "Card Reader";
            this.CardReaderTab.UseVisualStyleBackColor = true;
            // 
            // DispenserTab
            // 
            this.DispenserTab.Controls.Add(this.DispenserRetract);
            this.DispenserTab.Controls.Add(this.DispenserReject);
            this.DispenserTab.Controls.Add(this.DispenserCloseShutter);
            this.DispenserTab.Controls.Add(this.DispenserOpenShutter);
            this.DispenserTab.Controls.Add(this.DispenserDispense);
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
            this.DispenserTab.Controls.Add(this.DispenserDispURI);
            this.DispenserTab.Controls.Add(this.label11);
            this.DispenserTab.Controls.Add(this.label12);
            this.DispenserTab.Location = new System.Drawing.Point(4, 24);
            this.DispenserTab.Name = "DispenserTab";
            this.DispenserTab.Padding = new System.Windows.Forms.Padding(3);
            this.DispenserTab.Size = new System.Drawing.Size(1177, 515);
            this.DispenserTab.TabIndex = 1;
            this.DispenserTab.Text = "Dispenser";
            this.DispenserTab.UseVisualStyleBackColor = true;
            // 
            // DispenserRetract
            // 
            this.DispenserRetract.Location = new System.Drawing.Point(921, 120);
            this.DispenserRetract.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserReject.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserCloseShutter.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserOpenShutter.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserDispense.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserDispense.Name = "DispenserDispense";
            this.DispenserDispense.Size = new System.Drawing.Size(111, 22);
            this.DispenserDispense.TabIndex = 39;
            this.DispenserDispense.Text = "Dispense";
            this.DispenserDispense.UseVisualStyleBackColor = true;
            this.DispenserDispense.Click += new System.EventHandler(this.DispenserDispense_Click);
            // 
            // DispenserDenominate
            // 
            this.DispenserDenominate.Location = new System.Drawing.Point(1052, 90);
            this.DispenserDenominate.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserPresent.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserEndExchange.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserStartExchange.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserReset.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserGetPresentStatus.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserDeviceType.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserDeviceType.Name = "DispenserDeviceType";
            this.DispenserDeviceType.ReadOnly = true;
            this.DispenserDeviceType.Size = new System.Drawing.Size(106, 23);
            this.DispenserDeviceType.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(609, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 31;
            this.label14.Text = "Device type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(609, 11);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Device status";
            // 
            // DispenserStDevice
            // 
            this.DispenserStDevice.Location = new System.Drawing.Point(692, 12);
            this.DispenserStDevice.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserStDevice.Name = "DispenserStDevice";
            this.DispenserStDevice.ReadOnly = true;
            this.DispenserStDevice.Size = new System.Drawing.Size(106, 23);
            this.DispenserStDevice.TabIndex = 30;
            // 
            // DispenserGetMixTypes
            // 
            this.DispenserGetMixTypes.Location = new System.Drawing.Point(789, 134);
            this.DispenserGetMixTypes.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserCapabilities.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserStatus.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserGetCashUnitInfo.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserServiceURI.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserServiceURI.Name = "DispenserServiceURI";
            this.DispenserServiceURI.Size = new System.Drawing.Size(464, 23);
            this.DispenserServiceURI.TabIndex = 23;
            // 
            // DispenserEvtBox
            // 
            this.DispenserEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserEvtBox.Location = new System.Drawing.Point(816, 204);
            this.DispenserEvtBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserServiceDiscovery.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserPortNum.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserPortNum.Name = "DispenserPortNum";
            this.DispenserPortNum.ReadOnly = true;
            this.DispenserPortNum.Size = new System.Drawing.Size(106, 23);
            this.DispenserPortNum.TabIndex = 18;
            // 
            // DispenserRspBox
            // 
            this.DispenserRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DispenserRspBox.Location = new System.Drawing.Point(427, 204);
            this.DispenserRspBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.DispenserCmdBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Dispenser URI";
            // 
            // DispenserDispURI
            // 
            this.DispenserDispURI.Location = new System.Drawing.Point(100, 66);
            this.DispenserDispURI.Margin = new System.Windows.Forms.Padding(1);
            this.DispenserDispURI.Name = "DispenserDispURI";
            this.DispenserDispURI.ReadOnly = true;
            this.DispenserDispURI.Size = new System.Drawing.Size(464, 23);
            this.DispenserDispURI.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Port Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Service URI";
            // 
            // TextTerminalTab
            // 
            this.TextTerminalTab.Controls.Add(this.TextTerminalSetResolution);
            this.TextTerminalTab.Controls.Add(this.TextTerminalDispLightOff);
            this.TextTerminalTab.Controls.Add(this.TextTerminalDispLightOn);
            this.TextTerminalTab.Controls.Add(this.TextTerminalBeep);
            this.TextTerminalTab.Controls.Add(this.TextTerminalTurnOffLED);
            this.TextTerminalTab.Controls.Add(this.TextTerminalTurnOnLED);
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
            // TextTerminalBeep
            // 
            this.TextTerminalBeep.Location = new System.Drawing.Point(939, 32);
            this.TextTerminalBeep.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalBeep.Name = "TextTerminalBeep";
            this.TextTerminalBeep.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalBeep.TabIndex = 56;
            this.TextTerminalBeep.Text = "Beep";
            this.TextTerminalBeep.UseVisualStyleBackColor = true;
            this.TextTerminalBeep.Click += new System.EventHandler(this.TextTerminalBeep_Click);
            // 
            // TextTerminalTurnOffLED
            // 
            this.TextTerminalTurnOffLED.Location = new System.Drawing.Point(1052, 104);
            this.TextTerminalTurnOffLED.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalTurnOffLED.Name = "TextTerminalTurnOffLED";
            this.TextTerminalTurnOffLED.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalTurnOffLED.TabIndex = 55;
            this.TextTerminalTurnOffLED.Text = "TurnOffLED";
            this.TextTerminalTurnOffLED.UseVisualStyleBackColor = true;
            this.TextTerminalTurnOffLED.Click += new System.EventHandler(this.TextTerminalTurnOffLED_Click);
            // 
            // TextTerminalTurnOnLED
            // 
            this.TextTerminalTurnOnLED.Location = new System.Drawing.Point(1052, 80);
            this.TextTerminalTurnOnLED.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalTurnOnLED.Name = "TextTerminalTurnOnLED";
            this.TextTerminalTurnOnLED.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalTurnOnLED.TabIndex = 54;
            this.TextTerminalTurnOnLED.Text = "TurnOnLED";
            this.TextTerminalTurnOnLED.UseVisualStyleBackColor = true;
            this.TextTerminalTurnOnLED.Click += new System.EventHandler(this.TextTerminalTurnOnLED_Click);
            // 
            // TextTerminalReset
            // 
            this.TextTerminalReset.Location = new System.Drawing.Point(939, 8);
            this.TextTerminalReset.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalGetKeyDetail.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalRead.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalWrite.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalClearScreen.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalDeviceType.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalDeviceType.Name = "TextTerminalDeviceType";
            this.TextTerminalDeviceType.ReadOnly = true;
            this.TextTerminalDeviceType.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalDeviceType.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(610, 43);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
            this.label15.TabIndex = 47;
            this.label15.Text = "Device type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(610, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 15);
            this.label16.TabIndex = 43;
            this.label16.Text = "Device status";
            // 
            // TextTerminalStDevice
            // 
            this.TextTerminalStDevice.Location = new System.Drawing.Point(693, 10);
            this.TextTerminalStDevice.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalStDevice.Name = "TextTerminalStDevice";
            this.TextTerminalStDevice.ReadOnly = true;
            this.TextTerminalStDevice.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalStDevice.TabIndex = 46;
            // 
            // TextTerminalCapabilities
            // 
            this.TextTerminalCapabilities.Location = new System.Drawing.Point(811, 34);
            this.TextTerminalCapabilities.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalStatus.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalServiceURI.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalServiceURI.Name = "TextTerminalServiceURI";
            this.TextTerminalServiceURI.Size = new System.Drawing.Size(464, 23);
            this.TextTerminalServiceURI.TabIndex = 40;
            // 
            // TextTerminalEvtBox
            // 
            this.TextTerminalEvtBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalEvtBox.Location = new System.Drawing.Point(817, 202);
            this.TextTerminalEvtBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalServiceDiscovery.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalPortNum.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalPortNum.Name = "TextTerminalPortNum";
            this.TextTerminalPortNum.ReadOnly = true;
            this.TextTerminalPortNum.Size = new System.Drawing.Size(106, 23);
            this.TextTerminalPortNum.TabIndex = 35;
            // 
            // TextTerminalRspBox
            // 
            this.TextTerminalRspBox.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TextTerminalRspBox.Location = new System.Drawing.Point(428, 202);
            this.TextTerminalRspBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.TextTerminalCmdBox.Margin = new System.Windows.Forms.Padding(1);
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
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 15);
            this.label17.TabIndex = 37;
            this.label17.Text = "TextTerminal URI";
            // 
            // TextTerminalURI
            // 
            this.TextTerminalURI.Location = new System.Drawing.Point(101, 64);
            this.TextTerminalURI.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalURI.Name = "TextTerminalURI";
            this.TextTerminalURI.ReadOnly = true;
            this.TextTerminalURI.Size = new System.Drawing.Size(464, 23);
            this.TextTerminalURI.TabIndex = 38;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 41);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 15);
            this.label18.TabIndex = 39;
            this.label18.Text = "Port Number";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 15);
            this.label19.TabIndex = 41;
            this.label19.Text = "Service URI";
            // 
            // TextTerminalDispLightOff
            // 
            this.TextTerminalDispLightOff.Location = new System.Drawing.Point(939, 105);
            this.TextTerminalDispLightOff.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalDispLightOff.Name = "TextTerminalDispLightOff";
            this.TextTerminalDispLightOff.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalDispLightOff.TabIndex = 58;
            this.TextTerminalDispLightOff.Text = "DispLightOff";
            this.TextTerminalDispLightOff.UseVisualStyleBackColor = true;
            this.TextTerminalDispLightOff.Click += new System.EventHandler(this.TextTerminalDispLightOff_Click);
            // 
            // TextTerminalDispLightOn
            // 
            this.TextTerminalDispLightOn.Location = new System.Drawing.Point(939, 80);
            this.TextTerminalDispLightOn.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalDispLightOn.Name = "TextTerminalDispLightOn";
            this.TextTerminalDispLightOn.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalDispLightOn.TabIndex = 57;
            this.TextTerminalDispLightOn.Text = "DispLightOn";
            this.TextTerminalDispLightOn.UseVisualStyleBackColor = true;
            this.TextTerminalDispLightOn.Click += new System.EventHandler(this.TextTerminalDispLightOn_Click);
            // 
            // TextTerminalSetResolution
            // 
            this.TextTerminalSetResolution.Location = new System.Drawing.Point(1052, 128);
            this.TextTerminalSetResolution.Margin = new System.Windows.Forms.Padding(1);
            this.TextTerminalSetResolution.Name = "TextTerminalSetResolution";
            this.TextTerminalSetResolution.Size = new System.Drawing.Size(111, 22);
            this.TextTerminalSetResolution.TabIndex = 59;
            this.TextTerminalSetResolution.Text = "SetResolution";
            this.TextTerminalSetResolution.UseVisualStyleBackColor = true;
            this.TextTerminalSetResolution.Click += new System.EventHandler(this.TextTerminalSetResolution_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 520);
            this.Controls.Add(this.testClientTabControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(1);
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
        private System.Windows.Forms.Button TextTerminalTurnOffLED;
        private System.Windows.Forms.Button TextTerminalTurnOnLED;
        private System.Windows.Forms.Button TextTerminalReset;
        private System.Windows.Forms.Button TextTerminalBeep;
        private System.Windows.Forms.Button TextTerminalDispLightOff;
        private System.Windows.Forms.Button TextTerminalDispLightOn;
        private System.Windows.Forms.Button TextTerminalSetResolution;
    }
}

