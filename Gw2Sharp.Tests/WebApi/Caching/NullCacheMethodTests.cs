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
            Assert.False(await this.CacheMethod.Has<int>("unknown", "unknown"));
            Assert.Null(await this.CacheMethod.GetOrNull<int>("unknown", "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>("unknown", "unknown"));
        }

        [Fact]
        public async Task FlushTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(30));

            await this.CacheMethod.Set(cacheItem);
            Assert.False(await this.CacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));

            await this.CacheMethod.Flush();
            Assert.False(await this.CacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            Assert.Empty(await this.CacheMethod.GetMany<int>("Test category", new[] { "test1", "test2", "test3" }));
        }

        [Fact]
        public async Task IdDoesNotExistTest()
        {
            string category = "Test category";

            await this.CacheMethod.Set(new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)));
            Assert.False(await this.CacheMethod.Has<int>(category, "unknown"));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(category, "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(category, "unknown"));
        }

        [Fact]
        public async Task StoreExpiredTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(-30));

            await this.CacheMethod.Set(cacheItem);
            Assert.False(await this.CacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
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

            await this.CacheMethod.SetMany(cacheItems);
            Assert.False(await this.CacheMethod.Has<int>(cacheItems[0].Category, cacheItems[0].Id));
            Assert.False(await this.CacheMethod.Has<int>(cacheItems[1].Category, cacheItems[1].Id));
            Assert.False(await this.CacheMethod.Has<int>(cacheItems[2].Category, cacheItems[2].Id));
            Assert.Empty(await this.CacheMethod.GetMany<int>(category, cacheItems.Select(x => x.Id)));
        }

        [Fact]
        public async Task StoreValidTest()
        {
            string category = "Test category";
            var cacheItem = new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30));

            await this.CacheMethod.Set(cacheItem);
            Assert.False(await this.CacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));

            await this.CacheMethod.Set(cacheItem.Category, cacheItem.Id, cacheItem.Item, cacheItem.ExpiryTime);
            Assert.False(await this.CacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.CacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.CacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
        }
    }
}
