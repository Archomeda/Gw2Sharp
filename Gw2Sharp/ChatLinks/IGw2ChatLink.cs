using System;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// A Guild Wars 2 chat link.
    /// </summary>
    public interface IGw2ChatLink
    {
        /// <summary>
        /// The chat link type.
        /// </summary>
        ChatLinkType Type { get; }

        /// <summary>
        /// Parses a Guild Wars 2 chat link from a string.
        /// The implementation requires chat links to only parse the contents between the "[&amp;" and "]" characters.
        /// </summary>
        /// <param name="chatLinkData">The chat link bytes.</param>
        /// <exception cref="FormatException">The <paramref name="chatLinkData"/> is not in the correct format or is an unsupported chat link.</exception>
        void Parse(byte[] chatLinkData);

        /// <summary>
        /// Converts the chat link to its byte array representation.
        /// </summary>
        byte[] ToArray();

        /// <summary>
        /// Converts the chat link to its string representation.
        /// </summary>
        /// <returns>The chat link as string.</returns>
        string ToString();
    }
}
