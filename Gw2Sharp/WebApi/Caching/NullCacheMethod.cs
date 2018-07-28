using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A dummy caching method that doesn't store anything.
    /// </summary>
    public class NullCacheMethod : BaseCacheMethod
    {
        #region ICacheController members

        /// <inheritdoc />
        public override Task<bool> Has<T>(string category, object id)
        {
            return Task.FromResult(false);
        }

        /// <inheritdoc />
        public override Task<CacheItem<T>> Get<T>(string category, object id)
        {
            return Task.FromResult<CacheItem<T>>(null);
        }

        /// <inheritdoc />
        public override Task Set<T>(CacheItem<T> item)
        {
            return Task.FromResult<object>(null);
        }

        /// <inheritdoc />
        public override Task Set<T>(string category, object id, T item, DateTime expiryTime)
        {
            return Task.FromResult<object>(null);
        }

        /// <inheritdoc />
        public override Task<IDictionary<object, CacheItem<T>>> GetMany<T>(string category, IEnumerable<object> ids)
        {
            return Task.FromResult<IDictionary<object, CacheItem<T>>>(new Dictionary<object, CacheItem<T>>());
        }

        /// <inheritdoc />
        public override Task SetMany<T>(IEnumerable<CacheItem<T>> items)
        {
            return Task.FromResult<object>(null);
        }

        /// <inheritdoc />
        public override Task Flush()
        {
            return Task.FromResult<object>(null);
        }

        #endregion
    }
}
