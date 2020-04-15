namespace BasketballWorldCup.Model.Competition
{
    public class Match
    {
        public int Id { get; set; }

        public Team Host { get; set; }

        public Team Guest { get; set; }
    }
}
