using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 commerce listings endpoint.
    /// </summary>
    [EndpointPath("commerce/listings")]
    public class CommerceListingsClient : BaseEndpointBulkClient<CommerceListings, int>, ICommerceListingsClient
    {
        /// <summary>
        /// Creates a new <see cref="CommerceListingsClient"/> that is used for the API v2 commerce listings endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public CommerceListingsClient(IConnection connection) : base(connection) { }
    }
}
