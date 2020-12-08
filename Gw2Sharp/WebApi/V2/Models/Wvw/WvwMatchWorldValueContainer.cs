using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match value (kills/deaths/worldId) container.
    /// </summary>
    public class WvwMatchWorldValueContainer : ApiV2BaseObject
    {
        /// <summary>
        /// The value of the red worlds
        /// </summary>
        public int Red { get; set; }

        /// <summary>
        /// The value of the blue worlds
        /// </summary>
        public int Blue { get; set; }

        /// <summary>
        /// The value of the green worlds
        /// </summary>
        public int Green { get; set; }
    }
}
