using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an itemstat.
    /// </summary>
    public class Itemstat : IIdentifiable<int>
    {
        /// <summary>
        /// The itemstat id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The itemstat name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of itemstat attributes.
        /// </summary>
        public IReadOnlyList<ItemstatAttribute> Attributes { get; set; } = new List<ItemstatAttribute>();
    }
}
