namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// Represents the cache state of a response.
    /// </summary>
    public enum CacheState
    {
        /// <summary>
        /// The response was fully received from the live servers.
        /// </summary>
        FromLive,

        /// <summary>
        /// The response was partially received from the live servers and the cache.
        /// </summary>
        PartiallyFromCache,

        /// <summary>
        /// The response was fully received from the cache.
        /// </summary>
        FromCache
    }
}
