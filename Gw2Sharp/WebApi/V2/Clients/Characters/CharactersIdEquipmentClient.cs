using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id equipment endpoint.
    /// </summary>
    [EndpointPath("characters/:id/equipment")]
    public class CharactersIdEquipmentClient : BaseCharactersSubClient<CharactersEquipment>, ICharactersIdEquipmentClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdEquipmentClient"/> that is used for the API v2 characters id equipment endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        public CharactersIdEquipmentClient(IConnection connection, string characterName) :
            base(connection, characterName)
        { }
    }
}
