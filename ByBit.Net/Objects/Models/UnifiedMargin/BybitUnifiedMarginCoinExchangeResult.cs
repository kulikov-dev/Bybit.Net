using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for exchange result
    /// </summary>
    public class BybitUnifiedMarginCoinExchangeResultWrapper
    {
        /// <summary>
        /// List of exchange result
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginCoinExchangeResult> ExchangeResults { get; set; } = Array.Empty<BybitUnifiedMarginCoinExchangeResult>();
    }

    public class BybitUnifiedMarginCoinExchangeResult
    {
        /// <summary>
        /// Exchange transaction id
        /// </summary>
        [JsonProperty("exchangeTxId")]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// From coin
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;

        /// <summary>
        /// From amount
        /// </summary>
        public decimal FromAmount { get; set; }

        /// <summary>
        /// From coin
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;

        /// <summary>
        /// From amount
        /// </summary>
        public decimal ToAmount { get; set; }

        /// <summary>
        /// Create time
        /// </summary>
        [JsonProperty("createdAt"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Exchange rate
        /// </summary>
        public decimal ExchangeRate { get; set; }
    }
}
