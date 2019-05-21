using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
        /// Creates a new <see cref="Connection"/> without an API key, English locale and default HTTP client and caching method.
        /// </summary>
        public Connection() : this(string.Empty, Locale.English) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key and the default English locale.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <exception cref="NullReferenceException"><paramref name="accessToken"/> is <c>null</c>.</exception>
        public Connection(string accessToken) : this(accessToken, Locale.English) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified locale.
        /// </summary>
        /// <param name="locale">The locale.</param>
        public Connection(Locale locale) : this(string.Empty, locale) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/> with a specified API key and locale.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <exception cref="NullReferenceException"><paramref name="accessToken"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale) : this(accessToken, locale, new HttpClient(), new MemoryCacheMethod()) { }

        /// <summary>
        /// Creates a new <see cref="Connection"/>.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <exception cref="NullReferenceException"><paramref name="accessToken"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, IHttpClient httpClient, ICacheMethod cacheMethod) :
            this(accessToken, locale, string.Empty, httpClient, cacheMethod)
        { }

        /// <summary>
        /// Creates a new <see cref="Connection"/>.
        /// </summary>
        /// <param name="accessToken">The API key.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="userAgent">The User-Agent.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="cacheMethod">The cache method.</param>
        /// <exception cref="NullReferenceException"><paramref name="accessToken"/> or <paramref name="userAgent"/> is <c>null</c>.</exception>
        public Connection(string accessToken, Locale locale, string userAgent, IHttpClient httpClient, ICacheMethod cacheMethod)
        {
            if (userAgent == null)
                throw new ArgumentNullException(nameof(userAgent));

            this.AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            this.Locale = locale;
            this.UserAgent = $"{userAgent}{(string.IsNullOrWhiteSpace(userAgent) ? " " : "")}" +
                $"Gw2Sharp/{typeof(Connection).GetTypeInfo().Assembly.GetName().Version.ToString(3)} (https://github.com/Archomeda/Gw2Sharp)";
            this.HttpClient = httpClient;
            this.CacheMethod = cacheMethod;

            this.requestHeaders = new Dictionary<string, string>()
            {
                { "Accept", "application/json" },
                { "Accept-Language", this.LocaleString },
            };
            if (!string.IsNullOrWhiteSpace(this.AccessToken))
                this.requestHeaders.Add("Authorization", $"Bearer {this.AccessToken}");
            if (!string.IsNullOrWhiteSpace(this.UserAgent))
                this.requestHeaders.Add("User-Agent", this.UserAgent);
        }

        /// <inheritdoc />
        public string AccessToken { get; private set; }

        /// <inheritdoc />
        public Locale Locale { get; private set; }

        /// <inheritdoc />
        public string LocaleString
        {
            get
            {
                switch (this.Locale)
                {
                    case Locale.German:
                        return "de";
                    case Locale.French:
                        return "fr";
                    case Locale.Spanish:
                        return "es";
                    case Locale.Korean:
                        return "ko";
                    case Locale.Chinese:
                        return "zh";
                    case Locale.English:
                    default:
                        return "en";
                }
            }
        }

        /// <inheritdoc />
        public string UserAgent { get; private set; }

        /// <inheritdoc />
        public IHttpClient HttpClient { get; private set; }

        /// <inheritdoc />
        public ICacheMethod CacheMethod { get; private set; }


        /// <inheritdoc />
        public async Task<IHttpResponse<TResponse>> RequestAsync<TResponse>(Uri requestUri, CancellationToken cancellationToken) where TResponse : object
        {
            if (requestUri == null)
                throw new ArgumentNullException(nameof(requestUri));

            var request = new HttpRequest(requestUri, this.requestHeaders);

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
                catch (JsonSerializationException)
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
