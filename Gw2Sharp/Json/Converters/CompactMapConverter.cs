using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles compact map conversion.
    /// </summary>
    /// <seealso cref="JsonConverter{IDictionary}" />
    public class CompactMapConverter : JsonConverter<IDictionary<int, int>>
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
        /// <returns>The object value.</returns>
        public override IDictionary<int, int> ReadJson(JsonReader reader, Type objectType, IDictionary<int, int> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!(serializer.Deserialize<JToken>(reader) is JArray jArray))
                throw new JsonSerializationException($"Expected {nameof(jArray)} to be an array");

            return jArray.ToDictionary(x => (int)x[0], x => (int)x[1]);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, IDictionary<int, int> value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
