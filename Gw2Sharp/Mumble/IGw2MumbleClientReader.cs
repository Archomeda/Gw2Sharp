using System;

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// An interface for implementing a reader for the Guild Wars 2 Mumble client.
    /// </summary>
    public interface IGw2MumbleClientReader : IDisposable
    {
        /// <summary>
        /// Whether this reader is open.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Opens the reader.
        /// </summary>
        /// <param name="mumbleLinkName">The Mumble Link name.</param>
        void Open(string mumbleLinkName);

        /// <summary>
        /// Closes the reader.
        /// </summary>
        void Close();

        /// <summary>
        /// Reads the Guild Wars 2 Mumble Link data into the <see cref="Gw2LinkedMem"/> struct.
        /// </summary>
        /// <returns>The read Guild Wars 2 Mumble Link data as <see cref="Gw2LinkedMem"/>.</returns>
        Gw2LinkedMem Read();
    }
}
