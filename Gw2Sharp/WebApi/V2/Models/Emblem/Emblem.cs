using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an emblem.
    /// </summary>
    public class Emblem : IIdentifiable<int>
    {
        /// <summary>
        /// The emblem id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The emblem layer images.
        /// </summary>
        public IReadOnlyList<string> Layers { get; set; } = new List<string>();
    }
}
