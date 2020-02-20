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
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with a returned cached item if it exists and is not expired; <c>null</c> otherwise.</returns>
        Task<CacheItem<T>?> TryGetAsync<T>(string category, object id);

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="item">The item to cache.</param>
        /// <returns>The task for this operation.</returns>
        Task SetAsync<T>(CacheItem<T> item);

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item to cache.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <returns>The task for this operation.</returns>
        Task SetAsync<T>(string category, object id, T item, DateTimeOffset expiryTime);

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
        Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids);

        /// <summary>
        /// Sets many cached items of a given type at once.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The task for this operation.</returns>
        Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items);

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
        Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, DateTimeOffset expiryTime, Func<Task<T>> updateFunc);

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls <paramref name="updateFunc"/> to provide an updated value and its expiry date,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="updateFunc">The method that is called when no cache has been found.</param>
        /// <returns>The item.</returns>
        Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, Func<Task<(T, DateTimeOffset)>> updateFunc);

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
            Func<IList<object>, Task<(IDictionary<object, T>, DateTimeOffset)>> updateFunc);

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
            DateTimeOffset expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc);

        /// <summary>
        /// Clears the cache, a.k.a. empties the cache.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        [Obsolete("Use ClearAsync instead. Will be removed starting with version 0.9.0")]
        Task FlushAsync();

        /// <summary>
        /// Clears the cache, a.k.a. empties the cache.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task ClearAsync();
    }
}
