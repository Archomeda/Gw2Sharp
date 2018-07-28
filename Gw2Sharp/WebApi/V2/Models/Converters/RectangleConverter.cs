using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles rectangle conversion.
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{Rectangle}" />
    public abstract class RectangleConverter : JsonConverter<Rectangle>
    {
        /// <inheritdoc />
        public override bool CanWrite => false;

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read. If there is no existing value then <c>null</c> will be used.</param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <param name="directionType">The rectangle direction type.</param>
        /// <returns>The object value.</returns>
        public Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer, RectangleDirectionType directionType = RectangleDirectionType.TopDown)
        {
            var jArray = serializer.Deserialize<JToken>(reader) as JArray;
            if (jArray == null)
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return new Rectangle(jArray[0].ToObject<Coordinates2>(serializer), jArray[1].ToObject<Coordinates2>(serializer), directionType);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Rectangle value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
