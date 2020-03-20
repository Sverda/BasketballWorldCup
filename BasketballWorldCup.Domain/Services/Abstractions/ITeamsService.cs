using BasketballWorldCup.Model;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface ITeamsService
    {
        IEnumerable<Team> GetTeams();

        IEnumerable<Team> GetTeamsByTier(Tier tier);
        void AddTeam(Team team);
    }
}
