namespace BasketballWorldCup.Model
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Tier Tier { get; set; }

        public QualificationZone QualificationZone { get; set; }
    }
}
