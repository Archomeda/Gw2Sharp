using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 guild search by name endpoint.
    /// </summary>
    public interface IGuildSearchNameClient :
        IBlobClient<IReadOnlyList<Guid>>
   {
        /// <summary>
        /// The guild name.
        /// </summary>
        string Name { get; }
    }
}
