using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying the endpoint path on clients. Required.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointPathAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointPathAttribute"/> class.
        /// </summary>
        /// <param name="endpointPath">The endpoint path.</param>
        public EndpointPathAttribute(string endpointPath)
        {
            this.EndpointPath = endpointPath;
        }

        /// <summary>
        /// The endpoint path.
        /// </summary>
        public string EndpointPath { get; }
    }
}
