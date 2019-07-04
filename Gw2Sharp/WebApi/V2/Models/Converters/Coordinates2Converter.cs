using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles 2D coordinates conversion.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{Coordinates2}" />
    public class Coordinates2Converter : JsonConverter<Coordinates2>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override Coordinates2 ReadJson(JsonReader reader, Type objectType, Coordinates2 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JArray jArray))
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return new Coordinates2(jArray[0].ToObject<double>(serializer), jArray[1].ToObject<double>(serializer));
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Coordinates2 value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
