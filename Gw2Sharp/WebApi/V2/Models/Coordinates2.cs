using System;
using System.Collections;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a coordinates object in 2D space.
    /// </summary>
    [JsonConverter(typeof(Coordinates2Converter))]
    public struct Coordinates2 : IEquatable<Coordinates2>, IEnumerable<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates2"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Coordinates2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public int Y { get; }

        /// <inheritdoc />
        public IEnumerator<int> GetEnumerator()
        {
            yield return this.X;
            yield return this.Y;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() => $"({this.X},{this.Y})";

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Coordinates2 && this.Equals((Coordinates2)obj);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Coordinates2 other) => this.X == other.X && this.Y == other.Y;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = (hashCode * -1521134295) + this.X.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.Y.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Coordinates2 coordinates, Coordinates2 coordinates2) => coordinates.Equals(coordinates2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Coordinates2 coordinates, Coordinates2 coordinates2) => !(coordinates == coordinates2);
    }
}
