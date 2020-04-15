using BasketballWorldCup.Domain.Competition;
using BasketballWorldCup.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace Domain
{
    public class CompetitionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoundRobin_Success()
        {
            // Arrange
            var teams = new[]
            {
                new Team
                {
                    Name = "Team 1",
                    Tier = Tier.First
                },
                new Team
                {
                    Name = "Team 2",
                    Tier = Tier.Second
                },
                new Team
                {
                    Name = "Team 3",
                    Tier = Tier.Third
                },
                new Team
                {
                    Name = "Team 4",
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

            // Act
            var matches = new RoundRobinMatchmake().Matching(group);

            // Assert
            Assert.That(matches, Has.Length.EqualTo(12));
        }
    }
}