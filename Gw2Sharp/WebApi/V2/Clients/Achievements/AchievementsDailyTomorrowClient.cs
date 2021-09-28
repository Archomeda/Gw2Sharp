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
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AchievementsDailyTomorrowClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }
    }
}
