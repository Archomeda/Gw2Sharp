using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins with quantity endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/coins")]
    public class CommerceExchangeCoinsQuantityClient : BaseEndpointBlobClient<CommerceExchangeCoins>, ICommerceExchangeCoinsQuantityClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeCoinsQuantityClient"/> that is used for the API v2 commerce exchange coins with quantity endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="quantity">The amount of coins to exchange.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceExchangeCoinsQuantityClient(IConnection connection, int quantity) :
            base(connection)
        {
            this.Quantity = quantity;
        }

        /// <inheritdoc />
        [EndpointPathParameter("quantity")]
        public virtual int Quantity { get; protected set; }
    }
}
