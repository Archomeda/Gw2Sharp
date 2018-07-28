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
        /// <exception cref="ArgumentNullException">Thrown when category or id is <c>null</c>.</exception>
        Task<bool> Has<T>(string category, object id);

        /// <summary>
        /// Gets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <returns>The task for this operation with the cached item if it exists and is not expired; <c>null</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category or id is <c>null</c>.</exception>
        Task<CacheItem<T>> Get<T>(string category, object id);

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="item">The item to cache.</param>
        /// <returns>The task for this operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when item is <c>null</c>.</exception>
        Task Set<T>(CacheItem<T> item);

        /// <summary>
        /// Sets a cached item.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item to cache.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <returns>The task for this operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category, id or item is <c>null</c>.</exception>
        Task Set<T>(string category, object id, T item, DateTime expiryTime);

        /// <summary>
        /// Gets many cached items of a given type at once.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The ids.</param>
        /// <returns>The task for this operation with the cached items if they exist and are not expired.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category or ids is <c>null</c>.</exception>
        Task<IDictionary<object, CacheItem<T>>> GetMany<T>(string category, IEnumerable<object> ids);

        /// <summary>
        /// Sets many cached items of a given type at once.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns>The task for this operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when items is <c>null</c>.</exception>
        Task SetMany<T>(IEnumerable<CacheItem<T>> items);

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls updateFunc to provide an updated value,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="expiryTime">The expiry date.</param>
        /// <param name="updateFunc">The method that is called when no cache has been found.</param>
        /// <returns>The item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category, id or updateFunc is <c>null</c>.</exception>
        Task<CacheItem<T>> GetOrUpdate<T>(string category, object id, DateTime expiryTime, Func<Task<T>> updateFunc);

        /// <summary>
        /// Gets a cached item if it exists. If it doesn't exist, it calls updateFunc to provide an updated value and its expiry date,
        /// stores this in the cache, and returns it.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The cache id.</param>
        /// <param name="updateFunc">The method that is called when no cache has been found.</param>
        /// <returns>The item.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category, id or updateFunc is <c>null</c>.</exception>
        Task<CacheItem<T>> GetOrUpdate<T>(string category, object id, Func<Task<(T, DateTime)>> updateFunc);

        /// <summary>
        /// Gets cached items if they exist. If one or more don't exist, updateFunc will be called to provide updated values and their expiry date,
        /// and stores them in the cache. Returns all cached items.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The list of cache ids.</param>
        /// <param name="updateFunc">The method that is called for items that are not cached, with as parameter the missing ids.</param>
        /// <returns>The items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category, ids or updateFunc is <c>null</c>.</exception>
        Task<IList<CacheItem<T>>> GetOrUpdateMany<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTime)>> updateFunc);

        /// <summary>
        /// Gets cached items if they exist. If one or more don't exist, updateFunc will be called to provide updated values
        /// and stores them in the cache. Returns all cached items.
        /// </summary>
        /// <typeparam name="T">The cache type.</typeparam>
        /// <param name="category">The cache category.</param>
        /// <param name="ids">The list of cache ids.</param>
        /// <param name="expiryTime">The expiry date.</param>
        /// <param name="updateFunc">The method that is called for items that are not cached, with as parameter the missing ids.</param>
        /// <returns>The items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when category, ids or updateFunc is <c>null</c>.</exception>
        Task<IList<CacheItem<T>>> GetOrUpdateMany<T>(
            string category,
            IEnumerable<object> ids,
            DateTime expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc);

        /// <summary>
        /// Flushes the cache, a.k.a. empties the cache.
        /// </summary>
        /// <returns>The task for this operation.</returns>
        Task Flush();
    }
}
