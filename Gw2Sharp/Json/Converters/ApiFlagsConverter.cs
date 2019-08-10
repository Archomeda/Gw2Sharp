using System;
using System.Linq;
using System.Reflection;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiFlags{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public sealed class ApiFlagsConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var fToken = serializer.Deserialize<JToken>(reader);
            if (fToken.Type == JTokenType.Null)
                return null;
            if (!(fToken is JArray jArray))
                throw new JsonSerializationException($"Expected an array for {nameof(jArray)}");

            // Get generic type information and some sanity checks
            var typeInfo = objectType.GetTypeInfo();
            Type enumType;
            if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments.Length > 0)
                enumType = typeInfo.GenericTypeArguments[0];
            else
                return null;
            var apiEnumType = typeof(ApiEnum<>).MakeGenericType(enumType);

            var flags = jArray.Select(e =>
            {
                string rawValue = e.ToObject<string>();
                var value = rawValue.ParseEnum(enumType);
                return Activator.CreateInstance(apiEnumType, value, rawValue);
            });
            return Activator.CreateInstance(objectType, BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { flags }, null);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) =>
          objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ApiFlags<>);
    }
}
