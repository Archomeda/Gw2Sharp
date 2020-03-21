using System;
using Gw2Sharp.Json.Converters;
using Gw2Sharp.WebApi.V2.Models;
using Xunit;

namespace Gw2Sharp.Tests.Json.Converters
{
    public class PvpSeasonLeaderboardSettingsTierRangeConverterTests
    {
        [Fact]
        public void NoWriteTest()
        {
            var converter = new PvpSeasonLeaderboardSettingsTierRangeConverter();
            Assert.Throws<NotImplementedException>(() => converter.Write(default!, default!, default!));
        }

        [Fact]
        public void CanConvertTest()
        {
            var converter = new PvpSeasonLeaderboardSettingsTierRangeConverter();
            Assert.True(converter.CanConvert(typeof(PvpSeasonLeaderboardSettingsTierRange)));
        }
    }
}
