using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the character skills in a specific game mode.
    /// </summary>
    public class CharacterGameModeSkills
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
        public IReadOnlyList<int?> Utilities { get; set; }

        /// <summary>
        /// The elite skill.
        /// If no elite skill is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int? Elite { get; set; }

        /// <summary>
        /// The list of revenant skills.
        /// If the character is not a revenant, this value is <c>null</c>.
        /// If a legend is not selected in a specific slot, that element is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Legends"/>.
        /// </summary>
        public IReadOnlyList<string> Legends { get; set; }
    }
}
