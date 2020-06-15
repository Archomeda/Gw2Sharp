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
        public virtual async Task<IWebApiResponse> OnRequestAsync(IConnection connection, IWebApiRequest request, Func<IWebApiRequest, CancellationToken, Task<IWebApiResponse>> callNext, CancellationToken cancellationToken = default)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            if (callNext is null)
                throw new ArgumentNullException(nameof(callNext));

            var httpResponse = await callNext(request, cancellationToken).ConfigureAwait(false);
            if (httpResponse == null)
                return null!;

            if ((int)httpResponse.StatusCode >= 200 && (int)httpResponse.StatusCode <= 299)
                return httpResponse;

            ErrorObject error;
            try
            {
                error = JsonSerializer.Deserialize<ErrorObject>(httpResponse.Content, deserializerOptions);
            }
            catch (JsonException)
            {
                // Fallback message
                throw new UnexpectedStatusException(request, httpResponse, httpResponse.Content ?? string.Empty);
            }

            var errorResponse = new WebApiResponse<ErrorObject>(error, httpResponse.StatusCode, httpResponse.ResponseHeaders);
            throw httpResponse.StatusCode switch
            {
                // 400
                HttpStatusCode.BadRequest => new BadRequestException(request, errorResponse),
                // 401
                HttpStatusCode.Unauthorized => AuthorizationRequiredException.CreateFromResponse(request, errorResponse),
                // 403
                HttpStatusCode.Forbidden => AuthorizationRequiredException.CreateFromResponse(request, errorResponse),
                // 404
                HttpStatusCode.NotFound => new NotFoundException(request, errorResponse),
                // 429
                (HttpStatusCode)429 => new TooManyRequestsException(request, errorResponse),
                // 500
                HttpStatusCode.InternalServerError => new ServerErrorException(request, errorResponse),
                // 503
                HttpStatusCode.ServiceUnavailable => new ServiceUnavailableException(request, errorResponse),

                _ => new UnexpectedStatusException(request, httpResponse, httpResponse.Content ?? string.Empty),
            };
        }
    }
}
