using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters crafting endpoint.
    /// </summary>
    public class CharactersCrafting
    {
        /// <summary>
        /// The list of the character crafting disciplines.
        /// </summary>
        public IReadOnlyList<CharacterCraftingDiscipline> Crafting { get; set; } = new List<CharacterCraftingDiscipline>();
    }
}
