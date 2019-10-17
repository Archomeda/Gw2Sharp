namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an itemstat attribute.
    /// </summary>
    public class ItemstatAttribute
    {
        /// <summary>
        /// The itemstat attribute type.
        /// </summary>
        public ApiEnum<AttributeType> Attribute { get; set; } = new ApiEnum<AttributeType>();

        /// <summary>
        /// The itemstat attribute multiplier.
        /// </summary>
        public double Multiplier { get; set; }

        /// <summary>
        /// The itemstat attribute value.
        /// </summary>
        public int Value { get; set; }
    }
}
