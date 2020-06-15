using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.Json;
using Gw2Sharp.Json.Converters;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web request.
    /// </summary>
    public class WebApiRequest : IWebApiRequest
    {
        private readonly IConnection connection;
        private readonly IGw2Client gw2Client;

        /// <summary>
        /// The settings that are used when deserializing JSON objects.
        /// </summary>
        private static JsonSerializerOptions GetDeserializerSettings(IGw2Client client)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.SnakeCase
            };
            options.Converters.Add(new ApiEnumConverter());
            options.Converters.Add(new ApiFlagsConverter());
            options.Converters.Add(new ApiObjectConverter());
            options.Converters.Add(new ApiObjectListConverter());
            options.Converters.Add(new CastableTypeConverter());
            options.Converters.Add(new DictionaryIntKeyConverter());
            options.Converters.Add(new GuidConverter());
            options.Converters.Add(new RenderUrlConverter(client));
            options.Converters.Add(new TimeSpanConverter());
            return options;
        }

        /// <summary>
        /// Creates a new <see cref="WebApiRequest" />.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="gw2Client">The GW2 client.</param>
        /// <param name="requestHeaders">The request headers to use in the web request.</param>
        /// <exception cref="ArgumentNullException"><paramref name="url"/>, <paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        public WebApiRequest(Uri url, IConnection connection, IGw2Client gw2Client, IDictionary<string, string>? requestHeaders = default)
        {
            if (url is null)
                throw new ArgumentNullException(nameof(url));

            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.gw2Client = gw2Client ?? throw new ArgumentNullException(nameof(gw2Client));

            string baseUrl = new Uri(url.GetLeftPart(UriPartial.Authority)).ToString();
            string endpointPath = url.AbsolutePath;
            var endpointQuery = url.Query.Length > 0
                ? url.Query[1..]
                    .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split('='))
                    .ToDictionary(x => x[0], x => x.Skip(1).FirstOrDefault())
                : new Dictionary<string, string>();
            requestHeaders = requestHeaders?.ShallowCopy() ?? new Dictionary<string, string>();

            this.Options = new WebApiRequestOptions
            {
                BaseUrl = baseUrl,
                EndpointPath = endpointPath,
                EndpointQuery = endpointQuery,
                RequestHeaders = requestHeaders
            };
        }

        /// <summary>
        /// Creates a new <see cref="WebApiRequest"/>.
        /// </summary>
        /// <param name="options">The request options.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="gw2Client">The GW2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/>, <paramref name="connection"/> or <paramref name="gw2Client"/> is <c>null</c>.</exception>
        public WebApiRequest(WebApiRequestOptions options, IConnection connection, IGw2Client gw2Client)
        {
            this.Options = options ?? throw new ArgumentNullException(nameof(options));
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.gw2Client = gw2Client ?? throw new ArgumentNullException(nameof(gw2Client));
        }


        /// <inheritdoc />
        public WebApiRequestOptions Options { get; }


        /// <inheritdoc />
        public IWebApiRequest DeepCopy() =>
            new WebApiRequest(this.Options.DeepCopy(), this.connection, this.gw2Client);

        /// <inheritdoc />
        public async Task<IWebApiResponse<TResponse>> ExecuteAsync<TResponse>(CancellationToken cancellationToken = default)
        {
            var deserializerSettings = GetDeserializerSettings(this.gw2Client);

            // Give the middleware an opportunity to do something with the request and/or response
            var response = await RequestNextAsync(0, this, cancellationToken).ConfigureAwait(false);

            async Task<IWebApiResponse> RequestNextAsync(int middlewareIndex, IWebApiRequest innerRequest, CancellationToken innerCancellationToken) =>
                middlewareIndex < this.connection.Middleware.Count
                    ? await this.connection.Middleware[middlewareIndex].OnRequestAsync(this.connection, innerRequest, (r, t) => RequestNextAsync(middlewareIndex + 1, r, t), innerCancellationToken).ConfigureAwait(false)
                    : await this.connection.HttpClient.RequestAsync(innerRequest, innerCancellationToken).ConfigureAwait(false);

            // Deserialize response
            var obj = JsonSerializer.Deserialize<TResponse>(response.Content, deserializerSettings);
            return new WebApiResponse<TResponse>(obj, response.StatusCode, response.ResponseHeaders);
        }
    }
}
