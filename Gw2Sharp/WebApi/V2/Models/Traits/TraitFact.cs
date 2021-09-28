namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a trait fact.
    /// </summary>
    [CastableType(TraitFactType.AttributeAdjust, typeof(TraitFactAttributeAdjust))]
    [CastableType(TraitFactType.Buff, typeof(TraitFactBuff))]
    [CastableType(TraitFactType.BuffConversion, typeof(TraitFactBuffConversion))]
    [CastableType(TraitFactType.ComboField, typeof(TraitFactComboField))]
    [CastableType(TraitFactType.ComboFinisher, typeof(TraitFactComboFinisher))]
    [CastableType(TraitFactType.Damage, typeof(TraitFactDamage))]
    [CastableType(TraitFactType.Distance, typeof(TraitFactDistance))]
    [CastableType(TraitFactType.NoData, typeof(TraitFactNoData))]
    [CastableType(TraitFactType.Number, typeof(TraitFactNumber))]
    [CastableType(TraitFactType.Percent, typeof(TraitFactPercent))]
    [CastableType(TraitFactType.PrefixedBuff, typeof(TraitFactPrefixedBuff))]
    [CastableType(TraitFactType.Radius, typeof(TraitFactRadius))]
    [CastableType(TraitFactType.Range, typeof(TraitFactRange))]
    [CastableType(TraitFactType.Recharge, typeof(TraitFactRecharge))]
    [CastableType(TraitFactType.Time, typeof(TraitFactTime))]
    [CastableType(TraitFactType.Unblockable, typeof(TraitFactUnblockable))]
    public class TraitFact : ICastableType<TraitFact, TraitFactType>
    {
        /// <summary>
        /// The text describing the trait fact.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The trait fact icon URL.
        /// If the trait fact doesn't have an icon, this value is <see langword="null"/>.
        /// </summary>
        public RenderUrl? Icon { get; set; }

        /// <summary>
        /// The trait fact type.
        /// </summary>
        public ApiEnum<TraitFactType> Type { get; set; } = new ApiEnum<TraitFactType>();

        /// <summary>
        /// Only used in <see cref="Trait.TraitedFacts"/>.
        /// The trait that's required for this trait fact to be used.
        /// If the trait fact isn't a traited trait fact, this value is <see langword="null"/>.
        /// </summary>
        public int? RequiresTrait { get; set; }

        /// <summary>
        /// Only used in <see cref="Trait.TraitedFacts"/>.
        /// The index of <see cref="Trait.Facts"/> that this trait fact overrides when active.
        /// If the trait fact isn't a traited trait fact, or if the traited trait fact doesn't override an existing trait fact, this value is <see langword="null"/>.
        /// </summary>
        public int? Overrides { get; set; }
    }
}
