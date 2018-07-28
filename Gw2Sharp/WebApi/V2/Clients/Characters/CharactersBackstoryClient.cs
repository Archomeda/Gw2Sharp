using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters backstory endpoint.
    /// </summary>
    [EndpointPath("characters/:id/backstory")]
    public class CharactersBackstoryClient : BaseCharactersSubClient<CharactersBackstory>, ICharactersBackstoryClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersBackstoryClient"/> that is used for the API v2 characters backstory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersBackstoryClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
