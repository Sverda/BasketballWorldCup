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
    }
}
