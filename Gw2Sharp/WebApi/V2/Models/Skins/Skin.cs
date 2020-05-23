namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// Represents a skin.
    /// The skin can be <see cref="SkinArmor"/>,
    /// <see cref="SkinBack"/>,
    /// <see cref="SkinGathering"/>,
    /// <see cref="SkinWeapon"/>
    /// </summary>
    [CastableType(SkinType.Armor, typeof(SkinArmor))]
    [CastableType(SkinType.Back, typeof(SkinBack))]
    [CastableType(SkinType.Gathering, typeof(SkinGathering))]
    [CastableType(SkinType.Weapon, typeof(SkinWeapon))]
    public class Skin : ApiV2BaseObject, IIdentifiable<int>, ICastableType<Skin, SkinType>
    {
        /// <summary>
        /// The skin id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The skin name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The skin type.
        /// </summary>
        public ApiEnum<SkinType> Type { get; set; } = new ApiEnum<SkinType>();

        /// <summary>
        /// The skin flags.
        /// </summary>
        public ApiFlags<SkinFlag> Flags { get; set; } = new ApiFlags<SkinFlag>();

        /// <summary>
        /// The skin restrictions.
        /// </summary>
        public ApiFlags<SkinRestriction> Restrictions { get; set; } = new ApiFlags<SkinRestriction>();

        /// <summary>
        /// The skin icon URL.
        /// </summary>
        public RenderUrl Icon { get; set; }

        /// <summary>
        /// The skin description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The skin rarity.
        /// </summary>
        public ApiEnum<ItemRarity> Rarity { get; set; } = new ApiEnum<ItemRarity>();
    }
}
