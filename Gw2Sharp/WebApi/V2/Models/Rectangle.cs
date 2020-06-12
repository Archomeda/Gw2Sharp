using System;
using System.Collections;
using System.Collections.Generic;
using Gw2Sharp.Models;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a rectangle object.
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>, IEnumerable<IEnumerable<double>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="coords1">The first coordinates.</param>
        /// <param name="coords2">The second coordinates.</param>
        /// <param name="directionType">The rectangle direction type.</param>
        public Rectangle(Coordinates2 coords1, Coordinates2 coords2, RectangleDirectionType directionType)
        {
            this.Direction = directionType;
            if (directionType == RectangleDirectionType.BottomUp)
            {
                this.TopLeft = new Coordinates2(coords1.X, coords2.Y);
                this.TopRight = coords2;
                this.BottomLeft = coords1;
                this.BottomRight = new Coordinates2(coords2.X, coords1.Y);
            }
            else // TopDown
            {
                this.TopLeft = coords1;
                this.TopRight = new Coordinates2(coords2.X, coords1.Y);
                this.BottomLeft = new Coordinates2(coords1.X, coords2.Y);
                this.BottomRight = coords2;
            }
        }

        /// <summary>
        /// Gets the top left coordinates.
        /// </summary>
        public Coordinates2 TopLeft { get; private set; }

        /// <summary>
        /// Gets the top right coordinates.
        /// </summary>
        public Coordinates2 TopRight { get; private set; }

        /// <summary>
        /// Gets the bottom left coordinates.
        /// </summary>
        public Coordinates2 BottomLeft { get; private set; }

        /// <summary>
        /// Gets the bottom right coordinates.
        /// </summary>
        public Coordinates2 BottomRight { get; private set; }

        /// <summary>
        /// Gets the rectangle direction type.
        /// </summary>
        public RectangleDirectionType Direction { get; private set; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public double Width => Math.Abs(this.TopRight.X - this.TopLeft.X);

        /// <summary>
        /// Gets the height.
        /// </summary>
        public double Height => Math.Abs(this.BottomLeft.Y - this.TopLeft.Y);

        /// <inheritdoc />
        public IEnumerator<IEnumerable<double>> GetEnumerator()
        {
            if (this.Direction == RectangleDirectionType.BottomUp)
            {
                yield return new[] { this.BottomLeft.X, this.BottomLeft.Y };
                yield return new[] { this.TopRight.X, this.TopRight.Y };
            }
            else // TopDown
            {
                yield return new[] { this.TopLeft.X, this.TopLeft.Y };
                yield return new[] { this.BottomRight.X, this.BottomRight.Y };
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() =>
            $"({this.TopLeft},{this.TopRight},{this.BottomLeft},{this.BottomRight})";

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is Rectangle rectangle && this.Equals(rectangle);

        /// <inheritdoc />
        public bool Equals(Rectangle other) =>
            this.TopLeft.Equals(other.TopLeft) &&
            this.TopRight.Equals(other.TopRight) &&
            this.BottomLeft.Equals(other.BottomLeft) &&
            this.BottomRight.Equals(other.BottomRight);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(this.TopLeft, this.TopRight, this.BottomLeft, this.BottomRight);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="rectangle">The first rectangle.</param>
        /// <param name="rectangle2">The second rectangle.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Rectangle rectangle, Rectangle rectangle2) =>
            rectangle.Equals(rectangle2);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="rectangle">The first rectangle.</param>
        /// <param name="rectangle2">The second rectangle.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Rectangle rectangle, Rectangle rectangle2) =>
            !(rectangle == rectangle2);
    }

    /// <summary>
    /// Defines the rectangle direction type.
    /// </summary>
    public enum RectangleDirectionType
    {
        /// <summary>
        /// The rectangle is defined as north west to south east coordinates.
        /// </summary>
        TopDown,

        /// <summary>
        /// The rectangle is defined as south west to north east coordinates.
        /// </summary>
        BottomUp
    }
}
