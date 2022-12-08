using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for trade info
    /// </summary>
    public class BybitUnifiedMarginTradeWrapper
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// List of trades info
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginTrade> Trades { get; set; } = Array.Empty<BybitUnifiedMarginTrade>();
    }

    /// <summary>
    /// Trade info
    /// </summary>
    public class BybitUnifiedMarginTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("execId")]
        public string Id { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Trade price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order quantity in USD
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Side of the trade
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Timestamp of the trade
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        internal DateTime Time { get; set; }
    }
}
