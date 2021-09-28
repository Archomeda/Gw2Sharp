using System;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Json;
using Gw2Sharp.WebApi.Exceptions;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.Middleware
{
    /// <summary>
    /// The exception middleware for web API v2 requests.
    /// </summary>
    public class ExceptionMiddleware : IWebApiMiddleware
    {
        /// <summary>
        /// The settings that are used when deserializing JSON error objects.
        /// </summary>
        private static readonly JsonSerializerOptions deserializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = SnakeCaseNamingPolicy.SnakeCase
        };

        /// <inheritdoc />
        public virtual Task<IWebApiResponse> OnRequestAsync(MiddlewareContext context, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (callNext is null)
                throw new ArgumentNullException(nameof(callNext));
            return ExecAsync();

            async Task<IWebApiResponse> ExecAsync()
            {
                var httpResponse = await callNext(context, cancellationToken).ConfigureAwait(false);
                if (httpResponse == null)
                    return null!;

                if ((int)httpResponse.StatusCode >= 200 && (int)httpResponse.StatusCode <= 299)
                    return httpResponse;

                ErrorObject? error;
                try
                {
                    error = JsonSerializer.Deserialize<ErrorObject>(httpResponse.Content, deserializerOptions);
                    if (error is null)
                        throw new InvalidOperationException("Unexpected null value from deserialized JSON");
                }
                catch (JsonException)
                {
                    // Fallback message
                    error = new ErrorObject { Text = httpResponse.Content };
                }

                var errorResponse = new WebApiResponse<ErrorObject>(error, httpResponse.StatusCode, httpResponse.CacheState, httpResponse.ResponseHeaders);
                throw httpResponse.StatusCode switch
                {
                    HttpStatusCode.BadRequest => BadRequestException.CreateFromResponse(context.Request, errorResponse),
                    HttpStatusCode.Unauthorized => AuthorizationRequiredException.CreateFromResponse(context.Request, errorResponse),
                    HttpStatusCode.Forbidden => AuthorizationRequiredException.CreateFromResponse(context.Request, errorResponse),
                    HttpStatusCode.NotFound => new NotFoundException(context.Request, errorResponse),
#if NETSTANDARD
                    (HttpStatusCode)429 => new TooManyRequestsException(context.Request, errorResponse),
#else
                    HttpStatusCode.TooManyRequests => new TooManyRequestsException(context.Request, errorResponse),
#endif
                    HttpStatusCode.InternalServerError => new ServerErrorException(context.Request, errorResponse),
                    HttpStatusCode.ServiceUnavailable => new ServiceUnavailableException(context.Request, errorResponse),
                    _ => new UnexpectedStatusException(context.Request, errorResponse)
                };
            }
        }
    }
}
