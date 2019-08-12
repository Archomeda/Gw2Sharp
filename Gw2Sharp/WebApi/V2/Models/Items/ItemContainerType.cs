namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The item container type.
    /// </summary>
    public enum ItemContainerType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Default type.
        /// </summary>
        Default,

        /// <summary>
        /// A gift type.
        /// </summary>
        GiftBox,

        /// <summary>
        /// A type that opens a custom UI.
        /// </summary>
        OpenUI,

        /// <summary>
        /// A type that's immediate.
        /// </summary>
        Immediate
    }
}
