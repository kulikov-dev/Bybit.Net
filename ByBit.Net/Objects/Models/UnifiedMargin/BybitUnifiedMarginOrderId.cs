using Newtonsoft.Json;

namespace Bybit.Net.Objects.Models.UnifiedMargin
{
    /// <summary>
    /// Order id
    /// </summary>
    public class BybitUnifiedMarginOrderId
    {
        /// <summary>
        /// Order id
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Strategy linked order ID
        /// </summary>
        [JsonProperty("orderLinkId")]
        public string ClientOrderId { get; set; } = string.Empty;
    }
}
