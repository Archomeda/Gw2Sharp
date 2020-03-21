using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles rectangle conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{int}" />
    public class StringAsIntConverter : JsonConverter<int?>
    {
        /// <inheritdoc />
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Expected a string");

            string str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str))
                return null;

            if (int.TryParse(str, out int value))
                return value;

            throw new JsonException("Invalid integer as string");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
