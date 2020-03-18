using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.V2.Models;

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
            private readonly Type type;
            private readonly T defaultValue;

            public ApiEnumConverterInner()
            {
                this.type = typeof(T);

                var defaultValueAttribute = this.type.GetCustomAttribute<DefaultValueAttribute>();
                this.defaultValue = (T)(defaultValueAttribute?.Value ?? Enum.ToObject(this.type, 0));
            }

            public override ApiEnum<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    // If it's a string, create an enum with that value
                    string rawValue = reader.GetString();
                    var value = rawValue.ParseEnum<T>();
                    return new ApiEnum<T>(value, rawValue);
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    // If it's a number, create an enum with that value
                    int rawValue = reader.GetInt32();
                    var value = (T)Enum.ToObject(this.type, rawValue);
                    return new ApiEnum<T>(value, rawValue.ToString());
                }

                throw new JsonException("Expected null, a string or a number to deserialize as enum");
            }

            public override void Write(Utf8JsonWriter writer, ApiEnum<T> value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }
    }
}
