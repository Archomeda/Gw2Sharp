using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character's PvP equipment.
    /// </summary>
    public class CharacterEquipmentPvp
    {
        /// <summary>
        /// The PvP amulet.
        /// If no amulet is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IPvpClient.Amulets"/>.
        /// </summary>
        public int? Amulet { get; set; }

        /// <summary>
        /// The PvP rune.
        /// If no rune is selected, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int? Rune { get; set; }

        /// <summary>
        /// The list of PvP sigils.
        /// If a sigil is not selected in a specific slot, that value is <c>null</c>.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int?> Sigils { get; set; } = new List<int?>();
    }
}
