using BasketballWorldCup.Domain.Competition;
using BasketballWorldCup.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Points_NoMoreThan130()
        {
            // Arrange
            var group = ArrangeGroup();

            // Act
            var result = new Competition(new RoundRobinMatchmake(), new GameEngine()).Compete(group);

            // Assert
            Assert.That(result.MatchResults.Select(m => m.Guest.PointsFor), Has.None.GreaterThan(130));
            Assert.That(result.MatchResults.Select(m => m.Host.PointsFor), Has.None.GreaterThan(130));
        }

        private static Group ArrangeGroup()
        {
            var teams = new[]
            {
                new Team
                {
                    Id = 1,
                    Tier = Tier.First
                },
                new Team
                {
                    Id = 2,
                    Tier = Tier.Second
                },
                new Team
                {
                    Id = 3,
                    Tier = Tier.Third
                },
                new Team
                {
                    Id = 4,
                    Tier = Tier.Fourth
                }
            };
            var group = new Group
            {
                Id = 1,
                TeamGroups = new List<TeamGroup>()
            };
            foreach (var team in teams)
            {
                var teamGroup = new TeamGroup
                {
                    Group = group,
                    Team = team
                };
                group.TeamGroups.Add(teamGroup);
            }

            return group;
        }
    }
}