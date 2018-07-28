using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters core endpoint.
    /// </summary>
    [EndpointPath("characters/:id/core")]
    public class CharactersCoreClient : BaseCharactersSubClient<CharactersCore>, ICharactersCoreClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersCoreClient"/> that is used for the API v2 characters core endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersCoreClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
