using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a profession.
    /// </summary>
    public class Profession : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The profession id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The profession name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The profession icon.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The profession icon (big).
        /// </summary>
        public RenderUrl IconBig { get; set; }

        /// <summary>
        /// The profession specializations.
        /// </summary>
        public IReadOnlyList<int> Specializations { get; set; } = new List<int>();

        /// <summary>
        /// The profession weapons.
        /// </summary>
        public IReadOnlyDictionary<string, ProfessionWeapon> Weapons { get; set; } = new Dictionary<string, ProfessionWeapon>();

        /// <summary>
        /// The profession flags.
        /// </summary>
        public ApiFlags<ProfessionFlag> Flags { get; set; } = new ApiFlags<ProfessionFlag>();

        /// <summary>
        /// The profession skills.
        /// </summary>
        public IReadOnlyList<ProfessionSkill> Skills { get; set; } = new List<ProfessionSkill>();

        /// <summary>
        /// The profession training.
        /// </summary>
        public IReadOnlyList<ProfessionTraining> Training { get; set; } = new List<ProfessionTraining>();
    }
}
