using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce endpoint.
    /// </summary>
    [EndpointPath("commerce")]
    public class CommerceClient : BaseClient, ICommerceClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceClient"/> that is used for the API v2 commerce endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceClient(IConnection connection) :
            base(connection)
        {
            this.Delivery = new CommerceDeliveryClient(connection);
            this.Exchange = new CommerceExchangeClient(connection);
            this.Listings = new CommerceListingsClient(connection);
            this.Prices = new CommercePricesClient(connection);
            this.Transactions = new CommerceTransactionsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceDeliveryClient Delivery { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceExchangeClient Exchange { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceListingsClient Listings { get; protected set; }

        /// <inheritdoc />
        public virtual ICommercePricesClient Prices { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceTransactionsClient Transactions { get; protected set; }
    }
}
