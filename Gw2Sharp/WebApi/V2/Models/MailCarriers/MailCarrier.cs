using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mailcarrier.
    /// </summary>
    public class MailCarrier : ApiV2BaseObject, IIdentifiable<int>
    {
        /// <summary>
        /// The mailcarrier id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The items that unlock this mailcarrier.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Items"/>.
        /// </summary>
        public IReadOnlyList<int> UnlockItems { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The mailcarrier order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The mailcarrier icon.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The mailcarrier name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The mailcarrier flags.
        /// </summary>
        public ApiFlags<MailCarrierFlag> Flags { get; set; } = new ApiFlags<MailCarrierFlag>();
    }
}
