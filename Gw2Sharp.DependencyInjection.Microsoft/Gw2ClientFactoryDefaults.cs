using System;
using System.Collections.Generic;
using System.Net.Http;
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.Caching;
using Gw2Sharp.WebApi.Http;
using Gw2Sharp.WebApi.Middleware;

namespace Gw2Sharp.DependencyInjection.Microsoft
{
    /// <summary>
    /// Factory defaults for the <see cref="IConnection"/> that is used in <see cref="IGw2Client"/>.
    /// </summary>
    public class Gw2ClientFactoryDefaults
    {
        /// <summary>
        /// Creates a new instance of <see cref="Gw2ClientFactoryDefaults"/>.
        /// </summary>
        /// <param name="httpClientFactory">The <see cref="IHttpClientFactory"/> for creating new instances of <see cref="System.Net.Http.HttpClient"/>.</param>
        public Gw2ClientFactoryDefaults(IHttpClientFactory httpClientFactory)
        {
            // Copy defaults from a new Connection, so that we don't have to hardcode this
            var connection = new Connection();
            this.AccessToken = connection.AccessToken;
            this.Locale = connection.Locale;
            this.UserAgent = connection.UserAgent;
            this.CacheMethod = connection.CacheMethod;
            this.RenderCacheDuration = connection.RenderCacheDuration;
            this.RenderCacheMethod = connection.RenderCacheMethod;
            this.Middleware = connection.Middleware;

            // Except for the HttpClient, to support better disposals
            this.HttpClient = new WebApi.Http.HttpClient(httpClientFactory.CreateClient);
        }

        /// <summary>
        /// The default access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The default locale.
        /// </summary>
        public Locale Locale { get; set; }

        /// <summary>
        /// The default user agent.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The default http client.
        /// </summary>
        public IHttpClient HttpClient { get; set; }

        /// <summary>
        /// The default cache method.
        /// </summary>
        public ICacheMethod CacheMethod { get; set; }

        /// <summary>
        /// The default render cache duration.
        /// </summary>
        public TimeSpan RenderCacheDuration { get; set; }

        /// <summary>
        /// The default render cache method.
        /// </summary>
        public ICacheMethod RenderCacheMethod { get; set; }

        /// <summary>
        /// The default middleware.
        /// </summary>
        public IList<IWebApiMiddleware> Middleware { get; set; }
    }
}
