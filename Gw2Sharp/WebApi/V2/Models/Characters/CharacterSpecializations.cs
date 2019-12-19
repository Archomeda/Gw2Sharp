using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the character specializations.
    /// </summary>
    public class CharacterSpecializations
    {
        /// <summary>
        /// The list of PvE character specializations.
        /// If a specialization is not selected in a specific slot, that value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<BuildTemplateSpecialization>? Pve { get; set; }

        /// <summary>
        /// The list of PvP character specializations.
        /// If a specialization is not selected in a specific slot, that value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<BuildTemplateSpecialization>? Pvp { get; set; }

        /// <summary>
        /// The list of WvW character specializations.
        /// If a specialization is not selected in a specific slot, that value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<BuildTemplateSpecialization>? Wvw { get; set; }
    }
}
