using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 characters id recipes endpoint.
    /// </summary>
    [EndpointPath("characters/:id/recipes")]
    public class CharactersIdRecipesClient : BaseCharactersSubClient<CharactersRecipes>, ICharactersIdRecipesClient
    {
        /// <summary>
        /// Creates a new <see cref="CharactersIdRecipesClient"/> that is used for the API v2 characters id recipes endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="characterName">The character name.</param>
        public CharactersIdRecipesClient(IConnection connection, string characterName) : base(connection, characterName) { }
    }
}
