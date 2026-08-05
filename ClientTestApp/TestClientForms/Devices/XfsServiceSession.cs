/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT.TestTool.Devices.Reflection;
using XFS4IoT.Common;

namespace XFS4IoT.TestTool.Devices;

public delegate void XFS4IoTMessagesDelegate(object sender, string msg);

/// <summary>
/// A service discovered on the network: its endpoint, the interfaces it reports supporting,
/// and the exact set of command wire names it advertises (the union of every supported
/// interface's Commands dictionary keys) — this is what drives the GUI's command list, so a
/// service exposing several interfaces at once (e.g. CashDispenser + CashAcceptor +
/// CashManagement + Storage together) naturally offers every command from all of them.
/// </summary>
public sealed class DiscoveredService(
    string serviceURI, 
    IReadOnlyList<InterfaceClass.NameEnum> interfaces, 
    IReadOnlySet<string> supportedCommandNames)
{
    /// <summary>
    /// Service URI to connect.
    /// </summary>
    public string ServiceURI { get; } = serviceURI;

    /// <summary>
    /// Interfaces the service reports supporting.
    /// </summary>
    public IReadOnlyList<InterfaceClass.NameEnum> Interfaces { get; } = interfaces;

    /// <summary>
    /// Command names the service reports supporting.
    /// </summary>
    public IReadOnlySet<string> SupportedCommandNames { get; } = supportedCommandNames;

    public override string ToString() => ServiceURI;
}

/// <summary>
/// A single active connection to one XFS4IoT service. Replaces the old one-wrapper-class-per-
/// device-type pattern: since the GUI no longer has one tab per device, there is exactly one
/// session at a time (connecting to a new service automatically disconnects the previous one),
/// and the commands it can execute are whatever the connected service itself reports
/// supporting, discovered generically via <see cref="Xfs4IotCommandCatalog"/>.
/// </summary>
public sealed class XfsServiceSession
{
    public static readonly int CommandTimeout = 60000;

    /// <summary>
    /// Mirrors the camelCase-properties / camelCase-string-enums profile that
    /// XFS4IoT.MessageBase.Serialise() uses internally. Needed because
    /// XFS4IoT.GenericMessageContext (the vendor's source-generated context used to decode
    /// messages the framework can't map to a concrete typed Completion/Event) bakes in
    /// UseStringEnumConverter=true without a naming policy, so its own enum values serialize
    /// as raw PascalCase member names ("Command") instead of camelCase ("command") — and since
    /// its metadata is source-generated, that can't be overridden by passing a different
    /// JsonSerializerOptions to that same context. Serialising reflection-based instead (via
    /// message.GetType() rather than the frozen GenericMessageClass context) also correctly
    /// handles GenericMessageClass.Payload, which is typed as plain object.
    /// </summary>
    private static readonly JsonSerializerOptions GenericMessageOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };

    public event XFS4IoTMessagesDelegate XFS4IoTMessages;

    /// <summary>
    /// Message handler to show every message received from the service in the log/tree view, including unsolicited
    /// </summary>
    private void OnXFS4IoTMessages(string msg) => XFS4IoTMessages?.Invoke(this, msg);

    /// <summary>
    /// Serialises any message received from the connection to JSON for the log/tree view,
    /// routing XFS4IoT.GenericMessageClass instances (the decoder's fallback wrapper for
    /// messages it can't map to a concrete typed Completion/Event) through
    /// <see cref="GenericMessageOptions"/> instead of MessageBase.Serialise(), which they don't
    /// support.
    /// </summary>
    private static string SerialiseMessage(object message)
        => message.GetType() == typeof(GenericMessageClass)
            ? JsonSerializer.Serialize(message, message.GetType(), GenericMessageOptions)
            : ((MessageBase)message).Serialise();

    /// <summary>
    /// Logs a receive failure as a small synthetic JSON "event" message rather than a
    /// plain string, so it flows through Form1's existing JsonDocument.Parse-based log/tree
    /// pipeline (which would otherwise throw trying to parse a non-JSON diagnostic string,
    /// hiding the very error it was meant to surface) instead of being silently swallowed.
    /// </summary>
    private void OnReceiveError(Exception ex)
    {
        var diagnostic = JsonSerializer.Serialize(new
        {
            header = new { name = "Internal.Error", type = "event", requestId = 0 },
            payload = new { message = ex.Message },
        });
        OnXFS4IoTMessages(diagnostic);
    }

    public bool IsConnected => _connection?.IsConnected == true;

    public DiscoveredService ConnectedService { get; private set; }

    /// <summary>
    /// One signle connection at a time.
    /// </summary>
    private XFS4IoTClient.ClientConnection _connection;
    private int? _currentRequestId;

    /// <summary>
    /// The command currently awaiting a response, if any — set by <see cref="ExecuteCommand"/>
    /// just before sending, and resolved by <see cref="ReceiveLoopAsync"/> when a message of
    /// the expected completion type arrives. Only one slot because the GUI only ever allows one
    /// command in flight at a time (Send disables itself and the command picker while waiting).
    /// </summary>
    private TaskCompletionSource<object> _pendingCompletion;
    private Type _pendingCompletionType;

    /// <summary>
    /// Probes every port in <see cref="XFS4IoT.XFSConstants.PortRanges"/> on the given host for
    /// running services, without filtering by supported interfaces (unlike the old per-tab
    /// discovery, which skipped any service missing a required interface) — every service found
    /// is returned, along with the interfaces/commands it reports.
    /// </summary>
    public async Task<IReadOnlyList<DiscoveredService>> DiscoverServicesAsync(string hostUri)
    {
        var results = new ConcurrentBag<DiscoveredService>();
        await Task.WhenAll(XFS4IoT.XFSConstants.PortRanges.Select(port => DiscoverPortAsync(hostUri, port, results)));
        return results.OrderBy(s => s.ServiceURI, StringComparer.Ordinal).ToList();
    }

    private async Task DiscoverPortAsync(string hostUri, int port, ConcurrentBag<DiscoveredService> results)
    {
        try
        {
            WebSocketState state;
            using (var probeSocket = new ClientWebSocket())
            {
                var cancel = new CancellationTokenSource();
                cancel.CancelAfter(40_000);
                await probeSocket.ConnectAsync(new Uri($"{hostUri}:{port}/xfs4iot/v1.0"), cancel.Token);
                state = probeSocket.State;
            }

            if (state != WebSocketState.Open)
            {
                return;
            }

            var discovery = new XFS4IoTClient.ClientConnection(new Uri($"{hostUri}:{port}/xfs4iot/v1.0"));
            try
            {
                await discovery.ConnectAsync();
            }
            catch (Exception)
            {
                return;
            }

            var getServicesCmd = new XFS4IoT.ServicePublisher.Commands.GetServicesCommand(RequestId.NewID(), CommandTimeout);
            OnXFS4IoTMessages(getServicesCmd.Serialise());
            await discovery.SendCommandAsync(getServicesCmd);

            object response = null;
            while (response is not XFS4IoT.ServicePublisher.Completions.GetServicesCompletion)
            {
                response = await discovery.ReceiveMessageAsync();
                if (response is null)
                {
                    return;
                }
            }

            var servicesCompletion = (XFS4IoT.ServicePublisher.Completions.GetServicesCompletion)response;
            OnXFS4IoTMessages(servicesCompletion.Serialise());

            foreach (var service in servicesCompletion.Payload.Services)
            {
                var capabilities = await GetCapabilitiesForServiceAsync(service.ServiceURI);
                if (capabilities is null)
                {
                    continue;
                }

                var interfaces = capabilities.Payload.Interfaces
                    .Where(i => i.Name.HasValue)
                    .Select(i => i.Name!.Value)
                    .ToList();

                var supportedCommandNames = capabilities.Payload.Interfaces
                    .Where(i => i.Commands is not null)
                    .SelectMany(i => i.Commands.Keys)
                    .ToHashSet(StringComparer.Ordinal);

                results.Add(new DiscoveredService(service.ServiceURI, interfaces, supportedCommandNames));
            }
        }
        catch (WebSocketException)
        {
        }
        catch (System.Net.HttpListenerException)
        {
        }
        catch (TaskCanceledException)
        {
        }
    }

    private async Task<XFS4IoT.Common.Completions.CapabilitiesCompletion> GetCapabilitiesForServiceAsync(string serviceUri)
    {
        var connection = new XFS4IoTClient.ClientConnection(new Uri(serviceUri));
        try
        {
            await connection.ConnectAsync();
        }
        catch (Exception)
        {
            return null;
        }

        var cmd = new XFS4IoT.Common.Commands.CapabilitiesCommand(RequestId.NewID(), CommandTimeout);
        OnXFS4IoTMessages(cmd.Serialise());
        await connection.SendCommandAsync(cmd);

        for (; ; )
        {
            var response = await connection.ReceiveMessageAsync();
            if (response is null)
            {
                return null;
            }

            if (response is XFS4IoT.Common.Completions.CapabilitiesCompletion completion)
            {
                OnXFS4IoTMessages(completion.Serialise());
                await connection.DisconnectAsync();
                return completion;
            }
        }
    }

    /// <summary>
    /// Connects to the given service. If a different service is already connected, it is
    /// disconnected first — this session only ever holds one active connection at a time.
    /// </summary>
    public async Task<bool> ConnectAsync(DiscoveredService service)
    {
        if (IsConnected)
        {
            await DisconnectAsync();
        }

        var connection = new XFS4IoTClient.ClientConnection(new Uri(service.ServiceURI));
        try
        {
            await connection.ConnectAsync();
        }
        catch (Exception)
        {
            return false;
        }

        _connection = connection;
        ConnectedService = service;
        _ = RunAsync(connection);
        return true;
    }

    public async Task DisconnectAsync()
    {
        var connection = _connection;
        _connection = null;
        ConnectedService = null;

        if (connection is not null)
        {
            await connection.DisconnectAsync();
        }
    }

    /// <summary>
    /// Continuously reads every message off <paramref name="connection"/> for as long as it
    /// remains this session's active connection, logging each one as it arrives (this is what
    /// lets unsolicited events show up in the log the moment they're received, independent of
    /// whether any command is currently in flight) and handing off whichever one satisfies
    /// <see cref="_pendingCompletion"/>, if any, to the command that's waiting for it. Started
    /// once by <see cref="ConnectAsync"/> and left running until superseded by a new connection
    /// or the connection is torn down, rather than being re-entered per command.
    /// </summary>
    private async Task RunAsync(XFS4IoTClient.ClientConnection connection)
    {
        while (ReferenceEquals(_connection, connection))
        {
            object message;
            try
            {
                message = await connection.ReceiveMessageAsync();
            }
            catch (Exception ex)
            {
                OnReceiveError(ex);
                break;
            }

            if (message is null)
            {
                break;
            }

            OnXFS4IoTMessages(SerialiseMessage(message));

            if (_pendingCompletion is TaskCompletionSource<object> pending &&
                _pendingCompletionType?.IsInstanceOfType(message) == true)
            {
                _pendingCompletion = null;
                _pendingCompletionType = null;
                pending.TrySetResult(message);
            }
        }

        // The connection this loop was reading from is gone (superseded or disconnected) —
        // don't leave a command hanging forever waiting for a response that will never come.
        _pendingCompletion?.TrySetResult(null);
        _pendingCompletion = null;
        _pendingCompletionType = null;
    }

    /// <summary>
    /// Builds and sends the command described by <paramref name="descriptor"/> using values
    /// taken from <paramref name="payloadProxy"/>, then waits for <see cref="RunAsync"/>
    /// to hand back a message of the expected completion type. This single generic method
    /// replaces every hand-written per-command send/receive method the old per-device wrapper
    /// classes used to duplicate. Only one command may be in flight at a time (the GUI already
    /// enforces this by disabling Send/the command picker while waiting).
    /// </summary>
    public async Task<object> ExecuteCommand(CommandDescriptor descriptor, ReflectedObjectProxy payloadProxy)
    {
        if (!IsConnected)
        {
            return null;
        }

        int requestId = RequestId.NewID();
        _currentRequestId = requestId;

        var completionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
        _pendingCompletionType = descriptor.CompletionType;
        _pendingCompletion = completionSource;

        try
        {
            object payload = descriptor.PayloadType is null
                ? null
                : ObjectProxyBuilder.Build(descriptor.PayloadType, payloadProxy);

            object[] ctorArgs = descriptor.PayloadType is null
                ? [requestId, CommandTimeout]
                : [requestId, payload, CommandTimeout];

            var command = descriptor.CommandCtor.Invoke(ctorArgs);

            OnXFS4IoTMessages(((MessageBase)command).Serialise());
            await _connection.SendCommandAsync(command);

            var completed = await Task.WhenAny(completionSource.Task, Task.Delay(CommandTimeout));
            if (completed != completionSource.Task)
            {
                // The receive thread never saw a matching completion within the time.
                OnXFS4IoTMessages(JsonSerializer.Serialize(new
                {
                    header = new { name = descriptor.WireName, type = "event", requestId },
                    payload = new { message = $"No completion received within {CommandTimeout}ms — the service may be stuck." },
                }));
                return null;
            }

            return await completionSource.Task;
        }
        finally
        {
            _currentRequestId = null;
            if (ReferenceEquals(_pendingCompletion, completionSource))
            {
                _pendingCompletion = null;
                _pendingCompletionType = null;
            }
        }
    }

    public async Task CancelCurrentCommand()
    {
        if (_currentRequestId is not int requestId || !IsConnected)
        {
            return;
        }

        var cancelCmd = new XFS4IoT.Common.Commands.CancelCommand(RequestId.NewID(), new([requestId]), 5000);
        OnXFS4IoTMessages(cancelCmd.Serialise());
        await _connection.SendCommandAsync(cancelCmd);
    }

    public async Task<XFS4IoT.Common.Completions.StatusCompletion> GetStatus()
    {
        var descriptor = Xfs4IotCommandCatalog.FindByWireName("Common.Status");
        if (descriptor is null)
        {
            return null;
        }

        return await ExecuteCommand(descriptor, null) as XFS4IoT.Common.Completions.StatusCompletion;
    }

    public async Task<XFS4IoT.Common.Completions.CapabilitiesCompletion> GetCapabilities()
    {
        var descriptor = Xfs4IotCommandCatalog.FindByWireName("Common.Capabilities");
        if (descriptor is null)
        {
            return null;
        }

        return await ExecuteCommand(descriptor, null) as XFS4IoT.Common.Completions.CapabilitiesCompletion;
    }
}

/// <summary>
/// Static class to keep track of the next request ID to use for commands sent to the service. 
/// </summary>
internal static class RequestId
{
    internal static int NewID() => Interlocked.Increment(ref _id);

    private static int _id = 1;
}
