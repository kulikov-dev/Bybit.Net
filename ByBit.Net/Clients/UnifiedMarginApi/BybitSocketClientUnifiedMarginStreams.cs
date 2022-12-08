using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients.UnifiedMarginApi;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Internal.Socket;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects.Models.Socket.UnifiedMargin;
using Bybit.Net.Objects.Models.UnifiedMargin;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.UnifiedMarginApi
{
    /// <inheritdoc cref="IBybitSocketClientUnifiedMarginStreams" />
    public class BybitSocketClientUnifiedMarginStreams : SocketApiClient, IBybitSocketClientUnifiedMarginStreams
    {
        private readonly BybitSocketClientOptions _options;

        internal BybitSocketClientUnifiedMarginStreams(Log log, BybitSocketClientOptions options)
            : base(log, options, options.UnifiedMarginStreamsOptions)
        {
            _log = log;
            _options = options;

            ContinueOnQueryResponse = true;
            UnhandledMessageExpected = true;
            KeepAliveInterval = TimeSpan.Zero;

            SendPeriodic("Ping", options.UnifiedMarginStreamsOptions.PingInterval, (connection) =>
            {
                return new BybitRequestMessage() { Operation = "ping" };
            });
            AddGenericHandler("Heartbeat", (evnt) => { });
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new BybitAuthenticationProvider(credentials);


        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamCategory category, string symbol, int limit, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> deltaHandler, CancellationToken ct = default)
            => SubscribeToOrderBooksUpdatesAsync(category, new string[] { symbol }, limit, snapshotHandler, deltaHandler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> deltaHandler, CancellationToken ct = default)
        {
            limit.ValidateIntValues(nameof(limit), 1, 25, 50, 100, 200);

            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var type = data.Data["type"]?.ToString();
                var internalData = data.Data["data"];
                if (internalData == null || string.IsNullOrWhiteSpace(type))
                    return;

                var desResult = Deserialize<BybitUnifiedMarginOrderBookEntry>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitOrderBookEntry)} object: " + desResult.Error);
                    return;
                }

               if (type.Equals("snapshot", StringComparison.Ordinal))
                {
                    snapshotHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
                else
                {
                    deltaHandler(data.As(desResult.Data, desResult.Data.Symbol));
                }
            });

            var topic = $"orderbook.{limit}.";
            return await SubscribeAsync(
                _options.UnifiedMarginStreamsOptions.GetPublicAddress(category),
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => topic + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamCategory category, string symbol, Action<DataEvent<IEnumerable<BybitUnifiedMarginTradeUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToTradesUpdatesAsync(category, new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitUnifiedMarginTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitUnifiedMarginTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data, desResult.Data.First().Symbol));
            });

            return await SubscribeAsync(
                 _options.UnifiedMarginStreamsOptions.GetPublicAddress(category),
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "publicTrade." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamCategory category, string symbol, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default)
            => SubscribeToTickersUpdatesAsync(category, new string[] { symbol }, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default)
        {
            // TODO GENKI
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitUnifiedMarginKlineUpdate>>> handler, CancellationToken ct = default)
            => SubscribeToKlinesUpdatesAsync(category, new string[] { symbol }, interval, handler, ct);

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitUnifiedMarginKlineUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitUnifiedMarginKlineUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginKlineUpdate)} object: " + desResult.Error);
                    return;
                }

                var topic = data.Data["topic"]!.ToString();
                handler(data.As(desResult.Data, topic.Split('.').Last()));
            });

            return await SubscribeAsync(
                _options.UnifiedMarginStreamsOptions.GetPublicAddress(category),
                new BybitRequestMessage() { Operation = "subscribe", Parameters = symbols.Select(s => "kline." + JsonConvert.SerializeObject(interval, new KlineIntervalConverter(false)) + "." + s).ToArray() },
                null, false, internalHandler, ct).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginPositionUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitUnifiedMarginPositionUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginPositionUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });

            return await SubscribeAsync(_options.UnifiedMarginStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "user.position.unifiedAccount" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginUserTradeUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitUnifiedMarginUserTradeUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginUserTradeUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });

            return await SubscribeAsync(_options.UnifiedMarginStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "user.execution.unifiedAccount" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginOrderUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitUnifiedMarginOrderUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginOrderUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });

            return await SubscribeAsync(_options.UnifiedMarginStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "user.order.unifiedAccount" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitUnifiedMarginBalance>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<BybitUnifiedMarginBalance>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitUnifiedMarginBalance)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });

            return await SubscribeAsync(_options.UnifiedMarginStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "user.wallet.unifiedAccount" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToGreeksUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeksUpdate>>> handler, CancellationToken ct = default)
        {
            var internalHandler = new Action<DataEvent<JToken>>(data =>
            {
                var internalData = data.Data["data"];
                if (internalData == null)
                    return;

                var desResult = Deserialize<IEnumerable<BybitGreeksUpdate>>(internalData);
                if (!desResult)
                {
                    _log.Write(LogLevel.Warning, $"Failed to deserialize {nameof(BybitGreeksUpdate)} object: " + desResult.Error);
                    return;
                }

                handler(data.As(desResult.Data));
            });

            return await SubscribeAsync(_options.UnifiedMarginStreamsOptions.BaseAddressAuthenticated,
                new BybitRequestMessage() { Operation = "subscribe", Parameters = new[] { "user.greeks.unifiedAccount" } },
                null, true, internalHandler, ct).ConfigureAwait(false);
        }


        /// <inheritdoc />
        protected override async Task<CallResult<bool>> AuthenticateSocketAsync(SocketConnection socketConnection)
        {
            if (socketConnection.ApiClient.AuthenticationProvider == null)
                return new CallResult<bool>(new NoApiCredentialsError());

            var expireTime = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow.AddSeconds(30))!;
            var key = socketConnection.ApiClient.AuthenticationProvider.Credentials.Key!.GetString();
            var sign = socketConnection.ApiClient.AuthenticationProvider.Sign($"GET/realtime{expireTime}");

            var authRequest = new BybitRequestMessage()
            {
                Operation = "auth",
                Parameters = new object[]
                {
                    key,
                    expireTime,
                    sign
                }
            };

            var result = false;
            var error = "unspecified error";
            await socketConnection.SendAndWaitAsync(authRequest, Options.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "auth")
                    return false;

                result = data["success"]?.Value<bool>() == true;
                error = data["ret_msg"]?.ToString();
                return true;

            }).ConfigureAwait(false);
            return result ? new CallResult<bool>(result) : new CallResult<bool>(new ServerError(error));
        }

        /// <inheritdoc />
        protected override bool HandleQueryResponse<T>(SocketConnection socketConnection, object request, JToken data, out CallResult<T> callResult)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override bool HandleSubscriptionResponse(SocketConnection socketConnection, SocketSubscription subscription, object request, JToken data, out CallResult<object>? callResult)
        {
            callResult = null;
            if (data.Type != JTokenType.Object)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;
            var operation = data["request"]?["op"]?.ToString();
            var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
            if (operation != "subscribe")
                return false;

            if (requestParams.Any(p => !args.Contains(p)))
                return false;

            var success = data["success"]?.Value<bool>() == true;
            if (success)
                callResult = new CallResult<object>(true);
            else
                callResult = new CallResult<object>(new ServerError(data["ret_msg"]!.ToString()));
            return true;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, object request)
        {
            if (message.Type != JTokenType.Object)
                return false;

            var topic = message["topic"]?.ToString();
            if (topic == null)
                return false;

            var requestParams = ((BybitRequestMessage)request).Parameters;
            if (requestParams.Any(p => topic == p.ToString()))
                return true;

            if (topic.Contains('.'))
            {
                // Some subscriptions have topics like orderbook.ETHUSDT
                // Split on `.` to get the topic and symbol
                var split = topic.Split('.');
                var symbol = split.Last();
                if (symbol.Length == 0)
                    return false;

                var mainTopic = topic.Substring(0, topic.Length - symbol.Length - 1);
                if (requestParams.Any(p => (string)p == (mainTopic + ".*")))
                    return true;
            }

            return false;
        }

        /// <inheritdoc />
        protected override bool MessageMatchesHandler(SocketConnection socketConnection, JToken message, string identifier)
        {
            if (identifier == "Heartbeat")
            {
                if (message.Type != JTokenType.Object)
                    return false;

                var ret = message["ret_msg"];
                if (ret == null)
                    return false;

                var isPing = ret.ToString() == "pong";
                if (!isPing)
                    return false;

                return true;
            }

            if (identifier == "AccountInfo")
            {
                if (message.Type != JTokenType.Array)
                    return false;

                var updateType = ((JArray)message)[0]["e"]?.ToString();
                if (updateType == null)
                    return false;

                return updateType == "outboundAccountInfo" || updateType == "stop_executionReport" || updateType == "executionReport" || updateType == "order" || updateType == "ticketInfo";
            }

            return false;
        }

        /// <inheritdoc />
        protected override async Task<bool> UnsubscribeAsync(SocketConnection connection, SocketSubscription subscriptionToUnsub)
        {
            var requestParams = ((BybitRequestMessage)subscriptionToUnsub.Request!).Parameters;
            var message = new BybitRequestMessage { Operation = "unsubscribe", Parameters = requestParams };

            var result = false;
            await connection.SendAndWaitAsync(message, Options.SocketResponseTimeout, data =>
            {
                if (data.Type != JTokenType.Object)
                    return false;

                var operation = data["request"]?["op"]?.ToString();
                var args = data["request"]?["args"].Select(p => p.ToString()).ToList();
                if (operation != "unsubscribe")
                    return false;

                if (requestParams.Any(p => !args.Contains(p)))
                    return false;

                result = data["success"]?.Value<bool>() == true;
                return true;
            }).ConfigureAwait(false);
            return result;
        }
    }
}
