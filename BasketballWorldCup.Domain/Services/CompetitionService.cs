using BasketballWorldCup.Database;
using BasketballWorldCup.Domain.Competition.Abstractions;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model.Competition;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly BasketballContext _context;
        private readonly Competition.Competition _competition;

        public CompetitionService(BasketballContext context, IMatchmake matchmake, IGameEngine gameEngine)
        {
            _context = context;
            _competition = new Competition.Competition(matchmake, gameEngine);
        }

        public IEnumerable<GroupResult> FirstRound(int drawId)
        {
            var draw = _context.Draws
                .Include(d => d.Groups)
                .ThenInclude(g => g.TeamGroups)
                .ThenInclude(tg => tg.Team)
                .Single(d => d.Id == drawId);
            return draw.Groups.ToList().Select(g => _competition.Compete(g));
        }

        public IEnumerable<GroupSummary> GroupsSummaries(IEnumerable<GroupResult> groupResults)
        {
            var groupsSummaries = new List<GroupSummary>();
            foreach (var groupResult in groupResults)
            {
                var hostNames = groupResult.MatchResults
                    .Select(mr => mr.Host.Team.Name);
                var guestNames = groupResult.MatchResults
                    .Select(mr => mr.Guest.Team.Name);
                var teamNames = hostNames.ToList();
                teamNames.AddRange(guestNames);
                var teamSummaries = teamNames
                    .Distinct()
                    .Select(teamName => new TeamSummary { TeamName = teamName })
                    .ToList();
                var groupSummary = new GroupSummary
                {
                    Letter = groupResult.Group.Letter,
                    Summaries = teamSummaries
                };
                foreach (var matchResult in groupResult.MatchResults)
                {
                    var hostSummary = groupSummary.Summaries.Single(s => s.TeamName == matchResult.Host.Team.Name);
                    MatchSummary(hostSummary, matchResult.Host);
                    var guestSummary = groupSummary.Summaries.Single(s => s.TeamName == matchResult.Guest.Team.Name);
                    MatchSummary(guestSummary, matchResult.Guest);
                }

                groupSummary = RankByPoints(groupSummary);
                groupSummary.Summaries = groupSummary.Summaries.OrderBy(s => s.Loses).ToList();
                groupsSummaries.Add(groupSummary);
            }

            return groupsSummaries;
        }

        private static void MatchSummary(TeamSummary teamSummary, PlayResult matchResult)
        {
            teamSummary.Points += 1;
            if (matchResult.PointsFor <= matchResult.PointsAgainst)
            {
                teamSummary.Loses += 1;
            }
            else
            {
                teamSummary.Wins += 1;
                teamSummary.Points += 1;
            }

            teamSummary.PointsForSum += matchResult.PointsFor;
            teamSummary.PointsAgainstSum += matchResult.PointsAgainst;
        }

        private GroupSummary RankByPoints(GroupSummary groupSummary)
        {
            var rankedSummaries = groupSummary.Summaries.OrderBy(s => s.Points).ToArray();
            for (int i = 0; i < 4; i++)
            {
                var place = groupSummary.Summaries.Single(s => s.TeamName == rankedSummaries[i].TeamName);
                place.Rank = i + 1;
            }

            return groupSummary;
        }
    }
}
