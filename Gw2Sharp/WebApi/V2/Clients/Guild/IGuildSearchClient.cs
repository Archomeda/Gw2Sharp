namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search endpoint.
    /// </summary>
    public interface IGuildSearchClient
    {
        /// <summary>
        /// Searches for a guild with the specified name.
        /// </summary>
        /// <param name="name">The guild name.</param>
        /// <returns>The guild search name client.</returns>
        IGuildSearchNameClient Name(string name);
    }
}
