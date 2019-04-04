using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for implementing an API v2 response.
    /// </summary>
    public interface IApiV2Response<T> : IHttpResponse<T>
    {
        /// <summary>
        /// Whether the response is from a earlier request that was cached.
        /// </summary>
        bool Cached { get; }

        /// <summary>
        /// The cache age.
        /// This is returned by the value max-age in the header Cache-Control.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        TimeSpan? CacheMaxAge { get; }

        /// <summary>
        /// The cache expiry date.
        /// This is returned by the header Expires.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        DateTime? Expires { get; }

        /// <summary>
        /// The rate limit limit.
        /// This is returned by the header X-Rate-Limit-Limit.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        int? RateLimitLimit { get; }

        /// <summary>
        /// The result count.
        /// This is returned by the header X-Result-Count.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        int? ResultCount { get; }

        /// <summary>
        /// The result total.
        /// This is returned by the header X-Result-Total.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
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
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        int? PageSize { get; }

        /// <summary>
        /// The page total.
        /// This is returned by the header X-Page-Total.
        /// This value is <c>null</c> if <see cref="Cached"/> is <c>true</c> or the response didn't contain the appropriate header.
        /// </summary>
        int? PageTotal { get; }
    }
}
