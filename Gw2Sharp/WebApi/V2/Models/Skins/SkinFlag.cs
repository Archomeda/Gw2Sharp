namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A skin flag.
    /// </summary>
    public enum SkinFlag
    {
        /// <summary>
        /// Unknown flag.
        /// </summary>
        Unknown,

        /// <summary>
        /// The skin is shown in the wardrobe.
        /// </summary>
        ShowInWardrobe,

        /// <summary>
        /// The skin has no cost to apply.
        /// </summary>
        NoCost,

        /// <summary>
        /// The skin is hidden if locked.
        /// </summary>
        HideIfLocked,

        /// <summary>
        /// The skin overrides the rarity of the item.
        /// </summary>
        OverrideRarity
    }
}
