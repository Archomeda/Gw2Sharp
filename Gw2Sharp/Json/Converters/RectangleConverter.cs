using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles rectangle conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{Rectangle}" />
    public abstract class RectangleConverter : JsonConverter<Rectangle>
    {
        /// <summary>
        /// Reads and converts the JSON to type <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <param name="directionType">The rectangle direction type.</param>
        /// <returns>The converted value.</returns>
        public Rectangle Read(ref Utf8JsonReader reader, JsonSerializerOptions options, RectangleDirectionType directionType)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            var values = new Coordinates2[2];
            for (int i = 0; i < 2; i++)
            {
                if (!reader.Read())
                    throw new JsonException("Unexpected end of array");

                values[i] = JsonSerializer.Deserialize<Coordinates2>(ref reader, options);
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException("Expected end of array");

            return new Rectangle(values[0], values[1], directionType);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Rectangle value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
