using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP seasons id endpoint.
    /// </summary>
    [EndpointPath("pvp/seasons/:id")]
    [EndpointPathSegment("id", 0)]
    public class PvpSeasonsIdClient : BaseEndpointBlobClient<PvpSeason>, IPvpSeasonsIdClient
    {
        private readonly Guid seasonId;
        private readonly PvpSeasonsLeaderboardsClient leaderboards;

        /// <summary>
        /// Creates a new <see cref="PvpSeasonsIdClient"/> that is used for the API v2 PvP seasons id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="seasonId">The PvP season id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        public PvpSeasonsIdClient(IConnection connection, IGw2Client gw2Client, Guid seasonId) :
             base(connection, gw2Client, seasonId.ToString())
        {
            this.seasonId = seasonId;
            this.leaderboards = new PvpSeasonsLeaderboardsClient(connection, gw2Client, seasonId);
        }

        /// <inheritdoc />
        public virtual Guid SeasonId => this.seasonId;

        /// <inheritdoc />
        public virtual IPvpSeasonsLeaderboardsClient Leaderboards => this.leaderboards;
    }
}
