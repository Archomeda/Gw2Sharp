using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a color.
    /// </summary>
    public class Color : IIdentifiable<int>
    {
        /// <summary>
        /// The color id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The color name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color base RGB.
        /// </summary>
        public IReadOnlyList<int> BaseRgb { get; set; }

        /// <summary>
        /// The color cloth material.
        /// </summary>
        public ColorMaterial Cloth { get; set; }

        /// <summary>
        /// The color leather material.
        /// </summary>
        public ColorMaterial Leather { get; set; }

        /// <summary>
        /// The color metal meterial.
        /// </summary>
        public ColorMaterial Metal { get; set; }

        /// <summary>
        /// The dye item that unlocks this color.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Item { get; set; }

        /// <summary>
        /// The list of color categories.
        /// </summary>
        public IReadOnlyList<string> Categories { get; set; }
    }
}
