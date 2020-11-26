using System;
using System.Collections.Generic;
using System.Net;
#if !NETSTANDARD
using System.Collections.Immutable;
#endif

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A default object cache item.
    /// </summary>
    public sealed class CacheItem
    {
        private readonly object item;

#if !NETSTANDARD
        private static IDictionary<string, string> EmptyMetadata { get; } = new Dictionary<string, string>().ToImmutableDictionary();
#else
        private static IDictionary<string, string> EmptyMetadata => new Dictionary<string, string>();
#endif

        /// <summary>
        /// Creates a new raw cache item.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <param name="status">The cache status.</param>
        /// <param name="metadata">The cache metadata.</param>
        public CacheItem(string category, string id, byte[] item, HttpStatusCode statusCode, DateTimeOffset expiryTime, CacheItemStatus status, IDictionary<string, string>? metadata = null)
        {
            this.Category = category ?? throw new ArgumentNullException(nameof(category));
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.item = item ?? throw new ArgumentNullException(nameof(item));
            this.StatusCode = statusCode;
            this.ExpiryTime = expiryTime;
            this.Metadata = metadata ?? EmptyMetadata;
            this.Type = CacheItemType.Raw;
            this.Status = status;
        }

        /// <summary>
        /// Creates a new string cache item.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="expiryTime">The expiry time.</param>
        /// <param name="status">The cache status.</param>
        /// <param name="metadata">The cache metadata.</param>
        public CacheItem(string category, string id, string item, HttpStatusCode statusCode, DateTimeOffset expiryTime, CacheItemStatus status, IDictionary<string, string>? metadata = null)
        {
            this.Category = category ?? throw new ArgumentNullException(nameof(category));
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.item = item ?? throw new ArgumentNullException(nameof(item));
            this.StatusCode = statusCode;
            this.ExpiryTime = expiryTime;
            this.Metadata = metadata ?? EmptyMetadata;
            this.Type = CacheItemType.String;
            this.Status = status;
        }

        /// <summary>
        /// The cache item type.
        /// </summary>
        public CacheItemType Type { get; }

        /// <summary>
        /// The cache item status.
        /// </summary>
        public CacheItemStatus Status { get; }

        /// <summary>
        /// The category associated with the cache item.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The id associated with the cache item.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The cache item as a raw byte array.
        /// </summary>
        /// <exception cref="InvalidOperationException">The cache item is not a raw byte array.</exception>
#pragma warning disable CA1819 // Properties should not return arrays - How else are we returning the raw bytes?
        public byte[] RawItem =>
            this.item as byte[] ?? throw new InvalidOperationException("The cache item is not a raw byte array.");
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The cache item as a string.
        /// </summary>
        /// <exception cref="InvalidOperationException">The cache item is not a string.</exception>
        public string StringItem =>
            this.item as string ?? throw new InvalidOperationException("The cache item is not a string.");

        /// <summary>
        /// The original response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// The time when this cache item expires.
        /// </summary>
        public DateTimeOffset ExpiryTime { get; }

        /// <summary>
        /// The metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; }
    }
}
