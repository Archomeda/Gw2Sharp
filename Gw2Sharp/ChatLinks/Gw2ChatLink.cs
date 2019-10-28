using System;
using System.Diagnostics.CodeAnalysis;
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
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <param name="chatLinkData">The chat link data.</param>
        /// <param name="startIndex">The index to start parsing the chat link data.</param>
        /// <returns>The chat link as string.</returns>
        protected static unsafe T Parse<T>(byte[] chatLinkData, int startIndex = 1) where T : struct
        {
            int structSize = Marshal.SizeOf(typeof(T));
            if (chatLinkData.Length < structSize + startIndex)
            {
                // Prevent reading past the buffer by creating a new byte array in which the struct can fit
                byte[] bytes = new byte[structSize];
                Array.Copy(chatLinkData, startIndex, bytes, 0, chatLinkData.Length - startIndex);
                chatLinkData = bytes;
                startIndex = 0;
            }

            fixed (byte* ptr = &chatLinkData[startIndex])
            {
                var intPtr = new IntPtr(ptr);
                return Marshal.PtrToStructure<T>(intPtr);
            }
        }

        /// <inheritdoc />
        public abstract byte[] ToArray();

        /// <summary>
        /// Converts a chat link struct to its byte representation.
        /// </summary>
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <param name="chatLinkStruct">The chat link struct.</param>
        /// <param name="chatLinkType">The chat link type.</param>
        /// <returns>The chat link as byte array.</returns>
        protected static unsafe byte[] ToArray<T>(T chatLinkStruct, ChatLinkType? chatLinkType) where T : struct
        {
            int startPos = chatLinkType.HasValue ? 1 : 0;
            int structSize = Marshal.SizeOf(typeof(T));
            byte[] bytes = new byte[structSize + startPos];

            if (chatLinkType.HasValue)
                bytes[0] = (byte)chatLinkType;
            fixed (byte* ptr = &bytes[startPos])
            {
                var intPtr = new IntPtr(ptr);
                Marshal.StructureToPtr(chatLinkStruct, intPtr, true);
            }

            return bytes;
        }

        /// <inheritdoc />
        public abstract override string ToString();

        /// <summary>
        /// Converts a chat link struct to its string representation.
        /// </summary>
        /// <typeparam name="T">The chat link type.</typeparam>
        /// <param name="chatLinkType">The chat link type.</param>
        /// <param name="chatLinkStruct">The chat link struct.</param>
        /// <returns>The chat link as string.</returns>
        protected static unsafe string ToString<T>(ChatLinkType chatLinkType, T chatLinkStruct) where T : struct =>
            ToString(ToArray(chatLinkStruct, chatLinkType));

        /// <summary>
        /// Converts a chat link byte array to its string representation.
        /// </summary>
        /// <param name="chatLinkData">The chat link byte array.</param>
        /// <returns>The chat link as string.</returns>
        protected static unsafe string ToString(byte[] chatLinkData) =>
            $"[&{Convert.ToBase64String(chatLinkData)}]";

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
                    chatLinkString = chatLinkString.Remove(chatLinkString.Length - 1);

                byte[] bytes = Convert.FromBase64String(chatLinkString);
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
                chatLink.Parse(bytes);
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
        public override byte[] ToArray() =>
            ToArray(this.data, this.Type);

        /// <inheritdoc />
        public override string ToString() =>
            ToString(this.Type, this.data);
    }
}
