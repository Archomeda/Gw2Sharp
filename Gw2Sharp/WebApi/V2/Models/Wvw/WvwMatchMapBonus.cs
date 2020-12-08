using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a Wvw match map bonus.
    /// </summary>
    public class WvwMatchMapBonus : ApiV2BaseObject
    {
        /// <summary>
        /// The bonus type
        /// </summary>
        public ApiEnum<WvwBonus> Type { get; set; } = new ApiEnum<WvwBonus>();

        /// <summary>
        /// The bonus owner
        /// </summary>
        public ApiEnum<WvwOwner> Owner { get; set; } = new ApiEnum<WvwOwner>();

    }
}
