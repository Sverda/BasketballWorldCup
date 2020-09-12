namespace BasketballWorldCup.Domain.Competition.Actions
{
    internal class PointsFoulAction : FoulAction
    {
        public override void Effect(GameStats stats, bool isHost)
        {
            base.Effect(stats, isHost);

            if (isHost)
            {
                stats.GuestPoints += 1;
            }
            else
            {
                stats.HostPoints += 1;
            }
        }
    }
}
