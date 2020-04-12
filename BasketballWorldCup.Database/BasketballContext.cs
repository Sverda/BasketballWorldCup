using BasketballWorldCup.Model;
using Microsoft.EntityFrameworkCore;

namespace BasketballWorldCup.Database
{
    public class BasketballContext : DbContext
    {
        public DbSet<Draw> Draws { get; set; }

        public DbSet<Pot> Pots { get; set; }

        public DbSet<Team> Teams { get; set; }

        public BasketballContext(DbContextOptions<BasketballContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Draw>()
                .HasMany(d => d.Pots)
                .WithOne(p => p.Draw);

            modelBuilder.Entity<Pot>()
                .HasMany(p => p.Teams);
        }
    }
}
