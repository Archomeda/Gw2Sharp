using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account bank endpoint.
    /// </summary>
    public interface IAccountBankClient :
        IAuthenticatedClient<IApiV2ObjectList<AccountItem>>,
        IBlobClient<IApiV2ObjectList<AccountItem>>
    {
    }
}
