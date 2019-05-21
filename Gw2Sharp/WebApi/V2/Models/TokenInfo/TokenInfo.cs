namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a token info.
    /// </summary>
    public class TokenInfo
    {
        /// <summary>
        /// The token id.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The token name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The token permissions.
        /// </summary>
        public ApiFlags<TokenPermission> Permissions { get; set; } = new ApiFlags<TokenPermission>();
    }
}
