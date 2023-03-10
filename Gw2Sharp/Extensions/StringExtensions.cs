using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides extensions for strings.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Gets the SHA-1 hash of a string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The SHA-1 hash.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <see langword="null"/>.</exception>
        public static string GetSha1Hash(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
            using var sha1 = SHA1.Create();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
            return string.Concat(hash.Select(x => x.ToString("X2", CultureInfo.InvariantCulture)));
#pragma warning restore CA5350 // Do Not Use Weak Cryptographic Algorithms
        }

        /// <summary>
        /// Use a default string if the given string is <see langword="null"/> or empty.
        /// Shorthand for <c>string.IsNullOrEmpty(str) ? "default" : str</c>
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <param name="default">The default string if the given string is <see langword="null"/> or empty.</param>
        /// <returns>The original string if it's not <see langword="null"/> or empty; <paramref name="default"/> otherwise.</returns>
        public static string OrIfNullOrEmpty(this string? str, string @default) =>
            !string.IsNullOrEmpty(str) ? str : @default;
    }
}
