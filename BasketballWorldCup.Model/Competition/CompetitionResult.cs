using System.Collections.Generic;

namespace BasketballWorldCup.Model.Competition
{
    public class CompetitionResult
    {
        public int Id { get; set; }

        public Group Group { get; set; }

        public ICollection<PlayResult> PlayResults { get; set; }
    }
}
