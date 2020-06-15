using AutoFixture.Xunit2;

namespace Gw2Sharp.Tests
{
    public class MemberAutoMockDataAttribute : MemberAutoDataAttribute
    {
        public MemberAutoMockDataAttribute(string memberName, params object[] parameters)
            : base(new AutoMockDataAttribute(), memberName, parameters) { }
    }
}
