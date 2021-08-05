using System;
using System.Reflection;
using System.Runtime.InteropServices;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Execution;
using Gw2Sharp.Mumble;
using NSubstitute;
using Xunit;

namespace Gw2Sharp.Tests.Mumble
{
    public class Gw2MumbleClientTests
    {
        private bool isWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;

        private Gw2LinkedMem GetLinkedMem()
        {
            using var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Gw2Sharp.Tests.TestFiles.Mumble.MemoryMappedFile.bin");
            var buffer = new byte[resourceStream.Length];
            resourceStream.Read(buffer, 0, buffer.Length);

            var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                return Marshal.PtrToStructure<Gw2LinkedMem>(handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }
        }

        [Fact]
        public void ReadsCorrectlyTest()
        {
            using var reader = Substitute.For<IGw2MumbleClientReader>();
            reader.IsOpen.Returns(false);
            reader.Read().Returns(GetLinkedMem());

            using (var client = new Gw2MumbleClient(_ => reader))
            {
                client.Update();

                reader.Received(1).Open();
                reader.Received(1).Read();
            }

            reader.Received(1).Dispose();
        }

        [Fact]
        public void DisposeCorrectlyTest()
        {
            using var reader = Substitute.For<IGw2MumbleClientReader>();
            var client = new Gw2MumbleClient(_ => reader);
            client.Dispose();

            Action act = () => client.Update();
            act.Should().Throw<ObjectDisposedException>();
        }

        [Fact]
        public void DisposeChildOnlyCorrectlyTest()
        {
            using var reader = Substitute.For<IGw2MumbleClientReader>();
            using var rootClient = new Gw2MumbleClient(_ => reader);
            var childClientA = rootClient["CinderSteeltemper"];
            var childClientB = rootClient["VishenSteelshot"];
            childClientA.Dispose();

            using (new AssertionScope())
            {
                Action actRoot = () => rootClient.Update();
                Action actChildA = () => childClientA.Update();
                Action actChildB = () => childClientB.Update();

                // Only child A should be disposed
                actRoot.Should().NotThrow();
                actChildA.Should().Throw<ObjectDisposedException>();
                actChildB.Should().NotThrow();
            }
        }

        [Fact]
        public void DisposeAllFromRootCorrectlyTest()
        {
            using var reader = Substitute.For<IGw2MumbleClientReader>();
            var rootClient = new Gw2MumbleClient(_ => reader);
            var childClientA = rootClient["CinderSteeltemper"];
            var childClientB = rootClient["VishenSteelshot"];
            rootClient.Dispose();

            using (new AssertionScope())
            {
                Action actRoot = () => rootClient.Update();
                Action actChildA = () => childClientA.Update();
                Action actChildB = () => childClientB.Update();

                // Everything should be disposed
                actRoot.Should().Throw<ObjectDisposedException>();
                actChildA.Should().Throw<ObjectDisposedException>();
                actChildB.Should().Throw<ObjectDisposedException>();
            }
        }

        [Theory]
        [AutoData]
        public void UsesSameInstanceForSameNamesTest(string mumbleLinkName)
        {
            using var client = new Gw2MumbleClient(x => Substitute.For<IGw2MumbleClientReader>());
            var childClientA = client[mumbleLinkName];
            var childClientB = client[mumbleLinkName];
            var childClientAA = childClientA[mumbleLinkName];

            using (new AssertionScope())
            {
                childClientA.Should().BeSameAs(childClientB);
                childClientA.Should().BeSameAs(childClientAA);
            }
        }
    }
}
