using BasketballWorldCup.Database;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly BasketballContext _context;

        public TeamsService(BasketballContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }

        public IEnumerable<Team> GetTeamsByTier(Tier tier)
        {
            return _context.Teams.Where(t => t.Tier == tier).ToList();
        }
    }
}
