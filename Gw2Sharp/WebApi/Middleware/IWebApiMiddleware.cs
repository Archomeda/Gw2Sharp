using System;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Middleware
{
    /// <summary>
    /// An interface for implementing a web API middleware.
    /// </summary>
    public interface IWebApiMiddleware
    {
        /// <summary>
        /// Gets called when a request is about to be made.
        /// Make sure to call <paramref name="callNext"/> when the middleware is done handling the request,
        /// or you can short circuit the request by not calling <paramref name="callNext"/> at all.
        /// This should return the response.
        /// </summary>
        /// <param name="context">The middleware context.</param>
        /// <param name="callNext">The function that calls the next middleware, if any, or executes the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response.</returns>
        Task<IWebApiResponse> OnRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default);
    }
}
