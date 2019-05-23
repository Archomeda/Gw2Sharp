using System;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search by name endpoint.
    /// </summary>
    public interface IGuildSearchNameClient :
        IBlobClient<IApiV2ObjectList<Guid>>
    {
        /// <summary>
        /// The guild name.
        /// </summary>
        string Name { get; }
    }
}
