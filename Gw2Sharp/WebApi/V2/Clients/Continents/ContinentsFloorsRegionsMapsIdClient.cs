namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id/maps/:map_id")]
    public class ContinentsFloorsRegionsMapsIdClient : BaseClient, IContinentsFloorsRegionsMapsIdClient
    {
        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsMapsIdClient"/> that is used for the API v2 continents floors regions maps id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        /// <param name="mapId">The map id.</param>
        public ContinentsFloorsRegionsMapsIdClient(IConnection connection, int continentId, int floorId, int regionId, int mapId) : base(connection)
        {
            this.ContinentId = continentId;
            this.FloorId = floorId;
            this.RegionId = regionId;
            this.MapId = mapId;
            this.Sectors = new ContinentsFloorsRegionsMapsSectorsClient(connection, continentId, floorId, regionId, mapId);
            this.Pois = new ContinentsFloorsRegionsMapsPoisClient(connection, continentId, floorId, regionId, mapId);
            this.Tasks = new ContinentsFloorsRegionsMapsTasksClient(connection, continentId, floorId, regionId, mapId);
        }

        /// <inheritdoc />
        public virtual int ContinentId { get; protected set; }

        /// <inheritdoc />
        public virtual int FloorId { get; protected set; }

        /// <inheritdoc />
        public virtual int RegionId { get; protected set; }

        /// <inheritdoc />
        public virtual int MapId { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsPoisClient Pois { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsSectorsClient Sectors { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsTasksClient Tasks { get; protected set; }
    }
}
