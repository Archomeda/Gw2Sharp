using System;
using System.Collections.Generic;
using System.Linq;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides extensions for enumerables.
    /// </summary>
    internal static class EnumerableExtensions
    {
        /// <summary>
        /// Filters a sequence of values where <c>null</c> values are not present.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <returns>An enumerable without <c>null</c> values.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return source.Where(x => !(x is null));
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        /// <summary>
        /// Filters a sequence of values where <c>null</c> values are not present.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <returns>An enumerable without <c>null</c> values.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : struct
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return source.Where(x => x.HasValue).Select(x => x!.Value);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
    }
}
