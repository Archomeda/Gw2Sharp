namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account emotes endpoint.
    /// </summary>
    public interface IAccountEmotesClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<string>>
    {
    }
}
