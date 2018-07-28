using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// Implements various extension methods.
    /// </summary>
    public static class ExtensionImplementation
    {
        /// <summary>
        /// Determines whether this object is an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type to check against.</typeparam>
        /// <typeparam name="TParent">The parent type.</typeparam>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="typableObject">The typable object.</param>
        /// <returns><c>true</c> if the object is an instance of the given object type; <c>false</c> otherwise.</returns>
        public static bool IsType<T, TParent, TEnum>(this ICastableType<TParent, TEnum> typableObject)
            where T : TParent
            where TEnum : Enum
            => typableObject is T;

        /// <summary>
        /// Cast the object to another type.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <typeparam name="TParent">The parent type.</typeparam>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <returns>The object in the given type.</returns>
        public static T AsType<T, TParent, TEnum>(this ICastableType<TParent, TEnum> typableObject)
            where T : TParent
            where TEnum : Enum
            => (T)typableObject;
    }
}
