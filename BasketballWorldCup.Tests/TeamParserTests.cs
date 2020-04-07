using BasketballWorldCup.Tests.HtmlTeamsData.Helpers;
using NUnit.Framework;

namespace BasketballWorldCup.Tests
{
    public class TeamParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseFirstTeam()
        {
            HtmlDataHelper.GetAfricaHtml();
        }
    }
}