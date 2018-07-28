using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account materials endpoint.
    /// </summary>
    [EndpointPath("account/materials")]
    public class AccountMaterialsClient : BaseEndpointBlobClient<IReadOnlyList<AccountMaterial>>, IAccountMaterialsClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMaterialsClient"/> that is used for the API v2 account materials endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountMaterialsClient(IConnection connection) : base(connection) { }
    }
}
