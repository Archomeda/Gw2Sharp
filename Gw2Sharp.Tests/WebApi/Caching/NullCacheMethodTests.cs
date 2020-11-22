using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class NullCacheMethodTests
    {
        private readonly NullCacheMethod cacheMethod = new NullCacheMethod();

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
            actual.Should().BeNull();

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
        public async Task StoreManyTest(string category, (string Id, string Data)[] items)
        {
            var expiresAt = 30.Minutes().After(DateTime.Now);

            var cacheItems = items.Select(x => new CacheItem(category, x.Id, x.Data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New)).ToList();
            await this.cacheMethod.SetManyAsync(cacheItems);

            var individualActual = await Task.WhenAll(cacheItems.Select(async i => await this.cacheMethod.TryGetAsync(i.Category, i.Id)));
            individualActual.Should().OnlyContain(x => x == null);
            var manyActual = await this.cacheMethod.GetManyAsync(category, cacheItems.Select(x => x.Id));
            manyActual.Should().BeEmpty();
        }
    }
}
