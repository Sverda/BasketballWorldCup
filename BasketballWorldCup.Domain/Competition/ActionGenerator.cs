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
            var statistics = tier.GetStatistics();
            var value = random.NextDouble();
            if (value <= statistics.Attack)
            {
                value = random.NextDouble();
                if (value <= statistics.Attack)
                {
                    value = random.NextDouble();
                    if (value <= statistics.Attack)
                    {
                        return new ThreePointsAction();
                    }
                    else
                    {
                        return new TwoPointsAction();
                    }
                }
                else if (statistics.Attack < value && value <= statistics.Attack + statistics.Steal)
                {
                    return new LostBallAction();
                }
                else
                {
                    return new FoulAction();
                }
            }
            else if (statistics.Attack < value && value <= statistics.Attack + statistics.Steal)
            {
                return new LostBallAction();
            }
            else
            {
                return new FoulAction();
            }
        }
    }
}
