using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account progression endpoint.
    /// </summary>
    public interface IAccountProgressionClient :
        IAuthenticatedClient,
        IBlobClient<IApiV2ObjectList<AccountProgression>>
    {
    }
}
