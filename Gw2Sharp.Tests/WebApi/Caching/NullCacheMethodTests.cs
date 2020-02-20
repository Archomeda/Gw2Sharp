using System;
using System.Linq;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class NullCacheMethodTests
    {
        protected NullCacheMethod cacheMethod = new NullCacheMethod();

        [Fact]
        public async Task CategoryDoesNotExistTest()
        {
            Assert.Null(await this.cacheMethod.TryGetAsync<int>("unknown", "unknown"));
        }

        [Fact]
        public async Task FlushTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            await this.cacheMethod.ClearAsync();
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            Assert.Empty(await this.cacheMethod.GetManyAsync<int>("Test category", new[] { "test1", "test2", "test3" }));
        }

        [Fact]
        public async Task IdDoesNotExistTest()
        {
            string category = "Test category";

            await this.cacheMethod.SetAsync(new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)));
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(category, "unknown"));
        }

        [Fact]
        public async Task StoreExpiredTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(-30));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task StoreManyTest()
        {
            string category = "Test category";
            var cacheItems = new[]
            {
                new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)),
                new CacheItem<int>(category, "test2", 84, DateTime.Now.AddMinutes(30)),
                new CacheItem<int>(category, "test3", 168, DateTime.Now.AddMinutes(30))
            };

            await this.cacheMethod.SetManyAsync(cacheItems);
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItems[0].Category, cacheItems[0].Id));
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItems[1].Category, cacheItems[1].Id));
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItems[2].Category, cacheItems[2].Id));
            Assert.Empty(await this.cacheMethod.GetManyAsync<int>(category, cacheItems.Select(x => x.Id)));
        }

        [Fact]
        public async Task StoreValidTest()
        {
            string category = "Test category";
            var cacheItem = new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            await this.cacheMethod.SetAsync(cacheItem.Category, cacheItem.Id, cacheItem.Item, cacheItem.ExpiryTime);
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }
    }
}
