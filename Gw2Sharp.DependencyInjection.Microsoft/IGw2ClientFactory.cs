using System;

namespace Gw2Sharp.DependencyInjection.Microsoft
{
    /// <summary>
    /// A Gw2Sharp factory to create new clients.
    /// </summary>
    public interface IGw2ClientFactory
    {
        /// <summary>
        /// Creates a new <see cref="IGw2Client"/> with factory defaults.
        /// </summary>
        /// <returns>The <see cref="IGw2Client"/>.</returns>
        IGw2Client CreateClient();

        /// <summary>
        /// Creates a new <see cref="IGw2Client"/> with factory defaults that can be configured if necessary.
        /// </summary>
        /// <param name="configureConnection">The action for configuring the <see cref="Connection"/>.</param>
        /// <returns>The <see cref="IGw2Client"/>.</returns>
        IGw2Client CreateClient(Action<Connection> configureConnection);
    }
}
