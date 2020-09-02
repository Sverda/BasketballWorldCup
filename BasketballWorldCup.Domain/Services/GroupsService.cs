using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketballWorldCup.Domain.Services
{
    public class GroupsService : IGroupsService
    {
        private static Random _random;

        public GroupsService()
        {
            _random = new Random();
        }

        public IEnumerable<Group> DrawIntoGroups(Pot[] pots)
        {
            // TODO: Put one team from pot into group. Repeat. 
            var groups = FreshFirstRoundGroups().ToList();
            var firstPotsSet = new List<Pot>
            {
                pots[0],
                pots[3],
                pots[4],
                pots[7]
            };
            DrawSetIntoGroups(groups, firstPotsSet, 0);

            var secondPotsSet = new List<Pot>
            {
                pots[1],
                pots[2],
                pots[5],
                pots[6]
            };
            DrawSetIntoGroups(groups, secondPotsSet, 1);

            return groups;
        }

        private static void DrawSetIntoGroups(List<Group> groups, List<Pot> firstPotsSet, int set)
        {
            foreach (var group in groups.Where(g => groups.IndexOf(g) % 2 == set))
            {
                foreach (var pot in firstPotsSet)
                {
                    var teams = pot.TeamPots.Select(tp => tp.Team).ToArray();
                    var randomTeam = teams[_random.Next(0, teams.Length)];

                    var randomTeamPot = pot.TeamPots.Single(tp => tp.TeamId == randomTeam.Id);
                    pot.TeamPots.Remove(randomTeamPot);

                    var teamGroup = new TeamGroup
                    {
                        Group = group,
                        Team = randomTeam
                    };
                    group.TeamGroups.Add(teamGroup);
                }
            }
        }

        private static IEnumerable<Group> FreshFirstRoundGroups()
        {
            const string startingLetter = "A";
            const int groupsAmount = 8;

            var freshFirstRoundGroups = new List<Group>();
            for (var i = 0; i < groupsAmount; i++)
            {
                var group = new Group
                {
                    Letter = Encoding.ASCII.GetString(new[] { (byte)(startingLetter[0] + i) }),
                    TeamGroups = new List<TeamGroup>()
                };
                freshFirstRoundGroups.Add(group);
            }

            return freshFirstRoundGroups;
        }

        public IEnumerable<Group> ConstructSecondRoundGroups(Draw draw) =>
            new[]
            {
                ConstructGroup(
                    draw,
                    "I",
                    GetByLetter(draw, "A"),
                    GetByLetter(draw, "B")),
                ConstructGroup(
                    draw,
                    "J",
                    GetByLetter(draw, "C"),
                    GetByLetter(draw, "D")),
                ConstructGroup(
                    draw,
                    "K",
                    GetByLetter(draw, "E"),
                    GetByLetter(draw, "F")),
                ConstructGroup(
                    draw,
                    "L",
                    GetByLetter(draw, "G"),
                    GetByLetter(draw, "H"))
            };

        private static Group ConstructGroup(Draw draw, string letter, Group firstBase, Group secondBase)
        {
            var firstBests = firstBase.Summaries.OrderBy(s => s.Rank).Take(2).ToArray();
            var secondBests = secondBase.Summaries.OrderBy(s => s.Rank).Take(2).ToArray();
            var group = new Group
            {
                Draw = draw,
                Letter = letter
            };
            group.TeamGroups = new List<TeamGroup>
            {
                new TeamGroup
                {
                    Group = group,
                    Team = firstBests[0].Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = firstBests[1].Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = secondBests[0].Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = secondBests[1].Team
                },
            };

            return group;
        }

        private static Group GetByLetter(Draw draw, string letter) => draw.Groups.Single(g => g.Letter == letter);
    }
}
