using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements groups endpoint.
    /// </summary>
    public interface IAchievementsGroupsClient :
        IAllExpandableClient<AchievementGroup>,
        IBulkExpandableClient<AchievementGroup, Guid>,
        ILocalizedClient,
        IPaginatedClient<AchievementGroup>
    {
    }
}
