using System;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class MemoryCacheMethodTests : BaseCacheMethodTests
    {
        public MemoryCacheMethodTests()
        {
            this.cacheMethod = new MemoryCacheMethod();
        }

        [Fact]
        public async Task TriggersGarbageCollectionTest()
        {
            this.cacheMethod = new MemoryCacheMethod(1000);
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddSeconds(2));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Equal(cacheItem, await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            await Task.Delay(5000);

            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }
    }
}
