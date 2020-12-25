using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles dictionary conversions with ints as key.
    /// </summary>
    /// <seealso cref="JsonConverterFactory" />
    public sealed class DictionaryIntKeyConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsGenericType &&
            (typeToConvert.GetGenericTypeDefinition() == typeof(IDictionary<,>) || typeToConvert.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>)) &&
            typeToConvert.GetGenericArguments()[0] == typeof(int);

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var valueType = typeToConvert.GetGenericArguments()[1];
            var type = typeToConvert.GetGenericTypeDefinition() == typeof(IDictionary<,>)
                ? typeof(DictionaryIntKeyConverterInner<>).MakeGenericType(valueType)
                : typeof(DictionaryIntKeyConverterInnerReadOnly<>).MakeGenericType(valueType);
            return (JsonConverter?)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, new object?[] { options }, null);
        }

        private sealed class DictionaryIntKeyConverterInner<TValue> : JsonConverter<IDictionary<int, TValue>>
        {
            private readonly JsonConverter<TValue>? valueConverter;
            private readonly Type valueType;

            public DictionaryIntKeyConverterInner(JsonSerializerOptions options)
            {
                this.valueConverter = (JsonConverter<TValue>)options.GetConverter(typeof(TValue));
                this.valueType = typeof(TValue);
            }

            public override IDictionary<int, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                ReadShared(this.valueConverter, this.valueType, ref reader, options);

            public override void Write(Utf8JsonWriter writer, IDictionary<int, TValue> value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }

        private sealed class DictionaryIntKeyConverterInnerReadOnly<TValue> : JsonConverter<IReadOnlyDictionary<int, TValue>>
        {
            private readonly JsonConverter<TValue>? valueConverter;
            private readonly Type valueType;

            public DictionaryIntKeyConverterInnerReadOnly(JsonSerializerOptions options)
            {
                this.valueConverter = (JsonConverter<TValue>)options.GetConverter(typeof(TValue));
                this.valueType = typeof(TValue);
            }

            public override IReadOnlyDictionary<int, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                ReadShared(this.valueConverter, this.valueType, ref reader, options);

            public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<int, TValue> value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }

        private static Dictionary<int, TValue> ReadShared<TValue>(JsonConverter<TValue>? valueConverter, Type valueType, ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected the start of an object");

            var result = new Dictionary<int, TValue>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return result;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("Expected a property name");

                if (!int.TryParse(reader.GetString(), out int key))
                    throw new JsonException("Expected a number as property name");

                TValue value;
                if (valueConverter != null)
                {
                    reader.Read();
                    value = valueConverter.Read(ref reader, valueType, options);
                }
                else
                {
                    value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                }

                if (value is null)
                    throw new JsonException("Unexpected null value");
                result.Add(key, value);
            }

            throw new JsonException("Unexpected end of dictionary");
        }
    }
}
