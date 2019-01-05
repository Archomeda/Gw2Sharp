using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.Caching
{
    /// <summary>
    /// A default object cache item.
    /// </summary>
    public class CacheItem : IEquatable<CacheItem>
    {
        /// <summary>
        /// Creates a new cache item.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        /// <param name="expiryTime">The expiry time.</param>
        public CacheItem(string category, object id, object item, DateTime expiryTime)
        {
            this.Category = category ?? throw new ArgumentNullException(nameof(category));
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Item = item ?? throw new ArgumentNullException(nameof(item));
            this.ExpiryTime = expiryTime;
        }

        /// <summary>
        /// The category associated with the cache item.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The id associated with the cache item.
        /// </summary>
        public object Id { get; }

        /// <summary>
        /// The cache item.
        /// </summary>
        public object Item { get; }

        /// <summary>
        /// The time when this cache item expires.
        /// </summary>
        public DateTime ExpiryTime { get; }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 212114582;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Category);
            hashCode = (hashCode * -1521134295) + EqualityComparer<object>.Default.GetHashCode(this.Id);
            hashCode = (hashCode * -1521134295) + EqualityComparer<object>.Default.GetHashCode(this.Item);
            hashCode = (hashCode * -1521134295) + this.ExpiryTime.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return this.Equals(obj as CacheItem);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(CacheItem other)
        {
            return other != null &&
                Equals(this.Category, other.Category) &&
                Equals(this.Id, other.Id) &&
                Equals(this.Item, other.Item) &&
                Equals(this.ExpiryTime, other.ExpiryTime);
        }
    }

    /// <summary>
    /// A generic cache item.
    /// </summary>
    public class CacheItem<T> : CacheItem, IEquatable<CacheItem<T>>
    {
        /// <summary>
        /// Creates a new cache item.
        /// </summary>
        /// <param name="category">The cache category.</param>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        /// <param name="expiryTime">The expiry time.</param>
        public CacheItem(string category, object id, T item, DateTime expiryTime) : base(category, id, item, expiryTime) { }

        /// <summary>
        /// The cache item.
        /// </summary>
        public new T Item { get => (T)base.Item; }

        /// <inheritdoc />
        public bool Equals(CacheItem<T> other)
        {
            return this.Equals(other as CacheItem);
        }
    }
}
