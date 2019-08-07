using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a race.
    /// </summary>
    public class Race : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The race id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The race name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The racial skills.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Skills"/>.
        /// </summary>
        public IReadOnlyList<int> Skills { get; set; } = new List<int>();
    }
}
