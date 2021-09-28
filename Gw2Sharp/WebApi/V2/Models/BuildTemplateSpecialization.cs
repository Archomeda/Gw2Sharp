using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the build template specialization.
    /// </summary>
    public class BuildTemplateSpecialization
    {
        /// <summary>
        /// The specialization id.
        /// If no specialization is selected, this value is <see langword="null"/>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The list of major traits.
        /// If a trait is not selected in a specific slot, that element is <see langword="null"/>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Traits"/>.
        /// </summary>
        public IReadOnlyList<int?> Traits { get; set; } = Array.Empty<int?>();
    }
}
