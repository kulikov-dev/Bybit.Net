using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Mark price kline info
    /// </summary>
    public class BybitUnifiedMarginMarkPriceKline
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
        public IEnumerable<BybitUnifiedMarginMarkPriceKlineEntry> Klines { get; set; } = Array.Empty<BybitUnifiedMarginMarkPriceKlineEntry>();
    }

    /// <summary>
    /// Mark price klines entry
    /// </summary>
    [JsonConverter(typeof(ArrayConverter))]
    public class BybitUnifiedMarginMarkPriceKlineEntry
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
    }
}
