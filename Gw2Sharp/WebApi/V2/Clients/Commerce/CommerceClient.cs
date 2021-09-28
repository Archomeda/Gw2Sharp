using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce endpoint.
    /// </summary>
    [EndpointPath("commerce")]
    public class CommerceClient : Gw2WebApiBaseClient, ICommerceClient
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
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal CommerceClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.delivery = new CommerceDeliveryClient(connection, gw2Client);
            this.exchange = new CommerceExchangeClient(connection, gw2Client);
            this.listings = new CommerceListingsClient(connection, gw2Client);
            this.prices = new CommercePricesClient(connection, gw2Client);
            this.transactions = new CommerceTransactionsClient(connection, gw2Client);
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
