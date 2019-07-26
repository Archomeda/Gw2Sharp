using System;
using Gw2Sharp.WebApi.V2;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles API object lists.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public sealed class ApiObjectListConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var innerType = objectType.GetGenericArguments()[0];
            var type = typeof(ApiV2BaseObjectList<>).MakeGenericType(innerType);
            return serializer.Deserialize(reader, type);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) =>
            objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(IApiV2ObjectList<>);
    }
}
