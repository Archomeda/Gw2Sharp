using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A in-memory caching method.
    /// </summary>
    public class MemoryCacheMethod : BaseCacheMethod
    {
        private readonly Dictionary<string, Dictionary<object, object>> cachedItems = new Dictionary<string, Dictionary<object, object>>();

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
            DateTime now = DateTime.Now;
            foreach (string category in this.cachedItems.Keys.ToArray())
            {
                foreach (string key in this.cachedItems[category].Keys.ToArray())
                {
                    var item = (CacheItem)this.cachedItems[category][key];
                    if (item.ExpiryTime <= now)
                        this.cachedItems[category].Remove(key);
                }

                if (this.cachedItems[category].Count == 0)
                    this.cachedItems.Remove(category);
            }
        }

        #region BaseCacheController overrides

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            this.gcTimer.Dispose();
        }

        /// <inheritdoc />
        public override Task<bool> Has<T>(string category, object id)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (id == null) throw new ArgumentNullException(nameof(id));

            if (!this.cachedItems.ContainsKey(category) || !this.cachedItems[category].ContainsKey(id))
                return Task.FromResult(false);

            var item = this.cachedItems[category][id] as CacheItem<T>;
            return Task.FromResult(item.ExpiryTime > DateTime.Now);
        }

        /// <inheritdoc />
        public override Task<CacheItem<T>> Get<T>(string category, object id)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (id == null) throw new ArgumentNullException(nameof(id));

            if (!this.cachedItems.ContainsKey(category) || !this.cachedItems[category].ContainsKey(id))
                return Task.FromResult<CacheItem<T>>(null);

            var result = this.cachedItems[category][id] as CacheItem<T>;
            return result.ExpiryTime > DateTime.Now ? Task.FromResult(result) : Task.FromResult<CacheItem<T>>(null);
        }

        /// <inheritdoc />
        public override Task Set<T>(CacheItem<T> item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (item.ExpiryTime <= DateTime.Now)
                return Task.FromResult<object>(null);

            if (!this.cachedItems.ContainsKey(item.Category))
                this.cachedItems.Add(item.Category, new Dictionary<object, object>());

            this.cachedItems[item.Category][item.Id] = item;
            return Task.FromResult<object>(null);
        }

        /// <inheritdoc />
        public override Task<IDictionary<object, CacheItem<T>>> GetMany<T>(string category, IEnumerable<object> ids)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (ids == null) throw new ArgumentNullException(nameof(ids));

            if (!this.cachedItems.ContainsKey(category))
                return Task.FromResult<IDictionary<object, CacheItem<T>>>(new Dictionary<object, CacheItem<T>>());

            IDictionary<object, CacheItem<T>> result = ids
                .Where(x => x != null)
                .Where(x => ((CacheItem<T>)this.cachedItems[category][x]).ExpiryTime > DateTime.Now)
                .Where(x => this.cachedItems[category].ContainsKey(x))
                .ToDictionary(x => x, x => (CacheItem<T>)this.cachedItems[category][x]);
            return Task.FromResult(result);
        }

        /// <inheritdoc />
        public override Task Flush()
        {
            this.cachedItems.Clear();
            return Task.FromResult<object>(null);
        }

        #endregion
    }
}
