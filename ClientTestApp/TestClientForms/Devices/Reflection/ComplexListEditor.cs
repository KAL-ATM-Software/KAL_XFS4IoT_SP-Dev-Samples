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
/// A UITypeEditor for List&lt;TItem&gt; payload fields where TItem is itself a complex,
/// record-shaped class (e.g. EMVClessConfigureCommand.PayloadData.AidDataClass). Not a
/// subclassed System.ComponentModel.Design.CollectionEditor because that editor constructs new
/// items via the parameterless-constructor overload of Activator.CreateInstance, which fails
/// for these vendor record types (they only expose one constructor, with all-optional
/// parameters). Item creation instead goes through the same ReflectedObjectProxy mechanism
/// used everywhere else, so arbitrarily nested item types work with no per-type code.
/// </summary>
internal sealed class ComplexListEditor : UITypeEditor
{
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.Modal;

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if (value is not ProxyList list)
        {
            return value;
        }

        var editorService = provider?.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
        using var dialog = new ComplexListEditorForm(list);
        if (editorService is not null)
        {
            editorService.ShowDialog(dialog);
        }
        else
        {
            dialog.ShowDialog();
        }

        return list;
    }
}

/// <summary>
/// Small modal dialog backing <see cref="ComplexListEditor"/>: a list of items on the left, a
/// PropertyGrid for the selected item's fields on the right, and Add/Remove buttons. Built
/// entirely in code since it's a small, single-purpose utility dialog.
/// </summary>
internal sealed class ComplexListEditorForm : Form
{
    public ComplexListEditorForm(ProxyList list)
    {
        _list = list;

        Text = $"Edit {list.ItemType.Name} list";
        StartPosition = FormStartPosition.CenterParent;
        Size = new Size(640, 420);
        MinimizeBox = false;
        MaximizeBox = false;

        _itemListBox = new ListBox
        {
            Dock = DockStyle.Fill,
        };
        _itemListBox.SelectedIndexChanged += ItemListBox_SelectedIndexChanged;

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

        var removeButton = new Button { Text = "Remove", Size = new Size(75, 30) };
        removeButton.Click += RemoveButton_Click;

        sideButtonsPanel.Controls.Add(addButton);
        sideButtonsPanel.Controls.Add(removeButton);

        var leftPanel = new Panel { Dock = DockStyle.Left, Width = 200 };
        leftPanel.Controls.Add(_itemListBox);
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

        RefreshItemList();
    }

    private readonly ProxyList _list;
    private readonly ListBox _itemListBox;
    private readonly PropertyGrid _propertyGrid;

    private void RefreshItemList()
    {
        _itemListBox.BeginUpdate();
        _itemListBox.Items.Clear();
        for (int i = 0; i < _list.Count; i++)
        {
            _itemListBox.Items.Add($"[{i}] {_list.ItemType.Name}");
        }

        _itemListBox.EndUpdate();
    }

    private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var index = _itemListBox.SelectedIndex;
        _propertyGrid.SelectedObject = index >= 0 && index < _list.Count ? _list[index] : null;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        _list.Add(new ReflectedObjectProxy(_list.ItemType));
        RefreshItemList();
        _itemListBox.SelectedIndex = _list.Count - 1;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        var index = _itemListBox.SelectedIndex;
        if (index < 0)
        {
            return;
        }

        _list.RemoveAt(index);
        RefreshItemList();
    }
}
