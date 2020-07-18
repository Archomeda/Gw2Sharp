using Gw2Sharp.WebApi.Http;

namespace Gw2Sharp.WebApi.Middleware
{
    /// <summary>
    /// A middleware context.
    /// </summary>
    public class MiddlewareContext
    {
        /// <summary>
        /// Constructs a new <see cref="MiddlewareContext"/>.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="request">The web API request.</param>
        public MiddlewareContext(IConnection connection, IWebApiRequest request)
        {
            this.Connection = connection;
            this.Request = request;
        }

        /// <summary>
        /// The connection.
        /// </summary>
        public IConnection Connection { get; }

        /// <summary>
        /// The web API request.
        /// </summary>
        public IWebApiRequest Request { get; }
    }
}
