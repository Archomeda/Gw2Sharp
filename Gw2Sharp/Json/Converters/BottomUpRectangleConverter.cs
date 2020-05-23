using System;
using System.Text.Json;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles bottom-up rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public sealed class BottomUpRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            this.Read(ref reader, options, RectangleDirectionType.BottomUp);
    }
}
