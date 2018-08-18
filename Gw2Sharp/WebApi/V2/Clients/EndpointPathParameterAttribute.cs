using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying an endpoint path parameter on clients. Optional.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class EndpointPathParameterAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointPathParameterAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">The path parameter name.</param>
        public EndpointPathParameterAttribute(string parameterName)
        {
            this.ParameterName = parameterName;
        }

        /// <summary>
        /// The path parameter name.
        /// </summary>
        public string ParameterName { get; }
    }
}
