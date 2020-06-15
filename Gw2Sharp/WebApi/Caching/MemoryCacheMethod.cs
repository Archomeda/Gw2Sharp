using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A in-memory caching method.
    /// </summary>
    public class MemoryCacheMethod : BaseCacheMethod
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, object>> cachedItems = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

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

            static void Collect(DateTimeOffset now, ConcurrentDictionary<string, object> cache)
            {
                foreach (string key in cache.Keys.ToArray())
                {
                    if (!cache.TryGetValue(key, out var obj))
                        continue;

                    var item = (CacheItem)obj;
                    if (item.ExpiryTime <= now)
                        cache.TryRemove(key, out _);
                }
            }
        }

        #region BaseCacheController overrides

        /// <inheritdoc />
        public override Task<CacheItem<T>?> TryGetAsync<T>(string category, string id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return ExecAsync();

            async Task<CacheItem<T>?> ExecAsync()
            {
                if (this.cachedItems.TryGetValue(category, out var cache) &&
                    cache.TryGetValue(id, out var obj) &&
                    obj is CacheItem<T> item &&
                    item.ExpiryTime > DateTimeOffset.Now)
                    return item;
                else
                    return null;
            }
        }

        /// <inheritdoc />
        public override Task SetAsync<T>(CacheItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.ExpiryTime > DateTimeOffset.Now)
            {
                var cache = this.cachedItems.GetOrAdd(item.Category, new ConcurrentDictionary<string, object>());
                cache[item.Id] = item;
            }
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override Task<IDictionary<string, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<string> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            return ExecAsync();

            async Task<IDictionary<string, CacheItem<T>>> ExecAsync()
            {
                var items = new Dictionary<string, CacheItem<T>>();
                if (this.cachedItems.TryGetValue(category, out var cache))
                    items = ids
                        .Select(id => cache.TryGetValue(id, out var obj) ? obj : null)
                        .Where(x => x is CacheItem<T> item && item.ExpiryTime > DateTimeOffset.Now)
                        .Cast<CacheItem<T>>()
                        .ToDictionary(x => x.Id);
                return items;
            }
        }

        /// <inheritdoc />
        public override async Task ClearAsync() =>
            this.cachedItems.Clear();

        private bool isDisposed = false; // To detect redundant calls

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
