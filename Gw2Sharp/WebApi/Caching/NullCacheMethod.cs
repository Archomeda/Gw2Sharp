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
        #region BaseCacheMethod overrides

        /// <inheritdoc />
        public override Task<CacheItem?> TryGetAsync(string category, string id) =>
            Task.FromResult<CacheItem?>(null);

        /// <inheritdoc />
        public override Task SetAsync(CacheItem item) =>
            Task.CompletedTask;

        /// <inheritdoc />
        public override Task<IList<CacheItem>> GetManyAsync(string category, IEnumerable<string> ids) =>
            Task.FromResult<IList<CacheItem>>(Array.Empty<CacheItem>());

        /// <inheritdoc />
        public override Task SetManyAsync(IEnumerable<CacheItem> items) =>
            Task.CompletedTask;

        /// <inheritdoc />
        public override Task ClearAsync() =>
            Task.CompletedTask;

        #endregion
    }
}
