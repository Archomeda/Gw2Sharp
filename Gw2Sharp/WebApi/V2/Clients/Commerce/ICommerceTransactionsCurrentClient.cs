
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce transactions current endpoint.
    /// </summary>
    public interface ICommerceTransactionsCurrentClient : IClient
    {
        /// <summary>
        /// Gets the commerce transactions current buys client.
        /// </summary>
        ICommerceTransactionsCurrentBuysClient Buys { get; }

        /// <summary>
        /// Gets the commerce transactions current sells client.
        /// </summary>
        ICommerceTransactionsCurrentSellsClient Sells { get; }
    }
}
