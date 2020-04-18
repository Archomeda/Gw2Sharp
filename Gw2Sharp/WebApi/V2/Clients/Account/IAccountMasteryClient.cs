namespace Gw2Sharp.WebApi.V2.Clients
{
    /// <summary>
    /// A client of the Guild Wars 2 API v2 account mastery endpoint.
    /// </summary>
    public interface IAccountMasteryClient
    {
        /// <summary>
        /// Gets detailed information about the unlocked mastery points.
        /// Requires scopes: account, progression.
        /// </summary>
        IAccountMasteryPointsClient Points { get; }
    }
}
