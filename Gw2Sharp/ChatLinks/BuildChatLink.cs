using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Gw2Sharp.ChatLinks.Internal;
using Gw2Sharp.Models;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.ChatLinks
{
    /// <summary>
    /// Represents a Guild Wars 2 build chat link.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class BuildChatLink : Gw2ChatLink<BuildChatLinkStruct>, IEquatable<BuildChatLink>
    {
        /// <inheritdoc />
        public override ChatLinkType Type => ChatLinkType.Build;

        /// <summary>
        /// The profession.
        /// </summary>
        public ProfessionType Profession
        {
            get => this.data.Profession;
            set => this.data.Profession = value;
        }

        /// <summary>
        /// The first specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        public byte Specialization1Id
        {
            get => this.data.Specialization1Id;
            set => this.data.Specialization1Id = value;
        }

        /// <summary>
        /// The first major trait index of the first specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization1Trait1Index
        {
            get => (byte)(this.data.Specialization1TraitIndices & 0b11);
            set => this.data.Specialization1TraitIndices = (byte)((value & 0b11) | (this.data.Specialization1TraitIndices & 0b00111100));
        }

        /// <summary>
        /// The second major trait index of the first specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization1Trait2Index
        {
            get => (byte)((this.data.Specialization1TraitIndices >> 2) & 0b11);
            set => this.data.Specialization1TraitIndices = (byte)(((value & 0b11) << 2) | (this.data.Specialization1TraitIndices & 0b00110011));
        }

        /// <summary>
        /// The third major trait index of the first specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization1Trait3Index
        {
            get => (byte)((this.data.Specialization1TraitIndices >> 4) & 0b11);
            set => this.data.Specialization1TraitIndices = (byte)(((value & 0b11) << 4) | (this.data.Specialization1TraitIndices & 0b00001111));
        }

        /// <summary>
        /// The second specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        public byte Specialization2Id
        {
            get => this.data.Specialization2Id;
            set => this.data.Specialization2Id = value;
        }

        /// <summary>
        /// The first major trait index of the second specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization2Trait1Index
        {
            get => (byte)(this.data.Specialization2TraitIndices & 0b11);
            set => this.data.Specialization2TraitIndices = (byte)((value & 0b11) | (this.data.Specialization2TraitIndices & 0b00111100));
        }

        /// <summary>
        /// The second major trait index of the second specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization2Trait2Index
        {
            get => (byte)((this.data.Specialization2TraitIndices >> 2) & 0b11);
            set => this.data.Specialization2TraitIndices = (byte)(((value & 0b11) << 2) | (this.data.Specialization2TraitIndices & 0b00110011));
        }

        /// <summary>
        /// The third major trait index of the second specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization2Trait3Index
        {
            get => (byte)((this.data.Specialization2TraitIndices >> 4) & 0b11);
            set => this.data.Specialization2TraitIndices = (byte)(((value & 0b11) << 4) | (this.data.Specialization2TraitIndices & 0b00001111));
        }

        /// <summary>
        /// The third specialization id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        public byte Specialization3Id
        {
            get => this.data.Specialization3Id;
            set => this.data.Specialization3Id = value;
        }

        /// <summary>
        /// The first major trait index of the third specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization3Trait1Index
        {
            get => (byte)(this.data.Specialization3TraitIndices & 0b11);
            set => this.data.Specialization3TraitIndices = (byte)((value & 0b11) | (this.data.Specialization3TraitIndices & 0b00111100));
        }

        /// <summary>
        /// The second major trait index of the third specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization3Trait2Index
        {
            get => (byte)((this.data.Specialization3TraitIndices >> 2) & 0b11);
            set => this.data.Specialization3TraitIndices = (byte)(((value & 0b11) << 2) | (this.data.Specialization3TraitIndices & 0b00110011));
        }

        /// <summary>
        /// The third major trait index of the third specialization.
        /// 0 = no trait, 1 = top trait, 2 = middle trait, 3 = bottom trait.
        /// </summary>
        public byte Specialization3Trait3Index
        {
            get => (byte)((this.data.Specialization3TraitIndices >> 4) & 0b11);
            set => this.data.Specialization3TraitIndices = (byte)(((value & 0b11) << 4) | (this.data.Specialization3TraitIndices & 0b00001111));
        }

        /// <summary>
        /// The terrestrial healing skill palette id.
        /// </summary>
        public ushort TerrestrialHealingSkillPaletteId
        {
            get => this.data.TerrestrialHealingSkillPaletteId;
            set => this.data.TerrestrialHealingSkillPaletteId = value;
        }

        /// <summary>
        /// The aquatic healing skill palette id.
        /// </summary>
        public ushort AquaticHealingSkillPaletteId
        {
            get => this.data.AquaticHealingSkillPaletteId;
            set => this.data.AquaticHealingSkillPaletteId = value;
        }

        /// <summary>
        /// The first terrestrial utility skill palette id.
        /// </summary>
        public ushort TerrestrialUtility1SkillPaletteId
        {
            get => this.data.TerrestrialUtility1SkillPaletteId;
            set => this.data.TerrestrialUtility1SkillPaletteId = value;
        }

        /// <summary>
        /// The first aquatic utility skill palette id.
        /// </summary>
        public ushort AquaticUtility1SkillPaletteId
        {
            get => this.data.AquaticUtility1SkillPaletteId;
            set => this.data.AquaticUtility1SkillPaletteId = value;
        }

        /// <summary>
        /// The second terrestrial utility skill palette id.
        /// </summary>
        public ushort TerrestrialUtility2SkillPaletteId
        {
            get => this.data.TerrestrialUtility2SkillPaletteId;
            set => this.data.TerrestrialUtility2SkillPaletteId = value;
        }

        /// <summary>
        /// The second aquatic utility skill palette id.
        /// </summary>
        public ushort AquaticUtility2SkillPaletteId
        {
            get => this.data.AquaticUtility2SkillPaletteId;
            set => this.data.AquaticUtility2SkillPaletteId = value;
        }

        /// <summary>
        /// The third terrestrial utility skill palette id.
        /// </summary>
        public ushort TerrestrialUtility3SkillPaletteId
        {
            get => this.data.TerrestrialUtility3SkillPaletteId;
            set => this.data.TerrestrialUtility3SkillPaletteId = value;
        }

        /// <summary>
        /// The third aquatic utility skill palette id.
        /// </summary>
        public ushort AquaticUtility3SkillPaletteId
        {
            get => this.data.AquaticUtility3SkillPaletteId;
            set => this.data.AquaticUtility3SkillPaletteId = value;
        }

        /// <summary>
        /// The terrestrial elite skill palette id.
        /// </summary>
        public ushort TerrestrialEliteSkillPaletteId
        {
            get => this.data.TerrestrialEliteSkillPaletteId;
            set => this.data.TerrestrialEliteSkillPaletteId = value;
        }

        /// <summary>
        /// The aquatic elite skill palette id.
        /// </summary>
        public ushort AquaticEliteSkillPaletteId
        {
            get => this.data.AquaticEliteSkillPaletteId;
            set => this.data.AquaticEliteSkillPaletteId = value;
        }

        /// <summary>
        /// The first ranger terrestrial pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        public byte RangerTerrestrialPet1Id
        {
            get => this.data.RangerTerrestrialPet1Id;
            set => this.data.RangerTerrestrialPet1Id = value;
        }

        /// <summary>
        /// The second ranger terrestrial pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        public byte RangerTerrestrialPet2Id
        {
            get => this.data.RangerTerrestrialPet2Id;
            set => this.data.RangerTerrestrialPet2Id = value;
        }

        /// <summary>
        /// The first ranger aquatic pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        public byte RangerAquaticPet1Id
        {
            get => this.data.RangerAquaticPet1Id;
            set => this.data.RangerAquaticPet1Id = value;
        }

        /// <summary>
        /// The second ranger aquatic pet id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Pets"/>.
        /// </summary>
        public byte RangerAquaticPet2Id
        {
            get => this.data.RangerAquaticPet2Id;
            set => this.data.RangerAquaticPet2Id = value;
        }

        /// <summary>
        /// The active revenant terrestrial legend id.
        /// </summary>
        public byte RevenantActiveTerrestrialLegend
        {
            get => this.data.RevenantActiveTerrestrialLegend;
            set => this.data.RevenantActiveTerrestrialLegend = value;
        }

        /// <summary>
        /// The inactive revenant terrestrial legend id.
        /// </summary>
        public byte RevenantInactiveTerrestrialLegend
        {
            get => this.data.RevenantInactiveTerrestrialLegend;
            set => this.data.RevenantInactiveTerrestrialLegend = value;
        }

        /// <summary>
        /// The active revenant aquatic legend id.
        /// </summary>
        public byte RevenantActiveAquaticLegend
        {
            get => this.data.RevenantActiveAquaticLegend;
            set => this.data.RevenantActiveAquaticLegend = value;
        }

        /// <summary>
        /// The inactive revenant aquatic legend id.
        /// </summary>
        public byte RevenantInactiveAquaticLegend
        {
            get => this.data.RevenantInactiveAquaticLegend;
            set => this.data.RevenantInactiveAquaticLegend = value;
        }

        /// <summary>
        /// The first inactive revenant terrestrial utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveTerrestrialUtility1SkillPaletteId
        {
            get => this.data.RevenantInactiveTerrestrialUtility1SkillPaletteId;
            set => this.data.RevenantInactiveTerrestrialUtility1SkillPaletteId = value;
        }

        /// <summary>
        /// The second inactive revenant terrestrial utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveTerrestrialUtility2SkillPaletteId
        {
            get => this.data.RevenantInactiveTerrestrialUtility2SkillPaletteId;
            set => this.data.RevenantInactiveTerrestrialUtility2SkillPaletteId = value;
        }

        /// <summary>
        /// The third inactive revenant terrestrial utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveTerrestrialUtility3SkillPaletteId
        {
            get => this.data.RevenantInactiveTerrestrialUtility3SkillPaletteId;
            set => this.data.RevenantInactiveTerrestrialUtility3SkillPaletteId = value;
        }

        /// <summary>
        /// The first inactive revenant aquatic utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveAquaticUtility1SkillPaletteId
        {
            get => this.data.RevenantInactiveAquaticUtility1SkillPaletteId;
            set => this.data.RevenantInactiveAquaticUtility1SkillPaletteId = value;
        }

        /// <summary>
        /// The second inactive revenant aquatic utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveAquaticUtility2SkillPaletteId
        {
            get => this.data.RevenantInactiveAquaticUtility2SkillPaletteId;
            set => this.data.RevenantInactiveAquaticUtility2SkillPaletteId = value;
        }

        /// <summary>
        /// The third inactive revenant aquatic utility skill palette id.
        /// </summary>
        public ushort RevenantInactiveAquaticUtility3SkillPaletteId
        {
            get => this.data.RevenantInactiveAquaticUtility3SkillPaletteId;
            set => this.data.RevenantInactiveAquaticUtility3SkillPaletteId = value;
        }


        #region Equality

        /// <inheritdoc />
        public override bool Equals(object? obj) =>
            obj is BuildChatLink link && this.Equals(link);

        /// <inheritdoc />
        public bool Equals(BuildChatLink? other) =>
            !(other is null) &&
            this.Type == other.Type &&
            this.Profession == other.Profession &&
            this.Specialization1Id == other.Specialization1Id &&
            this.Specialization1Trait1Index == other.Specialization1Trait1Index &&
            this.Specialization1Trait2Index == other.Specialization1Trait2Index &&
            this.Specialization1Trait3Index == other.Specialization1Trait3Index &&
            this.Specialization2Id == other.Specialization2Id &&
            this.Specialization2Trait1Index == other.Specialization2Trait1Index &&
            this.Specialization2Trait2Index == other.Specialization2Trait2Index &&
            this.Specialization2Trait3Index == other.Specialization2Trait3Index &&
            this.Specialization3Id == other.Specialization3Id &&
            this.Specialization3Trait1Index == other.Specialization3Trait1Index &&
            this.Specialization3Trait2Index == other.Specialization3Trait2Index &&
            this.Specialization3Trait3Index == other.Specialization3Trait3Index &&
            this.TerrestrialHealingSkillPaletteId == other.TerrestrialHealingSkillPaletteId &&
            this.AquaticHealingSkillPaletteId == other.AquaticHealingSkillPaletteId &&
            this.TerrestrialUtility1SkillPaletteId == other.TerrestrialUtility1SkillPaletteId &&
            this.AquaticUtility1SkillPaletteId == other.AquaticUtility1SkillPaletteId &&
            this.TerrestrialUtility2SkillPaletteId == other.TerrestrialUtility2SkillPaletteId &&
            this.AquaticUtility2SkillPaletteId == other.AquaticUtility2SkillPaletteId &&
            this.TerrestrialUtility3SkillPaletteId == other.TerrestrialUtility3SkillPaletteId &&
            this.AquaticUtility3SkillPaletteId == other.AquaticUtility3SkillPaletteId &&
            this.TerrestrialEliteSkillPaletteId == other.TerrestrialEliteSkillPaletteId &&
            this.AquaticEliteSkillPaletteId == other.AquaticEliteSkillPaletteId &&
            this.RangerTerrestrialPet1Id == other.RangerTerrestrialPet1Id &&
            this.RangerTerrestrialPet2Id == other.RangerTerrestrialPet2Id &&
            this.RangerAquaticPet1Id == other.RangerAquaticPet1Id &&
            this.RangerAquaticPet2Id == other.RangerAquaticPet2Id &&
            this.RevenantActiveTerrestrialLegend == other.RevenantActiveTerrestrialLegend &&
            this.RevenantInactiveTerrestrialLegend == other.RevenantInactiveTerrestrialLegend &&
            this.RevenantActiveAquaticLegend == other.RevenantActiveAquaticLegend &&
            this.RevenantInactiveAquaticLegend == other.RevenantInactiveAquaticLegend &&
            this.RevenantInactiveTerrestrialUtility1SkillPaletteId == other.RevenantInactiveTerrestrialUtility1SkillPaletteId &&
            this.RevenantInactiveTerrestrialUtility2SkillPaletteId == other.RevenantInactiveTerrestrialUtility2SkillPaletteId &&
            this.RevenantInactiveTerrestrialUtility3SkillPaletteId == other.RevenantInactiveTerrestrialUtility3SkillPaletteId &&
            this.RevenantInactiveAquaticUtility1SkillPaletteId == other.RevenantInactiveAquaticUtility1SkillPaletteId &&
            this.RevenantInactiveAquaticUtility2SkillPaletteId == other.RevenantInactiveAquaticUtility2SkillPaletteId &&
            this.RevenantInactiveAquaticUtility3SkillPaletteId == other.RevenantInactiveAquaticUtility3SkillPaletteId;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Type);
            hash.Add(this.Profession);
            hash.Add(this.Specialization1Id);
            hash.Add(this.Specialization1Trait1Index);
            hash.Add(this.Specialization1Trait2Index);
            hash.Add(this.Specialization1Trait3Index);
            hash.Add(this.Specialization2Id);
            hash.Add(this.Specialization2Trait1Index);
            hash.Add(this.Specialization2Trait2Index);
            hash.Add(this.Specialization2Trait3Index);
            hash.Add(this.Specialization3Id);
            hash.Add(this.Specialization3Trait1Index);
            hash.Add(this.Specialization3Trait2Index);
            hash.Add(this.Specialization3Trait3Index);
            hash.Add(this.TerrestrialHealingSkillPaletteId);
            hash.Add(this.AquaticHealingSkillPaletteId);
            hash.Add(this.TerrestrialUtility1SkillPaletteId);
            hash.Add(this.AquaticUtility1SkillPaletteId);
            hash.Add(this.TerrestrialUtility2SkillPaletteId);
            hash.Add(this.AquaticUtility2SkillPaletteId);
            hash.Add(this.TerrestrialUtility3SkillPaletteId);
            hash.Add(this.AquaticUtility3SkillPaletteId);
            hash.Add(this.TerrestrialEliteSkillPaletteId);
            hash.Add(this.AquaticEliteSkillPaletteId);
            hash.Add(this.RangerTerrestrialPet1Id);
            hash.Add(this.RangerTerrestrialPet2Id);
            hash.Add(this.RangerAquaticPet1Id);
            hash.Add(this.RangerAquaticPet2Id);
            hash.Add(this.RevenantActiveTerrestrialLegend);
            hash.Add(this.RevenantInactiveTerrestrialLegend);
            hash.Add(this.RevenantActiveAquaticLegend);
            hash.Add(this.RevenantInactiveAquaticLegend);
            hash.Add(this.RevenantInactiveTerrestrialUtility1SkillPaletteId);
            hash.Add(this.RevenantInactiveTerrestrialUtility2SkillPaletteId);
            hash.Add(this.RevenantInactiveTerrestrialUtility3SkillPaletteId);
            hash.Add(this.RevenantInactiveAquaticUtility1SkillPaletteId);
            hash.Add(this.RevenantInactiveAquaticUtility2SkillPaletteId);
            hash.Add(this.RevenantInactiveAquaticUtility3SkillPaletteId);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The first <see cref="BuildChatLink"/>.</param>
        /// <param name="right">The second <see cref="BuildChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(BuildChatLink left, BuildChatLink right) =>
            EqualityComparer<BuildChatLink>.Default.Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The first <see cref="BuildChatLink"/>.</param>
        /// <param name="right">The second <see cref="BuildChatLink"/>.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(BuildChatLink left, BuildChatLink right) =>
            !(left == right);

        #endregion
    }
}
