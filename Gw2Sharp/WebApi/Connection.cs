using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Extensions;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.V2.Models;
using Gw2Sharp.WebApi.V2.Models.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gw2Sharp.WebApi
{
    /// <summary>
    /// A web API connection.
    /// </summary>
    public class Connection : IConnection
    {
        /// <summary>
        /// The settings that are used when deserializing JSON objects.
        /// </summary>
        public static readonly JsonSerializerSettings DeserializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            Converters = new JsonConverter[]
            {
                new ApiObjectConverter(),
                new ApiObjectListConverter(),
                new ApiEnumConverter(),
                new CastableTypeConverter(),
                new Coordinates2Converter(),
                new GuidConverter(),
                new SizeConverter(),
                new TimeSpanConverter()
            }
        };

        private readonly Dictionary<string, string> requestHeaders;


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
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// a specified locale,
        /// .NET's HTTP client,
        /// in-memory caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        public Connection(string accessToken, Locale locale) : this(accessToken, locale, new HttpClient(), new MemoryCacheMethod()) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// a specified locale,
        /// a specified HTTP client,
        /// a specified caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/> or <paramref name="cacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, IHttpClient httpClient, ICacheMethod cacheMethod) :
            this(accessToken, locale, string.Empty, httpClient, cacheMethod)
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// locale,
        /// HTTP client,
        /// caching method for API requests,
        /// and caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <param name="renderCacheMethod">The render cache method.</param>
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/> or <paramref name="cacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, IHttpClient httpClient, ICacheMethod cacheMethod, ICacheMethod renderCacheMethod) :
            this(accessToken, locale, string.Empty, httpClient, cacheMethod, renderCacheMethod)
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// locale,
        /// HTTP client,
        /// caching method for API requests,
        /// and caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <param name="renderCacheMethod">The render cache method.</param>
        /// <param name="renderCacheDuration">The render cache duration (defaults to render API headers)</param>
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/> or <paramref name="cacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, IHttpClient httpClient, ICacheMethod cacheMethod, ICacheMethod renderCacheMethod, TimeSpan renderCacheDuration) :
            this(accessToken, locale, string.Empty, httpClient, cacheMethod, renderCacheMethod, renderCacheDuration)
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// a specified locale,
        /// a custom user agent,
        /// a specified HTTP client,
        /// a specified caching method for API requests,
        /// and no caching method for render API requests.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="userAgent">The User-Agent.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/> or <paramref name="cacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, string userAgent, IHttpClient httpClient, ICacheMethod cacheMethod) :
            this(accessToken, locale, userAgent, httpClient, cacheMethod, new NullCacheMethod())
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// locale,
        /// custom user agent,
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
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/>, <paramref name="cacheMethod"/> or <paramref name="renderCacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, string userAgent, IHttpClient httpClient, ICacheMethod cacheMethod, ICacheMethod renderCacheMethod) :
            this(accessToken, locale, userAgent, httpClient, cacheMethod, renderCacheMethod, TimeSpan.Zero)
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key,
        /// locale,
        /// custom user agent,
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
        /// <exception cref="NullReferenceException"><paramref name="httpClient"/>, <paramref name="cacheMethod"/> or <paramref name="renderCacheMethod"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, string userAgent, IHttpClient httpClient, ICacheMethod cacheMethod, ICacheMethod renderCacheMethod, TimeSpan renderCacheDuration)
        {
            this.AccessToken = accessToken ?? string.Empty;
            this.Locale = locale;
            this.UserAgent = $"{userAgent}{(string.IsNullOrWhiteSpace(userAgent) ? " " : "")}" +
                $"Gw2Sharp/{typeof(Connection).GetTypeInfo().Assembly.GetName().Version.ToString(3)} (https://github.com/Archomeda/Gw2Sharp)";
            this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.CacheMethod = cacheMethod ?? throw new ArgumentNullException(nameof(cacheMethod));
            this.RenderCacheMethod = renderCacheMethod ?? throw new ArgumentNullException(nameof(renderCacheMethod));
            this.RenderCacheDuration = renderCacheDuration;

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
        public string AccessToken { get; set; }

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
        public IHttpClient HttpClient { get; set; }

        /// <inheritdoc />
        public ICacheMethod CacheMethod { get; set; }

        /// <inheritdoc />
        public TimeSpan RenderCacheDuration { get; set; } = TimeSpan.Zero;

        /// <inheritdoc />
        public ICacheMethod RenderCacheMethod { get; set; }


        /// <inheritdoc />
        public Task<IHttpResponse<TResponse>> RequestAsync<TResponse>(Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken) where TResponse : object
        {
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            return this.RequestInternalAsync<TResponse>(requestUri, additionalHeaders, cancellationToken);
        }

        private async Task<IHttpResponse<TResponse>> RequestInternalAsync<TResponse>(Uri requestUri, IEnumerable<KeyValuePair<string, string>>? additionalHeaders, CancellationToken cancellationToken) where TResponse : object
        {
            IDictionary<string, string> headers = this.requestHeaders;
            if (additionalHeaders != null)
            {
                headers = headers.ShallowCopy();
                headers.AddRange(additionalHeaders);
            }

            var request = new HttpRequest(requestUri, headers);

            try
            {
                var r = await this.HttpClient.RequestAsync(request, cancellationToken).ConfigureAwait(false);
                var obj = JsonConvert.DeserializeObject<TResponse>(r.Content, DeserializerSettings);
                return new HttpResponse<TResponse>(obj, r.StatusCode, r.RequestHeaders, r.ResponseHeaders);
            }
            catch (UnexpectedStatusException ex)
            {
                var error = new ErrorObject();
                try
                {
                    if (ex.Response != null)
                        error = JsonConvert.DeserializeObject<ErrorObject>(ex.Response.Content, DeserializerSettings);
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
