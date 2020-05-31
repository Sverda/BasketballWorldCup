namespace BasketballWorldCup.Model.Competition
{
    public class TeamSummary
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public Team Team { get; set; }

        public Group Group { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int PointsForSum { get; set; }

        public int PointsAgainstSum { get; set; }
    }
}
