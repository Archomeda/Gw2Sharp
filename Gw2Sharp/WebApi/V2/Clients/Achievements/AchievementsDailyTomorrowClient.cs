using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements daily tomorrow endpoint.
    /// </summary>
    [EndpointPath("achievements/daily/tomorrow")]
    [EndpointSchemaVersion("2019-05-16T00:00:00.000Z")]
    public class AchievementsDailyTomorrowClient : BaseEndpointBlobClient<AchievementsDaily>, IAchievementsDailyTomorrowClient
    {
        /// <summary>
        /// Creates a new <see cref="AchievementsDailyTomorrowClient"/> that is used for the API v2 achievements daily tomorrow endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public AchievementsDailyTomorrowClient(IConnection connection) :
            base(connection)
        { }
    }
}
