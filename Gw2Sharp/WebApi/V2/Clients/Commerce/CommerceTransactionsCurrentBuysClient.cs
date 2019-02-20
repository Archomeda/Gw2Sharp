using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current buys endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/current/buys")]
    public class CommerceTransactionsCurrentBuysClient : BaseEndpointPaginatedBlobClient<CommerceTransactionCurrent>, ICommerceTransactionsCurrentBuysClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsCurrentBuysClient"/> that is used for the API v2 commerce transactions current buys endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceTransactionsCurrentBuysClient(IConnection connection) :
            base(connection)
        { }
    }
}
