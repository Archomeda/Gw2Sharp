using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character equipment tab slot.
    /// </summary>
    public class CharacterEquipmentTabSlot : ApiV2BaseObject, IIdentifiable<int>
    {
#pragma warning disable CA1033 // Interface methods should be callable by child types
        int IIdentifiable<int>.Id
        {
            get => this.Tab;
            set => this.Tab = value;
        }
#pragma warning restore CA1033 // Interface methods should be callable by child types

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

        /// <summary>
        /// The PvP equipment.
        /// Additionally requires scopes: builds.
        /// If the required scopes are not met, this value is <c>null</c>.
        /// </summary>
        public CharacterEquipmentPvp? EquipmentPvp { get; set; }
    }
}
