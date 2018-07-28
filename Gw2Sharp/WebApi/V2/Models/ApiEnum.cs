using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Wraps an API enum to allow unsupported and/or future enum values.
    /// </summary>
    public abstract class ApiEnum
    {
        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="rawValue">The raw value.</param>
        protected ApiEnum(Enum value, string rawValue)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
            this.RawValue = rawValue ?? throw new ArgumentNullException(nameof(rawValue));
        }

        /// <summary>
        /// Whether the enum value is unknown to the library.
        /// If true, <see cref="RawValue" /> will contain the actual value whereas <see cref="Value" /> will have the default
        /// value.
        /// </summary>
        public bool IsUnknown => !string.Equals(this.Value.ToString(), this.RawValue);

        /// <summary>
        /// The actual enum value as interpreted by the library.
        /// </summary>
        public Enum Value { get; }

        /// <summary>
        /// The raw enum value.
        /// </summary>
        public string RawValue { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var other = obj as ApiEnum;
            if (other == null)
                return false;

            return Equals(this.RawValue, other.RawValue) && Equals(this.Value, other.Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = -1730349647;
            hashCode = hashCode * -1521134295 + EqualityComparer<Enum>.Default.GetHashCode(this.Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.RawValue);
            return hashCode;
        }
    }

    /// <summary>
    /// Wraps an API enum to allow unsupported and/or future enum values.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    [JsonConverter(typeof(ApiEnumConverter))]
    public class ApiEnum<T> : ApiEnum, IEquatable<ApiEnum<T>> where T : Enum
    {
        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        /// <param name="value">The enum value.</param>
        public ApiEnum(T value) : this(value, null) { }

        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="rawValue">The raw value.</param>
        public ApiEnum(T value, string rawValue) : base(value, rawValue ?? Enum.GetName(typeof(T), value)) { }

        /// <summary>
        /// The actual enum value as interpreted by the library.
        /// </summary>
        public new T Value => (T)base.Value;

        /// <summary>
        /// Converts an enum to an API enum.
        /// </summary>
        /// <param name="e">The enum.</param>
        public static implicit operator ApiEnum<T>(T e) => new ApiEnum<T>(e, e.ToString());

        /// <summary>
        /// Converts an API enum to its normal enum.
        /// </summary>
        /// <param name="e">The API enum.</param>
        public static implicit operator T(ApiEnum<T> e) => e.Value;

        /// <summary>
        /// Converts an API enum to its raw string form.
        /// </summary>
        /// <param name="e"></param>
        public static implicit operator string(ApiEnum<T> e) => e.RawValue;

        /// <inheritdoc />
        public bool Equals(ApiEnum<T> other) => other != null && base.Equals(other);
    }
}
