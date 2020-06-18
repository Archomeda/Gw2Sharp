using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// Provides basic implementation for non-standard methods in a cache method.
    /// </summary>
    public abstract class BaseCacheMethod : ICacheMethod
    {
        /// <inheritdoc />
        public abstract Task<CacheItem<T>?> TryGetAsync<T>(string category, object id);

        /// <inheritdoc />
        public abstract Task SetAsync<T>(CacheItem<T> item);

        /// <inheritdoc />
        public virtual Task SetAsync<T>(string category, object id, T item, DateTimeOffset expiryTime)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return this.SetAsync(new CacheItem<T>(category, id, item, expiryTime));
        }

        /// <inheritdoc />
        public virtual Task<IDictionary<object, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<object> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return this.GetManyInternalAsync<T>(category, ids);
        }

        private async Task<IDictionary<object, CacheItem<T>>> GetManyInternalAsync<T>(string category, IEnumerable<object> ids)
        {
            var cache = new Dictionary<object, CacheItem<T>>();
            foreach (object id in ids)
            {
                var cacheItem = await this.TryGetAsync<T>(category, id).ConfigureAwait(false);
                if (cacheItem != null)
                    cache[id] = cacheItem;
            }
            return cache;
        }

        /// <inheritdoc />
        public virtual Task SetManyAsync<T>(IEnumerable<CacheItem<T>> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            return this.SetManyInternalAsync(items);
        }

        private async Task SetManyInternalAsync<T>(IEnumerable<CacheItem<T>> items)
        {
            foreach (var item in items)
                await this.SetAsync(item).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, DateTimeOffset expiryTime, Func<Task<T>> updateFunc)
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateAsync(category, id, async () => (await updateFunc().ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual Task<CacheItem<T>> GetOrUpdateAsync<T>(string category, object id, Func<Task<(T, DateTimeOffset)>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateInternalAsync(category, id, updateFunc);
        }

        private async Task<CacheItem<T>> GetOrUpdateInternalAsync<T>(string category, object id, Func<Task<(T, DateTimeOffset)>> updateFunc)
        {
            var fItem = await this.TryGetAsync<T>(category, id).ConfigureAwait(false);
            if (fItem != null)
                return fItem;

            var (item, expiryTime) = await updateFunc().ConfigureAwait(false);
            var cache = new CacheItem<T>(category, id, item, expiryTime);
            await this.SetAsync(cache).ConfigureAwait(false);
            return cache;
        }

        /// <inheritdoc />
        public virtual Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            DateTimeOffset expiryTime,
            Func<IList<object>, Task<IDictionary<object, T>>> updateFunc)
        {
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateManyAsync(category, ids, async list => (await updateFunc(list).ConfigureAwait(false), expiryTime));
        }

        /// <inheritdoc />
        public virtual Task<IList<CacheItem<T>>> GetOrUpdateManyAsync<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTimeOffset)>> updateFunc)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            if (updateFunc == null)
                throw new ArgumentNullException(nameof(updateFunc));

            return this.GetOrUpdateManyInternalAsync(category, ids, updateFunc);
        }

        private async Task<IList<CacheItem<T>>> GetOrUpdateManyInternalAsync<T>(
            string category,
            IEnumerable<object> ids,
            Func<IList<object>, Task<(IDictionary<object, T>, DateTimeOffset)>> updateFunc)
        {
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
            return idsList
                .Select(x => cache.TryGetValue(x, out var value) ? value : null)
                .WhereNotNull()
                .ToList();
        }

        /// <inheritdoc />
        public abstract Task ClearAsync();

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="isDisposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool isDisposing) { }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
