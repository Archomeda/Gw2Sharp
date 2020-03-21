using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.Models
{
    /// <summary>
    /// Represents a coordinates object in 3D space.
    /// </summary>
    [JsonConverter(typeof(Coordinates3Converter))]
    public struct Coordinates3 : IEquatable<Coordinates3>, IEnumerable<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates3"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-coordinate.</param>
        public Coordinates3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// The z-coordinate.
        /// </summary>
        public double Z { get; }

        /// <inheritdoc />
        public IEnumerator<double> GetEnumerator()
        {
            yield return this.X;
            yield return this.Y;
            yield return this.Z;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() =>
            $"({this.X},{this.Y},{this.Z})";

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is Coordinates3 && this.Equals((Coordinates3)obj);

        /// <inheritdoc />
        public bool Equals(Coordinates3 other) =>
            this.X == other.X && this.Y == other.Y && this.Z == other.Z;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -307843816;
                hashCode = (hashCode * -1521134295) + this.X.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.Y.GetHashCode();
                hashCode = (hashCode * -1521134295) + this.Z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Coordinates3 coordinates, Coordinates3 coordinates2) =>
            coordinates.Equals(coordinates2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="coordinates">The first coordinates.</param>
        /// <param name="coordinates2">The second coordinates.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Coordinates3 coordinates, Coordinates3 coordinates2) =>
            !(coordinates == coordinates2);
    }
}
