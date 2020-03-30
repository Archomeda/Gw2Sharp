using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a specialization.
    /// </summary>
    public class Specialization : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The specialization id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The specialization name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The specialization profession.
        /// Can be resolved against <see cref="IProfessionsClient"/>.
        /// </summary>
        public string Profession { get; set; } = string.Empty;

        /// <summary>
        /// Whether this is an elite specialization.
        /// The number of output items.
        /// </summary>
        public bool Elite { get; set; }

        /// <summary>
        /// The minor specialization traits.
        /// Each element can be resolved against <see cref="ITraitsClient"/>.
        /// </summary>
        public IReadOnlyList<int> MinorTraits { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The major specialization traits.
        /// Each element can be resolved against <see cref="ITraitsClient"/>.
        /// </summary>
        public IReadOnlyList<int> MajorTraits { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The weapon trait associated with the specialization.
        /// If the specialization does not have an associated weapon trait, this value is <c>null</c>.
        /// Can be resolved against <see cref="ITraitsClient"/>.
        /// </summary>
        public int? WeaponTrait { get; set; }

        /// <summary>
        /// The specialization icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The specialization background URL.
        /// </summary>
        public RenderUrl Background { get; set; }

        /// <summary>
        /// The big specialization profession icon URL.
        /// If the specialization does not have a profession icon, this value is <c>null</c>.
        /// </summary>
        public RenderUrl? ProfessionIconBig { get; set; }

        /// <summary>
        /// The specialization profession icon URL.
        /// If the specialization does not have a profession icon, this value is <c>null</c>.
        /// </summary>
        public RenderUrl? ProfessionIcon { get; set; }
    }
}
