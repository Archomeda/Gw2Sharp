using Newtonsoft.Json;
using System;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles bottom-up rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public class BottomUpRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            ReadJson(reader, objectType, existingValue, hasExistingValue, serializer, RectangleDirectionType.BottomUp);
    }
}
