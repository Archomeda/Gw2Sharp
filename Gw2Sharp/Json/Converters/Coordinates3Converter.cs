using System;
using Gw2Sharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles 3D coordinates conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{Coordinates3}" />
    public sealed class Coordinates3Converter : JsonConverter<Coordinates3>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override Coordinates3 ReadJson(JsonReader reader, Type objectType, Coordinates3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JArray jArray))
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return new Coordinates3(jArray[0].ToObject<double>(serializer), jArray[1].ToObject<double>(serializer), jArray[2].ToObject<double>(serializer));
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Coordinates3 value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
