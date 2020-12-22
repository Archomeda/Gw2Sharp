using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents lists of team values of a WvW match.
    /// </summary>
    public class WvwMatchTeamList : ApiV2BaseObject
    {
        /// <summary>
        /// The red team values.
        /// </summary>
        public IReadOnlyList<int> Red { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The blue team values.
        /// </summary>
        public IReadOnlyList<int> Blue { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The green team values.
        /// </summary>
        public IReadOnlyList<int> Green { get; set; } = Array.Empty<int>();
    }
}
