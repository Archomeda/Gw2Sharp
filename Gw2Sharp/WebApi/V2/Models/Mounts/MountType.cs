using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mount type.
    /// </summary>
    public class MountType : ApiV2BaseObject, IIdentifiable<string>
    {
        /// <summary>
        /// The mount type id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The mount type name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mount type default skin id.
        /// Can be resolved against <see cref="IMountsClient.Skins"/>.
        /// </summary>
        public int DefaultSkin { get; set; }

        /// <summary>
        /// The mount type skin ids.
        /// Each element can be resolved against <see cref="IMountsClient.Skins"/>.
        /// </summary>
        public IReadOnlyList<int> Skins { get; set; } = new List<int>();

        /// <summary>
        /// The mount type skills.
        /// </summary>
        public IReadOnlyList<MountSkill> Skills { get; set; } = new List<MountSkill>();
    }
}
