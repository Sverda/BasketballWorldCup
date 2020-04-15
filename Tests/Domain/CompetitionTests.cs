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
                    Id = 1
                },
                new Team
                {
                    Id = 2
                },
                new Team
                {
                    Id = 3
                },
                new Team
                {
                    Id = 4
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
            Assert.That(matches, Has.Count.EqualTo(12));
        }
    }
}