using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters recipes endpoint.
    /// </summary>
    [EndpointPath("characters/:id/recipes")]
    public class CharactersRecipesClient : BaseCharactersSubClient<CharactersRecipes>, ICharactersRecipesClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersRecipesClient"/> that is used for the API v2 characters recipes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersRecipesClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
