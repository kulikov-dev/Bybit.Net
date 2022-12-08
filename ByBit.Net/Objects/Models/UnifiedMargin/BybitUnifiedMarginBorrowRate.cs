using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Wrapper for borrow rate
    /// </summary>
    public class BybitUnifiedMarginBorrowRateWrapper
    {
        /// <summary>
        /// List of borrow rates
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<BybitUnifiedMarginBorrowRate> BorrowRates { get; set; } = Array.Empty<BybitUnifiedMarginBorrowRate>();
    }

    /// <summary>
    /// Borrow rate
    /// </summary>
    public class BybitUnifiedMarginBorrowRate
    {
        /// <summary>
        /// Only for UDDC, USDT.If not passed, USDT&USDC interests are returned.You could pass multiple currency separated by comma, e.a USDC, USDT.
        /// </summary>
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Hourly interest rate
        /// </summary>
        public decimal HourlyBorrowRate { get; set; }

        /// <summary>
        /// Max loan amount
        /// </summary>
        public decimal MaxBorrowingAmount { get; set; }

        /// <summary>
        /// The free interest of loan amount
        /// </summary>
        public decimal FreeBorrowingAmount { get; set; }
    }
}
