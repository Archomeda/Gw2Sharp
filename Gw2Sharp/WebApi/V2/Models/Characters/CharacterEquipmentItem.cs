using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character's equipment item.
    /// </summary>
    public class CharacterEquipmentItem
    {
        /// <summary>
        /// The equipment item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The equipment location.
        /// </summary>
        public ApiEnum<ItemEquipmentLocationType> Location { get; set; } = new ApiEnum<ItemEquipmentLocationType>();

        /// <summary>
        /// The equipment slot.
        /// </summary>
        public ApiEnum<ItemEquipmentSlotType> Slot { get; set; } = new ApiEnum<ItemEquipmentSlotType>();

        /// <summary>
        /// The list of equipment tab indices that this item is used in.
        /// Each element can be resolved against <see cref="ICharactersIdClient.EquipmentTabs"/>.
        /// If the item is not part of an equipment tab, this value is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<int>? Tabs { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The list of upgrades applied to the equipped item.
        /// If the item does not have any upgrades, this value is <see langword="null"/>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int>? Upgrades { get; set; }

        /// <summary>
        /// The list of infusions applied to the equipped item.
        /// If the item does not have any upgrades, this value is <see langword="null"/>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int>? Infusions { get; set; }

        /// <summary>
        /// The skin id.
        /// If the item is not skinnable or has the original skin, this value is <see langword="null"/>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int? Skin { get; set; }

        /// <summary>
        /// The selected stats for the equipped item.
        /// If the item has no selectable item stats, this value is <see langword="null"/>.
        /// </summary>
        public EquipmentItemStats? Stats { get; set; }

        /// <summary>
        /// The current binding of the equipped item.
        /// If the item is not bound, this value is <see langword="null"/>.
        /// </summary>
        public ApiEnum<ItemBinding>? Binding { get; set; }

        /// <summary>
        /// The name of the character to which the equipped item is bound.
        /// If the item is not character bound (see <see cref="Binding"/>), this value is <see langword="null"/>.
        /// </summary>
        public string? BoundTo { get; set; }

        /// <summary>
        /// The selected dyes for the equipped item.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// If the item does not support dyeing, this value is <see langword="null"/>.
        /// If no dye is chosen for an element in this list, the element is <see langword="null"/>.
        /// </summary>
        public IReadOnlyList<int?>? Dyes { get; set; }
    }
}
