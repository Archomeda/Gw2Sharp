using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters training endpoint.
    /// </summary>
    public class CharactersTraining : ApiV2BaseObject
    {
        /// <summary>
        /// The list of character trainings.
        /// </summary>
        public IReadOnlyList<CharacterTraining> Training { get; set; } = new List<CharacterTraining>();
    }
}
