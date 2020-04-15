using BasketballWorldCup.Domain.Competition.Abstractions;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Competition
{
    public class Competition : ICompetition
    {
        private readonly IMatchmake _matchmake;
        private readonly IPlay _play;

        public Competition(IMatchmake matchmake, IPlay play)
        {
            _matchmake = matchmake;
            _play = play;
        }

        public CompetitionResult Compete(Group group)
        {
            var matches = _matchmake.Matching(group);
            var matchResults = matches.Select(m => _play.Play(m));
            return new CompetitionResult
            {
                Group = group,
                MatchResults = (ICollection<MatchResult>)matchResults
            };
        }
    }
}
