using BasketballWorldCup.Domain.Competition.Abstractions;
using BasketballWorldCup.Model;
using BasketballWorldCup.Model.Competition;
using System;

namespace BasketballWorldCup.Domain.Competition
{
    public class GameEngine : IGameEngine
    {
        private readonly TimeSpan _matchDeadline = TimeSpan.FromMinutes(40);

        private readonly TimeSpan _extraTime = TimeSpan.FromMinutes(5);

        public MatchResult Play(Match match)
        {
            var generator = new ActionGenerator();
            var gameLog = new GameLog();
            var currentTeam = match.Host;
            var extraTimeCount = 0;
            while (gameLog.Stats.GameplayTime < (_matchDeadline + _extraTime * extraTimeCount))
            {
                var action = generator.FindAction(currentTeam.Tier);
                action.Effect(gameLog.Stats, IsHost(match, currentTeam));
                gameLog.Stats.GameplayTime += action.TimeConsumption;
                gameLog.ActionsGroups.Add(action);
                currentTeam = ChangeTeam(match, currentTeam);

                if (gameLog.Stats.GameplayTime >= _matchDeadline 
                    && gameLog.Stats.GuestPoints == gameLog.Stats.HostPoints)
                {
                    extraTimeCount++;
                }
            }

            return PrepareResult(match, gameLog);
        }

        private static Team ChangeTeam(Match match, Team currentTeam)
        {
            return IsHost(match, currentTeam) ? match.Guest : match.Host;
        }

        private static bool IsHost(Match match, Team currentTeam)
        {
            return match.Host.Id == currentTeam.Id;
        }


        private static MatchResult PrepareResult(Match match, GameLog gameLog)
        {
            return new MatchResult
            {
                Host = new PlayResult
                {
                    Team = match.Host,
                    PointsFor = gameLog.Stats.HostPoints,
                    PointsAgainst = gameLog.Stats.GuestPoints
                },
                Guest = new PlayResult
                {
                    Team = match.Guest,
                    PointsFor = gameLog.Stats.GuestPoints,
                    PointsAgainst = gameLog.Stats.HostPoints
                }
            };
        }
    }
}