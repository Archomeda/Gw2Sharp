using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Http;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A file archive caching method.
    /// Particularly useful for caching files for a longer period of time, such as files from the render API.
    /// </summary>
    public class ArchiveCacheMethod : BaseCacheMethod
    {
        private const string EXPIRY_DATE_INDEX_FILENAME = "expiry_index";

        private readonly JsonSerializerOptions serializerSettings = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private FileStream archiveStream;
        private ZipArchive archive;
        private Dictionary<string, DateTimeOffset>? expiryCache;
        private readonly object operationLock = new object();

        /// <summary>
        /// Creates a new file archive caching method with the default cache duration (one day).
        /// </summary>
        /// <param name="archiveFileName">The file name of the archive.</param>
        /// <exception cref="ArgumentNullException"><paramref name="archiveFileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="archiveFileName"/> is empty or contains only whitespaces.</exception>
        public ArchiveCacheMethod(string archiveFileName)
        {
            if (archiveFileName == null)
                throw new ArgumentNullException(nameof(archiveFileName));
            if (string.IsNullOrWhiteSpace(archiveFileName))
                throw new ArgumentException("File name cannot be empty or only contain whitespaces", nameof(archiveFileName));

            this.archiveStream = File.Open(archiveFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            this.archive = new ZipArchive(this.archiveStream, ZipArchiveMode.Update);
        }


        private DateTimeOffset GetExpiryTime(string fileName, DateTimeOffset writeTime)
        {
            if (this.expiryCache == null)
            {
                this.expiryCache = new Dictionary<string, DateTimeOffset>();
                var expiryIndexEntry = this.archive.GetEntry(EXPIRY_DATE_INDEX_FILENAME);
                if (expiryIndexEntry != null)
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

        private void SetExpiryTime(string fileName, DateTimeOffset expiryTime)
        {
            this.expiryCache ??= new Dictionary<string, DateTimeOffset>();

            this.expiryCache[fileName] = expiryTime;
            this.StoreExpiryTimes();
        }

        private void StoreExpiryTimes()
        {
            if (this.expiryCache == null)
                return;

            var expiryIndexEntry = this.archive.GetEntry(EXPIRY_DATE_INDEX_FILENAME);
            expiryIndexEntry?.Delete();
            expiryIndexEntry = this.archive.CreateEntry(EXPIRY_DATE_INDEX_FILENAME, CompressionLevel.Fastest);

            using var entryStream = expiryIndexEntry.Open();
            using var streamWriter = new StreamWriter(entryStream);
            foreach (var kvp in this.expiryCache)
                streamWriter.WriteLine($"{kvp.Key}={kvp.Value:o}");
        }


        #region BaseCacheController overrides

        /// <inheritdoc />
        public override Task<CacheItem<T>?> TryGetAsync<T>(string category, string id)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Task.FromResult(this.TryGet<T>(category, id));
        }

        private CacheItem<T>? TryGet<T>(string category, string id)
        {
            string fileName = $"{category}/{id}";
            lock (this.operationLock)
            {
                var zipEntry = this.archive.GetEntry(fileName);
                if (zipEntry == null)
                    return null;

                var expiryTime = this.GetExpiryTime(fileName, zipEntry.LastWriteTime);
                if (expiryTime < DateTimeOffset.Now)
                {
                    zipEntry.Delete();
                    return null;
                }

                object data;
                using var zipStream = zipEntry.Open();
                var type = typeof(T);
                if (type == typeof(byte[]))
                {
                    // A byte array is requested
                    using var memoryStream = new MemoryStream();
                    zipStream.CopyTo(memoryStream);
                    data = memoryStream.ToArray();
                }
                else if (typeof(IWebApiResponse).IsAssignableFrom(type))
                {
                    // Another type is requested, try deserializing it from JSON
                    // Sadly enough System.Text.Json doesn't yet support deserializing from streams

                    // Temporary workaround until v0.12 to solve serializing/deserializing issues.
                    // v0.12 will introduce a breaking change to the ICacheMethod that will no longer accept a generic type,
                    // but instead only a byte array or a string, along with the response headers and status code.
                    using var streamReader = new StreamReader(zipStream);
                    string json = streamReader.ReadToEnd();
                    var wrappedResponse = JsonSerializer.Deserialize<WrappedResponse>(json, this.serializerSettings);
                    data = new WebApiResponse(wrappedResponse!.Content, wrappedResponse.StatusCode, wrappedResponse.ResponseHeaders);
                }
                else
                {
                    throw new NotSupportedException($"Trying to deserialize unknown type {type.Name} from the cache archive");
                }

                return new CacheItem<T>(category, id, (T)data, expiryTime);
            }
        }

        /// <inheritdoc />
        public override Task SetAsync<T>(CacheItem<T> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.ExpiryTime > DateTime.Now)
                this.Set(item);
            return Task.CompletedTask;
        }

        private void Set<T>(CacheItem<T> item)
        {
            string fileName = $"{item.Category}/{item.Id}";
            lock (this.operationLock)
            {
                var zipEntry = this.archive.GetEntry(fileName);
                zipEntry?.Delete();

                zipEntry = this.archive.CreateEntry(fileName, CompressionLevel.Fastest);
                using var zipStream = zipEntry.Open();
                if (item.Item is byte[] byteArrayData)
                {
                    // A byte array is stored
                    using var memoryStream = new MemoryStream(byteArrayData, false);
                    memoryStream.CopyTo(zipStream);
                }
                else if (item.Item is IWebApiResponse response)
                {
                    // Another type is stored, try serializing it to JSON
                    // Sadly enough System.Text.Json doesn't yet support serializing to streams

                    // Temporary workaround until v0.12 to solve serializing/deserializing issues.
                    // v0.12 will introduce a breaking change to the ICacheMethod that will no longer accept a generic type,
                    // but instead only a byte array or a string, along with the response headers and status code.
                    var wrappedResponse = new WrappedResponse
                    {
                        Content = response.Content,
                        ResponseHeaders = response.ResponseHeaders.ToDictionary(x => x.Key, x => x.Value),
                        StatusCode = response.StatusCode
                    };
                    using var streamWriter = new StreamWriter(zipStream);
                    string json = JsonSerializer.Serialize(wrappedResponse, this.serializerSettings);
                    streamWriter.Write(json);
                }
                else
                {
                    throw new NotSupportedException($"Trying to serialize unknown type {item.Item?.GetType().Name ?? "(null)"} to the cache archive");
                }

                this.SetExpiryTime(fileName, item.ExpiryTime);
            }
        }

        /// <inheritdoc />
        public override Task<IDictionary<string, CacheItem<T>>> GetManyAsync<T>(string category, IEnumerable<string> ids)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));
            return ExecAsync();

            async Task<IDictionary<string, CacheItem<T>>> ExecAsync() => ids
                .Select(id => this.TryGet<T>(category, id))
                .WhereNotNull()
                .ToDictionary(x => x.Id);
        }

        /// <inheritdoc />
        public override async Task ClearAsync()
        {
            lock (this.operationLock)
            {
                string fileName = this.archiveStream.Name;
                this.archive.Dispose();
                this.archiveStream.Close();
                this.archiveStream.Dispose();
                this.archiveStream = File.Open(fileName, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None);
                this.archive = new ZipArchive(this.archiveStream, ZipArchiveMode.Update);
            }
        }

        private bool isDisposed = false; // To detect redundant calls

        /// <inheritdoc />
        protected override void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
                return;

            if (isDisposing)
            {
                this.archive.Dispose();
                this.archiveStream.Dispose();
            }

            base.Dispose(isDisposing);
            this.isDisposed = true;
        }

        #endregion

        private class WrappedResponse
        {
            public string Content { get; set; } = string.Empty;

            public Dictionary<string, string> ResponseHeaders { get; set; } = new Dictionary<string, string>();

            public HttpStatusCode StatusCode { get; set; }
        }
    }
}
