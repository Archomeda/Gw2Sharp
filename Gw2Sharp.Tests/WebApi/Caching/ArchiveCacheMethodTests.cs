using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Gw2Sharp.Tests.Helpers;
using Gw2Sharp.WebApi.Caching;
using Xunit;

#pragma warning disable S3881 // "IDisposable" should be implemented correctly

namespace Gw2Sharp.Tests.WebApi.Caching
{
    public class ArchiveCacheMethodTests : BaseCacheMethodTests, IDisposable
    {
        private const string ARCHIVE_FILENAME = "test.zip";

        public ArchiveCacheMethodTests()
        {
            this.cacheMethod = new ArchiveCacheMethod(ARCHIVE_FILENAME);
        }


        [Fact]
        public async Task StoresCacheIntoArchiveTest()
        {
            string category = "testdata";
            string id = "bytearray.dat";
            var expiryTime = DateTimeOffset.UtcNow.AddMinutes(1);

            byte[] data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            await this.cacheMethod.SetAsync(category, id, data, expiryTime);
            var actualCache = await this.cacheMethod.TryGetAsync<byte[]>(category, id);

            Assert.Equal(data, actualCache?.Item);
            this.cacheMethod.Dispose();

            using var stream = File.OpenRead(ARCHIVE_FILENAME);
            var archive = new ZipArchive(stream);
            var entry = archive.GetEntry($"{category}/{id}");
            using var entryStream = entry.Open();
            using var memoryStream = new MemoryStream();
            await entryStream.CopyToAsync(memoryStream);
            byte[] actual = memoryStream.ToArray();
            Assert.Equal(data, actual);
        }

        [Fact]
        public async Task LoadExistingArchiveTest()
        {
            string category = "testdata";
            string id = "bytearray.dat";
            var expiryTime = DateTimeOffset.UtcNow.AddMinutes(1);

            byte[] data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            await this.cacheMethod.SetAsync(category, id, data, expiryTime);
            var actualCache = await this.cacheMethod.TryGetAsync<byte[]>(category, id);

            Assert.Equal(data, actualCache?.Item);
            this.cacheMethod.Dispose();

            this.cacheMethod = new ArchiveCacheMethod(ARCHIVE_FILENAME);
            actualCache = await this.cacheMethod.TryGetAsync<byte[]>(category, id);
            Assert.Equal(data, actualCache?.Item);
            Assert.Equal(expiryTime, actualCache?.ExpiryTime);
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
