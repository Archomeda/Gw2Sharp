using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gw2Sharp.Json.Converters;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Wraps a list an API enums into flags to allow unsupported and/or future enum values.
    /// </summary>
    public abstract class ApiFlags : IEquatable<ApiFlags>, IEnumerable<ApiEnum>
    {
        /// <summary>
        /// Creates new API flags.
        /// </summary>
        protected ApiFlags() { }

        /// <summary>
        /// Creates new API flags.
        /// </summary>
        /// <param name="list">The list of enum values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <c>null</c>.</exception>
        protected ApiFlags(IReadOnlyList<ApiEnum> list)
        {
            this.List = list ?? throw new ArgumentNullException(nameof(list));
            this.UnknownList = list.Where(e => e.IsUnknown).ToList().AsReadOnly();
        }

        /// <summary>
        /// Whether the flags has at least one unknown value to the library.
        /// If true, <see cref="UnknownList" /> will contain the actual values whereas <see cref="List" /> will have the default values.
        /// </summary>
        public bool HasUnknowns => this.UnknownList.Count > 0;

        /// <summary>
        /// The actual flags as interpreted by the library.
        /// </summary>
        public IReadOnlyList<ApiEnum> List { get; protected set; } = new List<ApiEnum>();

        /// <summary>
        /// Gets the list of unknown enum values.
        /// </summary>
        public IReadOnlyList<ApiEnum> UnknownList { get; protected set; } = new List<ApiEnum>();

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj != null && obj.GetType() == typeof(ApiFlags) && this.Equals((ApiFlags)obj);

        /// <inheritdoc />
        public virtual bool Equals(ApiFlags other) =>
            !(other is null) && this.List.SequenceEqual(other.List);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return -2004394551 +
                EqualityComparer<IReadOnlyList<ApiEnum>>.Default.GetHashCode(this.List);
        }

        /// <inheritdoc />
        public IEnumerator<ApiEnum> GetEnumerator() =>
            this.List.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public static bool operator ==(ApiFlags flags1, ApiFlags flags2) =>
            EqualityComparer<ApiFlags>.Default.Equals(flags1, flags2);

        /// <inheritdoc />
        public static bool operator !=(ApiFlags flags1, ApiFlags flags2) =>
            !(flags1 == flags2);
    }

    /// <summary>
    /// Wraps a list an API enums into flags to allow unsupported and/or future enum values.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    [JsonConverter(typeof(ApiFlagsConverter))]
    public class ApiFlags<T> : ApiFlags, IEquatable<ApiFlags<T>>, IEnumerable<ApiEnum<T>> where T : Enum
    {
        /// <summary>
        /// Creates new API flags.
        /// </summary>
        public ApiFlags() : base() { }

        /// <summary>
        /// Creates new API flags.
        /// </summary>
        /// <param name="list">The list of enum values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <c>null</c>.</exception>
        public ApiFlags(IReadOnlyList<ApiEnum> list) :
            this(list.Select(e => new ApiEnum<T>((T)e.Value, e.RawValue)).ToList())
        { }

        /// <summary>
        /// Creates new API flags.
        /// </summary>
        /// <param name="list">The list of enum values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <c>null</c>.</exception>
        public ApiFlags(IReadOnlyList<ApiEnum<T>> list) :
            base(list)
        { }

        /// <summary>
        /// The actual flags as interpreted by the library.
        /// </summary>
        public new IReadOnlyList<ApiEnum<T>> List => (IReadOnlyList<ApiEnum<T>>)base.List;

        /// <summary>
        /// Gets the list of unknown enum values.
        /// </summary>
        public new IReadOnlyList<ApiEnum<T>> UnknownList => (IReadOnlyList<ApiEnum<T>>)base.UnknownList;

        /// <summary>
        /// Converts a list of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static implicit operator ApiFlags<T>(List<ApiEnum<T>> l) => new ApiFlags<T>(l);

        /// <summary>
        /// Converts a collection of enums to API flags.
        /// </summary>
        /// <param name="l">The collection of enums.</param>
        public static implicit operator ApiFlags<T>(Collection<ApiEnum<T>> l) => new ApiFlags<T>(l);

        /// <summary>
        /// Converts a set of enums to API flags.
        /// </summary>
        /// <param name="l">The set of enums.</param>
        public static implicit operator ApiFlags<T>(HashSet<ApiEnum<T>> l) => new ApiFlags<T>(l.ToList());

        /// <summary>
        /// Converts API flags to a list of enums.
        /// </summary>
        /// <param name="e">The API enum.</param>
        public static implicit operator List<ApiEnum<T>>(ApiFlags<T> e) => e.List.ToList();

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj != null && obj.GetType() == typeof(ApiFlags<T>) && this.Equals((ApiFlags<T>)obj);

        /// <inheritdoc />
        public virtual bool Equals(ApiFlags<T> other) =>
            !(other is null) && this.List.SequenceEqual(other.List);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 1050334356;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<IReadOnlyList<ApiEnum<T>>>.Default.GetHashCode(this.List);
            return hashCode;
        }

        /// <inheritdoc />
        public new IEnumerator<ApiEnum<T>> GetEnumerator() =>
            this.List.GetEnumerator();

        /// <inheritdoc />
        public static bool operator ==(ApiFlags<T> flags1, ApiFlags<T> flags2) =>
            EqualityComparer<ApiFlags<T>>.Default.Equals(flags1, flags2);

        /// <inheritdoc />
        public static bool operator !=(ApiFlags<T> flags1, ApiFlags<T> flags2) =>
            !(flags1 == flags2);
    }
}
