using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements daily endpoint.
    /// </summary>
    public interface IAchievementsDailyClient :
        IBlobClient<AchievementsDaily>
    {
        /// <summary>
        /// Gets tomorrow's daily achievements.
        /// </summary>
        IAchievementsDailyTomorrowClient Tomorrow { get; }
    }
}
