using System.Net.Sockets;
using System.Runtime.InteropServices;

#pragma warning disable IDE0044
#pragma warning disable IDE1006
#pragma warning disable S101

namespace Gw2Sharp.Mumble
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Gw2LinkedMem
    {
        [FieldOffset(0)]
        public uint uiVersion;
        [FieldOffset(4)]
        public uint uiTick;
        [FieldOffset(8)]
        public fixed float fAvatarPosition[3];
        [FieldOffset(20)]
        public fixed float fAvatarFront[3];
        // Unused
        //public fixed float fAvatarTop[3];
        [FieldOffset(44)]
        public fixed char name[256];
        [FieldOffset(556)]
        public fixed float fCameraPosition[3];
        [FieldOffset(568)]
        public fixed float fCameraFront[3];
        // Unused
        //public fixed float fCameraTop[3];
        [FieldOffset(592)]
        public fixed char identity[256];
        [FieldOffset(1104)]
        public uint contextLen;

        // Inject the context directly instead of parsing it later for performance
        //public fixed byte context[256];
        [FieldOffset(1108)]
        public Gw2Context context;

        // Desscription is unused, leave it out for performance
        //public fixed char description[2048];
    }

    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Gw2Context
    {
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
    }
}
