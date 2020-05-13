namespace BasketballWorldCup.Domain.Competition.Statistics
{
    internal class TierStatistics
    {
        public double Attack { get; }

        public double Steal { get; }

        public double Foul { get; }

        public TierStatistics(double attack, double steal, double foul)
        {
            Attack = attack;
            Steal = steal;
            Foul = foul;
        }
    }
}
