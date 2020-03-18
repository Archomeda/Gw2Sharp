using System.Text.Json.Serialization;

namespace Gw2Sharp.WebApi.V2
{
    /// <summary>
    /// An interface for implementing an API v2 object.
    /// </summary>
    public interface IApiV2Object
    {
        /// <summary>
        /// Gets or sets the associated HTTP response information.
        /// When the request info isn't available, this value is <c>null</c>.
        /// </summary>
        [JsonIgnore]
        ApiV2HttpResponseInfo? HttpResponseInfo { get; set; }
    }
}
