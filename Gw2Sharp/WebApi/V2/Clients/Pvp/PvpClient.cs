using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 PvP endpoint.
    /// </summary>
    [EndpointPath("pvp")]
    public class PvpClient : BaseClient, IPvpClient
    {
        private readonly IPvpAmuletsClient amulets;
        private readonly IPvpGamesClient games;
        private readonly IPvpHeroesClient heroes;
        private readonly IPvpRanksClient ranks;
        private readonly IPvpSeasonsClient seasons;
        private readonly IPvpStatsClient stats;
        private readonly IPvpStandingsClient standings;

        /// <summary>
        /// Creates a new <see cref="PvpClient"/> that is used for the API v2 PvP endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        protected internal PvpClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.amulets = new PvpAmuletsClient(connection, gw2Client);
            this.games = new PvpGamesClient(connection, gw2Client);
            this.heroes = new PvpHeroesClient(connection, gw2Client);
            this.ranks = new PvpRanksClient(connection, gw2Client);
            this.seasons = new PvpSeasonsClient(connection, gw2Client);
            this.stats = new PvpStatsClient(connection, gw2Client);
            this.standings = new PvpStandingsClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IPvpAmuletsClient Amulets => this.amulets;

        /// <inheritdoc />
        public virtual IPvpGamesClient Games => this.games;

        /// <inheritdoc />
        public virtual IPvpHeroesClient Heroes => this.heroes;

        /// <inheritdoc />
        public virtual IPvpRanksClient Ranks => this.ranks;

        /// <inheritdoc />
        public virtual IPvpSeasonsClient Seasons => this.seasons;

        /// <inheritdoc />
        public virtual IPvpStatsClient Stats => this.stats;

        /// <inheritdoc />
        public virtual IPvpStandingsClient Standings => this.standings;
    }
}
