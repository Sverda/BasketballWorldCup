using System;
using Action = BasketballWorldCup.Domain.Competition.Abstractions.Action;

namespace BasketballWorldCup.Domain.Competition.Actions
{
    internal class FoulAction : Action
    {
        public override TimeSpan TimeConsumption { get; } = TimeSpan.FromMinutes(1);

        public override void Effect(GameStats stats, bool isHost)
        {
            if (isHost)
            {
                stats.HostFouls += 1;
            }
            else
            {
                stats.GuestFouls += 1;
            }
        }
    }
}
