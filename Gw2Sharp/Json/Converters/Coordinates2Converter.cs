using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles 2D coordinates conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public sealed class Coordinates2Converter : JsonConverter<Coordinates2>
    {
        /// <inheritdoc />
        public override Coordinates2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            double[] values = new double[2];
            for (int i = 0; i < 2; i++)
            {
                if (!reader.Read())
                    throw new JsonException("Unexpected end of array");

                if (reader.TryGetDouble(out double value))
                    values[i] = value;
                else
                    throw new JsonException("Expected a double");
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException("Expected end of array");

            return new Coordinates2(values[0], values[1]);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Coordinates2 value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
