using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Gw2Sharp.Extensions
{
    /// <summary>
    /// Provides enum-based extensions.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Parses a string into an enum.
        /// </summary>
        /// <param name="enumString">The enum string.</param>
        /// <param name="enumType">The enum type.</param>
        /// <returns>The enum value, or <c>null</c> if parsing failed.</returns>
        public static Enum? ParseEnum(this string enumString, Type enumType)
        {
            // Try looking for custom enum serialization names with EnumMemberAttribute
            string[] enumNames = Enum.GetNames(enumType);
            var enumValues = Enum.GetValues(enumType);
            for (int i = 0; i < enumNames.Length; i++)
            {
                var field = enumType.GetField(enumNames[i]);
                var attr = field.GetCustomAttribute<EnumMemberAttribute>();
                if (attr != null && attr.Value == enumString)
                    return (Enum)enumValues.GetValue(i);
            }

            // Just parse normally
            try
            {
                return (Enum)Enum.Parse(enumType, enumString, true);
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
