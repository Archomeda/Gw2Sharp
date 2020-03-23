using System.Runtime.Serialization;

namespace Gw2Sharp.WebApi.V2.Models
{
    /// <summary>
    /// The skill slot.
    /// </summary>
    public enum SkillSlot
    {
        /// <summary>
        /// Unknown slot.
        /// </summary>
        Unknown,

        /// <summary>
        /// First weapon slot.
        /// </summary>
        [EnumMember(Value = "Weapon_1")]
        Weapon1,

        /// <summary>
        /// Second weapon slot.
        /// </summary>
        [EnumMember(Value = "Weapon_2")]
        Weapon2,

        /// <summary>
        /// Third weapon slot.
        /// </summary>
        [EnumMember(Value = "Weapon_3")]
        Weapon3,

        /// <summary>
        /// Fourth weapon slot.
        /// </summary>
        [EnumMember(Value = "Weapon_4")]
        Weapon4,

        /// <summary>
        /// Fifth weapon slot.
        /// </summary>
        [EnumMember(Value = "Weapon_5")]
        Weapon5,

        /// <summary>
        /// First profession slot.
        /// </summary>
        [EnumMember(Value = "Profession_1")]
        Profession1,

        /// <summary>
        /// Second profession slot.
        /// </summary>
        [EnumMember(Value = "Profession_2")]
        Profession2,

        /// <summary>
        /// Third profession slot.
        /// </summary>
        [EnumMember(Value = "Profession_3")]
        Profession3,

        /// <summary>
        /// Fourth profession slot.
        /// </summary>
        [EnumMember(Value = "Profession_4")]
        Profession4,

        /// <summary>
        /// Fifth profession slot.
        /// </summary>
        [EnumMember(Value = "Profession_5")]
        Profession5,

        /// <summary>
        /// Heal slot.
        /// </summary>
        Heal,

        /// <summary>
        /// Utility slot.
        /// </summary>
        Utility,

        /// <summary>
        /// Elite slot.
        /// </summary>
        Elite,

        /// <summary>
        /// First downed slot.
        /// </summary>
        [EnumMember(Value = "Downed_1")]
        Downed1,

        /// <summary>
        /// Second downed slot.
        /// </summary>
        [EnumMember(Value = "Downed_2")]
        Downed2,

        /// <summary>
        /// Third downed slot.
        /// </summary>
        [EnumMember(Value = "Downed_3")]
        Downed3,

        /// <summary>
        /// Fourth downed slot.
        /// </summary>
        [EnumMember(Value = "Downed_4")]
        Downed4,

        /// <summary>
        /// Pet slot.
        /// </summary>
        Pet
    }
}
