using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters inventory endpoint.
    /// </summary>
    public class CharactersInventory : ApiV2BaseObject
    {
        /// <summary>
        /// The list of the character inventory bags.
        /// </summary>
        public IReadOnlyList<CharacterInventoryBag> Bags { get; set; } = Array.Empty<CharacterInventoryBag>();
    }
}
