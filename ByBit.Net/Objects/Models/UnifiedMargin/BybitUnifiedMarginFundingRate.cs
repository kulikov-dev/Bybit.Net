using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for funding rate
    /// </summary>
    public class BybitUnifiedMarginFundingRateWrapper
    {
        /// <summary>
        /// List of funding rate
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginFundingRate> FundingRates { get; set; } = Array.Empty<BybitUnifiedMarginFundingRate>();
    }

    /// <summary>
    /// Funding rate info
    /// </summary>
    public class BybitUnifiedMarginFundingRate
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear inverse are available
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal FundingRate { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("fundingRateTimestamp"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
