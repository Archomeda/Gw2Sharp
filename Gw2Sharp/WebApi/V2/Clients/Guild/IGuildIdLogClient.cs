using System;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild id log endpoint.
    /// </summary>
    public interface IGuildIdLogClient :
        IAuthenticatedClient<IApiV2ObjectList<GuildLog>>,
        IBlobClient<IApiV2ObjectList<GuildLog>>
    {
        /// <summary>
        /// The guild id.
        /// </summary>
        Guid GuildId { get; }

        /// <summary>
        /// The parameter for requesting logs with an id higher than the given id.
        /// Use <c>null</c> to unset the parameter.
        /// </summary>
        int? ParamSince { get; }

        /// <summary>
        /// Sets the parameter for requesting logs with an id higher than the given id.
        /// </summary>
        /// <param name="since">The id. Use null to unset the parameter.</param>
        /// <returns><c>this</c> to allow method chaining.</returns>
        IGuildIdLogClient Since(int? since);
    }
}
