using BasketballWorldCup.Database;
using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using System;
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

        public IEnumerable<Team> GetTeamsByZone(QualificationZone zone)
        {
            return _context.Teams.Where(t => t.QualificationZone == zone).ToList();
        }

        public Team AddTeam(Team team)
        {
            _context.Add(team);
            _context.SaveChanges();

            return team;
        }

        public Team DeleteTeam(int teamId)
        {
            var team = _context.Teams.SingleOrDefault(t => t.Id == teamId);
            if (team is null)
            {
                throw new ArgumentOutOfRangeException(nameof(teamId), "Team not found");
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return team;
        }
    }
}
