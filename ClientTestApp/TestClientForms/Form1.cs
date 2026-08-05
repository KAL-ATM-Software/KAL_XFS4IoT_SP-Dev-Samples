/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4IoT.TestTool.Devices;
using XFS4IoT.TestTool.Devices.Reflection;
using XFS4IoT.Common;

namespace XFS4IoT.TestTool;

public partial class Form1 : Form
{
    private const string AllInterfacesLabel = "(All Interfaces)";

    private readonly XfsServiceSession Session = new();

    private CamPreview _camPreviewForm;

    public Form1()
    {
        InitializeComponent();
        Session.XFS4IoTMessages += Session_XFS4IoTMessages;
        commandTreeView.AfterSelect += TreeView_AfterSelect;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        FormClosing += Form1_FormClosing;
        UpdateButtonStates(connected: false);
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        await Session.DisconnectAsync();
    }

    #region Discovery / connection

    private async void ServiceDiscoveryButton_Click(object sender, EventArgs e)
    {
        serviceDiscoveryButton.Enabled = false;
        portTextBox.Text = string.Empty;
        try
        {
            var discoveredServices = await Session.DiscoverServicesAsync(hostTextBox.Text);
            servicesComboBox.Items.Clear();
            servicesComboBox.Items.AddRange(discoveredServices.Cast<object>().ToArray());

            if (discoveredServices.Count == 0)
            {
                MessageBox.Show("Failed on finding services.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"'ServiceDiscoveryButton_Click' method exception {Environment.NewLine} {ex.Message}");
        }
        finally
        {
            serviceDiscoveryButton.Enabled = true;
            UpdateButtonStates(Session.IsConnected);
        }
    }

    private async void ServicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selected = servicesComboBox.SelectedItem as DiscoveredService;

        if (Session.IsConnected && !ReferenceEquals(Session.ConnectedService, selected))
        {
            await Session.DisconnectAsync();
            UpdateConnectionUi(connected: false);
        }

        portTextBox.Text = GetPort(selected);
        PopulateInterfaceFilter(selected);
    }

    /// <summary>
    /// Extracts the port number from a discovered service's URI, so it can be shown next to
    /// the Services combo box without the user having to read it out of the full URI text.
    /// </summary>
    private static string GetPort(DiscoveredService service)
    {
        if (service is not null && Uri.TryCreate(service.ServiceURI, UriKind.Absolute, out var uri))
        {
            return uri.Port.ToString();
        }

        return string.Empty;
    }

    private void PopulateInterfaceFilter(DiscoveredService service)
    {
        interfaceFilterComboBox.Items.Clear();
        interfaceFilterComboBox.Items.Add(AllInterfacesLabel);
        if (service is not null)
        {
            foreach (var iface in service.Interfaces)
            {
                interfaceFilterComboBox.Items.Add(iface.ToString());
            }
        }

        interfaceFilterComboBox.SelectedIndex = 0;
    }

    /// <summary>
    /// Re-filters the command list by the chosen interface. This never touches the
    /// connection — the interface filter can be changed freely at any time while connected,
    /// and Send keeps working against whatever command is currently selected.
    /// </summary>
    private void InterfaceFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateCommandComboBox();
    }

    private void PopulateCommandComboBox()
    {
        commandComboBox.Items.Clear();
        commandPropertyGrid.SelectedObject = null;
        commandPropertyGrid.Visible = true;
        noParametersLabel.Visible = false;

        if (!Session.IsConnected)
        {
            return;
        }

        var allCommands = Xfs4IotCommandCatalog.GetCommands(Session.ConnectedService);
        var selectedInterface = interfaceFilterComboBox.SelectedItem as string;

        var filtered = string.IsNullOrEmpty(selectedInterface) || selectedInterface == AllInterfacesLabel
            ? allCommands
            : allCommands.Where(c => c.WireName.StartsWith(selectedInterface + ".", StringComparison.Ordinal)).ToList();

        commandComboBox.Items.AddRange(filtered.Cast<object>().ToArray());
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        var selected = servicesComboBox.SelectedItem as DiscoveredService;
        if (selected is null)
        {
            MessageBox.Show("Select a service first.");
            return;
        }

        connectButton.Enabled = false;
        bool connected = await Session.ConnectAsync(selected);
        UpdateConnectionUi(connected);
        if (!connected)
        {
            MessageBox.Show("Failed to connect to the selected service.");
        }
    }

    private async void DisconnectButton_Click(object sender, EventArgs e)
    {
        await Session.DisconnectAsync();
        UpdateConnectionUi(connected: false);
    }

    private void UpdateConnectionUi(bool connected)
    {
        if (connected)
        {
            connectionStatusLabel.Text = $"Connected to {Session.ConnectedService.ServiceURI}";
            connectionStatusLabel.ForeColor = Color.DarkGreen;
            cameraPreviewButton.Visible = Session.ConnectedService.Interfaces.Contains(InterfaceClass.NameEnum.Camera);
            checkScannerStatusButton.Visible = Session.ConnectedService.Interfaces.Contains(InterfaceClass.NameEnum.Check);
        }
        else
        {
            connectionStatusLabel.Text = "Not connected";
            connectionStatusLabel.ForeColor = Color.DarkRed;
            cameraPreviewButton.Visible = false;
            checkScannerStatusButton.Visible = false;
        }

        UpdateButtonStates(connected);
        PopulateCommandComboBox();
    }

    /// <summary>
    /// Connect is only meaningful once at least one service has been discovered, and only
    /// while not already connected; Disconnect/Status/Capabilities/Send are only meaningful
    /// once actually connected.
    /// </summary>
    private void UpdateButtonStates(bool connected)
    {
        bool hasServices = servicesComboBox.Items.Count > 0;
        connectButton.Enabled = hasServices && !connected;
        disconnectButton.Enabled = connected;
        statusButton.Enabled = connected;
        capabilitiesButton.Enabled = connected;
        sendButton.Enabled = connected;
    }

    #endregion

    #region Command execution

    private async void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var descriptor = commandComboBox.SelectedItem as CommandDescriptor;
        commandDescriptionTextBox.Text = string.Empty;

        if (descriptor?.PayloadType is null)
        {
            commandPropertyGrid.Visible = false;
            noParametersLabel.Visible = true;
            commandPropertyGrid.SelectedObject = null;
            return;
        }

        commandPropertyGrid.Visible = true;
        noParametersLabel.Visible = false;
        var proxy = new ReflectedObjectProxy(descriptor.PayloadType);
        commandPropertyGrid.SelectedObject = proxy;

        if (descriptor.WireName == "Storage.SetStorage")
        {
            await SeedSetStorageDefaultsAsync(proxy);
        }
    }

    /// <summary>
    /// Defaults Storage.SetStorage's Storage dictionary from the connected service's current
    /// Storage.GetStorage results, so the grid starts from what's actually installed (unit IDs,
    /// existing configuration) instead of empty — entries can still be freely added, edited, or
    /// removed from there. Best-effort only: silently leaves the grid empty if not connected or
    /// the query fails, since this is a convenience default, not a required step.
    /// </summary>
    private async Task SeedSetStorageDefaultsAsync(ReflectedObjectProxy proxy)
    {
        if (!Session.IsConnected)
        {
            return;
        }

        var getStorageDescriptor = Xfs4IotCommandCatalog.FindByWireName("Storage.GetStorage");
        if (getStorageDescriptor is null)
        {
            return;
        }

        var result = await Session.ExecuteCommand(getStorageDescriptor, null);
        if (result is not XFS4IoT.Storage.Completions.GetStorageCompletion completion ||
            completion.Payload?.Storage is not { Count: > 0 } storageUnits)
        {
            return;
        }

        // The command combo box selection (and its PropertyGrid) may have moved on while the
        // GetStorage round trip was in flight — only apply the seed if it's still current.
        if (!ReferenceEquals(commandPropertyGrid.SelectedObject, proxy))
        {
            return;
        }

        var storageProperty = TypeDescriptor.GetProperties(proxy)["Storage"];
        var dictionary = (ProxyDictionary)storageProperty.GetValue(proxy);
        foreach (var (unitId, unit) in storageUnits)
        {
            dictionary[unitId] = ObjectProxyBuilder.WrapMatching(unit, dictionary.ValueType);
        }

        commandPropertyGrid.Refresh();
    }

    /// <summary>
    /// The stock PropertyGrid help pane can't scroll — long field descriptions just get clipped
    /// — so it's disabled (HelpVisible = false) in favor of this scrollable textbox, updated
    /// whenever the selected row changes.
    /// </summary>
    private void CommandPropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
    {
        commandDescriptionTextBox.Text = e.NewSelection?.PropertyDescriptor?.Description ?? string.Empty;
    }

    private async void SendButton_Click(object sender, EventArgs e)
    {
        var descriptor = commandComboBox.SelectedItem as CommandDescriptor;
        if (descriptor is null)
        {
            MessageBox.Show("Select a command first.");
            return;
        }

        var proxy = commandPropertyGrid.SelectedObject as ReflectedObjectProxy;

        SetCommandButtonsEnabled(false);
        cancelButton.Enabled = true;
        try
        {
            var result = await Session.ExecuteCommand(descriptor, proxy);
            if (result is null)
            {
                MessageBox.Show($"'{descriptor.WireName}' did not complete (no response, or the connection was lost).");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"'{descriptor.WireName}' failed {Environment.NewLine} {ex.Message}");
        }
        finally
        {
            SetCommandButtonsEnabled(true);
            cancelButton.Enabled = false;
        }
    }

    private async void CancelButton_Click(object sender, EventArgs e)
    {
        await Session.CancelCurrentCommand();
    }

    private async void StatusButton_Click(object sender, EventArgs e)
    {
        SetCommandButtonsEnabled(false);
        try
        {
            if (await Session.GetStatus() is null)
            {
                MessageBox.Show("Failed to get status.");
            }
        }
        finally
        {
            SetCommandButtonsEnabled(true);
        }
    }

    private async void CapabilitiesButton_Click(object sender, EventArgs e)
    {
        SetCommandButtonsEnabled(false);
        try
        {
            if (await Session.GetCapabilities() is null)
            {
                MessageBox.Show("Failed to get capabilities.");
            }
        }
        finally
        {
            SetCommandButtonsEnabled(true);
        }
    }

    /// <summary>
    /// Send/Status/Capabilities all funnel through XfsServiceSession.ExecuteCommand, which
    /// only has one pending-completion slot — letting two of them run at once would let the
    /// second silently steal the wait that the first is still relying on. Disabling all three
    /// for the duration of any one of them keeps exactly one command in flight at a time.
    /// </summary>
    private void SetCommandButtonsEnabled(bool enabled)
    {
        if (enabled)
        {
            UpdateButtonStates(Session.IsConnected);
        }
        else
        {
            statusButton.Enabled = false;
            capabilitiesButton.Enabled = false;
            sendButton.Enabled = false;
        }
    }

    #endregion

    #region Contextual popups

    private async void CameraPreviewButton_Click(object sender, EventArgs e)
    {
        var descriptor = Xfs4IotCommandCatalog.FindByWireName("Camera.TakePicture");
        if (descriptor is null)
        {
            return;
        }

        var proxy = descriptor.PayloadType is null ? null : new ReflectedObjectProxy(descriptor.PayloadType);
        var result = await Session.ExecuteCommand(descriptor, proxy);
        if (result is not XFS4IoT.Camera.Completions.TakePictureCompletion completion ||
            completion.Payload?.PictureFile is not { Count: > 0 } pictureBytes)
        {
            MessageBox.Show("Failed to take a picture.");
            return;
        }

        if (_camPreviewForm is null || _camPreviewForm.IsDisposed)
        {
            _camPreviewForm = new CamPreview();
            _camPreviewForm.Show(this);
        }

        using var stream = new MemoryStream(pictureBytes.ToArray());
        using var loaded = new Bitmap(stream);
        _camPreviewForm.UpdateImage(new Bitmap(loaded));
    }

    private async void CheckScannerStatusButton_Click(object sender, EventArgs e)
    {
        var descriptor = Xfs4IotCommandCatalog.FindByWireName("Check.GetTransactionStatus");
        if (descriptor is null)
        {
            return;
        }

        var proxy = descriptor.PayloadType is null ? null : new ReflectedObjectProxy(descriptor.PayloadType);
        var result = await Session.ExecuteCommand(descriptor, proxy);
        if (result is not XFS4IoT.Check.Completions.GetTransactionStatusCompletion completion || completion.Payload is null)
        {
            MessageBox.Show("Failed to get transaction status.");
            return;
        }

        using var dialog = new CheckScannerTxnStatus();
        dialog.PrepareDisplay(completion.Payload);
        dialog.ShowDialog(this);
    }

    #endregion

    #region Command/response tree view

    private void Session_XFS4IoTMessages(object sender, string msg)
    {
        LoadXFS4IoTMsgToTreeView(commandTreeView, msg);
    }

    private void LoadXFS4IoTMsgToTreeView(TreeView jsonTreeView, string jsonString)
    {
        if (jsonString == null || jsonString.Equals(string.Empty) || jsonString.Equals("<Unknown Event>"))
        {
            return;
        }

        try
        {
            if (jsonTreeView != null)
            {
                JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
                (string Description, Color FontColor) tDecoration = NodeDecoration(jsonDocument);
                TreeNode rootNode = new($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss.fff}] {tDecoration.Description}");
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
        string json;
        using (var stream = new MemoryStream())
        {
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions { Indented = true });
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
            switch (jHeader.GetProperty("type").ToString().ToLower())
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
                case "acknowledge":
                    tDecoration.FontColor = Color.Green;
                    break;
                default:
                    break;
            }

            tDecoration.Description = string.Empty;
            if (jHeader.TryGetProperty("name", out JsonElement element))
            {
                tDecoration.Description += element + " - ";
            }

            if (jHeader.TryGetProperty("type", out JsonElement element2))
            {
                tDecoration.Description += element2 + " - ";
            }

            if (jHeader.TryGetProperty("requestId", out JsonElement element3))
            {
                tDecoration.Description += element3 + " - ";
            }

            tDecoration.Description = tDecoration.Description[..^3];
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
                    // for primitive type show the keypair 'property : value' on node description
                    foreach (var childProperty in token.EnumerateObject())
                    {
                        string descriptionNode = childProperty.Name;
                        if (IsPrimitiveType(childProperty.Value))
                        {
                            descriptionNode += $" : {childProperty.Value}";
                        }

                        TreeNode childNode = new(descriptionNode);
                        childNode.Tag = childProperty.Value;
                        parentNode.Nodes.Add(childNode);
                        if (!IsPrimitiveType(childProperty.Value))
                        {
                            AddNode(childProperty.Value, childNode);
                        }
                    }

                    break;

                case JsonValueKind.Array:
                    // for each array element add a new tree node
                    for (int i = 0; i < token.GetArrayLength(); i++)
                    {
                        TreeNode childNode = new("[" + i + "]");
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
        switch (typeJson.ValueKind)
        {
            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
            case JsonValueKind.Null:
                return true;
            default:
                return false;
        }
    }

    private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var selectedNode = e.Node.Tag;
        rawLogBox.Text = selectedNode switch
        {
            string s => s,
            JsonElement el => el.ToString(),
            _ => string.Empty,
        };
    }

    #endregion
}
