using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 masteries endpoint.
    /// </summary>
    [EndpointPath("masteries")]
    public class MasteriesClient : BaseEndpointBulkAllClient<Mastery, int>, IMasteriesClient
    {
        /// <summary>
        /// Creates a new <see cref="MasteriesClient"/> that is used for the API v2 masteries endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal MasteriesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
