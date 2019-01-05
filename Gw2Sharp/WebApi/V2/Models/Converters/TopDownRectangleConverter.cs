using Newtonsoft.Json;
using System;

namespace Gw2Sharp.WebApi.V2.Models.Converters
{
    /// <summary>
    /// A custom JSON converter that handles top-down rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public class TopDownRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            this.ReadJson(reader, objectType, existingValue, hasExistingValue, serializer, RectangleDirectionType.TopDown);
    }
}
