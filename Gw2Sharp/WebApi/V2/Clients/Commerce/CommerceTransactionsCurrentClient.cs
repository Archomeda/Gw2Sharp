using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/current")]
    public class CommerceTransactionsCurrentClient : Gw2WebApiBaseClient, ICommerceTransactionsCurrentClient
    {
        private readonly ICommerceTransactionsCurrentBuysClient buys;
        private readonly ICommerceTransactionsCurrentSellsClient sells;

        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsCurrentClient"/> that is used for the API v2 commerce transactions current endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal CommerceTransactionsCurrentClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.buys = new CommerceTransactionsCurrentBuysClient(connection, gw2Client);
            this.sells = new CommerceTransactionsCurrentSellsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentBuysClient Buys => this.buys;

        /// <inheritdoc />
        public virtual ICommerceTransactionsCurrentSellsClient Sells => this.sells;
    }
}
