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
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<object, object>> cachedItems = new ConcurrentDictionary<string, ConcurrentDictionary<object, object>>();

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
            var now = DateTime.Now;
            foreach (string category in this.cachedItems.Keys.ToArray())
            {
                if (!this.cachedItems.TryGetValue(category, out var cache))
                    continue;

                this.CollectInnerGarbage(now, cache);

                if (cache.Count == 0)
                    this.cachedItems.TryRemove(category, out _);
            }
        }

        private void CollectInnerGarbage(DateTime now, ConcurrentDictionary<object, object> cache)
        {
            foreach (object key in cache.Keys.ToArray())
            {
                if (!cache.TryGetValue(key, out object obj))
                    continue;

                var item = (CacheItem)obj;
                if (item.ExpiryTime <= now)
                    cache.TryRemove(key, out _);
            }
        }

        #region BaseCacheController overrides

        /// <inheritdoc />
        public override Task<CacheItem<T>?> TryGetAsync<T>(string category, object id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.TryGetInternalAsync<T>(category, id);
        }

        private async Task<CacheItem<T>?> TryGetInternalAsync<T>(string category, object id) where T : object
        {
            return this.cachedItems.TryGetValue(category, out var cache) &&
                 cache.TryGetValue(id, out object obj) &&
                 obj is CacheItem<T> item &&
                 item.ExpiryTime > DateTime.Now
                 ? item : null;
        }

        /// <inheritdoc />
        public override Task SetAsync<T>(CacheItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return item.ExpiryTime <= DateTime.Now ? Task.CompletedTask : this.SetInternalAsync(item);
        }

        private async Task SetInternalAsync<T>(CacheItem<T> item) where T : object
        {
            var cache = this.cachedItems.GetOrAdd(item.Category, new ConcurrentDictionary<object, object>());
            cache[item.Id] = item;
        }

        /// <inheritdoc />
        public override Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return this.GetManyInternalAsync<T>(category, ids);
        }

        private async Task<IDictionary<object, CacheItem<T>>> GetManyInternalAsync<T>(string category, IEnumerable<object> ids) where T : object
        {
            var items = new Dictionary<object, CacheItem<T>>();
            if (this.cachedItems.TryGetValue(category, out var cache))
            {
                items = ids
                    .Select(id => cache.TryGetValue(id, out object obj) ? obj : null)
                    .Where(x => x is CacheItem<T> item && item.ExpiryTime > DateTime.Now)
                    .Cast<CacheItem<T>>()
                    .ToDictionary(x => x.Id);
            }
            return items;
        }

        /// <inheritdoc />
        public override async Task FlushAsync() =>
            this.cachedItems.Clear();

        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            this.gcTimer.Dispose();
            base.Dispose(isDisposing);
        }

        #endregion
    }
}
