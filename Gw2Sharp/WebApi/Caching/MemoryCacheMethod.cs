using System;
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
            var now = DateTime.Now;
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
        public override async Task<bool> HasAsync<T>(string category, object id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.cachedItems.ContainsKey(category) &&
                this.cachedItems[category].ContainsKey(id) &&
                this.cachedItems[category][id] is CacheItem<T> item &&
                item.ExpiryTime > DateTime.Now;
        }

        /// <inheritdoc />
        public override async Task<CacheItem<T>?> GetOrNullAsync<T>(string category, object id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await this.HasAsync<T>(category, id) ? (CacheItem<T>)this.cachedItems[category][id] : null;
        }

        /// <inheritdoc />
        public override async Task SetAsync<T>(CacheItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.ExpiryTime <= DateTime.Now)
                return;

            if (!this.cachedItems.ContainsKey(item.Category))
                this.cachedItems.Add(item.Category, new Dictionary<object, object>());

            this.cachedItems[item.Category][item.Id] = item;
        }

        /// <inheritdoc />
        public override async Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var items = new Dictionary<object, CacheItem<T>>();
            if (this.cachedItems.ContainsKey(category))
            {
                foreach (object id in ids)
                    if (await this.HasAsync<T>(category, id))
                        items.Add(id, (CacheItem<T>)this.cachedItems[category][id]);
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
