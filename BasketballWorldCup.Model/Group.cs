using BasketballWorldCup.Model.Competition;
using System.Collections.Generic;

namespace BasketballWorldCup.Model
{
    public class Group
    {
        public int Id { get; set; }

        public int DrawId { get; set; }

        public Draw Draw { get; set; }

        public string Letter { get; set; }

        public ICollection<TeamGroup> TeamGroups { get; set; }

        public ICollection<TeamSummary> Summaries { get; set; }
    }
}
