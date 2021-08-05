using System;

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// An unsupported Mumble platform client reader.
    /// Does nothing besides throwing <see cref="PlatformNotSupportedException"/> for each method.
    /// </summary>
    internal sealed class UnsupportedMumblePlatformClientReader : IGw2MumbleClientReader
    {
        /// <inheritdoc/>
        public bool IsOpen =>
            throw new PlatformNotSupportedException($"Mumble Link is not supported on {Environment.OSVersion.Platform}");

        /// <inheritdoc/>
        public void Open() =>
            throw new PlatformNotSupportedException($"Mumble Link is not supported on {Environment.OSVersion.Platform}");

        /// <inheritdoc/>
        public void Close() =>
            throw new PlatformNotSupportedException($"Mumble Link is not supported on {Environment.OSVersion.Platform}");

        /// <inheritdoc/>
        public Gw2LinkedMem Read() =>
            throw new PlatformNotSupportedException($"Mumble Link is not supported on {Environment.OSVersion.Platform}");


        #region IDisposable Support

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
