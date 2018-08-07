namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors id endpoint.
    /// </summary>
    [EndpointPath("continents/:continent_id/floors/:floor_id")]
    public class ContinentsFloorsIdClient : BaseClient, IContinentsFloorsIdClient
    {
        /// <summary>
        /// Creates a new <see cref="ContinentsFloorsIdClient"/> that is used for the API v2 continents floors id endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="continentId">The continent id.</param>
        /// <param name="floorId">The floor id.</param>
        public ContinentsFloorsIdClient(IConnection connection, int continentId, int floorId) : base(connection)
        {
            this.ContinentId = continentId;
            this.FloorId = floorId;
            this.Regions = new ContinentsFloorsRegionsClient(connection, continentId, floorId);
        }

        /// <inheritdoc />
        public virtual int ContinentId { get; protected set; }

        /// <inheritdoc />
        public virtual int FloorId { get; protected set; }

        /// <inheritdoc />
        public virtual IContinentsFloorsRegionsClient Regions { get; protected set; }
    }
}
