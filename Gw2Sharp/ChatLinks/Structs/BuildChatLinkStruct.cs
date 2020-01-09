using System.Runtime.InteropServices;
using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks.Structs
{
    /// <summary>
    /// Represents a Guild Wars 2 build chat link.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct BuildChatLinkStruct
    {
        /// <summary>
        /// The profession id.
        /// Matches <see cref="WebApi.V2.Models.Profession.Code"/> in <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        [FieldOffset(0)]
        public Profession Profession;

        /// <summary>
        /// The first specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        [FieldOffset(1)]
        public byte Specialization1Id;

        /// <summary>
        /// The first specialization trait indices in little endian format.
        /// </summary>
        /// <remarks>
        /// There are 3 trait indices, and each trait index consumes 2 bits and is 0-indexed.
        /// There is a 2 bit padding at the end to fill 1 byte.
        /// <para>
        /// The following values are possible:
        /// 0 = no trait selected.
        /// 1 = top trait selected (matches trait index 0, 3, 6 on <see cref="Specialization.MajorTraits"/>).
        /// 2 = middle trait selected (matches trait index 1, 4, 7 on <see cref="Specialization.MajorTraits"/>).
        /// 3 = bottom trait selected (matches trait index 2, 5, 8 on <see cref="Specialization.MajorTraits"/>).
        /// </para>
        /// </remarks>
        [FieldOffset(2)]
        public byte Specialization1TraitIndices;

        /// <summary>
        /// The second specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        [FieldOffset(3)]
        public byte Specialization2Id;

        /// <summary>
        /// The second specialization trait indices in little endian format.
        /// </summary>
        /// <remarks>
        /// There are 3 trait indices, and each trait index consumes 2 bits and is 0-indexed.
        /// There is a 2 bit padding at the end to fill 1 byte.
        /// <para>
        /// The following values are possible:
        /// 0 = no trait selected.
        /// 1 = top trait selected (matches trait index 0, 3, 6 on <see cref="Specialization.MajorTraits"/>).
        /// 2 = middle trait selected (matches trait index 1, 4, 7 on <see cref="Specialization.MajorTraits"/>).
        /// 3 = bottom trait selected (matches trait index 2, 5, 8 on <see cref="Specialization.MajorTraits"/>).
        /// </para>
        /// </remarks>
        [FieldOffset(4)]
        public byte Specialization2TraitIndices;

        /// <summary>
        /// The third specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        [FieldOffset(5)]
        public byte Specialization3Id;

        /// <summary>
        /// The third specialization trait indices in little endian format.
        /// </summary>
        /// <remarks>
        /// There are 3 trait indices, and each trait index consumes 2 bits and is 0-indexed.
        /// There is a 2 bit padding at the end to fill 1 byte.
        /// <para>
        /// The following values are possible:
        /// 0 = no trait selected.
        /// 1 = top trait selected (matches trait index 0, 3, 6 on <see cref="Specialization.MajorTraits"/>).
        /// 2 = middle trait selected (matches trait index 1, 4, 7 on <see cref="Specialization.MajorTraits"/>).
        /// 3 = bottom trait selected (matches trait index 2, 5, 8 on <see cref="Specialization.MajorTraits"/>).
        /// </para>
        /// </remarks>
        [FieldOffset(6)]
        public byte Specialization3TraitIndices;

        /// <summary>
        /// The terrestrial healing skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(7)]
        public ushort TerrestrialHealingSkillPaletteId;

        /// <summary>
        /// The aquatic healing skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(9)]
        public ushort AquaticHealingSkillPaletteId;

        /// <summary>
        /// The first terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(11)]
        public ushort TerrestrialUtility1SkillPaletteId;

        /// <summary>
        /// The first aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(13)]
        public ushort AquaticUtility1SkillPaletteId;

        /// <summary>
        /// The second terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(15)]
        public ushort TerrestrialUtility2SkillPaletteId;

        /// <summary>
        /// The second aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(17)]
        public ushort AquaticUtility2SkillPaletteId;

        /// <summary>
        /// The third terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(19)]
        public ushort TerrestrialUtility3SkillPaletteId;

        /// <summary>
        /// The third aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(21)]
        public ushort AquaticUtility3SkillPaletteId;

        /// <summary>
        /// The terrestrial elite skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(23)]
        public ushort TerrestrialEliteSkillPaletteId;

        /// <summary>
        /// The aquatic elite skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(25)]
        public ushort AquaticEliteSkillPaletteId;

        // -- START UNION: RANGER --

        /// <summary>
        /// The first ranger terrestrial pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        [FieldOffset(27)]
        public byte RangerTerrestrialPet1Id;

        /// <summary>
        /// The second ranger terrestrial pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        [FieldOffset(28)]
        public byte RangerTerrestrialPet2Id;

        /// <summary>
        /// The first ranger aquatic pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        [FieldOffset(29)]
        public byte RangerAquaticPet1Id;

        /// <summary>
        /// The second ranger aquatic pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        [FieldOffset(30)]
        public byte RangerAquaticPet2Id;

        // -- END UNION: RANGER --
        // -- START UNION: REVENANT --

        /// <summary>
        /// The active revenant terrestrial legend id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Legends"/> if used as string, or on <see cref="WebApi.V2.Models.Legend.Code"/> if used as byte.
        /// </summary>
        [FieldOffset(27)]
        public byte RevenantActiveTerrestrialLegend;

        /// <summary>
        /// The inactive revenant terrestrial legend id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Legends"/> if used as string, or on <see cref="WebApi.V2.Models.Legend.Code"/> if used as byte.
        /// </summary>
        [FieldOffset(28)]
        public byte RevenantInactiveTerrestrialLegend;

        /// <summary>
        /// The active revenant aquatic legend id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Legends"/> if used as string, or on <see cref="WebApi.V2.Models.Legend.Code"/> if used as byte.
        /// </summary>
        [FieldOffset(29)]
        public byte RevenantActiveAquaticLegend;

        /// <summary>
        /// The inactive revenant aquatic legend id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Legends"/> if used as string, or on <see cref="WebApi.V2.Models.Legend.Code"/> if used as byte.
        /// </summary>
        [FieldOffset(30)]
        public byte RevenantInactiveAquaticLegend;

        /// <summary>
        /// The first inactive revenant terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(31)]
        public ushort RevenantInactiveTerrestrialUtility1SkillPaletteId;

        /// <summary>
        /// The second inactive revenant terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(33)]
        public ushort RevenantInactiveTerrestrialUtility2SkillPaletteId;

        /// <summary>
        /// The third inactive revenant terrestrial utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(35)]
        public ushort RevenantInactiveTerrestrialUtility3SkillPaletteId;

        /// <summary>
        /// The first inactive revenant aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(37)]
        public ushort RevenantInactiveAquaticUtility1SkillPaletteId;

        /// <summary>
        /// The second inactive revenant aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(39)]
        public ushort RevenantInactiveAquaticUtility2SkillPaletteId;

        /// <summary>
        /// The third inactive revenant aquatic utility skill palette id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/> on <see cref="WebApi.V2.Models.Profession.SkillsByPalette"/>.
        /// </summary>
        [FieldOffset(41)]
        public ushort RevenantInactiveAquaticUtility3SkillPaletteId;

        // -- END UNION: REVENANT --
    }
}
