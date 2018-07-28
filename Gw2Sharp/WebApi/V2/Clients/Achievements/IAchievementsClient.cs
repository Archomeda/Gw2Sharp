using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements endpoint.
    /// </summary>
    public interface IAchievementsClient :
        IBulkExpandableClient<Achievement, int>,
        ILocalizedClient<Achievement>,
        IPaginatedClient<Achievement>
    {
        /// <summary>
        /// Gets the achievement categories.
        /// </summary>
        IAchievementsCategoriesClient Categories { get; }

        /// <summary>
        /// Gets the achievement groups.
        /// </summary>
        IAchievementsGroupsClient Groups { get; }

        /// <summary>
        /// Gets the daily achievements.
        /// </summary>
        IAchievementsDailyClient Daily { get; }
    }
}
