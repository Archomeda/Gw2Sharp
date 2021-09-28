using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// An abstract base class for implementing endpoint clients.
    /// </summary>
    public abstract class BaseEndpointClient : Gw2WebApiBaseClient, IEndpointClient
    {
        private readonly IReadOnlyList<(PropertyInfo Property, EndpointQueryParameterAttribute Attribute)> parameterProperties;

        /// <summary>
        /// Creates a new base endpoint client.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <param name="replaceSegments">The path segments to replace.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> or <paramref name="gw2Client"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// The client implements an invalid combination of <see cref="IEndpointClient"/> interfaces,
        /// or the number of replace segments does not equal the number of path segments given by <see cref="EndpointPathSegmentAttribute"/>.
        /// </exception>
        protected BaseEndpointClient(IConnection connection, IGw2Client gw2Client, params string[] replaceSegments) :
            base(connection, gw2Client)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));
            if (gw2Client == null)
                throw new ArgumentNullException(nameof(gw2Client));

            this.BaseUrl = Gw2WebApiV2Client.UrlBase.AbsoluteUri;
            this.EndpointPath = this.GetRequiredAttribute<EndpointPathAttribute>().EndpointPath;
            this.parameterProperties = this.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => (Property: p, Attribute: p.GetCustomAttribute<EndpointQueryParameterAttribute>()))
                .Where(x => x.Attribute != null)
                .Select(x => (x.Property, x.Attribute!))
                .ToList()
                .AsReadOnly();
            var bulkIdAttribute = this.GetAttribute<EndpointBulkIdNameAttribute>();
            this.BulkEndpointIdParameterName = bulkIdAttribute?.Id ?? EndpointBulkIdNameAttribute.DEFAULT_PARAM_ID;
            this.BulkEndpointIdsParameterName = bulkIdAttribute?.Ids ?? EndpointBulkIdNameAttribute.DEFAULT_PARAM_IDS;
            this.BulkEndpointIdObjectName = bulkIdAttribute?.ObjectId ?? EndpointBulkIdNameAttribute.DEFAULT_OBJECT_ID;
            this.SchemaVersion = this.GetAttribute<EndpointSchemaVersionAttribute>()?.SchemaVersion;

#pragma warning disable S3060 // "is" should not be used with "this"
            this.IsLocalized = this is ILocalizedClient;
            this.IsAuthenticated = this is IAuthenticatedClient;
#pragma warning restore S3060 // "is" should not be used with "this"
            this.IsPaginated = this.ImplementsGenericInterface(typeof(IPaginatedClient<>));
            this.IsAllExpandable = this.ImplementsGenericInterface(typeof(IAllExpandableClient<>));
            this.IsBulkExpandable = this.ImplementsGenericInterface(typeof(IBulkExpandableClient<,>));
            this.HasBlobData = this.ImplementsGenericInterface(typeof(IBlobClient<>));

            if (this.HasBlobData && (this.IsAllExpandable || this.IsBulkExpandable))
                throw new InvalidOperationException("An endpoint cannot implement all or bulk expansion in combination with blob data.");

            var segments = this.GetAttributes<EndpointPathSegmentAttribute>().OrderBy(a => a.Order).ToList();
            if (segments.Count != replaceSegments.Length)
                throw new InvalidOperationException($"The number of defined attribute path segments ({segments.Count}) does not equal the number of given replacement segments in the constructor ({replaceSegments.Length})");

            for (int i = 0; i < segments.Count; i++)
#if NETSTANDARD
                this.EndpointPath = this.EndpointPath.Replace($":{segments[i].PathSegment}", replaceSegments[i]);
#else
                this.EndpointPath = this.EndpointPath.Replace($":{segments[i].PathSegment}", replaceSegments[i], StringComparison.InvariantCulture);
#endif
        }


        #region Properties

        /// <inheritdoc />
        public string BaseUrl { get; }

        /// <inheritdoc />
        public string EndpointPath { get; }

        /// <inheritdoc />
        public IDictionary<string, string> EndpointQueryParameters =>
            this.parameterProperties
                .Select(x => new KeyValuePair<string, object?>(x.Attribute.ParameterName, x.Property.GetValue(this)))
                .Where(x => x.Value != null) // Explicit check for null
                .ToDictionary(x => x.Key, x => x.Value!.ToString()!);

        /// <inheritdoc />
        public string BulkEndpointIdParameterName { get; }

        /// <inheritdoc />
        public string BulkEndpointIdsParameterName { get; }

        /// <inheritdoc />
        public string BulkEndpointIdObjectName { get; }

        /// <inheritdoc />
        public string? SchemaVersion { get; }


        /// <inheritdoc />
        public bool IsPaginated { get; }

        /// <inheritdoc />
        public bool IsAuthenticated { get; }

        /// <inheritdoc />
        public bool IsLocalized { get; }

        /// <inheritdoc />
        public bool HasBlobData { get; }

        /// <inheritdoc />
        public bool IsAllExpandable { get; }

        /// <inheritdoc />
        public bool IsBulkExpandable { get; }

        #endregion


        #region Reflection helpers

        private bool ImplementsGenericInterface(Type interfaceType) =>
            this.GetType().GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == interfaceType);

        private T GetRequiredAttribute<T>() where T : Attribute =>
            this.GetRequiredAttributes<T>().First();

        private IReadOnlyList<T> GetRequiredAttributes<T>() where T : Attribute
        {
            var attrs = this.GetAttributes<T>();
            if (attrs.Count == 0)
                throw new InvalidOperationException($"{this.GetType().FullName} is required to define one or more attributes of {typeof(T).FullName}");
            return attrs;
        }

        private T? GetAttribute<T>() where T : Attribute =>
            this.GetAttributes<T>().FirstOrDefault();

        private IReadOnlyList<T> GetAttributes<T>() where T : Attribute =>
            this.GetType().GetCustomAttributes<T>().ToList();

        #endregion
    }
}
