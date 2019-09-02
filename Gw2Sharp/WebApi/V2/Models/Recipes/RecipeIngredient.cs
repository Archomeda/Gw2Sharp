namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a recipe ingredient.
    /// </summary>
    public class RecipeIngredient
    {
        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The number of items.
        /// </summary>
        public int Count { get; set; }
    }
}
