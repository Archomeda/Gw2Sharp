using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.V2.Models;

#pragma warning disable S1168 // Empty arrays and collections should be returned instead of null

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles <see cref="ApiFlags{T}" />.
    /// </summary>
    /// <seealso cref="JsonConverterFactory" />
    public sealed class ApiFlagsConverter : JsonConverterFactory
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ApiFlags<>) && typeToConvert.GetGenericArguments()[0].IsEnum;

        /// <inheritdoc />
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var innerType = typeToConvert.GetGenericArguments()[0];
            var type = typeof(ApiFlagsConverterInner<>).MakeGenericType(innerType);
            return (JsonConverter?)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public, null, null, null);
        }

        private sealed class ApiFlagsConverterInner<T> : JsonConverter<ApiFlags<T>?>
            where T : Enum
        {
            private readonly Type type;
            private readonly T defaultValue;

            public ApiFlagsConverterInner()
            {
                this.type = typeof(T);

                var defaultValueAttribute = this.type.GetCustomAttribute<DefaultValueAttribute>();
                this.defaultValue = (T)(defaultValueAttribute?.Value ?? Enum.ToObject(this.type, 0));
            }

            public override ApiFlags<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    // If it's explicitly defined as null, just return null
                    return null;
                }
                else if (reader.TokenType == JsonTokenType.StartArray)
                {
                    // If it's an array, create a flag with the values
                    var fEnums = new List<ApiEnum<T>>();

                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.Null)
                        {
                            // If it's explicitly defined as null, create an enum with null raw value and default enum value
                            fEnums.Add(new ApiEnum<T>(this.defaultValue, null));
                        }
                        else if (reader.TokenType == JsonTokenType.String)
                        {
                            // If it's a string, create an enum with that value
                            string rawValue = reader.GetString();
                            var value = rawValue.ParseEnum<T>();
                            fEnums.Add(new ApiEnum<T>(value, rawValue));
                        }
                        else if (reader.TokenType == JsonTokenType.Number)
                        {
                            // If it's a number, create an enum with that value
                            int rawValue = reader.GetInt32();
                            var value = (T)Enum.ToObject(this.type, rawValue);
                            fEnums.Add(new ApiEnum<T>(value, rawValue.ToString()));
                        }
                        else if (reader.TokenType == JsonTokenType.EndArray)
                            break;
                        else
                            throw new JsonException("Expected a string, a number, or the end of the array as an element in a of flags");
                    }

                    return new ApiFlags<T>(fEnums);
                }

                throw new JsonException($"Expected null or an array to deserialize as flags");
            }

            public override void Write(Utf8JsonWriter writer, ApiFlags<T>? value, JsonSerializerOptions options) =>
                throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
        }
    }
}
