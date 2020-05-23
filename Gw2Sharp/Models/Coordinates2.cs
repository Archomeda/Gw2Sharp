using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.Models
{
    /// <summary>
    /// Represents a coordinates object in 2D space.
    /// </summary>
    [JsonConverter(typeof(Coordinates2Converter))]
    public struct Coordinates2 : IEquatable<Coordinates2>, IEnumerable<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates2"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Coordinates2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public double Y { get; }

        /// <inheritdoc />
        public IEnumerator<double> GetEnumerator()
        {
            yield return this.X;
            yield return this.Y;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() =>
            $"({this.X},{this.Y})";

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is Coordinates2 && this.Equals((Coordinates2)obj);

        /// <inheritdoc />
        public bool Equals(Coordinates2 other) =>
            this.X == other.X && this.Y == other.Y;

        /// <inheritdoc />
        public override int GetHashCode() =>
            HashCode.Combine(this.X, this.Y);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Coordinates2 coordinates, Coordinates2 coordinates2) =>
            coordinates.Equals(coordinates2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Coordinates2 coordinates, Coordinates2 coordinates2) =>
            !(coordinates == coordinates2);
    }
}
