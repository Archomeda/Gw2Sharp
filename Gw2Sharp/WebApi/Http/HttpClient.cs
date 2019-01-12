using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NetHttpClient = System.Net.Http.HttpClient;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A basic web client that uses .NET's <see cref="NetHttpClient" />.
    /// </summary>
    public class HttpClient : IHttpClient
    {
        /// <inheritdoc />
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <inheritdoc />
        public async Task<IHttpResponse> Request(IHttpRequest request, CancellationToken cancellationToken)
        {
            using (var client = new NetHttpClient())
            using (var cancellationTimeout = new CancellationTokenSource(this.Timeout))
            using (var linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cancellationTimeout.Token))
            {
                var message = new HttpRequestMessage(HttpMethod.Get, request.Url);
                message.Headers.AddRange(request.RequestHeaders);

                Task<HttpResponseMessage>? task = null;
                HttpResponseMessage responseMessage;
                HttpResponse response;
                try
                {
                    task = client.SendAsync(message, linkedCancellation.Token);
                    responseMessage = await task.ConfigureAwait(false);

                    response = new HttpResponse(
                        await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false),
                        responseMessage.StatusCode,
                        request.RequestHeaders.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                        responseMessage.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
                    );

                }
                catch (Exception ex)
                {
                    if (task == null)
                        throw new RequestException(request, $"Failed to create task", ex);
                    else if (task.IsCanceled)
                        throw new RequestCanceledException(request);
                    throw new RequestException(request, $"Request error: {task?.Exception?.Message}", ex);
                }

                if (!responseMessage.IsSuccessStatusCode)
                    throw new UnexpectedStatusException(request, response);

                return response;
            }
        }
    }
}
