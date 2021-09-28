using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying an endpoint query parameter on clients. Optional.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class EndpointQueryParameterAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointQueryParameterAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">The query parameter name.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameterName"/> is <see langword="null"/>.</exception>
        public EndpointQueryParameterAttribute(string parameterName)
        {
            this.ParameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
        }

        /// <summary>
        /// The query parameter name.
        /// </summary>
        public string ParameterName { get; }
    }
}
