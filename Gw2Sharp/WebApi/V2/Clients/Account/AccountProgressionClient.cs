using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account progression endpoint.
    /// </summary>
    [EndpointPath("account/progression")]
    [EndpointSchemaVersion("2021-09-28T00:00:00.000Z")]
    public class AccountProgressionClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountProgression>>, IAccountProgressionClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountProgressionClient"/> that is used for the API v2 account progression endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AccountProgressionClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
