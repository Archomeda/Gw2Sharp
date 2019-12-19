using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying the name of the "id" and "ids" parameters of a bulk expandable endpoint.
    /// Optional. Defaults to "id" and "ids" if not specified. 
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointBulkIdNameAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointBulkIdNameAttribute"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="ids">The ids.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="ids"/> is <c>null</c>.</exception>
        public EndpointBulkIdNameAttribute(string id, string ids)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Ids = ids ?? throw new ArgumentNullException(nameof(ids));
        }

        /// <summary>
        /// The name of the "id" parameter.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The name of the "ids" parameter.
        /// </summary>
        public string Ids { get; }
    }
}
