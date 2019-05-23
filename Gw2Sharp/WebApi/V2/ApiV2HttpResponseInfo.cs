using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An API v2 response info.
    /// </summary>
    public class ApiV2HttpResponseInfo
    {
        private static readonly Regex linkRelRegex = new Regex("rel=\"?(previous|next|self|first|last)\"?", RegexOptions.IgnoreCase);
        private static readonly Regex linkUriRegex = new Regex("<(.+)>", RegexOptions.IgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV2HttpResponseInfo"/> class with a <see cref="IHttpResponse{T}"/> as base.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="requestHeaders">The HTTP request headers.</param>
        /// <param name="responseHeaders">The HTTP response headers.</param>
        public ApiV2HttpResponseInfo(HttpStatusCode statusCode, IReadOnlyDictionary<string, string>? requestHeaders, IReadOnlyDictionary<string, string>? responseHeaders)
        {
            requestHeaders ??= new Dictionary<string, string>();
            responseHeaders ??= new Dictionary<string, string>();

            this.ResponseStatusCode = statusCode;
            this.RawRequestHeaders = requestHeaders.ShallowCopy().AsReadOnly();
            this.RawResponseHeaders = responseHeaders.ShallowCopy().AsReadOnly();

            this.Date = this.ParseResponseHeader(responseHeaders, "Date", value => DateTime.Parse(value));
            this.LastModified = this.ParseResponseHeader(responseHeaders, "Last-Modified", ParseNullableDateTime);
            this.CacheMaxAge = this.ParseResponseHeader(responseHeaders, "Cache-Control", value => CacheControlHeaderValue.Parse(value).MaxAge);
            this.Expires = this.ParseResponseHeader(responseHeaders, "Expires", ParseNullableDateTime);
            this.RateLimitLimit = this.ParseResponseHeader(responseHeaders, "X-Rate-Limit-Limit", ParseNullableInt);
            this.ResultCount = this.ParseResponseHeader(responseHeaders, "X-Result-Count", ParseNullableInt);
            this.ResultTotal = this.ParseResponseHeader(responseHeaders, "X-Result-Total", ParseNullableInt);
            this.Links = this.ParseResponseHeader(responseHeaders, "Link", value => value
                .Split(',')
                .Select(link =>
                {
                    var rel = linkRelRegex.Match(link);
                    if (!rel.Success || rel.Groups.Count != 2)
                        return null;
                    var uri = linkUriRegex.Match(link);
                    return uri.Success && uri.Groups.Count == 2
                        ? Tuple.Create(rel.Groups[1].Value, new Uri(uri.Groups[1].Value, UriKind.RelativeOrAbsolute))
                        : null;
                })
                .Where(link => link != null)
                .ToDictionary(kvp => kvp!.Item1, kvp => kvp!.Item2)
                .AsReadOnly());
            this.PageSize = this.ParseResponseHeader(responseHeaders, "X-Page-Size", ParseNullableInt);
            this.PageTotal = this.ParseResponseHeader(responseHeaders, "X-Page-Total", ParseNullableInt);

            static DateTime? ParseNullableDateTime(string value) => !string.IsNullOrWhiteSpace(value) ? (DateTime?)DateTime.Parse(value) : null;
            static int? ParseNullableInt(string value) => !string.IsNullOrWhiteSpace(value) ? (int?)int.Parse(value) : null;
        }


        /// <summary>
        /// The response status code.
        /// </summary>
        public HttpStatusCode ResponseStatusCode { get; protected set; }

        /// <summary>
        /// The raw request headers.
        /// </summary>
        public IReadOnlyDictionary<string, string> RawRequestHeaders { get; protected set; }

        /// <summary>
        /// The raw response headers.
        /// </summary>
        public IReadOnlyDictionary<string, string> RawResponseHeaders { get; protected set; }


        /// <summary>
        /// The response date.
        /// This is returned by the header Date.
        /// </summary>
        public DateTime Date { get; protected set; }

        /// <summary>
        /// The date the resource has last been modified.
        /// This is returned by the header Date.
        /// </summary>
        public DateTime? LastModified { get; protected set; }

        /// <summary>
        /// The cache age.
        /// This is returned by the value max-age in the header Cache-Control.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public TimeSpan? CacheMaxAge { get; protected set; }

        /// <summary>
        /// The cache expiry date.
        /// This is returned by the header Expires.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public DateTime? Expires { get; protected set; }

        /// <summary>
        /// The rate limit limit.
        /// This is returned by the header X-Rate-Limit-Limit.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public int? RateLimitLimit { get; protected set; }

        /// <summary>
        /// The result count.
        /// This is returned by the header X-Result-Count.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public int? ResultCount { get; protected set; }

        /// <summary>
        /// The result total.
        /// This is returned by the header X-Result-Total.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public int? ResultTotal { get; protected set; }

        /// <summary>
        /// The links.
        /// This is returned by the header Link and may contain the following ids: previous, next, self, first, last.
        /// </summary>
        public IReadOnlyDictionary<string, Uri> Links { get; protected set; } = new Dictionary<string, Uri>();

        /// <summary>
        /// The page size.
        /// This is returned by the header X-Page-Size.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public int? PageSize { get; protected set; }

        /// <summary>
        /// The page total.
        /// This is returned by the header X-Page-Total.
        /// This value is <c>null</c> if the response didn't contain the appropriate header.
        /// </summary>
        public int? PageTotal { get; protected set; }


        private TResult ParseResponseHeader<TResult>(IReadOnlyDictionary<string, string> headers, string key, Func<string, TResult> parser)
        {
            if (headers == null)
                return default!;

            headers.TryGetValue(key, out string header);
            try
            {
                return parser(header);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                    return default!;
                throw;
            }
        }
    }
}
