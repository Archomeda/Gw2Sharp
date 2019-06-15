using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/current")]
    public class CommerceTransactionsCurrentClient : BaseClient, ICommerceTransactionsCurrentClient
    {
        private readonly ICommerceTransactionsCurrentBuysClient buys;
        private readonly ICommerceTransactionsCurrentSellsClient sells;

        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsCurrentClient"/> that is used for the API v2 commerce transactions current endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceTransactionsCurrentClient(IConnection connection) :
            base(connection)
        {
            this.buys = new CommerceTransactionsCurrentBuysClient(connection);
            this.sells = new CommerceTransactionsCurrentSellsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentBuysClient Buys => this.buys;

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentSellsClient Sells => this.sells;
    }
}
