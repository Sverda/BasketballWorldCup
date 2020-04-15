namespace BasketballWorldCup.Model.Competition
{
    public class PlayResult
    {
        public int Id { get; set; }

        public Team Team { get; set; }

        public int PointsFor { get; set; }

        public int PointsAgainst { get; set; }
    }
}
