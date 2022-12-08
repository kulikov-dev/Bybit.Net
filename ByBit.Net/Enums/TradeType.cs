using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Trade type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum TradeType
    {
        /// <summary>
        /// Normal trade
        /// </summary>
        [Map("Trade")]
        Trade,
        /// <summary>
        /// Adl trade
        /// </summary>
        [Map("AdlTrade")]
        AdlTrade,
        /// <summary>
        /// Funding trade
        /// </summary>
        [Map("Funding")]
        Funding,
        /// <summary>
        /// Bankruptcy trade
        /// </summary>
        [Map("BustTrade")]
        BustTrade
    }
}
