using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account build storage endpoint.
    /// </summary>
    public interface IAccountBuildStorageClient :
        IAuthenticatedClient,
        IAllExpandableClient<AccountBuildStorageSlot>,
        IBulkExpandableClient<AccountBuildStorageSlot, int>,
        IPaginatedClient<AccountBuildStorageSlot>
    {
    }
}
