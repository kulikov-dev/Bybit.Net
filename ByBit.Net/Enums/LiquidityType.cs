using CryptoExchange.Net.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Account type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum LiquidityType
    {
        /// <summary>
        /// Liquidity taker
        /// </summary>
        [Map("TAKER")]
        Taker,
        /// <summary>
        /// Liquidity maker
        /// </summary>
        [Map("MAKER")]
        Maker
    }
}
