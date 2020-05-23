using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a skill.
    /// </summary>
    public class Skill : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The skill id.
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
        /// The skill specialization.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// If the skill is not associated with a specific specialization, this value is <c>null</c>.
        /// </summary>
        public int? Specialization { get; set; }

        /// <summary>
        /// The skill chat link.
        /// </summary>
        public string ChatLink { get; set; } = string.Empty;

        /// <summary>
        /// The skill type.
        /// If the skill does not have a type, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<SkillType>? Type { get; set; }

        /// <summary>
        /// The weapon type.
        /// If the skill does not have a weapon type, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<SkillWeaponType>? WeaponType { get; set; }

        /// <summary>
        /// The list of professions that can use this skill.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        public IReadOnlyList<string> Professions { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The skill slot.
        /// If the skill does not have a slot, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<SkillSlot>? Slot { get; set; }

        /// <summary>
        /// The dual attunement.
        /// If the skill does not have a dual attunement, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<Attunement>? DualAttunement { get; set; }

        /// <summary>
        /// The skill flags.
        /// </summary>
        public ApiFlags<SkillFlag> Flags { get; set; } = new ApiFlags<SkillFlag>();

        /// <summary>
        /// The list of skill facts.
        /// If the skill doesn't have any facts, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<SkillFact>? Facts { get; set; }

        /// <summary>
        /// The list of traited skill facts.
        /// If the skill doesn't have any traited facts, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<SkillFact>? TraitedFacts { get; set; }

        /// <summary>
        /// The list of skill categories.
        /// If the skill doesn't have any categories, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<string>? Categories { get; set; }

        /// <summary>
        /// The list of sub skills.
        /// If the skill doesn't have any sub skills, this value is <c>null</c>.
        /// </summary>
        [JsonPropertyName("subskills")]
        public IReadOnlyList<SkillSubSkill>? SubSkills { get; set; }

        /// <summary>
        /// The attunement for elementalist weapon skills.
        /// If the skill isn't an elementalist weapon skill, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<Attunement>? Attunement { get; set; }

        /// <summary>
        /// The skill cost, for e.g. revenant, warrior and druid skills.
        /// If the skill doesn't have any cost, this value is <c>null</c>.
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// The dual wield weapon that needs to be equipped for this dual-wield skill to appear.
        /// If the skill is not part of a dual-wield weapon, this value is <c>null</c>.
        /// </summary>
        public string? DualWield { get; set; }

        /// <summary>
        /// The skill id that this skill can flip to.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill does not have a flip skill, this value is <c>null</c>.
        /// </summary>
        public int? FlipSkill { get; set; }

        /// <summary>
        /// The skill initiative cost for thief skills.
        /// If the skill is not a thief skill, this value is <c>null</c>.
        /// </summary>
        public int? Initiative { get; set; }

        /// <summary>
        /// The next skill in the skill chain.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill does not have a next skill in the chain, or if the skill is not part of a skill chain at all, this value is <c>null</c>.
        /// </summary>
        public int? NextChain { get; set; }

        /// <summary>
        /// The previous skill in the skill chain.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill does not have a previous skill in the chain, or if the skill is not part of a skill chain at all, this value is <c>null</c>.
        /// </summary>
        public int? PrevChain { get; set; }

        /// <summary>
        /// The transform skills that will replace the player's skills when the skill is activated.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill is not a transform skill, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int>? TransformSkills { get; set; }

        /// <summary>
        /// The bundle skills that will replace the player's skills when the skill is activated.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill is not a bundle skill, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<int>? BundleSkills { get; set; }

        /// <summary>
        /// The associated toolbelt skill.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// If the skill is not a toolbelt skill, this value is <c>null</c>.
        /// </summary>
        public int? ToolbeltSkill { get; set; }
    }
}
