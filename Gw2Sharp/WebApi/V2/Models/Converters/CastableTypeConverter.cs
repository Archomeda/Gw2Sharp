using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles castable type conversions.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class CastableTypeConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = serializer.Deserialize<JToken>(reader) as JObject;
            if (jObject == null)
                throw new JsonSerializationException($"Expected an object");

            // Get the castable type in string
            var type = jObject["type"].Value<string>();
            if (string.IsNullOrEmpty(type))
                throw new JsonSerializationException($"Expected JSON data to have a string property Type");

            // Get the castable type
            var targetType = objectType.GetCustomAttributes<CastableTypeAttribute>().FirstOrDefault(a => a.Value.ToString() == type)?.ObjectType;
            if (targetType == null)
                return jObject.ToObject(objectType);

            return jObject.ToObject(targetType);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => objectType.GetInterfaces()
            .Where(i => i.IsGenericType)
            .Any(i => i.GetGenericTypeDefinition() == typeof(ICastableType<,>));
    }
}
