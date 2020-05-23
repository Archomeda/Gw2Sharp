using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a story season.
    /// </summary>
    public class StorySeason : ApiV2BaseObject, IIdentifiable<Guid>
    {
        /// <summary>
        /// The story season id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The story season name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The story season order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The season stories.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Stories"/>.
        /// </summary>
        public IReadOnlyList<int> Stories { get; set; } = Array.Empty<int>();
    }
}
