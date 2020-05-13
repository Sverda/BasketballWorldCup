using BasketballWorldCup.Domain.Competition.Abstractions;
using System.Collections.Generic;

namespace BasketballWorldCup.Domain.Competition
{
    internal class GameLog
    {
        public List<Action> ActionsGroups { get; set; } = new List<Action>();

        public GameStats Stats { get; set; } = new GameStats();
    }
}
