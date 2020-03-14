using BasketballWorldCup.Model;
using Microsoft.EntityFrameworkCore;

namespace BasketballWorldCup.Database
{
    public class BasketballContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public BasketballContext(DbContextOptions<BasketballContext> options) : base(options)
        {
        }
    }
}
