using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2
{
    internal class RequestBuilder
    {
        private const int MAX_PAGE_SIZE = 200;

        private const string QUERY_PARAM_PAGE = "page";
        private const string QUERY_PARAM_PAGE_SIZE = "page_size";
        private const string ALL = "all";

        private const string HEADER_SCHEMA_VERSION = "X-Schema-Version";
        private const string HEADER_ACCEPT = "Accept";
        private const string APPLICATION_JSON = "application/json";
        private const string HEADER_ACCEPT_LANGUAGE = "Accept-Language";
        private const string HEADER_AUTHORIZATION = "Authorization";
        private const string BEARER = "Bearer";
        private const string HEADER_USER_AGENT = "User-Agent";

        private readonly string baseUrl;
        private readonly string endpointPath;
        private readonly string? schemaVersion;
        private readonly string bulkQueryParameterIdName;
        private readonly string bulkQueryParameterIdsName;
        private readonly string bulkObjectIdName;
#if NETSTANDARD
        private readonly IDictionary<string, string> queryParams;
#else
        private readonly IReadOnlyDictionary<string, string> queryParams;
#endif

        private readonly IConnection connection;
        private readonly IGw2Client gw2Client;
        private readonly string? authorization;
        private readonly string? locale;
        private readonly string userAgent;

        public RequestBuilder(IEndpointClient endpointClient, IConnection connection, IGw2Client gw2Client)
        {
            this.baseUrl = endpointClient.BaseUrl;
            this.endpointPath = endpointClient.EndpointPath;
            this.schemaVersion = endpointClient.SchemaVersion;
            this.bulkQueryParameterIdName = endpointClient.BulkEndpointIdParameterName;
            this.bulkQueryParameterIdsName = endpointClient.BulkEndpointIdsParameterName;
            this.bulkObjectIdName = endpointClient.BulkEndpointIdObjectName;
#if NETSTANDARD
            this.queryParams = endpointClient.EndpointQueryParameters.ShallowCopy();
#else
            this.queryParams = endpointClient.EndpointQueryParameters.AsReadOnly();
#endif

            this.connection = connection;
            this.gw2Client = gw2Client;

            this.authorization = endpointClient.IsAuthenticated ? $"{BEARER} {connection.AccessToken}" : null;
            this.locale = endpointClient.IsLocalized ? connection.LocaleString : null;
            this.userAgent = connection.UserAgent;
        }


        public IWebApiRequest All()
        {
            var query = this.BuildQueryParams(new Dictionary<string, string>
            {
                [this.bulkQueryParameterIdsName] = ALL
            });
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers), this.connection, this.gw2Client);
        }

        public IWebApiRequest Ids()
        {
            var query = this.BuildQueryParams();
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers), this.connection, this.gw2Client);
        }

        public IWebApiRequest Blob()
        {
            var query = this.BuildQueryParams();
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers), this.connection, this.gw2Client);
        }

        public IWebApiRequest Single<T>(T id)
            where T : notnull
        {
            var query = this.BuildQueryParams();
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers, $"/{FormatId(id)}"), this.connection, this.gw2Client);
        }

        public IWebApiRequest Many<T>(IEnumerable<T> ids)
            where T : notnull
        {
            var query = this.BuildQueryParams(new Dictionary<string, string>
            {
                [this.bulkQueryParameterIdsName] = string.Join(",", ids.Select(FormatId))
            });
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers), this.connection, this.gw2Client);
        }

        public IWebApiRequest Page(int page, int pageSize = MAX_PAGE_SIZE)
        {
            var query = this.BuildQueryParams(new Dictionary<string, string>
            {
                [QUERY_PARAM_PAGE] = page.ToString(CultureInfo.InvariantCulture),
                [QUERY_PARAM_PAGE_SIZE] = pageSize.ToString(CultureInfo.InvariantCulture)
            });
            var headers = this.BuildHeaders();
            return new WebApiRequest(this.BuildRequestOptions(query, headers), this.connection, this.gw2Client);
        }


        private WebApiRequestOptions BuildRequestOptions(IDictionary<string, string>? query, IDictionary<string, string> headers, string appendPath = "") => new()
        {
            BaseUrl = this.baseUrl,
            EndpointPath = $"{this.endpointPath}{appendPath}",
            EndpointQuery = query ?? new Dictionary<string, string>(),
            BulkQueryParameterIdName = this.bulkQueryParameterIdName,
            BulkQueryParameterIdsName = this.bulkQueryParameterIdsName,
            BulkObjectIdName = this.bulkObjectIdName,
            RequestHeaders = headers
        };

        private IDictionary<string, string>? BuildQueryParams(IDictionary<string, string>? additionalQueryParams = null)
        {
            if (this.queryParams.Count == 0)
                return additionalQueryParams;
            var combinedQueryParams = new Dictionary<string, string>(this.queryParams);
            if (additionalQueryParams != null)
                combinedQueryParams.AddRange(additionalQueryParams);
            return combinedQueryParams;
        }

        private IDictionary<string, string> BuildHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                [HEADER_ACCEPT] = APPLICATION_JSON
            };
            if (!string.IsNullOrWhiteSpace(this.authorization))
                headers[HEADER_AUTHORIZATION] = this.authorization;
            if (!string.IsNullOrWhiteSpace(this.locale))
                headers[HEADER_ACCEPT_LANGUAGE] = this.locale;
            if (!string.IsNullOrWhiteSpace(this.userAgent))
                headers[HEADER_USER_AGENT] = this.userAgent;
            if (!string.IsNullOrWhiteSpace(this.schemaVersion))
                headers[HEADER_SCHEMA_VERSION] = this.schemaVersion;
            return headers;
        }

        private static string FormatId<T>(T id) => id switch
        {
            Guid guid => guid.ToString().ToUpperInvariant(),
            _ => id?.ToString() ?? string.Empty
        };
    }
}
