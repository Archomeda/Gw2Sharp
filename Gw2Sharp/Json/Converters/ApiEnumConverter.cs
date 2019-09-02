using System;
using System.ComponentModel;
using System.Linq;
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
        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var fToken = serializer.Deserialize<JToken>(reader);
            if (fToken is JValue jValue)
            {
                // Get generic type information and some sanity checks
                var typeInfo = objectType.GetTypeInfo();
                var enumType = typeInfo.IsGenericType ? typeInfo.GenericTypeArguments.FirstOrDefault() : null;
                if (enumType == null)
                    return null;

                // If it's explicitly defined as null, create an enum with null raw value and default enum value
                if (jValue.Type == JTokenType.Null)
                {
                    var defaultValueAttribute = enumType.GetCustomAttribute<DefaultValueAttribute>();
                    object enumValue = defaultValueAttribute != null ? defaultValueAttribute.Value : Enum.ToObject(enumType, 0);
                    return Activator.CreateInstance(objectType, enumValue, null);
                }

                // It's a value, create an enum with that value
                string rawValue = jValue.ToObject<string>();
                var value = rawValue.ParseEnum(enumType);
                return Activator.CreateInstance(objectType, value, rawValue);
            }
            throw new JsonSerializationException($"Expected an enum value or null");
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) =>
            objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(ApiEnum<>);
    }
}
