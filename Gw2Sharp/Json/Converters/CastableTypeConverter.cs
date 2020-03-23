using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles castable type conversions.
    /// </summary>
    /// <seealso cref="JsonConverterFactory" />
    public sealed class CastableTypeConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            bool hasInterface = typeToConvert.GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == typeof(ICastableType<,>) && i.GetGenericArguments()[1].IsEnum);
            bool hasAttributes = typeToConvert.GetCustomAttributes<CastableTypeAttribute>().Any();
            return hasInterface && hasAttributes;
        }

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var type = typeof(CastableTypeConverterInner<>).MakeGenericType(typeToConvert);
            return (JsonConverter?)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
        }

        private sealed class CastableTypeConverterInner<T> : JsonConverter<T>
        {
            private static readonly Dictionary<string, Type> targetTypes;

            static CastableTypeConverterInner()
            {
                targetTypes = typeof(T).GetCustomAttributes<CastableTypeAttribute>()
                    .ToDictionary(x =>
                    {
                        string enumValue = x.Value.ToString();
                        var field = x.Value.GetType().GetField(enumValue);
                        var attribute = field?.GetCustomAttribute<EnumMemberAttribute>();
                        return attribute?.Value ?? enumValue;
                    }, x => x.ObjectType);
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException("Expected the start of an object");

                // Get the castable type as string
                using var obj = JsonDocument.ParseValue(ref reader);
                if (!obj.RootElement.TryGetProperty("type", out var typeProperty))
                    throw new JsonException("Expected 'type' property to exist in object to support polymorphism");
                string type = typeProperty.GetString();
                if (string.IsNullOrWhiteSpace(type))
                    throw new JsonException("Expected 'type' property to not be null or empty");

                // Find the castable type
                if (targetTypes.TryGetValue(type, out var targetType))
                    return (T)JsonSerializer.Deserialize(obj.RootElement.GetRawText(), targetType, options);
                foreach (var value in targetTypes)
                {
                    if (string.Equals(type, value.Key, StringComparison.OrdinalIgnoreCase))
                        return (T)JsonSerializer.Deserialize(obj.RootElement.GetRawText(), value.Value, options);
                }

                throw new JsonException($"Unsupported type {type}");
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }
    }
}
