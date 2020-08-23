using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public abstract class BaseCacheMethodTests
    {
        protected ICacheMethod cacheMethod = null!;

        [Fact]
        public async Task CategoryDoesNotExistTest()
        {
            var actual = await this.cacheMethod.TryGetAsync<string>("unknown", "unknown");
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task FlushTest(WebApiResponse response)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItem = new CacheItem<IWebApiResponse>("Test category", "test", response, expiresAt);

            await this.cacheMethod.SetAsync(cacheItem);
            var actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());

            await this.cacheMethod.ClearAsync();
            actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeNull();
        }

        [Fact]
        public async Task GetManyEmptyTest()
        {
            var actual = await this.cacheMethod.GetManyAsync<string>("Test category", new[] { "test1", "test2", "test3" });
            actual.Should().BeEmpty();
        }

        [Theory]
        [AutoData]
        public async Task GetManyWithoutExpiredTest(WebApiResponse response1, WebApiResponse response2)
        {
            string category = "Test category";
            var cacheItems = new[]
            {
                new CacheItem<IWebApiResponse>(category, "test", response1, 30.Minutes().After(DateTime.Now)),
                new CacheItem<IWebApiResponse>(category, "test2", response2, 1750.Milliseconds().After(DateTime.Now))
            };

            await this.cacheMethod.SetManyAsync(cacheItems);
            var actual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<IWebApiResponse>(i.Category, i.Id)));
            actual.Should().NotContainNulls();
            await Task.Delay(2000);

            var afterExpiryActual = await this.cacheMethod.GetManyAsync<IWebApiResponse>(category, cacheItems.Select(x => x.Id));
            afterExpiryActual.Values.Should().BeEquivalentTo(cacheItems.Where(i => i.ExpiryTime > DateTime.Now), x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateManyTest(WebApiResponse response1, WebApiResponse response2, WebApiResponse response3)
        {
            string category = "Test category";
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItems = new[]
            {
                new CacheItem<IWebApiResponse>(category, "test", response1, expiresAt),
                new CacheItem<IWebApiResponse>(category, "test2", response2, expiresAt),
                new CacheItem<IWebApiResponse>(category, "test3", response3, expiresAt)
            };

            await this.cacheMethod.GetOrUpdateManyAsync(category, cacheItems.Select(x => x.Id), expiresAt, missingIds =>
            {
                missingIds.Should().BeEquivalentTo(cacheItems.Select(x => x.Id));
                return Task.FromResult<IDictionary<string, IWebApiResponse>>(cacheItems.ToDictionary(x => x.Id, x => x.Item));
            });
            var individualActual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<IWebApiResponse>(i.Category, i.Id)));
            individualActual.Should().NotContainNulls();
            var manyActual = await this.cacheMethod.GetManyAsync<IWebApiResponse>(category, cacheItems.Select(x => x.Id));
            manyActual.Values.Should().BeEquivalentTo(cacheItems, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateManyPartlyTest(WebApiResponse response1, WebApiResponse response2, WebApiResponse response3)
        {
            const string CATEGORY = "Test category";
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItems = new[]
            {
                new CacheItem<IWebApiResponse>(CATEGORY, "test", response1, expiresAt),
                new CacheItem<IWebApiResponse>(CATEGORY, "test2", response2, expiresAt),
                new CacheItem<IWebApiResponse>(CATEGORY, "test3", response3, expiresAt)
            };
            var idsToGet = cacheItems.Select(x => x.Id).ToList();
            idsToGet.Add("0");

            // Set the cache items
            await this.cacheMethod.SetManyAsync(cacheItems);

            // Return an empty response to make sure that there's still an item missing, this should not throw any exception
            var actual = await this.cacheMethod.GetOrUpdateManyAsync(CATEGORY, idsToGet, expiresAt, missingIds =>
                Task.FromResult<IDictionary<string, IWebApiResponse>>(new Dictionary<string, IWebApiResponse>()));

            actual.Should().BeEquivalentTo(cacheItems, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateGetTest(WebApiResponse response)
        {
            string category = "Test category";
            string id = "test";
            var expiresAt = 30.Minutes().After(DateTime.Now);

            await this.cacheMethod.SetAsync(category, id, response, expiresAt);
            var actual = await this.cacheMethod.GetOrUpdateAsync<WebApiResponse>(category, id, expiresAt, () => throw new Exception("Should not be called"));
            actual.Item.Should().BeEquivalentTo(response);
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateUpdateTest(WebApiResponse response)
        {
            string category = "Test category";
            string id = "test";
            var expiresAt = 30.Minutes().After(DateTime.Now);

            await this.cacheMethod.GetOrUpdateAsync(category, id, expiresAt, () => Task.FromResult(response));
            var actual = await this.cacheMethod.TryGetAsync<WebApiResponse>(category, id);
            actual.Should().NotBeNull();
            actual.Item.Should().BeEquivalentTo(response);
        }

        [Theory]
        [AutoData]
        public async Task IdDoesNotExistTest(WebApiResponse response)
        {
            string category = "Test category";
            var expiresAt = 30.Minutes().After(DateTime.Now);

            await this.cacheMethod.SetAsync(new CacheItem<IWebApiResponse>(category, "test", response, expiresAt));
            var actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(category, "unknown");
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreExpiredTest(WebApiResponse response)
        {
            var expiresAt = 30.Minutes().Before(DateTime.Now);
            var cacheItem = new CacheItem<IWebApiResponse>("Test category", "test", response, expiresAt);

            await this.cacheMethod.SetAsync(cacheItem);
            var actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreExpiresSoonTest(WebApiResponse response)
        {
            var expiresAt = 1.5.Seconds().After(DateTime.Now);
            var cacheItem = new CacheItem<IWebApiResponse>("Test category", "test", response, expiresAt);

            await this.cacheMethod.SetAsync(cacheItem);
            var actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());

            await Task.Delay(2000);

            actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreManyTest(WebApiResponse response1, WebApiResponse response2, WebApiResponse response3)
        {
            string category = "Test category";
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItems = new[]
            {
                new CacheItem<IWebApiResponse>(category, "test", response1, expiresAt),
                new CacheItem<IWebApiResponse>(category, "test2", response2, expiresAt),
                new CacheItem<IWebApiResponse>(category, "test3", response3, expiresAt)
            };

            await this.cacheMethod.SetManyAsync(cacheItems);
            await AssertAsync.All(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync<IWebApiResponse>(i.Category, i.Id) != null), Assert.True);
            var actual = (await this.cacheMethod.GetManyAsync<IWebApiResponse>(category, cacheItems.Select(x => x.Id))).Select(x => x.Value);
            actual.Should().BeEquivalentTo(cacheItems, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());
        }

        [Theory]
        [AutoData]
        public async Task StoreValidTest(WebApiResponse response)
        {
            string category = "Test category";
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItem = new CacheItem<IWebApiResponse>(category, "test", response, expiresAt);

            await this.cacheMethod.SetAsync(cacheItem);
            var actual = await this.cacheMethod.TryGetAsync<IWebApiResponse>(cacheItem.Category, cacheItem.Id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.ComparingByMembers<CacheItem<IWebApiResponse>>());
        }

        #region ArgumentNullException tests

        [Fact]
        public async Task ArgumentNullGetTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.TryGetAsync<object>("Test category", "test"),
                new[] { true, true });

        [Fact]
        public async Task ArgumentNullGetManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetManyAsync<object>("Test category", Array.Empty<string>()),
                new[] { true, true });

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
        public async Task ArgumentNullSetManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetManyAsync(new List<CacheItem<object>>()),
                new[] { true });

        [Fact]
        public async Task ArgumentNullGetOrUpdateTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateAsync("Test category", "test", DateTime.Now, () => Task.FromResult(new object())),
                new[] { true, true, false, true });

        [Fact]
        public async Task ArgumentNullGetOrUpdateManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateManyAsync("Test category", new List<string>(), DateTime.Now, obj => Task.FromResult((IDictionary<string, object>)new Dictionary<string, object>())),
                new[] { true, true, false, true });

        #endregion
    }
}
