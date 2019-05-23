using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account minis endpoint.
    /// </summary>
    [EndpointPath("account/minis")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountMinisClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountMinisClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountMinisClient"/> that is used for the API v2 account minis endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountMinisClient(IConnection connection) :
            base(connection)
        { }
    }
}
