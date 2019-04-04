using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class NullCacheMethodTests
    {
        protected NullCacheMethod CacheMethod = new NullCacheMethod();

        [Fact]
        public async Task CategoryDoesNotExistTest()
        {
            Assert.False(await this.CacheMethod.HasAsync<int>("unknown", "unknown"));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>("unknown", "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>("unknown", "unknown"));
        }

        [Fact]
        public async Task FlushTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(30));

            await this.CacheMethod.SetAsync(cacheItem);
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(cacheItem.Category, cacheItem.Id));

            await this.CacheMethod.FlushAsync();
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            Assert.Empty(await this.CacheMethod.GetManyAsync<int>("Test category", new[] { "test1", "test2", "test3" }));
        }

        [Fact]
        public async Task IdDoesNotExistTest()
        {
            string category = "Test category";

            await this.CacheMethod.SetAsync(new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)));
            Assert.False(await this.CacheMethod.HasAsync<int>(category, "unknown"));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(category, "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(category, "unknown"));
        }

        [Fact]
        public async Task StoreExpiredTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(-30));

            await this.CacheMethod.SetAsync(cacheItem);
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(cacheItem.Category, cacheItem.Id));
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

            await this.CacheMethod.SetManyAsync(cacheItems);
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItems[0].Category, cacheItems[0].Id));
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItems[1].Category, cacheItems[1].Id));
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItems[2].Category, cacheItems[2].Id));
            Assert.Empty(await this.CacheMethod.GetManyAsync<int>(category, cacheItems.Select(x => x.Id)));
        }

        [Fact]
        public async Task StoreValidTest()
        {
            string category = "Test category";
            var cacheItem = new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30));

            await this.CacheMethod.SetAsync(cacheItem);
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(cacheItem.Category, cacheItem.Id));

            await this.CacheMethod.SetAsync(cacheItem.Category, cacheItem.Id, cacheItem.Item, cacheItem.ExpiryTime);
            Assert.False(await this.CacheMethod.HasAsync<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNullAsync<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.GetAsync<int>(cacheItem.Category, cacheItem.Id));
        }
    }
}
