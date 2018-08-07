namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a point of interest type
    /// </summary>
    public enum PoiType
    {
        /// <summary>
        /// An unknown point of interest type. Used as fallback.
        /// </summary>
        Unknown,

        /// <summary>
        /// A landmark.
        /// </summary>
        Landmark,

        /// <summary>
        /// A waypoint.
        /// </summary>
        Waypoint,

        /// <summary>
        /// A vista.
        /// </summary>
        Vista,

        /// <summary>
        /// An unlock.
        /// </summary>
        Unlock
    }
}
