using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters crafting endpoint.
    /// </summary>
    [EndpointPath("characters/:id/crafting")]
    public class CharactersCraftingClient : BaseCharactersSubClient<CharactersCrafting>, ICharactersCraftingClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersCraftingClient"/> that is used for the API v2 characters crafting endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersCraftingClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
