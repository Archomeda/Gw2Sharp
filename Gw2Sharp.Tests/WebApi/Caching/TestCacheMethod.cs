using System.Collections.Generic;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class TestCacheMethod : BaseCacheMethod
    {
        private readonly Dictionary<string, CacheItem> cacheItems = new Dictionary<string, CacheItem>();

        public IReadOnlyDictionary<string, CacheItem> CacheItems => this.cacheItems;


        public override Task<CacheItem?> TryGetAsync(string category, string id)
        {
            var item = this.cacheItems.TryGetValue($"{category}_{id}", out var result) ? result : null;
            return Task.FromResult(item);
        }

        public override Task SetAsync(CacheItem item)
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
