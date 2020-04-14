using BasketballWorldCup.Model;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface IDrawsService
    {
        Draw PutIntoPots(IEnumerable<int> teamsIds);

        Draw FillWithGroups(int drawId);
    }
}