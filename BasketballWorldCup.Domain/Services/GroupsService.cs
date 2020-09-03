using BasketballWorldCup.Domain.Services.Abstractions;
using BasketballWorldCup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasketballWorldCup.Model.Competition;

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
                ConstructSecondRoundGroup(
                    draw,
                    "I",
                    GetByLetter(draw, "A"),
                    GetByLetter(draw, "B")),
                ConstructSecondRoundGroup(
                    draw,
                    "J",
                    GetByLetter(draw, "C"),
                    GetByLetter(draw, "D")),
                ConstructSecondRoundGroup(
                    draw,
                    "K",
                    GetByLetter(draw, "E"),
                    GetByLetter(draw, "F")),
                ConstructSecondRoundGroup(
                    draw,
                    "L",
                    GetByLetter(draw, "G"),
                    GetByLetter(draw, "H"))
            };

        private static Group ConstructSecondRoundGroup(Draw draw, string letter, Group firstBase, Group secondBase)
        {
            var firstBests = GetTwoBestsTeams(firstBase);
            var secondBests = GetTwoBestsTeams(secondBase);
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

        public IEnumerable<Group> ConstructQuartersGroups(Draw draw) =>
            new[]
            {
                ConstructQuartersGroup(
                    draw,
                    "Q1",
                    GetByLetter(draw, "I"),
                    GetByLetter(draw, "J"),
                    true),
                ConstructQuartersGroup(
                    draw,
                    "Q2",
                    GetByLetter(draw, "I"),
                    GetByLetter(draw, "J"),
                    false),
                ConstructQuartersGroup(
                    draw,
                    "Q3",
                    GetByLetter(draw, "K"),
                    GetByLetter(draw, "L"),
                    true),
                ConstructQuartersGroup(
                    draw,
                    "Q4",
                    GetByLetter(draw, "K"),
                    GetByLetter(draw, "L"),
                    false)
            };

        private static Group ConstructQuartersGroup(Draw draw, string letter, Group firstBase, Group secondBase, bool cross)
        {
            var firstBests = GetTwoBestsTeams(firstBase);
            var secondBests = GetTwoBestsTeams(secondBase);
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
                    Team = firstBests[cross ? 0 : 1].Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = secondBests[cross ? 1 : 0].Team
                }
            };

            return group;
        }

        public IEnumerable<Group> ConstructSemiFinalsGroups(Draw draw)
        {
            return new[]
            {
                ConstructSemiFinalsGroup(
                    draw,
                    "S1",
                    GetByLetter(draw, "Q1"),
                    GetByLetter(draw, "Q2")),
                ConstructSemiFinalsGroup(
                    draw,
                    "S2",
                    GetByLetter(draw, "Q3"),
                    GetByLetter(draw, "Q4"))
            };
        }

        private static Group ConstructSemiFinalsGroup(Draw draw, string letter, Group firstBase, Group secondBase)
        {
            var firstBest = GetBestTeam(firstBase);
            var secondBest = GetBestTeam(secondBase);
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
                    Team = firstBest.Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = secondBest.Team
                }
            };

            return group;
        }

        public IEnumerable<Group> ConstructFinalsGroups(Draw draw)
        {
            return new[]
            {
                ConstructFinalsGroup(
                    draw,
                    "F1",
                    GetByLetter(draw, "S1"),
                    GetByLetter(draw, "S2"))
            };
        }

        private static Group ConstructFinalsGroup(Draw draw, string letter, Group firstBase, Group secondBase)
        {
            var firstBest = GetBestTeam(firstBase);
            var secondBest = GetBestTeam(secondBase);
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
                    Team = firstBest.Team
                },
                new TeamGroup
                {
                    Group = group,
                    Team = secondBest.Team
                }
            };

            return group;
        }

        private static TeamSummary[] GetTwoBestsTeams(Group @group) => @group.Summaries.OrderByDescending(s => s.Rank).Take(2).ToArray();

        private static TeamSummary GetBestTeam(Group @group) => @group.Summaries.OrderByDescending(s => s.Rank).First();

        private Group GetByLetter(Draw draw, string letter) => draw.Groups.Single(g => g.Letter == letter);
    }
}
