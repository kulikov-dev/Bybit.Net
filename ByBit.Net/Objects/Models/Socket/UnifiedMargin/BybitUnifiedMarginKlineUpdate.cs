using Bybit.Net.Converters;
using Bybit.Net.Enums;
using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.Socket.UnifiedMargin
{
    /// <summary>
    /// Kline update
    /// </summary>
    public class BybitUnifiedMarginKlineUpdate : BybitKlineUpdate
    {
        /// <summary>
        /// Data refresh interval
        /// </summary>
        [JsonConverter(typeof(KlineIntervalConverter))]
        public KlineInterval Interval { get; set; }
    }
}
