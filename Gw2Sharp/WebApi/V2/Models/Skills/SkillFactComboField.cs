namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A combo field skill fact.
    /// </summary>
    public class SkillFactComboField : SkillFact
    {
        /// <summary>
        /// The combo field type.
        /// </summary>
        public ApiEnum<ComboFieldType> FieldType { get; set; } = new ApiEnum<ComboFieldType>();
    }
}
