namespace BasketballWorldCup.Model.Competition
{
    public class MatchResult
    {
        public int Id { get; set; }

        public PlayResult Host { get; set; }

        public PlayResult Guest { get; set; }
    }
}
