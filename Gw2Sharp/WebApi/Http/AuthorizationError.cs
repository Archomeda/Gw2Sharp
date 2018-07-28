namespace Gw2Sharp.WebApi.Http
{
    /// <summary>
    /// Authorization errors.
    /// </summary>
    public enum AuthorizationError
    {
        /// <summary>
        /// No API key has been passed.
        /// </summary>
        RequiresAuthorization,

        /// <summary>
        /// The API key is invalid.
        /// </summary>
        InvalidKey,

        /// <summary>
        /// The API key is missing permissions in order to successfully complete the request.
        /// </summary>
        MissingScopes,

        /// <summary>
        /// The account of the API key is not a member of the guild.
        /// </summary>
        MembershipRequired,

        /// <summary>
        /// The guild endpoint is only accessible to guild leaders, and the account of the API key is not a guild leader.
        /// </summary>
        AccessRestrictedToGuildLeaders
    }
}
