using System;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble.Models;
using Gw2Sharp.WebApi.V2;

namespace Gw2Sharp.Mumble
{
    /// <summary>
    /// An interface for the client implementation of the Guild Wars 2 Mumble Link API service.
    /// </summary>
    public interface IGw2MumbleClient : IClient, IDisposable
    {
        /// <summary>
        /// Whether the Guild Wars 2 Mumble Link API is available or not.
        /// Use this to check if the Mumble Link API contains valid Guild Wars 2 data.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// The Mumble Link communication version.
        /// Should be equal to 2.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// The current Mumble Link tick number.
        /// Every update to the Mumble Link from Guild Wars 2 increments this value.
        /// </summary>
        int Tick { get; }

        /// <summary>
        /// The game name.
        /// Should be equal to "Guild Wars 2" when Guild Wars 2 is running.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The character's position in the current map.
        /// These coordinates are left-handed.
        /// </summary>
        Coordinates3 AvatarPosition { get; }

        /// <summary>
        /// The vector pointing out of the character's eyes.
        /// These coordinates are left-handed.
        /// </summary>
        Coordinates3 AvatarFront { get; }

        /// <summary>
        /// The camera's position in the current map.
        /// These coordinates are left-handed.
        /// </summary>
        Coordinates3 CameraPosition { get; }

        /// <summary>
        /// The vector pointing out of the camera.
        /// These coordinates are left-handed.
        /// </summary>
        Coordinates3 CameraFront { get; }

        /// <summary>
        /// The server address the client is currently connected to.
        /// This value has always been IPv4 so far.
        /// However, this value may also be IPv6 if ArenaNet decides to support that.
        /// </summary>
        string ServerAddress { get; }

        /// <summary>
        /// The server port the client is currently connected to.
        /// </summary>
        ushort ServerPort { get; }

        /// <summary>
        /// The Guild Wars 2 client build id.
        /// </summary>
        int BuildId { get; }

        /// <summary>
        /// Whether the map is currently open.
        /// </summary>
        bool IsMapOpen { get; }

        /// <summary>
        /// Whether the compass is positioned in the top right corner.
        /// Otherwise it's in the bottom right corner.
        /// </summary>
        bool IsCompassTopRight { get; }

        /// <summary>
        /// Whether the compass has rotation mode enabled.
        /// </summary>
        bool IsCompassRotationEnabled { get; }

        /// <summary>
        /// Whether the game window currently has focus.
        /// </summary>
        bool DoesGameHaveFocus { get; }

        /// <summary>
        /// Whether the map the player is currently in, is a competitive mode map.
        /// </summary>
        bool IsCompetitiveMode { get; }

        /// <summary>
        /// Whether any textbox input field has focus.
        /// </summary>
        bool DoesAnyInputHaveFocus { get; }

        /// <summary>
        /// Whether the player is currently in combat.
        /// </summary>
        bool IsInCombat { get; }

        /// <summary>
        /// The compass size.
        /// </summary>
        Size Compass { get; }

        /// <summary>
        /// The compass rotation.
        /// </summary>
        double CompassRotation { get; }

        /// <summary>
        /// The player's location on the map.
        /// This is measured in continent coordinates.
        /// </summary>
        Coordinates2 PlayerLocationMap { get; }

        /// <summary>
        /// The map center on the map.
        /// This is measured in continent coordinates.
        /// </summary>
        Coordinates2 MapCenter { get; }

        /// <summary>
        /// The map scaling.
        /// </summary>
        double MapScale { get; }

        /// <summary>
        /// The client process id.
        /// </summary>
        uint ProcessId { get; }

        /// <summary>
        /// The mount that's currently used by the player.
        /// </summary>
        MountType Mount { get; }

        /// <summary>
        /// The current map id.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Maps"/>.
        /// </summary>
        int MapId { get; }

        /// <summary>
        /// The current map type.
        /// </summary>
        MapType MapType { get; }

        // 4 MSB:
        // 0000 - Instances
        // 0001 - Generic public maps
        // 0010 - PvP maps
        // 1000 - WvW maps
        // 1100 - Edge of the Mists
        //
        // Rest:
        // 0000 - World id
        // ---- - Map number?
        /// <summary>
        /// The current shard id.
        /// </summary>
        uint ShardId { get; }

        /// <summary>
        /// The instance. Unknown.
        /// </summary>
        uint Instance { get; }

        /// <summary>
        /// The raw identity in JSON.
        /// </summary>
        string RawIdentity { get; }

        /// <summary>
        /// The character name.
        /// </summary>
        string CharacterName { get; }

        /// <summary>
        /// The character profession.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Professions"/>.
        /// </summary>
        ProfessionType Profession { get; }

        /// <summary>
        /// The character's currently equipped third specialization.
        /// Can be used to identify the elite specialization that's currently used.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Specializations"/>.
        /// </summary>
        int Specialization { get; }

        /// <summary>
        /// The character race.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Races"/>.
        /// </summary>
        RaceType Race { get; }

        /// <summary>
        /// The current team color.
        /// This value is 0 if no team color is available.
        /// Can be resolved against <see cref="IGw2WebApiV2Client.Colors"/>.
        /// </summary>
        int TeamColorId { get; }

        /// <summary>
        /// Whether the commander tag is active.
        /// </summary>
        bool IsCommander { get; }

        /// <summary>
        /// The vertical field of view value.
        /// </summary>
        double FieldOfView { get; }

        /// <summary>
        /// The UI size.
        /// </summary>
        UiSize UiSize { get; }


        /// <summary>
        /// Performs an update on the Mumble Link memory mapped file.
        /// Call this every frame and/or every time you want to update the Mumble Link data before reading.
        /// </summary>
        void Update();
    }
}
