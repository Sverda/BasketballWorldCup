using BasketballWorldCup.Domain.Competition.Abstractions;
using BasketballWorldCup.Domain.Helpers;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Competition
{
    public class RoundRobinMatchmake : IMatchmake
    {
        public IEnumerable<Match> Matching(Group group)
        {
            var matches =
                from host in @group.TeamGroups.Select(tg => tg.Team)
                from guest in @group.TeamGroups.Select(tg => tg.Team).Where(t => t.Id != host.Id)
                select new Match { Host = host, Guest = guest };
            return matches.Distinct(new MatchComparer()).ToList();
        }
    }
}
