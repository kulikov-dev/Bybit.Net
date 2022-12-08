using Bybit.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for cancelled order
    /// </summary>
    public class BybitUnifiedMarginCancelledOrderWrapper
    {
        /// <summary>
        /// List of cancelled orders
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginCancelledOrder> CancelledOrders { get; set; } = Array.Empty<BybitUnifiedMarginCancelledOrder>();
    }

    /// <summary>
    /// Cancelled order info
    /// </summary>
    public class BybitUnifiedMarginCancelledOrder : BybitUnifiedMarginOrderId
    {
        /// <summary>
        /// Derivatives products category. If category is not passed, then return ""For now, linear option are available
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
}
