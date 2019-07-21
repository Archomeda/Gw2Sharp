using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id hero points endpoint.
    /// </summary>
    [EndpointPath("characters/:id/heropoints")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class CharactersIdHeroPointsClient : BaseCharactersSubClient<IApiV2ObjectList<string>>, ICharactersIdHeroPointsClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdHeroPointsClient"/> that is used for the API v2 characters id hero points endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal CharactersIdHeroPointsClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        { }
    }
}
