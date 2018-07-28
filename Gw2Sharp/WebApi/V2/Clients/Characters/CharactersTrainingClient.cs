using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters training endpoint.
    /// </summary>
    [EndpointPath("characters/:id/training")]
    public class CharactersTrainingClient : BaseCharactersSubClient<CharactersTraining>, ICharactersTrainingClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersTrainingClient"/> that is used for the API v2 characters training endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersTrainingClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
