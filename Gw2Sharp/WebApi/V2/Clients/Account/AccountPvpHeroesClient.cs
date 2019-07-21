using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP heroes endpoint.
    /// </summary>
    [EndpointPath("account/pvp/heroes")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class AccountPvpHeroesClient : BaseEndpointBlobClient<IApiV2ObjectList<int>>, IAccountPvpHeroesClient
    {
        /// <summary>
        /// Creates a new <see cref="AccountPvpHeroesClient"/> that is used for the API v2 account PvP heroes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal AccountPvpHeroesClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
