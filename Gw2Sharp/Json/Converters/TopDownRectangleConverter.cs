using System;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles top-down rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public sealed class TopDownRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            this.ReadJson(reader, objectType, existingValue, hasExistingValue, serializer, RectangleDirectionType.TopDown);
    }
}
