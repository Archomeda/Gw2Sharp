using System;
using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
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

        [Theory]
        [AutoData]
        public async Task TriggersGarbageCollectionTest(string category, string id, string data)
        {
            this.cacheMethod = new MemoryCacheMethod(1000);

            var expiresAt = 2.Seconds().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);

            var actual = await this.cacheMethod.TryGetAsync(category, id);

            await Task.Delay(5000);

            actual.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actual.Status.Should().Be(CacheItemStatus.Cached);

            actual = await this.cacheMethod.TryGetAsync(category, id);

            actual.Should().BeNull();
        }
    }
}
