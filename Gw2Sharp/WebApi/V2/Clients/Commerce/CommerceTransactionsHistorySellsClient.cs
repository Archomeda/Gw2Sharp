using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions History history endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/history/sells")]
    public class CommerceTransactionsHistorySellsClient : BaseEndpointPaginatedBlobClient<CommerceTransactionHistory>, ICommerceTransactionsHistorySellsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsHistorySellsClient"/> that is used for the API v2 commerce transactions History history endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal CommerceTransactionsHistorySellsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
