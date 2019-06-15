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
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CommerceExchangeClient(IConnection connection) :
            base(connection)
        {
            this.coins = new CommerceExchangeCoinsClient(connection);
            this.gems = new CommerceExchangeGemsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceExchangeCoinsClient Coins => this.coins;

        /// <inheritdoc />
        public virtual ICommerceExchangeGemsClient Gems => this.gems;
    }
}
