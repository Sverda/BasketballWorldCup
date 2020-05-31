using System.Collections.Generic;

namespace BasketballWorldCup.Model.Competition
{
    public class GroupResult
    {
        public int Id { get; set; }

        public Group Group { get; set; }

        public ICollection<MatchResult> MatchResults { get; set; }

        public ICollection<TeamSummary> Summaries { get; set; }
    }
}
