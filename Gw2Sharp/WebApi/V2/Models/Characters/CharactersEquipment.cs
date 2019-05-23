using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters equipment endpoint.
    /// </summary>
    public class CharactersEquipment : ApiV2BaseObject
    {
        /// <summary>
        /// The list of the character equipment.
        /// </summary>
        public IReadOnlyList<CharacterEquipmentItem> Equipment { get; set; } = new List<CharacterEquipmentItem>();
    }
}
