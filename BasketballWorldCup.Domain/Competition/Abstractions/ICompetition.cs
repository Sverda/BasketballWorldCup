using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    public interface ICompetition
    {
        GroupResult Compete(Group group);
    }
}
