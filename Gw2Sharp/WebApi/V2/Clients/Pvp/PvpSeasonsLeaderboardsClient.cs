using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons leaderboards endpoint.
    /// </summary>
    [EndpointPath("pvp/seasons/:id/leaderboards")]
    [EndpointPathSegment("id", 0)]
    public class PvpSeasonsLeaderboardsClient : BaseEndpointBlobClient<IApiV2ObjectList<string>>, IPvpSeasonsLeaderboardsClient
    {
        private readonly Guid seasonId;

        /// <summary>
        /// Creates a new <see cref="PvpSeasonsLeaderboardsClient"/> that is used for the API v2 PvP seasons leaderboards endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="seasonId">The PvP season id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        public PvpSeasonsLeaderboardsClient(IConnection connection, IGw2Client gw2Client, Guid seasonId) :
            base(connection, gw2Client, seasonId.ToString())
        {
            this.seasonId = seasonId;
        }

        /// <inheritdoc />
        public virtual Guid SeasonId => this.seasonId;

        /// <inheritdoc />
        public virtual IPvpSeasonsLeaderboardsIdClient this[string leaderboardId] =>
            new PvpSeasonsLeaderboardsIdClient(this.Connection, this.Gw2Client!, this.SeasonId, leaderboardId);
    }
}
