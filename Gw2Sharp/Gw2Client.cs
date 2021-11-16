using System;
using System.Runtime.Versioning;
using DisposeGenerator;
using Gw2Sharp.Mumble;
using Gw2Sharp.WebApi;

namespace Gw2Sharp
{
    /// <summary>
    /// A client for the Guild Wars 2 web API.
    /// </summary>
    [DisposeAll]
    public partial class Gw2Client : IGw2Client
    {
        private IGw2MumbleClient? mumble;
        private readonly IGw2WebApiClient webApi;

        /// <summary>
        /// Creates a new <see cref="Gw2Client"/>.
        /// </summary>
        public Gw2Client() : this(new Connection()) { }

        /// <summary>
        /// Creates a new <see cref="Gw2Client"/>.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        public Gw2Client(IConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

#if NET5_0_OR_GREATER
            if (OperatingSystem.IsWindows())
                this.mumble = new Gw2MumbleClient();
#else
            this.mumble = new Gw2MumbleClient();
#endif
            this.webApi = new Gw2WebApiClient(connection, this);
        }

        /// <inheritdoc />
#if NET5_0_OR_GREATER
        [SupportedOSPlatform("windows")]
#endif
        public virtual IGw2MumbleClient Mumble =>
            this.mumble ?? throw new PlatformNotSupportedException("Mumble Link is only available on Windows platforms");

        /// <inheritdoc />
        public virtual IGw2WebApiClient WebApi => this.webApi;
    }
}
