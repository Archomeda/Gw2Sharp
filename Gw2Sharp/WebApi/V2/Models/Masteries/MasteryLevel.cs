namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mastery level.
    /// </summary>
    public class MasteryLevel
    {
        /// <summary>
        /// The mastery level name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mastery level description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The mastery level instruction.
        /// </summary>
        public string Instruction { get; set; } = string.Empty;

        /// <summary>
        /// The mastery level icon URL.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// The mastery level cost.
        /// </summary>
        public int PointCost { get; set; }

        /// <summary>
        /// The mastery level experience cost.
        /// </summary>
        public int ExpCost { get; set; }
    }
}
