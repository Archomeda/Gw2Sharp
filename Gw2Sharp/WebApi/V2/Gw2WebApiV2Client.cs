using System;
using Gw2Sharp.WebApi.V2.Clients;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// A client for the Guild Wars 2 web API v2.
    /// </summary>
    public class Gw2WebApiV2Client : IGw2WebApiV2Client
    {
        /// <summary>
        /// The base URL for making Guild Wars 2 API v2 requests.
        /// </summary>
        public static readonly Uri UrlBase = new Uri(Gw2WebApiClient.UrlBase, "v2/");

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiV2Client"/>.
        /// </summary>
        public Gw2WebApiV2Client() : this(new Connection()) { } 

        /// <summary>
        /// Creates a new <see cref="Gw2WebApiV2Client"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        public Gw2WebApiV2Client(IConnection connection)
        {
            this.Connection = connection;
            this.Account = new AccountClient(connection);
            this.Achievements = new AchievementsClient(connection);
            this.Backstory = new BackstoryClient(connection);
            this.Build = new BuildClient(connection);
            this.Cats = new CatsClient(connection);
            this.Characters = new CharactersClient(connection);
            this.Colors = new ColorsClient(connection);
            this.Commerce = new CommerceClient(connection);
        }

        /// <inheritdoc />
        public IConnection Connection { get; private set; }

        /// <inheritdoc />
        public virtual IAccountClient Account { get; protected set; }

        /// <inheritdoc />
        public virtual IAchievementsClient Achievements { get; protected set; }

        /// <inheritdoc />
        public virtual IBackstoryClient Backstory { get; protected set; }

        /// <inheritdoc />
        public virtual IBuildClient Build { get; protected set; }

        /// <inheritdoc />
        public virtual ICatsClient Cats { get; protected set; }

        /// <inheritdoc />
        public virtual ICharactersClient Characters { get; protected set; }

        /// <inheritdoc />
        public virtual IColorsClient Colors { get; protected set; }

        /// <inheritdoc />
        public virtual ICommerceClient Commerce { get; protected set; }
    }
}
