using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles size conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{Size}" />
    public sealed class SizeConverter : JsonConverter<Size>
    {
        /// <inheritdoc />
        public override Size Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            int[] values = new int[2];
            for (int i = 0; i < 2; i++)
            {
                if (!reader.Read())
                    throw new JsonException("Unexpected end of array");

                if (reader.TryGetInt32(out int value))
                    values[i] = value;
                else
                    throw new JsonException("Expected an int");
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException("Expected end of array");

            return new Size(values[0], values[1]);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Size value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
