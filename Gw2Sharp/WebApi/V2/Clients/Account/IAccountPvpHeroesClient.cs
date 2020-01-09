namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account PvP heroes endpoint.
    /// </summary>
    public interface IAccountPvpHeroesClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<int>>
    {
    }
}
