using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Gw2Sharp.DependencyInjection.Microsoft
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/> to support dependency injection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Gw2Sharp as a singleton factory service with default configuration.
        /// The factory service <see cref="IGw2ClientFactory"/> can be used to construct a new <see cref="IGw2Client"/> via
        /// <see cref="IGw2ClientFactory.CreateClient()"/> or <see cref="IGw2ClientFactory.CreateClient(Action{Connection})"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2SharpFactory(this IServiceCollection services) =>
            AddGw2SharpFactory(services, (_, _) => { });

        /// <summary>
        /// Adds Gw2Sharp as a singleton factory service with customized <see cref="IConnection"/> defaults.
        /// The factory service <see cref="IGw2ClientFactory"/> can be used to construct a new <see cref="IGw2Client"/> via
        /// <see cref="IGw2ClientFactory.CreateClient()"/> or <see cref="IGw2ClientFactory.CreateClient(Action{Connection})"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureDefaults">The action for configuring the <see cref="IConnection"/> defaults.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2SharpFactory(this IServiceCollection services, Action<Gw2ClientFactoryDefaults> configureDefaults) =>
            AddGw2SharpFactory(services, (_, c) => configureDefaults(c));

        /// <summary>
        /// Adds Gw2Sharp as a singleton factory service with customized <see cref="IConnection"/> defaults.
        /// The factory service <see cref="IGw2ClientFactory"/> can be used to construct a new <see cref="IGw2Client"/> via
        /// <see cref="IGw2ClientFactory.CreateClient()"/> or <see cref="IGw2ClientFactory.CreateClient(Action{Connection})"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureDefaults">The action for configuring the <see cref="IConnection"/> defaults.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2SharpFactory(this IServiceCollection services, Action<IServiceProvider, Gw2ClientFactoryDefaults> configureDefaults)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));
            if (configureDefaults is null)
                throw new ArgumentNullException(nameof(configureDefaults));

            services.AddHttpClient();

            services.AddSingleton(s =>
            {
                var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();

                var defaults = new Gw2ClientFactoryDefaults(httpClientFactory);
                configureDefaults(s, defaults);

                return defaults;
            });

            services.AddSingleton<IGw2ClientFactory>(s =>
            {
                var defaults = s.GetRequiredService<Gw2ClientFactoryDefaults>();

                return new Gw2ClientFactory(defaults);
            });

            return services;
        }

        /// <summary>
        /// Adds Gw2Sharp as a singleton service with default configuration.
        /// An instance of <see cref="IGw2Client"/> is added as a singleton service that can be used throughout the entire application lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2Sharp(this IServiceCollection services) =>
            AddGw2Sharp(services, (_, _) => { });

        /// <summary>
        /// Adds Gw2Sharp as a singleton service with default configuration.
        /// An instance of <see cref="IGw2Client"/> is added as a singleton service that can be used throughout the entire application lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configure">The action to configure the <see cref="Connection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2Sharp(this IServiceCollection services, Action<Connection> configure) =>
            AddGw2Sharp(services, (_, c) => configure(c));

        /// <summary>
        /// Adds Gw2Sharp as a singleton service with default configuration.
        /// An instance of <see cref="IGw2Client"/> is added as a singleton service that can be used throughout the entire application lifetime.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configure">The action to configure the <see cref="Connection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> for method chaining.</returns>
        public static IServiceCollection AddGw2Sharp(this IServiceCollection services, Action<IServiceProvider, Connection> configure)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));
            if (configure is null)
                throw new ArgumentNullException(nameof(configure));

            services.AddHttpClient();

            services.AddSingleton<IConnection>(s =>
            {
                var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();

                var connection = new Connection
                {
                    HttpClient = new WebApi.Http.HttpClient(httpClientFactory.CreateClient)
                };
                configure(s, connection);

                return connection;
            });

            services.AddSingleton<IGw2Client, Gw2Client>(s =>
                new Gw2Client(s.GetRequiredService<IConnection>()));

            return services;
        }
    }
}
