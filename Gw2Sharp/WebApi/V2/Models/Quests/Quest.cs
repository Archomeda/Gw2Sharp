using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a quest.
    /// </summary>
    public class Quest : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The quest id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The quest name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The quest level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The quest story id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Stories"/>.
        /// </summary>
        public int Story { get; set; }

        /// <summary>
        /// The quest goals.
        /// </summary>
        public IReadOnlyList<QuestGoal> Goals { get; set; } = new List<QuestGoal>();
    }
}
