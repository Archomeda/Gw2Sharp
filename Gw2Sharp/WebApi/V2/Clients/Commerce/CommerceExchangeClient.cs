using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange")]
    public class CommerceExchangeClient : BaseClient, ICommerceExchangeClient
    {
        private readonly ICommerceExchangeCoinsClient coins;
        private readonly ICommerceExchangeGemsClient gems;

        /// <summary>
        /// Creates a new <see cref="CommerceExchangeClient"/> that is used for the API v2 commerce exchange endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal CommerceExchangeClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.coins = new CommerceExchangeCoinsClient(connection, gw2Client);
            this.gems = new CommerceExchangeGemsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual ICommerceExchangeCoinsClient Coins => this.coins;

        /// <inheritdoc />
        public virtual ICommerceExchangeGemsClient Gems => this.gems;
    }
}
