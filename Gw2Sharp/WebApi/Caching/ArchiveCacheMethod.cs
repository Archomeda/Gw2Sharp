using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using DisposeGenerator.Attributes;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A file archive caching method.
    /// Particularly useful for caching files for a longer period of time, such as files from the render API.
    /// </summary>
    [DisposeAll]
    public partial class ArchiveCacheMethod : BaseCacheMethod
    {
        private const int ARCHIVE_VERSION = 1;

        private const string ARCHIVE_VERSION_FILENAME = "version";
        private const string EXPIRY_INDEX_FILENAME = "expiry_index";
        private const string METADATA_EXTENSION = ".metadata";
        private const string STATUS_CODE_KEY = "_statuscode";

        private ZipArchive archive;
        private FileStream archiveStream;
        private Dictionary<string, DateTimeOffset>? expiryCache;
        private readonly object operationLock = new();

        /// <summary>
        /// Creates a new file archive caching method with the default cache duration (one day).
        /// </summary>
        /// <param name="archiveFileName">The file name of the archive.</param>
        /// <exception cref="ArgumentNullException"><paramref name="archiveFileName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="archiveFileName"/> is empty or contains only whitespaces.</exception>
        public ArchiveCacheMethod(string archiveFileName)
        {
            if (archiveFileName == null)
                throw new ArgumentNullException(nameof(archiveFileName));
            if (string.IsNullOrWhiteSpace(archiveFileName))
                throw new ArgumentException("File name cannot be empty or only contain whitespaces", nameof(archiveFileName));

            this.archiveStream = File.Open(archiveFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            this.archive = new ZipArchive(this.archiveStream, ZipArchiveMode.Update);
            this.UpgradeArchive();
        }

        private void UpgradeArchive()
        {
            lock (this.operationLock)
            {
                var versionEntry = this.archive.GetEntry(ARCHIVE_VERSION_FILENAME);
                if (versionEntry is not null)
                {
                    using var stream = versionEntry.Open();
                    using var reader = new StreamReader(stream);
                    string version = reader.ReadToEnd();
                    if (version == ARCHIVE_VERSION.ToString(CultureInfo.InvariantCulture))
                        return;
                }

                // Wrong version, clear the archive
                this.Clear();
                {
                    versionEntry = this.archive.CreateEntry(ARCHIVE_VERSION_FILENAME, CompressionLevel.Fastest);
                    using var stream = versionEntry.Open();
                    using var writer = new StreamWriter(stream);
                    writer.Write(ARCHIVE_VERSION.ToString(CultureInfo.InvariantCulture));
                }
            }
        }


        private DateTimeOffset GetExpiryTime(string fileName, DateTimeOffset writeTime)
        {
            if (this.expiryCache is null)
            {
                this.expiryCache = new Dictionary<string, DateTimeOffset>();
                var expiryIndexEntry = this.archive.GetEntry(EXPIRY_INDEX_FILENAME);
                if (expiryIndexEntry is not null)
                {
                    using var entryStream = expiryIndexEntry.Open();
                    using var streamReader = new StreamReader(entryStream);
                    while (!streamReader.EndOfStream)
                    {
                        // ReadLine may return null if the end of the stream has been reached, but we're checking that case in the loop itself
                        string[] line = streamReader.ReadLine()!.Split('=');
                        this.expiryCache.Add(line[0], DateTimeOffset.Parse(line[1], CultureInfo.InvariantCulture));
                    }
                }
            }

            return this.expiryCache.TryGetValue(fileName, out var expiryTime) ? expiryTime : writeTime;
        }

        private void SetExpiryTime(string fileName, DateTimeOffset? expiryTime)
        {
            this.expiryCache ??= new Dictionary<string, DateTimeOffset>();

            if (expiryTime.HasValue)
                this.expiryCache[fileName] = expiryTime.Value;
            else
                this.expiryCache.Remove(fileName);
            this.SaveExpiryTimes();
        }

        private void SaveExpiryTimes()
        {
            if (this.expiryCache == null)
                return;

            var expiryIndexEntry = this.archive.GetEntry(EXPIRY_INDEX_FILENAME);
            expiryIndexEntry?.Delete();
            expiryIndexEntry = this.archive.CreateEntry(EXPIRY_INDEX_FILENAME, CompressionLevel.Fastest);

            using var entryStream = expiryIndexEntry.Open();
            using var streamWriter = new StreamWriter(entryStream);
            foreach (var kvp in this.expiryCache)
                streamWriter.WriteLine($"{kvp.Key}={kvp.Value:o}");
        }


        private (IDictionary<string, string> Metadata, HttpStatusCode StatusCode) ReadMetadata(string fileName)
        {
            string metadataFileName = $"{fileName}{METADATA_EXTENSION}";
            var metadata = new Dictionary<string, string>();

            var zipEntry = this.archive.GetEntry(metadataFileName);
            if (zipEntry is null)
                return (metadata, 0);

            using var entryStream = zipEntry.Open();
            using var reader = new StreamReader(entryStream);
            while (!reader.EndOfStream)
            {
                // ReadLine may return null if the end of the stream has been reached, but we're checking that case in the loop itself
                string[] line = reader.ReadLine()!.Split('=');
                metadata.Add(line[0], line[1]);
            }

            int statusCode = 0;
            if (metadata.TryGetValue(STATUS_CODE_KEY, out string? statusCodeString))
            {
                metadata.Remove(STATUS_CODE_KEY); // Remove the key since it's redundant and unexpected for internal data to be exposed

#pragma warning disable CA1806 // Do not ignore method results - We do not care if it succeeds or not, if it fails, we are fine with the default value
                int.TryParse(statusCodeString, out statusCode);
#pragma warning restore CA1806 // Do not ignore method results
            }
            return (metadata, (HttpStatusCode)statusCode);
        }

        private void WriteMetadata(string fileName, CacheItem cacheItem)
        {
            string metadataFileName = $"{fileName}{METADATA_EXTENSION}";

            var zipEntry = this.archive.GetEntry(metadataFileName);
            zipEntry?.Delete();

            zipEntry = this.archive.CreateEntry(metadataFileName, CompressionLevel.Fastest);
            using var entryStream = zipEntry.Open();
            using var writer = new StreamWriter(entryStream);

            if (cacheItem.Metadata is not null)
            {
                foreach (var kvp in cacheItem.Metadata)
                    writer.WriteLine($"{kvp.Key}={kvp.Value}");
            }
            writer.WriteLine($"{STATUS_CODE_KEY}={(int)cacheItem.StatusCode}");
        }

        private CacheItem? ReadEntry(string category, string id)
        {
            string fileName = $"{category}/{id}";

            lock (this.operationLock)
            {
                var zipEntry = this.archive.GetEntry(fileName);
                if (zipEntry is null)
                    return null;

                var expiryTime = this.GetExpiryTime(fileName, zipEntry.LastWriteTime);
                if (expiryTime < DateTimeOffset.Now)
                {
                    // Item has expired, delete and ignore
                    this.DeleteEntry(zipEntry);
                    return null;
                }

                using var stream = zipEntry.Open();

                // First byte indicates the type
                var type = (CacheItemType)stream.ReadByte();

                switch (type)
                {
                    case CacheItemType.Raw:
                        using (var rawStream = new MemoryStream())
                        {
                            stream.CopyTo(rawStream);
                            var (metadata, statusCode) = this.ReadMetadata(fileName);
                            return new CacheItem(category, id, rawStream.ToArray(), statusCode, expiryTime, CacheItemStatus.Cached, metadata);
                        }

                    case CacheItemType.String:
                        using (var stringStream = new StreamReader(stream))
                        {
                            var (metadata, statusCode) = this.ReadMetadata(fileName);
                            return new CacheItem(category, id, stringStream.ReadToEnd(), statusCode, expiryTime, CacheItemStatus.Cached, metadata);
                        }

                    default:
                        // Unknown, delete and ignore
                        stream.Close();
                        this.DeleteEntry(zipEntry);
                        return null;
                }
            }
        }

        private void WriteEntry(CacheItem item)
        {
            string fileName = $"{item.Category}/{item.Id}";

            lock (this.operationLock)
            {
                var zipEntry = this.archive.GetEntry(fileName);
                zipEntry?.Delete();

                zipEntry = this.archive.CreateEntry(fileName, CompressionLevel.Fastest);
                using var zipStream = zipEntry.Open();

                switch (item.Type)
                {
                    case CacheItemType.Raw:
                        using (var rawStream = new MemoryStream(item.RawItem))
                        {
                            zipStream.WriteByte((byte)item.Type);
                            rawStream.CopyTo(zipStream);
                        }
                        break;

                    case CacheItemType.String:
                        using (var stringStream = new StreamWriter(zipStream))
                        {
                            zipStream.WriteByte((byte)item.Type);
                            stringStream.Write(item.StringItem);
                        }
                        break;

                    default:
                        throw new NotSupportedException($"Trying to write entry of unknown type {item.Type} to the cache archive");
                }

                this.WriteMetadata(fileName, item);
                this.SetExpiryTime(fileName, item.ExpiryTime);
            }
        }

        private void DeleteEntry(ZipArchiveEntry zipEntry)
        {
            zipEntry.Delete();
            this.SetExpiryTime(zipEntry.FullName, null);
        }


        #region BaseCacheMethod overrides

        /// <inheritdoc />
        public override Task<CacheItem?> TryGetAsync(string category, string id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Task.FromResult(this.ReadEntry(category, id));
        }

        /// <inheritdoc />
        public override Task SetAsync(CacheItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.ExpiryTime > DateTime.Now)
                this.WriteEntry(item);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public override Task ClearAsync()
        {
            lock (this.operationLock)
            {
                this.Clear();
                return Task.CompletedTask;
            }
        }

        #endregion

        private void Clear()
        {
            string fileName = this.archiveStream.Name;
            this.archive.Dispose();
            this.archiveStream.Close();
            this.archiveStream.Dispose();
            this.archiveStream = File.Open(fileName, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None);
            this.archive = new ZipArchive(this.archiveStream, ZipArchiveMode.Update);
        }
    }
}
