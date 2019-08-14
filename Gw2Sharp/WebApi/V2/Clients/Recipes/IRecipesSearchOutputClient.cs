namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 recipes search output endpoint.
    /// </summary>
    public interface IRecipesSearchOutputClient :
        IBlobClient<IApiV2ObjectList<int>>
    {
        /// <summary>
        /// The output item id.
        /// </summary>
        int Output { get; }
    }
}
