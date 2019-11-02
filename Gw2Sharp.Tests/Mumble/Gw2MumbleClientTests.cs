using System;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble;
using Gw2Sharp.Mumble.Models;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.Mumble
{
    public class Gw2MumbleClientTests
    {
        [SkippableFact]
        public void ReadStructCorrectlyTest()
        {
            // Named memory mapped files aren't supported on Unix based systems.
            // So we need to skip this test.
            Skip.IfNot(Environment.OSVersion.Platform == PlatformID.Win32NT, "Mumble Link is only supported in Windows");

            var connection = Substitute.For<IConnection>();
            var gw2Client = Substitute.For<IGw2Client>();

            using var memorySource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Gw2Sharp.Tests.TestFiles.Mumble.MemoryMappedFile.bin");
            using var memoryMappedFile = MemoryMappedFile.CreateOrOpen(Gw2MumbleClient.MUMBLE_LINK_MAP_NAME, memorySource.Length);
            using var stream = memoryMappedFile.CreateViewStream();
            memorySource.CopyTo(stream);

            using var client = new Gw2MumbleClient(connection, gw2Client);
            client.Update();
            Assert.True(client.IsAvailable);
            Assert.Equal(2, client.Version);
            Assert.Equal(7244, client.Tick);
            Assert.Equal(-68.27287, client.AvatarPosition.X, 5);
            Assert.Equal(119.209, client.AvatarPosition.Y, 3);
            Assert.Equal(-6.154798, client.AvatarPosition.Z, 6);
            Assert.Equal(0.8834972, client.AvatarFront.X, 7);
            Assert.Equal(0, client.AvatarFront.Y, 5);
            Assert.Equal(-0.4684365, client.AvatarFront.Z, 7);
            Assert.Equal(Gw2MumbleClient.MUMBLE_LINK_GAME_NAME, client.Name);
            Assert.Equal(-78.08988, client.CameraPosition.X, 5);
            Assert.Equal(126.4892, client.CameraPosition.Y, 4);
            Assert.Equal(-0.2525153, client.CameraPosition.Z, 7);
            Assert.Equal(0.8136908, client.CameraFront.X, 7);
            Assert.Equal(-0.3139677, client.CameraFront.Y, 7);
            Assert.Equal(-0.4892152, client.CameraFront.Z, 7);
            Assert.Equal("Reiga Fiercecrusher", client.CharacterName);
            Assert.Equal(Profession.Warrior, client.Profession);
            Assert.Equal("Charr", client.Race);
            Assert.Equal(18, client.Specialization);
            Assert.Equal(0, client.TeamColorId);
            Assert.False(client.IsCommander);
            Assert.Equal(0.960, client.FieldOfView);
            Assert.Equal(UiSize.Normal, client.UiSize);
            Assert.Equal("18.197.217.165", client.ServerAddress);
            Assert.Equal(0, client.ServerPort);
            Assert.Equal(1206, client.MapId);
            Assert.Equal(MapType.PublicMini, client.MapType);
            Assert.Equal(268435460u, client.ShardId);
            Assert.Equal(0u, client.Instance);
            Assert.Equal(99552, client.BuildId);
            Assert.False(client.IsMapOpen);
            Assert.False(client.IsCompassTopRight);
            Assert.True(client.IsCompassRotationEnabled);
            Assert.Equal(362, client.Compass.Width);
            Assert.Equal(229, client.Compass.Height);
            Assert.Equal(-2.11212, client.CompassRotation, 5);
            Assert.Equal(14400.01, client.PlayerLocationMap.X, 2);
            Assert.Equal(18180.19, client.PlayerLocationMap.Y, 2);
            Assert.Equal(14400.01, client.MapCenter.X, 2);
            Assert.Equal(18180.19, client.MapCenter.Y, 2);
            Assert.Equal(1, client.MapScale);
        }
    }
}
