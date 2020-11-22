using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public abstract class BaseCacheMethodTests
    {
        protected ICacheMethod cacheMethod = null!;

        [Theory]
        [AutoData]
        public async Task CategoryDoesNotExistTest(string category, string id)
        {
            var actual = await this.cacheMethod.TryGetAsync(category, id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task FlushTest(string category, string id, string data)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);

            await this.cacheMethod.SetAsync(cacheItem);
            var actual = await this.cacheMethod.TryGetAsync(cacheItem.Category, cacheItem.Id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actual.Status.Should().Be(CacheItemStatus.Cached);

            await this.cacheMethod.ClearAsync();
            actual = await this.cacheMethod.TryGetAsync(cacheItem.Category, cacheItem.Id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task GetManyEmptyTest(string category, string[] ids)
        {
            var actual = await this.cacheMethod.GetManyAsync(category, ids);
            actual.Should().BeEmpty();
        }

        [Theory]
        [AutoData]
        public async Task GetManyWithoutExpiredTest(string category, (string Id, string Data)[] items)
        {
            var cacheItems = items
                .Select((x, i) => new CacheItem(category, x.Id, x.Data, HttpStatusCode.OK, i == 0 ? 750.Milliseconds().After(DateTime.Now) : 30.Minutes().After(DateTime.Now), CacheItemStatus.New))
                .ToList();

            await this.cacheMethod.SetManyAsync(cacheItems);
            var actual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync(i.Category, i.Id)));
            actual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status))
                .And.OnlyContain(x => x.Status == CacheItemStatus.Cached);
            await Task.Delay(1000);

            var afterExpiryActual = await this.cacheMethod.GetManyAsync(category, cacheItems.Select(x => x.Id));
            afterExpiryActual.Should().BeEquivalentTo(cacheItems.Where(i => i.ExpiryTime > DateTime.Now), x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateManyTest(string category, (string Id, string Data)[] items)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItems = items.Select(x => new CacheItem(category, x.Id, x.Data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New)).ToList();

            await this.cacheMethod.GetOrUpdateManyAsync(category, cacheItems.Select(x => x.Id), (_, missingIds) =>
            {
                missingIds.Should().BeEquivalentTo(cacheItems.Select(x => x.Id));
                return Task.FromResult<IList<CacheItem>>(cacheItems);
            });

            var individualActual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync(i.Category, i.Id)));
            individualActual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status))
                .And.OnlyContain(x => x.Status == CacheItemStatus.Cached);
            var manyActual = await this.cacheMethod.GetManyAsync(category, cacheItems.Select(x => x.Id));
            manyActual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status))
                .And.OnlyContain(x => x.Status == CacheItemStatus.Cached);
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateManyPartlyTest(string category, (string Id, string Data)[] items)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);
            var cacheItems = items.Select(x => new CacheItem(category, x.Id, x.Data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New)).ToList();
            var idsToGet = cacheItems.Select(x => x.Id).ToList();
            idsToGet.Add("0");

            // Set the cache items
            await this.cacheMethod.SetManyAsync(cacheItems);

            // Return an empty response to make sure that there's still an item missing, this should not throw any exception
            var actual = await this.cacheMethod.GetOrUpdateManyAsync(category, idsToGet, (_, missingIds) =>
                Task.FromResult<IList<CacheItem>>(Array.Empty<CacheItem>()));

            actual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status))
                .And.OnlyContain(x => x.Status == CacheItemStatus.Cached);
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateGetTest(string category, string id, string data)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);

            var actual = await this.cacheMethod.GetOrUpdateAsync(category, id, (_1, _2) => throw new Exception("Should not be called"));
            actual.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actual.Status.Should().Be(CacheItemStatus.Cached);
        }

        [Theory]
        [AutoData]
        public async Task GetOrUpdateUpdateTest(string category, string id, string data)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.GetOrUpdateAsync(category, id, (_1, _2) => Task.FromResult(cacheItem));

            var actual = await this.cacheMethod.TryGetAsync(category, id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actual.Status.Should().Be(CacheItemStatus.Cached);
        }

        [Theory]
        [AutoData]
        public async Task IdDoesNotExistTest(string category, string id, string data)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);

            var actual = await this.cacheMethod.TryGetAsync(category, $"{id}_nonexistent");
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreExpiredTest(string category, string id, string data)
        {
            var expiresAt = 30.Minutes().Before(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);

            var actual = await this.cacheMethod.TryGetAsync(category, id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreExpiresSoonTest(string category, string id, string data)
        {
            var expiresAt = 750.Milliseconds().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);

            var actual = await this.cacheMethod.TryGetAsync(category, id);
            actual.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actual.Status.Should().Be(CacheItemStatus.Cached);

            await Task.Delay(1000);

            actual = await this.cacheMethod.TryGetAsync(category, id);
            actual.Should().BeNull();
        }

        [Theory]
        [AutoData]
        public async Task StoreManyTest(string category, (string Id, string Data)[] items)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);

            var cacheItems = items.Select(x => new CacheItem(category, x.Id, x.Data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New)).ToList();
            await this.cacheMethod.SetManyAsync(cacheItems);

            var individualActual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync(i.Category, i.Id)));
            individualActual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            individualActual.Should().OnlyContain(x => x.Status == CacheItemStatus.Cached);
            var manyActual = await this.cacheMethod.GetManyAsync(category, cacheItems.Select(x => x.Id));
            manyActual.Should().BeEquivalentTo(cacheItems, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status))
                .And.OnlyContain(x => x.Status == CacheItemStatus.Cached);
        }

        #region ArgumentNullException tests

        [Fact]
        public async Task ArgumentNullGetTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.TryGetAsync("Test category", "test"),
                new[] { true, true });

        [Fact]
        public async Task ArgumentNullGetManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetManyAsync("Test category", Array.Empty<string>()),
                new[] { true, true });

        [Fact]
        public async Task ArgumentNullSetTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetAsync(new CacheItem("Test category", "test", "data", HttpStatusCode.OK, DateTime.Now, CacheItemStatus.New, null)),
                new[] { true });

        [Fact]
        public async Task ArgumentNullSetManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.SetManyAsync(Array.Empty<CacheItem>()),
                new[] { true });

        [Fact]
        public async Task ArgumentNullGetOrUpdateTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateAsync("Test category", "test", (_1, _2) => Task.FromResult<CacheItem>(null)),
                new[] { true, true, true });

        [Fact]
        public async Task ArgumentNullGetOrUpdateManyTest() =>
            await AssertArguments.ThrowsWhenNullAsync(
                () => this.cacheMethod.GetOrUpdateManyAsync("Test category", new List<string>(), (_1, _2) => Task.FromResult<IList<CacheItem>>(null)),
                new[] { true, true, true });

        #endregion
    }
}
