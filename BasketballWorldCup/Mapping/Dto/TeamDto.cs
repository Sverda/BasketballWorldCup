using BasketballWorldCup.Model;

namespace BasketballWorldCup.Mapping.Dto
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Tier Tier { get; set; }

        public string QualificationZone { get; set; }
    }
}
