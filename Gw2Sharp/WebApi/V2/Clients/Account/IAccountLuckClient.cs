using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account luck endpoint.
    /// </summary>
    public interface IAccountLuckClient :
        IAuthenticatedClient<IApiV2ObjectList<AccountLuck>>,
        IBlobClient<IApiV2ObjectList<AccountLuck>>
    {
    }
}
