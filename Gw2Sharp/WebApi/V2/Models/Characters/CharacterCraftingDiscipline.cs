namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character's crafting discipline.
    /// </summary>
    public class CharacterCraftingDiscipline
    {
        /// <summary>
        /// The crafting discipline id.
        /// </summary>
        public string Discipline { get; set; }

        /// <summary>
        /// The current level of the crafting discipline.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Whether the crafting discipline is currently active.
        /// </summary>
        public bool Active { get; set; }
    }
}
