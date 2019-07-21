using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps sectors endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id/maps/:map_id/sectors")]
    [EndpointPathSegment("continent_id", 0)]
    [EndpointPathSegment("floor_id", 1)]
    [EndpointPathSegment("region_id", 2)]
    [EndpointPathSegment("map_id", 3)]
    public class ContinentsFloorsRegionsMapsSectorsClient : BaseEndpointBulkAllClient<ContinentFloorRegionMapSector, int>, IContinentsFloorsRegionsMapsSectorsClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly int regionId;
        private readonly int mapId;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsMapsSectorsClient"/> that is used for the API v2 characters floors regions maps sectors endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        /// <param name="mapId">The map id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        internal ContinentsFloorsRegionsMapsSectorsClient(IConnection connection, IGw2Client gw2Client, int continentId, int floorId, int regionId, int mapId) :
            base(connection, gw2Client, continentId.ToString(), floorId.ToString(), regionId.ToString(), mapId.ToString())
        {
            this.continentId = continentId;
            this.floorId = floorId;
            this.regionId = regionId;
            this.mapId = mapId;
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual int RegionId => this.regionId;

        /// <inheritdoc />
        public virtual int MapId => this.mapId;
    }
}
