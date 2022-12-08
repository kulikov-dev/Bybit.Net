using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Server time record
    /// </summary>
    public class BybitUnifiedMarginServerTime
    {
        /// <summary>
        /// ServerTime
        /// </summary>
        [JsonProperty("timeSecond"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime ServerTime { get; set; }
    }
}
