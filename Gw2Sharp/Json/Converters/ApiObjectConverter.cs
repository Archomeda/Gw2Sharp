using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles API objects.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public sealed class ApiObjectConverter : JsonConverter<IApiV2Object>
    {
        /// <inheritdoc />
        public override IApiV2Object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<ApiV2BaseObject>(ref reader, options);

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, IApiV2Object value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
