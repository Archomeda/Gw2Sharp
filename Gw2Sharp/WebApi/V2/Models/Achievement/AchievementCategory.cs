using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement category.
    /// </summary>
    public class AchievementCategory : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The achievement category id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The achievement category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The achievement category description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The achievement category order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The achievement category icon.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// The achievements in the achievement category.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// </summary>
        public IReadOnlyList<int> Achievements { get; set; } = new List<int>();
    }
}
