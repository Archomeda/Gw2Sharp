using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons leaderboards id endpoint.
    /// </summary>
    [EndpointPath("pvp/seasons/:id/leaderboards/:board")]
    [EndpointPathSegment("id", 0)]
    [EndpointPathSegment("board", 1)]
    public class PvpSeasonsLeaderboardsIdClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IPvpSeasonsLeaderboardsIdClient
    {
        private readonly Guid seasonId;
        private readonly string leaderboardId;

        /// <summary>
        /// Creates a new <see cref="PvpSeasonsLeaderboardsIdClient"/> that is used for the API v2 PvP seasons leaderboards id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="seasonId">The PvP season id.</param>
        /// <param name="leaderboardId">The PvP season leaderboard id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public PvpSeasonsLeaderboardsIdClient(IConnection connection, IGw2Client gw2Client, Guid seasonId, string leaderboardId) :
            base(connection, gw2Client, seasonId.ToString(), leaderboardId)
        {
            this.seasonId = seasonId;
            this.leaderboardId = leaderboardId ?? throw new ArgumentNullException(nameof(leaderboardId));
        }

        /// <inheritdoc />
        public virtual Guid SeasonId =>
            this.seasonId;

        /// <inheritdoc />
        public virtual string LeaderboardId =>
            this.leaderboardId;

        /// <inheritdoc />
        public IPvpSeasonsLeaderboardsRegionIdClient this[string regionId] =>
            new PvpSeasonsLeaderboardsRegionIdClient(this.Connection, this.Gw2Client!, this.SeasonId, this.LeaderboardId, regionId);
    }
}
