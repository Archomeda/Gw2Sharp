using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id training endpoint.
    /// </summary>
    [EndpointPath("characters/:id/training")]
    public class CharactersIdTrainingClient : BaseCharactersSubClient<CharactersTraining>, ICharactersIdTrainingClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdTrainingClient"/> that is used for the API v2 characters id training endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdTrainingClient(IConnection connection, string characterName) :
            base(connection, characterName)
        { }
    }
}
