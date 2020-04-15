using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    public interface IPlay
    {
        MatchResult Play(Match match);
    }
}
