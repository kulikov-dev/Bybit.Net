using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Contract type
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum ContractType
    {
        /// <summary>
        /// Future
        /// </summary>
        [Map("Future")]
        Future,
        /// <summary>
        /// Perpetual
        /// </summary>
        [Map("Perpetual")]
        Perpetual
    }
}
