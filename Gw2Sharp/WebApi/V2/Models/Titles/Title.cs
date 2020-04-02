using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a title.
    /// </summary>
    public class Title : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The title id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The associated achievement.
        /// This property is outdated and should not be used anymore.
        /// Instead, use <see cref="Achievements"/>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// </summary>
        public int Achievement { get; set; }

        /// <summary>
        /// The associated achievements.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Achievements"/>.
        /// </summary>
        public IReadOnlyList<int> Achievements { get; set; } = Array.Empty<int>();
    }
}
