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
        public override async Task<bool> HasAsync<T>(string category, object id) =>
            false;

        /// <inheritdoc />
        public override async Task<CacheItem<T>?> GetOrNullAsync<T>(string category, object id) =>
            null;

        /// <inheritdoc />
        public override async Task SetAsync<T>(CacheItem<T> item)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task SetAsync<T>(string category, object id, T item, DateTime expiryTime)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids) =>
            new Dictionary<object, CacheItem<T>>();

        /// <inheritdoc />
        public override async Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items)
        {
            // Nothing to do
        }

        /// <inheritdoc />
        public override async Task FlushAsync()
        {
            // Nothing to do
        }

        #endregion
    }
}
