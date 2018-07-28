using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiEnum{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverter" />
    public class ApiEnumConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jValue = serializer.Deserialize<JToken>(reader) as JValue;
            if (jValue == null)
                throw new JsonSerializationException($"Expected a value for {nameof(jValue)}");

            // Get generic type information and some sanity checks
            TypeInfo typeInfo = objectType.GetTypeInfo();
            Type enumType;
            if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments.Length > 0)
                enumType = typeInfo.GenericTypeArguments[0];
            else
                return null;

            var rawValue = jValue.ToObject<string>();
            Enum value = null;
            try
            {
                value = (Enum)Enum.Parse(enumType, rawValue);
            }
            catch (ArgumentException)
            {
                var attribute = enumType.GetTypeInfo().GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                if (attribute != null)
                    value = (Enum)attribute.Value;
            }
            return (ApiEnum)Activator.CreateInstance(objectType, value, rawValue);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => objectType == typeof(ApiEnum);
    }
}
