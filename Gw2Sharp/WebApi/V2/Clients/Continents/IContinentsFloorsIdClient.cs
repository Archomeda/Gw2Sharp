namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 continents floors id endpoint.
    /// </summary>
    public interface IContinentsFloorsIdClient : IClient
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
        /// Gets the regions.
        /// </summary>
        IContinentsFloorsRegionsClient Regions { get; }
    }
}
