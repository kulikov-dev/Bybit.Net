using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Open interest info
    /// </summary>
    public class BybitUnifiedMarginOpenInterestWrapper
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear inverse including inverse futures are available
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Items
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginOpenInterest> Values { get; set; } = Array.Empty<BybitUnifiedMarginOpenInterest>();
    }

    /// <summary>
    /// Open interest item
    /// </summary>
    public class BybitUnifiedMarginOpenInterest
    {
        /// <summary>
        /// Open interest value
        /// </summary>
        public decimal OpenInterest { get; set; }
        /// <summary>
        /// Date timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
