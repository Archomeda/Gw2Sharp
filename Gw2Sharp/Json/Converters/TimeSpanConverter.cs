using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles timespan conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public sealed class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <inheritdoc />
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            TimeSpan.FromSeconds(reader.GetInt64());

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
