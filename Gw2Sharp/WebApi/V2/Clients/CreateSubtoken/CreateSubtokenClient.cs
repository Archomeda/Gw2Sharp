using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// <param name="gw2Client">The Guild Wars 2 client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null"/>.</exception>
        protected internal CreateSubtokenClient(IConnection connection, IGw2Client gw2Client) :
            base(connection, gw2Client)
        { }

        /// <summary>
        /// Clones a <see cref="CreateSubtokenClient"/> instance.
        /// </summary>
        /// <param name="client">The original client.</param>
        private CreateSubtokenClient(CreateSubtokenClient client)
            : this(client.Connection, client.Gw2Client!)
        {
            this.ParamExpire = client.ParamExpire;
            this.ParamPermissions = client.ParamPermissions;
            this.ParamUrls = client.ParamUrls;
        }


        /// <inheritdoc />
        [EndpointQueryParameter("expire")]
        public string? ParamExpire { get; protected set; }

        /// <inheritdoc />
        [EndpointQueryParameter("permissions")]
        public string? ParamPermissions { get; protected set; }

        /// <inheritdoc />
        [EndpointQueryParameter("urls")]
        public string? ParamUrls { get; protected set; }

        /// <inheritdoc />
        public virtual ICreateSubtokenClient Expires(DateTimeOffset expire) =>
            new CreateSubtokenClient(this) { ParamExpire = expire.ToString("o", CultureInfo.InvariantCulture) };

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithPermissions(IEnumerable<string> permissions) =>
            new CreateSubtokenClient(this) { ParamPermissions = string.Join(",", permissions) };

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithPermissions(IEnumerable<TokenPermission> permissions) =>
            this.WithPermissions(permissions.Select(x => x.ToString().ToLowerInvariant()));

        /// <inheritdoc />
        public virtual ICreateSubtokenClient WithUrls(IList<string> urls) =>
            new CreateSubtokenClient(this) { ParamUrls = string.Join(",", urls) };
    }
}
