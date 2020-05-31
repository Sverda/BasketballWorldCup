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

        public IEnumerable<GroupResult> GroupsSummaries(IEnumerable<GroupResult> groupResults)
        {
            return groupResults
                .Select(GroupSummary)
                .ToList();
        }

        private GroupResult GroupSummary(GroupResult groupResult)
        {
            var teamSummaries = groupResult.Group.TeamGroups
                .Select(tg => tg.Team)
                .Select(team => new TeamSummary { Team = team, Group = groupResult.Group })
                .ToList();
            foreach (var matchResult in groupResult.MatchResults)
            {
                var hostSummary = teamSummaries.Single(s => s.Team.Id == matchResult.Host.Team.Id);
                MatchSummary(hostSummary, matchResult.Host);
                var guestSummary = teamSummaries.Single(s => s.Team.Id == matchResult.Guest.Team.Id);
                MatchSummary(guestSummary, matchResult.Guest);
            }

            teamSummaries = RankByPoints(teamSummaries).ToList();
            teamSummaries = teamSummaries.OrderBy(s => s.Loses).ToList();
            _context.TeamSummaries.AddRange(teamSummaries);
            _context.SaveChanges();
            groupResult.Summaries = teamSummaries;
            return groupResult;
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

        private static IEnumerable<TeamSummary> RankByPoints(IEnumerable<TeamSummary> teamSummaries)
        {
            var rankedSummaries = teamSummaries.OrderBy(s => s.Points).ToArray();
            for (var i = 0; i < 4; i++)
            {
                var place = teamSummaries.Single(s => s.Team.Id == rankedSummaries[i].Team.Id);
                place.Rank = i + 1;
            }

            return teamSummaries;
        }
    }
}
