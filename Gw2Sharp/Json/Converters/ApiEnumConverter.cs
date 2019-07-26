using System;
using System.Reflection;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiEnum{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public sealed class ApiEnumConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JValue jValue))
                throw new JsonSerializationException($"Expected a value for {nameof(jValue)}");

            // Get generic type information and some sanity checks
            var typeInfo = objectType.GetTypeInfo();
            Type enumType;
            if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments.Length > 0)
                enumType = typeInfo.GenericTypeArguments[0];
            else
                return null!;

            string rawValue = jValue.ToObject<string>();
            var value = rawValue.ParseEnum(enumType);
            return (ApiEnum)Activator.CreateInstance(objectType, value, rawValue);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => objectType == typeof(ApiEnum);
    }
}
