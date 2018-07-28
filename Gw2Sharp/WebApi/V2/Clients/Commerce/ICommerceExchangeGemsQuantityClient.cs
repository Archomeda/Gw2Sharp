
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems with quantity endpoint.
    /// </summary>
    public interface ICommerceExchangeGemsQuantityClient :
        IBlobClient<CommerceExchangeGems>
    {
        /// <summary>
        /// The amount of gems to exchange.
        /// </summary>
        int Quantity { get; }
    }
}
