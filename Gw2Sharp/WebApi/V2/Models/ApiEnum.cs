using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Wraps an API enum to allow unsupported and/or future enum values.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    public class ApiEnum<T> : IEquatable<ApiEnum<T>> where T : Enum
    {
        private static readonly T defaultValue;
        private static readonly Dictionary<ulong, T> rawValues = new Dictionary<ulong, T>();
        private static readonly Dictionary<string, T> stringValues = new Dictionary<string, T>();

        static ApiEnum()
        {
            var type = typeof(T);

            var defaultValueAttribute = type.GetCustomAttribute<DefaultValueAttribute>();
            defaultValue = (T)(defaultValueAttribute?.Value ?? Enum.ToObject(type, 0));

            string[] enumNames = type.GetEnumNames();
            var enumValues = type.GetEnumValues();
            for (int i = 0; i < enumNames.Length; i++)
            {
                string enumName = enumNames[i];
                var enumValue = (Enum?)enumValues.GetValue(i);
                if (enumValue == null)
                    continue;
                ulong rawValue = GetEnumValue(enumValue);

                var field = type.GetField(enumNames[i]);
                var attribute = field?.GetCustomAttribute<EnumMemberAttribute>();
                string actualName = attribute?.Value ?? enumName;
                stringValues[actualName] = (T)enumValue;
                rawValues[rawValue] = (T)enumValue;
            }
        }


        /// <summary>
        /// Creates a new API enum.
        /// </summary>
        public ApiEnum() : this(defaultValue, null) { }

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
            this.IsUnknown = rawValue == null || !ContainsValue(rawValue);
        }

        internal ApiEnum(string value)
        {
            this.Value = GetValue(value);
            this.RawValue = value;
            this.IsUnknown = !ContainsValue(value);
        }

        internal ApiEnum(ulong value)
        {
            this.Value = GetValue(value);
            this.RawValue = value.ToString();
            this.IsUnknown = !ContainsValue(value);
        }


        /// <summary>
        /// Whether the enum value is unknown to the library.
        /// If true, <see cref="RawValue" /> will contain the actual value whereas <see cref="Value" /> will have the default value.
        /// </summary>
        public bool IsUnknown { get; }

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
            new ApiEnum<T>(GetValue(e), e);

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
        public virtual bool Equals(ApiEnum<T>? other) =>
            !(other is null) &&
            EqualityComparer<T>.Default.Equals(this.Value, other.Value) &&
            EqualityComparer<string?>.Default.Equals(this.RawValue?.ToLowerInvariant(), other.RawValue?.ToLowerInvariant());

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


        private static ulong GetEnumValue(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.Int32 => (ulong)(int)value,
                TypeCode.UInt32 => (uint)value,
                TypeCode.UInt64 => (ulong)value,
                TypeCode.Int64 => (ulong)(long)value,
                TypeCode.SByte => (ulong)(sbyte)value,
                TypeCode.Byte => (byte)value,
                TypeCode.Int16 => (ulong)(short)value,
                TypeCode.UInt16 => (ushort)value,
                _ => throw new ArgumentException($"Invalid typecode {Type.GetTypeCode(typeof(T))}", nameof(value))
            };
        }

        private static bool ContainsValue(string rawValue)
        {
            if (stringValues.ContainsKey(rawValue))
                return true;

            foreach (var value in stringValues)
            {
                if (string.Equals(rawValue, value.Key, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private static bool ContainsValue(ulong rawValue) =>
            rawValues.ContainsKey(rawValue);

        private static T GetValue(string rawValue)
        {
            if (stringValues.TryGetValue(rawValue, out var @enum))
                return new ApiEnum<T>(@enum, rawValue);

            foreach (var value in stringValues)
            {
                if (string.Equals(rawValue, value.Key, StringComparison.OrdinalIgnoreCase))
                    return new ApiEnum<T>(value.Value, rawValue);
            }

            return new ApiEnum<T>(defaultValue, rawValue);
        }

        private static T GetValue(ulong rawValue)
        {
            if (rawValues.TryGetValue(rawValue, out var @enum))
                return new ApiEnum<T>(@enum, rawValue.ToString());
            return new ApiEnum<T>(defaultValue, rawValue.ToString());
        }
    }
}
