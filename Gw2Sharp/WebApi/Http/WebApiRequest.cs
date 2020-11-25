using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.Json;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.Middleware;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// A web request.
    /// </summary>
    public class WebApiRequest : IWebApiRequest
    {
        private static readonly ConcurrentDictionary<int, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>> requestCalls =
            new ConcurrentDictionary<int, Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>>();

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

            var call = requestCalls.GetOrAdd(this.connection.MiddlewareHashCode, _ => this.GenerateRequestCall());
            var response = await call(new MiddlewareContext(this.connection, this), cancellationToken).ConfigureAwait(false);

            // Deserialize response
            var obj = JsonSerializer.Deserialize<TResponse>(response.Content, deserializerSettings);

            // If the type is an API v2 object, set its response info property
            switch (obj)
            {
                case IApiV2Object apiV2Object:
                    apiV2Object.HttpResponseInfo ??= new ApiV2HttpResponseInfo(response.StatusCode, response.CacheState, response.ResponseHeaders.AsReadOnly());
                    break;
                case IEnumerable<IApiV2Object> apiV2ObjectList:
                    var responseInfo = new ApiV2HttpResponseInfo(response.StatusCode, response.CacheState, response.ResponseHeaders.AsReadOnly());
                    foreach (var apiV2Obj in apiV2ObjectList)
                        apiV2Obj.HttpResponseInfo ??= responseInfo;
                    break;
            }

            return new WebApiResponse<TResponse>(obj, response.StatusCode, response.CacheState, response.ResponseHeaders);
        }

        private Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> GenerateRequestCall()
        {
            // We have to build the expression tree from inside out

            var contextParam = Expression.Parameter(typeof(MiddlewareContext), "context");
            var cancellationTokenParam = Expression.Parameter(typeof(CancellationToken), "cancellationToken");

            var chain = CreateRequestCallDelegate(
                typeof(IHttpClient).GetMethod(nameof(IHttpClient.RequestAsync))!,
                contextParam,
                cancellationTokenParam);

            foreach (var middleware in this.connection.Middleware.Reverse())
            {
                chain = CreateMiddlewareCallDelegate(
                    middleware,
                    middleware.GetType().GetMethod(nameof(IWebApiMiddleware.OnRequestAsync))!,
                    Expression.Parameter(typeof(MiddlewareContext), "context"),
                    Expression.Parameter(typeof(CancellationToken), "cancellationToken"),
                    chain);
            }

            return chain;
        }

        private static Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> CreateMiddlewareCallDelegate(IWebApiMiddleware currentMiddleware, MethodInfo middlewareOnRequestMethodInfo,
            ParameterExpression contextParam, ParameterExpression cancellationTokenParam,
            Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> previousCall)
        {
            var expressionBody = Expression.Call(
                Expression.Constant(currentMiddleware), middlewareOnRequestMethodInfo,
                contextParam, Expression.Constant(previousCall), cancellationTokenParam);
            var expressionLambda = Expression.Lambda<Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>>(expressionBody, contextParam, cancellationTokenParam);
            return expressionLambda.Compile();
        }

        private static Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>> CreateRequestCallDelegate(MethodInfo httpClientRequestMethodInfo,
            ParameterExpression contextParam, ParameterExpression cancellationTokenParam)
        {
            var expressionBody = Expression.Call(
                Expression.Property(Expression.Property(contextParam, nameof(MiddlewareContext.Connection)), nameof(MiddlewareContext.Connection.HttpClient)), httpClientRequestMethodInfo,
                Expression.Property(contextParam, nameof(MiddlewareContext.Request)), cancellationTokenParam);
            var expressionLambda = Expression.Lambda<Func<MiddlewareContext, CancellationToken, Task<IWebApiResponse>>>(expressionBody, contextParam, cancellationTokenParam);
            return expressionLambda.Compile();
        }
    }
}
