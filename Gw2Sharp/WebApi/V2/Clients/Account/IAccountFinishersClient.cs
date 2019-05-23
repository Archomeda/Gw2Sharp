using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account finishers endpoint.
    /// </summary>
    public interface IAccountFinishersClient :
        IAuthenticatedClient<IApiV2ObjectList<AccountFinisher>>,
        IBlobClient<IApiV2ObjectList<AccountFinisher>>
    {
    }
}
