using System;
using System.Globalization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps poins of interest endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id/maps/:map_id/pois")]
    [EndpointPathSegment("continent_id", 0)]
    [EndpointPathSegment("floor_id", 1)]
    [EndpointPathSegment("region_id", 2)]
    [EndpointPathSegment("map_id", 3)]
    public class ContinentsFloorsRegionsMapsPoisClient : BaseEndpointBulkAllClient<ContinentFloorRegionMapPoi, int>, IContinentsFloorsRegionsMapsPoisClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly int regionId;
        private readonly int mapId;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsMapsPoisClient"/> that is used for the API v2 characters floors regions maps poins of interest endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        /// <param name="mapId">The map id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal ContinentsFloorsRegionsMapsPoisClient(IConnection connection, IGw2Client gw2Client, int continentId, int floorId, int regionId, int mapId) :
            base(connection, gw2Client, continentId.ToString(CultureInfo.InvariantCulture), floorId.ToString(CultureInfo.InvariantCulture), regionId.ToString(CultureInfo.InvariantCulture), mapId.ToString(CultureInfo.InvariantCulture))
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
