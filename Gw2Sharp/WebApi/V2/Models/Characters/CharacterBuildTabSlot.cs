namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a character build tab slot.
    /// </summary>
    public class CharacterBuildTabSlot : ApiV2BaseObject, IIdentifiable<int>
    {
#pragma warning disable CA1033 // Interface methods should be callable by child types
        int IIdentifiable<int>.Id
        {
            get => this.Tab;
            set => this.Tab = value;
        }
#pragma warning restore CA1033 // Interface methods should be callable by child types

        /// <summary>
        /// The build tab slot id.
        /// </summary>
        public int Tab { get; set; }

        /// <summary>
        /// Whether this build tab slot is current active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The build.
        /// </summary>
        public BuildTemplate Build { get; set; } = new BuildTemplate();
    }
}
