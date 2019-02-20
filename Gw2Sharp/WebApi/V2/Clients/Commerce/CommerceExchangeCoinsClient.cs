using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/coins")]
    public class CommerceExchangeCoinsClient : BaseEndpointBlobClient<CommerceExchangeCoins>, ICommerceExchangeCoinsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeCoinsClient"/> that is used for the API v2 commerce exchange coins endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceExchangeCoinsClient(IConnection connection) :
            base(connection)
        { }

        /// <inheritdoc />
        public ICommerceExchangeCoinsQuantityClient Quantity(int quantity) => new CommerceExchangeCoinsQuantityClient(this.Connection, quantity);
    }
}
