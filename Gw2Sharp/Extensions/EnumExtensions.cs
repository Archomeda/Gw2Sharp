using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides enum-based extensions.
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Parses a string into an enum.
        /// </summary>
        /// <param name="value">The enum string to convert.</param>
        /// <param name="enumType">The enum type.</param>
        /// <returns>The enum value, or <c>default</c> if parsing failed.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="enumType"/>is not an <see cref="Enum"/>.
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="enumType"/> is <c>null</c>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <paramref name="enumType"/>.</exception>
        public static Enum ParseEnum(this string? value, Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            Enum? result = null;

            // Strip the underscores
            string strippedValue = value?.Replace("_", "") ?? string.Empty;

            // Try looking for custom enum serialization names with EnumMemberAttribute
            string[] enumNames = Enum.GetNames(enumType);
            var enumValues = Enum.GetValues(enumType);
            for (int i = 0; i < enumNames.Length; i++)
            {
                var field = enumType.GetField(enumNames[i]);
                var attr = field?.GetCustomAttribute<EnumMemberAttribute>();
                if (attr != null && (attr.Value == strippedValue || attr.Value == value))
                {
                    result = (Enum?)enumValues.GetValue(i);
                    break;
                }
            }

            // Just parse normally
            if (result == null)
            {
                try
                {
                    result = (Enum?)Enum.Parse(enumType, strippedValue, true);
                }
                catch (ArgumentException)
                {
                    // Do nothing
                }
            }

            if (result == null && enumType.GetTypeInfo().GetCustomAttribute(typeof(DefaultValueAttribute)) is DefaultValueAttribute attribute)
                result = (Enum?)attribute.Value;

            return result ?? (Enum)Enum.ToObject(enumType, 0);
        }

        /// <summary>
        /// Parses a string into an enum.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The enum string to convert.</param>
        /// <returns>The enum value, or <c>null</c> if parsing failed.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration.
        /// </exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="T"/>.</exception>
        public static T ParseEnum<T>(this string? value) where T : Enum =>
            (T)ParseEnum(value, typeof(T));
    }
}
