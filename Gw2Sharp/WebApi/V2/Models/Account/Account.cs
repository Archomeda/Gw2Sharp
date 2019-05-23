using System;
using System.Collections.Generic;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents generic account data.
    /// Requires scope: account.
    /// </summary>
    public class Account : ApiV2BaseObject
    {
        /// <summary>
        /// The account id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The account name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Total play time of the account.
        /// </summary>
        public TimeSpan Age { get; set; }

        /// <summary>
        /// The world that's associated with the account.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Worlds"/>.
        /// </summary>
        public int World { get; set; }

        /// <summary>
        /// The list of guilds that this account is a member of.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Guild"/>.
        /// </summary>
        public IReadOnlyList<Guid> Guilds { get; set; } = new List<Guid>();

        /// <summary>
        /// The list of guilds that this account is a leader of.
        /// Each element can be resolved against <see cref="IGw2WebApiV2Client.Guild"/>.
        /// </summary>
        public IReadOnlyList<Guid> GuildLeader { get; set; } = new List<Guid>();

        /// <summary>
        /// The last modification date for this data.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// The account creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The content flags that this account has access to.
        /// </summary>
        public ApiFlags<GameAccess> Access { get; set; } = new ApiFlags<GameAccess>();

        /// <summary>
        /// Whether this account has a commander tag unlocked or not.
        /// </summary>
        public bool Commander { get; set; }

        /// <summary>
        /// The maximum fractal level for this account.
        /// Additionally requires scopes: progression.
        /// </summary>
        public int? FractalLevel { get; set; }

        /// <summary>
        /// The total amount of daily achievement points earned by this account.
        /// Additionally requires scopes: progression.
        /// </summary>
        public int? DailyAp { get; set; }

        /// <summary>
        /// The total amount of monthly achievement points earned by this account.
        /// Additionally requires scopes: progression.
        /// </summary>
        public int? MonthlyAp { get; set; }

        /// <summary>
        /// The WvW rank for this account.
        /// Additionally requires scopes: progression.
        /// </summary>
        public int? WvwRank { get; set; }
    }
}
