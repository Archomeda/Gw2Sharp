namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a quest goal.
    /// </summary>
    public class QuestGoal
    {
        /// <summary>
        /// The quest goal description when the quest is active.
        /// </summary>
        public string Active { get; set; } = string.Empty;

        /// <summary>
        /// The quest goal description when the quest is complete.
        /// </summary>
        public string Complete { get; set; } = string.Empty;
    }
}
