using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 achievements endpoint.
    /// </summary>
    [EndpointPath("achievements")]
    public class AchievementsClient : BaseEndpointBulkClient<Achievement, int>, IAchievementsClient
    {
        /// <summary>
        /// Creates a new <see cref="AchievementsClient"/> that is used for the API v2 achievements endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public AchievementsClient(IConnection connection) : base(connection)
        {
            this.Categories = new AchievementsCategoriesClient(connection);
            this.Groups = new AchievementsGroupsClient(connection);
            this.Daily = new AchievementsDailyClient(connection);
        }

        /// <inheritdoc />
        public virtual IAchievementsCategoriesClient Categories { get; protected set; }

        /// <inheritdoc />
        public virtual IAchievementsGroupsClient Groups { get; protected set; }

        /// <inheritdoc />
        public virtual IAchievementsDailyClient Daily { get; protected set; }
    }
}
