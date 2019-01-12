using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public abstract class BaseCacheMethodTests
    {
        protected ICacheMethod cacheMethod;

        [Fact]
        public async Task CategoryDoesNotExistTest()
        {
            Assert.False(await this.cacheMethod.Has<int>("unknown", "unknown"));
            Assert.Null(await this.cacheMethod.GetOrNull<int>("unknown", "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.cacheMethod.Get<int>("unknown", "unknown"));
        }

        [Fact]
        public async Task FlushTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.Set(cacheItem);
            Assert.True(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Equal(cacheItem, await this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));

            await this.cacheMethod.Flush();
            Assert.False(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.cacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            Assert.Empty(await this.cacheMethod.GetMany<int>("Test category", new[] { "test1", "test2", "test3" }));
        }

        [Fact]
        public async Task GetManyWithoutExpiredTest()
        {
            string category = "Test category";
            var cacheItems = new[]
            {
                new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)),
                new CacheItem<int>(category, "test2", 84, DateTime.Now.AddSeconds(2))
            };

            await this.cacheMethod.SetMany(cacheItems);
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.Has<int>(i.Category, i.Id)), Assert.True);
            await Task.Delay(2000);

            Assert.Equal(cacheItems.Where(i => i.ExpiryTime > DateTime.Now),
                (await this.cacheMethod.GetMany<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
        }

        [Fact]
        public async Task GetOrUpdateManyTest()
        {
            string category = "Test category";
            var date = DateTime.Now.AddMinutes(30);
            var cacheItems = new[]
            {
                new CacheItem<int>(category, "test", 42, date),
                new CacheItem<int>(category, "test2", 84, date),
                new CacheItem<int>(category, "test3", 168, date)
            };

            await this.cacheMethod.GetOrUpdateMany(category, cacheItems.Select(x => x.Id), date, missingIds =>
            {
                Assert.Equal(cacheItems.Select(x => x.Id), missingIds);
                return Task.FromResult<IDictionary<object, int>>(cacheItems.ToDictionary(x => x.Id, x => x.Item));
            });
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.Has<int>(i.Category, i.Id)), Assert.True);
            Assert.Equal(cacheItems, (await this.cacheMethod.GetMany<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
        }

        [Fact]
        public async Task GetOrUpdateGetTest()
        {
            string category = "Test category";
            string id = "test";
            int item = 42;

            await this.cacheMethod.Set(category, id, item, DateTime.Now.AddMinutes(30));
            Assert.True(await this.cacheMethod.Has<int>(category, id));
            Assert.Equal(item, (await this.cacheMethod.GetOrUpdate<int>(category, id, DateTime.Now.AddMinutes(30), () => throw new Exception("Should not be called"))).Item);
        }

        [Fact]
        public async Task GetOrUpdateUpdateTest()
        {
            string category = "Test category";
            string id = "test";

            await this.cacheMethod.GetOrUpdate(category, id, DateTime.Now.AddMinutes(30), () => Task.FromResult(42));
            Assert.True(await this.cacheMethod.Has<int>(category, id));
            Assert.Equal(42, (await this.cacheMethod.Get<int>(category, id)).Item);
        }

        [Fact]
        public async Task IdDoesNotExistTest()
        {
            string category = "Test category";

            await this.cacheMethod.Set(new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30)));
            Assert.False(await this.cacheMethod.Has<int>(category, "unknown"));
            Assert.Null(await this.cacheMethod.GetOrNull<int>(category, "unknown"));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.cacheMethod.Get<int>(category, "unknown"));
        }

        [Fact]
        public async Task StoreExpiredTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddMinutes(-30));

            await this.cacheMethod.Set(cacheItem);
            Assert.False(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.cacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task StoreExpiresSoonTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddSeconds(2));

            await this.cacheMethod.Set(cacheItem);
            Assert.True(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Equal(cacheItem, await this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));

            await Task.Delay(2000);

            Assert.False(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Null(await this.cacheMethod.GetOrNull<int>(cacheItem.Category, cacheItem.Id));
            await Assert.ThrowsAsync<KeyNotFoundException>(() => this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
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

            await this.cacheMethod.SetMany(cacheItems);
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.Has<int>(i.Category, i.Id)), Assert.True);
            Assert.Equal(cacheItems, (await this.cacheMethod.GetMany<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
        }

        [Fact]
        public async Task StoreValidTest()
        {
            string category = "Test category";
            var cacheItem = new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.Set(cacheItem);
            Assert.True(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Equal(cacheItem, await this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));

            cacheItem = new CacheItem<int>(category, "test2", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.Set(cacheItem.Category, cacheItem.Id, cacheItem.Item, cacheItem.ExpiryTime);
            Assert.True(await this.cacheMethod.Has<int>(cacheItem.Category, cacheItem.Id));
            Assert.Equal(cacheItem, await this.cacheMethod.Get<int>(cacheItem.Category, cacheItem.Id));
        }

        #region ArgumentNullException tests

        [Fact]
        public async Task ArgumentNullHasTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.Has<object>("Test category", "test"),
                new[] { true, true });
        }

        [Fact]
        public async Task ArgumentNullGetTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.Get<object>("Test category", "test"),
                new[] { true, true });
        }

        [Fact]
        public async Task ArgumentNullGetManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetMany<object>("Test category", new List<object>()),
                new[] { true, true });
        }

        [Fact]
        public async Task ArgumentNullSetTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.Set(new CacheItem<object>("Test category", "test", new object(), DateTime.Now)),
                new[] { true });
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.Set("Test category", "test", new object(), DateTime.Now),
                new[] { true, true, false, false });
        }

        [Fact]
        public async Task ArgumentNullSetManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetMany(new List<CacheItem<object>>()),
                new[] { true });
        }

        [Fact]
        public async Task ArgumentNullGetOrUpdateTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdate("Test category", "test", DateTime.Now, () => Task.FromResult(new object())),
                new[] { true, true, false, true });
        }

        [Fact]
        public async Task ArgumentNullGetOrUpdateManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateMany("Test category", new List<object>(), DateTime.Now, obj => Task.FromResult((IDictionary<object, object>)new Dictionary<object, object>())),
                new[] { true, true, false, true });
        }

        #endregion
    }
}
