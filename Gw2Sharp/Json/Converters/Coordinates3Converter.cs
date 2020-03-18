using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles 3D coordinates conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{Coordinates3}" />
    public sealed class Coordinates3Converter : JsonConverter<Coordinates3>
    {
        /// <inheritdoc />
        public override Coordinates3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            double[] values = new double[3];
            for (int i = 0; i < 3; i++)
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

            return new Coordinates3(values[0], values[1], values[2]);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Coordinates3 value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
