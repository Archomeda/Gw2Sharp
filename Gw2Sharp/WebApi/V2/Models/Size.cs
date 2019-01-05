using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a size object in 2D space.
    /// </summary>
    [JsonConverter(typeof(SizeConverter))]
    public struct Size : IEquatable<Size>, IEnumerable<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// The width.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The height.
        /// </summary>
        public int Height { get; private set; }

        /// <inheritdoc />
        public IEnumerator<int> GetEnumerator()
        {
            yield return this.Width;
            yield return this.Height;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() => $"({this.Width},{this.Height})";

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Size && this.Equals((Size)obj);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Size other) => this.Width == other.Width && this.Height == other.Height;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 859600377;
            hashCode = (hashCode * -1521134295) + this.Width.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.Height.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="size1">The first size.</param>
        /// <param name="size2">The second size.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Size size1, Size size2) => size1.Equals(size2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="size1">The first size.</param>
        /// <param name="size2">The second size.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Size size1, Size size2) => !(size1 == size2);
    }
}
