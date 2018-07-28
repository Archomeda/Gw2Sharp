namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an account currency.
    /// </summary>
    public class AccountCurrency : IIdentifiable<int>
    {
        /// <summary>
        /// The currency id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Currencies"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The amount of this currency.
        /// </summary>
        public int Value { get; set; }
    }
}
