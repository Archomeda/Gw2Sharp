using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles timespan conversions.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{Size}" />
    public class TimeSpanConverter : JsonConverter<TimeSpan>
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
