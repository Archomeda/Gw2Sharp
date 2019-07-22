using System;
using Gw2Sharp.WebApi.V2.Models;
using Newtonsoft.Json;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles bottom-up rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public sealed class BottomUpRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            this.ReadJson(reader, objectType, existingValue, hasExistingValue, serializer, RectangleDirectionType.BottomUp);
    }
}
