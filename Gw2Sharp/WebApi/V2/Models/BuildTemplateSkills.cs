using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the build template skills.
    /// </summary>
    public class BuildTemplateSkills
    {
        /// <summary>
        /// The healing skill.
        /// If no healing skill is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int? Heal { get; set; }

        /// <summary>
        /// The list of utility skills.
        /// If a utility skill is not selected in a specific slot, that element is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public IReadOnlyList<int?> Utilities { get; set; } = Array.Empty<int?>();

        /// <summary>
        /// The elite skill.
        /// If no elite skill is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int? Elite { get; set; }
    }
}
