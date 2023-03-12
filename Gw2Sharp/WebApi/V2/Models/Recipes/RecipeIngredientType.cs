namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// A recipe ingredient type.
    /// </summary>
    public enum RecipeIngredientType
    {
        /// <summary>
        /// Unknown recipe ingredient type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Item ingredient type.
        /// </summary>
        Item,

        /// <summary>
        /// Guild upgrade ingredient type.
        /// </summary>
        GuildUpgrade,

        /// <summary>
        /// Currency ingredient type.
        /// </summary>
        Currency
    }
}
