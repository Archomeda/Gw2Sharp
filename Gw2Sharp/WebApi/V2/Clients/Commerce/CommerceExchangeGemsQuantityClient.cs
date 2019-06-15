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
        /// <param name="quantity">The amount of gems to exchange.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceExchangeGemsQuantityClient(IConnection connection, int quantity) :
            base(connection)
        {
            this.quantity = quantity;
        }

        /// <inheritdoc />
        [EndpointPathParameter("quantity")]
        public virtual int Quantity => this.quantity;
    }
}
