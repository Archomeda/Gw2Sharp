using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account item.
    /// </summary>
    public class AccountItem
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The number of items in the item stack.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The number of charges remaining.
        /// If the item does not support charges, this value is <c>null</c>.
        /// </summary>
        public int? Charges { get; set; }

        /// <summary>
        /// The skin id.
        /// If the item is not skinnable or has the original skin, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int? Skin { get; set; }

        /// <summary>
        /// The selected stats for the equipped item.
        /// If the item has no selectable item stats, this value is <c>null</c>.
        /// </summary>
        public EquipmentItemStats Stats { get; set; }

        /// <summary>
        /// The list of upgrades applied to the item.
        /// If the item does not have any upgrades, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> Upgrades { get; set; }

        /// <summary>
        /// The list of infusions applied to the item.
        /// If the item does not have any upgrades, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> Infusions { get; set; }

        /// <summary>
        /// The current binding of the item.
        /// If the item is not bound, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<ItemBinding> Binding { get; set; }

        /// <summary>
        /// The name of the character to which the item is bound.
        /// If the item is not character bound (see <see cref="Binding"/>), this value is <c>null</c>.
        /// </summary>
        public string BoundTo { get; set; }
    }
}
