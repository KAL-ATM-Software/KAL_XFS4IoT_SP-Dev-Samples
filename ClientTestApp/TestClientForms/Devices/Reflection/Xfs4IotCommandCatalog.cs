/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XFS4IoT;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// Describes a single XFS4IoT command discovered via reflection: its wire name, the CLR types
/// involved, and the constructors needed to build and send it generically.
/// </summary>
public sealed class CommandDescriptor
{
    public CommandDescriptor(
        string wireName,
        Type commandType,
        Type payloadType,
        Type completionType,
        ConstructorInfo commandCtor,
        ConstructorInfo payloadCtor)
    {
        WireName = wireName;
        CommandType = commandType;
        PayloadType = payloadType;
        CompletionType = completionType;
        CommandCtor = commandCtor;
        PayloadCtor = payloadCtor;
    }

    /// <summary>The dotted wire name, e.g. "CardReader.ReadRawData".</summary>
    public string WireName { get; }

    public Type CommandType { get; }

    /// <summary>Null when the command has no parameters (e.g. QueryIFMIdentifier).</summary>
    public Type PayloadType { get; }

    public Type CompletionType { get; }

    public ConstructorInfo CommandCtor { get; }

    /// <summary>Null when <see cref="PayloadType"/> is null.</summary>
    public ConstructorInfo PayloadCtor { get; }

    public override string ToString() => WireName;
}

/// <summary>
/// Scans the referenced XFS4IoT vendor assembly once for every command type and resolves its
/// matching completion type, so the GUI can discover and execute any command generically
/// instead of hardcoding one method per command.
/// </summary>
public static class Xfs4IotCommandCatalog
{
    /// <summary>
    /// Wire names that keep their own dedicated Status/Capabilities buttons in the GUI and are
    /// therefore excluded from the generic command list.
    /// </summary>
    private static readonly HashSet<string> ExcludedWireNames = new(StringComparer.Ordinal)
    {
        "Common.Status",
        "Common.Capabilities",
    };

    private static readonly Lazy<IReadOnlyList<CommandDescriptor>> All = new(BuildAll);

    /// <summary>
    /// Looks up a specific known command by its wire name, for the handful of contextual
    /// flows (camera preview, check-scanner transaction status, and the dedicated
    /// Status/Capabilities buttons) that call one specific command directly rather than
    /// presenting the full dynamic command list. Unlike <see cref="GetCommands"/>, this is not
    /// filtered by <see cref="ExcludedWireNames"/> or by what a particular service reports
    /// supporting.
    /// </summary>
    public static CommandDescriptor FindByWireName(string wireName)
        => All.Value.FirstOrDefault(d => d.WireName == wireName);

    /// <summary>
    /// Returns every known command whose wire name is reported as supported by the connected
    /// service. Falls back to matching by interface-namespace prefix if the precise wire-name
    /// set doesn't resolve anything for a supported interface, so a service report that omits
    /// the per-command dictionary still yields a usable (if slightly broader) command list.
    /// </summary>
    public static IReadOnlyList<CommandDescriptor> GetCommands(DiscoveredService service)
    {
        var candidates = All.Value.Where(d => !ExcludedWireNames.Contains(d.WireName));

        var byWireName = candidates.Where(d => service.SupportedCommandNames.Contains(d.WireName)).ToList();
        if (byWireName.Count > 0)
        {
            return byWireName;
        }

        var prefixes = service.Interfaces.Select(i => i + ".").ToArray();
        return candidates.Where(d => prefixes.Any(p => d.WireName.StartsWith(p, StringComparison.Ordinal))).ToList();
    }

    private static IReadOnlyList<CommandDescriptor> BuildAll()
    {
        var assembly = Assembly.GetAssembly(typeof(XFS4IoT.Common.Commands.StatusCommand));
        var descriptors = new List<CommandDescriptor>();

        foreach (var type in assembly.GetTypes())
        {
            var commandAttribute = type.GetCustomAttribute<CommandAttribute>();
            if (commandAttribute?.Name is null)
            {
                continue;
            }

            var commandCtor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Length > 0);
            if (commandCtor is null)
            {
                continue;
            }

            var payloadType = type.GetNestedType("PayloadData");
            var payloadCtor = payloadType?.GetConstructors().SingleOrDefault();

            var completionType = ResolveCompletionType(type);
            if (completionType is null)
            {
                continue;
            }

            descriptors.Add(new CommandDescriptor(commandAttribute.Name, type, payloadType, completionType, commandCtor, payloadCtor));
        }

        return descriptors;
    }

    /// <summary>
    /// Rewrites "X.Commands.FooCommand" to "X.Completions.FooCompletion" (verified with zero
    /// exceptions across the CardReader/CashDispenser/Printer/CheckScanner/Biometric commands
    /// inspected while designing this catalog), with a case-insensitive structural fallback.
    /// </summary>
    private static Type ResolveCompletionType(Type commandType)
    {
        const string CommandsSuffix = "Commands";
        const string CompletionsSuffix = "Completions";
        const string CommandTypeSuffix = "Command";
        const string CompletionTypeSuffix = "Completion";

        var ns = commandType.Namespace;
        if (ns is null || !ns.EndsWith(CommandsSuffix, StringComparison.Ordinal) ||
            !commandType.Name.EndsWith(CommandTypeSuffix, StringComparison.Ordinal))
        {
            return null;
        }

        var completionNamespace = ns[..^CommandsSuffix.Length] + CompletionsSuffix;
        var completionName = commandType.Name[..^CommandTypeSuffix.Length] + CompletionTypeSuffix;

        var resolved = commandType.Assembly.GetType($"{completionNamespace}.{completionName}");
        if (resolved is not null)
        {
            return resolved;
        }

        return commandType.Assembly.GetTypes().FirstOrDefault(t =>
            t.Namespace == completionNamespace &&
            t.Name.Equals(completionName, StringComparison.OrdinalIgnoreCase));
    }
}
