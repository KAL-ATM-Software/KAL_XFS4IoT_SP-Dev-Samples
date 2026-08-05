/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// A UITypeEditor added alongside ExpandableObjectConverter for every complex-single payload
/// parameter (e.g. Printer.SetForm's Form, Printer.SetMedia's Media), letting a whole nested
/// structure be loaded from a JSON file instead of filled in field-by-field through the
/// PropertyGrid. Deserializes directly into the parameter's real vendor type (so a JSON file
/// captured from an existing form/media definition works as-is), then hands the result to
/// ObjectProxyBuilder.Wrap so it still edits normally afterward. Fully generic — not specific to
/// Printer commands, so any large nested command parameter benefits with no per-command code.
/// </summary>
internal sealed class JsonFileLoaderEditor : UITypeEditor
{
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.Modal;

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if (value is not ReflectedObjectProxy proxy)
        {
            return value;
        }

        using var dialog = new OpenFileDialog
        {
            Title = $"Load {proxy.TargetType.Name} from JSON file",
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
        };

        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return value;
        }

        try
        {
            var json = File.ReadAllText(dialog.FileName);
            var instance = JsonSerializer.Deserialize(json, proxy.TargetType, Xfs4IotJsonOptions.Value);
            return instance is null ? value : ObjectProxyBuilder.Wrap(instance, proxy.TargetType);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load '{dialog.FileName}':{Environment.NewLine}{ex.Message}");
            return value;
        }
    }
}
