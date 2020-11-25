using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.WebApi.V2;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles API object lists.
    /// </summary>
    /// <seealso cref="JsonConverterFactory" />
    public sealed class ApiObjectListConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(IApiV2ObjectList<>);

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var innerType = typeToConvert.GetGenericArguments()[0];
            var type = typeof(ApiObjectListConverterInner<>).MakeGenericType(innerType);
            return (JsonConverter?)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
        }

        private sealed class ApiObjectListConverterInner<T> : JsonConverter<ApiV2BaseObjectList<T>>
        {
            public override ApiV2BaseObjectList<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                JsonSerializer.Deserialize<ApiV2BaseObjectList<T>>(ref reader, options);

            public override void Write(Utf8JsonWriter writer, ApiV2BaseObjectList<T> value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }
    }
}
