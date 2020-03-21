using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.Json;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp
{
    /// <summary>
    /// A web API connection.
    /// </summary>
    public class Connection : IConnection
    {
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

        private readonly Dictionary<string, string> requestHeaders;
        private IHttpClient httpClient;
        private ICacheMethod cacheMethod;
        private ICacheMethod renderCacheMethod;
        private string accessToken;


        /// <summary>
        /// Creates a new <see cref="Connection"/> without an API key,
        /// with English locale,
        /// with .NET's HTTP client,
        /// with in-memory caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        public Connection() : this(string.Empty, Locale.English) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// English locale,
        /// .NET's HTTP client,
        /// in-memory caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        public Connection(string accessToken) : this(accessToken, Locale.English) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> without an API key,
        /// with a specified locale,
        /// with .NET's HTTP client,
        /// with in-memory caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        /// <param name="locale">The locale.</param>
        public Connection(Locale locale) : this(string.Empty, locale) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key and locale.
        /// With optionally a custom user agent,
        /// HTTP client,
        /// caching method for API requests,
        /// and caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="userAgent">The User-Agent.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <param name="renderCacheMethod">The render cache method.</param>
        /// <param name="renderCacheDuration">The render cache duration (defaults to render API headers)</param>
        public Connection(
            string? accessToken,
            Locale locale,
            ICacheMethod? cacheMethod = null,
            ICacheMethod? renderCacheMethod = null,
            TimeSpan? renderCacheDuration = null,
            string? userAgent = null,
            IHttpClient? httpClient = null)
        {
            this.accessToken = accessToken ?? string.Empty;
            this.Locale = locale;
            this.UserAgent = $"{userAgent}{(string.IsNullOrWhiteSpace(userAgent) ? " " : "")}" +
                $"Gw2Sharp/{typeof(Connection).GetTypeInfo().Assembly.GetName().Version?.ToString(3)} (https://github.com/Archomeda/Gw2Sharp)";
            this.httpClient = httpClient ?? new HttpClient();
            this.cacheMethod = cacheMethod ?? new MemoryCacheMethod();
            this.renderCacheMethod = renderCacheMethod ?? new NullCacheMethod();
            this.RenderCacheDuration = renderCacheDuration ?? TimeSpan.Zero;

            this.requestHeaders = new Dictionary<string, string>()
            {
                { "Accept", "application/json" },
                { "Accept-Language", this.LocaleString }
            };
            if (!string.IsNullOrWhiteSpace(this.AccessToken))
                this.requestHeaders.Add("Authorization", $"Bearer {this.AccessToken}");
            if (!string.IsNullOrWhiteSpace(this.UserAgent))
                this.requestHeaders.Add("User-Agent", this.UserAgent);
        }


        /// <inheritdoc />
        public string AccessToken
        {
            get => this.accessToken;
            set => this.accessToken = value ?? string.Empty;
        }

        /// <inheritdoc />
        public Locale Locale { get; set; }

        /// <inheritdoc />
        public string LocaleString
        {
            get => this.Locale switch
            {
                Locale.German => "de",
                Locale.French => "fr",
                Locale.Spanish => "es",
                Locale.Korean => "ko",
                Locale.Chinese => "zh",
                _ => "en"
            };
        }

        /// <inheritdoc />
        public string UserAgent { get; private set; }

        /// <inheritdoc />
        public IHttpClient HttpClient
        {
            get => this.httpClient;
            set => this.httpClient = value ?? throw new ArgumentNullException(nameof(value), "HttpClient cannot be null");
        }

        /// <inheritdoc />
        public ICacheMethod CacheMethod
        {
            get => this.cacheMethod;
            set => this.cacheMethod = value ?? throw new ArgumentNullException(nameof(value), "CacheMethod cannot be null");
        }

        /// <inheritdoc />
        public TimeSpan RenderCacheDuration { get; set; } = TimeSpan.Zero;

        /// <inheritdoc />
        public ICacheMethod RenderCacheMethod
        {
            get => this.renderCacheMethod;
            set => this.renderCacheMethod = value ?? throw new ArgumentNullException(nameof(value), "RenderCacheMethod cannot be null");
        }


        /// <inheritdoc />
        public Task<IHttpResponse<TResponse>> RequestAsync<TResponse>(IGw2Client client, Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken = default)
        {
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            return this.RequestInternalAsync<TResponse>(client, requestUri, additionalHeaders, cancellationToken);
        }

        private async Task<IHttpResponse<TResponse>> RequestInternalAsync<TResponse>(IGw2Client client, Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken)
        {
            IDictionary<string, string> headers = this.requestHeaders;
            if (additionalHeaders != null)
            {
                headers = headers.ShallowCopy();
                headers.AddRange(additionalHeaders);
            }

            var request = new HttpRequest(requestUri, headers);
            var deserializerSettings = GetDeserializerSettings(client);

            try
            {
                var r = await this.HttpClient.RequestAsync(request, cancellationToken).ConfigureAwait(false);
                var obj = JsonSerializer.Deserialize<TResponse>(r.Content, deserializerSettings);
                return new HttpResponse<TResponse>(obj, r.StatusCode, r.RequestHeaders, r.ResponseHeaders);
            }
            catch (UnexpectedStatusException ex)
            {
                var error = new ErrorObject();
                try
                {
                    if (ex.Response != null)
                        error = JsonSerializer.Deserialize<ErrorObject>(ex.Response.Content, deserializerSettings);
                }
                catch (JsonException)
                {
                    // Fallback message
                    throw new UnexpectedStatusException(ex.Request, ex.Response, ex.Response?.Content ?? string.Empty);
                }

                var errorResponse = new HttpResponse<ErrorObject>(error, ex.Response?.StatusCode, ex.Response?.RequestHeaders, ex.Response?.RequestHeaders);

                switch (ex.Response?.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        // 400
                        throw new BadRequestException(ex.Request, errorResponse);
                    case HttpStatusCode.Unauthorized:
                        // 401
                        throw AuthorizationRequiredException.CreateFromResponse(ex.Request, errorResponse);
                    case HttpStatusCode.Forbidden:
                        // 403
                        throw AuthorizationRequiredException.CreateFromResponse(ex.Request, errorResponse);
                    case HttpStatusCode.NotFound:
                        // 404
                        throw new NotFoundException(ex.Request, errorResponse);
                    case (HttpStatusCode)429:
                        // 429
                        throw new TooManyRequestsException(ex.Request, errorResponse);
                    case HttpStatusCode.InternalServerError:
                        // 500
                        throw new ServerErrorException(ex.Request, errorResponse);
                    case HttpStatusCode.ServiceUnavailable:
                        // 503
                        throw new ServiceUnavailableException(ex.Request, errorResponse);
                    default:
                        throw new UnexpectedStatusException(ex.Request, ex.Response, ex.Response?.Content ?? string.Empty);
                }
            }
        }
    }
}
