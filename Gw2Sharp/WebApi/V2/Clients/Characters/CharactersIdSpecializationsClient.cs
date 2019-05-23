using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id specializations endpoint.
    /// </summary>
    [EndpointPath("characters/:id/specializations")]
    [EndpointSchemaVersion("2019-02-21T00:00:00.000Z")]
    public class CharactersIdSpecializationsClient : BaseCharactersSubClient<CharactersSpecializations>, ICharactersIdSpecializationsClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdSpecializationsClient"/> that is used for the API v2 characters id specializations endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdSpecializationsClient(IConnection connection, string characterName) :
            base(connection, characterName)
        { }
    }
}
