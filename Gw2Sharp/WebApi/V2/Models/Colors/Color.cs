using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a color.
    /// </summary>
    public class Color : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The color id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The color name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The color base RGB.
        /// </summary>
        public IReadOnlyList<int> BaseRgb { get; set; } = new List<int>();

        /// <summary>
        /// The color cloth material.
        /// </summary>
        public ColorMaterial Cloth { get; set; } = new ColorMaterial();

        /// <summary>
        /// The color leather material.
        /// </summary>
        public ColorMaterial Leather { get; set; } = new ColorMaterial();

        /// <summary>
        /// The color metal meterial.
        /// </summary>
        public ColorMaterial Metal { get; set; } = new ColorMaterial();

        /// <summary>
        /// The color fur material.
        /// </summary>
        public ColorMaterial Fur { get; set; } = new ColorMaterial();

        /// <summary>
        /// The dye item that unlocks this color.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Item { get; set; }

        /// <summary>
        /// The list of color categories.
        /// </summary>
        public IReadOnlyList<string> Categories { get; set; } = new List<string>();
    }
}
