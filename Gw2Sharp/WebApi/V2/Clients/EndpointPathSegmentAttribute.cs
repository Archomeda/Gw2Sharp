using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying an endpoint path segment replacement on clients. Optional.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class EndpointPathSegmentAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointPathAttribute"/> class.
        /// </summary>
        /// <param name="pathSegment">The path segment to replace.</param>
        /// <param name="order">The order of the passed parameter that is used when replacing the path segment.</param>
        public EndpointPathSegmentAttribute(string pathSegment, int order)
        {
            this.PathSegment = pathSegment;
            this.Order = order;
        }

        /// <summary>
        /// The path segment to replace.
        /// </summary>
        public string PathSegment { get; }

        /// <summary>
        /// The order of the passed parameter.
        /// </summary>
        public int Order { get; }
    }
}
