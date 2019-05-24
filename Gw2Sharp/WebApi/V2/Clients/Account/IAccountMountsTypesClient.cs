namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mounts types endpoint.
    /// </summary>
    public interface IAccountMountsTypesClient :
        IAuthenticatedClient<IApiV2ObjectList<string>>,
        IBlobClient<IApiV2ObjectList<string>>
    {
    }
}
