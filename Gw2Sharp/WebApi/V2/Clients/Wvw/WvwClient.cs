using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 wvw endpoint.
    /// </summary>
    [EndpointPath("wvw")]
    public class WvwClient : Gw2WebApiBaseClient, IWvwClient
    {
        private readonly IWvwAbilitiesClient abilities;
        private readonly IWvwMatchesClient matches;
        private readonly IWvwObjectivesClient objectives;
        private readonly IWvwRanksClient ranks;
        private readonly IWvwUpgradesClient upgrades;

        /// <summary>
        /// Creates a new <see cref="WvwClient"/> that is used for the API v2 commerce endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal WvwClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        {
            this.abilities = new WvwAbilitiesClient(connection, gw2Client);
            this.matches = new WvwMatchesClient(connection, gw2Client);
            this.objectives = new WvwObjectivesClient(connection, gw2Client);
            this.ranks = new WvwRanksClient(connection, gw2Client);
            this.upgrades = new WvwUpgradesClient(connection, gw2Client);
        }

        /// <inheritdoc />
        public virtual IWvwAbilitiesClient Abilities => this.abilities;

        /// <inheritdoc />
        public virtual IWvwMatchesClient Matches => this.matches;

        /// <inheritdoc />
        public virtual IWvwObjectivesClient Objectives => this.objectives;

        /// <inheritdoc />
        public virtual IWvwRanksClient Ranks => this.ranks;

        /// <inheritdoc />
        public virtual IWvwUpgradesClient Upgrades => this.upgrades;

    }
}
