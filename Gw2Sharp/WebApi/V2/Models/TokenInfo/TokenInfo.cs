namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a token info.
    /// The token info can be <see cref="ApiTokenInfo"/> or <see cref="SubTokenInfo"/>.
    /// </summary>
    [CastableType(TokenType.APIKey, typeof(ApiTokenInfo))]
    [CastableType(TokenType.Subtoken, typeof(SubTokenInfo))]
    public class TokenInfo : ApiV2BaseObject, ICastableType<TokenInfo, TokenType>
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

        /// <summary>
        /// The token type.
        /// </summary>
        public ApiEnum<TokenType> Type { get; set; } = new ApiEnum<TokenType>();
    }
}
