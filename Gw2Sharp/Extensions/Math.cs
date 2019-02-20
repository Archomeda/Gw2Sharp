using System;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides math-based extensions.
    /// </summary>
    internal static class Math
    {
        /// <summary>
        /// Clamps a value between the given boundaries.
        /// </summary>
        /// <typeparam name="T">A class that implements <see cref="IComparable{T}" />.</typeparam>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The lower boundary.</param>
        /// <param name="max">The upper boundary.</param>
        /// <returns>The clamped value.</returns>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            else if (value.CompareTo(max) > 0)
                return max;
            return value;
        }

        /// <summary>
        /// Checks whether a value is clamped between the given boundaries.
        /// </summary>
        /// <typeparam name="T">A class that implements <see cref="IComparable{T}" />.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The lower boundary.</param>
        /// <param name="max">The upper boundary.</param>
        /// <returns>True if the value is clamped; false otherwise.</returns>
        public static bool IsClampedIn<T>(this T value, T min, T max) where T : IComparable<T> =>
            value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }
}
