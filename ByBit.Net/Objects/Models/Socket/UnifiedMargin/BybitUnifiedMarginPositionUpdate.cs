using Bybit.Net.Converters;
using Bybit.Net.Enums;
using CryptoExchange.Net.Converters;
using Newtonsoft.Json;
using System;

namespace Bybit.Net.Objects.Models.Socket.UnifiedMargin
{
    /// <summary>
    /// Position update
    /// </summary>
    public class BybitUnifiedMarginPositionUpdate
    {
        /// <summary>
        /// Position mode
        /// </summary>
        [JsonProperty("positionIdx"), JsonConverter(typeof(PositionModeConverter))]
        public PositionMode PositionMode { get; set; }

        /// <summary>
        /// Risk id
        /// </summary>
        public long RiskId { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Side
        /// </summary>
        [JsonConverter(typeof(PositionSideConverter))]
        public PositionSide Side { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Average entry price
        /// </summary>
        public decimal EntryPrice { get; set; }

        /// <summary>
        /// Settlement price, for USDC only
        /// </summary>
        [JsonProperty("sessionAvgPrice")]
        public decimal SettlementPrice { get; set; }

        /// <summary>
        /// Under the isolated margin mode, the value should be the leverage set by the user. Under the cross margin mode, the value should be the maximum leverage under the current risk limit. For contracts only, and not for options
        /// </summary>
        public decimal Leverage { get; set; }

        /// <summary>
        /// Position margin
        /// </summary>
        public decimal PositionMargin { get; set; }

        /// <summary>
        /// Mark price
        /// </summary>
        public decimal MarkPrice { get; set; }

        /// <summary>
        /// Take profit price
        /// </summary>
        public decimal TakeProfit { get; set; }
        /// <summary>
        /// Stop loss price
        /// </summary>
        public decimal StopLoss { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public decimal PositionValue { get; set; }

        /// <summary>
        /// Session UPL, for USDC only
        /// </summary>
        public decimal SessionUPL { get; set; }

        /// <summary>
        /// Session RPL, for USDC only
        /// </summary>
        public decimal SessionRPL { get; set; }

        /// <summary>
        /// Position Initial margin
        /// </summary>
        [JsonProperty("positionIM")]
        public decimal InitialMargin { get; set; }

        /// <summary>
        /// Position Maintenance margin
        /// </summary>
        [JsonProperty("positionMM")]
        public decimal MaintenanceMargin { get; set; }

        /// <summary>
        /// Trailing stop
        /// </summary>
        public decimal TrailingStop { get; set; }

        /// <summary>
        /// Unrealized P&L
        /// </summary>
        public decimal UnrealizedPnl { get; set; }

        /// <summary>
        /// Accumulated realized pnl (all-time total)
        /// </summary>
        [JsonProperty("cumRealisedPnl")]
        public decimal TotalRealizedPnl { get; set; }

        /// <summary>
        /// Creation time of the order
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("createdTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Last update time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updatedTime")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Is isolated
        /// </summary>
        public bool IsIsolated { get; set; }

        /// <summary>
        /// Stop loss and take profit mode
        /// </summary>
        [JsonProperty("tpslMode"), JsonConverter(typeof(StopLossTakeProfitModeConverter))]
        public StopLossTakeProfitMode StopMode { get; set; }
    }
}
