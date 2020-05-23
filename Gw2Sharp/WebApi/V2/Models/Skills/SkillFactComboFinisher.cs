namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A combo finisher skill fact.
    /// </summary>
    public class SkillFactComboFinisher : SkillFact
    {
        /// <summary>
        /// The combo finisher type.
        /// </summary>
        public ApiEnum<ComboFinisherType> FinisherType { get; set; } = new ApiEnum<ComboFinisherType>();

        /// <summary>
        /// The combo finisher trigger chance in percent.
        /// </summary>
        public double Percent { get; set; }
    }
}
