using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem backgrounds endpoint.
    /// </summary>
    [EndpointPath("emblem/backgrounds")]
    public class EmblemBackgroundsClient : BaseEndpointBulkAllClient<Emblem, int>, IEmblemBackgroundsClient
    {
        /// <summary>
        /// Creates a new <see cref="EmblemBackgroundsClient"/> that is used for the API v2 emblem backgrounds endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public EmblemBackgroundsClient(IConnection connection) : base(connection) { }
    }
}
