using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// An interface for implementing a caching method.
    /// </summary>
    public interface ICacheMethod : IDisposable
    {
        /// <summary>
        /// Tries to get a cached item.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with a returned cached item if it exists and has not expired; <c>null</c> otherwise.</returns>
        Task<CacheItem?> TryGetAsync(string category, string id);

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <param name="item">The item to cache.</param>
        /// <returns>The task for this operation.</returns>
        Task SetAsync(CacheItem item);

        /// <summary>
        /// Gets many cached items of a given type at once.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>
        /// The task for this operation with the cached items if they exist and have not expired.
        /// Only items that exist are included in the returned list.
        /// </returns>
        Task<IList<CacheItem>> GetManyAsync(string category, IEnumerable<string> ids);

        /// <summary>
        /// Sets many cached items of a given type at once.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The task for this operation.</returns>
        Task SetManyAsync(IEnumerable<CacheItem> items);

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls <paramref name="updateFunc"/> to provide the updated item,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="updateFunc">
        /// The method that is called when no cache has been found.
        /// The first parameter is <paramref name="category"/>, the second parameter is <paramref name="id"/>.
        /// The returned object is a <see cref="CacheItem"/>.
        /// </param>
        /// <returns>The task for this operation with the item.</returns>
        Task<CacheItem> GetOrUpdateAsync(string category, string id, Func<string, string, Task<CacheItem>> updateFunc);

        /// <summary>
        /// Gets cached items if they exist. If one or more don't exist, <paramref name="updateFunc"/> will be called to provide updated items,
        /// and stores them in the cache. Returns all cached and new items.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The list of cache ids.</param>
        /// <param name="updateFunc">
        /// The method that is called for items that are not cached.
        /// The first parameter is <paramref name="category"/>, the second parameter is the list of missing ids (which is always a subset of <paramref name="ids"/>.
        /// The returned object is a list of <see cref="CacheItem"/>.
        /// </param>
        /// <returns>The task for this operation with the items.</returns>
        Task<IList<CacheItem>> GetOrUpdateManyAsync(
            string category,
            IEnumerable<string> ids,
            Func<string, IList<string>, Task<IList<CacheItem>>> updateFunc);

        /// <summary>
        /// Clears the cache, a.k.a. empties the cache.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task ClearAsync();
    }
}
