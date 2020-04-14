using BasketballWorldCup.Model;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface IDrawsService
    {
        Draw SeedPots(IEnumerable<int> teamsIds);

        Draw AssignGroups(int drawId);
    }
}