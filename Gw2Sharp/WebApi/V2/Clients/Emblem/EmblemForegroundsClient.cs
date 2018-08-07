using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 emblem foregrounds endpoint.
    /// </summary>
    [EndpointPath("emblem/foregrounds")]
    public class EmblemForegroundsClient : BaseEndpointBulkAllClient<Emblem, int>, IEmblemForegroundsClient
    {
        /// <summary>
        /// Creates a new <see cref="EmblemForegroundsClient"/> that is used for the API v2 emblem foregrounds endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public EmblemForegroundsClient(IConnection connection) : base(connection) { }
    }
}
