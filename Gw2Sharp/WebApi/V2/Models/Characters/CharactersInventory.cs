using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters inventory endpoint.
    /// </summary>
    public class CharactersInventory
    {
        /// <summary>
        /// The list of the character inventory bags.
        /// </summary>
        public IReadOnlyList<CharacterInventoryBag> Bags { get; set; } = new List<CharacterInventoryBag>();
    }
}
