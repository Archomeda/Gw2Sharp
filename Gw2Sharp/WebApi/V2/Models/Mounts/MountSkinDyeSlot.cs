namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a mount skin dye slot.
    /// </summary>
    public class MountSkinDyeSlot
    {
        /// <summary>
        /// The dye color id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        public int ColorId { get; set; }

        /// <summary>
        /// The dye material.
        /// </summary>
        public string Material { get; set; } = string.Empty;
    }
}
