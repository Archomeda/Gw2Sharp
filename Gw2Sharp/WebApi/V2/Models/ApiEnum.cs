using System;
using System.Collections.Generic;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Wraps an API enum to allow unsupported and/or future enum values.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    public class ApiEnum<T> : IEquatable<ApiEnum<T>> where T : Enum
    {
        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        public ApiEnum() : this(default!, null) { }

        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public ApiEnum(T value) : this(value, Enum.GetName(typeof(T), value)) { }

        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="rawValue">The raw value.</param>
        public ApiEnum(T value, string? rawValue)
        {
            this.Value = value;
            this.RawValue = rawValue;
        }


        /// <summary>
        /// Whether the enum value is unknown to the library.
        /// If true, <see cref="RawValue" /> will contain the actual value whereas <see cref="Value" /> will have the default value.
        /// </summary>
        public bool IsUnknown => !string.Equals(this.Value.ToString(), this.RawValue?.Replace("_", ""), StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// The actual enum value as interpreted by the library.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// The raw enum value.
        /// If the original value was <c>undefined</c> or <c>null</c>, this value is <c>null</c>.
        /// </summary>
        public string? RawValue { get; }


        /// <summary>
        /// Converts an enum to an API enum.
        /// </summary>
        /// <param name="e">The enum.</param>
        public static implicit operator ApiEnum<T>(T e) =>
            new ApiEnum<T>(e, e.ToString());

        /// <summary>
        /// Converts a string to an API enum.
        /// </summary>
        /// <param name="e">The enum.</param>
        public static implicit operator ApiEnum<T>(string e) =>
            new ApiEnum<T>(e.ParseEnum<T>(), e);

        /// <summary>
        /// Converts an API enum to its normal enum.
        /// </summary>
        /// <param name="e">The API enum.</param>
        public static implicit operator T(ApiEnum<T> e) =>
            e.Value;

        /// <summary>
        /// Converts an API enum to its raw string form.
        /// </summary>
        /// <param name="e">The API enum.</param>
        public static implicit operator string?(ApiEnum<T> e) =>
            e.RawValue;

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is ApiEnum<T> apiEnum && this.Equals(apiEnum);

        /// <inheritdoc />
        public virtual bool Equals(ApiEnum<T> other)
        {
            return !(other is null) &&
                EqualityComparer<T>.Default.Equals(this.Value, other.Value) &&
                EqualityComparer<string>.Default.Equals(this.RawValue?.ToLowerInvariant(), other.RawValue?.ToLowerInvariant());
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -159790080;
                hashCode = (hashCode * -1521134295) + EqualityComparer<Enum>.Default.GetHashCode(this.Value);
                if (this.RawValue != null)
                    hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.RawValue.ToLowerInvariant());
                return hashCode;
            }
        }

        /// <inheritdoc />
        public override string? ToString() =>
            this.RawValue;

        /// <inheritdoc />
        public static bool operator ==(ApiEnum<T> enum1, ApiEnum<T> enum2) =>
            EqualityComparer<ApiEnum<T>>.Default.Equals(enum1, enum2);

        /// <inheritdoc />
        public static bool operator !=(ApiEnum<T> enum1, ApiEnum<T> enum2) =>
            !(enum1 == enum2);
    }
}
