using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mounts types endpoint.
    /// </summary>
    [EndpointPath("mounts/types")]
    public class MountsTypesClient : BaseEndpointBulkAllClient<MountType, string>, IMountsTypesClient
    {
        /// <summary>
        /// Creates a new <see cref="MountsTypesClient"/> that is used for the API v2 mounts types endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal MountsTypesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
