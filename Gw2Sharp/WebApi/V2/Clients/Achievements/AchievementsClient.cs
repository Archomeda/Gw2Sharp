using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements endpoint.
    /// </summary>
    [EndpointPath("achievements")]
    public class AchievementsClient : BaseEndpointBulkClient<Achievement, int>, IAchievementsClient
    {
        private readonly IAchievementsCategoriesClient categories;
        private readonly IAchievementsGroupsClient groups;
        private readonly IAchievementsDailyClient daily;

        /// <summary>
        /// Creates a new <see cref="AchievementsClient"/> that is used for the API v2 achievements endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal AchievementsClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.categories = new AchievementsCategoriesClient(connection, gw2Client);
            this.groups = new AchievementsGroupsClient(connection, gw2Client);
            this.daily = new AchievementsDailyClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IAchievementsCategoriesClient Categories => this.categories;

        /// <inheritdoc />
        public virtual IAchievementsGroupsClient Groups => this.groups;

        /// <inheritdoc />
        public virtual IAchievementsDailyClient Daily => this.daily;
    }
}
