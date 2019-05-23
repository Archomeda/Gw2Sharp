using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id skills endpoint.
    /// </summary>
    [EndpointPath("characters/:id/skills")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class CharactersIdSkillsClient : BaseCharactersSubClient<CharactersSkills>, ICharactersIdSkillsClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdSkillsClient"/> that is used for the API v2 characters id skills endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdSkillsClient(IConnection connection, string characterName) :
            base(connection, characterName)
        { }
    }
}
