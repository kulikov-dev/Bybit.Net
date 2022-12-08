using System;
using System.Collections.Generic;
using System.Text;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Stream category of Symbol to subscribe for Unified Margin public streams
    /// </summary>
    /// <remarks> In Bybit, for now, BTCPERP is USDC perp, BTCUSDT is usdt perp, And BTC-10DEC22-20000-C is option.</remarks>
    public enum StreamCategory
    {
        /// <summary>
        /// USDT perpetual
        /// </summary>
        USDTPerp,
        /// <summary>
        /// USDC perpetual
        /// </summary>
        USDCPerp,
        /// <summary>
        /// USDC option
        /// </summary>
        USDCOption
    }
}
