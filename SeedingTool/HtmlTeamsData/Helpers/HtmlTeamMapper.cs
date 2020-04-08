using BasketballWorldCup.Model;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace SeedingTool.HtmlTeamsData.Helpers
{
    public class HtmlTeamMapper
    {
        private readonly string _htmlPath;
        private readonly QualificationZone _qualificationZone;

        public HtmlTeamMapper(string htmlPath, QualificationZone qualificationZone)
        {
            _htmlPath = htmlPath;
            _qualificationZone = qualificationZone;
        }

        public HtmlDocument GetHtml()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(_htmlPath);
            return htmlDocument;
        }

        public IEnumerable<Team> MapHtmlIntoTeamsModel()
        {
            var html = GetHtml();
            var htmlTeams = html.DocumentNode.ChildNodes.Nodes().Where(n => n.Name == "tr");

            var teamsCount = htmlTeams.Count();
            var meanTierCount = teamsCount / 4;
            var firstTierTeams = htmlTeams.Take(meanTierCount);
            var secondTierTeams = htmlTeams.Skip(meanTierCount).Take(meanTierCount);
            var thirdTierTeams = htmlTeams.Skip(2 * meanTierCount).Take(meanTierCount);
            var fourthTierTeams = htmlTeams.Skip(3 * meanTierCount);

            var parsedTeams = new List<Team>();
            parsedTeams.AddRange(firstTierTeams.Select(n => MapTeam(n, Tier.First)));
            parsedTeams.AddRange(secondTierTeams.Select(n => MapTeam(n, Tier.Second)));
            parsedTeams.AddRange(thirdTierTeams.Select(n => MapTeam(n, Tier.Third)));
            parsedTeams.AddRange(fourthTierTeams.Select(n => MapTeam(n, Tier.Fourth)));

            return parsedTeams;
        }

        private Team MapTeam(HtmlNode teamNode, Tier tier)
        {
            var teamModel = new Team
            {
                Name = teamNode.SelectNodes("td[@class=\"country has_flag\"]/span").First().InnerText,
                Flag = teamNode.SelectNodes("td[@class=\"country has_flag\"]/img").First().Attributes["src"].Value,
                QualificationZone = _qualificationZone,
                Tier = tier
            };
            return teamModel;
        }
    }
}
