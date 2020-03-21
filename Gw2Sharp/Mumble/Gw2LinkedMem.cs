using System.Net.Sockets;
using System.Runtime.InteropServices;
using Gw2Sharp.Mumble.Models;

#pragma warning disable IDE0044
#pragma warning disable IDE1006
#pragma warning disable S101

namespace Gw2Sharp.Mumble
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Gw2LinkedMem
    {
        public const int SIZE = 5460;

        [FieldOffset(0)]
        public uint uiVersion;
        [FieldOffset(4)]
        public uint uiTick;
        [FieldOffset(8)]
        public fixed float fAvatarPosition[3];
        [FieldOffset(20)]
        public fixed float fAvatarFront[3];
        [FieldOffset(44)]
        public fixed char name[256];
        [FieldOffset(556)]
        public fixed float fCameraPosition[3];
        [FieldOffset(568)]
        public fixed float fCameraFront[3];
        [FieldOffset(592)]
        public fixed char identity[256];
        [FieldOffset(1104)]
        public uint contextLen;
        [FieldOffset(1108)]
        public Gw2Context context;

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

    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Gw2Context
    {
        public const int SOCKET_ADDRESS_SIZE = 28;

        [FieldOffset(0)]
        public fixed byte socketAddress[SOCKET_ADDRESS_SIZE];

        [FieldOffset(0)]
        private ushort _socketAddressFamily;
        public AddressFamily socketAddressFamily => (AddressFamily)this._socketAddressFamily;

        [FieldOffset(2)]
        public ushort socketPort;
        [FieldOffset(4)]
        public fixed byte socketAddress4[4];
        [FieldOffset(8)]
        public fixed ushort socketAddress6[8];

        [FieldOffset(28)]
        public uint mapId;
        [FieldOffset(32)]
        public uint mapType;
        [FieldOffset(36)]
        public uint shardId;
        [FieldOffset(40)]
        public uint instance;
        [FieldOffset(44)]
        public uint buildId;
        [FieldOffset(48)]
        public UiState uiState;
        [FieldOffset(52)]
        public ushort compassWidth;
        [FieldOffset(54)]
        public ushort compassHeight;
        [FieldOffset(56)]
        public float compassRotation;
        [FieldOffset(60)]
        public float playerMapX;
        [FieldOffset(64)]
        public float playerMapY;
        [FieldOffset(68)]
        public float mapCenterX;
        [FieldOffset(72)]
        public float mapCenterY;
        [FieldOffset(76)]
        public float mapScale;

        // Total struct size is 256 bytes
    }
}
