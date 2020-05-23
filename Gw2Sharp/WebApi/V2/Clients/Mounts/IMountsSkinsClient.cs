
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 mounts skins endpoint.
    /// </summary>
    public interface IMountsSkinsClient :
        IAllExpandableClient<MountSkin>,
        IBulkExpandableClient<MountSkin, int>,
        ILocalizedClient,
        IPaginatedClient<MountSkin>
    {
    }
}
