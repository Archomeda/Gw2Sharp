namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search endpoint.
    /// </summary>
    public interface IRecipesSearchClient : IClient
    {
        /// <summary>
        /// Requests recipes with the specified input item id.
        /// </summary>
        /// <param name="input">The input item id.</param>
        /// <returns>The recipes search input client.</returns>
        /// <returns><c>this</c> to allow method chaining.</returns>
        IRecipesSearchInputClient Input(int input);

        /// <summary>
        /// Requests recipes with the specified output item id.
        /// </summary>
        /// <param name="output">The output item id.</param>
        /// <returns>The recipes search output client.</returns>
        IRecipesSearchOutputClient Output(int output);
    }
}
