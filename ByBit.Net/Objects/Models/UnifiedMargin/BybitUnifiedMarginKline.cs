using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Kline info
    /// </summary>
    public class BybitUnifiedMarginKline
    {
        /// <summary>
        /// Category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Name of the trading pair
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Klines
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginKlineEntry> Klines { get; set; } = Array.Empty<BybitUnifiedMarginKlineEntry>();
    }

    /// <summary>
    /// Kline entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitUnifiedMarginKlineEntry
    {
        /// <summary>
        /// Start
        /// </summary>
        [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Start { get; set; }
        /// <summary>
        /// Open
        /// </summary>
        [ArrayProperty(1)]
        public decimal Open { get; set; }
        /// <summary>
        /// High
        /// </summary>
        [ArrayProperty(2)]
        public decimal High { get; set; }
        /// <summary>
        /// Low
        /// </summary>
        [ArrayProperty(3)]
        public decimal Low { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [ArrayProperty(4)]
        public decimal Close { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [ArrayProperty(5)]
        public decimal Volume { get; set; }
        /// <summary>
        /// Turnover
        /// </summary>
        [ArrayProperty(6)]
        public decimal Turnover { get; set; }
    }
}
