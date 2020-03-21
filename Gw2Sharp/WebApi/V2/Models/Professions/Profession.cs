using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;

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
        /// The profession code.
        /// Used in build template chat links.
        /// </summary>
        public int Code { get; set; }

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
        public IReadOnlyList<int> Specializations { get; set; } = Array.Empty<int>();

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
        public IReadOnlyList<ProfessionSkill> Skills { get; set; } = Array.Empty<ProfessionSkill>();

        /// <summary>
        /// The profession training.
        /// </summary>
        public IReadOnlyList<ProfessionTraining> Training { get; set; } = Array.Empty<ProfessionTraining>();

        /// <summary>
        /// The map of skill palette ids to skill ids.
        /// </summary>
        [JsonConverter(typeof(CompactMapConverter))]
        public IDictionary<int, int> SkillsByPalette { get; set; } = new Dictionary<int, int>();
    }
}
