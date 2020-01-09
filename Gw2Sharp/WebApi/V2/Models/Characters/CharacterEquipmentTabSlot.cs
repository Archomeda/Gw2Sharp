using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character equipment tab slot.
    /// </summary>
    public class CharacterEquipmentTabSlot : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The equipment tab slot id.
        /// </summary>
        int IIdentifiable<int>.Id
        {
            get => this.Tab;
            set => this.Tab = value;
        }

        /// <summary>
        /// The equipment tab slot id.
        /// </summary>
        public int Tab { get; set; }

        /// <summary>
        /// Whether this equipment tab slot is current active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The equipment.
        /// </summary>
        public IReadOnlyList<CharacterEquipmentItem> Equipment { get; set; } = Array.Empty<CharacterEquipmentItem>();
    }
}
