using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles size conversion.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{Size}" />
    public class SizeConverter : JsonConverter<Size>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override Size ReadJson(JsonReader reader, Type objectType, Size existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jArray = serializer.Deserialize<JToken>(reader) as JArray;
            if (jArray == null)
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return new Size(jArray[0].ToObject<int>(serializer), jArray[1].ToObject<int>(serializer));
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Size value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
