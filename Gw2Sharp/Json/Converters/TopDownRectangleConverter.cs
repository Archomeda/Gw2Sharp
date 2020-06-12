using System;
using System.Text.Json;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.Json.Converters
{
    /// <summary>
    /// A custom JSON converter that handles top-down rectangle conversion.
    /// </summary>
    /// <seealso cref="RectangleConverter" />
    public sealed class TopDownRectangleConverter : RectangleConverter
    {
        /// <inheritdoc />
        public override Rectangle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            Read(ref reader, options, RectangleDirectionType.TopDown);
    }
}
