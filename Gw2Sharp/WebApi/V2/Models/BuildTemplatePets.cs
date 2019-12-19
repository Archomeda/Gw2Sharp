using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the build template pets.
    /// </summary>
    public class BuildTemplatePets
    {
        /// <summary>
        /// The terrestrial pets.
        /// If a pet is not selected in a specific slot, that element is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int?> Terrestrial { get; set; } = Array.Empty<int?>();

        /// <summary>
        /// The aquatic pets.
        /// If a pet is not selected in a specific slot, that element is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int?> Aquatic { get; set; } = Array.Empty<int?>();
    }
}
