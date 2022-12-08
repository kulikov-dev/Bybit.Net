namespace Bybit.Net.Objects
{
    /// <summary>
    /// Api addresses usable for the Bybit clients
    /// </summary>
    public class BybitApiAddresses
    {
        /// <summary>
        /// The address used by the BybitClient for the Spot rest API
        /// </summary>
        public string SpotRestClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Copy Trading rest API
        /// </summary>
        public string CopyTradingRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API v1
        /// </summary>
        public string SpotPublicSocketV1ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API v2
        /// </summary>
        public string SpotPublicSocketV2ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public Spot socket API v3
        /// </summary>
        public string SpotPublicSocketV3ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Spot socket API v1
        /// </summary>
        public string SpotPrivateSocketV1ClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private Spot socket API v3
        /// </summary>
        public string SpotPrivateSocketV3ClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the USD perpetual rest API
        /// </summary>
        public string UsdPerpetualRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the public USD perpetual socket API
        /// </summary>
        public string UsdPerpetualPublicSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketclient for the private USD perpetual socket API 
        /// </summary>
        public string UsdPerpetualPrivateSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Inverse perpetual rest API
        /// </summary>
        public string InversePerpetualRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse perpetual socket API
        /// </summary>
        public string InversePerpetualSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Inverse futures rest API
        /// </summary>
        public string InverseFuturesRestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Inverse futures socket API
        /// </summary>
        public string InverseFuturesSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the Copy trading socket API
        /// </summary>
        public string CopyTradingSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitSocketClient for the public Unified margin socket API
        /// </summary>
        public string UnifiedMarginPrivateSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private USDT contract Unified margin socket API
        /// </summary>
        public string UnifiedMarginPublicUSDTContractSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private USDC contract Unified margin socket API
        /// </summary>
        public string UnifiedMarginPublicUSDCContractSocketClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the BybitSocketClient for the private USDC option Unified margin socket API
        /// </summary>
        public string UnifiedMarginPublicUSDCOptionSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the BybitClient for the Unified margin rest API
        /// </summary>
        public string UnifiedMarginRestClientAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the Bybit.com API
        /// </summary>
        public static BybitApiAddresses Default = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api.bybit.com",
            SpotPublicSocketV1ClientAddress = "wss://stream.bybit.com/spot/quote/ws/v1",
            SpotPublicSocketV2ClientAddress = "wss://stream.bybit.com/spot/quote/ws/v2",
            SpotPublicSocketV3ClientAddress = "wss://stream.bybit.com/spot/public/v3",
            SpotPrivateSocketV1ClientAddress = "wss://stream.bybit.com/spot/ws",
            SpotPrivateSocketV3ClientAddress = "wss://stream.bybit.com/spot/private/v3",
            UsdPerpetualRestClientAddress = "https://api.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream.bybit.com/realtime",
            CopyTradingRestClientAddress = "https://api.bybit.com",
            CopyTradingSocketClientAddress = "wss://stream.bybit.com/realtime_private",
            UnifiedMarginRestClientAddress = "https://api.bybit.com",
            UnifiedMarginPrivateSocketClientAddress = "wss://stream.bybit.com/unified/private/v3",
            UnifiedMarginPublicUSDTContractSocketClientAddress = "wss://stream.bybit.com/contract/usdt/public/v3",
            UnifiedMarginPublicUSDCContractSocketClientAddress = "wss://stream.bybit.com/contract/usdc/public/v3",
            UnifiedMarginPublicUSDCOptionSocketClientAddress = "wss://stream.bybit.com/option/usdc/public/v3"
        };

        /// <summary>
        /// The addresses to connect to the Bybit testnet
        /// </summary>
        public static BybitApiAddresses TestNet = new BybitApiAddresses
        {
            SpotRestClientAddress = "https://api-testnet.bybit.com",
            SpotPublicSocketV1ClientAddress = "wss://stream-testnet.bybit.com/spot/quote/ws/v1",
            SpotPublicSocketV2ClientAddress = "wss://stream-testnet.bybit.com/spot/quote/ws/v2",
            SpotPublicSocketV3ClientAddress = "wss://stream-testnet.bybit.com/spot/public/v3",
            SpotPrivateSocketV1ClientAddress = "wss://stream-testnet.bybit.com/spot/ws",
            SpotPrivateSocketV3ClientAddress = "wss://stream-testnet.bybit.com/spot/private/v3",
            UsdPerpetualRestClientAddress = "https://api-testnet.bybit.com",
            UsdPerpetualPublicSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_public",
            UsdPerpetualPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/realtime_private",
            InversePerpetualRestClientAddress = "https://api-testnet.bybit.com",
            InversePerpetualSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
            InverseFuturesRestClientAddress = "https://api-testnet.bybit.com",
            InverseFuturesSocketClientAddress = "wss://stream-testnet.bybit.com/realtime",
            UnifiedMarginRestClientAddress = "https://api-testnet.bybit.com",
            UnifiedMarginPrivateSocketClientAddress = "wss://stream-testnet.bybit.com/unified/private/v3",
            UnifiedMarginPublicUSDTContractSocketClientAddress = "wss://stream-testnet.bybit.com/contract/usdt/public/v3",
            UnifiedMarginPublicUSDCContractSocketClientAddress = "wss://stream-testnet.bybit.com/contract/usdc/public/v3",
            UnifiedMarginPublicUSDCOptionSocketClientAddress = "wss://stream-testnet.bybit.com/option/usdc/public/v3"
        };
    }
}
