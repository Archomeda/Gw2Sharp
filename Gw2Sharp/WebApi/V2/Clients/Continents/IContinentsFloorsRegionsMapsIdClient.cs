namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions maps id endpoint.
    /// </summary>
    public interface IContinentsFloorsRegionsMapsIdClient : IClient
    {
        /// <summary>
        /// The continent id.
        /// </summary>
        int ContinentId { get; }

        /// <summary>
        /// The floor id.
        /// </summary>
        int FloorId { get; }

        /// <summary>
        /// The region id.
        /// </summary>
        int RegionId { get; }

        /// <summary>
        /// The map id.
        /// </summary>
        int MapId { get; }

        /// <summary>
        /// Gets the points of interest.
        /// </summary>
        IContinentsFloorsRegionsMapsPoisClient Pois { get; }

        /// <summary>
        /// Gets the sectors.
        /// </summary>
        IContinentsFloorsRegionsMapsSectorsClient Sectors { get; }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        IContinentsFloorsRegionsMapsTasksClient Tasks { get; }
    }
}
