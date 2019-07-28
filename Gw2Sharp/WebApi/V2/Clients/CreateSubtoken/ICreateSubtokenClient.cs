using System;
using System.Collections.Generic;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 createsubtoken endpoint.
    /// </summary>
    public interface ICreateSubtokenClient :
        IAuthenticatedClient<CreateSubtoken>,
        IBlobClient<CreateSubtoken>
    {
        /// <summary>
        /// The parameter for the subtoken expire date.
        /// </summary>
        string? ParamExpire { get; }

        /// <summary>
        /// The parameter for the subtoken permissions.
        /// </summary>
        string? ParamPermissions { get; }

        /// <summary>
        /// The parameter for the subtoken URLs.
        /// </summary>
        string? ParamUrls { get; }

        /// <summary>
        /// Sets the subtoken expire date.
        /// </summary>
        /// <param name="expire">The expire date.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        ICreateSubtokenClient Expires(DateTimeOffset expire);

        /// <summary>
        /// Sets the subtoken permissions.
        /// </summary>
        /// <param name="permissions">The list of permissions.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        ICreateSubtokenClient WithPermissions(IEnumerable<string> permissions);

        /// <summary>
        /// Sets the subtoken permissions.
        /// </summary>
        /// <param name="permissions">The list of permissions.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        ICreateSubtokenClient WithPermissions(IEnumerable<TokenPermission> permissions);

        /// <summary>
        /// Sets the subtoken URLs.
        /// </summary>
        /// <param name="urls">The URLs.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        ICreateSubtokenClient WithUrls(IList<string> urls);
    }
}
