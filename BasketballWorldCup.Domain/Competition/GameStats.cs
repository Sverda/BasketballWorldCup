using System;

namespace BasketballWorldCup.Domain.Competition
{
    internal class GameStats
    {
        public int HostPoints { get; set; }

        public int GuestPoints { get; set; }

        public int HostFouls { get; set; }

        public int GuestFouls { get; set; }

        public TimeSpan GameplayTime { get; set; }
    }
}
