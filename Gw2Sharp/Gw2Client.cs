using System;
using Gw2Sharp.Mumble;
using Gw2Sharp.WebApi;

namespace Gw2Sharp
{
    /// <summary>
    /// A client for the Guild Wars 2 web API.
    /// </summary>
    public class Gw2Client : IGw2Client
    {
        private readonly IGw2MumbleClient mumble;
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

            this.mumble = new Gw2MumbleClient(connection.MumbleClientReaderFactory);
            this.webApi = new Gw2WebApiClient(connection, this);
        }

        /// <inheritdoc />
        public virtual IGw2MumbleClient Mumble => this.mumble;

        /// <inheritdoc />
        public virtual IGw2WebApiClient WebApi => this.webApi;

        #region IDisposable Support

        private bool isDisposed = false; // To detect redundant calls

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
                return;

            if (disposing)
            {
                this.mumble?.Dispose();
            }

            this.isDisposed = true;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
