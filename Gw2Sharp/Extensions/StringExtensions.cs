using System;
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
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is <c>null</c>.</exception>
        public static string GetSha1Hash(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            using (var sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
                return string.Join("", hash.Select(x => x.ToString("X2")));
            }
        }
    }
}
