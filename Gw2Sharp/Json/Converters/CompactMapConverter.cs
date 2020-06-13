using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles compact map conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public class CompactMapConverter : JsonConverter<IReadOnlyDictionary<int, int>>
    {
        /// <inheritdoc />
        public override IReadOnlyDictionary<int, int> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException("Expected start of array");

            var values = new Dictionary<int, int>();
            int[] pair = new int[2];
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                    return values;

                if (reader.TokenType != JsonTokenType.StartArray)
                    throw new JsonException("Expected start of array");

                for (int i = 0; i < 2; i++)
                {
                    if (!reader.Read())
                        throw new JsonException("Unexpected end of array");

                    if (reader.TryGetInt32(out int value))
                        pair[i] = value;
                    else
                        throw new JsonException("Expected an int");
                }

                if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
                    throw new JsonException("Expected end of array");
                values[pair[0]] = pair[1];
            }

            throw new JsonException("Unexpected end of compact map");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<int, int> value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
