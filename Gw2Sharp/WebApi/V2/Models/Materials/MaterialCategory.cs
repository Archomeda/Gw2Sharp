using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a material category.
    /// </summary>
    public class MaterialCategory : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The material category id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The material category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The items that can be stored in this material category.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> Items { get; set; } = new List<int>();

        /// <summary>
        /// The material category order.
        /// </summary>
        public int Order { get; set; }
    }
}
