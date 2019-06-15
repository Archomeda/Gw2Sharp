
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 worldbosses endpoint.
    /// </summary>
    public interface IWorldBossesClient :
        IAllExpandableClient<WorldBoss>,
        IBulkExpandableClient<WorldBoss, string>,
        ILocalizedClient<WorldBoss>,
        IPaginatedClient<WorldBoss>
    {
    }
}
