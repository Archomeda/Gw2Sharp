using System;
using System.Runtime.InteropServices;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// A UInt24 implementation used in chat links.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UInt24
    {
        private readonly byte b0;
        private readonly byte b1;
        private readonly byte b2;

        /// <summary>
        /// Initializes a new instance of the <see cref="UInt24"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is greater than the maximum allowed value.</exception>
        public UInt24(int value)
        {
            uint uvalue = (uint)value;
            if ((uvalue >> 24) != 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "The value cannot be greater than 16777215");

            this.b0 = (byte)(uvalue & 0xFF);
            this.b1 = (byte)((uvalue >> 8) & 0xFF);
            this.b2 = (byte)((uvalue >> 16) & 0xFF);
        }

        /// <summary>
        /// Gets the value;
        /// </summary>
        public int Value =>
            this.b0 | (this.b1 << 8) | (this.b2 << 16);


        /// <summary>
        /// Gets the <see cref="UInt24"/> value of an integer.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator UInt24(int value) =>
            new UInt24(value);

        /// <summary>
        /// Gets the integer value of <see cref="UInt24"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator int(UInt24 value) =>
            value.Value;
    }
}
