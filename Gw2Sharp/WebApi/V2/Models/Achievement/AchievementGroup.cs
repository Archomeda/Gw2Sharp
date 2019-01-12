using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an achievement group.
    /// </summary>
    public class AchievementGroup : IIdentifiable<Guid>
    {
        /// <summary>
        /// The achievement group id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The achievement group name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The achievement group description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The achievement group order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The achievement categories in the achievement group.
        /// Each element can be resolved against <see cref="IAchievementsClient.Categories"/>.
        /// </summary>
        public IReadOnlyList<int> Categories { get; set; } = new List<int>();
    }
}
