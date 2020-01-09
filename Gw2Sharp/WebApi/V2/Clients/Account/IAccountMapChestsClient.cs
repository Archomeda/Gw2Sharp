namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mapchests endpoint.
    /// </summary>
    public interface IAccountMapChestsClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<string>>
    {
    }
}
