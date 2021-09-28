using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a trait skill.
    /// </summary>
    public class TraitSkill
    {
        /// <summary>
        /// The skill id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The skill name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The skill description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The skill icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The skill chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The skill flags.
        /// </summary>
        public ApiFlags<SkillFlag> Flags { get; set; } = new ApiFlags<SkillFlag>();

        /// <summary>
        /// The list of skill facts.
        /// If the skill doesn't have any facts, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<SkillFact>? Facts { get; set; } = Array.Empty<SkillFact>();

        /// <summary>
        /// The list of traited skill facts.
        /// If the skill doesn't have any traited facts, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<SkillFact>? TraitedFacts { get; set; } = Array.Empty<SkillFact>();

        /// <summary>
        /// The list of skill categories.
        /// If the skill doesn't have any categories, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<string>? Categories { get; set; } = Array.Empty<string>();
    }
}
