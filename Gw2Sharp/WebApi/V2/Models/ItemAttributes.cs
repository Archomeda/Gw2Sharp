using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the attributes of an item.
    /// </summary>
    public class ItemAttributes
    {
        /// <summary>
        /// The power attribute.
        /// If the item has no power attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "Power")]
        public int? Power { get; set; }

        /// <summary>
        /// The precision attribute.
        /// If the item has no precision attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "Precision")]
        public int? Precision { get; set; }

        /// <summary>
        /// The ferocity attribute.
        /// If the item has no ferocity attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "CritDamage")]
        public int? CritDamage { get; set; }

        /// <summary>
        /// The toughness attribute.
        /// If the item has no toughness attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "Toughness")]
        public int? Toughness { get; set; }

        /// <summary>
        /// The virtality attribute.
        /// If the item has no virtality attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "Vitality")]
        public int? Vitality { get; set; }

        /// <summary>
        /// The condition damage attribute.
        /// If the item has no condition damage attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "ConditionDamage")]
        public int? ConditionDamage { get; set; }

        /// <summary>
        /// The condition duration attribute.
        /// If the item has no condition duration attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "ConditionDuration")]
        public int? ConditionDuration { get; set; }

        /// <summary>
        /// The healing attribute.
        /// If the item has no healing attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "Healing")]
        public int? Healing { get; set; }

        /// <summary>
        /// The boon duration attribute.
        /// If the item has no boon duration attribute, this value is <c>null</c>.
        /// </summary>
        [JsonProperty(PropertyName = "BoonDuration")]
        public int? BoonDuration { get; set; }
    }
}
