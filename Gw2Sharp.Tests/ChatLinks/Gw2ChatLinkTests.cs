using Gw2Sharp.ChatLinks;
using Xunit;

namespace Gw2Sharp.Tests.ChatLinks
{
    public class Gw2ChatLinkTests
    {
        protected void AssertChatLinkString(string expected, IGw2ChatLink chatLinkObject)
        {
            Assert.Equal(expected, chatLinkObject.ToString());
        }

        protected void AssertChatLinkObject(string chatLink, IGw2ChatLink expected)
        {
            var actual = Gw2ChatLink.Parse(chatLink);
            Assert.Equal(expected, actual);

            bool isValid = Gw2ChatLink.TryParse(chatLink, out actual);
            Assert.True(isValid);
            Assert.Equal(expected, actual);
        }
    }
}
