
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins with quantity endpoint.
    /// </summary>
    public interface ICommerceExchangeCoinsQuantityClient :
        IBlobClient<CommerceExchangeCoins>
    {
        /// <summary>
        /// The amount of coins to exchange.
        /// </summary>
        int Quantity { get; }
    }
}
