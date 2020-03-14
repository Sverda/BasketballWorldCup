using BasketballWorldCup.Model;
using Microsoft.EntityFrameworkCore;

namespace BasketballWorldCup.Database
{
    public class BasketballContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Move to user's secret
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BasketballWorldCup;Trusted_Connection=True;");
        }
    }
}
