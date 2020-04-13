using BasketballWorldCup.Database;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketballWorldCup.Domain.Services
{
    public class DrawsService : IDrawsService
    {
        private readonly BasketballContext _context;

        public DrawsService(BasketballContext context)
        {
            _context = context;
        }

        public Draw PutIntoPots(IEnumerable<int> teamsIds)
        {
            var teamsCount = teamsIds.Count();
            if (teamsCount % 4 != 0)
            {
                throw new ArgumentException($"Unequal pots with teams count of {teamsCount}");
            }

            var teams = _context.Teams.Where(t => teamsIds.Contains(t.Id)).ToList();
            var rankedTeams = teams.OrderBy(t => t.Tier);
            var groupsOfFours = rankedTeams
                .Select((team, index) => new { team, index })
                .GroupBy(g => g.index / 4, i => new TeamPot { Team = i.team });
            var pots = groupsOfFours.Select(g => new Pot { TeamPots = g.ToList() }).ToList();
            var draw = new Draw { Pots = pots };
            _context.Draws.Add(draw);
            _context.SaveChanges();
            return draw;
        }
    }
}
