namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A recipe flag.
    /// </summary>
    public enum RecipeFlag
    {
        /// <summary>
        /// Unknown flag.
        /// </summary>
        Unknown,

        /// <summary>
        /// The recipe is automatically learned.
        /// </summary>
        AutoLearned,

        /// <summary>
        /// The recipe is learned from an item.
        /// </summary>
        LearnedFromItem
    }
}
