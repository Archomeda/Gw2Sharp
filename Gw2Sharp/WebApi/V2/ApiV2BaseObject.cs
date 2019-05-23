using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// Represents a base API v2 object.
    /// </summary>
    public class ApiV2BaseObject : IApiV2Object
    {
        /// <inheritdoc />
        [JsonIgnore]
        public ApiV2HttpResponseInfo? HttpResponseInfo { get; set; }
    }
}
