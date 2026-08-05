/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// Reads the XFS4IoT assembly's XML documentation comments — embedded into this
/// assembly at build time (see XFS4IoT.TestTool.csproj's EmbeddedResource entry for
/// XFS4IoT.SP.Framework.Core.xml, so it can never go missing when the built exe is copied
/// elsewhere) — and looks up each property's original "summary" doc comment, so the
/// PropertyGrid's description pane can show the real field documentation (e.g. "Track 1 of the
/// magnetic stripe will be read.") instead of just the field name.
/// </summary>
internal static class XmlDocComments
{
    private const string EmbeddedResourceName = "XFS4IoT.SP.Framework.Core.xml";

    private static readonly Lazy<IReadOnlyDictionary<string, string>> Cache = new(LoadXmlDocComments);

    /// <summary>
    /// Returns the &lt;summary&gt; text for the given property, or null if this assembly has no
    /// embedded XML doc resource, or no entry for that member.
    /// </summary>
    public static string GetSummary(PropertyInfo property)
    {
        var key = "P:" + property.DeclaringType!.FullName!.Replace('+', '.') + "." + property.Name;
        return Cache.Value.TryGetValue(key, out var summary) ? summary : null;
    }

    private static IReadOnlyDictionary<string, string> LoadXmlDocComments()
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        try
        {
            using var stream = typeof(XmlDocComments).Assembly.GetManifestResourceStream(EmbeddedResourceName);
            if (stream is null)
            {
                return result;
            }

            var doc = XDocument.Load(stream);
            var members = doc.Root?.Element("members")?.Elements("member") ?? Enumerable.Empty<XElement>();
            foreach (var member in members)
            {
                var name = member.Attribute("name")?.Value;
                var summary = member.Element("summary")?.Value;
                if (name is not null && summary is not null)
                {
                    result[name] = CleanSummary(summary);
                }
            }
        }
        catch (Exception)
        {
            // Best-effort: a missing/unreadable/malformed XML doc resource just means no
            // descriptions are shown — not worth failing property editing over.
        }

        return result;
    }

    /// <summary>
    /// Collapses the doc comment's original indentation/line-wrapping into a single readable
    /// line, and strips any trailing "&lt;example&gt;...&lt;/example&gt;" tag content that
    /// some summaries append (not useful as a short PropertyGrid description).
    /// </summary>
    private static string CleanSummary(string raw)
    {
        var lines = raw
            .Split('\n')
            .Select(line => line.Trim())
            .Where(line => line.Length > 0 && !line.StartsWith("<example>", StringComparison.OrdinalIgnoreCase) && !line.StartsWith("</example>", StringComparison.OrdinalIgnoreCase));
        return string.Join(" ", lines);
    }
}
