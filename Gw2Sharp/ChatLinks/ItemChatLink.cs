using System;
using System.Collections.Generic;
using System.Linq;
using Gw2Sharp.ChatLinks.Internal;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 item chat link.
    /// </summary>
    public sealed class ItemChatLink : Gw2ChatLink, IEquatable<ItemChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Item;

        /// <summary>
        /// The quantity.
        /// </summary>
        public byte Quantity { get; set; }

        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The skin id.
        /// If the chat link doesn't contain a skin, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Skins"/>.
        /// </summary>
        public int? SkinId { get; set; }

        /// <summary>
        /// The first upgrade id.
        /// If the chat link doesn't contain a first upgrade, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int? Upgrade1Id { get; set; }

        /// <summary>
        /// The second upgrade id.
        /// If the chat link doesn't contain a second upgrade, this value is <c>null</c>.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int? Upgrade2Id { get; set; }


        /// <inheritdoc />
        public override unsafe void Parse(byte[] chatLinkData)
        {
            var item = Parse<ItemChatLinkStruct>(chatLinkData);
            this.Quantity = item.Quantity;
            this.ItemId = item.ItemId;

            bool hasSkin = item.AdditionalDataFlag.HasFlag(ItemChatLinkStructAdditionalData.Skin);
            bool hasUpgrade1 = item.AdditionalDataFlag.HasFlag(ItemChatLinkStructAdditionalData.Upgrade1);
            bool hasUpgrade2 = item.AdditionalDataFlag.HasFlag(ItemChatLinkStructAdditionalData.Upgrade2);

            int i = 0;
            if (hasSkin)
                this.SkinId = (int)item.AdditionalData[i++];
            if (hasUpgrade1)
                this.Upgrade1Id = (int)item.AdditionalData[i++];
            if (hasUpgrade2)
                this.Upgrade2Id = (int)item.AdditionalData[i];
        }

        /// <inheritdoc />
        public override unsafe byte[] ToArray()
        {
            var additionalDataFlag = ItemChatLinkStructAdditionalData.None;
            if (this.SkinId.HasValue)
                additionalDataFlag |= ItemChatLinkStructAdditionalData.Skin;
            if (this.Upgrade1Id.HasValue)
                additionalDataFlag |= ItemChatLinkStructAdditionalData.Upgrade1;
            if (this.Upgrade2Id.HasValue)
                additionalDataFlag |= ItemChatLinkStructAdditionalData.Upgrade2;

            var chatLinkStruct = new ItemChatLinkStruct
            {
                Quantity = this.Quantity,
                ItemId = this.ItemId,
                AdditionalDataFlag = additionalDataFlag
            };

            var additionalData = new[] { this.SkinId, this.Upgrade1Id, this.Upgrade2Id }.WhereNotNull().ToList();
            for (int i = 0; i < additionalData.Count; i++)
                chatLinkStruct.AdditionalData[i] = (uint)additionalData[i];

            byte[] chatLinkData = ToArray(chatLinkStruct, this.Type);
            return chatLinkData.Take(1 + 1 + 3 + 1 + (4 * additionalData.Count)).ToArray(); // chat link type + quantity + item id + additional data flag + (upgrade id * i)
        }

        /// <inheritdoc />
        public override string ToString() =>
            ToString(this.ToArray());


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is ItemChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(ItemChatLink? other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.Quantity == other.Quantity &&
            this.ItemId == other.ItemId &&
            EqualityComparer<int?>.Default.Equals(this.SkinId, other.SkinId) &&
            EqualityComparer<int?>.Default.Equals(this.Upgrade1Id, other.Upgrade1Id) &&
            EqualityComparer<int?>.Default.Equals(this.Upgrade2Id, other.Upgrade2Id);

        /// <inheritdoc />
        public override int GetHashCode() =>
            HashCode.Combine(this.Type, this.Quantity, this.ItemId, this.SkinId, this.Upgrade1Id, this.Upgrade2Id);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="ItemChatLink"/>.</param>
        /// <param name="right">The second <see cref="ItemChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(ItemChatLink left, ItemChatLink right) =>
            EqualityComparer<ItemChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="ItemChatLink"/>.</param>
        /// <param name="right">The second <see cref="ItemChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(ItemChatLink left, ItemChatLink right) =>
            !(left == right);

        #endregion
    }
}
