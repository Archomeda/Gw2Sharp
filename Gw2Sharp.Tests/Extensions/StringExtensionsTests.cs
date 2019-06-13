using Gw2Sharp.Extensions;
using Xunit;

namespace Gw2Sharp.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void GetSha1HashTest()
        {
            string str = "Grenk!";
            string expected = "256A07822E45D36ABD1837D42E65A456E7872932";
            string actual = str.GetSha1Hash();

            Assert.Equal(expected, actual);
        }
    }
}
