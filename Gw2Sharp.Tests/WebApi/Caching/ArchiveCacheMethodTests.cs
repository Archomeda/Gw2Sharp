using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Extensions;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class ArchiveCacheMethodTests : BaseCacheMethodTests, IDisposable
    {
        private const string ARCHIVE_FILENAME = "test.zip";

        public ArchiveCacheMethodTests()
        {
            this.cacheMethod = new ArchiveCacheMethod(ARCHIVE_FILENAME);
        }


        [Theory]
        [AutoData]
        public async Task StoresRawDataIntoArchiveTest(string category, string id, byte[] data)
        {
            var expiresAt = 1.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);
            var actualCache = await this.cacheMethod.TryGetAsync(category, id);

            actualCache.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.StringItem).Excluding(y => y.Status));
            actualCache.Status.Should().Be(CacheItemStatus.Cached);
            this.cacheMethod.Dispose();

            using var stream = File.OpenRead(ARCHIVE_FILENAME);
            var archive = new ZipArchive(stream);
            var entry = archive.GetEntry($"{category}/{id}");
            using var entryStream = entry.Open();
            using var memoryStream = new MemoryStream();
            await entryStream.CopyToAsync(memoryStream);

            var expected = new[] { (byte)CacheItemType.Raw }.Concat(data);
            byte[] actual = memoryStream.ToArray();
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public async Task StoresStringDataIntoArchiveTest(string category, string id, string data)
        {
            var expiresAt = 1.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);
            var actualCache = await this.cacheMethod.TryGetAsync(category, id);

            actualCache.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.RawItem).Excluding(y => y.Status));
            actualCache.Status.Should().Be(CacheItemStatus.Cached);
            this.cacheMethod.Dispose();

            using var stream = File.OpenRead(ARCHIVE_FILENAME);
            var archive = new ZipArchive(stream);
            var entry = archive.GetEntry($"{category}/{id}");
            using var entryStream = entry.Open();
            using var memoryStream = new MemoryStream();
            await entryStream.CopyToAsync(memoryStream);

            string expected = $"{(char)CacheItemType.String}{data}";
            string actual = Encoding.UTF8.GetString(memoryStream.ToArray());
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [AutoData]
        public async Task LoadExistingArchiveTest(string category, string id, byte[] data)
        {
            var expiresAt = 1.Minutes().After(DateTime.Now);

            var cacheItem = new CacheItem(category, id, data, HttpStatusCode.OK, expiresAt, CacheItemStatus.New);
            await this.cacheMethod.SetAsync(cacheItem);
            var actualCache = await this.cacheMethod.TryGetAsync(category, id);

            actualCache.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.StringItem).Excluding(y => y.Status));
            actualCache.Status.Should().Be(CacheItemStatus.Cached);
            this.cacheMethod.Dispose();

            this.cacheMethod = new ArchiveCacheMethod(ARCHIVE_FILENAME);
            actualCache = await this.cacheMethod.TryGetAsync(category, id);
            actualCache.Status.Should().Be(CacheItemStatus.Cached);
            actualCache.Should().BeEquivalentTo(cacheItem, x => x.Excluding(y => y.StringItem).Excluding(y => y.Status));
        }

        public void Dispose()
        {
            this.cacheMethod.Dispose();
            File.Delete(ARCHIVE_FILENAME);
        }


        #region Constructor exception tests

        [Fact]
        public void ConstructorNullFileNameTest()
        {
            AssertArguments.ThrowsWhenNullConstructor(typeof(ArchiveCacheMethod), new[] { typeof(string) }, new[] { "test" }, new[] { true });
        }

        [Fact]
        public void ConstructorEmptyStringFileNameTest()
        {
            AssertArguments.ThrowsWhenEmptyStringConstructor(typeof(ArchiveCacheMethod), new[] { typeof(string) }, new[] { "test" }, new[] { true });
        }

        #endregion
    }
}
