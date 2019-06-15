using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id")]
    public class ContinentsFloorsIdClient : BaseClient, IContinentsFloorsIdClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly IContinentsFloorsRegionsClient regions;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsIdClient"/> that is used for the API v2 continents floors id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public ContinentsFloorsIdClient(IConnection connection, int continentId, int floorId) :
            base(connection)
        {
            this.continentId = continentId;
            this.floorId = floorId;
            this.regions = new ContinentsFloorsRegionsClient(connection, continentId, floorId);
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsClient Regions => this.regions;
    }
}
