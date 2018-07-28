using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements daily endpoint.
    /// </summary>
    [EndpointPath("achievements/daily")]
    public class AchievementsDailyClient : BaseEndpointBlobClient<AchievementsDaily>, IAchievementsDailyClient
    {
        /// <summary>
        /// Creates a new <see cref="AchievementsDailyClient"/> that is used for the API v2 achievements daily endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AchievementsDailyClient(IConnection connection) : base(connection)
        {
            this.Tomorrow = new AchievementsDailyTomorrowClient(connection);
        }

        /// <inheritdoc />
        public virtual IAchievementsDailyTomorrowClient Tomorrow { get; protected set; }
    }
}
