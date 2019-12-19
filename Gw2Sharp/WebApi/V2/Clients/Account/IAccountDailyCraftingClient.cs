namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account dailycrafting endpoint.
    /// </summary>
    public interface IAccountDailyCraftingClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<string>>
    {
    }
}
