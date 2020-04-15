namespace BasketballWorldCup.Model.Competition
{
    public class MatchResult
    {
        public int Id { get; set; }

        public Team Team { get; set; }

        public int Won { get; set; }

        public int Lost { get; set; }

        public int PointsFor { get; set; }

        public int PointsAgainst { get; set; }
    }
}
