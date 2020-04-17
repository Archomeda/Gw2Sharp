namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a skill fact.
    /// </summary>
    [CastableType(SkillFactType.AttributeAdjust, typeof(SkillFactAttributeAdjust))]
    [CastableType(SkillFactType.Buff, typeof(SkillFactBuff))]
    [CastableType(SkillFactType.ComboField, typeof(SkillFactComboField))]
    [CastableType(SkillFactType.ComboFinisher, typeof(SkillFactComboFinisher))]
    [CastableType(SkillFactType.Damage, typeof(SkillFactDamage))]
    [CastableType(SkillFactType.Distance, typeof(SkillFactDistance))]
    [CastableType(SkillFactType.Duration, typeof(SkillFactDuration))]
    [CastableType(SkillFactType.Heal, typeof(SkillFactHeal))]
    [CastableType(SkillFactType.HealingAdjust, typeof(SkillFactHealingAdjust))]
    [CastableType(SkillFactType.NoData, typeof(SkillFactNoData))]
    [CastableType(SkillFactType.Number, typeof(SkillFactNumber))]
    [CastableType(SkillFactType.Percent, typeof(SkillFactPercent))]
    [CastableType(SkillFactType.PrefixedBuff, typeof(SkillFactPrefixedBuff))]
    [CastableType(SkillFactType.Radius, typeof(SkillFactRadius))]
    [CastableType(SkillFactType.Range, typeof(SkillFactRange))]
    [CastableType(SkillFactType.Recharge, typeof(SkillFactRecharge))]
    [CastableType(SkillFactType.StunBreak, typeof(SkillFactStunBreak))]
    [CastableType(SkillFactType.Time, typeof(SkillFactTime))]
    [CastableType(SkillFactType.Unblockable, typeof(SkillFactUnblockable))]
    public class SkillFact : ICastableType<SkillFact, SkillFactType>
    {
        /// <summary>
        /// The text describing the skill fact.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The skill fact icon URL.
        /// If the skill fact doesn't have an icon, this value is <c>null</c>.
        /// </summary>
        public RenderUrl? Icon { get; set; }

        /// <summary>
        /// The skill fact type.
        /// </summary>
        public ApiEnum<SkillFactType> Type { get; set; } = new ApiEnum<SkillFactType>();

        /// <summary>
        /// Only used in <see cref="Skill.TraitedFacts"/>.
        /// The trait that's required for this skill fact to be used.
        /// If the skill fact isn't a traited skill fact, this value is <c>null</c>.
        /// </summary>
        public int? RequiresTrait { get; set; }

        /// <summary>
        /// Only used in <see cref="Skill.TraitedFacts"/>.
        /// The index of <see cref="Skill.Facts"/> that this skill fact overrides when active.
        /// If the skill fact isn't a traited skill fact, or if the traited skill fact doesn't override an existing skill fact, this value is <c>null</c>.
        /// </summary>
        public int? Overrides { get; set; }
    }
}
