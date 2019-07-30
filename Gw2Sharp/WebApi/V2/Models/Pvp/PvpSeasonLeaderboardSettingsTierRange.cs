using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a PvP season leaderboard tier range.
    /// </summary>
    [JsonConverter(typeof(PvpSeasonLeaderboardSettingsTierRangeConverter))]
    public struct PvpSeasonLeaderboardSettingsTierRange : IEquatable<PvpSeasonLeaderboardSettingsTierRange>, IEnumerable<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PvpSeasonLeaderboardSettingsTierRange"/> struct.
        /// </summary>
        /// <param name="lowest">The lowest position.</param>
        /// <param name="highest">The highest position.</param>
        public PvpSeasonLeaderboardSettingsTierRange(double lowest, double highest)
        {
            this.Lowest = lowest;
            this.Highest = highest;
        }

        /// <summary>
        /// The lowest position in this tier range.
        /// </summary>
        public double Lowest { get; private set; }

        /// <summary>
        /// The highest position in this tier range.
        /// </summary>
        public double Highest { get; private set; }

        /// <inheritdoc />
        public IEnumerator<double> GetEnumerator()
        {
            yield return this.Lowest;
            yield return this.Highest;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        /// <inheritdoc />
        public override string ToString() =>
             $"({this.Lowest},{this.Highest})";

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is PvpSeasonLeaderboardSettingsTierRange other && this.Equals(other);

        /// <inheritdoc />
        public bool Equals(PvpSeasonLeaderboardSettingsTierRange other)
        {
            return this.Lowest.Equals(other.Lowest) &&
                this.Highest.Equals(other.Highest);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 689316674;
            hashCode = (hashCode * -1521134295) + this.Lowest.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.Highest.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first range.</param>
        /// <param name="right">The second range.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(PvpSeasonLeaderboardSettingsTierRange left, PvpSeasonLeaderboardSettingsTierRange right) =>
            left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first range.</param>
        /// <param name="right">The second range.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(PvpSeasonLeaderboardSettingsTierRange left, PvpSeasonLeaderboardSettingsTierRange right) =>
            !(left == right);
    }
}
