﻿using System;
using Action = BasketballWorldCup.Domain.Competition.Abstractions.Action;

namespace BasketballWorldCup.Domain.Competition.Actions
{
    internal class TwoPointsAction : Action
    {
        public override TimeSpan TimeConsumption { get; } = TimeSpan.FromMinutes(0.5);

        public override void Effect(GameStats stats, bool isHost)
        {
            if (isHost)
            {
                stats.HostPoints += 2;
            }
            else
            {
                stats.GuestPoints += 2;
            }
        }
    }
}
