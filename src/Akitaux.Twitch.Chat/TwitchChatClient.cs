using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Akitaux.Twitch.Chat.Serialization;
using Voltaic;
using Voltaic.Serialization;
using Voltaic.Serialization.Utf8;

namespace Akitaux.Twitch.Chat
{
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Disconnecting
    }

    public class TwitchChatClient : IDisposable
    {
        public static string Version { get; } =
            typeof(TwitchChatClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(TwitchChatClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";
        
        // Status events
        public event Action Connected;
        public event Action<Exception> Disconnected;
        public event Action<SerializationException> DeserializationError;

        // Raw events
        public event Action<IrcMessage, int> ReceivedPayload;
        public event Action<IrcMessage> SentPayload;

        // Events
        public event Action Heartbeat;
        public event Action HeartbeatAck;
        public event Action Reconnect;

        // Instance
        private readonly ResizableMemoryStream _memoryStream;
        private Task _connectionTask;
        private CancellationTokenSource _runCts;
        private string _url;

        // Connection
        private readonly SemaphoreSlim _stateLock;
        private BlockingCollection<IrcMessage> _sendQueue;
        private bool _receivedData;

        public ConnectionState State { get; private set; }
        public Utf8Serializer Serializer { get; }

        public TwitchChatClient(Utf8Serializer serializer = null)
        {
            Serializer = serializer ?? new Utf8Serializer();
            _memoryStream = new ResizableMemoryStream(10 * 1024); // 10 KB
            _stateLock = new SemaphoreSlim(1, 1);
            _connectionTask = Task.CompletedTask;
            _runCts = new CancellationTokenSource();
            _runCts.Cancel(); // Start canceled
        }
        
        public void Run(string url)
            => RunAsync(url).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task RunAsync(string url)
        {
            Task exceptionSignal;
            await _stateLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopAsyncInternal().ConfigureAwait(false);

                _url = url;
                _runCts = new CancellationTokenSource();

                _connectionTask = RunTaskAsync(_runCts.Token);
                exceptionSignal = _connectionTask;
            }
            finally
            {
                _stateLock.Release();
            }
            await exceptionSignal.ConfigureAwait(false);
        }
        private async Task RunTaskAsync(CancellationToken runCancelToken)
        {
            Task[] tasks = null;
            bool isRecoverable = true;

            while (isRecoverable)
            {
                Exception disconnectEx = null;
                var connectionCts = new CancellationTokenSource();
                var cancelToken = CancellationTokenSource.CreateLinkedTokenSource(runCancelToken, connectionCts.Token).Token;

                using (var client = new ClientWebSocket())
                {
                    try
                    {
                        cancelToken.ThrowIfCancellationRequested();
                        _receivedData = true;

                        State = ConnectionState.Connecting;
                        var uri = new Uri(_url);
                        await client.ConnectAsync(uri, cancelToken).ConfigureAwait(false);

                        _sendQueue = new BlockingCollection<IrcMessage>();
                        tasks = new[]
                        {
                            RunSendAsync(client, cancelToken),
                            RunReceiveAsync(client, cancelToken)
                        };

                        State = ConnectionState.Connected;
                        Connected?.Invoke();

                        // Wait until an exception occurs (due to cancellation or failure)
                        await WhenAny(tasks).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        disconnectEx = ex;
                        isRecoverable = IsRecoverable(ex);
                        if (!isRecoverable)
                            throw;
                    }
                    finally
                    {
                        var oldState = State;
                        State = ConnectionState.Disconnecting;

                        // Wait for the other tasks to complete
                        connectionCts.Cancel();
                        if (tasks != null)
                        {
                            try { await Task.WhenAll(tasks).ConfigureAwait(false); }
                            catch { } // We already captured the root exception
                        }

                        // receiveTask and sendTask must have completed before we can send/receive from a different thread
                        if (client.State == WebSocketState.Open)
                        {
                            try { await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None).ConfigureAwait(false); }
                            catch { } // We don't actually care if sending a close msg fails
                        }

                        _sendQueue = null;
                        State = ConnectionState.Disconnected;
                        if (oldState == ConnectionState.Connected)
                            Disconnected?.Invoke(disconnectEx);

                        // Something something exponential backoff here
                        if (isRecoverable)
                            await Task.Delay(5000);
                    }
                }
            }
        }
        private async Task WhenAny(IEnumerable<Task> tasks)
        {
            var task = await Task.WhenAny(tasks).ConfigureAwait(false);
            //if (task.IsFaulted)
            await task.ConfigureAwait(false); // Return or rethrow
        }
        private async Task WhenAny(IEnumerable<Task> tasks, int millis, string errorText)
        {
            var timeoutTask = Task.Delay(millis);
            var task = await Task.WhenAny(tasks.Append(timeoutTask)).ConfigureAwait(false);
            if (task == timeoutTask)
                throw new TimeoutException(errorText);
            //else if (task.IsFaulted)
            await task.ConfigureAwait(false); // Return or rethrow
        }
        private bool IsRecoverable(Exception ex)
        {
            switch (ex)
            {
                case WebSocketException wsEx:
                    if (wsEx.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                        return true;
                    break;
                case WebSocketClosedException wscEx:
                    if (wscEx.CloseStatus.HasValue)
                    {
                        switch (wscEx.CloseStatus.Value)
                        {
                            case WebSocketCloseStatus.Empty:
                            case WebSocketCloseStatus.NormalClosure:
                            case WebSocketCloseStatus.InternalServerError:
                            case WebSocketCloseStatus.ProtocolError:
                                return true;
                        }
                    }
                    break;
                case TimeoutException _: // Caused by missing heartbeat ack
                    return true;
            }
            if (ex.InnerException != null)
                return IsRecoverable(ex.InnerException);
            return false;
        }
        
        private Task RunReceiveAsync(ClientWebSocket client, CancellationToken cancelToken)
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    try
                    {
                        await ReceiveAsync(client, cancelToken).ConfigureAwait(false);
                    }
                    catch (SerializationException ex)
                    {
                        DeserializationError?.Invoke(ex);
                    }
                }
            });
        }
        private async Task<IrcMessage> ReceiveAsync(ClientWebSocket client, CancellationToken cancelToken)
        {
            // Reset memory stream
            _memoryStream.Position = 0;
            _memoryStream.SetLength(0);

            WebSocketReceiveResult result;
            do
            {
                var buffer = _memoryStream.Buffer.RequestSegment(10 * 1024);
                result = await client.ReceiveAsync(buffer, cancelToken).ConfigureAwait(false);
                _memoryStream.Buffer.Advance(result.Count);
                _receivedData = true;

                if (result.CloseStatus != null)
                    throw new WebSocketClosedException(result.CloseStatus.Value, result.CloseStatusDescription);
            }
            while (!result.EndOfMessage);

            var payload = IrcParser.Read(_memoryStream.Buffer.AsReadOnlySpan(), Serializer);

            HandleEvent(payload);
            ReceivedPayload?.Invoke(payload, _memoryStream.Buffer.Length);
            return payload;
        }
        private void HandleEvent(IrcMessage evnt)
        {
            switch (evnt.Command)
            {
                case IrcCommand.Ping:
                    SendHeartbeatAck();
                    Heartbeat?.Invoke();
                    break;
                case IrcCommand.Pong: HeartbeatAck?.Invoke(); break;
            }
        }

        private Task RunSendAsync(ClientWebSocket client, CancellationToken cancelToken)
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    var payload = _sendQueue.Take(cancelToken);
                    await SendAsync(client, cancelToken, payload).ConfigureAwait(false);
                }
            });
        }
        public void Send(IrcMessage payload)
        {
            if (!_runCts.IsCancellationRequested)
                _sendQueue?.Add(payload);
        }
        private async Task SendAsync(ClientWebSocket client, CancellationToken cancelToken, IrcMessage payload)
        {
            var writer = IrcParser.Write(payload, Serializer);
            await client.SendAsync(writer.AsSegment(), WebSocketMessageType.Text, true, cancelToken);
            SentPayload?.Invoke(payload);
        }

        public void Stop()
            => StopAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task StopAsync()
        {
            await _stateLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopAsyncInternal().ConfigureAwait(false);
            }
            finally
            {
                _stateLock.Release();
            }
        }
        private async Task StopAsyncInternal()
        {
            _runCts?.Cancel(); // Cancel any connection attempts or active connections

            try { await _connectionTask.ConfigureAwait(false); } catch { } // Wait for current connection to complete
            _connectionTask = Task.CompletedTask;

            // Double check that the connection task terminated successfully
            var state = State;
            if (state != ConnectionState.Disconnected)
                throw new InvalidOperationException($"Client did not successfully disconnect (State = {state}).");
        }

        public void Dispose()
        {
            Stop();
        }

        private void SendHeartbeatAck() => Send(new IrcMessage(IrcCommand.Ping, Utf8String.Empty));
    }
}