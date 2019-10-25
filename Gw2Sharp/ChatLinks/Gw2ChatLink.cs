using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// A Guild Wars 2 chat link.
    /// </summary>
    public abstract class Gw2ChatLink : IGw2ChatLink
    {
        /// <inheritdoc />
        public abstract ChatLinkType Type { get; }

        /// <inheritdoc />
        public abstract void Parse(byte[] chatLinkData);

        /// <summary>
        /// Parses Guild Wars 2 chat link struct.
        /// </summary>
        /// <param name="chatLinkData">The chat link data.</param>
        /// <returns>The chat link as string.</returns>
        protected static T Parse<T>(byte[] chatLinkData) where T : struct
        {
            T chatLink = default;
            var handle = GCHandle.Alloc(chatLink, GCHandleType.Pinned);
            try
            {
                var pointer = handle.AddrOfPinnedObject();
                Marshal.Copy(chatLinkData, 0, pointer, chatLinkData.Length);
                return chatLink;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        /// <inheritdoc />
        public abstract override string ToString();

        /// <summary>
        /// Converts a chat link struct to its string representation.
        /// </summary>
        /// <param name="chatLinkStruct">The chat link struct.</param>
        /// <returns>The chat link as string.</returns>
        protected static string ToString<T>(T chatLinkStruct) where T : struct
        {
            var handle = GCHandle.Alloc(chatLinkStruct, GCHandleType.Pinned);
            try
            {
                var pointer = handle.AddrOfPinnedObject();
                byte[] bytes = new byte[Marshal.SizeOf(typeof(T))];
                Marshal.Copy(pointer, bytes, 0, bytes.Length);
                return $"[&{Convert.ToBase64String(bytes)}]";
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }

        /// <summary>
        /// Parses a Guild Wars 2 chat link from a string.
        /// It's not required that the chat link is wrapped with the conventional "[&amp;" and "]" characters.
        /// </summary>
        /// <param name="chatLinkString">The chat link string.</param>
        /// <returns>The chat link.</returns>
        /// <exception cref="FormatException">The <paramref name="chatLinkString"/> is not in the correct format or is an unsupported chat link.</exception>
        public static IGw2ChatLink Parse(string chatLinkString)
        {
            try
            {
                if (chatLinkString.StartsWith("["))
                    chatLinkString = chatLinkString.Substring(1);
                if (chatLinkString.StartsWith("&"))
                    chatLinkString = chatLinkString.Substring(1);
                if (chatLinkString.EndsWith("]"))
                    chatLinkString = chatLinkString.Remove(chatLinkString.Length - 2);

                byte[] bytes = Convert.FromBase64String(chatLinkString);
                byte[] bytesLink = bytes.Skip(1).ToArray();
                var chatLink = ((ChatLinkType)bytes[0]) switch
                {
                    ChatLinkType.Coin => (Gw2ChatLink)new CoinChatLink(),
                    ChatLinkType.Item => new ItemChatLink(),
                    ChatLinkType.NpcText => new NpcTextChatLink(),
                    ChatLinkType.PointOfInterest => new PointOfInterestChatLink(),
                    ChatLinkType.Skill => new SkillChatLink(),
                    ChatLinkType.Trait => new TraitChatLink(),
                    ChatLinkType.Recipe => new RecipeChatLink(),
                    ChatLinkType.Skin => new SkinChatLink(),
                    ChatLinkType.Outfit => new OutfitChatLink(),
                    _ => throw new FormatException("Unsupported chat link or the chat link is not in the correct format")
                };
                chatLink.Parse(bytesLink);
                return chatLink;
            }
            catch (Exception ex)
            {
                throw new FormatException("The chat link is not in the correct format", ex);
            }
        }

        /// <summary>
        /// Tries to parse a Guild Wars 2 chat link from a string.
        /// It's not required that the chat link is wrapped with the conventional "[&amp;" and "]" characters.
        /// </summary>
        /// <param name="chatLinkString">The chat link string.</param>
        /// <param name="chatLink">The chat link if <paramref name="chatLinkString"/> is a valid chat link.</param>
        /// <returns><c>true</c> if <paramref name="chatLinkString"/> is a valid chat link; <c>false</c> otherwise.</returns>
        public static bool TryParse(string chatLinkString, [NotNullWhen(true)] out IGw2ChatLink? chatLink)
        {
            try
            {
                chatLink = Parse(chatLinkString);
                return true;
            }
            catch
            {
                chatLink = null;
                return false;
            }
        }
    }

    /// <summary>
    /// A Guild Wars 2 chat link with a backing struct.
    /// </summary>
    /// <typeparam name="T">The backing struct type.</typeparam>
    public abstract class Gw2ChatLink<T> : Gw2ChatLink where T : struct
    {
        /// <summary>
        /// The backing struct data.
        /// </summary>
        protected T data;

        /// <inheritdoc />
        public override void Parse(byte[] chatLinkData) =>
            this.data = Parse<T>(chatLinkData);

        /// <inheritdoc />
        public override string ToString() =>
            ToString(this.data);
    }
}
