using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides enum-based extensions.
    /// </summary>
    internal static class Enums
    {
        /// <summary>
        /// Parses a string into an enum.
        /// </summary>
        /// <param name="value">The enum string to convert.</param>
        /// <param name="enumType">The enum type.</param>
        /// <returns>The enum value, or <c>null</c> if parsing failed.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="enumType"/>is not an <see cref="Enum"/>.
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <c>null</c>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <paramref name="enumType"/>.</exception>
        public static Enum? ParseEnum(this string? value, Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            // Try looking for custom enum serialization names with EnumMemberAttribute
            string[] enumNames = Enum.GetNames(enumType);
            var enumValues = Enum.GetValues(enumType);
            for (int i = 0; i < enumNames.Length; i++)
            {
                var field = enumType.GetField(enumNames[i]);
                var attr = field.GetCustomAttribute<EnumMemberAttribute>();
                if (attr != null && attr.Value == value)
                    return (Enum)enumValues.GetValue(i);
            }

            // Just parse normally
            try
            {
                return (Enum)Enum.Parse(enumType, value, true);
            }
            catch (ArgumentException)
            {
                // Not found, set to custom default if available
                if (enumType.GetTypeInfo().GetCustomAttribute(typeof(DefaultValueAttribute)) is DefaultValueAttribute attribute)
                    return (Enum)attribute.Value;
            }
            return null;
        }
    }
}
