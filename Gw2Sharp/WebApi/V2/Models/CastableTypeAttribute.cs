using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// An attribute for specifying the types to which the model object can be casted to.
    /// Required when defining typable models.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class CastableTypeAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CastableTypeAttribute"/> class.
        /// </summary>
        public CastableTypeAttribute(object value, Type objectType)
        {
            if (!value.GetType().IsEnum)
                throw new ArgumentException("An enum value is required", nameof(value));
            this.Value = value;
            this.ObjectType = objectType;
        }

        /// <summary>
        /// The enum value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// The object type.
        /// </summary>
        public Type ObjectType { get; }
    }
}
