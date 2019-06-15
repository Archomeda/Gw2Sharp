using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/history")]
    public class CommerceTransactionsHistoryClient : BaseClient, ICommerceTransactionsHistoryClient
    {
        private readonly ICommerceTransactionsHistoryBuysClient buys;
        private readonly ICommerceTransactionsHistorySellsClient sells;

        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsHistoryClient"/> that is used for the API v2 commerce transactions history endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceTransactionsHistoryClient(IConnection connection) :
            base(connection)
        {
            this.buys = new CommerceTransactionsHistoryBuysClient(connection);
            this.sells = new CommerceTransactionsHistorySellsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistoryBuysClient Buys => this.buys;

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistorySellsClient Sells => this.sells;
    }
}
