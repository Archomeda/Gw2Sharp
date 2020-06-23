using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons leaderboards region id endpoint.
    /// </summary>
    [EndpointPath("pvp/seasons/:id/leaderboards/:board/:region")]
    [EndpointPathSegment("id", 0)]
    [EndpointPathSegment("board", 1)]
    [EndpointPathSegment("region", 2)]
    public class PvpSeasonsLeaderboardsRegionIdClient : BaseEndpointPaginatedBlobClient<PvpSeasonLeaderboardEntry>, IPvpSeasonsLeaderboardsRegionIdClient
    {
        private readonly Guid seasonId;
        private readonly string leaderboardId;
        private readonly string regionId;

        /// <summary>
        /// Creates a new <see cref="PvpSeasonsLeaderboardsRegionIdClient"/> that is used for the API v2 PvP seasons leaderboards region id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="seasonId">The PvP season id.</param>
        /// <param name="leaderboardId">The PvP season leaderboard id.</param>
        /// <param name="regionId">The PvP season leaderboard region id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public PvpSeasonsLeaderboardsRegionIdClient(IConnection connection, IGw2Client gw2Client, Guid seasonId, string leaderboardId, string regionId) :
            base(connection, gw2Client, seasonId.ToString(), leaderboardId, regionId)
        {
            this.seasonId = seasonId;
            this.leaderboardId = leaderboardId ?? throw new ArgumentNullException(nameof(leaderboardId));
            this.regionId = regionId ?? throw new ArgumentNullException(nameof(regionId));
        }

        /// <inheritdoc />
        public virtual Guid SeasonId => this.seasonId;

        /// <inheritdoc />
        public virtual string LeaderboardId => this.leaderboardId;

        /// <inheritdoc />
        public virtual string RegionId => this.regionId;
    }
}
