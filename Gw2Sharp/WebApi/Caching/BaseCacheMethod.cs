using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// Provides basic implementation for non-standard methods in a cache method.
    /// </summary>
    public abstract class BaseCacheMethod : ICacheMethod
    {
        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="isDisposing">Dispose unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing) { }

        /// <inheritdoc />
        public void Dispose() => this.Dispose(true);

        /// <inheritdoc />
        public abstract Task<bool> Has<T>(string category, object id);

        /// <inheritdoc />
        public abstract Task<CacheItem<T>> Get<T>(string category, object id);

        /// <inheritdoc />
        public abstract Task Set<T>(CacheItem<T> item);

        /// <inheritdoc />
        public virtual Task Set<T>(string category, object id, T item, DateTime expiryTime)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (id == null) throw new ArgumentNullException(nameof(id));

            return this.Set(new CacheItem<T>(category, id, item, expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<IDictionary<object, CacheItem<T>>> GetMany<T>(string category, IEnumerable<object> ids)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (ids == null) throw new ArgumentNullException(nameof(ids));

            var cache = new Dictionary<object, CacheItem<T>>();
            foreach (object id in ids)
                cache[id] = await this.Get<T>(category, id).ConfigureAwait(false);
            return cache;
        }

        /// <inheritdoc />
        public virtual async Task SetMany<T>(IEnumerable<CacheItem<T>> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                await this.Set(item).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CacheItem<T>> GetOrUpdate<T>(string category, object id, DateTime expiryTime, Func<Task<T>> updateFunc)
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));
            return this.GetOrUpdate(category, id, async () => (await updateFunc().ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<CacheItem<T>> GetOrUpdate<T>(string category, object id, Func<Task<(T, DateTime)>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            var cache = await this.Get<T>(category, id).ConfigureAwait(false);
            if (cache != null)
                return cache;

            var (item, expiryTime) = await updateFunc().ConfigureAwait(false);
            cache = new CacheItem<T>(category, id, item, expiryTime);
            await this.Set(cache).ConfigureAwait(false);
            return cache;
        }

        /// <inheritdoc />
        public virtual Task<IList<CacheItem<T>>> GetOrUpdateMany<T>(
            string category, 
            IEnumerable<object> ids, 
            DateTime expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc)
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));
            return this.GetOrUpdateMany(category, ids, async list => (await updateFunc(list).ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<IList<CacheItem<T>>> GetOrUpdateMany<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTime)>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            var idsList = ids as IList<object> ?? ids.ToList();

            var cache = await this.GetMany<T>(category, idsList).ConfigureAwait(false) ?? new Dictionary<object, CacheItem<T>>();
            IList<object> missing = idsList.Except(cache.Keys).ToList();

            if (missing.Count > 0)
            {
                var (newItems, expiryTime) = await updateFunc(missing).ConfigureAwait(false);
                IList<CacheItem<T>> newCacheItems = newItems.Select(x => new CacheItem<T>(category, x.Key, x.Value, expiryTime)).ToList();
                await this.SetMany(newCacheItems).ConfigureAwait(false);
                foreach (var item in newCacheItems)
                    cache[item.Id] = item;
            }

            // Return in the same order as requested
            return idsList.Select(x => cache[x]).ToList();
        }

        /// <inheritdoc />
        public abstract Task Flush();
    }
}
