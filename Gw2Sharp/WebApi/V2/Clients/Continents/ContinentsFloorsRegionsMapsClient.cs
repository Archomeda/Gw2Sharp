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
        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsMapsClient"/> that is used for the API v2 characters floors regions maps endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        public ContinentsFloorsRegionsMapsClient(IConnection connection, int continentId, int floorId, int regionId) :
            base(connection, continentId.ToString(), floorId.ToString(), regionId.ToString())
        {
            this.ContinentId = continentId;
            this.FloorId = floorId;
            this.RegionId = regionId;
        }

        /// <inheritdoc />
        public virtual int ContinentId { get; protected set; }

        /// <inheritdoc />
        public virtual int FloorId { get; protected set; }

        /// <inheritdoc />
        public virtual int RegionId { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsIdClient this[int mapId] =>
            new ContinentsFloorsRegionsMapsIdClient(this.Connection, this.ContinentId, this.FloorId, this.RegionId, mapId);
    }
}
