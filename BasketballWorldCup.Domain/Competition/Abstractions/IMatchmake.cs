using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    public interface IMatchmake
    {
        IEnumerable<Match> Matching(Group group);
    }
}
