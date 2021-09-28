using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An attribute for specifying the names of the query parameter that act as the id and ids of a bulk expandable endpoint.
    /// The name of the property in the object returned by the API that acts as the id can also be specified.
    /// Optional. Defaults to "id", "ids" and "id" respectively if not specified. 
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EndpointBulkIdNameAttribute : Attribute
    {
        /// <summary>
        /// The default name of the query parameter that acts as the id.
        /// </summary>
        public const string DEFAULT_PARAM_ID = "id";

        /// <summary>
        /// The default name of the query parameter that acts as the ids.
        /// </summary>
        public const string DEFAULT_PARAM_IDS = "ids";

        /// <summary>
        /// The default name of the property in the object returned by the API that acts as the id.
        /// </summary>
        public const string DEFAULT_OBJECT_ID = "id";


        /// <summary>
        /// Creates a new instance of the <see cref="EndpointBulkIdNameAttribute"/> class.
        /// </summary>
        /// <param name="id">The name of the query parameter that acts as the id.</param>
        /// <param name="ids">The name of the query parameter that acts as the ids.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="ids"/> is <see langword="null"/>.</exception>
        public EndpointBulkIdNameAttribute(string id, string ids)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Ids = ids ?? throw new ArgumentNullException(nameof(ids));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EndpointBulkIdNameAttribute"/> class.
        /// </summary>
        /// <param name="objectId">The name of the property in the object returned by the API that acts as the id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="objectId"/>is <see langword="null"/>.</exception>
        public EndpointBulkIdNameAttribute(string objectId)
        {
            this.ObjectId = objectId ?? throw new ArgumentNullException(nameof(objectId));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EndpointBulkIdNameAttribute"/> class.
        /// </summary>
        /// <param name="id">The name of the query parameter that acts as the id.</param>
        /// <param name="ids">The name of the query parameter that acts as the ids.</param>
        /// <param name="objectId">The name of the property in the object returned by the API that acts as the id.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="ids"/> is <see langword="null"/>.</exception>
        public EndpointBulkIdNameAttribute(string id, string ids, string objectId)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Ids = ids ?? throw new ArgumentNullException(nameof(ids));
            this.ObjectId = objectId ?? throw new ArgumentNullException(nameof(objectId));
        }

        /// <summary>
        /// The name of the query parameter that acts as the id.
        /// </summary>
        public string Id { get; } = DEFAULT_PARAM_ID;

        /// <summary>
        /// The name of the query parameter that acts as the ids.
        /// </summary>
        public string Ids { get; } = DEFAULT_PARAM_IDS;

        /// <summary>
        /// The name of the property in the object returned by the API that acts as the id.
        /// </summary>
        public string ObjectId { get; } = DEFAULT_OBJECT_ID;
    }
}
