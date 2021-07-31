using System;
using System.IO.MemoryMappedFiles;
using System.Net.Sockets;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble;
using Gw2Sharp.Mumble.Models;
using Xunit;

namespace Gw2Sharp.Tests.Mumble
{
    public class Gw2MumbleClientReaderTests
    {
        private bool isWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;

        [Fact]
        public void ThrowsPlatformNotSupportedExceptionIfNotWindowsTest()
        {
            Action createClient = () =>
            {
                using var reader = new Gw2MumbleClientReader();
            };

            if (this.isWindows)
                createClient.Should().NotThrow<PlatformNotSupportedException>();
            else
                createClient.Should().Throw<PlatformNotSupportedException>();
        }

        [SkippableFact]
        public unsafe void ReadStructCorrectlyTest()
        {
            // Named memory mapped files aren't supported on Unix based systems.
            // So we need to skip this test.
            Skip.IfNot(this.isWindows, "Mumble Link is only supported on Windows");

            using var memorySource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Gw2Sharp.Tests.TestFiles.Mumble.MemoryMappedFile.bin");
            using var memoryMappedFile = MemoryMappedFile.CreateOrOpen(Gw2MumbleClient.DEFAULT_MUMBLE_LINK_MAP_NAME, memorySource.Length);
            using var stream = memoryMappedFile.CreateViewStream();
            memorySource.CopyTo(stream);

            using var client = new Gw2MumbleClientReader();
            client.Open(Gw2MumbleClient.DEFAULT_MUMBLE_LINK_MAP_NAME);
            var mem = client.Read();

            using (new AssertionScope())
            {
                mem.uiVersion.Should().Be(2);
                mem.uiTick.Should().Be(7244);
                mem.fAvatarPosition[0].Should().BeApproximately(-68.27287f, 5);
                mem.fAvatarPosition[1].Should().BeApproximately(119.209f, 3);
                mem.fAvatarPosition[2].Should().BeApproximately(-6.154798f, 6);
                mem.fAvatarFront[0].Should().BeApproximately(0.8834972f, 7);
                mem.fAvatarFront[1].Should().BeApproximately(0f, 5);
                mem.fAvatarFront[2].Should().BeApproximately(-0.4684365f, 7);
                new string(mem.name).Should().BeEquivalentTo(Gw2MumbleClient.MUMBLE_LINK_GAME_NAME_GUILD_WARS_2);
                mem.fCameraPosition[0].Should().BeApproximately(-78.08988f, 5);
                mem.fCameraPosition[1].Should().BeApproximately(126.4892f, 4);
                mem.fCameraPosition[2].Should().BeApproximately(-0.2525153f, 7);
                mem.fCameraFront[0].Should().BeApproximately(0.8136908f, 7);
                mem.fCameraFront[1].Should().BeApproximately(-0.3139677f, 7);
                mem.fCameraFront[2].Should().BeApproximately(-0.4892152f, 7);
                new string(mem.identity).Should().BeEquivalentTo(@"{""name"":""Reiga Fiercecrusher"",""profession"":2,""spec"":18,""race"":1,""map_id"":1206,""world_id"":268435460,""team_color_id"":0,""commander"":false,""map"":1206,""fov"":0.960,""uisz"":1}");
                mem.context.socketAddressFamily.Should().Be(AddressFamily.InterNetwork);
                mem.context.socketAddress4[0].Should().Be(18);
                mem.context.socketAddress4[1].Should().Be(197);
                mem.context.socketAddress4[2].Should().Be(217);
                mem.context.socketAddress4[3].Should().Be(165);
                mem.context.socketPort.Should().Be(0);
                mem.context.mapId.Should().Be(1206);
                mem.context.mapType.Should().Be((uint)MapType.PublicMini);
                mem.context.shardId.Should().Be(268435460u);
                mem.context.instance.Should().Be(0);
                mem.context.buildId.Should().Be(99552);
                mem.context.uiState.Should().Be(UiState.IsCompassRotationEnabled | UiState.DoesGameHaveFocus | UiState.IsCompetitiveMode | UiState.DoesAnyInputHaveFocus);
                mem.context.compassWidth.Should().Be(362);
                mem.context.compassHeight.Should().Be(229);
                mem.context.compassRotation.Should().BeApproximately(-2.11212f, 5);
                mem.context.playerMapX.Should().BeApproximately(14400.01f, 2);
                mem.context.playerMapY.Should().BeApproximately(18180.19f, 2);
                mem.context.mapCenterX.Should().BeApproximately(14400.01f, 2);
                mem.context.mapCenterY.Should().BeApproximately(18180.19f, 2);
                mem.context.mapScale.Should().Be(1);
                mem.context.processId.Should().Be(15101);
                mem.context.mount.Should().Be(MountType.Griffon);
            }
        }

        [SkippableFact]
        public void DisposeCorrectlyTest()
        {
            // Named memory mapped files aren't supported on Unix based systems.
            // So we need to skip this test.
            Skip.IfNot(this.isWindows, "Mumble Link is only supported in Windows");

            var reader = new Gw2MumbleClientReader();
            reader.Dispose();
            Assert.ThrowsAny<ObjectDisposedException>(() => reader.Read());
        }
    }
}
