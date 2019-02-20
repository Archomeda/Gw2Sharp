using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/history")]
    public class CommerceTransactionsHistoryClient : BaseClient, ICommerceTransactionsHistoryClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsHistoryClient"/> that is used for the API v2 commerce transactions history endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceTransactionsHistoryClient(IConnection connection) :
            base(connection)
        {
            this.Buys = new CommerceTransactionsHistoryBuysClient(connection);
            this.Sells = new CommerceTransactionsHistorySellsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistoryBuysClient Buys { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceTransactionsHistorySellsClient Sells { get; protected set; }
    }
}
