using AutoFixture.Xunit2;

namespace Gw2Sharp.Tests
{
    public class InlineAutoMockDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMockDataAttribute(params object[] values) : base(new AutoMockDataAttribute(), values) { }
    }
}
