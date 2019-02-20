using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides extensions for dictionaries.
    /// </summary>
    internal static class Dictionary
    {
        /// <summary>
        /// Creates a shallow copy of a <see cref="IEnumerable{T}"/> that contains <see cref="KeyValuePair{TKey, TValue}"/> items
        /// and returns a <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <returns>A shallow copy in the form of a dictionary.</returns>
        /// <exception cref="ArgumentException"><paramref name="source"/> contains duplicate keys.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
        public static IDictionary<TKey, TValue> ShallowCopy<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        /// <summary>
        /// Wraps a dictionary into a read-only dictionary by calling the <see cref="ReadOnlyDictionary{TKey, TValue}"/> constructor.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>The read-only dictionary.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is <c>null</c>.</exception>
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}
