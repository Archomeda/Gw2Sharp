using System;
using System.IO;
using Gw2Sharp.WebApi.Caching;

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

        public void Dispose()
        {
            this.cacheMethod.Dispose();
            File.Delete(ARCHIVE_FILENAME);
        }
    }
}
