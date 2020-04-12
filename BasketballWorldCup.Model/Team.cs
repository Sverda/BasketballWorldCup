using System.Collections.Generic;

namespace BasketballWorldCup.Model
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Tier Tier { get; set; }

        public QualificationZone QualificationZone { get; set; }

        public string Flag { get; set; }

        public ICollection<TeamPot> TeamPots { get; set; }
    }
}
