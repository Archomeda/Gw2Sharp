using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mastery.
    /// </summary>
    public class Mastery : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The mastery id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The mastery name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mastery requirement details.
        /// </summary>
        public string Requirement { get; set; } = string.Empty;

        /// <summary>
        /// The mastery order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The mastery background image URL.
        /// </summary>
        public string Background { get; set; } = string.Empty;

        /// <summary>
        /// The mastery region.
        /// </summary>
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// The mastery levels.
        /// </summary>
        public IReadOnlyList<MasteryLevel> Levels { get; set; } = new List<MasteryLevel>();
    }
}
