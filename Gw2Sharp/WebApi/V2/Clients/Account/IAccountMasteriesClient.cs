using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account masteries endpoint.
    /// </summary>
    public interface IAccountMasteriesClient :
        IAuthenticatedClient<IApiV2ObjectList<AccountMastery>>,
        IBlobClient<IApiV2ObjectList<AccountMastery>>
    {
    }
}
