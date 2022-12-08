using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum OrderFilter
    {
        /// <summary>
        /// Active order
        /// </summary>
        [Map("Order")]
        Order,
        /// <summary>
        /// Conditional order
        /// </summary>
        [Map("StopOrder")]
        StopOrder
    }
}
