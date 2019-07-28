using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An item infix upgrade.
    /// </summary>
    public class ItemInfixUpgrade
    {
        /// <summary>
        /// The infix upgrade item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Itemstats"/>.
        /// If the infix upgrade does not have an item, this value is <c>null</c>.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The infix upgrade item attributes.
        /// </summary>
        public IReadOnlyList<ItemUpgradeAttribute> Attributes { get; set; } = new List<ItemUpgradeAttribute>();

        /// <summary>
        /// The infix upgrade buff.
        /// </summary>
        public ItemBuff Buff { get; set; } = new ItemBuff();
    }
}
