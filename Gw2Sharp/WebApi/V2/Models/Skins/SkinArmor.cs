namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents an armor skin.
    /// </summary>
    public class SkinArmor : Skin
    {
        /// <summary>
        /// The armor details.
        /// </summary>
        public SkinArmorDetails Details { get; set; } = new SkinArmorDetails();
    }
}
