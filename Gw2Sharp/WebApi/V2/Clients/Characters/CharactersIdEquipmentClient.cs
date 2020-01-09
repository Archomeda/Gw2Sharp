using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id equipment endpoint.
    /// </summary>
    [EndpointPath("characters/:id/equipment")]
    [EndpointSchemaVersion("2019-12-19T00:00:00.000Z")]
    public class CharactersIdEquipmentClient : BaseCharactersSubBlobClient<CharactersEquipment>, ICharactersIdEquipmentClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdEquipmentClient"/> that is used for the API v2 characters id equipment endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        protected internal CharactersIdEquipmentClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        { }
    }
}
