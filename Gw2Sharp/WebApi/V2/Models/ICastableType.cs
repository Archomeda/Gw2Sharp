using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An interface for a model that can be casted to a different type.
    /// </summary>
    /// <typeparam name="TParent">The parent type.</typeparam>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    public interface ICastableType<TParent, TEnum> where TEnum : Enum
    {
        /// <summary>
        /// The object type.
        /// </summary>
        ApiEnum<TEnum> Type { get; }
    }
}
