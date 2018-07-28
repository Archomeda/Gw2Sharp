using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 build endpoint.
    /// </summary>
    [EndpointPath("build")]
    public class BuildClient : BaseEndpointBlobClient<Build>, IBuildClient
    {
        /// <summary>
        /// Creates a new <see cref="BuildClient"/> that is used for the API v2 build endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public BuildClient(IConnection connection) : base(connection) { }
    }
}
