using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements daily endpoint.
    /// </summary>
    [EndpointPath("achievements/daily")]
    [EndpointSchemaVersion("2019-05-16T00:00:00.000Z")]
    public class AchievementsDailyClient : BaseEndpointBlobClient<AchievementsDaily>, IAchievementsDailyClient
    {
        private readonly IAchievementsDailyTomorrowClient tomorrow;

        /// <summary>
        /// Creates a new <see cref="AchievementsDailyClient"/> that is used for the API v2 achievements daily endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal AchievementsDailyClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.tomorrow = new AchievementsDailyTomorrowClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IAchievementsDailyTomorrowClient Tomorrow => this.tomorrow;
    }
}
