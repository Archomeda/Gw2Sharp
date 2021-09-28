using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/history")]
    public class CommerceTransactionsHistoryClient : Gw2WebApiBaseClient, ICommerceTransactionsHistoryClient
    {
        private readonly ICommerceTransactionsHistoryBuysClient buys;
        private readonly ICommerceTransactionsHistorySellsClient sells;

        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsHistoryClient"/> that is used for the API v2 commerce transactions history endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal CommerceTransactionsHistoryClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.buys = new CommerceTransactionsHistoryBuysClient(connection, gw2Client);
            this.sells = new CommerceTransactionsHistorySellsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistoryBuysClient Buys => this.buys;

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistorySellsClient Sells => this.sells;
    }
}
