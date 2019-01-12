using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Gw2Sharp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiFlags{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class ApiFlagsConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JArray jArray))
                throw new JsonSerializationException($"Expected a value for {nameof(jArray)}");

            // Get generic type information and some sanity checks
            var typeInfo = objectType.GetTypeInfo();
            Type enumType;
            if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments.Length > 0)
                enumType = typeInfo.GenericTypeArguments[0];
            else
                return null!;
            var apiEnumType = typeof(ApiEnum<>).MakeGenericType(enumType);

            var flags = jArray.Select(e =>
            {
                string rawValue = e.ToObject<string>();
                var value = rawValue.ParseEnum(enumType);
                return (ApiEnum)Activator.CreateInstance(apiEnumType, value, rawValue);
            }).ToList();
            return (ApiFlags)Activator.CreateInstance(objectType, (IReadOnlyList<ApiEnum>)flags);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => objectType == typeof(ApiFlags);
    }
}
