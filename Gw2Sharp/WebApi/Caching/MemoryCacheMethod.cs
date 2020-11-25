using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A in-memory caching method.
    /// </summary>
    public class MemoryCacheMethod : BaseCacheMethod
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, CacheItem>> cachedItems = new ConcurrentDictionary<string, ConcurrentDictionary<string, CacheItem>>();

        private readonly Timer gcTimer;

        /// <summary>
        /// Creates a new in-memory caching method.
        /// </summary>
        public MemoryCacheMethod() : this(5 * 60 * 1000) { }

        /// <summary>
        /// Creates a new in-memory caching method.
        /// </summary>
        /// <param name="garbageCollectionTimeout">The timeout of the garbage collector in milliseconds. Defaults to 5 minutes.</param>
        public MemoryCacheMethod(int garbageCollectionTimeout)
        {
            this.gcTimer = new Timer(state => this.CollectGarbage(), null, garbageCollectionTimeout, garbageCollectionTimeout);
        }

        private void CollectGarbage()
        {
            var now = DateTimeOffset.Now;
            foreach (string category in this.cachedItems.Keys.ToArray())
            {
                if (!this.cachedItems.TryGetValue(category, out var cache))
                    continue;

                Collect(now, cache);

                if (cache.Count == 0)
                    this.cachedItems.TryRemove(category, out _);
            }

            static void Collect(DateTimeOffset now, ConcurrentDictionary<string, CacheItem> cache)
            {
                foreach (string key in cache.Keys.ToArray())
                {
                    if (!cache.TryGetValue(key, out var item))
                        continue;

                    if (item.ExpiryTime <= now)
                        cache.TryRemove(key, out _);
                }
            }
        }

        #region BaseCacheMethod overrides

        /// <inheritdoc />
        public override Task<CacheItem?> TryGetAsync(string category, string id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (this.cachedItems.TryGetValue(category, out var cache) &&
                cache.TryGetValue(id, out var item) &&
                item.ExpiryTime > DateTimeOffset.Now)
                return Task.FromResult<CacheItem?>(CopyCacheItemWithStatus(item, CacheItemStatus.Cached));

            return Task.FromResult<CacheItem?>(null);
        }

        /// <inheritdoc />
        public override Task SetAsync(CacheItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.ExpiryTime > DateTimeOffset.Now)
            {
                var cache = this.cachedItems.GetOrAdd(item.Category, new ConcurrentDictionary<string, CacheItem>());
                cache[item.Id] = item;
            }
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override Task<IList<CacheItem>> GetManyAsync(string category, IEnumerable<string> ids)
        {
            // Override for list optimizations

            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            if (!this.cachedItems.TryGetValue(category, out var cache))
                return Task.FromResult<IList<CacheItem>>(Array.Empty<CacheItem>());

            var items = ids
                .Select(id => cache.TryGetValue(id, out var obj) ? obj : null)
                .Where(x => x?.ExpiryTime > DateTimeOffset.Now)
                .WhereNotNull()
                .ToList();
            return Task.FromResult<IList<CacheItem>>(items.Select(x => CopyCacheItemWithStatus(x, CacheItemStatus.Cached)).ToList());
        }

        /// <inheritdoc />
        public override Task ClearAsync()
        {
            this.cachedItems.Clear();
            return Task.CompletedTask;
        }

        private bool isDisposed = false; // To detect redundant calls


        private static CacheItem CopyCacheItemWithStatus(CacheItem item, CacheItemStatus status) => item.Type switch
        {
            CacheItemType.Raw => new CacheItem(item.Category, item.Id, item.RawItem, item.StatusCode, item.ExpiryTime, status, item.Metadata?.ShallowCopy()),
            CacheItemType.String => new CacheItem(item.Category, item.Id, item.StringItem, item.StatusCode, item.ExpiryTime, status, item.Metadata?.ShallowCopy()),

            // Should not happen
            _ => throw new NotSupportedException("Unsupported cache type")
        };


        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                    this.gcTimer.Dispose();

                base.Dispose(isDisposing);
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
