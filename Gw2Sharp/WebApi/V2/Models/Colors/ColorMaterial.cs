using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a color material.
    /// </summary>
    public class ColorMaterial
    {
        /// <summary>
        /// The color brightness.
        /// </summary>
        public int Brightness { get; set; }

        /// <summary>
        /// The color contrast.
        /// </summary>
        public double Contrast { get; set; }

        /// <summary>
        /// The color hue.
        /// </summary>
        public int Hue { get; set; }

        /// <summary>
        /// The color saturation.
        /// </summary>
        public double Saturation { get; set; }

        /// <summary>
        /// The color lightness.
        /// </summary>
        public double Lightness { get; set; }

        /// <summary>
        /// The precalculated RGB values.
        /// </summary>
        public IReadOnlyList<int> Rgb { get; set; }
    }
}
