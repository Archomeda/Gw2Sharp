using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.WebApi.V2.Models;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiEnum{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverterFactory" />
    public sealed class ApiEnumConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ApiEnum<>) && typeToConvert.GetGenericArguments()[0].IsEnum;

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var innerType = typeToConvert.GetGenericArguments()[0];
            var type = typeof(ApiEnumConverterInner<>).MakeGenericType(innerType);
            return (JsonConverter?)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
        }

        private sealed class ApiEnumConverterInner<T> : JsonConverter<ApiEnum<T>>
            where T : Enum
        {
            public override ApiEnum<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.TokenType switch
            {
                JsonTokenType.String => new ApiEnum<T>(reader.GetString()!),
                JsonTokenType.Number => new ApiEnum<T>(reader.GetUInt64()),
                _ => throw new JsonException("Expected null, a string or a number to deserialize as enum")
            };

            public override void Write(Utf8JsonWriter writer, ApiEnum<T> value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }
    }
}
