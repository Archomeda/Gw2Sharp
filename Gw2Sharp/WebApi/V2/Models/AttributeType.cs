namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An item attribute type.
    /// </summary>
    public enum AttributeType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Concentration.
        /// </summary>
        BoonDuration,

        /// <summary>
        /// Condition damage.
        /// </summary>
        ConditionDamage,

        /// <summary>
        /// Expertise.
        /// </summary>
        ConditionDuration,

        /// <summary>
        /// Ferocity.
        /// </summary>
        CritDamage,

        /// <summary>
        /// Healing power.
        /// </summary>
        Healing,

        /// <summary>
        /// Power.
        /// </summary>
        Power,

        /// <summary>
        /// Precision.
        /// </summary>
        Precision,

        /// <summary>
        /// Toughness.
        /// </summary>
        Toughness,

        /// <summary>
        /// Vitality.
        /// </summary>
        Vitality,

        /// <summary>
        /// Agony resistance.
        /// </summary>
        AgonyResistance
    }
}
