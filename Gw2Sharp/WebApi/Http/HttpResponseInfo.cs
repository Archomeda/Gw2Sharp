using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using Gw2Sharp.Extensions;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// An HTTP response info.
    /// </summary>
    public class HttpResponseInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseInfo"/> class with a <see cref="IWebApiResponse{T}"/> as base.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="cacheState">The cache state.</param>
        /// <param name="responseHeaders">The HTTP response headers.</param>
        public HttpResponseInfo(HttpStatusCode statusCode, CacheState cacheState, IReadOnlyDictionary<string, string>? responseHeaders)
        {
            responseHeaders ??= new Dictionary<string, string>();

            this.ResponseStatusCode = statusCode;
            this.RawResponseHeaders = responseHeaders.ShallowCopy().AsReadOnly();

            this.Date = ParseResponseHeader(responseHeaders, "Date", value => DateTimeOffset.Parse(value, CultureInfo.InvariantCulture));
            this.LastModified = ParseResponseHeader(responseHeaders, "Last-Modified", ParseNullableDateTime);
            this.CacheMaxAge = ParseResponseHeader(responseHeaders, "Cache-Control", ParseNullableMaxAgeCache);
            this.Expires = ParseResponseHeader(responseHeaders, "Expires", ParseNullableDateTime);
            this.CacheState = cacheState;

            static DateTimeOffset? ParseNullableDateTime(string value) =>
                !string.IsNullOrWhiteSpace(value) ? (DateTimeOffset?)DateTimeOffset.Parse(value, CultureInfo.InvariantCulture) : null;

            static TimeSpan? ParseNullableMaxAgeCache(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;
                if (value.StartsWith("\"", StringComparison.OrdinalIgnoreCase) && value.EndsWith("\"", StringComparison.OrdinalIgnoreCase))
                    value = value[1..^1];
                return CacheControlHeaderValue.Parse(value).MaxAge;
            }
        }


        /// <summary>
        /// The response status code.
        /// </summary>
        public HttpStatusCode ResponseStatusCode { get; protected set; }

        /// <summary>
        /// The raw response headers.
        /// </summary>
        public IReadOnlyDictionary<string, string> RawResponseHeaders { get; protected set; }


        /// <summary>
        /// The response date.
        /// This is returned by the header Date.
        /// </summary>
        public DateTimeOffset Date { get; protected set; }

        /// <summary>
        /// The date the resource has last been modified.
        /// This is returned by the header Date.
        /// </summary>
        public DateTimeOffset? LastModified { get; protected set; }

        /// <summary>
        /// The cache age.
        /// This is returned by the value max-age in the header Cache-Control.
        /// This value is <see langword="null"/> if the response didn't contain the appropriate header.
        /// </summary>
        public TimeSpan? CacheMaxAge { get; protected set; }

        /// <summary>
        /// The cache expiry date.
        /// This is returned by the header Expires.
        /// This value is <see langword="null"/> if the response didn't contain the appropriate header.
        /// </summary>
        public DateTimeOffset? Expires { get; protected set; }

        /// <summary>
        /// The cache state.
        /// </summary>
        public CacheState CacheState { get; set; }

        /// <summary>
        /// Parses a response header.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="headers">The headers.</param>
        /// <param name="key">The key.</param>
        /// <param name="parser">The parser.</param>
        /// <returns>The parsed response header.</returns>
        protected static TResult ParseResponseHeader<TResult>(IReadOnlyDictionary<string, string> headers, string key, Func<string, TResult> parser)
        {
            if (headers == null)
                return default!;
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));

            headers.TryGetValue(key, out string? header);
            if (header == null)
                return default!;

            try
            {
                return parser(header);
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                    return default!;
                throw;
            }
        }
    }
}
