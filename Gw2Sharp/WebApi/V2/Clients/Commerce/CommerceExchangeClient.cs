namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange")]
    public class CommerceExchangeClient : BaseClient, ICommerceExchangeClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeClient"/> that is used for the API v2 commerce exchange endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CommerceExchangeClient(IConnection connection) : base(connection)
        {
            this.Coins = new CommerceExchangeCoinsClient(connection);
            this.Gems = new CommerceExchangeGemsClient(connection);
        }

        /// <inheritdoc />
        public virtual ICommerceExchangeCoinsClient Coins { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceExchangeGemsClient Gems { get; protected set; }
    }
}
