using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes endpoint.
    /// </summary>
    public interface IRecipesClient :
        IBulkExpandableClient<Recipe, int>,
        IPaginatedClient<Recipe>
    {
        /// <summary>
        /// Gets the recipes search.
        /// </summary>
        IRecipesSearchClient Search { get; }
    }
}
