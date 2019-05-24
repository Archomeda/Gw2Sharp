using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account worldbosses endpoint.
    /// </summary>
    [EndpointPath("account/worldbosses")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountWorldBossesClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IAccountWorldBossesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountWorldBossesClient"/> that is used for the API v2 account worldbosses endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AccountWorldBossesClient(IConnection connection) :
            base(connection)
        { }
    }
}
