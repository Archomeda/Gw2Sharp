using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match world id container.
    /// </summary>
    public class WvwMatchWorldIdContainer : ApiV2BaseObject
    {
        /// <summary>
        /// The Ids of the red worlds
        /// </summary>
        public IReadOnlyList<int> Red { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The Ids of the blue worlds
        /// </summary>
        public IReadOnlyList<int> Blue { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The Ids of the green worlds
        /// </summary>
        public IReadOnlyList<int> Green { get; set; } = Array.Empty<int>();
    }
}
