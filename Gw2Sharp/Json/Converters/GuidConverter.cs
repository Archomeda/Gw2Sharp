using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles GUID conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public sealed class GuidConverter : JsonConverter<Guid>
    {
        /// <inheritdoc />
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            Guid.TryParse(reader.GetString(), out var result) ? result : Guid.Empty;

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
