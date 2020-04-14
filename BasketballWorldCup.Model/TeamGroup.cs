namespace BasketballWorldCup.Model
{
    public class TeamGroup
    {
        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
