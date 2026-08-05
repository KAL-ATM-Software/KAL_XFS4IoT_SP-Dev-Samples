/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// Edits a List&lt;byte&gt; payload field (e.g. EMV APDU data) as a single-line, whitespace
/// tolerant hex string ("5F 36 01 03") instead of PropertyGrid's default byte-by-byte
/// collection editor.
/// </summary>
internal sealed class HexByteListConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        => destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is not string text)
        {
            return base.ConvertFrom(context, culture, value);
        }

        var hex = new string(text.Where(c => !char.IsWhiteSpace(c)).ToArray());
        if (hex.Length == 0)
        {
            return new List<byte>();
        }

        if (hex.Length % 2 != 0)
        {
            throw new FormatException("Hex byte string must contain an even number of hex digits.");
        }

        var bytes = new List<byte>(hex.Length / 2);
        for (int i = 0; i < hex.Length; i += 2)
        {
            bytes.Add(Convert.ToByte(hex.Substring(i, 2), 16));
        }

        return bytes;
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType != typeof(string))
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }

        var bytes = value as List<byte> ?? [];
        return string.Join(" ", bytes.Select(b => b.ToString("X2")));
    }
}
