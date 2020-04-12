using BasketballWorldCup.Model;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Services.Abstractions
{
    public interface IDrawsService
    {
        Draw PutIntoPots(IEnumerable<Team> teams);
    }
}