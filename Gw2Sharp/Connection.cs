using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http.Headers;
using Gw2Sharp.Mumble;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;
using static Gw2Sharp.Mumble.IGw2MumbleClientReader;

namespace Gw2Sharp
{
    /// <summary>
    /// A web API connection.
    /// </summary>
    public class Connection : IConnection
    {
        private IHttpClient httpClient;
        private ICacheMethod cacheMethod;
        private ICacheMethod renderCacheMethod;
        private string accessToken;
        private string apiBaseUrl = "https://api.guildwars2.com/";
        private readonly ObservableCollection<IWebApiMiddleware> middleware = new ObservableCollection<IWebApiMiddleware>();


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
        /// <exception cref="ArgumentException"><paramref name="accessToken"/> is incorrectly formatted.</exception>
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
        /// <exception cref="ArgumentException"><paramref name="accessToken"/> is incorrectly formatted.</exception>
        public Connection(
            string? accessToken,
            Locale locale,
            ICacheMethod? cacheMethod = null,
            ICacheMethod? renderCacheMethod = null,
            TimeSpan? renderCacheDuration = null,
            string? userAgent = null,
            IHttpClient? httpClient = null)
        {
            if (!string.IsNullOrWhiteSpace(accessToken) && !IsAccessTokenValid(accessToken))
                throw new ArgumentException("The access token is incorrectly formatted", nameof(accessToken));

            this.accessToken = accessToken ?? string.Empty;
            this.Locale = locale;
            string userAgentProduct = "Gw2Sharp";
            try
            {
                string? fileVersion = FileVersionInfo.GetVersionInfo(typeof(Gw2Client).Assembly.Location).FileVersion;
                if (!string.IsNullOrWhiteSpace(fileVersion))
                    userAgentProduct = $"Gw2Sharp/{new Version(fileVersion).ToString(3)}";
            }
            catch { /* Ignore */ }
            this.UserAgent = $"{userAgent}{(!string.IsNullOrWhiteSpace(userAgent) ? " " : "")}" +
                $"{userAgentProduct} (https://github.com/Archomeda/Gw2Sharp)";
            this.httpClient = httpClient ?? new HttpClient();
            this.cacheMethod = cacheMethod ?? new MemoryCacheMethod();
            this.renderCacheMethod = renderCacheMethod ?? new NullCacheMethod();
            this.RenderCacheDuration = renderCacheDuration ?? TimeSpan.Zero;

            this.middleware.CollectionChanged += this.Middleware_CollectionChanged;
            this.UseDefaultMiddleware();

#if NET5_0_OR_GREATER
            if (OperatingSystem.IsWindows())
#else
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
#endif
            {
#pragma warning disable CA1416 // We can't get a different platform than Windows here, but the analyzer doesn't understand this
                this.MumbleClientReaderFactory = x => new Gw2MumbleClientReader(x);
#pragma warning restore CA1416
            }
            else
            {
                this.MumbleClientReaderFactory = _ => new UnsupportedMumblePlatformClientReader();
            }
        }


        /// <inheritdoc />
        public string AccessToken
        {
            get => this.accessToken;
            set
            {
                if (!IsAccessTokenValid(value))
                    throw new ArgumentException("The access token is incorrectly formatted", nameof(value));
                this.accessToken = value ?? string.Empty;
            }
        }

        /// <inheritdoc />
        public Locale Locale { get; set; }

        /// <inheritdoc />
        public string LocaleString => this.Locale switch
        {
            Locale.German => "de",
            Locale.French => "fr",
            Locale.Spanish => "es",
            Locale.Korean => "ko",
            Locale.Chinese => "zh",
            _ => "en"
        };

        /// <inheritdoc />
        public string UserAgent { get; }

        /// <inheritdoc />
        public bool UseSimpleRequests { get; set; }

        /// <inheritdoc />
        public string ApiBaseUrl
        {
            get => this.apiBaseUrl;
            set => this.apiBaseUrl = value ?? throw new ArgumentNullException(nameof(value), "ApiBaseUrl cannot be null");
        }

        /// <inheritdoc />
        public string? RenderBaseUrl { get; set; }

        /// <inheritdoc />
        public TimeSpan RequestTimeout
        {
            get => this.HttpClient.Timeout;
            set => this.HttpClient.Timeout = value;
        }

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
        public IList<IWebApiMiddleware> Middleware => this.middleware;

        /// <inheritdoc />
        public int MiddlewareHashCode { get; protected set; }

        /// <inheritdoc />
        public Gw2MumbleLinkReaderFactory MumbleClientReaderFactory { get; set; }


        /// <summary>
        /// Resets this connection's middleware to the default list.
        /// </summary>
        public void UseDefaultMiddleware()
        {
            this.Middleware.Clear();
            this.Middleware.Add(new CacheMiddleware());
            this.Middleware.Add(new RequestSplitterMiddleware());
            this.Middleware.Add(new ExceptionMiddleware());
        }

        private void Middleware_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var hashCode = new HashCode();
            foreach (var middleware in this.Middleware)
                hashCode.Add(middleware);
            this.MiddlewareHashCode = hashCode.ToHashCode();
        }

        private static bool IsAccessTokenValid(string accessToken) =>
            AuthenticationHeaderValue.TryParse($"Bearer {accessToken}", out _);
    }
}
