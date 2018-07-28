using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters inventory endpoint.
    /// </summary>
    [EndpointPath("characters/:id/inventory")]
    public class CharactersInventoryClient : BaseCharactersSubClient<CharactersInventory>, ICharactersInventoryClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersInventoryClient"/> that is used for the API v2 characters inventory endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersInventoryClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
