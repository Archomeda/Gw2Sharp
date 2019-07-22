using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account materials endpoint.
    /// </summary>
    [EndpointPath("account/materials")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountMaterialsClient : BaseEndpointBlobClient<IApiV2ObjectList<AccountMaterial>>, IAccountMaterialsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMaterialsClient"/> that is used for the API v2 account materials endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal AccountMaterialsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
