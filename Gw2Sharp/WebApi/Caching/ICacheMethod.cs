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
        /// Checks if the cache contains a cached item with the given id and type.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with the result whether the cached item exists and has not expired.</returns>
        [Obsolete("Removed: Use TryGetAsync to test whether the cache contains an item (this will be removed in next release)")]
        Task<bool> HasAsync<T>(string category, object id) where T : object;

        /// <summary>
        /// Gets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with the cached item if it exists.</returns>
        /// <exception cref="KeyNotFoundException">The cache does not contain the cached item.</exception>
        [Obsolete("Removed: Use TryGetAsync instead (this will be removed in next release)")]
        Task<CacheItem<T>> GetAsync<T>(string category, object id) where T : object;

        /// <summary>
        /// Tries to get a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with a returned cached item if it exists and is not expired; <c>null</c> otherwise.</returns>
        [Obsolete("Renamed: Use TryGetAsync instead (this will be removed in next release)")]
        Task<CacheItem<T>?> GetOrNullAsync<T>(string category, object id) where T : object;

        /// <summary>
        /// Tries to get a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with a returned cached item if it exists and is not expired; <c>null</c> otherwise.</returns>
        Task<CacheItem<T>?> TryGetAsync<T>(string category, object id) where T : object;

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="item">The item to cache.</param>
        /// <returns>The task for this operation.</returns>
        Task SetAsync<T>(CacheItem<T> item) where T : object;

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item to cache.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <returns>The task for this operation.</returns>
        Task SetAsync<T>(string category, object id, T item, DateTime expiryTime) where T : object;

        /// <summary>
        /// Gets many cached items of a given type at once.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>
        /// The task for this operation with the cached items if they exist and have not expired.
        /// Only items that exist are included in the returned dictionary.
        /// </returns>
        Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids) where T : object;

        /// <summary>
        /// Sets many cached items of a given type at once.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The task for this operation.</returns>
        Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items) where T : object;

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls <paramref name="updateFunc"/> to provide an updated value,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="expiryTime">The expiry date.</param>
        /// <param name="updateFunc">The method that is called when no cache has been found.</param>
        /// <returns>The item.</returns>
        Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, DateTime expiryTime, Func<Task<T>> updateFunc) where T : object;

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls <paramref name="updateFunc"/> to provide an updated value and its expiry date,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="updateFunc">The method that is called when no cache has been found.</param>
        /// <returns>The item.</returns>
        Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, Func<Task<(T, DateTime)>> updateFunc) where T : object;

        /// <summary>
        /// Gets cached items if they exist. If one or more don't exist, <paramref name="updateFunc"/> will be called to provide updated values and their expiry date,
        /// and stores them in the cache. Returns all cached items.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The list of cache ids.</param>
        /// <param name="updateFunc">The method that is called for items that are not cached, with as parameter the missing ids.</param>
        /// <returns>The items.</returns>
        Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTime)>> updateFunc)
            where T : object;

        /// <summary>
        /// Gets cached items if they exist. If one or more don't exist, <paramref name="updateFunc"/> will be called to provide updated values
        /// and stores them in the cache. Returns all cached items.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The list of cache ids.</param>
        /// <param name="expiryTime">The expiry date.</param>
        /// <param name="updateFunc">The method that is called for items that are not cached, with as parameter the missing ids.</param>
        /// <returns>The items.</returns>
        Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            DateTime expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc)
            where T : object;

        /// <summary>
        /// Flushes the cache, a.k.a. empties the cache.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task FlushAsync();
    }
}
