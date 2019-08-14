using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange coins endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/coins")]
    public class CommerceExchangeCoinsClient : BaseClient, ICommerceExchangeCoinsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeCoinsClient"/> that is used for the API v2 commerce exchange coins endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal CommerceExchangeCoinsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <inheritdoc />
        public ICommerceExchangeCoinsQuantityClient Quantity(int quantity) => new CommerceExchangeCoinsQuantityClient(this.Connection, this.Gw2Client!, quantity);
    }
}
