using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account recipes endpoint.
    /// </summary>
    [EndpointPath("account/recipes")]
    public class AccountRecipesClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountRecipesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountRecipesClient"/> that is used for the API v2 account recipes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountRecipesClient(IConnection connection) : base(connection) { }
    }
}
