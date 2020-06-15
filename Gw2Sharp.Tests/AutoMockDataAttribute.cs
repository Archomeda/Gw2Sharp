using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Gw2Sharp.Tests.WebApi.Caching;
using Gw2Sharp.WebApi.Caching;

namespace Gw2Sharp.Tests
{
    public class AutoMockDataAttribute : AutoDataAttribute
    {
        public AutoMockDataAttribute() : base(() =>
            new Fixture().Customize(new CompositeCustomization(
                new MockedInstancesCustomization(),
                new AutoNSubstituteCustomization { ConfigureMembers = true }))) { }

        private class MockedInstancesCustomization : ICustomization
        {
            public void Customize(IFixture fixture) => fixture.Customizations.Add(
                new TypeRelay(typeof(ICacheMethod), typeof(TestCacheMethod)));
        }
    }
}
