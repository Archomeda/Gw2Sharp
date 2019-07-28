using System;
using System.IO.MemoryMappedFiles;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble.Models;
using Newtonsoft.Json;

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// A client for the Guild Wars 2 Mumble Link API service.
    /// </summary>
    public class Gw2MumbleClient : BaseClient, IGw2MumbleClient
    {
        private readonly Lazy<MemoryMappedFile> memoryMappedFile;
        private readonly Lazy<MemoryMappedViewAccessor> memoryMappedViewAccessor;

        private Gw2LinkedMem linkedMem;

        /// <summary>
        /// Creates a new <see cref="Gw2MumbleClient"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        protected internal Gw2MumbleClient(IConnection connection, IGw2Client? gw2Client) : base(connection, gw2Client)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (gw2Client == null)
                throw new ArgumentNullException(nameof(gw2Client));

            this.memoryMappedFile = new Lazy<MemoryMappedFile>(
                () => MemoryMappedFile.CreateOrOpen("MumbleLink", Marshal.SizeOf(typeof(Gw2LinkedMem)), MemoryMappedFileAccess.ReadWrite), true);
            this.memoryMappedViewAccessor = new Lazy<MemoryMappedViewAccessor>(
                () => this.memoryMappedFile.Value.CreateViewAccessor());
        }

        private string identityJson = "{}";
        private CharacterIdentity? identityObject;
        private CharacterIdentity Identity
        {
            get
            {
                if (this.identityObject == null)
                    this.identityObject = JsonConvert.DeserializeObject<CharacterIdentity>(this.identityJson);
                return this.identityObject;
            }
        }


        /// <inheritdoc />
        public bool IsAvailable { get; private set; }

        /// <inheritdoc />
        public int Version =>
            this.IsAvailable ? (int)this.linkedMem.uiVersion : default;

        /// <inheritdoc />
        public int Tick =>
            this.IsAvailable ? (int)this.linkedMem.uiTick : default;

        /// <inheritdoc />
        public string Name { get; private set; } = string.Empty;

        /// <inheritdoc />
        public unsafe Coordinates3 AvatarPosition =>
            this.IsAvailable ? new Coordinates3(this.linkedMem.fAvatarPosition[0], this.linkedMem.fAvatarPosition[1], this.linkedMem.fAvatarPosition[2]) : default;

        /// <inheritdoc />
        public unsafe Coordinates3 AvatarFront =>
            this.IsAvailable ? new Coordinates3(this.linkedMem.fAvatarFront[0], this.linkedMem.fAvatarFront[1], this.linkedMem.fAvatarFront[2]) : default;

        /// <inheritdoc />
        public unsafe Coordinates3 CameraPosition =>
            this.IsAvailable ? new Coordinates3(this.linkedMem.fCameraPosition[0], this.linkedMem.fCameraPosition[1], this.linkedMem.fCameraPosition[2]) : default;

        /// <inheritdoc />
        public unsafe Coordinates3 CameraFront =>
            this.IsAvailable ? new Coordinates3(this.linkedMem.fCameraFront[0], this.linkedMem.fCameraFront[1], this.linkedMem.fCameraFront[2]) : default;

        /// <inheritdoc />
        public unsafe string ServerAddress
        {
            get
            {
                if (!this.IsAvailable)
                    return string.Empty;

                var context = this.linkedMem.context;
                switch (context.socketAddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        return $"{context.socketAddress4[0]}.{context.socketAddress4[1]}.{context.socketAddress4[2]}.{context.socketAddress4[3]}";
                    case AddressFamily.InterNetworkV6:
                        return $"{context.socketAddress6[0]:X4}:{context.socketAddress6[1]:X4}:{context.socketAddress6[2]:X4}:{context.socketAddress6[3]:X4}:" +
                        $"{context.socketAddress6[4]:X4}:{context.socketAddress6[5]:X4}:{context.socketAddress6[6]:X4}:{context.socketAddress6[7]:X4}";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <inheritdoc />
        public ushort ServerPort =>
            this.IsAvailable ? this.linkedMem.context.socketPort : default;

        /// <inheritdoc />
        public int BuildId =>
            this.IsAvailable ? (int)this.linkedMem.context.buildId : default;

        /// <inheritdoc />
        public int MapId =>
            this.IsAvailable ? (int)this.linkedMem.context.mapId : default;

        /// <inheritdoc />
        public MapType MapType =>
            this.IsAvailable ? (MapType)this.linkedMem.context.mapType : default;

        /// <inheritdoc />
        public uint ShardId =>
            this.IsAvailable ? this.linkedMem.context.shardId : default;

        /// <inheritdoc />
        public uint Instance =>
            this.IsAvailable ? this.linkedMem.context.instance : default;

        /// <inheritdoc />
        public string CharacterName =>
            this.IsAvailable ? this.Identity.Name : string.Empty;

        /// <inheritdoc />
        public string Profession =>
            this.IsAvailable ? this.Identity.Profession.ToString() : string.Empty;

        /// <inheritdoc />
        public string Race =>
            this.IsAvailable ? this.Identity.Race.ToString() : string.Empty;

        /// <inheritdoc />
        public int TeamColorId =>
            this.IsAvailable ? this.Identity.TeamColorId : default;

        /// <inheritdoc />
        public bool IsCommander =>
            this.IsAvailable ? this.Identity.Commander : default;

        /// <inheritdoc />
        public double FieldOfView =>
            this.IsAvailable ? this.Identity.Fov : default;

        /// <inheritdoc />
        public UiSize UiSize =>
            this.IsAvailable ? this.Identity.Uisz : default;


        /// <inheritdoc />
        public unsafe void Update()
        {
            this.memoryMappedViewAccessor.Value.Read<Gw2LinkedMem>(0, out var linkedMem);

            this.identityJson = new string(linkedMem.identity);
            this.Name = new string(linkedMem.name);
            this.IsAvailable = this.Name == "Guild Wars 2";

            this.identityJson = this.IsAvailable ? new string(linkedMem.identity) : "{}";
            this.identityObject = null;

            this.linkedMem = linkedMem;
        }

        #region IDisposable Support

        private bool isDisposed = false; // To detect redundant calls

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="isDisposing">Dispose unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    if (this.memoryMappedViewAccessor.IsValueCreated)
                        this.memoryMappedViewAccessor.Value.Dispose();
                    if (this.memoryMappedFile.IsValueCreated)
                        this.memoryMappedFile.Value.Dispose();
                }

                this.isDisposed = true;
            }
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
