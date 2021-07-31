using System;
using System.IO.MemoryMappedFiles;

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// The default Guild Wars 2 Mumble client reader.
    /// Uses the official Mumble Link API, which is only available on Windows operating systems, or in Windows-emulated environments.
    /// </summary>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public class Gw2MumbleClientReader : IGw2MumbleClientReader
    {
        private MemoryMappedFile? file;
        private MemoryMappedViewAccessor? accessor;

        /// <summary>
        /// Creates a new <see cref="Gw2MumbleClientReader"/>.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Only Windows operating systems are supported.</exception>
        public Gw2MumbleClientReader()
        {
#if NET5_0_OR_GREATER
            if (!OperatingSystem.IsWindows())
#else
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
#endif
                throw new PlatformNotSupportedException("Only Windows operating systems support the Mumble Link");
        }

        /// <inheritdoc/>
        public bool IsOpen { get; private set; }

        /// <inheritdoc/>
        public void Open(string mumbleLinkName)
        {
            this.file = MemoryMappedFile.CreateOrOpen(mumbleLinkName, Gw2LinkedMem.SIZE, MemoryMappedFileAccess.ReadWrite);
            this.accessor = this.file.CreateViewAccessor();
            this.IsOpen = true;
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.accessor?.Dispose();
            this.file?.Dispose();

            this.accessor = null;
            this.file = null;
            this.IsOpen = false;
        }

        /// <inheritdoc/>
        public Gw2LinkedMem Read()
        {
            if (this.isDisposed)
                throw new ObjectDisposedException(nameof(Gw2MumbleClientReader));
            if (this.file is null || this.accessor is null)
                throw new InvalidOperationException("The reader has to be opened first");

            this.accessor.Read<Gw2LinkedMem>(0, out var mem);
            return mem;
        }


#region IDisposable Support

        private bool isDisposed = false; // To detect redundant calls

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
                return;

            if (disposing)
            {
                this.Close();
            }

            this.isDisposed = true;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

#endregion
    }
}
