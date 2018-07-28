using Gw2Sharp.WebApi.Http;
using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for implementing an API v2 response.
    /// </summary>
    public interface IApiV2Response<T> : IHttpResponse<T>
    {
        /// <summary>
        /// The cache age.
        /// This is returned by the value max-age in the header Cache-Control.
        /// </summary>
        TimeSpan? CacheMaxAge { get; }

        /// <summary>
        /// The cache expiry date.
        /// This is returned by the header Expires.
        /// </summary>
        DateTime? Expires { get; }

        /// <summary>
        /// The rate limit limit.
        /// This is returned by the header X-Rate-Limit-Limit.
        /// </summary>
        int? RateLimitLimit { get; }

        /// <summary>
        /// The result count.
        /// This is returned by the header X-Result-Count.
        /// </summary>
        int? ResultCount { get; }

        /// <summary>
        /// The result total.
        /// This is returned by the header X-Result-Total.
        /// </summary>
        int? ResultTotal { get; }

        /// <summary>
        /// The links.
        /// This is returned by the header Link and may contain the following ids: previous, next, self, first, last.
        /// </summary>
        IReadOnlyDictionary<string, Uri> Links { get; }

        /// <summary>
        /// The page size.
        /// This is returned by the header X-Page-Size.
        /// </summary>
        int? PageSize { get; }

        /// <summary>
        /// The page total.
        /// This is returned by the header X-Page-Total.
        /// </summary>
        int? PageTotal { get; }
    }
}
