using System;
using System.Globalization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id/maps")]
    [EndpointPathSegment("continent_id", 0)]
    [EndpointPathSegment("floor_id", 1)]
    [EndpointPathSegment("region_id", 2)]
    public class ContinentsFloorsRegionsMapsClient : BaseEndpointBulkAllClient<ContinentFloorRegionMap, int>, IContinentsFloorsRegionsMapsClient
    {
        private readonly int continentId;
        private readonly int floorId;
        private readonly int regionId;

        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsMapsClient"/> that is used for the API v2 characters floors regions maps endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        protected internal ContinentsFloorsRegionsMapsClient(IConnection connection, IGw2Client gw2Client, int continentId, int floorId, int regionId) :
            base(connection, gw2Client, continentId.ToString(CultureInfo.InvariantCulture), floorId.ToString(CultureInfo.InvariantCulture), regionId.ToString(CultureInfo.InvariantCulture))
        {
            this.continentId = continentId;
            this.floorId = floorId;
            this.regionId = regionId;
        }

        /// <inheritdoc />
        public virtual int ContinentId => this.continentId;

        /// <inheritdoc />
        public virtual int FloorId => this.floorId;

        /// <inheritdoc />
        public virtual int RegionId => this.regionId;

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsIdClient this[int mapId] =>
            new ContinentsFloorsRegionsMapsIdClient(this.Connection, this.Gw2Client!, this.ContinentId, this.FloorId, this.RegionId, mapId);
    }
}
