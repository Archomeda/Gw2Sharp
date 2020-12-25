using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Gw2Sharp.WebApi;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles GUID conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{T}" />
    public sealed class RenderUrlConverter : JsonConverter<RenderUrl>
    {
        private readonly IGw2Client gw2Client;

        /// <summary>
        /// Creates a new <see cref="RenderUrlConverter"/>
        /// </summary>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        public RenderUrlConverter(IGw2Client gw2Client)
        {
            this.gw2Client = gw2Client;
        }

        /// <inheritdoc />
        public override RenderUrl Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Expected a string value");
            return new RenderUrl(this.gw2Client, reader.GetString()!);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, RenderUrl value, JsonSerializerOptions options) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
