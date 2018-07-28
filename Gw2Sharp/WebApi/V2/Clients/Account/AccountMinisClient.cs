using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account minis endpoint.
    /// </summary>
    [EndpointPath("account/minis")]
    public class AccountMinisClient : BaseEndpointBlobClient<IReadOnlyList<int>>, IAccountMinisClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMinisClient"/> that is used for the API v2 account minis endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AccountMinisClient(IConnection connection) : base(connection) { }
    }
}
