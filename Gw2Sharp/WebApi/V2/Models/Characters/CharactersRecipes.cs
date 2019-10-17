using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents the response from the characters recipes endpoint.
    /// </summary>
    public class CharactersRecipes : ApiV2BaseObject
    {
        /// <summary>
        /// The list of character recipes.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Recipes"/>.
        /// </summary>
        public IReadOnlyList<int> Recipes { get; set; } = Array.Empty<int>();
    }
}
