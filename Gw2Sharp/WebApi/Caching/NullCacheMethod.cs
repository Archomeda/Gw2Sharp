using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A dummy caching method that doesn't store anything.
    /// </summary>
    public class NullCacheMethod : BaseCacheMethod
    {
        #region ICacheController members

        /// <inheritdoc />
        public override async Task<CacheItem<T>?> TryGetAsync<T>(string category, string id) =>
            null;

        /// <inheritdoc />
        public override async Task SetAsync<T>(CacheItem<T> item)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task SetAsync<T>(string category, string id, T item, DateTimeOffset expiryTime)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task<IDictionary<string, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<string> ids) =>
            new Dictionary<string, CacheItem<T>>();

        /// <inheritdoc />
        public override async Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task ClearAsync()
        {
            // Nothing to do
        }

        #endregion
    }
}
