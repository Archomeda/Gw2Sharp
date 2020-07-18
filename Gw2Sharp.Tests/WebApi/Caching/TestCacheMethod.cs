using System.Collections.Generic;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class TestCacheMethod : BaseCacheMethod
    {
        private readonly Dictionary<string, object> cacheItems = new Dictionary<string, object>();

        public IReadOnlyDictionary<string, object> CacheItems => this.cacheItems;


        public override Task<CacheItem<T>?> TryGetAsync<T>(string category, string id)
        {
            if (this.cacheItems.TryGetValue($"{category}_{id}", out var result))
                return Task.FromResult((CacheItem<T>)result);
            return Task.FromResult(default(CacheItem<T>));
        }

        public override Task SetAsync<T>(CacheItem<T> item)
        {
            this.cacheItems[$"{item.Category}_{item.Id}"] = item;
            return Task.CompletedTask;
        }

        public override Task ClearAsync()
        {
            this.cacheItems.Clear();
            return Task.CompletedTask;
        }
    }
}
