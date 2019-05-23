using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// Represents a base API v2 object list.
    /// </summary>
    public class ApiV2BaseObjectList<T> : List<T>, IApiV2ObjectList<T>
    {
        /// <inheritdoc />
        [JsonIgnore]
        public ApiV2HttpResponseInfo? HttpResponseInfo { get; set; }
    }
}
