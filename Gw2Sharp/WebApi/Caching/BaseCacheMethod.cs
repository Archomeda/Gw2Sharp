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
        /// <inheritdoc />
        public abstract Task<bool> HasAsync<T>(string category, object id) where T : object;

        /// <inheritdoc />
        public virtual async Task<CacheItem<T>> GetAsync<T>(string category, object id) where T : object =>
            await this.GetOrNullAsync<T>(category, id) ?? throw new KeyNotFoundException($"Cache item '{id}' in category '{category}' doesn't exist.");

        /// <inheritdoc />
        public abstract Task<CacheItem<T>?> GetOrNullAsync<T>(string category, object id) where T : object;

        /// <inheritdoc />
        public abstract Task SetAsync<T>(CacheItem<T> item) where T : object;

        /// <inheritdoc />
        public virtual Task SetAsync<T>(string category, object id, T item, DateTime expiryTime) where T : object
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.SetAsync(new CacheItem<T>(category, id, item, expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids) where T : object
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var cache = new Dictionary<object, CacheItem<T>>();
            foreach (object id in ids)
                cache[id] = await this.GetAsync<T>(category, id).ConfigureAwait(false);
            return cache;
        }

        /// <inheritdoc />
        public virtual async Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items) where T : object
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                await this.SetAsync(item).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, DateTime expiryTime, Func<Task<T>> updateFunc) where T : object
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateAsync(category, id, async () => (await updateFunc().ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, Func<Task<(T, DateTime)>> updateFunc) where T : object
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            try
            {
                return await this.GetAsync<T>(category, id).ConfigureAwait(false);
            }
            catch (KeyNotFoundException)
            {
                var (item, expiryTime) = await updateFunc().ConfigureAwait(false);
                var cache = new CacheItem<T>(category, id, item, expiryTime);
                await this.SetAsync(cache).ConfigureAwait(false);
                return cache;
            }
        }

        /// <inheritdoc />
        public virtual Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            DateTime expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc) where T : object
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateManyAsync(category, ids, async list => (await updateFunc(list).ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual async Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTime)>> updateFunc) where T : object
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            var idsList = ids as IList<object> ?? ids.ToList();

            var cache = await this.GetManyAsync<T>(category, idsList).ConfigureAwait(false) ?? new Dictionary<object, CacheItem<T>>();
            IList<object> missing = idsList.Except(cache.Keys).ToList();

            if (missing.Count > 0)
            {
                var (newItems, expiryTime) = await updateFunc(missing).ConfigureAwait(false);
                IList<CacheItem<T>> newCacheItems = newItems.Select(x => new CacheItem<T>(category, x.Key, x.Value, expiryTime)).ToList();
                await this.SetManyAsync(newCacheItems).ConfigureAwait(false);
                foreach (var item in newCacheItems)
                    cache[item.Id] = item;
            }

            // Return in the same order as requested
            return idsList.Select(x => cache[x]).ToList();
        }

        /// <inheritdoc />
        public abstract Task FlushAsync();

        /// <inheritdoc />
        public void Dispose() => this.Dispose(true);

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="isDisposing">Dispose unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing) { }
    }
}
