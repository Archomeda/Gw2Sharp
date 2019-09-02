namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search input endpoint.
    /// </summary>
    public interface IRecipesSearchInputClient :
        IBlobClient<IApiV2ObjectList<int>>
    {
        /// <summary>
        /// The input item id.
        /// </summary>
        int Input { get; }
    }
}
