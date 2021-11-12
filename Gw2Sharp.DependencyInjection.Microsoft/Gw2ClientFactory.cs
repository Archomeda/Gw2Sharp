using System;

namespace Gw2Sharp.DependencyInjection.Microsoft
{
    internal class Gw2ClientFactory : IGw2ClientFactory
    {
        private readonly Gw2ClientFactoryDefaults factoryDefaults;

        public Gw2ClientFactory(Gw2ClientFactoryDefaults factoryDefaults)
        {
            this.factoryDefaults = factoryDefaults;
        }

        public IGw2Client CreateClient() =>
            this.CreateClient(_ => { });

        public IGw2Client CreateClient(Action<Connection> configureConnection)
        {
            var connection = this.CreateConnection();
            configureConnection(connection);
            return new Gw2Client(connection);
        }

        private Connection CreateConnection()
        {
            var connection = new Connection(
                this.factoryDefaults.AccessToken,
                this.factoryDefaults.Locale,
                this.factoryDefaults.CacheMethod,
                this.factoryDefaults.RenderCacheMethod,
                this.factoryDefaults.RenderCacheDuration,
                this.factoryDefaults.UserAgent,
                this.factoryDefaults.HttpClient);

            connection.Middleware.Clear();
            foreach (var middleware in this.factoryDefaults.Middleware)
                connection.Middleware.Add(middleware);

            return connection;
        }
    }
}
