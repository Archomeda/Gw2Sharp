using System;
using System.Linq;
using Gw2Sharp.ChatLinks.Structs;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 item chat link.
    /// </summary>
    public class ItemChatLink : Gw2ChatLink
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Item;

        /// <summary>
        /// The quantity.
        /// </summary>
        public int Quantity { get; set; }

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
        public override void Parse(byte[] chatLinkData)
        {
            var item = Parse<ItemChatLinkStructMain>(chatLinkData);
            this.Quantity = item.Quantity;

            bool hasSkin = item.AdditionalData.HasFlag(ItemChatLinkStructAdditionalData.Skin);
            bool hasUpgrade1 = item.AdditionalData.HasFlag(ItemChatLinkStructAdditionalData.Upgrade1);
            bool hasUpgrade2 = item.AdditionalData.HasFlag(ItemChatLinkStructAdditionalData.Upgrade2);

            int additionalDataCount = new bool[] { hasSkin, hasUpgrade1, hasUpgrade2 }.Count(x => x);
            for (int i = 0; i < additionalDataCount; i++)
            {
                int pos = 5 + (4 * i);
                var data = Parse<ItemChatLinkStructData>(chatLinkData.Skip(pos).Take(4).ToArray());

                if (i == 0)
                {
                    if (hasSkin)
                        this.SkinId = data.ItemId;
                    else if (hasUpgrade1)
                        this.Upgrade1Id = data.ItemId;
                    else if (hasUpgrade2)
                        this.Upgrade2Id = data.ItemId;
                }

                if (i == 1)
                {
                    if (hasUpgrade1)
                        this.Upgrade1Id = data.ItemId;
                    else if (hasUpgrade2)
                        this.Upgrade2Id = data.ItemId;
                }

                if (i == 2 && hasUpgrade2)
                    this.Upgrade2Id = data.ItemId;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            //TODO Implement
            throw new NotImplementedException("TODO");
        }
    }
}
