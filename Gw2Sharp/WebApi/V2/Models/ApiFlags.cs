using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Wraps a list an API enums into flags to allow unsupported and/or future enum values.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    public class ApiFlags<T> : IEquatable<ApiFlags<T>>, IEnumerable<ApiEnum<T>> where T : Enum
    {
        /// <summary>
        /// Creates new API flags.
        /// </summary>
        public ApiFlags() { }

        /// <summary>
        /// Creates new API flags.
        /// </summary>
        /// <param name="list">The list of enum values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>.</exception>
        public ApiFlags(IEnumerable<ApiEnum<T>> list)
        {
            this.List = list?.ToList()?.AsReadOnly() ?? throw new ArgumentNullException(nameof(list));
            this.UnknownList = this.List.Where(e => e.IsUnknown).ToList().AsReadOnly();
        }

        /// <summary>
        /// Creates new API flags.
        /// Used internally by <see cref="ApiFlagsConverter"/>.
        /// </summary>
        /// <param name="list">The list of enum values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>.</exception>
        internal ApiFlags(IEnumerable<object> list) :
            this(list?.Cast<ApiEnum<T>>() ?? throw new ArgumentNullException(nameof(list)))
        { }


        /// <summary>
        /// Whether the flags has at least one unknown value to the library.
        /// If true, <see cref="UnknownList" /> will contain the actual values whereas <see cref="List" /> will have the default values.
        /// </summary>
        public bool HasUnknowns => this.UnknownList.Count > 0;

        /// <summary>
        /// The actual flags as interpreted by the library.
        /// </summary>
        public IReadOnlyList<ApiEnum<T>> List { get; } = Array.Empty<ApiEnum<T>>();

        /// <summary>
        /// Gets the list of unknown enum values.
        /// </summary>
        public IReadOnlyList<ApiEnum<T>> UnknownList { get; } = Array.Empty<ApiEnum<T>>();


        /// <summary>
        /// Converts an array of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static implicit operator ApiFlags<T>(ApiEnum<T>[] l) =>
            new ApiFlags<T>(l);

        /// <summary>
        /// Converts an array of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static ApiFlags<T> From(ApiEnum<T>[] l) => l;

        /// <summary>
        /// Converts a list of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static implicit operator ApiFlags<T>(List<ApiEnum<T>> l) =>
            new ApiFlags<T>(l);

        /// <summary>
        /// Converts an array of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static ApiFlags<T> From(List<ApiEnum<T>> l) => l;

        /// <summary>
        /// Converts a collection of enums to API flags.
        /// </summary>
        /// <param name="l">The collection of enums.</param>
        public static implicit operator ApiFlags<T>(Collection<ApiEnum<T>> l) =>
            new ApiFlags<T>(l);

        /// <summary>
        /// Converts a collection of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static ApiFlags<T> From(Collection<ApiEnum<T>> l) => l;

        /// <summary>
        /// Converts a set of enums to API flags.
        /// </summary>
        /// <param name="l">The set of enums.</param>
        public static implicit operator ApiFlags<T>(HashSet<ApiEnum<T>> l) =>
            new ApiFlags<T>(l);

        /// <summary>
        /// Converts a set of enums to API flags.
        /// </summary>
        /// <param name="l">The list of enums.</param>
        public static ApiFlags<T> From(HashSet<ApiEnum<T>> l) => l;

        /// <summary>
        /// Converts API flags to an array of enums.
        /// </summary>
        /// <param name="e">The API enum.</param>
#pragma warning disable CA2225 // Operator overloads have named alternates
        public static implicit operator ApiEnum<T>[](ApiFlags<T> e) =>
            e.List.ToArray();
#pragma warning restore CA2225 // Operator overloads have named alternates

        /// <summary>
        /// Converts API flags to an array of enums.
        /// </summary>
        /// <returns>The enum.</returns>
        public ApiEnum<T>[] ToArray() => this;

        /// <summary>
        /// Converts API flags to a list of enums.
        /// </summary>
        /// <param name="e">The API enum.</param>
        public static implicit operator List<ApiEnum<T>>(ApiFlags<T> e) =>
            e.List.ToList();

        /// <summary>
        /// Converts API flags to a list of enums.
        /// </summary>
        /// <returns>The enum.</returns>
        public List<ApiEnum<T>> ToList() => this;

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is ApiFlags<T> apiFlags && this.Equals(apiFlags);

        /// <inheritdoc />
        public virtual bool Equals(ApiFlags<T>? other) =>
            other is not null && this.List.SequenceEqual(other.List);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 1050334356;
            foreach (var item in this.List)
                hashCode = (hashCode * -1521134295) + EqualityComparer<ApiEnum<T>>.Default.GetHashCode(item);
            return hashCode;
        }

        /// <inheritdoc />
        public IEnumerator<ApiEnum<T>> GetEnumerator() =>
            this.List.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public static bool operator ==(ApiFlags<T> flags1, ApiFlags<T> flags2) =>
            EqualityComparer<ApiFlags<T>>.Default.Equals(flags1, flags2);

        /// <inheritdoc />
        public static bool operator !=(ApiFlags<T> flags1, ApiFlags<T> flags2) =>
            !(flags1 == flags2);
    }
}
