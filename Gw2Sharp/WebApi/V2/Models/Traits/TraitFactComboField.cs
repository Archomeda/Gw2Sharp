namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A combo field trait fact.
    /// </summary>
    public class TraitFactComboField : TraitFact
    {
        /// <summary>
        /// The combo field type.
        /// </summary>
        public ApiEnum<ComboFieldType> FieldType { get; set; } = new ApiEnum<ComboFieldType>();
    }
}
