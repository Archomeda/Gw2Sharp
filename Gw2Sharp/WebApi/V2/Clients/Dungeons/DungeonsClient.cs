using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 dungeons endpoint.
    /// </summary>
    [EndpointPath("dungeons")]
    public class DungeonsClient : BaseEndpointBulkAllClient<Dungeon, string>, IDungeonsClient
    {
        /// <summary>
        /// Creates a new <see cref="DungeonsClient"/> that is used for the API v2 dungeons endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public DungeonsClient(IConnection connection) : base(connection) { }
    }
}
