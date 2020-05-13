using BasketballWorldCup.Domain.Competition.Abstractions;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
using System.Linq;

namespace BasketballWorldCup.Domain.Competition
{
    public class Competition : ICompetition
    {
        private readonly IMatchmake _matchmake;
        private readonly IGameEngine _gameEngine;

        public Competition(IMatchmake matchmake, IGameEngine gameEngine)
        {
            _matchmake = matchmake;
            _gameEngine = gameEngine;
        }

        public GroupResult Compete(Group group)
        {
            var matches = _matchmake.Matching(group);
            var matchResults = matches.Select(m => _gameEngine.Play(m)).ToList();
            return new GroupResult
            {
                Group = group,
                MatchResults = matchResults
            };
        }
    }
}
