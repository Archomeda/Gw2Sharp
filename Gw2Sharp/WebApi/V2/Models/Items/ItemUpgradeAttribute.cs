namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An item upgrade attribute.
    /// </summary>
    public class ItemUpgradeAttribute
    {
        /// <summary>
        /// The item upgrade attribute type.
        /// </summary>
        public ApiEnum<ItemAttributeType> Attribute { get; set; }

        /// <summary>
        /// The modifier value.
        /// </summary>
        public int Modifier { get; set; }
    }
}
