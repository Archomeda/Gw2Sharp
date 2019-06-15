using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce endpoint.
    /// </summary>
    [EndpointPath("commerce")]
    public class CommerceClient : BaseClient, ICommerceClient
    {
        private readonly ICommerceDeliveryClient delivery;
        private readonly ICommerceExchangeClient exchange;
        private readonly ICommerceListingsClient listings;
        private readonly ICommercePricesClient prices;
        private readonly ICommerceTransactionsClient transactions;

        /// <summary>
        /// Creates a new <see cref="CommerceClient"/> that is used for the API v2 commerce endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceClient(IConnection connection) :
            base(connection)
        {
            this.delivery = new CommerceDeliveryClient(connection);
            this.exchange = new CommerceExchangeClient(connection);
            this.listings = new CommerceListingsClient(connection);
            this.prices = new CommercePricesClient(connection);
            this.transactions = new CommerceTransactionsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceDeliveryClient Delivery => this.delivery;

        /// <inheritdoc />
        public virtual ICommerceExchangeClient Exchange => this.exchange;

        /// <inheritdoc />
        public virtual ICommerceListingsClient Listings => this.listings;

        /// <inheritdoc />
        public virtual ICommercePricesClient Prices => this.prices;

        /// <inheritdoc />
        public virtual ICommerceTransactionsClient Transactions => this.transactions;
    }
}
