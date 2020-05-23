namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce endpoint.
    /// </summary>
    public interface ICommerceClient
    {
        /// <summary>
        /// Gets the commerce delivery.
        /// Requires scopes: account, tradingpost.
        /// </summary>
        ICommerceDeliveryClient Delivery { get; }

        /// <summary>
        /// Gets the commerce exchange.
        /// </summary>
        ICommerceExchangeClient Exchange { get; }

        /// <summary>
        /// Gets the commerce listings.
        /// </summary>
        ICommerceListingsClient Listings { get; }

        /// <summary>
        /// Gets the commerce prices.
        /// </summary>
        ICommercePricesClient Prices { get; }

        /// <summary>
        /// Gets the commerce transactions.
        /// Requires scopes: account, tradingpost.
        /// </summary>
        ICommerceTransactionsClient Transactions { get; }
    }
}
