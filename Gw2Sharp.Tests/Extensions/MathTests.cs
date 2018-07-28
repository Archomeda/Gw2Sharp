using Gw2Sharp.Extensions;
using Xunit;

namespace Gw2Sharp.Tests.Extensions
{
    public class MathTests
    {
        [Theory]
        [InlineData(1, 5, 2, 2)]
        [InlineData(1, 5, -2, 1)]
        [InlineData(1, 5, 7, 5)]
        public void ClampTest(int min, int max, int value, int expected)
        {
            int actual = Math.Clamp(value, min, max);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 5, 2, true)]
        [InlineData(1, 5, -2, false)]
        [InlineData(1, 5, 7, false)]
        public void IsClampedTest(int min, int max, int value, bool expected)
        {
            Assert.Equal(expected, Math.IsClampedIn(value, min, max));
        }
    }
}
