﻿using Bybit.Net.Enums;
using Bybit.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;

namespace Bybit.Net.Objects
{
    /// <summary>
    /// Options for the Bybit client
    /// </summary>
    public class BybitClientOptions : ClientOptions
    {
        /// <summary>
        /// Default options for the Bybit client
        /// </summary>
        public static BybitClientOptions Default { get; set; } = new BybitClientOptions();

        /// <summary>
        /// A referer, will be sent in the x-referer header
        /// </summary>
        public string? Referer { get; set; } = "JKorf";

        /// <summary>
        /// The default receive window for requests
        /// </summary>
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        private RestApiClientOptions _inverseFuturesApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.InverseFuturesRestClientAddress);
        /// <summary>
        /// Inverse futures API options
        /// </summary>
        public RestApiClientOptions InverseFuturesApiOptions
        {
            get => _inverseFuturesApiOptions;
            set => _inverseFuturesApiOptions = new RestApiClientOptions(_inverseFuturesApiOptions, value);
        }

        private RestApiClientOptions _inversePerpetualApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.InversePerpetualRestClientAddress);
        /// <summary>
        /// Inverse perpetual API options
        /// </summary>
        public RestApiClientOptions InversePerpetualApiOptions
        {
            get => _inversePerpetualApiOptions;
            set => _inversePerpetualApiOptions = new RestApiClientOptions(_inversePerpetualApiOptions, value);
        }

        private RestApiClientOptions _usdPerpetualApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.UsdPerpetualRestClientAddress);
        /// <summary>
        /// Usd perpetual API options
        /// </summary>
        public RestApiClientOptions UsdPerpetualApiOptions
        {
            get => _usdPerpetualApiOptions;
            set => _usdPerpetualApiOptions = new RestApiClientOptions(_usdPerpetualApiOptions, value);
        }

        private RestApiClientOptions _spotApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.SpotRestClientAddress);
        /// <summary>
        /// Spot API options
        /// </summary>
        public RestApiClientOptions SpotApiOptions
        {
            get => _spotApiOptions;
            set => _spotApiOptions = new RestApiClientOptions(_spotApiOptions, value);
        }

        private RestApiClientOptions _copyTradingApiOptions = new RestApiClientOptions(BybitApiAddresses.Default.SpotRestClientAddress);
        /// <summary>
        /// Copy trading API options
        /// </summary>
        public RestApiClientOptions CopyTradingApiOptions
        {
            get => _copyTradingApiOptions;
            set => _copyTradingApiOptions = new RestApiClientOptions(_copyTradingApiOptions, value);
        }

        private RestApiClientOptions _unifiedMarginApiOptions = new RestApiClientOptions(BybitApiAddresses.TestNet.UnifiedMarginRestClientAddress);     //TODO genki don't forget to remove
        /// <summary>
        /// Unified margin API options
        /// </summary>
        public RestApiClientOptions UnifiedMarginApiOptions
        {
            get => _unifiedMarginApiOptions;
            set => _unifiedMarginApiOptions = new RestApiClientOptions(_unifiedMarginApiOptions, value);
        }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitClientOptions() : this(Default)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn">Base the new options on other options</param>
        internal BybitClientOptions(BybitClientOptions baseOn) : base(baseOn)
        {
            if (baseOn == null)
                return;

            ReceiveWindow = baseOn.ReceiveWindow;
            Referer = baseOn.Referer;

            InverseFuturesApiOptions = new RestApiClientOptions(baseOn.InverseFuturesApiOptions, null);
            InversePerpetualApiOptions = new RestApiClientOptions(baseOn.InversePerpetualApiOptions, null);
            SpotApiOptions = new RestApiClientOptions(baseOn.SpotApiOptions, null);
            UsdPerpetualApiOptions = new RestApiClientOptions(baseOn.UsdPerpetualApiOptions, null);
        }
    }

    /// <summary>
    /// Options for the futures socket client
    /// </summary>
    public class BybitSocketClientOptions : ClientOptions
    {
        /// <summary>
        /// Default options for the futures socket client
        /// </summary>
        public static BybitSocketClientOptions Default { get; set; } = new BybitSocketClientOptions();

        private BybitSocketApiClientOptions _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InverseFuturesSocketClientAddress, BybitApiAddresses.Default.InverseFuturesSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Inverse futures streams options
        /// </summary>
        public BybitSocketApiClientOptions InverseFuturesStreamsOptions
        {
            get => _inverseFuturesStreamsOptions;
            set => _inverseFuturesStreamsOptions = new BybitSocketApiClientOptions(_inverseFuturesStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.InversePerpetualSocketClientAddress, BybitApiAddresses.Default.InversePerpetualSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Inverse perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions InversePerpetualStreamsOptions
        {
            get => _inversePerpetualStreamsOptions;
            set => _inversePerpetualStreamsOptions = new BybitSocketApiClientOptions(_inversePerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.UsdPerpetualPublicSocketClientAddress, BybitApiAddresses.Default.UsdPerpetualPrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Usd perpetual streams options
        /// </summary>
        public BybitSocketApiClientOptions UsdPerpetualStreamsOptions
        {
            get => _usdPerpetualStreamsOptions;
            set => _usdPerpetualStreamsOptions = new BybitSocketApiClientOptions(_usdPerpetualStreamsOptions, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV1Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV1ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV1ClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 1
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV1Options
        {
            get => _spotStreamsV1Options;
            set => _spotStreamsV1Options = new BybitSocketApiClientOptions(_spotStreamsV1Options, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV2Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV2ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV1ClientAddress)
        {

            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 2
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV2Options
        {
            get => _spotStreamsV2Options;
            set => _spotStreamsV2Options = new BybitSocketApiClientOptions(_spotStreamsV2Options, value);
        }

        private BybitSocketApiClientOptions _spotStreamsV3Options = new BybitSocketApiClientOptions(BybitApiAddresses.Default.SpotPublicSocketV3ClientAddress, BybitApiAddresses.Default.SpotPrivateSocketV3ClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Spot streams options version 2
        /// </summary>
        public BybitSocketApiClientOptions SpotStreamsV3Options
        {
            get => _spotStreamsV3Options;
            set => _spotStreamsV3Options = new BybitSocketApiClientOptions(_spotStreamsV3Options, value);
        }

        private BybitSocketApiClientOptions _copyTradingStreamsOptions = new BybitSocketApiClientOptions(BybitApiAddresses.Default.CopyTradingSocketClientAddress, BybitApiAddresses.Default.CopyTradingSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Copy trading streams options
        /// </summary>
        public BybitSocketApiClientOptions CopyTradingStreamsOptions
        {
            get => _copyTradingStreamsOptions;
            set => _copyTradingStreamsOptions = new BybitSocketApiClientOptions(_copyTradingStreamsOptions, value);
        }

        private BybitUnifiedMarginSocketApiClientOptions _unifiedMarginStreamsOptions = new BybitUnifiedMarginSocketApiClientOptions(
                                                                                                BybitApiAddresses.Default.UnifiedMarginPublicUSDTContractSocketClientAddress,
                                                                                                BybitApiAddresses.Default.UnifiedMarginPublicUSDCContractSocketClientAddress,
                                                                                                BybitApiAddresses.Default.UnifiedMarginPublicUSDCOptionSocketClientAddress,
                                                                                                BybitApiAddresses.Default.UnifiedMarginPrivateSocketClientAddress)
        {
            SocketSubscriptionsCombineTarget = 10,
            PingInterval = TimeSpan.FromSeconds(20)
        };

        /// <summary>
        /// Unified margin streams options
        /// </summary>
        public BybitUnifiedMarginSocketApiClientOptions UnifiedMarginStreamsOptions
        {
            get => _unifiedMarginStreamsOptions;
            set => _unifiedMarginStreamsOptions = new BybitUnifiedMarginSocketApiClientOptions(_unifiedMarginStreamsOptions, value);
        }

        /// <summary>
        /// ctor
        /// </summary>
        public BybitSocketClientOptions() : this(Default)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn">Base the new options on other options</param>
        internal BybitSocketClientOptions(BybitSocketClientOptions baseOn) : base(baseOn)
        {
            if (baseOn == null)
                return;

            InverseFuturesStreamsOptions = new BybitSocketApiClientOptions(baseOn.InverseFuturesStreamsOptions, null);
            InversePerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.InversePerpetualStreamsOptions, null);
            SpotStreamsV1Options = new BybitSocketApiClientOptions(baseOn.SpotStreamsV1Options, null);
            SpotStreamsV2Options = new BybitSocketApiClientOptions(baseOn.SpotStreamsV2Options, null);
            UsdPerpetualStreamsOptions = new BybitSocketApiClientOptions(baseOn.UsdPerpetualStreamsOptions, null);
            UnifiedMarginStreamsOptions = new BybitUnifiedMarginSocketApiClientOptions(baseOn.UnifiedMarginStreamsOptions, null);
        }
    }

    /// <summary>
    /// Bybit socket API client options
    /// </summary>
    public class BybitSocketApiClientOptions : SocketApiClientOptions
    {
        /// <summary>
        /// The base address for the authenticated websocket
        /// </summary>
        public string BaseAddressAuthenticated { get; set; }

        /// <summary>
        /// Interval at which to send a ping to the server
        /// </summary>
        public TimeSpan PingInterval { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
#pragma warning disable 8618
        public BybitSocketApiClientOptions()
        {
        }
#pragma warning restore

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseOn"></param>
        /// <param name="newValues"></param>
        internal BybitSocketApiClientOptions(BybitSocketApiClientOptions baseOn, BybitSocketApiClientOptions? newValues) : base(baseOn, newValues)
        {
            PingInterval = newValues?.PingInterval ?? baseOn.PingInterval;
            BaseAddressAuthenticated = newValues?.BaseAddressAuthenticated ?? baseOn.BaseAddressAuthenticated;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="baseAddressAuthenticated"></param>
        internal BybitSocketApiClientOptions(string baseAddress, string baseAddressAuthenticated) : base(baseAddress)
        {
            BaseAddressAuthenticated = baseAddressAuthenticated;
        }
    }

    /// <summary>
    /// Socket options for UnifiedMargin account
    /// </summary>
    public class BybitUnifiedMarginSocketApiClientOptions : BybitSocketApiClientOptions
    {
        private Dictionary<StreamCategory, string> PublicBaseAddresses { get; set; }

        internal BybitUnifiedMarginSocketApiClientOptions(BybitUnifiedMarginSocketApiClientOptions baseOn, BybitUnifiedMarginSocketApiClientOptions? newValues) : base(baseOn, newValues)
        {
            PublicBaseAddresses.Clear();

            foreach (var item in newValues.PublicBaseAddresses)
            {
                PublicBaseAddresses.Add(item.Key, item.Value);
            }
        }

        internal BybitUnifiedMarginSocketApiClientOptions(string baseUSDTAddress, string baseUSDCAddress, string baseUSDCOptionAddress, string baseAddressAuthenticated)
        {
            PublicBaseAddresses = new Dictionary<StreamCategory, string>();

            PublicBaseAddresses.Add(StreamCategory.USDTPerp, baseUSDTAddress);
            PublicBaseAddresses.Add(StreamCategory.USDCPerp, baseUSDCAddress);
            PublicBaseAddresses.Add(StreamCategory.USDCOption, baseUSDCOptionAddress);
        }

        internal string GetPublicAddress(StreamCategory category)
        {
            if (!PublicBaseAddresses.ContainsKey(category))
            {
                throw new NotSupportedException("Public stream for this StreamCategory not found.");
            }

            return PublicBaseAddresses[category];
        }
    }

    /// <summary>
    /// Options for the futures symbol order book
    /// </summary>
    public class BybitSymbolOrderBookOptions : OrderBookOptions
    {
        /// <summary>
        /// After how much time we should consider the connection dropped if no data is received for this time after the initial subscriptions
        /// </summary>
        public TimeSpan? InitialDataTimeout { get; set; }
        /// <summary>
        /// The client to use for the socket connection. When using the same client for multiple order books the connection can be shared.
        /// </summary>
        public IBybitSocketClient? SocketClient { get; set; }

        /// <summary>
        /// The limit of entries in the order book, either 25 or 200
        /// </summary>
        public int? Limit { get; set; }
    }
}
