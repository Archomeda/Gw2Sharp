using System;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles GUID conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{Guid}" />
    public sealed class GuidConverter : JsonConverter<Guid>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            return new Guid(serializer.Deserialize<string>(reader));
        }
            
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
