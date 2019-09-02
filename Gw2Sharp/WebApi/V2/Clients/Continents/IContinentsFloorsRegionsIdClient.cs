using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors regions id endpoint.
    /// </summary>
    public interface IContinentsFloorsRegionsIdClient : IBlobClient<ContinentFloorRegion>
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
        /// Gets the maps.
        /// </summary>
        IContinentsFloorsRegionsMapsClient Maps { get; }
    }
}
