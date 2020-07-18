using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// Implements an endpoint client.
    /// </summary>
    public interface IEndpointClient
    {
        /// <summary>
        /// The base URL used for this endpoint.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// The endpoint path used for this endpoint.
        /// </summary>
        string EndpointPath { get; }

        /// <summary>
        /// The additional endpoint query parameters for this endpoint.
        /// </summary>
        IDictionary<string, string> EndpointQueryParameters { get; }

        /// <summary>
        /// The name of the query parameter that acts as the id for a bulk expandable endpoint.
        /// </summary>
        string BulkEndpointIdParameterName { get; }

        /// <summary>
        /// The name of the query parameter that acts as the ids for a bulk expandable endpoint.
        /// </summary>
        string BulkEndpointIdsParameterName { get; }

        /// <summary>
        /// The name of the property that acts as the id for a bulk expandable endpoint.
        /// </summary>
        string BulkEndpointIdObjectName { get; }

        /// <summary>
        /// The endpoint schema version override.
        /// </summary>
        string? SchemaVersion { get; }


        /// <summary>
        /// Gets whether this endpoint supports localization.
        /// </summary>
        bool IsLocalized { get; }

        /// <summary>
        /// Gets whether this endpoint requires authentication.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets whether this endpoint supports pagination.
        /// </summary>
        bool IsPaginated { get; }

        /// <summary>
        /// Gets whether this endpoint supports expansion with the 'all' parameter.
        /// </summary>
        bool IsAllExpandable { get; }

        /// <summary>
        /// Gets whether this endpoint supports bulk expansion.
        /// </summary>
        bool IsBulkExpandable { get; }

        /// <summary>
        /// Gets whether this endpoint has blob data (replaces the default returned list of ids).
        /// </summary>
        bool HasBlobData { get; }
    }
}
