using System;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles timespan conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{Size}" />
    public sealed class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            TimeSpan.FromSeconds(serializer.Deserialize<int>(reader));

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
