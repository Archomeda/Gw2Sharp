using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce exchange gems endpoint.
    /// </summary>
    [EndpointPath("commerce/exchange/gems")]
    public class CommerceExchangeGemsClient : BaseEndpointBlobClient<CommerceExchangeGems>, ICommerceExchangeGemsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceExchangeGemsClient"/> that is used for the API v2 commerce exchange gems endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CommerceExchangeGemsClient(IConnection connection) : base(connection) { }

        /// <inheritdoc />
        public ICommerceExchangeGemsQuantityClient this[int quantity] => new CommerceExchangeGemsQuantityClient(this.Connection, quantity);
    }
}
