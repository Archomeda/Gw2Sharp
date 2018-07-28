using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current sells endpoint.
    /// </summary>
    [EndpointPath("commerce/transactions/current/sells")]
    public class CommerceTransactionsCurrentSellsClient : BaseEndpointPaginatedBlobClient<CommerceTransactionCurrent>, ICommerceTransactionsCurrentSellsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceTransactionsCurrentSellsClient"/> that is used for the API v2 commerce transactions current sells endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CommerceTransactionsCurrentSellsClient(IConnection connection) : base(connection) { }
    }
}
