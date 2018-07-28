
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions endpoint.
    /// </summary>
    public interface ICommerceTransactionsClient : IClient
    {
        /// <summary>
        /// Gets the commerce transactions current client.
        /// </summary>
        ICommerceTransactionsCurrentClient Current { get; }

        /// <summary>
        /// Gets the commerce transactions history client.
        /// </summary>
        ICommerceTransactionsHistoryClient History { get; }
    }
}
