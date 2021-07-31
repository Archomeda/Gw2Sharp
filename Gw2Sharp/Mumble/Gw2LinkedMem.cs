using System.Net.Sockets;
using System.Runtime.InteropServices;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble.Models;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming

#pragma warning disable IDE0044
#pragma warning disable IDE1006
#pragma warning disable S101

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// The Guild Wars 2 Mumble Link struct.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Gw2LinkedMem
    {
        /// <summary>
        /// The Mumble Link struct size.
        /// </summary>
        public const int SIZE = 5460;

        /// <summary>
        /// The Mumble Link version.
        /// </summary>
        [FieldOffset(0)] public uint uiVersion;
        /// <summary>
        /// The Mumble Link tick count.
        /// </summary>
        [FieldOffset(4)] public uint uiTick;
        /// <summary>
        /// The avatar position.
        /// </summary>
        [FieldOffset(8)] public fixed float fAvatarPosition[3];
        /// <summary>
        /// The avatar front.
        /// </summary>
        [FieldOffset(20)] public fixed float fAvatarFront[3];
        /// <summary>
        /// The game name.
        /// </summary>
        [FieldOffset(44)] public fixed char name[256];
        /// <summary>
        /// The camera position.
        /// </summary>
        [FieldOffset(556)] public fixed float fCameraPosition[3];
        /// <summary>
        /// The camera front.
        /// </summary>
        [FieldOffset(568)] public fixed float fCameraFront[3];
        /// <summary>
        /// The Mumble Link identity.
        /// </summary>
        [FieldOffset(592)] public fixed char identity[256];
        /// <summary>
        /// The context struct size.
        /// </summary>
        [FieldOffset(1104)] public uint contextLen;
        /// <summary>
        /// The Mumble Link context.
        /// </summary>
        [FieldOffset(1108)] public Gw2Context context;

        // Unused fields
#if FALSE
        [FieldOffset(32)]
        public fixed float fAvatarTop[3];
        [FieldOffset(580)]
        public fixed float fCameraTop[3];
        [FieldOffset(1364)]
        public fixed char description[2048];
#endif

        // Total struct size is 5460 bytes
    }

    /// <summary>
    /// Guild Wars 2 specific Mumble Link context struct.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct Gw2Context
    {
        /// <summary>
        /// The socket address struct size.
        /// </summary>
        public const int SOCKET_ADDRESS_SIZE = 28;

        /// <summary>
        /// The raw socket address data.
        /// </summary>
        [FieldOffset(0)] public fixed byte socketAddress[SOCKET_ADDRESS_SIZE];

        /// <summary>
        /// The socket address family.
        /// </summary>
        [FieldOffset(0)] private ushort _socketAddressFamily;

        /// <summary>
        /// The socket address family.
        /// </summary>
        public AddressFamily socketAddressFamily => (AddressFamily)this._socketAddressFamily;

        /// <summary>
        /// The socket port.
        /// </summary>
        [FieldOffset(2)] public ushort socketPort;
        /// <summary>
        /// The socket address in IPv4 format.
        /// </summary>
        [FieldOffset(4)] public fixed byte socketAddress4[4];
        /// <summary>
        /// The socket address in IPv6 format.
        /// </summary>
        [FieldOffset(8)] public fixed ushort socketAddress6[8];

        /// <summary>
        /// The map id.
        /// </summary>
        [FieldOffset(28)] public uint mapId;
        /// <summary>
        /// The map type.
        /// </summary>
        [FieldOffset(32)] public uint mapType;
        /// <summary>
        /// The shard id.
        /// </summary>
        [FieldOffset(36)] public uint shardId;
        /// <summary>
        /// The instance.
        /// </summary>
        [FieldOffset(40)] public uint instance;
        /// <summary>
        /// The build id.
        /// </summary>
        [FieldOffset(44)] public uint buildId;
        /// <summary>
        /// The UI state.
        /// </summary>
        [FieldOffset(48)] public UiState uiState;
        /// <summary>
        /// The compass width.
        /// </summary>
        [FieldOffset(52)] public ushort compassWidth;
        /// <summary>
        /// The compass height.
        /// </summary>
        [FieldOffset(54)] public ushort compassHeight;
        /// <summary>
        /// The compass rotation.
        /// </summary>
        [FieldOffset(56)] public float compassRotation;
        /// <summary>
        /// The player map x-coordinate.
        /// </summary>
        [FieldOffset(60)] public float playerMapX;
        /// <summary>
        /// The player map y-coordinate.
        /// </summary>
        [FieldOffset(64)] public float playerMapY;
        /// <summary>
        /// The map center x-coordinate.
        /// </summary>
        [FieldOffset(68)] public float mapCenterX;
        /// <summary>
        /// The map center y-coordinate.
        /// </summary>
        [FieldOffset(72)] public float mapCenterY;
        /// <summary>
        /// The map scale.
        /// </summary>
        [FieldOffset(76)] public float mapScale;
        /// <summary>
        /// The process id.
        /// </summary>
        [FieldOffset(80)] public uint processId;
        /// <summary>
        /// The mount.
        /// </summary>
        [FieldOffset(84)] public MountType mount;

        // Total struct size is 256 bytes
    }
}
