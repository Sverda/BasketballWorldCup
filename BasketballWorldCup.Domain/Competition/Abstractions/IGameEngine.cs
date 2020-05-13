using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    public interface IGameEngine
    {
        MatchResult Play(Match match);
    }
}
