using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters backstory endpoint.
    /// </summary>
    public class CharactersBackstory : ApiV2BaseObject
    {
        /// <summary>
        /// The character backstory answers.
        /// Each element can be resolved against <see cref="IBackstoryClient.Answers"/>.
        /// </summary>
        public IReadOnlyList<string> Backstory { get; set; } = new List<string>();
    }
}
