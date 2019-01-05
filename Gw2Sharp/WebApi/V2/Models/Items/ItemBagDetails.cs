namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the details of a bag item.
    /// </summary>
    public class ItemBagDetails
    {
        /// <summary>
        /// The bag size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Whether the bag prevents selling and/or compacting.
        /// </summary>
        public bool NoSellOrSort { get; set; }
    }
}
