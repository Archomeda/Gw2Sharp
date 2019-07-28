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
        [Fact]
        public void ReadStructCorrectlyTest()
        {
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
            Assert.Equal(1771, client.Tick);
            Assert.Equal(-81.71323, client.AvatarPosition.X, 5);
            Assert.Equal(128.4586, client.AvatarPosition.Y, 4);
            Assert.Equal(-16.58734, client.AvatarPosition.Z, 5);
            Assert.Equal(0.9798555, client.AvatarFront.X, 7);
            Assert.Equal(0, client.AvatarFront.Y, 5);
            Assert.Equal(0.1997077, client.AvatarFront.Z, 7);
            Assert.Equal(Gw2MumbleClient.MUMBLE_LINK_GAME_NAME, client.Name);
            Assert.Equal(-81.45905, client.CameraPosition.X, 5);
            Assert.Equal(140.1803, client.CameraPosition.Y, 4);
            Assert.Equal(-9.959071, client.CameraPosition.Z, 6);
            Assert.Equal(-0.02423627, client.CameraFront.X, 8);
            Assert.Equal(-0.7745691, client.CameraFront.Y, 7);
            Assert.Equal(-0.6320248, client.CameraFront.Z, 7);
            Assert.Equal("Reiga Fiercecrusher", client.CharacterName);
            Assert.Equal("Warrior", client.Profession);
            Assert.Equal("Charr", client.Race);
            Assert.Equal(0, client.TeamColorId);
            Assert.False(client.IsCommander);
            Assert.Equal(0.977, client.FieldOfView);
            Assert.Equal(UiSize.Normal, client.UiSize);
            Assert.Equal("35.156.132.82", client.ServerAddress);
            Assert.Equal(0, client.ServerPort);
            Assert.Equal(1206, client.MapId);
            Assert.Equal(MapType.PublicMini, client.MapType);
            Assert.Equal(268435461u, client.ShardId);
            Assert.Equal(0u, client.Instance);
            Assert.Equal(97999, client.BuildId);
        }
    }
}
