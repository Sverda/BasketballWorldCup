using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    public interface ICompetition
    {
        CompetitionResult Compete(Group group);
    }
}
