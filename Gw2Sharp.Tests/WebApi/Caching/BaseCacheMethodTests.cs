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
        protected ICacheMethod cacheMethod = null!;

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
            Assert.Equal(cacheItem, await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            await this.cacheMethod.FlushAsync();
            Assert.Null(await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            Assert.Empty(await this.cacheMethod.GetManyAsync<int>("Test category", new[] { "test1", "test2", "test3" }));
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

            await this.cacheMethod.SetManyAsync(cacheItems);
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<int>(i.Category, i.Id) != null), Assert.True);
            await Task.Delay(2000);

            Assert.Equal(cacheItems.Where(i => i.ExpiryTime > DateTime.Now),
                (await this.cacheMethod.GetManyAsync<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
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

            await this.cacheMethod.GetOrUpdateManyAsync(category, cacheItems.Select(x => x.Id), date, missingIds =>
            {
                Assert.Equal(cacheItems.Select(x => x.Id), missingIds);
                return Task.FromResult<IDictionary<object, int>>(cacheItems.ToDictionary(x => x.Id, x => x.Item));
            });
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<int>(i.Category, i.Id) != null), Assert.True);
            Assert.Equal(cacheItems, (await this.cacheMethod.GetManyAsync<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
        }

        [Fact]
        public async Task GetOrUpdateGetTest()
        {
            string category = "Test category";
            string id = "test";
            int item = 42;

            await this.cacheMethod.SetAsync(category, id, item, DateTime.Now.AddMinutes(30));
            Assert.Equal(item, (await this.cacheMethod.GetOrUpdateAsync<int>(category, id, DateTime.Now.AddMinutes(30), () => throw new Exception("Should not be called"))).Item);
        }

        [Fact]
        public async Task GetOrUpdateUpdateTest()
        {
            string category = "Test category";
            string id = "test";

            await this.cacheMethod.GetOrUpdateAsync(category, id, DateTime.Now.AddMinutes(30), () => Task.FromResult(42));
            Assert.Equal(42, (await this.cacheMethod.TryGetAsync<int>(category, id))?.Item);
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
        public async Task StoreExpiresSoonTest()
        {
            var cacheItem = new CacheItem<int>("Test category", "test", 42, DateTime.Now.AddSeconds(1.5));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Equal(cacheItem, await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            await Task.Delay(2000);

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
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<int>(i.Category, i.Id) != null), Assert.True);
            Assert.Equal(cacheItems, (await this.cacheMethod.GetManyAsync<int>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value));
        }

        [Fact]
        public async Task StoreValidTest()
        {
            string category = "Test category";
            var cacheItem = new CacheItem<int>(category, "test", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.SetAsync(cacheItem);
            Assert.Equal(cacheItem, await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));

            cacheItem = new CacheItem<int>(category, "test2", 42, DateTime.Now.AddMinutes(30));

            await this.cacheMethod.SetAsync(cacheItem.Category, cacheItem.Id, cacheItem.Item, cacheItem.ExpiryTime);
            Assert.Equal(cacheItem, await this.cacheMethod.TryGetAsync<int>(cacheItem.Category, cacheItem.Id));
        }

        #region ArgumentNullException tests

        [Fact]
        public async Task ArgumentNullGetTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.TryGetAsync<object>("Test category", "test"),
                new[] { true, true });
        }

        [Fact]
        public async Task ArgumentNullGetManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetManyAsync<object>("Test category", new List<object>()),
                new[] { true, true });
        }

        [Fact]
        public async Task ArgumentNullSetTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetAsync(new CacheItem<object>("Test category", "test", new object(), DateTime.Now)),
                new[] { true });
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetAsync("Test category", "test", new object(), DateTime.Now),
                new[] { true, true, false, false });
        }

        [Fact]
        public async Task ArgumentNullSetManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetManyAsync(new List<CacheItem<object>>()),
                new[] { true });
        }

        [Fact]
        public async Task ArgumentNullGetOrUpdateTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateAsync("Test category", "test", DateTime.Now, () => Task.FromResult(new object())),
                new[] { true, true, false, true });
        }

        [Fact]
        public async Task ArgumentNullGetOrUpdateManyTest()
        {
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateManyAsync("Test category", new List<object>(), DateTime.Now, obj => Task.FromResult((IDictionary<object, object>)new Dictionary<object, object>())),
                new[] { true, true, false, true });
        }

        #endregion
    }
}
