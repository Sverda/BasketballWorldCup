using BasketballWorldCup.Model.Competition;

namespace BasketballWorldCup.Mapping.Dto
{
    public class GroupResultDto
    {
        public string GroupLetter { get; set; }

        public MatchResultDto[] MatchResults { get; set; }

        public TeamSummary[] Summaries { get; set; }
    }
}
