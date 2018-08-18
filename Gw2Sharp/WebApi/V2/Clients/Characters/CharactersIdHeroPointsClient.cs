using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id hero points endpoint.
    /// </summary>
    [EndpointPath("characters/:id/heropoints")]
    public class CharactersIdHeroPointsClient : BaseCharactersSubClient<IReadOnlyList<string>>, ICharactersIdHeroPointsClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdHeroPointsClient"/> that is used for the API v2 characters id hero points endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersIdHeroPointsClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
