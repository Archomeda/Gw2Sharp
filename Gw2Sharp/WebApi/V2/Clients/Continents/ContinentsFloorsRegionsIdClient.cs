namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id/regions/:region_id")]
    public class ContinentsFloorsRegionsIdClient : BaseClient, IContinentsFloorsRegionsIdClient
    {
        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsRegionsIdClient"/> that is used for the API v2 continents floors regions id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        /// <param name="regionId">The region id.</param>
        public ContinentsFloorsRegionsIdClient(IConnection connection, int continentId, int floorId, int regionId) : base(connection)
        {
            this.ContinentId = continentId;
            this.FloorId = floorId;
            this.RegionId = regionId;
            this.Maps = new ContinentsFloorsRegionsMapsClient(connection, continentId, floorId, regionId);
        }

        /// <inheritdoc />
        public virtual int ContinentId { get; protected set; }

        /// <inheritdoc />
        public virtual int FloorId { get; protected set; }

        /// <inheritdoc />
        public virtual int RegionId { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsMapsClient Maps { get; protected set; }
    }
}
