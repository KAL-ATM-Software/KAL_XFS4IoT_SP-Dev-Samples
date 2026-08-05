/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// A UITypeEditor for Dictionary&lt;string, TValue&gt; payload fields where TValue is a complex,
/// record-shaped class (e.g. Storage.SetStorage's Storage parameter, keyed by storage unit ID).
/// Not a subclassed System.ComponentModel.Design.CollectionEditor: that editor is written
/// against IList semantics (indexed Insert/RemoveAt), which Dictionary&lt;,&gt; doesn't
/// implement, so its Add button stays permanently disabled against a dictionary-typed property.
/// Entry values are built through the same ReflectedObjectProxy mechanism used everywhere else,
/// so arbitrarily nested value types work with no per-command code.
/// </summary>
internal sealed class ComplexDictionaryEditor : UITypeEditor
{
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.Modal;

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if (value is not ProxyDictionary dictionary)
        {
            return value;
        }

        var editorService = provider?.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
        using var dialog = new ComplexDictionaryEditorForm(dictionary);
        if (editorService is not null)
        {
            editorService.ShowDialog(dialog);
        }
        else
        {
            dialog.ShowDialog();
        }

        return dictionary;
    }
}

/// <summary>
/// Small modal dialog backing <see cref="ComplexDictionaryEditor"/>: a list of keyed entries on
/// the left, a PropertyGrid for the selected entry's value fields on the right, and Add/Rename/
/// Remove buttons. Built entirely in code since it's a small, single-purpose utility dialog.
/// </summary>
internal sealed class ComplexDictionaryEditorForm : Form
{
    public ComplexDictionaryEditorForm(ProxyDictionary dictionary)
    {
        _dictionary = dictionary;

        Text = $"Edit {dictionary.ValueType.Name} entries";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(700, 420);
        MinimizeBox = false;
        MaximizeBox = false;

        _entryListBox = new ListBox
        {
            Dock = DockStyle.Fill,
        };
        _entryListBox.SelectedIndexChanged += EntryListBox_SelectedIndexChanged;

        _propertyGrid = new PropertyGrid
        {
            Dock = DockStyle.Fill,
        };

        var sideButtonsPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.LeftToRight,
            Height = 40,
        };

        var addButton = new Button { Text = "Add", Size = new Size(75, 30) };
        addButton.Click += AddButton_Click;

        var renameButton = new Button { Text = "Rename", Size = new Size(75, 30) };
        renameButton.Click += RenameButton_Click;

        var removeButton = new Button { Text = "Remove", Size = new Size(75, 30) };
        removeButton.Click += RemoveButton_Click;

        sideButtonsPanel.Controls.Add(addButton);
        sideButtonsPanel.Controls.Add(renameButton);
        sideButtonsPanel.Controls.Add(removeButton);

        // Wide enough for all three buttons to fit on a single FlowLayoutPanel row — at the
        // previous 200px width, "Remove" wrapped to a second row that fell outside the panel's
        // fixed height and was clipped from view entirely.
        var leftPanel = new Panel { Dock = DockStyle.Left, Width = 260 };
        leftPanel.Controls.Add(_entryListBox);
        leftPanel.Controls.Add(sideButtonsPanel);

        var closeButton = new Button
        {
            Text = "Close",
            Dock = DockStyle.Bottom,
            Height = 32,
            DialogResult = DialogResult.OK,
        };

        Controls.Add(_propertyGrid);
        Controls.Add(leftPanel);
        Controls.Add(closeButton);
        AcceptButton = closeButton;

        RefreshEntryList(selectKey: null);
    }

    private readonly ProxyDictionary _dictionary;
    private readonly ListBox _entryListBox;
    private readonly PropertyGrid _propertyGrid;

    private void RefreshEntryList(string selectKey)
    {
        _entryListBox.BeginUpdate();
        _entryListBox.Items.Clear();
        foreach (var key in _dictionary.Keys)
        {
            _entryListBox.Items.Add(key);
        }

        _entryListBox.EndUpdate();
        _entryListBox.SelectedIndex = selectKey is not null ? _entryListBox.Items.IndexOf(selectKey) : -1;
    }

    private void EntryListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var key = _entryListBox.SelectedItem as string;
        _propertyGrid.SelectedObject = key is not null ? _dictionary[key] : null;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        if (KeyInputDialog.TryPromptForKey(this, "Add entry", "Key:", string.Empty, out var key) &&
            !_dictionary.ContainsKey(key))
        {
            _dictionary[key] = new ReflectedObjectProxy(_dictionary.ValueType);
            RefreshEntryList(key);
        }
    }

    private void RenameButton_Click(object sender, EventArgs e)
    {
        var oldKey = _entryListBox.SelectedItem as string;
        if (oldKey is null)
        {
            return;
        }

        if (KeyInputDialog.TryPromptForKey(this, "Rename entry", "Key:", oldKey, out var newKey) &&
            newKey != oldKey && !_dictionary.ContainsKey(newKey))
        {
            var proxy = _dictionary[oldKey];
            _dictionary.Remove(oldKey);
            _dictionary[newKey] = proxy;
            RefreshEntryList(newKey);
        }
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        var key = _entryListBox.SelectedItem as string;
        if (key is null)
        {
            return;
        }

        _dictionary.Remove(key);
        RefreshEntryList(selectKey: null);
    }
}

/// <summary>
/// A tiny modal text-entry dialog used to name/rename dictionary entry keys, built in code to
/// avoid pulling in the Microsoft.VisualBasic InputBox dependency for one string prompt.
/// </summary>
internal static class KeyInputDialog
{
    public static bool TryPromptForKey(IWin32Window owner, string title, string label, string initialValue, out string value)
    {
        using var dialog = new Form
        {
            Text = title,
            StartPosition = FormStartPosition.CenterParent,
            Size = new Size(320, 140),
            MinimizeBox = false,
            MaximizeBox = false,
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var promptLabel = new Label { Text = label, Location = new Point(12, 15), AutoSize = true };
        var textBox = new TextBox { Text = initialValue, Location = new Point(12, 38), Width = 280 };
        var okButton = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(132, 70) };
        var cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Location = new Point(217, 70) };

        dialog.Controls.Add(promptLabel);
        dialog.Controls.Add(textBox);
        dialog.Controls.Add(okButton);
        dialog.Controls.Add(cancelButton);
        dialog.AcceptButton = okButton;
        dialog.CancelButton = cancelButton;

        bool accepted = dialog.ShowDialog(owner) == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text);
        value = accepted ? textBox.Text.Trim() : null;
        return accepted;
    }
}
