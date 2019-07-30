using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP hero.
    /// </summary>
    public class PvpHero : ApiV2BaseObject, IIdentifiable<Guid>
    {
        /// <summary>
        /// The hero id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The hero name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The hero description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The hero type.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// The hero stats.
        /// </summary>
        public PvpHeroStats Stats { get; set; } = new PvpHeroStats();

        /// <summary>
        /// The hero overlay URL.
        /// </summary>
        public RenderUrl Overlay { get; set; }

        /// <summary>
        /// The hero underlay URL.
        /// </summary>
        public RenderUrl Underlay { get; set; }

        /// <summary>
        /// The hero skins.
        /// </summary>
        public IReadOnlyList<PvpHeroSkin> Skins { get; set; } = new List<PvpHeroSkin>();
    }
}
