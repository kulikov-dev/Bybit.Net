using CryptoExchange.Net.Interfaces;
using System;

namespace Bybit.Net.Interfaces.Clients.UnifiedMarginApi
{
    /// <summary>
    /// Bybit Unified Margin API endpoints
    /// </summary>
    public interface IBybitClientUnifiedMarginApi : IDisposable
    {
        /// <summary>
        /// The factory for creating requests. Used for unit testing
        /// </summary>
        IRequestFactory RequestFactory { get; set; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        IBybitClientUnifiedMarginApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        IBybitClientUnifiedMarginApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        IBybitClientUnifiedMarginApiTrading Trading { get; }
    }
}