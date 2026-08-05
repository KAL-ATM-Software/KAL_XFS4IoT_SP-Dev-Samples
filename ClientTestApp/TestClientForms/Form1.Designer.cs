/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

namespace XFS4IoT.TestTool;

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
        lblHost = new System.Windows.Forms.Label();
        hostTextBox = new System.Windows.Forms.TextBox();
        serviceDiscoveryButton = new System.Windows.Forms.Button();
        connectionStatusLabel = new System.Windows.Forms.Label();
        lblPort = new System.Windows.Forms.Label();
        portTextBox = new System.Windows.Forms.TextBox();
        lblServices = new System.Windows.Forms.Label();
        servicesComboBox = new System.Windows.Forms.ComboBox();
        lblInterface = new System.Windows.Forms.Label();
        interfaceFilterComboBox = new System.Windows.Forms.ComboBox();
        connectButton = new System.Windows.Forms.Button();
        disconnectButton = new System.Windows.Forms.Button();
        statusButton = new System.Windows.Forms.Button();
        capabilitiesButton = new System.Windows.Forms.Button();
        cameraPreviewButton = new System.Windows.Forms.Button();
        checkScannerStatusButton = new System.Windows.Forms.Button();
        lblCommand = new System.Windows.Forms.Label();
        commandComboBox = new System.Windows.Forms.ComboBox();
        sendButton = new System.Windows.Forms.Button();
        cancelButton = new System.Windows.Forms.Button();
        noParametersLabel = new System.Windows.Forms.Label();
        commandPropertyGrid = new System.Windows.Forms.PropertyGrid();
        commandDescriptionTextBox = new System.Windows.Forms.TextBox();
        bottomSplitContainer = new System.Windows.Forms.SplitContainer();
        commandTreeView = new System.Windows.Forms.TreeView();
        rawLogBox = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).BeginInit();
        bottomSplitContainer.Panel1.SuspendLayout();
        bottomSplitContainer.Panel2.SuspendLayout();
        bottomSplitContainer.SuspendLayout();
        SuspendLayout();
        // 
        // lblHost
        // 
        lblHost.AutoSize = true;
        lblHost.Location = new System.Drawing.Point(16, 26);
        lblHost.Name = "lblHost";
        lblHost.Size = new System.Drawing.Size(43, 20);
        lblHost.TabIndex = 0;
        lblHost.Text = "Host:";
        // 
        // hostTextBox
        // 
        hostTextBox.Location = new System.Drawing.Point(66, 23);
        hostTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        hostTextBox.Name = "hostTextBox";
        hostTextBox.Size = new System.Drawing.Size(182, 27);
        hostTextBox.TabIndex = 1;
        hostTextBox.Text = "ws://localhost";
        // 
        // serviceDiscoveryButton
        // 
        serviceDiscoveryButton.Location = new System.Drawing.Point(261, 21);
        serviceDiscoveryButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        serviceDiscoveryButton.Name = "serviceDiscoveryButton";
        serviceDiscoveryButton.Size = new System.Drawing.Size(149, 31);
        serviceDiscoveryButton.TabIndex = 2;
        serviceDiscoveryButton.Text = "Service Discovery";
        serviceDiscoveryButton.UseVisualStyleBackColor = true;
        serviceDiscoveryButton.Click += ServiceDiscoveryButton_Click;
        // 
        // connectionStatusLabel
        // 
        connectionStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        connectionStatusLabel.AutoEllipsis = true;
        connectionStatusLabel.ForeColor = System.Drawing.Color.DarkRed;
        connectionStatusLabel.Location = new System.Drawing.Point(423, 26);
        connectionStatusLabel.Name = "connectionStatusLabel";
        connectionStatusLabel.Size = new System.Drawing.Size(525, 26);
        connectionStatusLabel.TabIndex = 3;
        connectionStatusLabel.Text = "Not connected";
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new System.Drawing.Point(14, 128);
        lblPort.Name = "lblPort";
        lblPort.Size = new System.Drawing.Size(38, 20);
        lblPort.TabIndex = 10;
        lblPort.Text = "Port:";
        // 
        // portTextBox
        // 
        portTextBox.BackColor = System.Drawing.SystemColors.Control;
        portTextBox.Location = new System.Drawing.Point(66, 125);
        portTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        portTextBox.Name = "portTextBox";
        portTextBox.ReadOnly = true;
        portTextBox.Size = new System.Drawing.Size(70, 27);
        portTextBox.TabIndex = 11;
        // 
        // lblServices
        // 
        lblServices.AutoSize = true;
        lblServices.Location = new System.Drawing.Point(14, 75);
        lblServices.Name = "lblServices";
        lblServices.Size = new System.Drawing.Size(65, 20);
        lblServices.TabIndex = 4;
        lblServices.Text = "Services:";
        // 
        // servicesComboBox
        // 
        servicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        servicesComboBox.FormattingEnabled = true;
        servicesComboBox.Location = new System.Drawing.Point(85, 72);
        servicesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        servicesComboBox.Name = "servicesComboBox";
        servicesComboBox.Size = new System.Drawing.Size(365, 28);
        servicesComboBox.TabIndex = 5;
        servicesComboBox.SelectedIndexChanged += ServicesComboBox_SelectedIndexChanged;
        // 
        // lblInterface
        // 
        lblInterface.AutoSize = true;
        lblInterface.Location = new System.Drawing.Point(466, 75);
        lblInterface.Name = "lblInterface";
        lblInterface.Size = new System.Drawing.Size(70, 20);
        lblInterface.TabIndex = 6;
        lblInterface.Text = "Interface:";
        // 
        // interfaceFilterComboBox
        // 
        interfaceFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        interfaceFilterComboBox.FormattingEnabled = true;
        interfaceFilterComboBox.Location = new System.Drawing.Point(542, 72);
        interfaceFilterComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        interfaceFilterComboBox.Name = "interfaceFilterComboBox";
        interfaceFilterComboBox.Size = new System.Drawing.Size(182, 28);
        interfaceFilterComboBox.TabIndex = 7;
        interfaceFilterComboBox.SelectedIndexChanged += InterfaceFilterComboBox_SelectedIndexChanged;
        // 
        // connectButton
        // 
        connectButton.Enabled = false;
        connectButton.Location = new System.Drawing.Point(757, 70);
        connectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        connectButton.Name = "connectButton";
        connectButton.Size = new System.Drawing.Size(91, 31);
        connectButton.TabIndex = 8;
        connectButton.Text = "Connect";
        connectButton.UseVisualStyleBackColor = true;
        connectButton.Click += ConnectButton_Click;
        // 
        // disconnectButton
        // 
        disconnectButton.Enabled = false;
        disconnectButton.Location = new System.Drawing.Point(855, 69);
        disconnectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        disconnectButton.Name = "disconnectButton";
        disconnectButton.Size = new System.Drawing.Size(91, 31);
        disconnectButton.TabIndex = 9;
        disconnectButton.Text = "Disconnect";
        disconnectButton.UseVisualStyleBackColor = true;
        disconnectButton.Click += DisconnectButton_Click;
        // 
        // statusButton
        // 
        statusButton.Enabled = false;
        statusButton.Location = new System.Drawing.Point(157, 123);
        statusButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        statusButton.Name = "statusButton";
        statusButton.Size = new System.Drawing.Size(80, 31);
        statusButton.TabIndex = 12;
        statusButton.Text = "Status";
        statusButton.UseVisualStyleBackColor = true;
        statusButton.Click += StatusButton_Click;
        // 
        // capabilitiesButton
        // 
        capabilitiesButton.Enabled = false;
        capabilitiesButton.Location = new System.Drawing.Point(243, 123);
        capabilitiesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        capabilitiesButton.Name = "capabilitiesButton";
        capabilitiesButton.Size = new System.Drawing.Size(103, 31);
        capabilitiesButton.TabIndex = 13;
        capabilitiesButton.Text = "Capabilities";
        capabilitiesButton.UseVisualStyleBackColor = true;
        capabilitiesButton.Click += CapabilitiesButton_Click;
        // 
        // cameraPreviewButton
        // 
        cameraPreviewButton.Location = new System.Drawing.Point(352, 123);
        cameraPreviewButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        cameraPreviewButton.Name = "cameraPreviewButton";
        cameraPreviewButton.Size = new System.Drawing.Size(126, 31);
        cameraPreviewButton.TabIndex = 14;
        cameraPreviewButton.Text = "Camera Preview";
        cameraPreviewButton.UseVisualStyleBackColor = true;
        cameraPreviewButton.Visible = false;
        cameraPreviewButton.Click += CameraPreviewButton_Click;
        // 
        // checkScannerStatusButton
        // 
        checkScannerStatusButton.Location = new System.Drawing.Point(484, 123);
        checkScannerStatusButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        checkScannerStatusButton.Name = "checkScannerStatusButton";
        checkScannerStatusButton.Size = new System.Drawing.Size(171, 31);
        checkScannerStatusButton.TabIndex = 15;
        checkScannerStatusButton.Text = "Check Scanner Status";
        checkScannerStatusButton.UseVisualStyleBackColor = true;
        checkScannerStatusButton.Visible = false;
        checkScannerStatusButton.Click += CheckScannerStatusButton_Click;
        // 
        // lblCommand
        // 
        lblCommand.AutoSize = true;
        lblCommand.Location = new System.Drawing.Point(14, 181);
        lblCommand.Name = "lblCommand";
        lblCommand.Size = new System.Drawing.Size(81, 20);
        lblCommand.TabIndex = 16;
        lblCommand.Text = "Command:";
        // 
        // commandComboBox
        // 
        commandComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        commandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        commandComboBox.FormattingEnabled = true;
        commandComboBox.Location = new System.Drawing.Point(101, 178);
        commandComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        commandComboBox.Name = "commandComboBox";
        commandComboBox.Size = new System.Drawing.Size(639, 28);
        commandComboBox.TabIndex = 17;
        commandComboBox.SelectedIndexChanged += CommandComboBox_SelectedIndexChanged;
        // 
        // sendButton
        // 
        sendButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        sendButton.Enabled = false;
        sendButton.Location = new System.Drawing.Point(757, 176);
        sendButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        sendButton.Name = "sendButton";
        sendButton.Size = new System.Drawing.Size(91, 31);
        sendButton.TabIndex = 18;
        sendButton.Text = "Send";
        sendButton.UseVisualStyleBackColor = true;
        sendButton.Click += SendButton_Click;
        // 
        // cancelButton
        // 
        cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        cancelButton.Enabled = false;
        cancelButton.Location = new System.Drawing.Point(855, 176);
        cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        cancelButton.Name = "cancelButton";
        cancelButton.Size = new System.Drawing.Size(91, 31);
        cancelButton.TabIndex = 19;
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;
        cancelButton.Click += CancelButton_Click;
        // 
        // noParametersLabel
        // 
        noParametersLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        noParametersLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        noParametersLabel.Location = new System.Drawing.Point(16, 229);
        noParametersLabel.Name = "noParametersLabel";
        noParametersLabel.Size = new System.Drawing.Size(932, 195);
        noParametersLabel.TabIndex = 20;
        noParametersLabel.Text = "(no parameters)";
        noParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        noParametersLabel.Visible = false;
        // 
        // commandPropertyGrid
        // 
        commandPropertyGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        commandPropertyGrid.BackColor = System.Drawing.Color.White;
        commandPropertyGrid.CategoryForeColor = System.Drawing.Color.Black;
        commandPropertyGrid.CategorySplitterColor = System.Drawing.Color.Silver;
        commandPropertyGrid.HelpVisible = false;
        commandPropertyGrid.LineColor = System.Drawing.Color.White;
        commandPropertyGrid.Location = new System.Drawing.Point(14, 229);
        commandPropertyGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        commandPropertyGrid.Name = "commandPropertyGrid";
        commandPropertyGrid.Size = new System.Drawing.Size(933, 195);
        commandPropertyGrid.TabIndex = 21;
        commandPropertyGrid.ToolbarVisible = false;
        commandPropertyGrid.ViewBackColor = System.Drawing.Color.White;
        commandPropertyGrid.ViewBorderColor = System.Drawing.Color.Black;
        commandPropertyGrid.SelectedGridItemChanged += CommandPropertyGrid_SelectedGridItemChanged;
        // 
        // commandDescriptionTextBox
        // 
        commandDescriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        commandDescriptionTextBox.BackColor = System.Drawing.SystemColors.Control;
        commandDescriptionTextBox.Location = new System.Drawing.Point(14, 428);
        commandDescriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        commandDescriptionTextBox.Multiline = true;
        commandDescriptionTextBox.Name = "commandDescriptionTextBox";
        commandDescriptionTextBox.ReadOnly = true;
        commandDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        commandDescriptionTextBox.Size = new System.Drawing.Size(933, 123);
        commandDescriptionTextBox.TabIndex = 22;
        // 
        // bottomSplitContainer
        // 
        bottomSplitContainer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        bottomSplitContainer.Location = new System.Drawing.Point(14, 559);
        bottomSplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        bottomSplitContainer.Name = "bottomSplitContainer";
        // 
        // bottomSplitContainer.Panel1
        // 
        bottomSplitContainer.Panel1.Controls.Add(commandTreeView);
        // 
        // bottomSplitContainer.Panel2
        // 
        bottomSplitContainer.Panel2.Controls.Add(rawLogBox);
        bottomSplitContainer.Size = new System.Drawing.Size(933, 308);
        bottomSplitContainer.SplitterDistance = 400;
        bottomSplitContainer.SplitterWidth = 5;
        bottomSplitContainer.TabIndex = 23;
        // 
        // commandTreeView
        // 
        commandTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        commandTreeView.Location = new System.Drawing.Point(0, 0);
        commandTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        commandTreeView.Name = "commandTreeView";
        commandTreeView.Size = new System.Drawing.Size(400, 308);
        commandTreeView.TabIndex = 0;
        // 
        // rawLogBox
        // 
        rawLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
        rawLogBox.Font = new System.Drawing.Font("Consolas", 9F);
        rawLogBox.Location = new System.Drawing.Point(0, 0);
        rawLogBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        rawLogBox.Multiline = true;
        rawLogBox.Name = "rawLogBox";
        rawLogBox.ReadOnly = true;
        rawLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        rawLogBox.Size = new System.Drawing.Size(528, 308);
        rawLogBox.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(960, 882);
        Controls.Add(bottomSplitContainer);
        Controls.Add(commandDescriptionTextBox);
        Controls.Add(commandPropertyGrid);
        Controls.Add(noParametersLabel);
        Controls.Add(cancelButton);
        Controls.Add(sendButton);
        Controls.Add(commandComboBox);
        Controls.Add(lblCommand);
        Controls.Add(checkScannerStatusButton);
        Controls.Add(cameraPreviewButton);
        Controls.Add(capabilitiesButton);
        Controls.Add(statusButton);
        Controls.Add(disconnectButton);
        Controls.Add(connectButton);
        Controls.Add(interfaceFilterComboBox);
        Controls.Add(lblInterface);
        Controls.Add(servicesComboBox);
        Controls.Add(lblServices);
        Controls.Add(portTextBox);
        Controls.Add(lblPort);
        Controls.Add(connectionStatusLabel);
        Controls.Add(serviceDiscoveryButton);
        Controls.Add(hostTextBox);
        Controls.Add(lblHost);
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        MinimumSize = new System.Drawing.Size(797, 695);
        Name = "Form1";
        Text = "XFS4IoT Test Tool";
        Load += Form1_Load;
        bottomSplitContainer.Panel1.ResumeLayout(false);
        bottomSplitContainer.Panel2.ResumeLayout(false);
        bottomSplitContainer.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).EndInit();
        bottomSplitContainer.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblHost;
    private System.Windows.Forms.TextBox hostTextBox;
    private System.Windows.Forms.Button serviceDiscoveryButton;
    private System.Windows.Forms.Label connectionStatusLabel;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.TextBox portTextBox;
    private System.Windows.Forms.Label lblServices;
    private System.Windows.Forms.ComboBox servicesComboBox;
    private System.Windows.Forms.Label lblInterface;
    private System.Windows.Forms.ComboBox interfaceFilterComboBox;
    private System.Windows.Forms.Button connectButton;
    private System.Windows.Forms.Button disconnectButton;
    private System.Windows.Forms.Button statusButton;
    private System.Windows.Forms.Button capabilitiesButton;
    private System.Windows.Forms.Button cameraPreviewButton;
    private System.Windows.Forms.Button checkScannerStatusButton;
    private System.Windows.Forms.Label lblCommand;
    private System.Windows.Forms.ComboBox commandComboBox;
    private System.Windows.Forms.Button sendButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label noParametersLabel;
    private System.Windows.Forms.PropertyGrid commandPropertyGrid;
    private System.Windows.Forms.TextBox commandDescriptionTextBox;
    private System.Windows.Forms.SplitContainer bottomSplitContainer;
    private System.Windows.Forms.TreeView commandTreeView;
    private System.Windows.Forms.TextBox rawLogBox;
}
