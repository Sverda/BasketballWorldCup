using BasketballWorldCup.Domain.Competition.Actions;
using BasketballWorldCup.Domain.Competition.Statistics;
using BasketballWorldCup.Model;
using System;
using Action = BasketballWorldCup.Domain.Competition.Abstractions.Action;

namespace BasketballWorldCup.Domain.Competition
{
    internal class ActionGenerator
    {
        public Action FindAction(Tier tier)
        {
            var random = new Random();
            // Pobranie prawdopodobieństw na zaistnienie poszczególnych akcji
            var statistics = tier.GetStatistics();
            // Losowanie liczby z przedziału od 0 do 1
            var value = random.NextDouble();
            if (value <= statistics.Attack)
            {
                value = random.NextDouble();
                if (value <= statistics.Attack)
                {
                    value = random.NextDouble();
                    if (value <= statistics.Attack)
                    {
                        // Wybranie akcji ataku za trzy punkty
                        return new ThreePointsAction();
                    }
                    else
                    {
                        // Wybranie akcji ataku za dwa punkty
                        return new TwoPointsAction();
                    }
                }
                else if (statistics.Attack < value && value <= statistics.Attack + statistics.Steal)
                {
                    // Wybranie akcji utracenia piłki
                    return new LostBallAction();
                }
                else
                {
                    // Wybranie akcji faulu
                    return new FoulAction();
                }
            }
            else if (statistics.Attack < value && value <= statistics.Attack + statistics.Steal)
            {
                // Wybranie akcji utracenia piłki
                return new LostBallAction();
            }
            else
            {
                // Wybranie akcji faulu
                return new FoulAction();
            }
        }
    }
}
