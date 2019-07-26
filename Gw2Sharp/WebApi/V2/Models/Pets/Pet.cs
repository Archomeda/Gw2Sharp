using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a pet.
    /// </summary>
    public class Pet : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The pet id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The pet name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The pet description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The pet skills.
        /// </summary>
        public IReadOnlyList<PetSkill> Skills { get; set; } = new List<PetSkill>();
    }
}
