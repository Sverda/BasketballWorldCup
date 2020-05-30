using System.Collections.Generic;

namespace BasketballWorldCup.Model.Competition
{
    public class GroupSummary
    {
        public string Letter { get; set; }

        public ICollection<TeamSummary> Summaries { get; set; }
    }
}
