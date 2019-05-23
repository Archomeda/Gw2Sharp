namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account home cats endpoint.
    /// </summary>
    public interface IAccountHomeCatsClient :
        IAuthenticatedClient<IApiV2ObjectList<int>>,
        IBlobClient<IApiV2ObjectList<int>>
    {
    }
}
