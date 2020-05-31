namespace BasketballWorldCup.Mapping.Dto
{
    public class TeamSummaryDto
    {
        public int Rank { get; set; }

        public string TeamName { get; set; }

        public string TeamFlag { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int PointsForSum { get; set; }

        public int PointsAgainstSum { get; set; }
    }
}
