using System;

namespace BasketballWorldCup.Domain.Competition.Abstractions
{
    internal abstract class Action
    {
        public int ActionsGroupId { get; set; }

        public abstract TimeSpan TimeConsumption { get; }

        public abstract void Effect(GameStats stats, bool isHost);
    }
}
