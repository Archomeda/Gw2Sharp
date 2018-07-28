using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements categories endpoint.
    /// </summary>
    public interface IAchievementsCategoriesClient :
        IAllExpandableClient<AchievementCategory>,
        IBulkExpandableClient<AchievementCategory, int>,
        ILocalizedClient<AchievementCategory>,
        IPaginatedClient<AchievementCategory>
    {
    }
}
