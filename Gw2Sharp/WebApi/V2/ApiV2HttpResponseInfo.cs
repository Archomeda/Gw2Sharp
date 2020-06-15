using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An API v2 response info.
    /// </summary>
    public class ApiV2HttpResponseInfo : HttpResponseInfo
    {
        private static readonly Regex linkRelRegex = new Regex("rel=\"?(previous|next|self|first|last)\"?", RegexOptions.IgnoreCase);
        private static readonly Regex linkUriRegex = new Regex("<(.+)>", RegexOptions.IgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV2HttpResponseInfo"/> class with a <see cref="IWebApiResponse{T}"/> as base.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="responseHeaders">The HTTP response headers.</param>
        public ApiV2HttpResponseInfo(HttpStatusCode statusCode, IReadOnlyDictionary<string, string>? responseHeaders) :
            base(statusCode, responseHeaders)
        {
            responseHeaders ??= new Dictionary<string, string>();

            this.RateLimitLimit = ParseResponseHeader(responseHeaders, "X-Rate-Limit-Limit", ParseNullableInt);
            this.ResultCount = ParseResponseHeader(responseHeaders, "X-Result-Count", ParseNullableInt);
            this.ResultTotal = ParseResponseHeader(responseHeaders, "X-Result-Total", ParseNullableInt);
            this.Links = ParseResponseHeader(responseHeaders, "Link", value => value
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
            this.PageSize = ParseResponseHeader(responseHeaders, "X-Page-Size", ParseNullableInt);
            this.PageTotal = ParseResponseHeader(responseHeaders, "X-Page-Total", ParseNullableInt);

            static int? ParseNullableInt(string value) => !string.IsNullOrWhiteSpace(value) ? (int?)int.Parse(value, CultureInfo.InvariantCulture) : null;
        }


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
        public IReadOnlyDictionary<string, Uri> Links { get; protected set; }

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
    }
}
