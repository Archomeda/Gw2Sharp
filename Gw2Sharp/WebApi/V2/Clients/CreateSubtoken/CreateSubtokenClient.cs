using System;
using System.Collections.Generic;
using System.Linq;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 createsubtoken endpoint.
    /// </summary>
    [EndpointPath("createsubtoken")]
    public class CreateSubtokenClient : BaseEndpointBlobClient<CreateSubtoken>, ICreateSubtokenClient
    {
        /// <summary>
        /// Creates a new <see cref="CreateSubtokenClient"/> that is used for the API v2 createsubtoken endpoint.
        /// </summary>
        /// <param name="connection">The connection used to make requests, see <see cref="IConnection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <c>null</c>.</exception>
        public CreateSubtokenClient(IConnection connection) :
            base(connection)
        { }

        /// <inheritdoc />
        [EndpointPathParameter("expire")]
        public string? ParamExpire { get; protected set; }

        /// <inheritdoc />
        [EndpointPathParameter("permissions")]
        public string? ParamPermissions { get; protected set; }

        /// <inheritdoc />
        [EndpointPathParameter("urls")]
        public string? ParamUrls { get; protected set; }

        /// <inheritdoc />
        public virtual ICreateSubtokenClient Expires(DateTime expire)
        {
            this.ParamExpire = expire.ToString("o");
            return this;
        }

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithPermissions(IEnumerable<string> permissions)
        {
            this.ParamPermissions = string.Join(",", permissions);
            return this;
        }

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithPermissions(IEnumerable<TokenPermission> permissions) =>
            this.WithPermissions(permissions.Select(x => x.ToString().ToLowerInvariant()));

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithUrls(IList<string> urls)
        {
            this.ParamUrls = string.Join(",", urls);
            return this;
        }
    }
}
