using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id equipment tabs endpoint.
    /// </summary>
    [EndpointPath("characters/:id/equipmenttabs")]
    [EndpointBulkIdName("tab", "tabs", "tab")]
    [EndpointSchemaVersion("2021-04-06T21:00:00.000Z")]
    public class CharactersIdEquipmentTabsClient : BaseCharactersSubBulkClient<CharacterEquipmentTabSlot, int>, ICharactersIdEquipmentTabsClient
    {
        private readonly ICharactersIdEquipmentTabsActiveClient active;

        /// <summary>
        /// Creates a new <see cref="CharactersIdEquipmentTabsClient"/> that is used for the API v2 characters id equipment tabs endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/>, <paramref name="gw2Client"/> or <paramref name="characterName"/> is <c>null</c>.</exception>
        protected internal CharactersIdEquipmentTabsClient(IConnection connection, IGw2Client gw2Client, string characterName) :
            base(connection, gw2Client, characterName)
        {
            this.active = new CharactersIdEquipmentTabsActiveClient(connection, gw2Client, characterName);
        }

        /// <inheritdoc />
        public virtual ICharactersIdEquipmentTabsActiveClient Active => this.active;
    }
}
