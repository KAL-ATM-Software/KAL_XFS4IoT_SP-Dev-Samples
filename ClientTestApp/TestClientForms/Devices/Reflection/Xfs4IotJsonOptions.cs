/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// The camelCase JSON convention XFS4IoT commands use over the wire, shared by anything in this
/// namespace that needs to (de)serialize a vendor payload type directly (e.g.
/// <see cref="JsonFileLoaderEditor"/>). Mirrors XfsServiceSession's GenericMessageOptions rather
/// than reaching into the vendor's own MessageBase.JsonOptions field, which is private.
/// </summary>
internal static class Xfs4IotJsonOptions
{
    public static readonly JsonSerializerOptions Value = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };
}
