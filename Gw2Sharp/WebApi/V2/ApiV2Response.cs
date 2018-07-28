using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An API v2 response.
    /// </summary>
    public class ApiV2Response<T> : HttpResponse<T>, IApiV2Response<T>
    {
        private static readonly Regex LinkRelRegex = new Regex("rel=\"?(previous|next|self|first|last)\"?", RegexOptions.IgnoreCase);
        private static readonly Regex LinkUriRegex = new Regex("<(.+)>", RegexOptions.IgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV2Response{T}"/> class.
        /// </summary>
        public ApiV2Response() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV2Response{T}"/> class with a <see cref="IHttpResponse{T}"/> as base.
        /// </summary>
        /// <param name="response">The base response.</param>
        public ApiV2Response(IHttpResponse<T> response)
        {
            this.Content = response.Content;
            this.StatusCode = response.StatusCode;
            this.RequestHeaders = response.RequestHeaders?.ShallowCopy().AsReadOnly();
            this.ResponseHeaders = response.ResponseHeaders?.ShallowCopy().AsReadOnly();
            this.CacheMaxAge = this.ParseResponseHeader(response.ResponseHeaders, "Cache-Control", value => CacheControlHeaderValue.Parse(value).MaxAge);
            this.Expires = this.ParseResponseHeader(response.ResponseHeaders, "Expires", value => DateTime.Parse(value));
            this.RateLimitLimit = this.ParseResponseHeader(response.ResponseHeaders, "X-Rate-Limit-Limit", ParseNullableInt);
            this.ResultCount = this.ParseResponseHeader(response.ResponseHeaders, "X-Result-Count", ParseNullableInt);
            this.ResultTotal = this.ParseResponseHeader(response.ResponseHeaders, "X-Result-Total", ParseNullableInt);
            this.Links = this.ParseResponseHeader(response.ResponseHeaders, "Link", value =>
                value.Split(',')
                    .Select(link =>
                    {
                        var rel = LinkRelRegex.Match(link);
                        if (!rel.Success || rel.Groups.Count != 2)
                            return null;
                        var uri = LinkUriRegex.Match(link);
                        if (!uri.Success || uri.Groups.Count != 2)
                            return null;
                        return Tuple.Create(rel.Groups[1].Value, new Uri(uri.Groups[1].Value, UriKind.RelativeOrAbsolute));
                    })
                    .Where(link => link != null)
                    .ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2)
                    .AsReadOnly());
            this.PageSize = this.ParseResponseHeader(response.ResponseHeaders, "X-Page-Size", ParseNullableInt);
            this.PageTotal = this.ParseResponseHeader(response.ResponseHeaders, "X-Page-Total", ParseNullableInt);

            int? ParseNullableInt(string value) => int.Parse(value);
        }

        /// <inheritdoc />
        public TimeSpan? CacheMaxAge { get; set; }

        /// <inheritdoc />
        public DateTime? Expires { get; set; }

        /// <inheritdoc />
        public int? RateLimitLimit { get; set; }

        /// <inheritdoc />
        public int? ResultCount { get; set; }

        /// <inheritdoc />
        public int? ResultTotal { get; set; }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, Uri> Links { get; set; }

        /// <inheritdoc />
        public int? PageSize { get; set; }

        /// <inheritdoc />
        public int? PageTotal { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="ApiV2Response{T}"/> to the content type T.
        /// </summary>
        /// <param name="obj">The response object.</param>
        /// <returns>
        /// The response content object.
        /// </returns>
        public static implicit operator T(ApiV2Response<T> obj) => obj.Content;

        private TResult ParseResponseHeader<TResult>(IReadOnlyDictionary<string, string> headers, string key, Func<string, TResult> parser)
        {
            if (headers == null)
                return default;

            headers.TryGetValue(key, out string header);
            try
            {
                return parser(header);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                    return default;
                throw;
            }
        }
    }
}
