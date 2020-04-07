using HtmlAgilityPack;

namespace BasketballWorldCup.Tests.HtmlTeamsData.Helpers
{
    public static class HtmlDataHelper
    {
        private const string _africaHtml = "./HtmlTeamsData/AfricaTeams.html";

        public static HtmlDocument GetAfricaHtml()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(_africaHtml);
            return htmlDocument;
        }
    }
}
