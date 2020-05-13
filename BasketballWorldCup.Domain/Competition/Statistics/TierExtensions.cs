using BasketballWorldCup.Model;
using System;

namespace BasketballWorldCup.Domain.Competition.Statistics
{
    internal static class TierExtensions
    {
        public static TierStatistics GetStatistics(this Tier tier)
        {
            return tier switch
            {
                Tier.First => new TierStatistics(attack: 0.7, steal: 0.25, foul: 0.05),
                Tier.Second => new TierStatistics(attack: 0.6, steal: 0.3, foul: 0.1),
                Tier.Third => new TierStatistics(attack: 0.5, steal: 0.3, foul: 0.2),
                Tier.Fourth => new TierStatistics(attack: 0.4, steal: 0.3, foul: 0.3),
                _ => throw new ArgumentOutOfRangeException(nameof(tier), tier, null)
            };
        }
    }
}
