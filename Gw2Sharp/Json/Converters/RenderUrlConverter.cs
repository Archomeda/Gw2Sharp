using System;
using Gw2Sharp.WebApi;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles GUID conversions.
    /// </summary>
    /// <seealso cref="JsonConverter{RenderUrl}" />
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
        public override bool CanWrite => false;

        /// <inheritdoc />
        public override RenderUrl ReadJson(JsonReader reader, Type objectType, RenderUrl existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            new RenderUrl(this.gw2Client, serializer.Deserialize<string>(reader));

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, RenderUrl value, JsonSerializer serializer) =>
            throw new NotImplementedException("TODO: This should generally not be used since we only deserialize stuff from the API, and not serialize to it. Might add support later.");
    }
}
