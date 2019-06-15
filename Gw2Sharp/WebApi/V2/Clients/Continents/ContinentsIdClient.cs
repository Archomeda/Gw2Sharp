using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id")]
    public class ContinentsIdClient : BaseClient, IContinentsIdClient
    {
        private readonly int continentId;
        private readonly IContinentsFloorsClient floors;

        /// <summary>
        /// Creates a new <see cref="ContinentsIdClient"/> that is used for the API v2 continents id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public ContinentsIdClient(IConnection connection, int continentId) :
            base(connection)
        {
            this.continentId = continentId;
            this.floors = new ContinentsFloorsClient(connection, continentId);
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual IContinentsFloorsClient Floors => this.floors;
    }
}
