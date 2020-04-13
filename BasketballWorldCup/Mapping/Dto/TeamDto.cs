using BasketballWorldCup.Model;

namespace BasketballWorldCup.Mapping.Dto
{
    internal class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Tier Tier { get; set; }

        public string QualificationZone { get; set; }

        public string Flag { get; set; }

        public bool IsSelected { get; set; }
    }
}
