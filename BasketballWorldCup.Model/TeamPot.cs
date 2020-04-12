namespace BasketballWorldCup.Model
{
    public class TeamPot
    {
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PotId { get; set; }

        public Pot Pot { get; set; }
    }
}
