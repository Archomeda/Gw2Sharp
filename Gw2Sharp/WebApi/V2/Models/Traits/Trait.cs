using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a trait.
    /// </summary>
    public class Trait : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The trait id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The trait name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The trait description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The trait icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The specialization the trait belongs to.
        /// </summary>
        public int Specialization { get; set; }

        /// <summary>
        /// The trait tier.
        /// </summary>
        public int Tier { get; set; }

        /// <summary>
        /// The trait order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The trait slot.
        /// If the trait does not have a slot, this value is <c>null</c>.
        /// </summary>
        public ApiEnum<TraitSlot>? Slot { get; set; }

        /// <summary>
        /// The list of trait facts.
        /// If the trait doesn't have any facts, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<TraitFact>? Facts { get; set; }

        /// <summary>
        /// The list of traited skill facts.
        /// If the skill doesn't have any traited facts, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<TraitFact>? TraitedFacts { get; set; }

        /// <summary>
        /// The list of trait skills.
        /// If the trait doesn't have any skills, this value is <c>null</c>.
        /// </summary>
        public IReadOnlyList<TraitSkill>? Skills { get; set; }
    }
}
