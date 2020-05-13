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
    }
}
