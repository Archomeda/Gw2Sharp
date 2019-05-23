using System;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a current commerce transaction.
    /// </summary>
    public class CommerceTransactionCurrent : ApiV2BaseObject, IIdentifiable<long>
    {
        /// <summary>
        /// The transaction id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The item id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// The price in coins.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// The amount of items.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The date the transaction was created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
