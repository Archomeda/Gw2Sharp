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
        public override async Task<bool> Has<T>(string category, object id) =>
            false;

        /// <inheritdoc />
        public override async Task<CacheItem<T>?> GetOrNull<T>(string category, object id) =>
            null;

        /// <inheritdoc />
        public override async Task Set<T>(CacheItem<T> item) { }

        /// <inheritdoc />
        public override async Task Set<T>(string category, object id, T item, DateTime expiryTime) { }

        /// <inheritdoc />
        public override async Task<IDictionary<object, CacheItem<T>>> GetMany<T>(string category, IEnumerable<object> ids) =>
            new Dictionary<object, CacheItem<T>>();

        /// <inheritdoc />
        public override async Task SetMany<T>(IEnumerable<CacheItem<T>> items) { }

        /// <inheritdoc />
        public override async Task Flush() { }

        #endregion
    }
}
