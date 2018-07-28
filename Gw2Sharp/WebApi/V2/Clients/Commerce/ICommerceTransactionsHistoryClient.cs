
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions history endpoint.
    /// </summary>
    public interface ICommerceTransactionsHistoryClient : IClient
    {
        /// <summary>
        /// Gets the commerce transactions history buys client.
        /// </summary>
        ICommerceTransactionsHistoryBuysClient Buys { get; }

        /// <summary>
        /// Gets the commerce transactions history sells client.
        /// </summary>
        ICommerceTransactionsHistorySellsClient Sells { get; }
    }
}
