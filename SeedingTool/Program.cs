using BasketballWorldCup.Database;
using BasketballWorldCup.Model;
using Microsoft.EntityFrameworkCore;
using SeedingTool.HtmlTeamsData.Helpers;

namespace SeedingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedTeams();
            PatchAmpersandInUrl();
        }

        private static void SeedTeams()
        {
            var options = new DbContextOptionsBuilder<BasketballContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BasketballWorldCup;Trusted_Connection=True;")
                .Options;
            using var context = new BasketballContext(options);
            using var transaction = context.Database.BeginTransaction();

            var africaMapper = new HtmlTeamMapper("./HtmlTeamsData/AfricaTeams.html", QualificationZone.Africa);
            var africaTeams = africaMapper.MapHtmlIntoTeamsModel();
            context.Teams.AddRange(africaTeams);

            var americasMapper = new HtmlTeamMapper("./HtmlTeamsData/AmericasTeams.html", QualificationZone.Americas);
            var americasTeams = americasMapper.MapHtmlIntoTeamsModel();
            context.Teams.AddRange(americasTeams);

            var asiaMapper = new HtmlTeamMapper("./HtmlTeamsData/AsiaTeams.html", QualificationZone.AsiaAndOceania);
            var asiaTeams = asiaMapper.MapHtmlIntoTeamsModel();
            context.Teams.AddRange(asiaTeams);

            var europeMapper = new HtmlTeamMapper("./HtmlTeamsData/EuropeTeams.html", QualificationZone.Europe);
            var europeTeams = europeMapper.MapHtmlIntoTeamsModel();
            context.Teams.AddRange(europeTeams);

            context.SaveChanges();
            transaction.Commit();
        }

        private static void PatchAmpersandInUrl()
        {
            var options = new DbContextOptionsBuilder<BasketballContext>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BasketballWorldCup;Trusted_Connection=True;")
                .Options;
            using var context = new BasketballContext(options);
            using var transaction = context.Database.BeginTransaction();

            foreach (var team in context.Teams)
            {
                if (!team.Flag.Contains("amp;"))
                {
                    continue;
                }

                team.Flag = team.Flag.Replace("amp;", string.Empty);
            }

            context.SaveChanges();
            transaction.Commit();
        }
    }
}
