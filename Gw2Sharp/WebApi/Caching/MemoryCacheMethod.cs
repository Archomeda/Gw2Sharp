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

                foreach (string key in cache.Keys.ToArray())
                {
                    if (!cache.TryGetValue(key, out object obj))
                        continue;

                    var item = (CacheItem)obj;
                    if (item.ExpiryTime <= now)
                    {
                        while (!cache.TryRemove(key, out _))
                            Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    }
                }

                if (cache.Count == 0)
                {
                    while (!this.cachedItems.TryRemove(category, out _))
                        Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
        }

        #region BaseCacheController overrides

        /// <inheritdoc />
        public override async Task<bool> HasAsync<T>(string category, object id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.cachedItems.TryGetValue(category, out var cache) &&
                cache.TryGetValue(id, out object obj) &&
                obj is CacheItem<T> item &&
                item.ExpiryTime > DateTime.Now;
        }

        /// <inheritdoc />
        public override async Task<CacheItem<T>?> GetOrNullAsync<T>(string category, object id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.cachedItems.TryGetValue(category, out var cache) &&
                cache.TryGetValue(id, out object obj) &&
                obj is CacheItem<T> item &&
                item.ExpiryTime > DateTime.Now
                ? item : null;
        }

        /// <inheritdoc />
        public override async Task SetAsync<T>(CacheItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.ExpiryTime <= DateTime.Now)
                return;

            var cache = this.cachedItems.GetOrAdd(item.Category, new ConcurrentDictionary<object, object>());
            cache[item.Id] = item;
        }

        /// <inheritdoc />
        public override async Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var items = new Dictionary<object, CacheItem<T>>();
            if (this.cachedItems.TryGetValue(category, out var cache))
            {
                foreach (object id in ids)
                {
                    if (await this.HasAsync<T>(category, id) && cache.TryGetValue(id, out object obj) && obj is CacheItem<T> item)
                        items.Add(id, item);
                }
            }
            return items;
        }

        /// <inheritdoc />
        public override async Task FlushAsync() =>
            this.cachedItems.Clear();

        /// <inheritdoc />
        protected override void Dispose(bool disposing) =>
            this.gcTimer.Dispose();

        #endregion
    }
}
