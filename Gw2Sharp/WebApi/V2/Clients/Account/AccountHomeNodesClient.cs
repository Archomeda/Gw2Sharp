using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home nodes endpoint.
    /// </summary>
    [EndpointPath("account/home/nodes")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountHomeNodesClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IAccountHomeNodesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountHomeNodesClient"/> that is used for the API v2 account home nodes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal AccountHomeNodesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
