using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the character specialization in a specific game mode.
    /// </summary>
    public class CharacterGameModeSpecialization
    {
        /// <summary>
        /// The specialization id.
        /// If no specialization is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of major traits.
        /// If a trait is not selected in a specific slot, that element is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Traits"/>.
        /// </summary>
        public IReadOnlyList<int?> Traits { get; set; } = Array.Empty<int?>();
    }
}
