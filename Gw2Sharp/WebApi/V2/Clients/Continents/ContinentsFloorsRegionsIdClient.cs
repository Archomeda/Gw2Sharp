using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id")]
    public class ContinentsFloorsRegionsIdClient : BaseClient, IContinentsFloorsRegionsIdClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly int regionId;
        private readonly IContinentsFloorsRegionsMapsClient maps;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsIdClient"/> that is used for the API v2 continents floors regions id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public ContinentsFloorsRegionsIdClient(IConnection connection, int continentId, int floorId, int regionId) :
            base(connection)
        {
            this.continentId = continentId;
            this.floorId = floorId;
            this.regionId = regionId;
            this.maps = new ContinentsFloorsRegionsMapsClient(connection, continentId, floorId, regionId);
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual int RegionId => this.regionId;

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsClient Maps => this.maps;
    }
}
