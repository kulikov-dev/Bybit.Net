using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for risk limit
    /// </summary>
    public class BybitUnifiedMarginRiskLimitWrapper
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear inverse are available
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// List of risk limits
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginRiskLimit> Limits { get; set; } = Array.Empty<BybitUnifiedMarginRiskLimit>();
    }

    /// <summary>
    /// Risk limit info
    /// </summary>
    public class BybitUnifiedMarginRiskLimit
    {
        /// <summary>
        /// Risk id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// Risk limit
        /// </summary>
        public decimal Limit { get; set; }
        /// <summary>
        /// Maintain margin
        /// </summary>
        public decimal MaintainMargin { get; set; }
        /// <summary>
        /// Starting margin
        /// </summary>
        [JsonProperty("initialMargin")]
        public decimal StartingMargin { get; set; }
        /// <summary>
        /// Section
        /// </summary>
        public IEnumerable<string> Section { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Is lowest risk
        /// </summary>
        public bool IsLowestRisk { get; set; }
        /// <summary>
        /// Max leverage
        /// </summary>
        public decimal MaxLeverage { get; set; }
    }
}
