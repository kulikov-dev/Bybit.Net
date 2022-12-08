using Bybit.Net.Enums;
using Bybit.Net.Objects.Models;
using Bybit.Net.Objects.Models.Socket;
using Bybit.Net.Objects.Models.Socket.UnifiedMargin;
using Bybit.Net.Objects.Models.UnifiedMargin;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.UnifiedMarginApi
{
    /// <summary>
    /// Bybit usd perpetual streams
    /// </summary>
    public interface IBybitSocketClientUnifiedMarginStreams
    {
        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="limit">The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the update messages</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(StreamCategory category, string symbol, int limit, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> deltaHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to orderbook updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorderbookdepth" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="limit">The amount of rows to receive updates for. Either 1, 25, 50, 100, 200.</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the update messages</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBooksUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, int limit, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> snapshotHandler, Action<DataEvent<BybitUnifiedMarginOrderBookEntry>> deltaHandler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(StreamCategory category, string symbol, Action<DataEvent<IEnumerable<BybitUnifiedMarginTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to public trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websockettrade" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradesUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, Action<DataEvent<IEnumerable<BybitUnifiedMarginTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(StreamCategory category, string symbol, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates. Note that for a symbol the first update is a snapshot, containing all info. After that only partial updates are given for 
        /// properties which have changed. If a property in the update is `null` it isn't changed and should be ignored.
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketticker_v3" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickersUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, Action<DataEvent<BybitTickerUpdate>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbol">The symbol to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(StreamCategory category, string symbol, KlineInterval interval, Action<DataEvent<IEnumerable<BybitUnifiedMarginKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to kline (candlestick) updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketkline" /></para>
        /// </summary>
        /// <param name="category">Asset category</param>
        /// <param name="interval">The interval of the klines</param>
        /// <param name="symbols">List of symbols to receive updates for</param>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlinesUpdatesAsync(StreamCategory category, IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IEnumerable<BybitUnifiedMarginKlineUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user position updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketposition" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginPositionUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user trade updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketexecution" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginUserTradeUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user order updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketorder" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<IEnumerable<BybitUnifiedMarginOrderUpdate>>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to user balance updates
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-websocketwallet" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BybitUnifiedMarginBalance>> handler, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to greeks update
        /// <para><a href="https://bybit-exchange.github.io/docs/derivativesV3/unified_margin/#t-greeksoption" /></para>
        /// </summary>
        /// <param name="handler">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToGreeksUpdatesAsync(Action<DataEvent<IEnumerable<BybitGreeksUpdate>>> handler, CancellationToken ct = default);
    }
}
