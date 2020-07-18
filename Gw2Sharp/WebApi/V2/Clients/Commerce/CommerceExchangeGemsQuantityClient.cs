using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems with quantity endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/gems")]
    public class CommerceExchangeGemsQuantityClient : BaseEndpointBlobClient<CommerceExchangeGems>, ICommerceExchangeGemsQuantityClient
    {
        private readonly int quantity;

        /// <summary>
        /// Creates a new <see cref="CommerceExchangeGemsQuantityClient"/> that is used for the API v2 commerce exchange gems with quantity endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="quantity">The amount of gems to exchange.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        public CommerceExchangeGemsQuantityClient(IConnection connection, IGw2Client gw2Client, int quantity) :
            base(connection, gw2Client)
        {
            this.quantity = quantity;
        }

        /// <inheritdoc />
        [EndpointQueryParameter("quantity")]
        public virtual int Quantity => this.quantity;
    }
}
