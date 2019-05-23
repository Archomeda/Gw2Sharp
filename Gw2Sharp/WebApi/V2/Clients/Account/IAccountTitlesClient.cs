namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account titles endpoint.
    /// </summary>
    public interface IAccountTitlesClient :
        IAuthenticatedClient<IApiV2ObjectList<int>>,
        IBlobClient<IApiV2ObjectList<int>>
    {
    }
}
