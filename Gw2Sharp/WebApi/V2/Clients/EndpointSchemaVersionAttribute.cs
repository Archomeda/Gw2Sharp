using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying the schema version on clients. Optional.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointSchemaVersionAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EndpointSchemaVersionAttribute"/> class.
        /// </summary>
        /// <param name="schemaVersion">The schema version.</param>
        /// <exception cref="ArgumentNullException"><paramref name="schemaVersion"/> is <see langword="null"/>.</exception>
        public EndpointSchemaVersionAttribute(string schemaVersion)
        {
            this.SchemaVersion = schemaVersion ?? throw new ArgumentNullException(nameof(schemaVersion));
        }

        /// <summary>
        /// The endpoint path.
        /// </summary>
        public string SchemaVersion { get; }
    }
}
