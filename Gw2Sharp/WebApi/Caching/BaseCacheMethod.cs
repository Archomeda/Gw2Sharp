using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisposeGenerator.Attributes;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// Provides basic implementation for non-standard methods in a cache method.
    /// </summary>
    [DisposeAll]
    public abstract partial class BaseCacheMethod : ICacheMethod
    {
        /// <inheritdoc />
        public abstract Task<CacheItem?> TryGetAsync(string category, string id);

        /// <inheritdoc />
        public abstract Task SetAsync(CacheItem item);

        /// <inheritdoc />
        public virtual Task<IList<CacheItem>> GetManyAsync(string category, IEnumerable<string> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            return ExecAsync();

            async Task<IList<CacheItem>> ExecAsync()
            {
                var cache = new List<CacheItem>();
                foreach (string id in ids)
                {
                    var cacheItem = await this.TryGetAsync(category, id).ConfigureAwait(false);
                    if (cacheItem != null)
                        cache.Add(cacheItem);
                }
                return cache;
            }
        }

        /// <inheritdoc />
        public virtual Task SetManyAsync(IEnumerable<CacheItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            return ExecAsync();

            async Task ExecAsync()
            {
                foreach (var item in items)
                    await this.SetAsync(item).ConfigureAwait(false);
            }
        }

        /// <inheritdoc />
        public virtual Task<CacheItem> GetOrUpdateAsync(string category, string id, Func<string, string, Task<CacheItem>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));
            return ExecAsync();

            async Task<CacheItem> ExecAsync()
            {
                var fItem = await this.TryGetAsync(category, id).ConfigureAwait(false);
                if (fItem != null)
                    return fItem;

                var item = await updateFunc(category, id).ConfigureAwait(false);
                await this.SetAsync(item).ConfigureAwait(false);
                return item;
            }
        }

        /// <inheritdoc />
        public virtual Task<IList<CacheItem>> GetOrUpdateManyAsync(string category, IEnumerable<string> ids, Func<string, IList<string>, Task<IList<CacheItem>>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));
            return ExecAsync();

            async Task<IList<CacheItem>> ExecAsync()
            {
                var idsList = ids as IList<string> ?? ids.ToList();

                var cache = await this.GetManyAsync(category, idsList).ConfigureAwait(false);
                var dict = cache.ToDictionary(x => x.Id, x => x);
                var missing = idsList.Except(cache.Select(x => x.Id)).ToList();

                if (missing.Count > 0)
                {
                    var newItems = await updateFunc(category, missing).ConfigureAwait(false);
                    await this.SetManyAsync(newItems).ConfigureAwait(false);
                    foreach (var item in newItems)
                        dict[item.Id] = item;
                }

                // Return in the same order as requested
                return idsList
                    .Select(x => dict.TryGetValue(x, out var value) ? value : null)
                    .WhereNotNull()
                    .ToList();
            }
        }

        /// <inheritdoc />
        public abstract Task ClearAsync();
    }
}
